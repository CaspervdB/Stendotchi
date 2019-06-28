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
    [Activity(Label = "ReminderActivity", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
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

            var spinner = this.FindViewById<ProgressBar>(Resource.Id.reminderphotospin);
            spinner.Visibility = ViewStates.Invisible;

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
                        "Camera permission denied.", ToastLength.Long).Show();
                    return;
                }

                if(perm == Android.Content.PM.Permission.Denied || perm == Android.Content.PM.Permission.Denied)
                {
                    Toast.MakeText(this.ApplicationContext,
                        "Storage permission(s) denied.", ToastLength.Long).Show();
                    return;
                }

                Toast.MakeText(this.ApplicationContext,
                        "Camera permission given.", ToastLength.Long).Show();

                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    
                    Toast.MakeText(this.ApplicationContext, "Camera unavailable", ToastLength.Short).Show();
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

                Toast.MakeText(this.BaseContext, file.Path, ToastLength.Short).Show();

                spinner.Visibility = ViewStates.Visible;
                using (FileStream fs = new FileStream(file.Path, FileMode.Open))
                {
                    var objects = await RestHelper.DetectObjects(fs);
                    switch((ReminderType)this.Intent.GetIntExtra("type", (int)ReminderType.Unknown))
                    {
                        case ReminderType.Drink:
                            if (objects.Any(x => x.ToLower().Contains("water") || x.ToLower().Contains("bottle") || x.ToLower().Contains("jug")))
                            {
                                // Ja! gedronken!
                                UserProfile.Current.UserXp += 80;
                                Toast.MakeText(this.BaseContext, $"Je hebt gedronken! Je wordt beloond met 80 XP." +
                                    $"\nJe nieuwe level is {UserProfile.Current.GetUserLevelAndRemainingXp().level}",
                                    ToastLength.Short).Show();
                                this.Finish();
                            }
                            else
                            {
                                Toast.MakeText(this.BaseContext, $"Er is niks herkend, je krijgt geen punten.\n" +
                                    $"Probeer het nog een keer!",
                                    ToastLength.Short).Show();
                            }
                            break;

                        case ReminderType.Exercise:
                            if(objects.Any(x => x.ToLower().Contains("cycle") || x.ToLower().Contains("bike")))
                            {
                                // Ja! gefietst!
                                UserProfile.Current.UserXp += 200;
                                Toast.MakeText(this.BaseContext, $"Je hebt gefietst! Je wordt beloond met 200 XP." +
                                    $"\nJe nieuwe level is {UserProfile.Current.GetUserLevelAndRemainingXp().level}",
                                    ToastLength.Short).Show();
                                this.Finish();
                            }
                            else
                            {
                                Toast.MakeText(this.BaseContext, $"Er is niks herkend, je krijgt geen punten.\n" +
                                    $"Probeer het nog een keer!",
                                    ToastLength.Short).Show();
                            }
                            break;
                    }
                    spinner.Visibility = ViewStates.Invisible;
                }
                File.Delete(file.Path);
            };
        }
    }
}