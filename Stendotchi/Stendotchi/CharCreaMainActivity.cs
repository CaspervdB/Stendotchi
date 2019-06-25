using System;

using System.Web;
using Android.Systems;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Util.Concurrent.Locks;
using System.Threading;
using Android.Content.PM;
using Wardrobe;

namespace Stendotchi
{
    [Activity(Label = "CharacterCreator", MainLauncher = true)]

    public class CharCreaMainActivity : AppCompatActivity
    {
        //avatar class komt nog
        private Avatar _avatar;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.CharCrea_activity_main);

            this._avatar = new Avatar(this);

            SetOnClick(Resource.Id.AvatarTopper, this._avatar.NextHead);
            SetOnClick(Resource.Id.AvatarTorsos, this._avatar.NextTorso);
            SetOnClick(Resource.Id.AvatarLegs, this._avatar.NextLegs);
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

        public override bool OnOptionsPartSelected(IMenuPart part)
        {
            int id = part.PartId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsPartSelected(part);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View)sender;
            CharCreateView.Make(view, "Hier komt nog een actie", CharCreateView.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}