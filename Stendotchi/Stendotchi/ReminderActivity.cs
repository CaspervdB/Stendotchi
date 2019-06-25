using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Plugin.Media;

namespace Stendotchi
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
            string[] req = new string[1]
                {
                    Android.Manifest.Permission.Camera
                };
            RequestPermissions(req, 0);

            // get reminder data from intent
            text = this.Intent.GetStringExtra("text");
            id = this.Intent.GetIntExtra("id", -1);

            // if id == -1 then the reminder is invalid / no data is passed. close this activity.
            if(this.id == -1)
            {
                this.Finish();
            }

            // set textview and button data
            this.FindViewById<TextView>(Resource.Id.textView1).SetText($"{id}: {text}", TextView.BufferType.Normal);
            this.FindViewById<Button>(Resource.Id.okbtn).Click += (sender, e) =>
            {
                this.Finish();
            };

            this.FindViewById<Button>(Resource.Id.photobtn).Click += async (sender, e) =>
            {
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    Toast.MakeText(this.BaseContext, "Camera unavailable", ToastLength.Short);
                    return;
                }

                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    Directory = "Stendotchi",
                    Name = "img.jpg"
                });

                if (file == null)
                    return;

                Toast.MakeText(this.BaseContext, file.Path, ToastLength.Short);

                using(FileStream fs = new FileStream(file.Path, FileMode.Open))
                {
                    var objects = await RestHelper.DetectObjects(fs);
                    this.FindViewById<TextView>(Resource.Id.textView1).SetText(string.Join(", ", objects), TextView.BufferType.Normal);
                    return;
                }
            };
        }
    }
}