namespace <%- namespaceContext %>.iOS
{
    using Foundation;
    using JASidePanel.Navigation.iOS;
    using Loymax.Core.iOS;

    [Register(nameof(AppDelegate))]
    public class AppDelegate : BaseAppDelegate
    {
        public override BaseIosSetup MvxIosSetup()
        {
            return new Setup(this, new JASidebarViewPresenter(this, this.Window));
        }
    }
}