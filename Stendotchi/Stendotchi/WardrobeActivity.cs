using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace Stendotchi
{
    [Activity(Label = "@string/app_name")]
    public class WardrobeActivity : AppCompatActivity
    {
        private Avatar _avatar;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.wardrobeLayout);


            this._avatar = new Avatar(this);

            // Create Events
            SetOnClick(Resource.Id.AvatarTopper, this._avatar.NextTopper);
            SetOnClick(Resource.Id.AvatarUpperBody, this._avatar.NextUpperBody);
            SetOnClick(Resource.Id.AvatarLowerBody, this._avatar.NextLowerBody);
        }

        private void SetOnClick(int resourceId, Action onClickFunction)
        {
            var view = FindViewById(resourceId);
            view.Click += delegate
            {
                onClickFunction();
            };
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

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View)sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}