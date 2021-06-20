using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using UnityEngine;
using Verse;
using Verse.Sound;

namespace HandLoading
{
	
	// Token: 0x0200004F RID: 79
	public class LoadingBench : Building, IThingHolder
	{
		
		public bool StorageTabVisible
		{
			get
			{
				return true;
			}
		}

	
		public void GetChildHolders(List<IThingHolder> outChildren)
		{
		}
		public ThingOwner GetDirectlyHeldThings()
		{
			return this.ingredients;
		}





		public override void PostMake()
		{
			
			doob();
			
			
		}

		public void doob()
		{
			Find.WindowStack.Add(new HandLoading.HandLoadingWindow());
			
		}
		public ThingOwner<Thing> ingredients = new ThingOwner<Thing>();

		



	}
}
