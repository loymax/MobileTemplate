namespace <%- namespaceContext %>.iOS
{
    using Foundation;
    using Loymax.Core.iOS;
    using UIKit;

    [Register(nameof(AppDelegate))]
    public class AppDelegate : BaseAppDelegate
    {
        public override BaseIosSetup MvxIosSetup()
        {
            return new Setup(this);
        }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
#if !DEBUG
            Firebase.Core.App.Configure();
#endif
            return base.FinishedLaunching(application, launchOptions);
        }
    }
}