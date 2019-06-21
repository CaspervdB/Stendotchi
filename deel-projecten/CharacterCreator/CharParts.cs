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

namespace CharacterCreator
{
    class CharParts
    {
        public string Name;
        public string ImagePath;

        public CharParts(string name, string imagePath)
        {
            this.Name = name;
            this.ImagePath = imagePath;
        }
    }
}