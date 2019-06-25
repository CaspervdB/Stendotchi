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
    [Activity(Label = "@string/app_name", MainLauncher = true, LaunchMode = Android.Content.PM.LaunchMode.SingleTop, Icon = "@mipmap/icon")]
    public class MainActivity : AppCompatActivity
    {

        BottomNavigationView bottomNavigation;
        protected override void OnCreate(Bundle bundle)
        {
            System.Console.WriteLine("ping");
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.main);
            Button settingsButton = FindViewById<Button>(Resource.Id.settings);
            settingsButton.Click += delegate {
                StartActivity(typeof(bedroom));
            };
            Button remindersButton = FindViewById<Button>(Resource.Id.reminders);
            settingsButton.Click += delegate {
                StartActivity(typeof(ReminderMainActivity));
            };
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            if (toolbar != null)
            {
                SetSupportActionBar(toolbar);
                SupportActionBar.SetDisplayHomeAsUpEnabled(false);
                SupportActionBar.SetHomeButtonEnabled(false);
            }


            bottomNavigation = FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation);

            bottomNavigation.NavigationItemSelected += BottomNavigation_NavigationItemSelected;

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

