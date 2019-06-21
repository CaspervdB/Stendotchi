using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Xamarin.Essentials;
namespace Stendotchi
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class BathroomMainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            //Set view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            //Bind buttons to methods
            //Button ButEN = FindViewById<Button>(Resource.Id.ButtonEN);
            //ButEN.Click += Button_Click_English;

            //Button ButNL = FindViewById<Button>(Resource.Id.ButtonNL);
            //ButNL.Click += Button_Click_Dutch;

            //Button ButtBath = FindViewById<Button>(Resource.Id.ButtonBath);
            //ButtBath.Click += Button_Click_Bathroom;

            //Button ButtSet = FindViewById<Button>(Resource.Id.ButtonSettings);
            //ButtSet.Click += Button_Click_Settings;

        }

        //Methods for buttons

        private void Button_Click_Bathroom(object sender, System.EventArgs e)
        {
            StartActivity(typeof(Bathroom));

        }
        private void Button_Click_Settings(object sender, System.EventArgs e)
        {
            StartActivity(typeof(Settings));

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}