using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;

namespace Stendotchi.Fragments
{
    public class Fragment3 : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public static Fragment3 NewInstance()
        {
            var frag3 = new Fragment3 { Arguments = new Bundle() };
            return frag3;
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            view.FindViewById<ImageButton>(Resource.Id.gameimg).Click += delegate
            {
                Toast.MakeText(view.Context, "Sorry! Er zijn nog geen minigames beschikbaar.", ToastLength.Short).Show();
            };
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            return inflater.Inflate(Resource.Layout.fragment3, null);
        }
    }
}