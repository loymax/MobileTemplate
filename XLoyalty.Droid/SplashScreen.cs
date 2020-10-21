namespace <%- namespaceContext %>.Droid
{
    using Android.App;
    using Android.Content.PM;
    using Loymax.Core.Droid;
    using MvvmCross.Platforms.Android.Presenters.Attributes;

    [MvxActivityPresentation]
    [Activity(
        Theme = "@style/AppTheme.Splash"
        , MainLauncher = true
        , NoHistory = true
        , ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : BaseSplashScreen
    {
        public SplashScreen()
            : base (Droid.Resource.Layout.main_splash_activity)
        {
        }
    }
}