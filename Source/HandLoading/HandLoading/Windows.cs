using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Verse;
using RimWorld;
using CombatExtended;
using Verse.AI;
using Verse.Sound;
using UnityEngine;

namespace HandLoading
{
	
	public class HandLoadingWindow : Window
	{

	
		public override Vector2 InitialSize
		{
			get
			{
				return new Vector2(900f, 610f);
			}
		}


		public HandLoadingWindow()
		{

		}
		public Texture sometextureidk;
		private int pint = 0;
		public override void DoWindowContents(Rect inRect)
		{
			
			Rect rect1 = new Rect(inRect);
			rect1.width = HandLoadingWindow.Test.x + 16f;
			rect1.height = HandLoadingWindow.Test.y + 16f;
			rect1 = rect1.CenteredOnXIn(inRect);
			rect1 = rect1.CenteredOnYIn(inRect);
			rect1.x += 16f;
			rect1.y += 16f;
			Rect position = new Rect(rect1.xMin + (rect1.width - HandLoadingWindow.Test.x) / 2f - 10f, rect1.yMin + 20f, HandLoadingWindow.Test.x, HandLoadingWindow.Test.y);
			
			if (pint != 1)
			{
				ammodef_selected = AmmoClassesDefOf.Ammo_556x45mmNATO_FMJ;
				
				++pint;
			}







			Rect rect3 = new Rect(inRect);
			rect3.width = 20f;
			rect3.height = 20f;
			rect3 = rect3.CenteredOnXIn(inRect);
			rect3 = rect3.CenteredOnYIn(inRect);
			rect3.x += 16f;
			rect3.y += 16f;
			Rect rect4 = new Rect(inRect);
			rect4.width = 100f;
			rect4.height = 100f;
			rect4 = rect4.CenteredOnXIn(inRect);
			rect4 = rect4.CenteredOnYIn(inRect);
			rect4.x += -320f;
			rect4.y +=  200f;
			
			if (Widgets.ButtonText(rect4, "choose caliber"))
			{
				

					var options = new List<FloatMenuOption>
					{

					};
					//foreach (AmmoDef)
					List<AmmoDef> shlist = DefDatabase<AmmoDef>.AllDefs.ToList().FindAll(deffer => deffer.ammoClass == AmmoClassesDefOf.FullMetalJacket);


					foreach (AmmoDef ammodef in shlist)
					{
						FloatMenuOption floatmenuoption = new FloatMenuOption(ammodef.label, (delegate
						{
							
							this.ammodef_selected = ammodef;
							this.ammoclass_selected = ammodef.AmmoSetDefs.FindLast(dod => dod.ammoTypes != null);
							this.SelectedProjectile = ammoclass_selected.ammoTypes.Find(A => A.ammo == ammodef_selected).projectile;
							Log.Message(SelectedProjectile.ToString());
							Log.Error(ammodef_selected.ToString());
							Texture poob = ammodef_selected.uiIcon;
							sometextureidk = poob;

							
						}));

						options.Add(floatmenuoption);
					}


					Find.WindowStack.Add(new FloatMenu(options));


					
				
			}
			else
			{

			}
			Rect rect5 = new Rect(inRect);
			rect5.width = 100f;
			rect5.height = 100f;
			rect5 = rect5.CenteredOnXIn(inRect);
			rect5 = rect5.CenteredOnYIn(inRect);
			rect5.x += -320f;
			rect5.y += -100f;
			if (Widgets.ButtonText(rect5, "Choose Bullet's projectile material"))
			{
				var options2 = new List<FloatMenuOption>
				{

				};

				List<ThingDef> somelist = DefDatabase<ThingDef>.AllDefs.ToList().Where<ThingDef>(L => L.stuffProps?.categories?.Contains(StuffCategoryDefOf.Metallic)  == true).ToList();
				
				foreach (ThingDef szteel in somelist)
				{ 
					FloatMenuOption floatmenuoption = new FloatMenuOption(szteel.label, (delegate
					{
						projectile_material = szteel;
						hardness_material_multiplier = projectile_material.stuffProps.statFactors.Find(A => A.stat == StatDefOf.MaxHitPoints).value;
					}));

					options2.Add(floatmenuoption);
				}
				Find.WindowStack.Add(new FloatMenu(options2));
				
			}
			Rect rectCasing = new Rect(inRect);
			rectCasing.width = 100f;
			rectCasing.height = 100f;
			rectCasing = rectCasing.CenteredOnXIn(inRect);
			rectCasing = rectCasing.CenteredOnYIn(inRect);
			rectCasing.x += -320f;
			rectCasing.y += 100f;
			if (Widgets.ButtonText(rectCasing, "Choose Bullet's case material"))
			{
				var options2 = new List<FloatMenuOption>
				{

				};

				List<ThingDef> somelist = DefDatabase<ThingDef>.AllDefs.ToList().Where<ThingDef>(L => L.stuffProps?.categories?.Contains(StuffCategoryDefOf.Metallic) == true).ToList();

				foreach (ThingDef szteel in somelist)
				{
					FloatMenuOption floatmenuoption = new FloatMenuOption(szteel.label, (delegate
					{
						casematerial = szteel;
					}));

					options2.Add(floatmenuoption);
				}
				Find.WindowStack.Add(new FloatMenu(options2));

			}
			Rect rectPowder = new Rect(inRect);
			rectPowder.width = 100f;
			rectPowder.height = 100f;
			rectPowder = rectPowder.CenteredOnXIn(inRect);
			rectPowder = rectPowder.CenteredOnYIn(inRect);
			rectPowder.x += -320f;
			rectPowder.y += -0f;
			if (Widgets.ButtonText(rectPowder, "Choose propellant"))
			{
				var options3 = new List<FloatMenuOption>
				{

				};

				List<ThingDef> somelister = new List<ThingDef>();
				somelister.Add(AmmoClassesDefOf.IndustrialPowder);

				foreach (ThingDef szteel in somelister)
				{
					FloatMenuOption floatmenuoption = new FloatMenuOption(szteel.label, (delegate
					{
						Log.Message(szteel.ToString());
					}));

					options3.Add(floatmenuoption);
				}
				Find.WindowStack.Add(new FloatMenu(options3));

			}
			Rect rectDesign = new Rect(inRect);
			rectDesign.width = 100f;
			rectDesign.height = 100f;
			rectDesign = rectDesign.CenteredOnXIn(inRect);
			rectDesign = rectDesign.CenteredOnYIn(inRect);
			rectDesign.x += -320f;
			rectDesign.y += -200f;
			if (Widgets.ButtonText(rectDesign, "Choose projectile type"))
			{
				var options3 = new List<FloatMenuOption>
				{

				};

				List<String> somelister = new List<String>();
				somelister.Add("Hollow point");
				somelister.Add("Armor piercing");
				somelister.Add("Full metal jacket");
				somelister.Add("Sabot");

				foreach (String szteel in somelister)
				{
					FloatMenuOption floatmenuoption = new FloatMenuOption(szteel, (delegate
					{
						ProjectileShape = szteel;
					}));

					options3.Add(floatmenuoption);
				}
				Find.WindowStack.Add(new FloatMenu(options3));

			}

			Rect rect7 = new Rect(inRect);
			rect7.width = 80f;
			rect7.height = 80f;
			rect7 = rect7.CenteredOnXIn(inRect);
			rect7 = rect7.CenteredOnYIn(inRect);
			rect7.x += 320f;
			rect7.y += -200f;
			



			Rect rect6 = new Rect(inRect);
			rect6.width = 80f;
			rect6.height = 80f;
			rect6 = rect6.CenteredOnXIn(inRect);
			rect6 = rect6.CenteredOnYIn(inRect);
			rect6.x += 390f;
			rect6.y += 200f;
			
			if (Widgets.ButtonText(rect6, "Finish"))
			{
				CalculateAP();
				MadeProjectile = new ThingDef() { label = "somethingagainProjectile",  defName ="somethingPrjectile",graphicData = SelectedProjectile.graphicData, projectile = new ProjectilePropertiesCE() { damageDef = DamageDefOf.Bullet, armorPenetrationSharp = ArmorPenSharpCalculated, armorPenetrationBlunt = ArmorPenSharpCalculated, speed = CalculatedSpeed, flyOverhead = false, ai_IsIncendiary = false, dropsCasings = true, pelletCount = 1, stoppingPower = 2.5f} };
			    MadeAmmoDef = new AmmoDef() {label ="somethingagain" , defName = "something", graphicData = ammodef_selected.graphicData, cookOffProjectile = MadeProjectile, projectile = MadeProjectile.projectile };
				ammoclass_selected.ammoTypes.Add(new AmmoLink() {ammo = MadeAmmoDef, projectile = MadeProjectile});
				foreach (AmmoLink amlink in ammoclass_selected.ammoTypes)
				{
					Log.Error(amlink.ToString());
				}
				
				
				
				

				this.Close();

			}
			GUI.DrawTexture(position, sometextureidk);


			Text.Font = GameFont.Medium;
			Text.Anchor = TextAnchor.MiddleCenter;
			Widgets.Label(new Rect(0f, 0f, inRect.width, 32f), "Design bullets");
			Text.Font = GameFont.Small;
			Text.Anchor = TextAnchor.MiddleLeft;
			float num = 32f;
			Rect rect2 = new Rect(32f, num, 240f, 24f);


		}
		public List<ThingDef> ThingDefsToAddToDatabase;

