
using hui_management_backend.Core.FundAggregate;
using hui_management_backend.Core.UserAggregate;
using hui_management_backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace hui_management_backend.Web;

public static class SeedData
{
  
  public static readonly Fund Fund = new Fund("Hụi ngày", 1, 1, 0, DateTimeOffset.Now ,DateTimeOffset.Now, DateTimeOffset.Now, 1500000.0, 300000.0, FundType.DayFund);

  public static readonly User FundOwner = new User("0862106650", "123123aaa", RoleName.Owner);
  
  public static readonly User FundMember1 = new User("123123", "123123aaa", RoleName.User);
  
  public static readonly User FundMember2 = new User("123124", "123123aaa", RoleName.User);



  public static void Initialize(IServiceProvider serviceProvider)
  {
    using (var dbContext = new AppDbContext(
        serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null))
    {

      PopulateData(dbContext);

    }
  }

  public static void PopulateData(AppDbContext dbContext)
  {
    PopulateFundData(dbContext);
  }

  public static void PopulateFundData(AppDbContext dbContext)
  {

    bool hasAnyFunds = dbContext.Funds.Any();
    if (hasAnyFunds)
    {
      return;
    }


    FundOwner.AddSubUser("https://firebasestorage.googleapis.com/v0/b/test-1d90e.appspot.com/o/public%2F132-400x400.jpeg?alt=media&token=1deb6643-f519-490b-bc91-ff671d01a5ff", "34543523441", DateTimeOffset.Now, "Bình khánh Mỹ Khánh LX AG", "123123aaa", "khang võ", "võ ngọc khang", "159 xa lộ hà nội quận 2", "MB bank", "0862106650", "0862106650", "Con của Chị Nhiễn", FundOwner);

    
    var subUser1 = FundMember1.AddSubUser("https://firebasestorage.googleapis.com/v0/b/test-1d90e.appspot.com/o/public%2F132-400x400.jpeg?alt=media&token=1deb6643-f519-490b-bc91-ff671d01a5ff", "34543523441", DateTimeOffset.Now, "Bình khánh Mỹ Khánh LX AG", "123123aaa", "khang võ", "võ ngọc khang", "159 xa lộ hà nội quận 2", "MB bank", "0862106650", "0862106650", "Con của Chị Nhiễn", FundOwner);

    var subUser2 = FundMember2.AddSubUser("https://firebasestorage.googleapis.com/v0/b/test-1d90e.appspot.com/o/public%2F132-400x400.jpeg?alt=media&token=1deb6643-f519-490b-bc91-ff671d01a5ff", "12341524323", DateTimeOffset.Now, "Bình khánh Mỹ Khánh LX AG", "123123aaa", "ngọc ngạn", "nguyễn ngọc ngạn", "159 xa lộ hà nội quận 2", "MB bank", "0862106652", "0862106652", "Thích đọc truyện tranh", FundOwner);


    Fund.SetOwner(FundOwner);
    dbContext.Funds.Add(Fund);


    FundMember fundMember1 = new FundMember
    {
      subUser = subUser1,
      replicationCount = 1
    };

    FundMember fundMember2 = new FundMember
    {
      subUser = subUser2,
      replicationCount = 1
    };



    Fund.AddMember(fundMember1);
    Fund.AddMember(fundMember2);

    dbContext.SaveChanges();

  }

}
