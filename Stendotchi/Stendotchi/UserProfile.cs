using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Stendotchi
{
    public class UserProfile
    {
        public static UserProfile Current;
        public void Initialize(Activity ctx)
        {
            var init = Xamarin.Essentials.SecureStorage.GetAsync("initialized").GetAwaiter().GetResult();

            if (string.IsNullOrEmpty(init))
            {
                Toast.MakeText(ctx, $"Nieuwe gebruiker", ToastLength.Short).Show();
                ShowNewUserDialog(ctx);

                this.CurrentTopper = 0;
                this.CurrentUpperbody = 9;
                this.CurrentLowerbody = 14;
                this.UserXp = 0;

                Xamarin.Essentials.SecureStorage.SetAsync("initialized", "yes").GetAwaiter().GetResult();
            }
            else
            {
                Toast.MakeText(ctx, $"Welkom terug, {this.Username}", ToastLength.Short).Show();
            }
        }

        private void ShowNewUserDialog(Activity ctx)
        {
            LayoutInflater layoutInflater = LayoutInflater.From(ctx);
            View view = layoutInflater.Inflate(Resource.Layout.popupinput, null);
            Android.Support.V7.App.AlertDialog.Builder alertbuilder = new Android.Support.V7.App.AlertDialog.Builder(ctx);
            alertbuilder.SetView(view);
            var userdata = view.FindViewById<EditText>(Resource.Id.stendname);
            alertbuilder.SetCancelable(false)
            .SetPositiveButton("Submit", delegate
            {
                Toast.MakeText(ctx, $"Welkom, {userdata.Text}!", ToastLength.Short).Show();
                UserProfile.Current.Username = userdata.Text;
            })
            .SetNegativeButton("Cancel", delegate
            {
                Toast.MakeText(ctx, $"Welkom, Gebruiker!", ToastLength.Short).Show();
                UserProfile.Current.Username = "Gebruiker";
            });
            Android.Support.V7.App.AlertDialog dialog = alertbuilder.Create();
            dialog.Show();
        }

        public (int level, int remainingxp) GetUserLevelAndRemainingXp()
        {
            // elke level is n * 50 xp
            var xp = this.UserXp;

            int level = (xp - (xp % 250)) / 250;
            int remaining = ((level + 1) * 250) - xp;
            return (level, remaining);
        }

        public string Username
        {
            get
            {
                return Xamarin.Essentials.SecureStorage.GetAsync("username").GetAwaiter().GetResult();
            }

            set
            {
                Xamarin.Essentials.SecureStorage.SetAsync("username", value).GetAwaiter().GetResult();
            }
        }

        public int CurrentTopper
        {
            get
            {
                var res = Xamarin.Essentials.SecureStorage.GetAsync("topper").GetAwaiter().GetResult();
                return int.Parse(res);
            }

            set
            {
                Xamarin.Essentials.SecureStorage.SetAsync("topper", value.ToString()).GetAwaiter().GetResult();
            }
        }

        public int CurrentUpperbody
        {
            get
            {
                var res = Xamarin.Essentials.SecureStorage.GetAsync("upper").GetAwaiter().GetResult();
                return int.Parse(res);
            }

            set
            {
                Xamarin.Essentials.SecureStorage.SetAsync("upper", value.ToString()).GetAwaiter().GetResult();
            }
        }

        public int CurrentLowerbody
        {
            get
            {
                var res = Xamarin.Essentials.SecureStorage.GetAsync("lower").GetAwaiter().GetResult();
                return int.Parse(res);
            }

            set
            {
                Xamarin.Essentials.SecureStorage.SetAsync("lower", value.ToString()).GetAwaiter().GetResult();
            }
        }

        public int UserXp
        {
            get
            {
                var res = Xamarin.Essentials.SecureStorage.GetAsync("xp").GetAwaiter().GetResult();
                return int.Parse(res);
            }

            set
            {
                Xamarin.Essentials.SecureStorage.SetAsync("xp", value.ToString()).GetAwaiter().GetResult();
            }
        }
    }
}