using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Collections.Generic;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ShopProject
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class ShopMain : AppCompatActivity
    {
        public Button shirtButton;
        public Button glassesButton;
        public Button pantsButton;
        public Button hatsButton;
        public TextView dbResults;


        private  List<ObjectDBSort> httpGet()
        {
            try
            {
                List<ObjectDBSort> returnObject = new List<ObjectDBSort>();
                var response = RestHelper.Get("https://resserver1.herokuapp.com", "getAllData");

                returnObject = JsonConvert.DeserializeObject<List<ObjectDBSort>>(response.Content);

                return returnObject;
            }
            catch(Exception e)
            {
                return new List<ObjectDBSort>();
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.ShopLayout);


            //AXML properties
            shirtButton = FindViewById<Button>(Resource.Id.shirts);
            pantsButton = FindViewById<Button>(Resource.Id.pants);
            hatsButton = FindViewById<Button>(Resource.Id.hats);
            glassesButton = FindViewById<Button>(Resource.Id.glasses);
            dbResults = FindViewById<TextView>(Resource.Id.textViewDbResults);

            List<ObjectDBSort> listObject = httpGet();
            foreach (ObjectDBSort obj in listObject)
            {
                dbResults.Text += obj.id + obj.text;
            }



            shirtButton.Click += delegate
            {
                StartActivity(typeof(ShirtsShop));
                
            };

            glassesButton.Click += delegate
            {
                StartActivity(typeof(GlassesShop));

            };

            pantsButton.Click += delegate
            {
                StartActivity(typeof(PantsShop));
            };

            hatsButton.Click += delegate
            {
                StartActivity(typeof(HatsShop));
            };

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }

    public class shop : ShopMain
    {
    }
}