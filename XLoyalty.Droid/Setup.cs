namespace <%- namespaceContext %>.Droid
{
    using Android.Content;
    using Loymax.Core;
    using Loymax.Core.Droid;
    using Loymax.Core.Modules;
    using Loymax.Core.Providers.Interfaces;
    using MvvmCross;
    using <%- namespaceContext %>.Core;
    <%- droidUsingGoogleAnalytics %>

    public class Setup : BaseDroidSetup
    {
        protected override App CreateLxApp()
        {
            return new CoreApp();
        }

        protected override void AddPlatformModules(ILxLoaderModuleRegistry registry)
        {
            base.AddPlatformModules(registry);
            <%- droidSetupContext %>
        }

        protected override void InitializeLastChance()
        {
            base.InitializeLastChance();
            <%- registerGoogleAnalytics %>
        }
    }
}