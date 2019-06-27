using Android.Content;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace Stendotchi.Fragments
{
    public class Fragment1 : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your fragment here

        }

        public static Fragment1 NewInstance()
        {
            var frag1 = new Fragment1 { Arguments = new Bundle() };
            return frag1;
        }


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.fragment1, container, false);

            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            return inflater.Inflate(Resource.Layout.fragment1, null);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            //Verbind button in axml met cs code
            ImageButton buttonBathHome = view.FindViewById<ImageButton>(Resource.Id.buttonBathHome);
            Button buttonBedHome = view.FindViewById<Button>(Resource.Id.buttonBedHome);

            //Set activity
            var bathroom = new Intent(Activity, typeof(Bathroom));
            var bedroom = new Intent(Activity, typeof(bedroom));

            //Start activity bij indrukken van de knop
            buttonBathHome.Click += delegate
            {
                StartActivity(bathroom);
            };
            buttonBedHome.Click += delegate
            {
                StartActivity(bedroom);
                Toast.MakeText(this.Context, "Hello toast!", ToastLength.Short).Show();
            };
        }
    }
}