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
    [Activity(Label = "reminders")]
    public class reminders : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.reminders);
            Button backButton = FindViewById<Button>(Resource.Id.backButton);
            backButton.Click += delegate {
                StartActivity(typeof(MainActivity));
            };
        }
    }
}