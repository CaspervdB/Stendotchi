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
    [Activity(Label = "CharacterCreator", Theme = "@style/AppTheme", MainLauncher = true)]

    public class CharCreaMainActivity : AppCompatActivity
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