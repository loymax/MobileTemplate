namespace <%- namespaceContext %>.iOS
{
    using JASidePanel.Navigation.iOS;
    using System.Collections.Generic;
    using Loymax.Core;
    using Loymax.Core.iOS;
    using Loymax.Core.iOS.Extensions;
    using Loymax.Core.iOS.Style.Interfaces;
    using Loymax.Core.Modules;
    using Loymax.Support.Style.iOS.Managers;
    using Loymax.Support.Style.iOS.Settings;
    using Loymax.Core.Providers.Interfaces;
    using Loymax.Core.iOS.Implements;
    using MvvmCross;
    using MvvmCross.Binding.Bindings.Target.Construction;
    using MvvmCross.Platforms.Ios.Core;
    using MvvmCross.Platforms.Ios.Presenters;
    using MvvmCross.IoC;
    using Microsoft.Extensions.Logging;
    using Serilog;
    using Serilog.Extensions.Logging;
    using UIKit;
    using <%- namespaceContext %>.Core;
    <%- iosUsingGoogleAnalytics %>

    public class Setup : BaseIosSetup
    {
        public Setup(MvxApplicationDelegate applicationDelegate) : base(applicationDelegate) { }

        protected override IMvxIosViewPresenter CreateViewPresenter() => new JASidebarViewPresenter(ApplicationDelegate, Window);

        protected override App CreateLxApp() => new CoreApp();

        protected override IThemeManager CreateThemeManager()
        {
            var fileSettings = new RenderSettings.FileSettings("style.less");
            var settings = new RenderSettings(new List<RenderSettings.FileSettings>
            {
                fileSettings
            })
            {
                ThemeViewControllers = new ThemeManager.ThemeViewControllers(),
                ConfigureAppearance = ThemeManager.SelfConfigureAppearance
            };

#if DEBUG
            if (!string.IsNullOrEmpty(Application.StylePath) && DeviceExtension.IsEmulator)
            {
                var realtimeFileSettings = new RenderSettings.FileSettings(Application.StylePath)
                {
                    RealtimeUpdateStyle = true
                };

                settings.FilesSettings.Add(realtimeFileSettings);
            }
#endif

            LxThemeManager.Init(this.Window, settings);

            return LxThemeManager.Instance;
        }

        protected override void AddPlatformModules(ILxLoaderModuleRegistry registry)
        {
            base.AddPlatformModules(registry);
            <%- iosSetupContext %>
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