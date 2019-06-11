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

namespace Reminders
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        { 
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.content_main);

            var reminder = Stub.GetReminders();
            var lo = FindViewById<LinearLayout>(Resource.Id.linearLayout1);

            foreach (var r in reminder)
            {
                var rem = new ReminderView(lo.Context, r);
                rem.OnReminder += Rem_OnReminder;
                lo.AddView(rem);
            }
        }

        private void Rem_OnReminder(int reminderid, string text, ReminderType type)
        {
            Toast.MakeText(this.ApplicationContext, $"Clicked reminder with ID {reminderid} ({text})", ToastLength.Short).Show();
            Console.WriteLine($"Clicked reminder with ID {reminderid} ({text})");
            var act = new Intent(this, typeof(ReminderActivity));
            act.PutExtra("text", text);
            act.PutExtra("id", reminderid);

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
            new Reminder(){text="Heb je vandaag wel gegeten?", id = 1, type = ReminderType.Eat},
            new Reminder(){text="Ik en de jongens in creatieve modus", id = 2, type = ReminderType.Unknown}
        };
    }

    public class Reminder
    {
        public int id;
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

