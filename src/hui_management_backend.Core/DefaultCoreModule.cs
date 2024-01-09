using Autofac;
using hui_management_backend.Core.Interfaces;
using hui_management_backend.Core.Services;

namespace hui_management_backend.Core;

public class DefaultCoreModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {

    builder.RegisterType<AuthenticationService>()
        .As<IAuthenticationService>().InstancePerLifetimeScope();


    builder.RegisterType<AddMemberFundService>()
        .As<IAddMemberFundService>().InstancePerLifetimeScope();

    builder.RegisterType<RemoveMemberFundService>()
        .As<IRemoveMemberFundService>().InstancePerLifetimeScope();

    builder.RegisterType<AddSessionFundService>()
        .As<IAddSessionFundService>().InstancePerLifetimeScope();

    builder.RegisterType<GetPaymentService>()
        .As<IGetPaymentService>().InstancePerLifetimeScope();

    builder.RegisterType<FundMemberValidatorService>()
        .As<IFundMemberValidatorService>().InstancePerLifetimeScope();

    builder.RegisterType<EmergencySessionCreateService>()
        .As<IEmergencySessionCreateService>().InstancePerLifetimeScope();

    builder.RegisterType<CreateFinalSettlementForDeadSessionService>()
        .As<ICreateFinalSettlementForDeadSessionService>().InstancePerLifetimeScope();

    builder.RegisterType<GetFundService>()
    .As<IGetFundService>().InstancePerLifetimeScope();

    builder.RegisterType<GetAllSubUserService>()
      .As<IGetAllSubUserService>().InstancePerLifetimeScope();

    builder.RegisterType<GetAllSubUserWithPaymentService>()
      .As<IGetAllSubUserWithPaymentService>().InstancePerLifetimeScope();

    builder.RegisterType<GetSubUserWithPaymentByIdService>() 
      .As<IGetSubUserWithPaymentByIdService>().InstancePerLifetimeScope();

    builder.RegisterType<ScanExpiredProcessingPaymentService>()
        .As<IScanExpiredProcessingPayment>().SingleInstance();



  }
}
