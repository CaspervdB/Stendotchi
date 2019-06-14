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

namespace Settings
{
    [Activity(Label = "Bathroom")]
    public class Bathroom : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Bathroom);

            ImageButton ButtShower = FindViewById<ImageButton>(Resource.Id.shower);
            ButtShower.Click += Button_Click_Shower;

            ImageButton ButtSink = FindViewById<ImageButton>(Resource.Id.sink);
            ButtSink.Click += Button_Click_Sink;

        }
        private void Button_Click_Shower(object sender, System.EventArgs e)
        {
            //Action for tapping the shower
            Android.App.AlertDialog.Builder dialog = new AlertDialog.Builder(this);
            AlertDialog alert = dialog.Create();
            //alert.SetTitle("Title");  Title not needed here.
            alert.SetMessage("Je hebt gedoucht.");
            alert.SetButton("OK.", (c, ev) => { });
            alert.Show();
        }
        private void Button_Click_Sink(object sender, System.EventArgs e)
        {
            //Action for tapping the sink
            Android.App.AlertDialog.Builder dialog = new AlertDialog.Builder(this);
            AlertDialog alert = dialog.Create();
            //alert.SetTitle("Title");  Title not needed here.
            alert.SetMessage("Je hebt je tanden gepoetst.");
            alert.SetButton("OK.", (c, ev) => { });
            alert.Show();
        }
    }
}