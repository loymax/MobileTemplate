namespace <%- namespaceContext %>.Droid
{
    using Android.Content;
    using Loymax.Core;
    using Loymax.Core.Droid;
    using Loymax.Core.Modules;
    using <%- namespaceContext %>.Core;

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
    }
}