
using Ardalis.SmartEnum;

namespace hui_management_backend.Core.FundAggregate;
public class NormalSessionType : SmartEnum<NormalSessionType>
{

  public static NormalSessionType Taken = new(nameof(Taken), 2);
  public static NormalSessionType Alive = new(nameof(Alive), 0);
  public static NormalSessionType Dead = new(nameof(Dead), 1);

  public NormalSessionType(string name, int value) : base(name, value) { }
}
