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
    class Avatar
    {
        private CharCreaMainActivity _Activity;

        //private CharParts _Hairs { get; setl }
        private CharParts _headers { get; set; }
        private CharParts _torsos { get; set; }
        private CharParts _legs { get; set; }

        private CharAssembly _charAssembly;

        public Avatar(CharCreaMainActivity activity)
        {
            this._activity = activity;

            this._charAssembly = new CharAssembly();

        NextHeader();
        NextTorso();
        NextLegs();
        }

    //update parts
    private void UpdateCharacterUI(int resourceId, string name)
    {
        UpdateCharAssemblyPart(resourceId, part.Name);
        UpdateCharacterPartImage(resourceId, part.ImagePath);
    }

    // Next image of the part HEAD
    public void NextHead()
    {
        // Retrieve next.
        this._Head = this._CharAssembly.GetNextTopper();
        // Update UI.
        UpdateCharAssemblyUI(mipmap.Id.testHoofd1, this._head);
    }

    // Next image of the part HEAD
    public void NextTorso()
    {
        // Retrieve next.
        this._Torso = this._CharAssembly.GetNextTorso();
        // Update UI.
        UpdateCharAssemblyUI(mipmap.Id.testTorso1, this._Torso);
    }

    // Next image of the part HEAD
    public void NextLegs()
    {
        // Retrieve next.
        this._Legs = this._CharAssembly.GetNextLegs();
        // Update UI.
        UpdateCharAssemblyUI(mipmap.Id.testLegs1, this._Legs);
    }

    //PREVIOUS

    // Previous image of the part HEAD
    public void NextHead()
    {
        // Retrieve next.
        this._Head = this._CharAssembly.GetPreviousHead();
        // Update UI.
        UpdateCharAssemblyUI(mipmap.Id.testHead1, this._Head);
    }

    // Previous image of the part HEAD
    public void NextTorso()
    {
        // Retrieve next.
        this._Torso = this._CharAssembly.GetPreviousTorso();
        // Update UI.
        UpdateCharAssemblyUI(mipmap.Id.testTorso1, this._Torso);
    }

    // Previous image of the part HEAD
    public void NextLegs()
    {
        // Retrieve next.
        this._Legs = this._CharAssembly.GetPreviousLegs();
        // Update UI.
        UpdateCharAssemblyUI(mipmap.Id.testLegs1, this._Legs);
    }
}