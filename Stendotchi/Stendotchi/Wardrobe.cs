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
            AddTopper("Head One", "head/hoofd1.svg");
            AddTopper("Head Two", "head/hoofd2.svg");
            AddTopper("Head Three", "head/hoofd3.svg");

            AddUpperBody("Short Sleeve Blue", "shirt/kortemouwBlauw.svg");
            AddUpperBody("Short Sleeve Green", "shirt/kortemouwGroen.svg");
            AddUpperBody("Short Sleeve Red", "shirt/kortemouwRood.svg");
            AddUpperBody("Short Long Sleeve Red", "shirt/langemouwRood.svg");
            AddUpperBody("Short Long Sleeve Green", "shirt/langemouwGroen.svg");
            AddUpperBody("Short Long Sleeve Blue", "shirt/langemouwBlauw.svg");

            AddLowerBody("Shorts Blue", "jeans/kortebroekBlauw.svg");
            AddLowerBody("Shorts Brown", "jeans/kortebroekBruin.svg");
            AddLowerBody("Shorts Red", "jeans/kortebroekRood.svg");
            AddLowerBody("Trousers Blue", "jeans/langebroekRood.svg");
            AddLowerBody("Trousers Brown", "jeans/langebroekRood.svg");
            AddLowerBody("Trousers Grey", "jeans/langebroekRood.svg");
        }

        // Add a new Topper.
        private void AddTopper(string name, string imagePath)
        {
            var item = new WardrobeItem(name, imagePath);
            this.Toppers.Add(item);
        }

        // Add a new UpperBody.
        private void AddUpperBody(string name, string imagePath)
        {
            var item = new WardrobeItem(name, imagePath);
            this.UpperBodies.Add(item);
        }

        // Add a new LowerBody.
        private void AddLowerBody(string name, string imagePath)
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
            var nextItem = this.Toppers[this.Toppers.Count - 1];
            this.Toppers.RemoveAt(this.Toppers.Count - 1);
            this.Toppers.Insert(0, nextItem);
            return nextItem;
        }

        // Get previous UpperBody and places it at the front of the list.
        public WardrobeItem GetPreviousUpperBody()
        {
            var nextItem = this.UpperBodies[this.UpperBodies.Count - 1];
            this.UpperBodies.RemoveAt(this.UpperBodies.Count - 1);
            this.UpperBodies.Insert(0, nextItem);
            return nextItem;
        }

        // Get previous LowerBody and places it at the front of the list.
        public WardrobeItem GetPreviousLowerBody()
        {
            var nextItem = this.LowerBodies[this.LowerBodies.Count - 1];
            this.LowerBodies.RemoveAt(this.LowerBodies.Count - 1);
            this.LowerBodies.Insert(0, nextItem);
            return nextItem;
        }
    }
}