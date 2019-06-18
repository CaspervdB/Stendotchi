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
    [Activity(Label = "Activity1")]
    public class PantsShop : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.PantsLayout);

            Button button3 = FindViewById<Button>(Resource.Id.FirstPants);

            button3.Click += delegate
            {
                StartActivity(typeof(ShopMain));
            };

        }
    }
}