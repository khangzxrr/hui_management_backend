
using hui_management_backend.Core.FundAggregate;
using hui_management_backend.Core.UserAggregate;
using hui_management_backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace hui_management_backend.Web;

public static class SeedData
{
  
  public static readonly Fund Fund = new Fund("Hụi ngày", "Khui vào mỗi ngày", DateTimeOffset.Now, 1500000.0, 300000.0);

  public static readonly User FundOwner = new User("0862106650", "123123aaa", RoleName.Owner);
  
  public static readonly User FundMember1 = new User("123123", "123123aaa", RoleName.User);
  
  public static readonly User FundMember2 = new User("123124", "123123aaa", RoleName.User);

  public static readonly User FundOwner2 = new User("0919092211", "123123aaa", RoleName.Owner);

  public static readonly User FundMemberOfBoth = new User("123125", "123123aaa", RoleName.User);


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

    FundOwner2.AddSubUser("https://firebasestorage.googleapis.com/v0/b/test-1d90e.appspot.com/o/public%2F132-400x400.jpeg?alt=media&token=1deb6643-f519-490b-bc91-ff671d01a5ff", "2342234334", DateTimeOffset.Now, "Bình khánh Mỹ Khánh LX AG", "123123aaa", "kim nhiễn", "đoàn kim nhiễn", "159 xa lộ hà nội quận 2", "MB bank", "09123235323", "09123235323", "Nhiễn pro vip", FundOwner2);
    
    var subUser1 = FundMember1.AddSubUser("https://firebasestorage.googleapis.com/v0/b/test-1d90e.appspot.com/o/public%2F132-400x400.jpeg?alt=media&token=1deb6643-f519-490b-bc91-ff671d01a5ff", "34543523441", DateTimeOffset.Now, "Bình khánh Mỹ Khánh LX AG", "123123aaa", "khang võ", "võ ngọc khang", "159 xa lộ hà nội quận 2", "MB bank", "0862106650", "0862106650", "Con của Chị Nhiễn", FundOwner);

    var subUser2 = FundMember2.AddSubUser("https://firebasestorage.googleapis.com/v0/b/test-1d90e.appspot.com/o/public%2F132-400x400.jpeg?alt=media&token=1deb6643-f519-490b-bc91-ff671d01a5ff", "12341524323", DateTimeOffset.Now, "Bình khánh Mỹ Khánh LX AG", "123123aaa", "ngọc ngạn", "nguyễn ngọc ngạn", "159 xa lộ hà nội quận 2", "MB bank", "0862106652", "0862106652", "Thích đọc truyện tranh", FundOwner);

    var subUserOfBoth1 = FundMemberOfBoth.AddSubUser("https://firebasestorage.googleapis.com/v0/b/test-1d90e.appspot.com/o/public%2F132-400x400.jpeg?alt=media&token=1deb6643-f519-490b-bc91-ff671d01a5ff", "213432112334", DateTimeOffset.Now, "Bình khánh Mỹ Khánh LX AG", "123123aaa", "hà linh", "Bùi Phạm Hà Linh", "159 xa lộ hà nội quận 2", "MB bank", "093334435312", "093334435312", "Thích ăn nhiều bơ", FundOwner2);

    var subUserOfBoth2 = FundMemberOfBoth.AddSubUser("https://firebasestorage.googleapis.com/v0/b/test-1d90e.appspot.com/o/public%2F132-400x400.jpeg?alt=media&token=1deb6643-f519-490b-bc91-ff671d01a5ff", "213432112334", DateTimeOffset.Now, "Bình khánh Mỹ Khánh LX AG", "123123aaa", "linhlike", "Bùi Phạm Hà Linh 2", "159 xa lộ hà nội quận 2", "MB bank", "093334435312", "093334435312", "Thích ăn nhiều bơ", FundOwner2);

    dbContext.Users.Add(FundMemberOfBoth);

    Fund.SetOwner(FundOwner);
    dbContext.Funds.Add(Fund);


    FundMember fundMember1 = new FundMember
    {
      subUser = subUser1,
      NickName = $"{subUser1.Name}-1"
    };

    FundMember fundMember2 = new FundMember
    {
      subUser = subUser2,
      NickName = $"{subUser2.Name}-2"
    };



    Fund.AddMember(fundMember1);
    Fund.AddMember(fundMember2);

    dbContext.SaveChanges();

  }

}
