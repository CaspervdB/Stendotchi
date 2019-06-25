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
    class CharAssembly
    {
        //public List<CharParts> Hairs;
        public List<CharParts> Headers;
        public List<CharParts> Torsos;
        public List<CharParts> Legs;

        public CharAssembly()
        {
            // Fill Lists with CharParts
            this.Headers = new List<CharParts>();
            this.Torsos = new List<CharParts>();
            this.Legs = new List<CharParts>();
            //Head
            AddHeader("Hoofd 1", "mipmap/testHoofd1.png");

            //Torso
            AddTorso("Short Sleeve Blue", "mipmap/testTorso1.png");
            AddTorso("Short Sleeve Dark Blue", "mipmap/testTorso2.png");

            //Legs
            AddLegs("Blauwe Broek", "mipmap/testLegs1.png");
        }

        // Add a new Header
        private void AddHeader(string name, string imagePath)
        {
            var part = new CharParts(name, imagePath);
            this.Headers.Add(part);
        }

        // Add a new UpperBody.
        private void AddTorso(string name, string imagePath)
        {
            var part = new CharParts(name, imagePath);
            this.Torsos.Add(part);
        }

        // Add a new LowerBody.
        private void AddLegs(string name, string imagePath)
        {
            var part = new CharParts(name, imagePath);
            this.Legs.Add(part);
        }

        // Get next head and places it at the back of the list.
        public CharParts GetNextHeader()
        {
            var nextPart = this.Headers[0];
            this.Headers.RemoveAt(0);
            this.Headers.Add(nextPart);
            return nextPart;
        }

        // Get next torso and places it at the back of the list.
        public CharParts GetNextTorso()
        {
            var nextPart = this.Torsos[0];
            this.Torsos.RemoveAt(0);
            this.Torsos.Add(nextPart);
            return nextPart;
        }

        // Get next LowerBody and places it at the back of the list.
        public CharParts GetNextLegs()
        {
            var nextPart = this.Legs[0];
            this.Legs.RemoveAt(0);
            this.Legs.Add(nextPart);
            return nextPart;
        }

        // Get previous Topper and places it at the front of the list.
        public CharParts GetPreviousHeader()
        {
            var nextPart = this.Headers[this.Headers.Count - 1];
            this.Headers.RemoveAt(this.Headers.Count - 1);
            this.Headers.Insert(0, nextPart);
            return nextPart;
        }

        // Get previous UpperBody and places it at the front of the list.
        public CharParts GetPreviousTorso()
        {
            var nextPart = this.Torsos[this.Torsos.Count - 1];
            this.Torsos.RemoveAt(this.Torsos.Count - 1);
            this.Torsos.Insert(0, nextPart);
            return nextPart;
        }

        // Get previous LowerBody and places it at the front of the list.
        public CharParts GetPreviousLegs()
        {
            var nextPart = this.Legs[this.Legs.Count - 1];
            this.Legs.RemoveAt(this.Legs.Count - 1);
            this.Legs.Insert(0, nextPart);
            return nextPart;
        }
    }
}