using System;

using System.Web;
using Android.Systems;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace CharacterCreator
{
<<<<<<< HEAD:deel-projecten/CharacterCreator/MainActivity.cs
    [Activity(Label = "CharacterCreator", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
=======
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class CCMainActivity : AppCompatActivity
>>>>>>> fa17db4b2bf27be66693ac76e3453fd376cfc21f:deel-projecten/CharacterCreator/CCMainActivity.cs
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            var charCreatorHairButtTerug = FindViewById<ImageButton>(Resource.Id.charCreatorHairButtTerug);

        }

        private object FindViewById<T>(object charCreatorHairButtTerug)
        {
            throw new NotImplementedException();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}