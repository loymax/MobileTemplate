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
        , WindowSoftInputMode = SoftInput.AdjustResize)]
    public class MainActivity : BaseMenuFragmentHostActivity<MainMenuFragmentHostViewModel>, FragmentManager.IOnBackStackChangedListener
    {
        private DrawerLayout _drawerLayout;
        private ActionBarDrawerToggle _drawerToggle;
        private SupportToolbar _toolbar;

        protected override FrameLayout ContentView => FindViewById<FrameLayout>(Resource.Id.main_layoutContent);

        protected override DrawerLayout DrawerLayout => _drawerLayout;

        protected override int ViewId => Resource.Layout.main_activity;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            _toolbar = FindViewById<SupportToolbar>(Resource.Id.lmx_toolbar);
            _drawerLayout = FindViewById<DrawerLayout>(Resource.Id.main_DrawerLayout);
            // Toolbar will now take on default actionbar characteristics
            SetToolBarInsets(_toolbar);
            SetSupportActionBar(_toolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowTitleEnabled(true);
            _drawerToggle = new ActionBarDrawerToggle(
                this,
                _drawerLayout,
                Resource.String.navigation_drawer_open,
				Resource.String.navigation_drawer_close)
            {
                DrawerIndicatorEnabled = true
            };
            _drawerLayout.AddDrawerListener(_drawerToggle);
            _drawerToggle.SyncState();
            SupportFragmentManager.AddOnBackStackChangedListener(this);
            ViewModel?.ShowMenuViewModel();
        }

        public void OnBackStackChanged()
        {
            SupportFragmentManager.SyncActionBarArrowState(_drawerToggle, _drawerLayout);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (_drawerToggle.OnOptionsItemSelected(item))
            {
                return true;
            }

            switch (item.ItemId)
            {
                default:
                    return OnContextItemSelected(item);
            }
        }
    }
}