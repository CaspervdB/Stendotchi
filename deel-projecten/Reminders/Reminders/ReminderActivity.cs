using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace Reminders
{
    [Activity(Label = "ReminderActivity")]
    public class ReminderActivity : AppCompatActivity
    {
        private string text;
        private int id;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_reminder);

            text = this.Intent.GetStringExtra("text");
            id = this.Intent.GetIntExtra("id", -1);

            if(this.id == -1)
            {
                this.Finish();
            }

            this.FindViewById<TextView>(Resource.Id.textView1).SetText($"{id}: {text}", TextView.BufferType.Normal);
            this.FindViewById<Button>(Resource.Id.okbtn).Click += (sender, e) =>
            {
                this.Finish();
            };
        }
    }
}