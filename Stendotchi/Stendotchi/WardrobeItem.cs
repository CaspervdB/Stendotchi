﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Wardrobe
{
    class WardrobeItem
    {
        public string Name;
        public string ImagePath;

        public WardrobeItem(string name, string imagePath)
        {
            this.Name = name;
            this.ImagePath = imagePath;
        }
    }
}