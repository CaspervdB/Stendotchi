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
    [Activity(Label = "TimePicker")]
    public class bedroom : Activity
    {
        TimePicker timePicker;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.bedroom);
            var timeButton = FindViewById<Button>(Resource.Id.timeButton);
            var timeDisplay = FindViewById<TextView>(Resource.Id.timer);
            timePicker = FindViewById<TimePicker>(Resource.Id.tpicker);

            timeButton.Click += (s, e) =>
            {
                timeDisplay.Text = DateTime.Now.ToString("h:mm tt");
            };
            timePicker.SetIs24HourView(Java.Lang.Boolean.True);
            timeDisplay.Text = DateTime.Now.ToString("h:mm tt");
        }
        private string getTime() {
            StringBuilder strTime = new StringBuilder();
#pragma warning disable CS0618 // Type or member is obsolete
            strTime.Append("Time: " + timePicker.CurrentHour + timePicker.CurrentMinute);
#pragma warning restore CS0618 // Type or member is obsolete
            return strTime.ToString();
        }
    }
}