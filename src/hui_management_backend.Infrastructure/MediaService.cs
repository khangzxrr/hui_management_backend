
using Ardalis.Result;
using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Storage;
using hui_management_backend.Core.Interfaces;
using hui_management_backend.Core.MediaAggregate;
using hui_management_backend.Core.MediaAggregate.Specifications;
using hui_management_backend.SharedKernel.Interfaces;
using hui_management_backend.Web.Constants;
using Microsoft.Extensions.Configuration;

namespace hui_management_backend.Core.Services;
public class MediaService : IMediaService
{

  private readonly IRepository<Media> _mediaRepository;
  private readonly IConfiguration _configuration;

  public MediaService(IRepository<Media> mediaRepository, IConfiguration configuration)
  {
    _configuration = configuration;
    _mediaRepository = mediaRepository;
  }

  public async Task<Result<string>> Download(string fileName)
  {
    var spec = new MediaByNameSpec(fileName);

    var media = await _mediaRepository.FirstOrDefaultAsync(spec);

    if (media == null) return Result.Error(ResponseMessageConstants.MediaNotFound);


    string? key = _configuration.GetSection("Firebase").GetSection("Storage").Value;

    if (key == null)
    {
      return Result.Error(ResponseMessageConstants.FirebaseKeyNotExist);
    }

    var config = new FirebaseAuthConfig
    {
      ApiKey = key,
      AuthDomain = _configuration.GetSection("Firebase").GetSection("auth_uri").Value,
      Providers = new FirebaseAuthProvider[]
      {
        new EmailProvider()
      },
    };


    var client = new FirebaseAuthClient(config);

    var auth = await client.SignInWithEmailAndPasswordAsync(
      _configuration.GetSection("Firebase").GetSection("upload_email").Value,
      _configuration.GetSection("Firebase").GetSection("upload_password").Value);


    var task = new FirebaseStorage(
           _configuration.GetSection("Firebase").GetSection("storage_bucket").Value,
                new FirebaseStorageOptions
                {
                  AuthTokenAsyncFactory = () => auth.User.GetIdTokenAsync(),
                  ThrowOnCancel = true
                })
      .Child("public")
      .Child(fileName)
      .GetDownloadUrlAsync();


    try
    {
      var url = await task;
      return new Result<string>(url);
    }
    catch(Exception ex)
    {
      return Result.Error(ex.Message);
    }
    


  }

  public async Task<Result<string>> Upload(Stream fileStream, string fileName)
  {
    //get fileName extension
    var fileExtension = Path.GetExtension(fileName);

    if (fileExtension == null)
    {
      return Result.Error(ResponseMessageConstants.FileExtensionNotExist);
    }

    if (fileExtension != ".jpg" && fileExtension != ".png")
    {
      return Result.Error(ResponseMessageConstants.FileExtensionNotSupport);
    }

    //generate random file name 30 chars with extension
    var newFileName = Guid.NewGuid().ToString() + fileExtension;

    string? key = _configuration.GetSection("Firebase").GetSection("Storage").Value;

    if (key == null)
    {
      return Result.Error(ResponseMessageConstants.FirebaseKeyNotExist);
    }

    var config = new FirebaseAuthConfig
    {
      ApiKey = key,
      AuthDomain = _configuration.GetSection("Firebase").GetSection("auth_uri").Value,
      Providers = new FirebaseAuthProvider[]
      {
        new EmailProvider()
      },
    };

    
    var client = new FirebaseAuthClient(config);

    var auth = await client.SignInWithEmailAndPasswordAsync(
      _configuration.GetSection("Firebase").GetSection("upload_email").Value, 
      _configuration.GetSection("Firebase").GetSection("upload_password").Value);    


    var task = new FirebaseStorage(
           _configuration.GetSection("Firebase").GetSection("storage_bucket").Value,
                new FirebaseStorageOptions
                {
        AuthTokenAsyncFactory = () => auth.User.GetIdTokenAsync(),
        ThrowOnCancel = true
      })
      .Child("public")
      .Child(newFileName)
      .PutAsync(fileStream);

    try
    {
      var downloadUrl = await task;

      Media media = new Media
      {
        name = newFileName,
      };
      await _mediaRepository.AddAsync(media);
      await _mediaRepository.SaveChangesAsync();

      return Result<string>.Success("Media/" + newFileName);

    }catch(Exception e)
    {
      return Result.Error(e.Message);
    }
  }
}
