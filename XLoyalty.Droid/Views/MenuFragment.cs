namespace <%- namespaceContext %>.Droid.Views
{
    using Android.OS;
    using Android.Runtime;
    using Android.Views;
    using Loymax.Core.Droid.Custom.Adapters;
    using Loymax.Core.Droid.ViewModels;
    using Loymax.Core.Droid.Views;
    using MvvmCross.Binding.BindingContext;
    using MvvmCross.Platforms.Android.Presenters.Attributes;
    using MvvmCross.ViewModels;
    using <%- namespaceContext %>.Core.ViewModels;
    using Google.Android.Material.Navigation;

    [MvxViewFor(typeof(MenuViewModel))]
    [MvxFragmentPresentation(typeof(MainMenuFragmentHostViewModel), Resource.Id.main_menuFragment)]
    [Register(nameof(MenuFragment))]
    public class MenuFragment : BaseFragment<MenuViewModel>
    {
        private NavigationViewAdapter navViewAdapter;

        protected override int FragmentId => Resource.Layout.menu_view;

        public override string Title { get; set; }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var navigationView = base.OnCreateView(inflater, container, savedInstanceState) as NavigationView;
            if (navigationView == null)
            {
                return null;
            }

            this.navViewAdapter = new NavigationViewAdapter(navigationView);
            navigationView.SetNavigationItemSelectedListener(this.navViewAdapter);
            var set = this.CreateBindingSet<MenuFragment, MenuViewModel>();
            set.Bind(this.navViewAdapter).For(v => v.MenuItems).To(vm => vm.Items);
            set.Bind(this.navViewAdapter).For(v => v.SelectedMenuItemCommand).To(vm => vm.ItemClickCommand);
            set.Apply();

            return navigationView;
        }

        public override void OnDestroyView()
        {
            base.OnDestroyView();
            if (this.navViewAdapter == null)
            {
                return;
            }

            this.navViewAdapter.Dispose();
            this.navViewAdapter = null;
        }
    }
}