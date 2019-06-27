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
    class WardrobeItem
    {
        public string Name;
        public int Mipmap;

        public WardrobeItem(string name, int mipmap)
        {
            this.Name = name;
            this.Mipmap = mipmap;
        }
    }
}