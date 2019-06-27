using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace Stendotchi
{
    public class CharacterView : LinearLayout
    {
        private ImageView Topper;
        private ImageView Upper;
        private ImageView Lower;

        public CharacterView(Context ctx) : base(ctx)
        {
            this.SetGravity(GravityFlags.CenterHorizontal);
            var bodysiz = (int)(100 * ctx.Resources.DisplayMetrics.Density);
            var headsiz = (int)(65 * ctx.Resources.DisplayMetrics.Density);
            var legsiz = (int)(70 * ctx.Resources.DisplayMetrics.Density);
            this.Orientation = Orientation.Vertical;
            Topper = new ImageView(ctx);
            Topper.LayoutParameters = new ViewGroup.LayoutParams(headsiz, headsiz);
            Upper = new ImageView(ctx);
            Upper.LayoutParameters = new ViewGroup.LayoutParams(bodysiz, bodysiz);
            Lower = new ImageView(ctx);
            Lower.LayoutParameters = new ViewGroup.LayoutParams(legsiz, bodysiz);

            Topper.SetScaleType(ImageView.ScaleType.FitXy);
            Upper.SetScaleType(ImageView.ScaleType.FitXy);
            Lower.SetScaleType(ImageView.ScaleType.FitXy);

            this.AddView(Topper);
            this.AddView(Upper);
            this.AddView(Lower);
        }

        public void UpdateView()
        {
            Topper.SetImageResource(UserProfile.Current.CurrentTopper);

            Upper.SetImageResource(UserProfile.Current.CurrentUpperbody);

            Lower.SetImageResource(UserProfile.Current.CurrentLowerbody);
        }
    }
}