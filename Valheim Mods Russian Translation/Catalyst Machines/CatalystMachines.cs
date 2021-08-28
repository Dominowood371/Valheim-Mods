using System;
using BepInEx;
using BepInEx.Configuration;
using Jotunn;
using Jotunn.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;
using UnityEngine;

namespace CatalystMachines
{
	// Token: 0x02000002 RID: 2
	[BepInPlugin("com.redridingwolf.catalystmachines", "Catalyst Machines", "0.0.5")]
	[BepInDependency("com.jotunn.jotunn", BepInDependency.DependencyFlags.HardDependency)]
	internal class CatalystMachines : BaseUnityPlugin
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		private void Awake()
		{
			base.Config.Bind<int>("Main Section", "This Will change the amount of seconds it takes to produce 1 resource, for now it does nothing", 1, new ConfigDescription("This is an example config, using a range limitation for ConfigurationManager", new AcceptableValueRange<int>(0, 100), Array.Empty<object>()));
			Jotunn.Logger.LogInfo("The princess and the firefly ready for the harvest!");
                        LoadAssets();
                        ItemManager.OnVanillaItemsAvailable += LoadSounds;
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002130 File Offset: 0x00000330

		        public void LoadAssets()
        {
            assetBundle = AssetUtils.LoadAssetBundleFromResources("catalystmachines", Assembly.GetExecutingAssembly());
        }

		// Token: 0x06000003 RID: 3 RVA: 0x0000208F File Offset: 0x0000028F
		public CatalystMachines()
		{
		}

		// Token: 0x04000001 RID: 1
		public const string PluginGUID = "com.redridingwolf.catalystmachines";

		// Token: 0x04000002 RID: 2
		public const string PluginName = "Catalyst Machines";

		// Token: 0x04000003 RID: 3
		public const string PluginVersion = "0.0.5";

	public AssetBundle assetBundle;
        public EffectList buildStone;
        public EffectList breakStone;
        public EffectList hitStone;
        public EffectList breakWood;
        public EffectList hitWood;
        public EffectList buildWood;
	
		private void LoadSounds()
        {
                var sfxStoneBuild = PrefabManager.Cache.GetPrefab<GameObject>("sfx_build_hammer_stone");
                var vfxStoneBuild = PrefabManager.Cache.GetPrefab<GameObject>("vfx_Place_stone_wall_2x1");
                var sfxWoodBuild = PrefabManager.Cache.GetPrefab<GameObject>("sfx_build_hammer_wood");
                var sfxBreakStone = PrefabManager.Cache.GetPrefab<GameObject>("sfx_rock_destroyed");
                var sfxWoodBreak = PrefabManager.Cache.GetPrefab<GameObject>("sfx_wood_break");
                var vfxWoodHit = PrefabManager.Cache.GetPrefab<GameObject>("vfx_SawDust");
                var sfxStoneHit = PrefabManager.Cache.GetPrefab<GameObject>("sfx_Rock_Hit");


                buildStone = new EffectList { m_effectPrefabs = new EffectList.EffectData[2] { new EffectList.EffectData { m_prefab = sfxStoneBuild }, new EffectList.EffectData { m_prefab = vfxStoneBuild } } };
                breakStone = new EffectList { m_effectPrefabs = new EffectList.EffectData[2] { new EffectList.EffectData { m_prefab = sfxBreakStone }, new EffectList.EffectData { m_prefab = vfxWoodHit } } };
                hitStone = new EffectList { m_effectPrefabs = new EffectList.EffectData[1] { new EffectList.EffectData { m_prefab = sfxStoneHit } } };
                buildWood = new EffectList { m_effectPrefabs = new EffectList.EffectData[2] { new EffectList.EffectData { m_prefab = sfxWoodBuild }, new EffectList.EffectData { m_prefab = vfxStoneBuild } } };
                breakWood = new EffectList { m_effectPrefabs = new EffectList.EffectData[2] { new EffectList.EffectData { m_prefab = sfxWoodBreak }, new EffectList.EffectData { m_prefab = vfxWoodHit } } };
                hitWood = new EffectList { m_effectPrefabs = new EffectList.EffectData[1] { new EffectList.EffectData { m_prefab = vfxWoodHit} } };

                ResinFarmT1();
                ResinFarmT2();
                StoneFarmT1();
                StoneFarmT2();
                WoodFarmT1();
                WoodFarmT2();

                Jotunn.Logger.LogMessage("Loaded Game VFX and SFX");
                Jotunn.Logger.LogMessage("Load Complete.");

                ItemManager.OnVanillaItemsAvailable -= LoadSounds;
            //}
        }

		private void ResinFarmT1()
        {

            var buildFab = assetBundle.LoadAsset<GameObject>("ResinFarmT1");
            var build = new CustomPiece(buildFab,
                new PieceConfig
                {
                            Name = "$item_treetap_name",
							Description = "$item_treetap_desc",
							PieceTable = "Hammer",
							Requirements = new RequirementConfig[]
							{
								new RequirementConfig
								{
									Item = "KnifeFlint",
									Amount = 1,
									Recover = true
								},
								new RequirementConfig
								{
									Item = "Stone",
									Amount = 15,
									Recover = true
								},
								new RequirementConfig
								{
									Item = "DeerHide",
									Amount = 10,
									Recover = true
								}
							}
                });
            var buildfx = buildFab.GetComponent<Piece>();
            buildfx.m_placeEffect = buildStone;

            var breakfx = buildFab.GetComponent<WearNTear>();
            breakfx.m_destroyedEffect = breakStone;
            breakfx.m_hitEffect = hitStone;
            PieceManager.Instance.AddPiece(build);
        }

		private void ResinFarmT2()
        {

            var buildFab = assetBundle.LoadAsset<GameObject>("ResinFarmT2");
            var build = new CustomPiece(buildFab,
                new PieceConfig
                {
							Name = "$item_resinfermenter_name",
							Description = "$item_resinfermenter_desc",
							PieceTable = "Hammer",
							Requirements = new RequirementConfig[]
							{
								new RequirementConfig
								{
									Item = "FineWood",
									Amount = 100,
									Recover = true
								},
								new RequirementConfig
								{
									Item = "Stone",
									Amount = 150,
									Recover = true
								},
								new RequirementConfig
								{
									Item = "Resin",
									Amount = 100,
									Recover = true
								}
							}

                });
            var fxBuild = buildFab.GetComponent<Piece>();
            fxBuild.m_placeEffect = buildWood;

            var fxHit = buildFab.GetComponent<WearNTear>();
            fxHit.m_hitEffect = hitWood;
            fxHit.m_destroyedEffect = breakWood;
            PieceManager.Instance.AddPiece(build);
        }

		private void StoneFarmT1()
        {

            var buildFab = assetBundle.LoadAsset<GameObject>("StoneFarmT1");
            var build = new CustomPiece(buildFab,
                new PieceConfig
                {
   							Name = "$item_gravelspot_name",
							Description = "$item_gravelspot_desc",
							PieceTable = "Hammer",
							Requirements = new RequirementConfig[]
							{
								new RequirementConfig
								{
									Item = "PickaxeAntler",
									Amount = 1,
									Recover = true
								},
								new RequirementConfig
								{
									Item = "Stone",
									Amount = 30,
									Recover = true
								},
								new RequirementConfig
								{
									Item = "Resin",
									Amount = 10,
									Recover = true
								},
								new RequirementConfig
								{
									Item = "SurtlingCore",
									Amount = 5,
									Recover = true
								}
							}

                });
            var buildfx = buildFab.GetComponent<Piece>();
            buildfx.m_placeEffect = buildStone;

            var breakfx = buildFab.GetComponent<WearNTear>();
            breakfx.m_destroyedEffect = breakStone;
            breakfx.m_hitEffect = hitStone;
            PieceManager.Instance.AddPiece(build);

        }

		private void StoneFarmT2()
        {

            var buildFab = assetBundle.LoadAsset<GameObject>("StoneFarmT2");
            var build = new CustomPiece(buildFab,
                new PieceConfig
                {
							Name = "$item_stoneharveste_name",
							Description = "$item_stoneharveste_desc",
							PieceTable = "Hammer",
							Requirements = new RequirementConfig[]
							{
								new RequirementConfig
								{
									Item = "PickaxeBronze",
									Amount = 4,
									Recover = true
								},
								new RequirementConfig
								{
									Item = "Stone",
									Amount = 100,
									Recover = true
								},
								new RequirementConfig
								{
									Item = "Resin",
									Amount = 100,
									Recover = true
								},
								new RequirementConfig
								{
									Item = "SurtlingCore",
									Amount = 20,
									Recover = true
								}
							}

                });
            var fxBuild = buildFab.GetComponent<Piece>();
            fxBuild.m_placeEffect = buildWood;

            var fxHit = buildFab.GetComponent<WearNTear>();
            fxHit.m_hitEffect = hitWood;
            fxHit.m_destroyedEffect = breakWood;
            PieceManager.Instance.AddPiece(build);
        }

		private void WoodFarmT1()
        {

            var buildFab = assetBundle.LoadAsset<GameObject>("WoodFarmT1");
            var build = new CustomPiece(buildFab,
                new PieceConfig
                {
							Name = "$item_greydwarfharvester_name",
							Description = "$item_greydwarfharvester_desc",
							PieceTable = "Hammer",
							Requirements = new RequirementConfig[]
							{
								new RequirementConfig
								{
									Item = "Stone",
									Amount = 20,
									Recover = true
								},
								new RequirementConfig
								{
									Item = "HardAntler",
									Amount = 5,
									Recover = true
								},
								new RequirementConfig
								{
									Item = "AncientSeed",
									Amount = 5,
									Recover = true
								},
								new RequirementConfig
								{
									Item = "AxeBronze",
									Amount = 1,
									Recover = true
								}
							}

                });
            var buildfx = buildFab.GetComponent<Piece>();
            buildfx.m_placeEffect = buildStone;

            var breakfx = buildFab.GetComponent<WearNTear>();
            breakfx.m_destroyedEffect = breakStone;
            breakfx.m_hitEffect = hitStone;
            PieceManager.Instance.AddPiece(build);
        }

		private void WoodFarmT2()
        {

            var buildFab = assetBundle.LoadAsset<GameObject>("WoodFarmT2");
            var build = new CustomPiece(buildFab,
                new PieceConfig
                {
							Name = "$item_ancientharvester_name",
							Description = "$item_ancientharvester_desc",
							PieceTable = "Hammer",
							Requirements = new RequirementConfig[]
							{
								new RequirementConfig
								{
									Item = "Stone",
									Amount = 100,
									Recover = true
								},
								new RequirementConfig
								{
									Item = "FineWood",
									Amount = 100,
									Recover = true
								},
								new RequirementConfig
								{
									Item = "AncientSeed",
									Amount = 50,
									Recover = true
								}
							}

                });
            var fxBuild = buildFab.GetComponent<Piece>();
            fxBuild.m_placeEffect = buildWood;

            var fxHit = buildFab.GetComponent<WearNTear>();
            fxHit.m_hitEffect = hitWood;
            fxHit.m_destroyedEffect = breakWood;
            PieceManager.Instance.AddPiece(build);
}
	}
}