		public string ProjectileShape;

		public string AmmoDefLabel;

		public float CalculatedSpeed;

		public float ArmorPenSharpCalculated;

		public float ArmorPenBluntCalculated;

		public ThingDef MadeProjectile;

		public ThingDef SelectedProjectile;

		public AmmoDef MadeAmmoDef;

		public float hardness_material_multiplier;

		public ThingDef projectile_material;

		public AmmoSetDef ammoclass_selected;

		public AmmoDef ammodef_selected;

		public ThingDef casematerial;

		private static readonly Vector2 Test = new Vector2(100f, 140f);

		
		
		public void CalculateAP()
		{
			float ShapeDoubleAP = 1f;
			switch (ProjectileShape)
			{
				case "Hollow point":
					ShapeDoubleAP = 0.5f;
					break;
				case "Armor Piercing":
					ShapeDoubleAP = 2f;
					break;
				case "Full Metal Jacket":
					ShapeDoubleAP = 1f;
					break;
				case "Sabot":
					ShapeDoubleAP = 3.5f;
					break;
			}
			ProjectilePropertiesCE propsCE = SelectedProjectile.projectile as ProjectilePropertiesCE;
			ArmorPenSharpCalculated = propsCE.armorPenetrationSharp * (ShapeDoubleAP * hardness_material_multiplier);
			Log.Message(ArmorPenSharpCalculated.ToString());
		}
		public void CalculateAPBlunt()
		{
			ArmorPenBluntCalculated = ArmorPenSharpCalculated * 2f;
			Log.Message(ArmorPenBluntCalculated.ToString());
		}


		
	}
	[DefOf]
	public static class AmmoClassesDefOf
	{
		
		static AmmoClassesDefOf()
		{
			DefOfHelper.EnsureInitializedInCtor(typeof(AmmoClassesDefOf));
		}

		
		public static AmmoCategoryDef FullMetalJacket;
		public static AmmoDef Ammo_556x45mmNATO_FMJ;
		public static ThingDef IndustrialPowder;
	}
	public class PowderComp : ThingComp
	{
		public float Power;
		public PowderCompProps Props => (PowderCompProps)this.props;
		public override void Initialize(CompProperties props)
		{
			Log.Message("initialised");
			this.parent.def = DefDatabase<AmmoDef>.AllDefs.ToList().Find(AA => AA.defName == "something");
			
			
		
		}
	}
	public class PowderCompProps : CompProperties
	{
		public float Power;
		public PowderCompProps()
		{
			this.compClass = typeof(PowderComp);
		}

		public PowderCompProps(Type compClass) : base(compClass)
		{
			this.compClass = compClass;
		}
	}
}

