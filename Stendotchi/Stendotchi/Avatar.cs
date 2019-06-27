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
   class Avatar
    {
        private WardrobeActivity _activity;

        private WardrobeItem _topper { get; set; }
        private WardrobeItem _upperBody { get; set; }
        private WardrobeItem _lowerBody { get; set; }

        private Wardrobe _wardrobe;

        public Avatar(WardrobeActivity activity)
        {
            // Set activity for UI manipulation.
            this._activity = activity;

            // Initialize Wardrobe.
            _wardrobe = new Wardrobe();

            // Initialize Clothes.
            NextTopper();
            NextUpperBody();
            NextLowerBody();
        }

        public void SaveCharacter()
        {
            UserProfile.Current.CurrentTopper = this._topper.Mipmap;
            UserProfile.Current.CurrentUpperbody = this._upperBody.Mipmap;
            UserProfile.Current.CurrentLowerbody = this._lowerBody.Mipmap;
            Toast.MakeText(_activity, "Jouw nieuwe Stendotchi is opgeslagen!", ToastLength.Short).Show();
            _activity.Finish();
        }

        private void UpdateWardrobeUI(int resourceId, int textid, WardrobeItem item)
        {
            UpdateWardrobeItemText(textid, item.Name);
            UpdateWardrobeItemImage(resourceId, item.Mipmap);
        }

        // Update UI text for WardrobeItem.
        private void UpdateWardrobeItemText(int resourceId, string name)
        {
            var textView = this._activity.FindViewById<TextView>(resourceId);
            textView.Text = name;
        }

        // Update UI img for WardrobeItem.
        private void UpdateWardrobeItemImage(int resourceId, int mipmap)
        {
            var img = this._activity.FindViewById<ImageView>(resourceId);
            img.SetImageResource(mipmap);
        }

        // Swap to the next Topper.
        public void NextTopper()
        {
            // Retrieve next.
            this._topper = this._wardrobe.GetNextTopper();
            // Update UI.
            UpdateWardrobeUI(Resource.Id.HeadView, Resource.Id.AvatarTopper, this._topper);
        }

        // Swap to the next UpperBody.
        public void NextUpperBody()
        {
            // Retrieve next.
            this._upperBody = this._wardrobe.GetNextUpperBody();
            // Update UI.
            UpdateWardrobeUI(Resource.Id.UpperView, Resource.Id.AvatarUpperBody, this._upperBody);
        }

        // Swap to the next LowerBody.
        public void NextLowerBody()
        {
            // Retrieve next.
            this._lowerBody = this._wardrobe.GetNextLowerBody();
            // Update UI.
            UpdateWardrobeUI(Resource.Id.LowerView, Resource.Id.AvatarLowerBody, this._lowerBody);
        }

        // Swap to the previous Topper.
        public void PreviousTopper()
        {
            // Retrieve next.
            this._topper = this._wardrobe.GetPreviousTopper();
            // Update UI.
            UpdateWardrobeUI(Resource.Id.HeadView, Resource.Id.AvatarTopper, this._topper);
        }

        // Swap to the previous UpperBody.
        public void PreviousUpperBody()
        {
            // Retrieve next.
            this._upperBody = this._wardrobe.GetPreviousUpperBody();
            // Update UI.
            UpdateWardrobeUI(Resource.Id.UpperView, Resource.Id.AvatarUpperBody, this._upperBody);
        }

        // Swap to the previous LowerBody.
        public void PreviousLowerBody()
        {
            // Retrieve next.
            this._lowerBody = this._wardrobe.GetPreviousLowerBody();
            // Update UI.
            UpdateWardrobeUI(Resource.Id.LowerView, Resource.Id.AvatarLowerBody, this._lowerBody);
        }
    }
}