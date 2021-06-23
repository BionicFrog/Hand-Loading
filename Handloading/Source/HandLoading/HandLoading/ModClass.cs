using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using UnityEngine;
using Verse;
using Verse.Sound;
using CombatExtended;
using HarmonyLib;
using HarmonyMod;

namespace HandLoading
{
    public class OofMod : Mod
    {
       
        public OofMod(ModContentPack content) : base(content)
        {


           

            var harmony = new Harmony("Caulaflower.HandLoads.Coolmod");
            try
            {
                harmony.PatchAll();
            }
            catch (Exception e)
            {
                Log.Error("Failed to apply 1 or more harmony patches! See error:");
                Log.Error(e.ToString());
            }
        }
        public override void DoSettingsWindowContents(Rect inRect)
        {
            
        }
        
    }
   
   
}
