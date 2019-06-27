using Android.App;
using Android.OS;
using Stendotchi.Fragments;
using Android;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace Stendotchi
{
    [Activity(Label = "@string/app_name", MainLauncher = true, LaunchMode = Android.Content.PM.LaunchMode.SingleTop, Icon = "@mipmap/hart")]
    public class MainActivity : AppCompatActivity
    {

        BottomNavigationView bottomNavigation;
        protected override void OnCreate(Bundle bundle)
        {

            System.Console.WriteLine("ping");
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.main);

            //var bn = FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation);
            //bn.InflateMenu(Resource.Menu.bottom_navigation_main);

            ImageButton settingsButton = FindViewById<ImageButton>(Resource.Id.settings);
            settingsButton.Click += delegate
            {
                StartActivity(typeof(Settings));
            };
            ImageButton remindersButton = FindViewById<ImageButton>(Resource.Id.reminders);
            remindersButton.Click += delegate
            {
                StartActivity(typeof(ReminderMainActivity));
            };

            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            if (toolbar != null)
            {
                //SetSupportActionBar(toolbar);
                SupportActionBar.SetDisplayHomeAsUpEnabled(false);
                SupportActionBar.SetHomeButtonEnabled(false);
            }

            bottomNavigation = FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation);

            bottomNavigation.ItemIconTintList = null;
            bottomNavigation.NavigationItemSelected += BottomNavigation_NavigationItemSelected;

            ImageButton homeButton = FindViewById<ImageButton>(Resource.Id.homeknop);
            bottomNavigation.Selected = false;
            homeButton.Click += delegate
            {
                LoadFragment(Resource.Id.home);
                bottomNavigation.Selected = false;
            };

            ImageButton level = FindViewById<ImageButton>(Resource.Id.levelknop);
            level.Click += delegate
            {
                int mijnlvl = 7;
                Toast.MakeText(this.BaseContext, $"Je bent momenteel level {mijnlvl}", ToastLength.Short).Show();
            };

            LoadFragment(Resource.Id.home);
        }

        private void BottomNavigation_NavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
        {
            LoadFragment(e.Item.ItemId);
        }

        void LoadFragment(int id)
        {
            Android.Support.V4.App.Fragment fragment = null;
            switch (id)
            {
                case Resource.Id.Gezondheid:
                    fragment = Fragment1.NewInstance();
                    break;
                case Resource.Id.Style:
                    fragment = Fragment2.NewInstance();
                    break;
                case Resource.Id.Minigames:
                    fragment = Fragment3.NewInstance();
                    break;
                default:
                case Resource.Id.home:
                    fragment = Home.NewInstance();
                    break;
            }
            if (fragment == null)
                return;

            SupportFragmentManager.BeginTransaction()
               .Replace(Resource.Id.content_frame, fragment)
               .Commit();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}

