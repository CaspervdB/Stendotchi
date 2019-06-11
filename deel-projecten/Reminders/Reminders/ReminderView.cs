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
    public class ReminderView : LinearLayout
    {
        public Button Button;
        public TextView TextView;
        public Reminder reminder { get; private set; }

        public delegate void OnReminderButton(int reminderid, string text, ReminderType type);

        public event OnReminderButton OnReminder;

        public ReminderView(Context context, Reminder reminder) : base(context)
        {
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

            this.Button = new Button(context) { Text = $"Open{viewtype}"};
            this.TextView = new TextView(context) { Text = reminder.text };
            this.Button.SetWidth(350);
            this.Button.SetHeight(180);
            this.TextView.SetTextSize(Android.Util.ComplexUnitType.Pt, 7);
            this.TextView.SetHeight(180);
            this.TextView.Gravity = GravityFlags.CenterVertical;
            this.AddView(this.Button);
            this.AddView(this.TextView);
            this.LayoutParameters = new ViewGroup.LayoutParams(LayoutParams.WrapContent, 200);

            this.reminder = reminder;

            this.Button.Click += Button_Click;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            OnReminder.Invoke(this.reminder.id, this.reminder.text, this.reminder.type);
        }
    }
}