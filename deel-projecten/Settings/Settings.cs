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
using Xamarin.Essentials;

namespace Settings
{
    [Activity(Label = "Settings")]
    public class Settings : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Settings);

            //Bind buttons to methods
            Button ButtSoundOff = FindViewById<Button>(Resource.Id.ButtonBGMOff);
            ButtSoundOff.Click += Button_Click_SoundOff;

            Button ButtSoundOn = FindViewById<Button>(Resource.Id.ButtonBGMOn);
            ButtSoundOn.Click += Button_Click_SoundOn;

            Button ButtSFXOn = FindViewById<Button>(Resource.Id.ButtonSFXOn);
            ButtSFXOn.Click += Button_Click_SFXOn;

            Button ButtSFXOff = FindViewById<Button>(Resource.Id.ButtonSFXOff);
            ButtSFXOff.Click += Button_Click_SFXOn;

            Button ButtEN = FindViewById<Button>(Resource.Id.ButtonEnglish);
            ButtEN.Click += Button_Click_English;

            Button ButtNL = FindViewById<Button>(Resource.Id.ButtonDutch);
            ButtNL.Click += Button_Click_Dutch;

            Button ButtNotifOn = FindViewById<Button>(Resource.Id.ButtonNotifOn);
            ButtNotifOn.Click += Button_Click_NotifOn;

            Button ButtNotifOff = FindViewById<Button>(Resource.Id.ButtonNotifOff);
            ButtNotifOff.Click += Button_Click_NotifOff;
        }
        private void Button_Click_SoundOff(object sender, System.EventArgs e)
        {
            Preferences.Set("BGM", "off");

        }
        private void Button_Click_SoundOn(object sender, System.EventArgs e)
        {
            Preferences.Set("BGM", "on");

        }
        private void Button_Click_SFXOff(object sender, System.EventArgs e)
        {
            Preferences.Set("SFX", "off");

        }
        private void Button_Click_SFXOn(object sender, System.EventArgs e)
        {
            Preferences.Set("SFX", "on");

        }
        private void Button_Click_English(object sender, System.EventArgs e)
        {
            Preferences.Set("Language", "EN");

        }
        private void Button_Click_Dutch(object sender, System.EventArgs e)
        {
            Preferences.Set("Language", "NL");

        }

        private void Button_Click_NotifOn(object sender, System.EventArgs e)
        {
            Preferences.Set("Notif", "On");

        }
        private void Button_Click_NotifOff(object sender, System.EventArgs e)
        {
            Preferences.Set("Notif", "Off");

        }
    }
}