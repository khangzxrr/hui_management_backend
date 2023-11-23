﻿
using Ardalis.SmartEnum;

namespace hui_management_backend.Core.FundAggregate;
public class NormalSessionType : SmartEnum<NormalSessionType>
{

  public static NormalSessionType Alive = new(nameof(Alive), 0);
  public static NormalSessionType Dead = new(nameof(Dead), 1);

  public static NormalSessionType Taken = new(nameof(Taken), 2);

  public static NormalSessionType FakeAlive = new(nameof(FakeAlive), 3);
  public static NormalSessionType EmergencyTaken = new(nameof(EmergencyTaken), 4);

  public static NormalSessionType FakeTaken = new(nameof(FakeTaken), 5);

  public NormalSessionType(string name, int value) : base(name, value) { }
}
