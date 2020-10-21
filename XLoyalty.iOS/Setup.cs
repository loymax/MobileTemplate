namespace <%- namespaceContext %>.iOS
{
    using System.Collections.Generic;
    using Loymax.Core;
    using Loymax.Core.iOS;
    using Loymax.Core.iOS.Extensions;
    using Loymax.Core.iOS.Style.Interfaces;
    using Loymax.Core.Modules;
    using Loymax.Support.Style.iOS.Managers;
    using Loymax.Support.Style.iOS.Settings;
    using MvvmCross.Platforms.Ios.Core;
    using MvvmCross.Platforms.Ios.Presenters;
    using UIKit;
    using <%- namespaceContext %>.Core;

    public class Setup : BaseIosSetup
    {
        public Setup(MvxApplicationDelegate applicationDelegate, IMvxIosViewPresenter presenter) : base(applicationDelegate, presenter)
        {
        }

        public Setup(MvxApplicationDelegate applicationDelegate, UIWindow window) : base(applicationDelegate, window)
        {
        }

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
    }
}