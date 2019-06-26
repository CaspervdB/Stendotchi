using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Content;
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
            string[] req = new string[3]
                {
                    Android.Manifest.Permission.Camera,
                    Android.Manifest.Permission.ReadExternalStorage,
                    Android.Manifest.Permission.WriteExternalStorage
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

                var perm = ContextCompat.CheckSelfPermission(this.ApplicationContext, Android.Manifest.Permission.Camera);
                var perm2 = ContextCompat.CheckSelfPermission(this.ApplicationContext, Android.Manifest.Permission.ReadExternalStorage);
                var perm3 = ContextCompat.CheckSelfPermission(this.ApplicationContext, Android.Manifest.Permission.WriteExternalStorage);

                if (perm == Android.Content.PM.Permission.Denied)
                {
                    Toast.MakeText(this.ApplicationContext, 
                        "Camera permission denied.", ToastLength.Long);
                    return;
                }

                if(perm == Android.Content.PM.Permission.Denied || perm == Android.Content.PM.Permission.Denied)
                {
                    Toast.MakeText(this.ApplicationContext,
                        "Storage permission(s) denied.", ToastLength.Long);
                    return;
                }

                Toast.MakeText(this.ApplicationContext,
                        "Camera permission given.", ToastLength.Long);

                await Task.Delay(1500);
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    Toast.MakeText(this.ApplicationContext, "Camera unavailable", ToastLength.Short);
                    return;
                }

                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    Directory = "Stendotchi",
                    Name = "img.jpg",
                    SaveToAlbum = false
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