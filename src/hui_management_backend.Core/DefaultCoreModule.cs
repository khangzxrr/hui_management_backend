using Autofac;
using hui_management_backend.Core.Interfaces;
using hui_management_backend.Core.Services;

namespace hui_management_backend.Core;

public class DefaultCoreModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterType<ToDoItemSearchService>()
        .As<IToDoItemSearchService>().InstancePerLifetimeScope();

    builder.RegisterType<DeleteContributorService>()
        .As<IDeleteContributorService>().InstancePerLifetimeScope();

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
  }
}
