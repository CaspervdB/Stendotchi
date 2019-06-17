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

namespace ShopProject
{
    [Activity(Label = "Activity1")]
    public class ShirtsShop : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.LayoutShirts);

            Button button1 = FindViewById<Button>(Resource.Id.FirstShirts);

            button1.Click += delegate
            {
                StartActivity(typeof(ShopMain));
            };
        }
    }
}