namespace <%- namespaceContext %>.Droid
{
    using Android.Content;
    using Loymax.Core;
    using Loymax.Core.Droid;
    using Loymax.Core.Modules;
    using Loymax.Core.Providers.Interfaces;
    using MvvmCross;
    using MvvmCross.IoC;    
    using Microsoft.Extensions.Logging;
    using Serilog.Extensions.Logging;
    using Serilog;
    using Loymax.Core.Droid.Implements;
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

        protected override void InitializeLastChance(IMvxIoCProvider iocProvider)
        {
            base.InitializeLastChance(iocProvider);
            <%- registerGoogleAnalytics %>
        }

        protected override ILoggerProvider CreateLogProvider()
        {
#if !RELEASE
            Mvx.IoCProvider.RegisterType<ILoggerProvider, LogProvider>();
            return new LogProvider();
#else
			return base.CreateLogProvider();
#endif
        }

        protected override ILoggerFactory CreateLogFactory()
        {
#if !RELEASE
            var loggerProviders = new LoggerProviderCollection();
            loggerProviders.AddProvider(Mvx.IoCProvider.Resolve<ILoggerProvider>());
            Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Verbose()
               .WriteTo.Providers(loggerProviders)
               .CreateLogger();

            var loggerFactory = new SerilogLoggerFactory();
            loggerFactory.AddProvider(Mvx.IoCProvider.Resolve<ILoggerProvider>());
            return loggerFactory;
#else
            return base.CreateLogFactory();
#endif
        }
    }
}