namespace <%- namespaceContext %>.iOS.Views
{
    using Loymax.Core.iOS.Views.Menu;
    using Loymax.Core.ViewModels.Base;
    using MvvmCross.ViewModels;
    using <%- namespaceContext %>.Core.ViewModels;

    [MvxViewFor(typeof(MenuViewModel))]
    public class MenuView : BaseMenuView<BaseMenuViewModel>
    {
    }
}