namespace <%- namespaceContext %>.Core
{
    using System;
    using Loymax.Core;
    using Loymax.Core.Modules;
    using Loymax.Core.Settings.Client;

    public class CoreApp : App
    {
        public override Type MainViewModelType => typeof(Loymax.Module.Offers.ViewModels.OffersViewModel);

        protected override IClientEnvironmentSettings CreateClientSettings()
        {
            return new ClientEnvironmentSettings(typeof(CoreApp).Assembly,
#if DEBUG
                BuildEnvironmentType.Development

#elif ADHOC
                BuildEnvironmentType.Staging
#else
                BuildEnvironmentType.Production
#endif
            );
        }

        public override void LoadModules(ILxModuleManager moduleManager)
        {
            base.LoadModules(moduleManager);
            <%- coreAppContext %>
        }
    }
}