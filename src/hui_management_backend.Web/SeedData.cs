
using hui_management_backend.Core.FundAggregate;
using hui_management_backend.Core.UserAggregate;
using hui_management_backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace hui_management_backend.Web;

public static class SeedData
{
  
  public static readonly Fund Fund = new Fund("Hụi ngày", "Khui vào mỗi ngày", DateTimeOffset.Now, 1500000.0, 300000.0);

  public static readonly User FundOwner = new User("khangzxrr@gmail.com", "123123aaa", "võ ngọc khang", "159 xa lộ hà nội quận 2", "MB bank", "0862106650", "0862106650", "Con của Chị Nhiễn");

  public static readonly User FundMember = new User("khang1@gmail.com", "123123aaa", "võ ngọc khang", "159 xa lộ hà nội quận 2", "MB bank", "0862106650", "0862106650", "Con của Chị Nhiễn");

  public static void Initialize(IServiceProvider serviceProvider)
  {
    using (var dbContext = new AppDbContext(
        serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null))
    {
      
      PopulateFundData(dbContext);

    }
  }

  public static void PopulateData(AppDbContext dbContext)
  {
    PopulateFundData(dbContext);
  }

  public static void PopulateFundData(AppDbContext dbContext)
  {
    if (dbContext.Funds.Any())
    {
      return;
    }

    Fund.SetOwner(FundOwner);

    dbContext.Funds.Add(Fund);

    dbContext.SaveChanges();
  }

}
