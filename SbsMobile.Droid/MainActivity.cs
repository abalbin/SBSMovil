using Android.App;
using Android.Content.Res;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Widget;
using Android.OS;
using SbsMobile.Droid.Fragments;
using SbsMobile.Droid.Helpers;

namespace SbsMobile.Droid
{
    [Activity(Label = "SBS Mobile", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private MyActionBarDrawerToggle _mDrawerToggle;
        private string _mDrawerTitle;
        private string _mTitle;
        private DrawerLayout _mDrawer;
        private ListView _mDrawerList;
        private static readonly string[] Sections =
        {
            "Tipo de Cambio"
        };

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            _mTitle = _mDrawerTitle = Title;

            _mDrawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            _mDrawerList = FindViewById<ListView>(Resource.Id.left_drawer);

            _mDrawerList.Adapter = new ArrayAdapter<string>(this, Resource.Layout.item_menu, Sections);

            _mDrawerList.ItemClick += (sender, args) => ListItemClicked(args.Position);

            _mDrawer.SetDrawerShadow(Resource.Drawable.drawer_shadow, (int)GravityFlags.Start);

            //DrawerToggle is the animation that happens with the indicator next to the actionbar
            _mDrawerToggle = new MyActionBarDrawerToggle(this, _mDrawer,
                                                               Resource.Drawable.ic_drawer,
                                                               Resource.String.drawer_open,
                                                               Resource.String.drawer_close);

            //Display the current fragments title and update the options menu
            _mDrawerToggle.DrawerClosed += (o, args) =>
            {
                ActionBar.Title = _mTitle;
                InvalidateOptionsMenu();
            };

            //Display the drawer title and update the options menu
            _mDrawerToggle.DrawerOpened += (o, args) =>
            {
                ActionBar.Title = _mDrawerTitle;
                InvalidateOptionsMenu();
            };

            //			this.m_DrawerToggle.DrawerSlide += (s, e) => {
            //				this.InvalidateOptionsMenu();
            //			};

            //Set the drawer lister to be the toggle.
            _mDrawer.SetDrawerListener(_mDrawerToggle);

            //if first time you will want to go ahead and click first item.
            if (bundle == null)
            {
                ListItemClicked(0);
            }

            ActionBar.SetDisplayHomeAsUpEnabled(true);
            ActionBar.SetHomeButtonEnabled(true);
        }

        protected override void OnPostCreate(Bundle savedInstanceState)
        {
            base.OnPostCreate(savedInstanceState);
            _mDrawerToggle.SyncState();
        }

        public override void OnConfigurationChanged(Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);
            _mDrawerToggle.OnConfigurationChanged(newConfig);
        }
        // Pass the event to ActionBarDrawerToggle, if it returns
        // true, then it has handled the app icon touch event
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            var selectedId = item.ItemId;
            switch (selectedId)
            {
                case Android.Resource.Id.Home:
                    if (_mDrawer.IsDrawerOpen(_mDrawerList))
                    {
                        _mDrawer.CloseDrawer(_mDrawerList);
                    }
                    else
                    {
                        _mDrawer.OpenDrawer(_mDrawerList);
                    }
                    break;
            }
            return base.OnOptionsItemSelected(item);
        }

        public override bool OnPrepareOptionsMenu(IMenu menu)
        {

            var drawerOpen = _mDrawer.IsDrawerOpen(_mDrawerList);
            //when open don't show anything
            for (var i = 0; i < menu.Size(); i++)
                menu.GetItem(i).SetVisible(!drawerOpen);

            return base.OnPrepareOptionsMenu(menu);
        }

        private void ListItemClicked(int position)
        {
            Fragment fragment = null;
            switch (position)
            {
                case 0:
                    fragment = new TipoCambioFragment();
                    break;
            }

            FragmentManager.BeginTransaction()
                .Replace(Resource.Id.content_frame, fragment)
                    .Commit();

            _mDrawerList.SetItemChecked(position, true);
            ActionBar.Title = _mTitle = Sections[position];
            _mDrawer.CloseDrawer(_mDrawerList);
        }
    }
}

