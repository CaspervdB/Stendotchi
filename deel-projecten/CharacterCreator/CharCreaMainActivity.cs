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

namespace CharacterCreator
{
    [Activity(Label = "CharacterCreator", MainLauncher = true)]

    public class CharCreaMainActivity : AppCompatActivity
    {
        int TorsNumber = 0;


        protected override void OnCreate(Bundle savedInstanceState)                        
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.CharCrea_activity_main);

            ImageView charCreatorTorsoView = FindViewById<ImageView>(Resource.Id.charCreatorTorsoView);
            ImageButton charCreatorTorsoButtTerug = FindViewById<ImageButton>(Resource.Id.charCreatorTorsoButtTerug);
            ImageButton charCreatorTorsoButtVerder = FindViewById<ImageButton>(Resource.Id.charCreatorTorsoButtVerder);

            FindViewById<ImageView>(Resource.Id.charCreatorTorsoView).SetImageResource(Resource.Mipmap.testTorso1);
        }

        //OPTIE een list van de items i.p.v. increment en decrement
        protected void CharCreatorTorsoButtTerug_Click(object sender, CharCreaMainActivity e)
        {
            charCreatorTorsoButtTerug.Click += (o) => CharCreatorTorsoButtTerug_Click;
            TorsNumber = --TorsNumber;
        }

        protected void CharCreatorTorsoButtVerder_Click(object sender, CharCreaMainActivity e)
        {
            charCreatorTorsoButtVerder.Click += (o) => CharCreatorTorsoButtVerder_Click;
            TorsNumber = ++TorsNumber;
        }


    }
}