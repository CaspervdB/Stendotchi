using Android.OS;
using Android.Support.V4.App;
using Android.Views;

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


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            return inflater.Inflate(Resource.Layout.home, null);
        }
    }
}