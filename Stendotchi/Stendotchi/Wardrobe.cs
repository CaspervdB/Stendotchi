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
    class Wardrobe
    {
        public List<WardrobeItem> Toppers;
        public List<WardrobeItem> UpperBodies;
        public List<WardrobeItem> LowerBodies;

        public Wardrobe()
        {
            // Initialize the Queue fields.
            this.Toppers = new List<WardrobeItem>();
            this.UpperBodies = new List<WardrobeItem>();
            this.LowerBodies = new List<WardrobeItem>();

            // Fill Lists with WardrobeItem.
            AddTopper("Head One", Resource.Mipmap.hoofd1);
            AddTopper("Head Two", Resource.Mipmap.hoofd2);
            AddTopper("Head Three", Resource.Mipmap.hoofd3);

            AddUpperBody("Short Sleeve Blue", Resource.Mipmap.kortmouw1);
            AddUpperBody("Short Sleeve Green", Resource.Mipmap.kortmouw3);
            AddUpperBody("Short Sleeve Red", Resource.Mipmap.kortmouw2);
            AddUpperBody("Short Long Sleeve Red", Resource.Mipmap.langmouw3);
            AddUpperBody("Short Long Sleeve Green", Resource.Mipmap.langmouw2);
            AddUpperBody("Short Long Sleeve Blue", Resource.Mipmap.langmouw1);

            AddLowerBody("Shorts Blue", Resource.Mipmap.kort3);
            AddLowerBody("Shorts Brown", Resource.Mipmap.kort2);
            AddLowerBody("Shorts Red", Resource.Mipmap.kort1);
            AddLowerBody("Trousers Blue", Resource.Mipmap.lang2);
            AddLowerBody("Trousers Brown", Resource.Mipmap.lang1);
            AddLowerBody("Trousers Grey", Resource.Mipmap.lang3);
        }

        // Add a new Topper.
        private void AddTopper(string name, int imagePath)
        {
            var item = new WardrobeItem(name, imagePath);
            this.Toppers.Add(item);
        }

        // Add a new UpperBody.
        private void AddUpperBody(string name, int imagePath)
        {
            var item = new WardrobeItem(name, imagePath);
            this.UpperBodies.Add(item);
        }

        // Add a new LowerBody.
        private void AddLowerBody(string name, int imagePath)
        {
            var item = new WardrobeItem(name, imagePath);
            this.LowerBodies.Add(item);
        }

        // Get next Topper and places it at the back of the list.
        public WardrobeItem GetNextTopper()
        {
            var nextItem = this.Toppers[0];
            this.Toppers.RemoveAt(0);
            this.Toppers.Add(nextItem);
            return nextItem;
        }

        // Get next UpperBody and places it at the back of the list.
        public WardrobeItem GetNextUpperBody()
        {
            var nextItem = this.UpperBodies[0];
            this.UpperBodies.RemoveAt(0);
            this.UpperBodies.Add(nextItem);
            return nextItem;
        }

        // Get next LowerBody and places it at the back of the list.
        public WardrobeItem GetNextLowerBody()
        {
            var nextItem = this.LowerBodies[0];
            this.LowerBodies.RemoveAt(0);
            this.LowerBodies.Add(nextItem);
            return nextItem;
        }

        // Get previous Topper and places it at the front of the list.
        public WardrobeItem GetPreviousTopper()
        {
            var nextItem = this.Toppers.Last();
            this.Toppers.Remove(nextItem);
            this.Toppers.Insert(0, nextItem);
            return nextItem;
        }

        // Get previous UpperBody and places it at the front of the list.
        public WardrobeItem GetPreviousUpperBody()
        {
            var nextItem = this.UpperBodies.Last();
            this.UpperBodies.Remove(nextItem);
            this.UpperBodies.Insert(0, nextItem);
            return nextItem;
        }

        // Get previous LowerBody and places it at the front of the list.
        public WardrobeItem GetPreviousLowerBody()
        {
            var nextItem = this.LowerBodies.Last();
            this.LowerBodies.Remove(nextItem);
            this.LowerBodies.Insert(0, nextItem);
            return nextItem;
        }
    }
}