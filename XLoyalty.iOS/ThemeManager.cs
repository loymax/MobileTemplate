namespace <%- namespaceContext %>.iOS
{
    using Loymax.Core.iOS.Style;
    using Loymax.Core.iOS.Style.Interfaces;
    using UIKit;

    public static class ThemeManager
    {
        public static void SelfConfigureAppearance(IThemeManager themeManager)
        {
            UINavigationBar.Appearance.TintColor = UIColor.White;
            UINavigationBar.Appearance.BarStyle = UIBarStyle.Black;
            UINavigationBar.Appearance.BarTintColor = themeManager.Colors.TintColor;
            UINavigationBar.Appearance.TitleTextAttributes = new UIStringAttributes
            {
                ForegroundColor = UIColor.White
            };

            if (UIDevice.CurrentDevice.CheckSystemVersion(11, 0))
            {
                UISearchBar.Appearance.TintColor = UIColor.White;
            }

            UIApplication.SharedApplication.StatusBarStyle = UIStatusBarStyle.LightContent;
        }

        public class ThemeViewControllers : DefaultThemeViewControllers
        {
            public override void SetBarStyle(UINavigationController navController)
            {
                var navBar = navController?.NavigationBar;
                if (navBar != null)
                {
                    var attributes = new UIStringAttributes
                    {
                        ForegroundColor = UIColor.White
                    };

                    navBar.TitleTextAttributes = attributes;
                    navBar.Translucent = false;
                    navBar.BarStyle = UIBarStyle.Default;
                    navBar.TintColor = UIColor.White;
                }
            }
        }
    }
}