
using hui_management_backend.Core.FundAggregate;
using hui_management_backend.Core.UserAggregate;
using hui_management_backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace hui_management_backend.Web;

public static class SeedData
{
  
  public static readonly Fund Fund = new Fund("Hụi ngày", "Khui vào mỗi ngày", DateTimeOffset.Now, 1500000.0, 300000.0);

  public static readonly User FundOwner = new User("user.jpg", "khangzxrr@gmail.com", "123123aaa", "võ ngọc khang", "159 xa lộ hà nội quận 2", "MB bank", "0862106650", "0862106650", "Con của Chị Nhiễn", RoleName.Owner);

  public static readonly User FundMember1 = new User("user.jpg", "khang1@gmail.com", "123123aaa", "đoàn văn bơ", "159 xa lộ hà nội quận 2", "MB bank", "0862106651", "0862106651", "Thích ăn nhiều bơ", RoleName.User);

  public static readonly User FundMember2 = new User("user.jpg", "khang2@gmail.com", "123123aaa", "nguyễn ngọc ngạn", "159 xa lộ hà nội quận 2", "MB bank", "0862106652", "0862106652", "Thích đọc truyện tranh", RoleName.User);

  public static readonly User FundOwner2 = new User("user.jpg", "khangzxrr2@gmail.com", "123123aaa", "đoàn kim nhiễn", "159 xa lộ hà nội quận 2", "MB bank", "09123235323", "09123235323", "Nhiễn pro vip", RoleName.Owner);

  public static readonly User FundMemberOfBoth = new User("user.jpg", "khang1@gmail.com", "123123aaa", "Bùi Phạm Hà Linh", "159 xa lộ hà nội quận 2", "MB bank", "093334435312", "093334435312", "Thích ăn nhiều bơ", RoleName.User);


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

    
    FundMember1.AddCreateBy(FundOwner);
    FundMember2.AddCreateBy(FundOwner);

    FundMemberOfBoth.AddCreateBy(FundOwner);
    FundMemberOfBoth.AddCreateBy(FundOwner2);

    dbContext.Users.Add(FundMemberOfBoth);

    Fund.SetOwner(FundOwner);
    dbContext.Funds.Add(Fund);


    FundMember fundMember1 = new FundMember
    {
      User = FundMember1,
      NickName = "đoàn văn bơ-1"
    };

    FundMember fundMember2 = new FundMember
    {
      User = FundMember2,
      NickName = "nguyễn ngọc ngạn-2"
    };



    Fund.AddMember(fundMember1);
    Fund.AddMember(fundMember2);

    dbContext.SaveChanges();

  }

}
