using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;

namespace Stendotchi.Fragments
{
    public class Home : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public static Home NewInstance()
        {
            var frag3 = new Home { Arguments = new Bundle() };
            return frag3;
        }

        int click = 0;
        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            var chv = view.FindViewById<LinearLayout>(Resource.Id.charview);
            var charview = new CharacterView(view.Context);
            charview.UpdateView();

            chv.AddView(charview);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            return inflater.Inflate(Resource.Layout.home, null);
        }
    }
}