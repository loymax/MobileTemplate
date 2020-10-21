namespace <%- namespaceContext %>.Core.ViewModels
{
    using Loymax.Core.Providers.Interfaces;
    using Loymax.Core.Services.Interfaces;
    using Loymax.Core.ViewModels.Base;
    using MvvmCross.Plugin.Messenger;

    public class MenuViewModel : BaseMenuViewModel
    {
        public MenuViewModel(IMvxMessenger messenger, ICurrentUserContext userContext, ILocalizationProvider localizationProvider)
            : base(messenger, userContext, localizationProvider)
        {
        }
    }
}