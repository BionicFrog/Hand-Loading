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
			
			
			
			
		}

		public void doob()
		{
			
			Find.WindowStack.Add(new HandLoading.HandLoadingWindow() { ammodef_selected = AmmoClassesDefOf.Ammo_556x45mmNATO_FMJ});
			
		}
		public ThingOwner<Thing> ingredients = new ThingOwner<Thing>();

		



	}
	public class BenchComp : ThingComp
	{
		
		public BenchCompProps Props => (BenchCompProps)this.props;
		public override void Initialize(CompProperties props)
		{
			
			



		}
		public override IEnumerable<Gizmo> CompGetGizmosExtra()
		{
			HandLoadingWindow winda = new HandLoading.HandLoadingWindow() { ammodef_selected = AmmoClassesDefOf.Ammo_556x45mmNATO_FMJ };
			yield return new Command_Action()
			{
				defaultLabel = "design bullets",
				defaultDesc = "design new bullets",
				icon = ContentFinder<Texture2D>.Get("Things/designing", true),
				
				action = delegate { Log.Error(this.parent.Position.ToString()); Log.Message(ParentHolder.ToString()); Find.WindowStack.Add(winda); winda.mapa = this.ParentHolder as Map; winda.Poss = this.parent.Position; }
				
				
			};
			
		}
	}
	public class BenchCompProps : CompProperties
	{
		
		public BenchCompProps()
		{
			this.compClass = typeof(BenchComp);
		}

		public BenchCompProps(Type compClass) : base(compClass)
		{
			this.compClass = compClass;
		}
	}
}
