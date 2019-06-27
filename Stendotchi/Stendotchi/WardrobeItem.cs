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
        public int Id;

        public WardrobeItem(string name, int mipmap, int id)
        {
            this.Name = name;
            this.Mipmap = mipmap;
            this.Id = id;
        }
    }
}