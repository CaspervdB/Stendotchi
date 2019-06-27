using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Stendotchi;

namespace Stendotchi
{
    [Activity(Label = "@string/app_name")]
    public class ReminderMainActivity : AppCompatActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.reminder_content_main);

            // Get reminders
            var reminder = Stub.GetReminders();
            // Get linear layout by id
            var lo = FindViewById<LinearLayout>(Resource.Id.linearLayout1);

            // Add ReminderViews to lo
            foreach (var r in reminder)
            {
                var rem = new ReminderView(lo.Context, r);
                rem.OnReminder += OnReminder;
                lo.AddView(rem);
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void OnReminder(Reminder r)
        {
            // Show toast with info
            Toast.MakeText(this.ApplicationContext, $"Clicked reminder with ID {r.id} ({r.text})", ToastLength.Short).Show();
            Console.WriteLine($"Clicked reminder with ID {r.id} ({r.text})");

            // Create new intent to show a reminderactivity
            var act = new Intent(this, typeof(ReminderActivity));
            // Pass data
            act.PutExtra("text", r.text);
            act.PutExtra("id", r.id);

            // start activity
            StartActivity(act);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }
    }

    public static class Stub
    {
        public static List<Reminder> GetReminders() => new List<Reminder>() {
            new Reminder(){text="Heb je al gefietst vandaag?", id = 0, type = ReminderType.Exercise},
            new Reminder(){text="Heb je vandaag wel gegeten?", id = 1, type = ReminderType.Eat}
        };
    }

    public class Reminder
    {
        public int id;
        public int userid;
        public string text;
        public ReminderType type;
    }

    public enum ReminderType
    {
        Exercise,
        Eat,
        Sleep,
        Unknown
    }
}

