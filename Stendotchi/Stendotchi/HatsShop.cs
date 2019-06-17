using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Stendotchi
{
    [Activity(Label = "HatsShop")]
    public class HatsShop : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.HatsLayout);

            Button button4 = FindViewById<Button>(Resource.Id.FirstHats);

            button4.Click += delegate
            {
                StartActivity(typeof(ShopMain));
            };


            // Create your application here
        }
    }
}