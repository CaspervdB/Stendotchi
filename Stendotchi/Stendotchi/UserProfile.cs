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

namespace Stendotchi
{
    public class UserProfile
    {
        public static UserProfile Current;
        public void Initialize(Context ctx)
        {
            var init = Xamarin.Essentials.SecureStorage.GetAsync("initialized").GetAwaiter().GetResult();

            if (string.IsNullOrEmpty(init))
            {
                Toast.MakeText(ctx, $"Nieuwe gebruiker", ToastLength.Short).Show();
                this.Username = "gebruiker";

                this.CurrentTopper = 0;
                this.CurrentUpperbody = 0;
                this.CurrentLowerbody = 0;
                Xamarin.Essentials.SecureStorage.SetAsync("initialized", "yes").GetAwaiter().GetResult();
            }

            Toast.MakeText(ctx, $"Welkom, {this.Username}", ToastLength.Short).Show();
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
    }
}