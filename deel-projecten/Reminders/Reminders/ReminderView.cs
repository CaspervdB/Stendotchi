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

namespace Reminders
{
    // Reminderview is a linearlayout with some extra data and a button + textview pre-configured. 
    // It has an event for when the button is clicked
    public class ReminderView : LinearLayout
    {
        public Button Button;
        public TextView TextView;
        public Reminder reminder { get; private set; }

        public delegate void OnReminderButton(Reminder reminder);

        public event OnReminderButton OnReminder;

        public ReminderView(Context context, Reminder reminder) : base(context)
        {
            // Check remindertype to know what screen is to be opened / btn text
            string viewtype = "";
            switch (reminder.type)
            {
                default:
                case ReminderType.Unknown:
                    viewtype = "";
                    break;

                case ReminderType.Eat:
                    viewtype = " Food";
                    break;

                case ReminderType.Exercise:
                    viewtype = " Exercise";
                    break;

                case ReminderType.Sleep:
                    viewtype = " Sleep";
                    break;
            }

            // create button and textview
            this.Button = new Button(context) { Text = $"Open{viewtype}"};
            this.TextView = new TextView(context) { Text = reminder.text };

            // set button dimensions
            this.Button.SetWidth(350);
            this.Button.SetHeight(180);
            // set text size and view height
            this.TextView.SetTextSize(Android.Util.ComplexUnitType.Pt, 7);
            this.TextView.SetHeight(180);
            // center text vertically
            this.TextView.Gravity = GravityFlags.CenterVertical;

            // add views to this
            this.AddView(this.Button);
            this.AddView(this.TextView);

            // set own height
            this.LayoutParameters = new ViewGroup.LayoutParams(LayoutParams.WrapContent, 200);

            // set reminder property and event
            this.reminder = reminder;
            this.Button.Click += Button_Click;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            // invoke own OnReminder event on click of button
            OnReminder.Invoke(this.reminder);
        }
    }
}