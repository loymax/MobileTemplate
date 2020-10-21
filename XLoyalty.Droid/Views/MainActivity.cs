using AndroidX.Fragment.App;

namespace <%- namespaceContext %>.Droid.Views
{
    using Android.App;
    using Android.Content.PM;
    using Android.OS;
    using Android.Views;
    using Android.Widget;
    using AndroidX.AppCompat.App;
    using AndroidX.DrawerLayout.Widget;
    using Loymax.Core.Droid.Extensions;
    using Loymax.Core.Droid.ViewModels;
    using Loymax.Core.Droid.Views;
    using MvvmCross.ViewModels;
    using FragmentManager = FragmentManager;
    using SupportToolbar = global::AndroidX.AppCompat.Widget.Toolbar;

    [MvxViewFor(typeof(MainMenuFragmentHostViewModel))]
    [Activity(Theme = "@style/AppTheme.Main"
        , LaunchMode = LaunchMode.SingleTask
        , ScreenOrientation = ScreenOrientation.Portrait
        , WindowSoftInputMode = SoftInput.StateHidden)]
    public class MainActivity : BaseMenuFragmentHostActivity<MainMenuFragmentHostViewModel>, FragmentManager.IOnBackStackChangedListener
    {
        private DrawerLayout drawerLayout;
        private ActionBarDrawerToggle drawerToggle;
        private SupportToolbar toolbar;

        protected override FrameLayout ContentView => this.FindViewById<FrameLayout>(Resource.Id.main_layoutContent);

        protected override DrawerLayout DrawerLayout => this.drawerLayout;

        protected override int ViewId => Resource.Layout.main_activity;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            this.toolbar = this.FindViewById<SupportToolbar>(Resource.Id.lmx_toolbar);
            this.drawerLayout = this.FindViewById<DrawerLayout>(Resource.Id.main_DrawerLayout);
            // Toolbar will now take on default actionbar characteristics
            this.SetSupportActionBar(this.toolbar);
            this.SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            this.SupportActionBar.SetDisplayShowTitleEnabled(true);
            this.drawerToggle = new ActionBarDrawerToggle(
                this,
                this.drawerLayout,
                Resource.String.navigation_drawer_open,
				Resource.String.navigation_drawer_close)
            {
                DrawerIndicatorEnabled = true
            };
            this.drawerLayout.AddDrawerListener(this.drawerToggle);
            this.drawerToggle.SyncState();
            this.SupportFragmentManager.AddOnBackStackChangedListener(this);
            this.ViewModel?.ShowMenuViewModel();
        }

        public void OnBackStackChanged()
        {
            this.SupportFragmentManager.SyncActionBarArrowState(this.drawerToggle, this.drawerLayout);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (this.drawerToggle.OnOptionsItemSelected(item))
            {
                return true;
            }

            switch (item.ItemId)
            {
                default:
                    return this.OnContextItemSelected(item);
            }
        }
    }
}