using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using Jotunn;
using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;
using Jotunn.Utils;
using On;
using UnityEngine;

namespace MaorBuilds
{
	// Token: 0x02000002 RID: 2
	[BepInPlugin("com.zarboz.moarbuilds", "MoArBuIlDs", "1.0.8")]
	[BepInDependency("com.jotunn.jotunn", BepInDependency.DependencyFlags.HardDependency)]
	[NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.None)]
	internal class MoarBuilds : BaseUnityPlugin
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		private void Awake()
		{
			this.ConfigThing();
			this.SpriteThings();
			ItemManager.OnVanillaItemsAvailable += this.GrabPieces;
			SynchronizationManager.OnConfigurationSynchronized += delegate(object obj, ConfigurationSynchronizationEventArgs attr)
			{
				if (attr.InitialSynchronization)
				{
					Jotunn.Logger.LogMessage("Initial Config sync event received");
					this.configsyncheard();
					return;
				}
				Jotunn.Logger.LogMessage("Config sync event received");
			};
			Jotunn.Logger.ShowDate = true;
			Harmony.CreateAndPatchAll(typeof(MoarBuilds).Assembly, null);
			On.TeleportWorld.Awake += this.TeleportWorldAwakePrefix;
			On.Game.ConnectPortals += this.GameConnectPortalsPrefix;
		}

		// Token: 0x06000002 RID: 2 RVA: 0x000020CC File Offset: 0x000002CC
		private void TeleportWorldAwakePrefix(On.TeleportWorld.orig_Awake orig, global::TeleportWorld self)
		{
			if (!this._isModEnabled.Value)
			{
				orig(self);
				return;
			}
			self.m_nview = self.GetComponent<global::ZNetView>();
			if (self.m_nview.GetZDO() == null)
			{
				self.enabled = false;
				return;
			}
			self.m_hadTarget = self.HaveTarget();
			if (!self.m_proximityRoot)
			{
				self.m_proximityRoot = self.transform;
			}
			if (self.m_target_found == null)
			{
				GameObject gameObject = self.gameObject.transform.Find("_target_found").gameObject;
				gameObject.SetActive(false);
				self.m_target_found = gameObject.AddComponent<global::EffectFade>();
				gameObject.SetActive(true);
			}
			self.m_nview.Register<string>("SetTag", new Action<long, string>(self.RPC_SetTag));
			self.InvokeRepeating("UpdatePortal", 0.5f, 0.5f);
		}

		// Token: 0x06000003 RID: 3 RVA: 0x000021A8 File Offset: 0x000003A8
		private static bool GetAllZdosMatchingPrefabHashcodes(global::ZDOMan zdoMan, HashSet<int> prefabHashcodes, List<global::ZDO> matchingZdos, ref int index)
		{
			if (index >= zdoMan.m_objectsBySector.Length)
			{
				Func<global::ZDO, bool> <>9__0;
				foreach (List<global::ZDO> list in zdoMan.m_objectsByOutsideSector.Values)
				{
					IEnumerable<global::ZDO> source = list;
					Func<global::ZDO, bool> predicate;
					if ((predicate = <>9__0) == null)
					{
						predicate = (<>9__0 = ((global::ZDO zdo) => zdo.IsValid() && prefabHashcodes.Contains(zdo.GetPrefab())));
					}
					matchingZdos.AddRange(source.Where(predicate));
				}
				return true;
			}
			int num = 0;
			Func<global::ZDO, bool> <>9__1;
			while (index < zdoMan.m_objectsBySector.Length)
			{
				List<global::ZDO> list2 = zdoMan.m_objectsBySector[index];
				if (list2 != null)
				{
					IEnumerable<global::ZDO> source2 = list2;
					Func<global::ZDO, bool> predicate2;
					if ((predicate2 = <>9__1) == null)
					{
						predicate2 = (<>9__1 = ((global::ZDO zdo) => prefabHashcodes.Contains(zdo.GetPrefab())));
					}
					IEnumerable<global::ZDO> enumerable = source2.Where(predicate2);
					matchingZdos.AddRange(enumerable);
					num += Enumerable.Count<global::ZDO>(enumerable);
				}
				index++;
				if (num > 500)
				{
					break;
				}
			}
			return false;
		}

		// Token: 0x06000004 RID: 4 RVA: 0x000022AC File Offset: 0x000004AC
		private void configsyncheard()
		{
			this.ctn.m_width = this.chestwidth.Value;
			this.ctn.m_height = this.chestheight.Value;
			this.basketchest.m_width = this.basketwidth.Value;
			this.basketchest.m_height = this.basketheight.Value;
			this.barrell3chest.m_width = this.altbarrelwidth.Value;
			this.barrell3chest.m_height = this.altbarrelheight.Value;
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002340 File Offset: 0x00000540
		private void ConfigThing()
		{
			this.GoblinStick = base.Config.Bind<bool>("GoblinStick", "Turn Goblin Brute Weapon off and on", false, new ConfigDescription("Turn the goblin stick on or off", null, new object[]
			{
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.BarrelHeight = base.Config.Bind<int>("Barrel Size", "Barrel Container Height", 4, new ConfigDescription("Container Height for barrell", new AcceptableValueRange<int>(0, 10), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.BarrelWidth = base.Config.Bind<int>("Barrel Size", "Barrel Container Width", 4, new ConfigDescription("Container Width for barrell", new AcceptableValueRange<int>(0, 8), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.chestheight = base.Config.Bind<int>("Chest Size", "Chest Container Height", 4, new ConfigDescription("Container Height for Chest", new AcceptableValueRange<int>(0, 10), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.chestwidth = base.Config.Bind<int>("Chest Size", "Chest Container Width", 4, new ConfigDescription("Container Width for Chest", new AcceptableValueRange<int>(0, 8), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.basketheight = base.Config.Bind<int>("Basket Size", "Basket Container Height", 4, new ConfigDescription("Container Height for Basket", new AcceptableValueRange<int>(0, 10), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.basketwidth = base.Config.Bind<int>("Basket Size", "Basket Container Width", 4, new ConfigDescription("Container Width for Basket", new AcceptableValueRange<int>(0, 8), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.altbarrelheight = base.Config.Bind<int>("AltBarrel Size", "AltBarrel Container Height", 4, new ConfigDescription("Container Height for AltBarrel", new AcceptableValueRange<int>(0, 10), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.altbarrelwidth = base.Config.Bind<int>("AltBarrel Size", "AltBarrel Width", 4, new ConfigDescription("Container Width for AltBarrel", new AcceptableValueRange<int>(0, 8), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.CrateCraftingMat = base.Config.Bind<string>("Crate Crafting Mat", "Crate Material 1", "Iron", new ConfigDescription("Crate Material #1", null, new object[]
			{
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.CrateCraftingMat2 = base.Config.Bind<string>("Crate Crafting Mat", "Crate Material 2", "Wood", new ConfigDescription("Crate Material #2", null, new object[]
			{
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this._connectPortalCoroutineWait = base.Config.Bind<float>("Portals", "connectPortalCoroutineWait", 4f, new ConfigDescription("Wait time (seconds) when ConnectPortal coroutine yields.", null, new object[]
			{
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this._portalPrefabName = base.Config.Bind<string>("Portals", "portalPrefabName", "Stone_Portal", new ConfigDescription("Alternative portal prefab name to search for.", null, new object[]
			{
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this._onewayPortalTagPrefix = base.Config.Bind<string>("Portals", "onewayPortalTagPrefix", ">>>", new ConfigDescription("Prefix for specifying a one-way portal.", null, new object[]
			{
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this._getMatchingZdosBreakCount = base.Config.Bind<int>("Portals", "getMatchingZdosBreakCount", 400, new ConfigDescription("Max ZDOs to match before breaking/pausing in method.", new AcceptableValueRange<int>(0, 1600), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this._isModEnabled = base.Config.Bind<bool>("Portals", "This enables connection of stone portal -> normal portals", true, new ConfigDescription("disable or enable prefab linking for portals", null, new object[]
			{
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002764 File Offset: 0x00000964
		private void SpriteThings()
		{
			this.spritebundle1 = AssetUtils.LoadAssetBundleFromResources("capsprite", typeof(MoarBuilds).Assembly);
			this.assetBundle = AssetUtils.LoadAssetBundleFromResources("sprites", typeof(MoarBuilds).Assembly);
			this.goblinfence = this.assetBundle.LoadAsset<Sprite>("goblinfence");
			this.goblinspike = this.assetBundle.LoadAsset<Sprite>("goblinpsike");
			this.goblinribwall2m = this.assetBundle.LoadAsset<Sprite>("goblinribwall2m");
			this.roof45 = this.assetBundle.LoadAsset<Sprite>("roof45");
			this.roof45corner = this.assetBundle.LoadAsset<Sprite>("Roof45Corner");
			this.woodwall1m = this.assetBundle.LoadAsset<Sprite>("woodwall1m");
			this.woodwall2m = this.assetBundle.LoadAsset<Sprite>("woodwall2m");
			this.dungeongate1 = this.assetBundle.LoadAsset<Sprite>("dungeongate");
			this.goblinbanner1 = this.assetBundle.LoadAsset<Sprite>("goblinbanner");
			this.goblinsmacker1 = this.assetBundle.LoadAsset<Sprite>("goblinsmacker");
			this.capsprite = this.spritebundle1.LoadAsset<Sprite>("default");
			this.barrelsprite = this.spritebundle1.LoadAsset<Sprite>("barrel_icon");
			this.basketsprite = this.spritebundle1.LoadAsset<Sprite>("basket");
			this.barrelaltsprite = this.spritebundle1.LoadAsset<Sprite>("barrelalt");
			this.boxsprite = this.spritebundle1.LoadAsset<Sprite>("boxes");
			this.chestsprite = this.spritebundle1.LoadAsset<Sprite>("chest");
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002910 File Offset: 0x00000B10
		private void LoadAssets()
		{
			this.clutterassets = AssetUtils.LoadAssetBundleFromResources("containerclutter", typeof(MoarBuilds).Assembly);
			GameObject gameObject = this.clutterassets.LoadAsset<GameObject>("TraderChest_static");
			GameObject gameObject2 = this.clutterassets.LoadAsset<GameObject>("fi_vil_container_basket02_closed");
			GameObject gameObject3 = this.clutterassets.LoadAsset<GameObject>("fi_vil_container_barrel_small");
			GameObject gameObject4 = this.clutterassets.LoadAsset<GameObject>("default");
			GameObject gameObject5 = this.clutterassets.LoadAsset<GameObject>("fi_vil_container_crate_big_x4_01");
			gameObject.AddComponent<global::Piece>();
			global::ZSyncTransform zsyncTransform = gameObject.AddComponent<global::ZSyncTransform>();
			zsyncTransform.m_syncRotation = true;
			zsyncTransform.m_syncScale = true;
			zsyncTransform.m_syncPosition = true;
			gameObject.AddComponent<global::ZNetView>().m_persistent = true;
			this.ctn = gameObject.AddComponent<global::Container>();
			this.ctn.m_width = this.chestwidth.Value;
			this.ctn.m_height = this.chestheight.Value;
			this.ctn.m_name = "$piece_traderchest_name";
			this.ctn.m_checkGuardStone = true;
			this.ctn.m_bkg = PrefabManager.Cache.GetPrefab<GameObject>("piece_chest").GetComponent<global::Container>().m_bkg;
			CustomPiece customPiece = new CustomPiece(gameObject, new PieceConfig
			{
				PieceTable = "_HammerPieceTable",
				AllowedInDungeons = false,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Iron",
						Amount = 5,
						Recover = true
					},
					new RequirementConfig
					{
						Item = "Wood",
						Amount = 10,
						Recover = true
					}
				}
			});
			customPiece.Piece.m_name = "$piece_traderchest_name";
			customPiece.Piece.m_description = "$piece_traderchest_desc";
			customPiece.Piece.m_canBeRemoved = true;
			customPiece.Piece.m_icon = this.chestsprite;
			customPiece.Piece.m_primaryTarget = false;
			customPiece.Piece.m_randomTarget = false;
			customPiece.Piece.m_category = global::Piece.PieceCategory.Building;
			customPiece.Piece.m_enabled = true;
			customPiece.Piece.m_clipEverything = true;
			customPiece.Piece.m_isUpgrade = false;
			customPiece.Piece.m_comfort = 0;
			customPiece.Piece.m_groundPiece = false;
			customPiece.Piece.m_allowAltGroundPlacement = false;
			customPiece.Piece.m_cultivatedGroundOnly = false;
			customPiece.Piece.m_waterPiece = false;
			customPiece.Piece.m_noInWater = false;
			customPiece.Piece.m_notOnWood = false;
			customPiece.Piece.m_notOnTiltingSurface = false;
			customPiece.Piece.m_noClipping = false;
			customPiece.Piece.m_onlyInTeleportArea = false;
			customPiece.Piece.m_allowedInDungeons = false;
			customPiece.Piece.m_spaceRequirement = 0f;
			customPiece.Piece.m_placeEffect = this.effectList;
			gameObject.AddComponent<global::WearNTear>().m_health = 1000f;
			PieceManager.Instance.AddPiece(customPiece);
			gameObject2.transform.localScale = new Vector3(1.75f, 1.75f, 1.75f);
			gameObject2.AddComponent<global::Piece>();
			global::ZNetView znetView = gameObject2.AddComponent<global::ZNetView>();
			znetView.m_persistent = true;
			znetView.m_type = global::ZDO.ObjectType.Solid;
			global::ZSyncTransform zsyncTransform2 = gameObject2.AddComponent<global::ZSyncTransform>();
			zsyncTransform2.m_syncRotation = true;
			zsyncTransform2.m_syncScale = true;
			zsyncTransform2.m_syncPosition = true;
			this.basketchest = gameObject2.AddComponent<global::Container>();
			gameObject2.transform.position = new Vector3(0f, 0f, 0f);
			gameObject2.transform.localPosition = new Vector3(0f, 0f, 0f);
			this.basketchest.m_width = this.basketwidth.Value;
			this.basketchest.m_height = this.basketheight.Value;
			this.basketchest.m_name = "$piece_tradersbasket_name";
			this.basketchest.m_checkGuardStone = true;
			this.basketchest.m_bkg = PrefabManager.Cache.GetPrefab<GameObject>("piece_chest").GetComponent<global::Container>().m_bkg;
			CustomPiece customPiece2 = new CustomPiece(gameObject2, new PieceConfig
			{
				PieceTable = "_HammerPieceTable",
				AllowedInDungeons = false,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Iron",
						Amount = 5,
						Recover = true
					},
					new RequirementConfig
					{
						Item = "Wood",
						Amount = 10,
						Recover = true
					}
				}
			});
			customPiece2.Piece.m_name = "$piece_tradersbasket_name";
			customPiece2.Piece.m_description = "$piece_tradersbasket_desc";
			customPiece2.Piece.m_canBeRemoved = true;
			customPiece2.Piece.m_icon = this.basketsprite;
			customPiece2.Piece.m_primaryTarget = false;
			customPiece2.Piece.m_randomTarget = false;
			customPiece2.Piece.m_category = global::Piece.PieceCategory.Building;
			customPiece2.Piece.m_enabled = true;
			customPiece2.Piece.m_clipEverything = true;
			customPiece2.Piece.m_isUpgrade = false;
			customPiece2.Piece.m_comfort = 0;
			customPiece2.Piece.m_groundPiece = false;
			customPiece2.Piece.m_allowAltGroundPlacement = false;
			customPiece2.Piece.m_cultivatedGroundOnly = false;
			customPiece2.Piece.m_waterPiece = false;
			customPiece2.Piece.m_noInWater = false;
			customPiece2.Piece.m_notOnWood = false;
			customPiece2.Piece.m_notOnTiltingSurface = false;
			customPiece2.Piece.m_noClipping = false;
			customPiece2.Piece.m_onlyInTeleportArea = false;
			customPiece2.Piece.m_allowedInDungeons = false;
			customPiece2.Piece.m_spaceRequirement = 0f;
			customPiece2.Piece.m_placeEffect = this.effectList;
			PieceManager.Instance.AddPiece(customPiece2);
			gameObject3.AddComponent<global::Piece>();
			global::ZNetView znetView2 = gameObject3.AddComponent<global::ZNetView>();
			Vector3 localScale = new Vector3(1.5f, 1.5f, 1.5f);
			znetView2.SetLocalScale(localScale);
			znetView2.m_persistent = true;
			global::ZSyncTransform zsyncTransform3 = gameObject3.AddComponent<global::ZSyncTransform>();
			zsyncTransform3.m_syncRotation = true;
			zsyncTransform3.m_syncScale = true;
			zsyncTransform3.m_syncPosition = true;
			this.barrell3chest = gameObject3.AddComponent<global::Container>();
			gameObject3.transform.position = new Vector3(0f, 0f, 0f);
			gameObject3.transform.localPosition = new Vector3(0f, 0f, 0f);
			gameObject3.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
			this.barrell3chest.m_width = this.altbarrelwidth.Value;
			this.barrell3chest.m_height = this.altbarrelheight.Value;
			this.barrell3chest.m_name = "$piece_traderroundbarrel_name";
			this.barrell3chest.m_checkGuardStone = true;
			this.barrell3chest.m_bkg = PrefabManager.Cache.GetPrefab<GameObject>("piece_chest").GetComponent<global::Container>().m_bkg;
			CustomPiece customPiece3 = new CustomPiece(gameObject3, new PieceConfig
			{
				PieceTable = "_HammerPieceTable",
				AllowedInDungeons = false,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Iron",
						Amount = 5,
						Recover = true
					},
					new RequirementConfig
					{
						Item = "Wood",
						Amount = 10,
						Recover = true
					}
				}
			});
			customPiece3.Piece.m_name = "$piece_traderroundbarrel_name";
			customPiece3.Piece.m_description = "$piece_traderroundbarrel_desc";
			customPiece3.Piece.m_canBeRemoved = true;
			customPiece3.Piece.m_icon = this.barrelaltsprite;
			customPiece3.Piece.m_primaryTarget = false;
			customPiece3.Piece.m_randomTarget = false;
			customPiece3.Piece.m_category = global::Piece.PieceCategory.Building;
			customPiece3.Piece.m_enabled = true;
			customPiece3.Piece.m_clipEverything = true;
			customPiece3.Piece.m_isUpgrade = false;
			customPiece3.Piece.m_comfort = 0;
			customPiece3.Piece.m_groundPiece = false;
			customPiece3.Piece.m_allowAltGroundPlacement = false;
			customPiece3.Piece.m_cultivatedGroundOnly = false;
			customPiece3.Piece.m_waterPiece = false;
			customPiece3.Piece.m_noInWater = false;
			customPiece3.Piece.m_notOnWood = false;
			customPiece3.Piece.m_notOnTiltingSurface = false;
			customPiece3.Piece.m_noClipping = false;
			customPiece3.Piece.m_onlyInTeleportArea = false;
			customPiece3.Piece.m_allowedInDungeons = false;
			customPiece3.Piece.m_spaceRequirement = 0f;
			customPiece3.Piece.m_placeEffect = this.effectList;
			gameObject3.AddComponent<global::WearNTear>().m_health = 1000f;
			PieceManager.Instance.AddPiece(customPiece3);
			gameObject4.AddComponent<global::Piece>();
			global::ZNetView znetView3 = gameObject4.AddComponent<global::ZNetView>();
			global::ZSyncTransform zsyncTransform4 = gameObject4.AddComponent<global::ZSyncTransform>();
			zsyncTransform4.m_syncPosition = true;
			zsyncTransform4.m_syncScale = true;
			zsyncTransform4.m_syncRotation = true;
			znetView3.m_syncInitialScale = true;
			znetView3.m_type = global::ZDO.ObjectType.Solid;
			znetView3.m_persistent = true;
			this.roundchest = gameObject4.AddComponent<global::Container>();
			gameObject4.transform.position = new Vector3(0f, 3f, 0f);
			gameObject4.transform.localPosition = new Vector3(0f, 3f, 0f);
			this.roundchest.m_width = this.BarrelWidth.Value;
			this.roundchest.m_height = this.BarrelHeight.Value;
			this.roundchest.m_name = "$piece_traderroundbarrel2_name";
			this.roundchest.m_checkGuardStone = true;
			this.roundchest.m_bkg = PrefabManager.Cache.GetPrefab<GameObject>("piece_chest").GetComponent<global::Container>().m_bkg;
			CustomPiece customPiece4 = new CustomPiece(gameObject4, new PieceConfig
			{
				PieceTable = "_HammerPieceTable",
				AllowedInDungeons = false,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Iron",
						Amount = 5,
						Recover = true
					},
					new RequirementConfig
					{
						Item = "Wood",
						Amount = 10,
						Recover = true
					}
				}
			});
			customPiece4.Piece.m_name = "$piece_traderroundbarrel2_name";
			customPiece4.Piece.m_description = "$piece_traderroundbarrel2_desc";
			customPiece4.Piece.m_canBeRemoved = true;
			customPiece4.Piece.m_icon = this.barrelsprite;
			customPiece4.Piece.m_primaryTarget = false;
			customPiece4.Piece.m_randomTarget = false;
			customPiece4.Piece.m_category = global::Piece.PieceCategory.Building;
			customPiece4.Piece.m_enabled = true;
			customPiece4.Piece.m_clipEverything = true;
			customPiece4.Piece.m_isUpgrade = false;
			customPiece4.Piece.m_comfort = 0;
			customPiece4.Piece.m_groundPiece = false;
			customPiece4.Piece.m_allowAltGroundPlacement = false;
			customPiece4.Piece.m_cultivatedGroundOnly = false;
			customPiece4.Piece.m_waterPiece = false;
			customPiece4.Piece.m_noInWater = false;
			customPiece4.Piece.m_notOnWood = false;
			customPiece4.Piece.m_notOnTiltingSurface = false;
			customPiece4.Piece.m_noClipping = false;
			customPiece4.Piece.m_onlyInTeleportArea = false;
			customPiece4.Piece.m_allowedInDungeons = false;
			customPiece4.Piece.m_spaceRequirement = 0f;
			customPiece4.Piece.m_placeEffect = this.effectList;
			gameObject4.AddComponent<global::WearNTear>().m_health = 1000f;
			PieceManager.Instance.AddPiece(customPiece4);
			gameObject5.AddComponent<global::Piece>();
			global::ZNetView znetView4 = gameObject5.AddComponent<global::ZNetView>();
			global::ZSyncTransform zsyncTransform5 = gameObject5.AddComponent<global::ZSyncTransform>();
			zsyncTransform5.m_syncPosition = true;
			zsyncTransform5.m_syncScale = true;
			zsyncTransform5.m_syncRotation = true;
			znetView4.m_syncInitialScale = true;
			znetView4.m_type = global::ZDO.ObjectType.Solid;
			znetView4.m_persistent = true;
			this.cratechest = gameObject5.AddComponent<global::Container>();
			gameObject5.transform.position = new Vector3(0f, 0f, 0f);
			gameObject5.transform.localPosition = new Vector3(0f, 0f, 0f);
			this.cratechest.m_width = 8;
			this.cratechest.m_height = 4;
			this.cratechest.m_bkg = PrefabManager.Cache.GetPrefab<GameObject>("piece_chest").GetComponent<global::Container>().m_bkg;
			this.cratechest.m_name = "$piece_crates_name";
			this.cratechest.m_checkGuardStone = true;
			CustomPiece customPiece5 = new CustomPiece(gameObject5, new PieceConfig
			{
				PieceTable = "_HammerPieceTable",
				AllowedInDungeons = false,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = this.CrateCraftingMat.Value,
						Amount = 5,
						Recover = true
					},
					new RequirementConfig
					{
						Item = this.CrateCraftingMat2.Value,
						Amount = 10,
						Recover = true
					}
				}
			});
			customPiece5.Piece.m_name = "$piece_crates_name";
			customPiece5.Piece.m_description = "$piece_crates_desc";
			customPiece5.Piece.m_canBeRemoved = true;
			customPiece5.Piece.m_icon = this.boxsprite;
			customPiece5.Piece.m_primaryTarget = false;
			customPiece5.Piece.m_randomTarget = false;
			customPiece5.Piece.m_category = global::Piece.PieceCategory.Building;
			customPiece5.Piece.m_enabled = true;
			customPiece5.Piece.m_clipEverything = true;
			customPiece5.Piece.m_isUpgrade = false;
			customPiece5.Piece.m_comfort = 0;
			customPiece5.Piece.m_groundPiece = false;
			customPiece5.Piece.m_allowAltGroundPlacement = false;
			customPiece5.Piece.m_cultivatedGroundOnly = false;
			customPiece5.Piece.m_waterPiece = false;
			customPiece5.Piece.m_noInWater = false;
			customPiece5.Piece.m_notOnWood = false;
			customPiece5.Piece.m_notOnTiltingSurface = false;
			customPiece5.Piece.m_noClipping = false;
			customPiece5.Piece.m_onlyInTeleportArea = false;
			customPiece5.Piece.m_allowedInDungeons = false;
			customPiece5.Piece.m_spaceRequirement = 0f;
			customPiece5.Piece.m_placeEffect = this.effectList;
			gameObject5.AddComponent<global::WearNTear>().m_health = 1000f;
			PieceManager.Instance.AddPiece(customPiece5);
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00003738 File Offset: 0x00001938
		private void GrabPieces()
		{
			try
			{
				GameObject prefab = PrefabManager.Cache.GetPrefab<GameObject>("sfx_build_hammer_wood");
				GameObject prefab2 = PrefabManager.Cache.GetPrefab<GameObject>("vfx_Place_wood_roof");
				PrefabManager.Cache.GetPrefab<GameObject>("vfx_Place_wood_wall_roof");
				GameObject prefab3 = PrefabManager.Cache.GetPrefab<GameObject>("vfx_Place_wood_wall_half");
				this.effectList = new global::EffectList
				{
					m_effectPrefabs = new global::EffectList.EffectData[]
					{
						new global::EffectList.EffectData
						{
							m_prefab = prefab
						},
						new global::EffectList.EffectData
						{
							m_prefab = prefab2
						}
					}
				};
				global::EffectList placeEffect = new global::EffectList
				{
					m_effectPrefabs = new global::EffectList.EffectData[]
					{
						new global::EffectList.EffectData
						{
							m_prefab = prefab
						},
						new global::EffectList.EffectData
						{
							m_prefab = prefab3
						}
					}
				};
				GameObject gameObject = PrefabManager.Instance.CreateClonedPrefab("goblin_woodwall_2m_ribs1", "goblin_woodwall_2m_ribs");
				gameObject.AddComponent<global::Piece>();
				UnityEngine.Object.DestroyImmediate(gameObject.GetComponent<global::DropOnDestroyed>());
				CustomPiece customPiece = new CustomPiece(gameObject, new PieceConfig
				{
					PieceTable = "_HammerPieceTable",
					AllowedInDungeons = false,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "Wood",
							Amount = 15,
							Recover = false
						}
					}
				});
				Jotunn.Logger.LogInfo("resetting vectors");
				gameObject.transform.localPosition = new Vector3(0f, 0f, 0f);
				gameObject.transform.position = new Vector3(0f, 0f, 0f);
				global::Piece piece = customPiece.Piece;
				piece.m_name = "$piece_goblinribwall_name";
				piece.m_description = "$piece_goblinribwall_desc";
				piece.m_canBeRemoved = true;
				piece.m_icon = this.goblinribwall2m;
				piece.m_primaryTarget = false;
				piece.m_randomTarget = true;
				piece.m_category = global::Piece.PieceCategory.Building;
				piece.m_enabled = true;
				piece.m_isUpgrade = false;
				piece.m_comfort = 0;
				piece.m_groundPiece = false;
				piece.m_allowAltGroundPlacement = false;
				piece.m_cultivatedGroundOnly = false;
				piece.m_waterPiece = false;
				piece.m_noInWater = false;
				piece.m_notOnWood = false;
				piece.m_notOnTiltingSurface = false;
				piece.m_noClipping = false;
				piece.m_onlyInTeleportArea = false;
				piece.m_allowedInDungeons = false;
				piece.m_haveCenter = true;
				piece.m_spaceRequirement = 2f;
				piece.m_placeEffect = placeEffect;
				CustomPiece customPiece2 = new CustomPiece(PrefabManager.Instance.CreateClonedPrefab("piece_stonefloor_2x2", "stone_floor"), new PieceConfig
				{
					PieceTable = "_HammerPieceTable",
					AllowedInDungeons = false,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "Stone",
							Amount = 15,
							Recover = false
						}
					}
				});
				GameObject gameObject2 = PrefabManager.Instance.CreateClonedPrefab("goblin_fence1", "goblin_fence");
				UnityEngine.Object.DestroyImmediate(gameObject2.GetComponent<global::DropOnDestroyed>());
				gameObject2.AddComponent<global::Piece>();
				CustomPiece customPiece3 = new CustomPiece(gameObject2, new PieceConfig
				{
					PieceTable = "_HammerPieceTable",
					AllowedInDungeons = false,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "Wood",
							Amount = 15,
							Recover = false
						}
					}
				});
				Jotunn.Logger.LogInfo("resetting vectors");
				gameObject2.transform.localPosition = new Vector3(0f, 0f, 0f);
				gameObject2.transform.position = new Vector3(0f, 0f, 0f);
				global::Piece piece2 = customPiece3.Piece;
				piece2.m_name = "$piece_goblinfence_name";
				piece2.m_description = "$piece_goblinfence_desc";
				piece2.m_canBeRemoved = true;
				piece2.m_icon = this.goblinfence;
				piece2.m_primaryTarget = false;
				piece2.m_randomTarget = true;
				piece2.m_category = global::Piece.PieceCategory.Building;
				piece2.m_enabled = true;
				piece2.m_isUpgrade = false;
				piece2.m_comfort = 0;
				piece2.m_groundPiece = false;
				piece2.m_allowAltGroundPlacement = false;
				piece2.m_cultivatedGroundOnly = false;
				piece2.m_waterPiece = false;
				piece2.m_noInWater = false;
				piece2.m_notOnWood = false;
				piece2.m_notOnTiltingSurface = false;
				piece2.m_noClipping = false;
				piece2.m_onlyInTeleportArea = false;
				piece2.m_allowedInDungeons = false;
				piece2.m_spaceRequirement = 2f;
				piece2.m_placeEffect = placeEffect;
				GameObject gameObject3 = PrefabManager.Instance.CreateClonedPrefab("goblin_roof_45d1", "goblin_roof_45d");
				gameObject3.AddComponent<global::Piece>();
				UnityEngine.Object.DestroyImmediate(gameObject3.GetComponent<global::DropOnDestroyed>());
				CustomPiece customPiece4 = new CustomPiece(gameObject3, new PieceConfig
				{
					PieceTable = "_HammerPieceTable",
					AllowedInDungeons = false,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "Wood",
							Amount = 15,
							Recover = false
						}
					}
				});
				Jotunn.Logger.LogInfo("resetting vectors");
				gameObject3.transform.localPosition = new Vector3(0f, 0f, 0f);
				gameObject3.transform.position = new Vector3(0f, 0f, 0f);
				global::Piece piece3 = customPiece4.Piece;
				piece3.m_name = "$piece_goblinroof45_name";
				piece3.m_description = "$piece_goblinroof45_desc";
				piece3.m_canBeRemoved = true;
				piece3.m_icon = this.roof45;
				piece3.m_primaryTarget = false;
				piece3.m_randomTarget = true;
				piece3.m_category = global::Piece.PieceCategory.Building;
				piece3.m_enabled = true;
				piece3.m_isUpgrade = false;
				piece3.m_comfort = 0;
				piece3.m_groundPiece = false;
				piece3.m_allowAltGroundPlacement = false;
				piece3.m_cultivatedGroundOnly = false;
				piece3.m_waterPiece = false;
				piece3.m_noInWater = false;
				piece3.m_notOnWood = false;
				piece3.m_notOnTiltingSurface = false;
				piece3.m_noClipping = false;
				piece3.m_onlyInTeleportArea = false;
				piece3.m_allowedInDungeons = false;
				piece3.m_spaceRequirement = 2f;
				piece3.m_placeEffect = this.effectList;
				GameObject gameObject4 = PrefabManager.Instance.CreateClonedPrefab("goblin_roof_45d_corner1", "goblin_roof_45d_corner");
				gameObject4.AddComponent<global::Piece>();
				UnityEngine.Object.DestroyImmediate(gameObject4.GetComponent<global::DropOnDestroyed>());
				CustomPiece customPiece5 = new CustomPiece(gameObject4, new PieceConfig
				{
					PieceTable = "_HammerPieceTable",
					AllowedInDungeons = false,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "Wood",
							Amount = 15,
							Recover = false
						}
					}
				});
				Jotunn.Logger.LogInfo("resetting vectors");
				gameObject4.transform.localPosition = new Vector3(0f, 0f, 0f);
				gameObject4.transform.position = new Vector3(0f, 0f, 0f);
				global::Piece piece4 = customPiece5.Piece;
				piece4.m_name = "$piece_goblinroofcorner_name";
				piece4.m_description = "$piece_goblinroofcorner_desc";
				piece4.m_canBeRemoved = true;
				piece4.m_icon = this.roof45corner;
				piece4.m_primaryTarget = false;
				piece4.m_randomTarget = true;
				piece4.m_category = global::Piece.PieceCategory.Building;
				piece4.m_enabled = true;
				piece4.m_isUpgrade = false;
				piece4.m_comfort = 0;
				piece4.m_groundPiece = false;
				piece4.m_allowAltGroundPlacement = false;
				piece4.m_cultivatedGroundOnly = false;
				piece4.m_waterPiece = false;
				piece4.m_noInWater = false;
				piece4.m_notOnWood = false;
				piece4.m_notOnTiltingSurface = false;
				piece4.m_noClipping = false;
				piece4.m_onlyInTeleportArea = false;
				piece4.m_allowedInDungeons = false;
				piece4.m_spaceRequirement = 2f;
				piece4.m_placeEffect = this.effectList;
				GameObject gameObject5 = PrefabManager.Instance.CreateClonedPrefab("goblin_woodwall_2m1", "goblin_woodwall_2m");
				gameObject5.AddComponent<global::Piece>();
				UnityEngine.Object.DestroyImmediate(gameObject5.GetComponent<global::DropOnDestroyed>());
				CustomPiece customPiece6 = new CustomPiece(gameObject5, new PieceConfig
				{
					PieceTable = "_HammerPieceTable",
					AllowedInDungeons = false,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "Wood",
							Amount = 15,
							Recover = false
						}
					}
				});
				Jotunn.Logger.LogInfo("resetting vectors");
				gameObject4.transform.localPosition = new Vector3(0f, 0f, 0f);
				gameObject4.transform.position = new Vector3(0f, 0f, 0f);
				global::Piece piece5 = customPiece6.Piece;
				piece5.m_name = "$piece_goblinwall2m_name";
				piece5.m_description = "$piece_goblinwall2m_desc";
				piece5.m_canBeRemoved = true;
				piece5.m_icon = this.woodwall2m;
				piece5.m_primaryTarget = false;
				piece5.m_randomTarget = true;
				piece5.m_category = global::Piece.PieceCategory.Building;
				piece5.m_enabled = true;
				piece5.m_isUpgrade = false;
				piece5.m_comfort = 0;
				piece5.m_groundPiece = false;
				piece5.m_allowAltGroundPlacement = false;
				piece5.m_cultivatedGroundOnly = false;
				piece5.m_waterPiece = false;
				piece5.m_noInWater = false;
				piece5.m_notOnWood = false;
				piece5.m_notOnTiltingSurface = false;
				piece5.m_noClipping = false;
				piece5.m_onlyInTeleportArea = false;
				piece5.m_allowedInDungeons = false;
				piece5.m_spaceRequirement = 2f;
				piece5.m_placeEffect = this.effectList;
				GameObject gameObject6 = PrefabManager.Instance.CreateClonedPrefab("goblin_woodwall_1m1", "goblin_woodwall_1m");
				gameObject6.AddComponent<global::Piece>();
				UnityEngine.Object.DestroyImmediate(gameObject6.GetComponent<global::DropOnDestroyed>());
				CustomPiece customPiece7 = new CustomPiece(gameObject6, new PieceConfig
				{
					PieceTable = "_HammerPieceTable",
					AllowedInDungeons = false,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "Wood",
							Amount = 15,
							Recover = false
						}
					}
				});
				Jotunn.Logger.LogInfo("resetting vectors");
				gameObject6.transform.localPosition = new Vector3(0f, 0f, 0f);
				gameObject6.transform.position = new Vector3(0f, 0f, 0f);
				global::Piece piece6 = customPiece7.Piece;
				piece6.m_name = "$piece_goblinwall1m_name";
				piece6.m_description = "$piece_goblinwall1m_desc";
				piece6.m_canBeRemoved = true;
				piece6.m_icon = this.woodwall1m;
				piece6.m_primaryTarget = false;
				piece6.m_randomTarget = true;
				piece6.m_category = global::Piece.PieceCategory.Building;
				piece6.m_enabled = true;
				piece6.m_isUpgrade = false;
				piece6.m_comfort = 0;
				piece6.m_groundPiece = false;
				piece6.m_allowAltGroundPlacement = false;
				piece6.m_cultivatedGroundOnly = false;
				piece6.m_waterPiece = false;
				piece6.m_noInWater = false;
				piece6.m_notOnWood = false;
				piece6.m_notOnTiltingSurface = false;
				piece6.m_noClipping = false;
				piece6.m_onlyInTeleportArea = false;
				piece6.m_allowedInDungeons = false;
				piece6.m_spaceRequirement = 2f;
				piece6.m_placeEffect = this.effectList;
				GameObject gameObject7 = PrefabManager.Instance.CreateClonedPrefab("goblin_pole1", "goblin_pole");
				gameObject7.AddComponent<global::Piece>();
				UnityEngine.Object.DestroyImmediate(gameObject7.GetComponent<global::DropOnDestroyed>());
				CustomPiece customPiece8 = new CustomPiece(gameObject7, new PieceConfig
				{
					PieceTable = "_HammerPieceTable",
					AllowedInDungeons = false,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "Wood",
							Amount = 15,
							Recover = false
						}
					}
				});
				Jotunn.Logger.LogInfo("resetting vectors");
				gameObject7.transform.localPosition = new Vector3(0f, 0f, 0f);
				gameObject7.transform.position = new Vector3(0f, 0f, 0f);
				global::Piece piece7 = customPiece8.Piece;
				piece7.m_name = "$piece_goblinspike_name";
				piece7.m_description = "$piece_goblinspike_desc";
				piece7.m_canBeRemoved = true;
				piece7.m_icon = this.goblinspike;
				piece7.m_primaryTarget = false;
				piece7.m_randomTarget = true;
				piece7.m_category = global::Piece.PieceCategory.Building;
				piece7.m_enabled = true;
				piece7.m_isUpgrade = false;
				piece7.m_comfort = 0;
				piece7.m_groundPiece = false;
				piece7.m_allowAltGroundPlacement = false;
				piece7.m_cultivatedGroundOnly = false;
				piece7.m_waterPiece = false;
				piece7.m_noInWater = false;
				piece7.m_notOnWood = false;
				piece7.m_notOnTiltingSurface = false;
				piece7.m_noClipping = false;
				piece7.m_onlyInTeleportArea = false;
				piece7.m_allowedInDungeons = false;
				piece7.m_spaceRequirement = 2f;
				piece7.m_placeEffect = this.effectList;
				GameObject gameObject8 = PrefabManager.Instance.CreateClonedPrefab("goblin_banner1", "goblin_banner");
				gameObject8.AddComponent<global::Piece>();
				UnityEngine.Object.DestroyImmediate(gameObject8.GetComponent<global::DropOnDestroyed>());
				CustomPiece customPiece9 = new CustomPiece(gameObject8, new PieceConfig
				{
					PieceTable = "_HammerPieceTable",
					AllowedInDungeons = false,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "Wood",
							Amount = 15,
							Recover = false
						}
					}
				});
				Jotunn.Logger.LogInfo("resetting vectors");
				gameObject8.transform.localPosition = new Vector3(0f, 0f, 0f);
				gameObject8.transform.position = new Vector3(0f, 0f, 0f);
				global::Piece piece8 = customPiece9.Piece;
				piece8.m_name = "$piece_goblinbanner_name";
				piece8.m_description = "$piece_goblinbanner_desc";
				piece8.m_canBeRemoved = true;
				piece8.m_icon = this.goblinbanner1;
				piece8.m_primaryTarget = false;
				piece8.m_randomTarget = true;
				piece8.m_category = global::Piece.PieceCategory.Building;
				piece8.m_enabled = true;
				piece8.m_isUpgrade = false;
				piece8.m_comfort = 0;
				piece8.m_groundPiece = false;
				piece8.m_allowAltGroundPlacement = false;
				piece8.m_cultivatedGroundOnly = false;
				piece8.m_waterPiece = false;
				piece8.m_noInWater = false;
				piece8.m_notOnWood = false;
				piece8.m_notOnTiltingSurface = false;
				piece8.m_noClipping = false;
				piece8.m_onlyInTeleportArea = false;
				piece8.m_allowedInDungeons = false;
				piece8.m_spaceRequirement = 2f;
				piece8.m_placeEffect = placeEffect;
				GameObject gameObject9 = PrefabManager.Instance.CreateClonedPrefab("dungeon_sunkencrypt_irongate1", "dungeon_sunkencrypt_irongate");
				gameObject9.AddComponent<global::Piece>();
				CustomPiece customPiece10 = new CustomPiece(gameObject9, new PieceConfig
				{
					PieceTable = "_HammerPieceTable",
					AllowedInDungeons = false,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "Iron",
							Amount = 5,
							Recover = false
						}
					}
				});
				Jotunn.Logger.LogInfo("resetting vectors");
				gameObject9.transform.localPosition = new Vector3(0f, 0f, 0f);
				gameObject9.transform.position = new Vector3(0f, 0f, 0f);
				global::Piece piece9 = customPiece10.Piece;
				piece9.m_name = "$piece_dungeongate_name";
				piece9.m_description = "$piece_dungeongate_desc";
				piece9.m_canBeRemoved = true;
				piece9.m_icon = this.dungeongate1;
				piece9.m_primaryTarget = false;
				piece9.m_randomTarget = true;
				piece9.m_category = global::Piece.PieceCategory.Building;
				piece9.m_enabled = true;
				piece9.m_isUpgrade = false;
				piece9.m_comfort = 0;
				piece9.m_groundPiece = false;
				piece9.m_allowAltGroundPlacement = false;
				piece9.m_cultivatedGroundOnly = false;
				piece9.m_waterPiece = false;
				piece9.m_noInWater = false;
				piece9.m_notOnWood = false;
				piece9.m_notOnTiltingSurface = false;
				piece9.m_noClipping = false;
				piece9.m_onlyInTeleportArea = false;
				piece9.m_allowedInDungeons = false;
				piece9.m_spaceRequirement = 0f;
				piece9.m_placeEffect = this.effectList;
				GameObject gameObject10 = PrefabManager.Instance.CreateClonedPrefab("goblin_roof_cap1", "goblin_roof_cap");
				gameObject10.AddComponent<global::Piece>();
				UnityEngine.Object.DestroyImmediate(gameObject10.GetComponent<global::DropOnDestroyed>());
				CustomPiece customPiece11 = new CustomPiece(gameObject10, new PieceConfig
				{
					PieceTable = "_HammerPieceTable",
					AllowedInDungeons = false,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "Iron",
							Amount = 5,
							Recover = false
						}
					}
				});
				Jotunn.Logger.LogInfo("resetting vectors");
				Vector3 vector = new Vector3(0f, 0f, 0f);
				gameObject10.transform.localPosition = vector;
				gameObject10.transform.position = vector;
				customPiece11.Piece.m_name = "$piece_goblinroofcap_name";
				customPiece11.Piece.m_description = "$piece_goblinroofcap_desc";
				customPiece11.Piece.m_canBeRemoved = true;
				customPiece11.Piece.m_icon = this.capsprite;
				customPiece11.Piece.m_primaryTarget = false;
				customPiece11.Piece.m_randomTarget = false;
				customPiece11.Piece.m_category = global::Piece.PieceCategory.Building;
				customPiece11.Piece.m_enabled = true;
				customPiece11.Piece.m_clipEverything = true;
				customPiece11.Piece.m_isUpgrade = false;
				customPiece11.Piece.m_comfort = 0;
				customPiece11.Piece.m_groundPiece = false;
				customPiece11.Piece.m_allowAltGroundPlacement = false;
				customPiece11.Piece.m_cultivatedGroundOnly = false;
				customPiece11.Piece.m_waterPiece = false;
				customPiece11.Piece.m_noInWater = false;
				customPiece11.Piece.m_notOnWood = false;
				customPiece11.Piece.m_notOnTiltingSurface = false;
				customPiece11.Piece.m_noClipping = false;
				customPiece11.Piece.m_onlyInTeleportArea = false;
				customPiece11.Piece.m_allowedInDungeons = false;
				customPiece11.Piece.m_spaceRequirement = 0f;
				customPiece11.Piece.m_placeEffect = this.effectList;
				GameObject gameObject11 = PrefabManager.Instance.CreateClonedPrefab("Boxthing", "barrell");
				gameObject11.AddComponent<global::Piece>();
				gameObject11.AddComponent<global::ZSyncTransform>();
				gameObject11.AddComponent<global::ZNetView>().m_persistent = true;
				gameObject11.transform.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
				gameObject11.transform.gameObject.transform.position = new Vector3(0f, 5f, 0f);
				gameObject11.transform.gameObject.transform.localPosition = new Vector3(0f, 5f, 0f);
				MeshCollider meshCollider = gameObject11.transform.gameObject.AddComponent<MeshCollider>();
				meshCollider.convex = false;
				Jotunn.Logger.LogWarning(string.Format("Did I find it?{0}", meshCollider));
				global::Container container = gameObject11.AddComponent<global::Container>();
				container.m_width = this.BarrelWidth.Value;
				container.m_height = this.BarrelHeight.Value;
				container.m_name = "Barrell";
				container.m_checkGuardStone = true;
				UnityEngine.Object.DestroyImmediate(gameObject11.GetComponent<global::DropOnDestroyed>());
				CustomPiece customPiece12 = new CustomPiece(gameObject11, new PieceConfig
				{
					PieceTable = "_HammerPieceTable",
					AllowedInDungeons = false,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "Iron",
							Amount = 5,
							Recover = true
						},
						new RequirementConfig
						{
							Item = "Wood",
							Amount = 10,
							Recover = true
						}
					}
				});
				gameObject11.AddComponent<global::WearNTear>().m_health = 1000f;
				customPiece12.Piece.m_name = "$piece_barrel_name";
				customPiece12.Piece.m_description = "$piece_barrel_desc";
				customPiece12.Piece.m_canBeRemoved = true;
				customPiece12.Piece.m_icon = this.barrelsprite;
				customPiece12.Piece.m_primaryTarget = false;
				customPiece12.Piece.m_randomTarget = false;
				customPiece12.Piece.m_category = global::Piece.PieceCategory.Building;
				customPiece12.Piece.m_enabled = true;
				customPiece12.Piece.m_clipEverything = true;
				customPiece12.Piece.m_isUpgrade = false;
				customPiece12.Piece.m_comfort = 0;
				customPiece12.Piece.m_groundPiece = false;
				customPiece12.Piece.m_allowAltGroundPlacement = false;
				customPiece12.Piece.m_cultivatedGroundOnly = false;
				customPiece12.Piece.m_waterPiece = false;
				customPiece12.Piece.m_noInWater = false;
				customPiece12.Piece.m_notOnWood = false;
				customPiece12.Piece.m_notOnTiltingSurface = false;
				customPiece12.Piece.m_noClipping = false;
				customPiece12.Piece.m_onlyInTeleportArea = false;
				customPiece12.Piece.m_allowedInDungeons = false;
				customPiece12.Piece.m_spaceRequirement = 0f;
				customPiece12.Piece.m_placeEffect = this.effectList;
				GameObject gameObject12 = PrefabManager.Instance.CreateClonedPrefab("CastleBox", "CastleKit_braided_box01");
				gameObject12.AddComponent<global::Piece>();
				gameObject12.GetComponent<global::ZNetView>().m_persistent = true;
				global::Container container2 = gameObject12.AddComponent<global::Container>();
				container2.m_width = 4;
				container2.m_height = 4;
				container2.m_name = "Small Crate";
				container2.m_checkGuardStone = true;
				UnityEngine.Object.DestroyImmediate(gameObject12.GetComponent<global::Destructible>());
				CustomPiece customPiece13 = new CustomPiece(gameObject12, new PieceConfig
				{
					PieceTable = "_HammerPieceTable",
					AllowedInDungeons = false,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "Iron",
							Amount = 5,
							Recover = true
						},
						new RequirementConfig
						{
							Item = "Wood",
							Amount = 10,
							Recover = true
						}
					}
				});
				gameObject12.AddComponent<global::WearNTear>().m_health = 1000f;
				customPiece13.Piece.m_name = "$piece_smallcrate_name";
				customPiece13.Piece.m_description = "$piece_smallcrate_desc";
				customPiece13.Piece.m_canBeRemoved = true;
				customPiece13.Piece.m_icon = this.barrelsprite;
				customPiece13.Piece.m_primaryTarget = false;
				customPiece13.Piece.m_randomTarget = false;
				customPiece13.Piece.m_category = global::Piece.PieceCategory.Building;
				customPiece13.Piece.m_enabled = true;
				customPiece13.Piece.m_clipEverything = true;
				customPiece13.Piece.m_isUpgrade = false;
				customPiece13.Piece.m_comfort = 0;
				customPiece13.Piece.m_groundPiece = false;
				customPiece13.Piece.m_allowAltGroundPlacement = false;
				customPiece13.Piece.m_cultivatedGroundOnly = false;
				customPiece13.Piece.m_waterPiece = false;
				customPiece13.Piece.m_noInWater = false;
				customPiece13.Piece.m_notOnWood = false;
				customPiece13.Piece.m_notOnTiltingSurface = false;
				customPiece13.Piece.m_noClipping = false;
				customPiece13.Piece.m_onlyInTeleportArea = false;
				customPiece13.Piece.m_allowedInDungeons = false;
				customPiece13.Piece.m_spaceRequirement = 0f;
				customPiece13.Piece.m_placeEffect = this.effectList;
				MoarBuilds.Portal = PrefabManager.Instance.CreateClonedPrefab("Stone_Portal", "portal");
				global::TeleportWorld component = MoarBuilds.Portal.GetComponent<global::TeleportWorld>();
				if (!component.m_proximityRoot)
				{
					component.m_proximityRoot = component.transform;
				}
				if (component.m_target_found == null)
				{
					GameObject gameObject13 = component.gameObject.transform.Find("_target_found").gameObject;
					gameObject13.SetActive(false);
					component.m_target_found = gameObject13.AddComponent<global::EffectFade>();
					gameObject13.SetActive(true);
				}
				CustomPiece customPiece14 = new CustomPiece(MoarBuilds.Portal, new PieceConfig
				{
					PieceTable = "_HammerPieceTable",
					AllowedInDungeons = false,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "Stone",
							Amount = 5,
							Recover = true
						},
						new RequirementConfig
						{
							Item = "SurtlingCore",
							Amount = 10,
							Recover = true
						},
						new RequirementConfig
						{
							Item = "GreydwarfEye",
							Amount = 20,
							Recover = false
						},
						new RequirementConfig
						{
							Item = "Thistle",
							Amount = 10,
							Recover = true
						}
					}
				});
				CustomItem customItem = new CustomItem(PrefabManager.Instance.CreateClonedPrefab("GoblinBrute_RageAttack1", "GoblinBrute_Attack"), true, new ItemConfig
				{
					Amount = 1,
					Enabled = this.GoblinStick.Value,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "Wood",
							Amount = 15,
							AmountPerLevel = 1
						},
						new RequirementConfig
						{
							Item = "Stone",
							Amount = 10,
							AmountPerLevel = 20
						},
						new RequirementConfig
						{
							Item = "LeatherScraps",
							Amount = 10,
							AmountPerLevel = 10
						}
					}
				});
				global::ItemDrop itemDrop = customItem.ItemDrop;
				itemDrop.m_itemData.m_shared.m_icons = new Sprite[]
				{
					this.goblinsmacker1
				};
				itemDrop.m_itemData.m_shared.m_name = "$piece_goblinsmacker_name";
				itemDrop.m_itemData.m_shared.m_description = "$piece_goblinsmacker_desc";
				itemDrop.m_itemData.m_shared.m_itemType = global::ItemDrop.ItemData.ItemType.OneHandedWeapon;
				itemDrop.m_itemData.m_shared.m_animationState = global::ItemDrop.ItemData.AnimationState.OneHanded;
				itemDrop.m_itemData.m_shared.m_attack.m_attackType = global::Attack.AttackType.Horizontal;
				itemDrop.m_itemData.m_shared.m_attack.m_attackAnimation = "swing_longsword";
				itemDrop.m_itemData.m_shared.m_attack.m_currentAttackCainLevel = 2;
				itemDrop.m_itemData.m_shared.m_attack.m_attackRange = 5f;
				itemDrop.m_itemData.m_shared.m_attack.m_attackAngle = 70f;
				itemDrop.m_itemData.m_shared.m_attack.m_attackRayWidth = 0.8f;
				itemDrop.m_itemData.m_shared.m_attack.m_attackHeight = 1.5f;
				itemDrop.m_itemData.m_shared.m_attack.m_forceMultiplier = 3f;
				itemDrop.m_itemData.m_shared.m_attack.m_resetChainIfHit = DestructibleType.Tree;
				itemDrop.m_itemData.m_shared.m_attack.m_lastChainDamageMultiplier = 2f;
				itemDrop.m_itemData.m_shared.m_attack.m_hitTerrain = true;
				itemDrop.m_itemData.m_shared.m_secondaryAttack.m_attackType = global::Attack.AttackType.Horizontal;
				itemDrop.m_itemData.m_shared.m_secondaryAttack.m_attackAnimation = "battleaxe_secondary";
				itemDrop.m_itemData.m_shared.m_maxQuality = 4;
				ItemManager.Instance.AddItem(customItem);
				PieceManager.Instance.AddPiece(customPiece);
				PieceManager.Instance.AddPiece(customPiece2);
				PieceManager.Instance.AddPiece(customPiece3);
				PieceManager.Instance.AddPiece(customPiece4);
				PieceManager.Instance.AddPiece(customPiece5);
				PieceManager.Instance.AddPiece(customPiece6);
				PieceManager.Instance.AddPiece(customPiece7);
				PieceManager.Instance.AddPiece(customPiece8);
				PieceManager.Instance.AddPiece(customPiece10);
				PieceManager.Instance.AddPiece(customPiece9);
				PieceManager.Instance.AddPiece(customPiece11);
				PieceManager.Instance.AddPiece(customPiece12);
				PieceManager.Instance.AddPiece(customPiece14);
				this.LoadAssets();
			}
			catch (Exception arg)
			{
				Jotunn.Logger.LogError(string.Format("Error while adding cloned item: {0}", arg));
			}
			finally
			{
				ItemManager.OnVanillaItemsAvailable -= this.GrabPieces;
			}
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00005180 File Offset: 0x00003380
		private IEnumerator GameConnectPortalsPrefix(On.Game.orig_ConnectPortals orig, global::Game self)
		{
			global::ZDOMan zdoMan = global::ZDOMan.instance;
			for (;;)
			{
				DateTimeOffset.Now.ToUnixTimeSeconds();
				long logIntervalSeconds = this._logIntervalSeconds;
				self.m_tempPortalList.Clear();
				int index = 0;
				HashSet<int> prefabHashcodes = new HashSet<int>
				{
					self.m_portalPrefab.name.GetStableHashCode(),
					this._portalPrefabName.Value.GetStableHashCode()
				};
				bool getPrefabsComplete;
				do
				{
					getPrefabsComplete = MoarBuilds.GetAllZdosMatchingPrefabHashcodes(zdoMan, prefabHashcodes, self.m_tempPortalList, ref index);
					yield return null;
				}
				while (!getPrefabsComplete);
				foreach (global::ZDO zdo in self.m_tempPortalList)
				{
					global::ZDOID zdoid = zdo.GetZDOID("target");
					if (!zdoid.IsNone())
					{
						string @string = zdo.GetString("tag", string.Empty);
						global::ZDO zdo2 = zdoMan.GetZDO(zdoid);
						if (@string == string.Empty || zdo2 == null || (zdo2.GetString("tag", string.Empty) != @string && !@string.StartsWith(this._onewayPortalTagPrefix.Value)))
						{
							zdo.SetOwner(zdoMan.GetMyID());
							zdo.Set("target", global::ZDOID.None);
							zdoMan.ForceSendZDO(zdo.m_uid);
						}
					}
				}
				foreach (global::ZDO zdo3 in self.m_tempPortalList)
				{
					string string2 = zdo3.GetString("tag", string.Empty);
					if (!(string2 == string.Empty) && zdo3.GetZDOID("target").IsNone())
					{
						bool flag = string2.StartsWith(this._onewayPortalTagPrefix.Value);
						global::ZDO zdo4 = self.FindRandomUnconnectedPortal(self.m_tempPortalList, zdo3, flag ? string2.Remove(0, this._onewayPortalTagPrefix.Value.Length) : string2);
						if (zdo4 != null)
						{
							zdo3.SetOwner(zdoMan.GetMyID());
							zdo3.Set("target", zdo4.m_uid);
							zdo4.SetOwner(zdoMan.GetMyID());
							zdo4.Set("target", flag ? global::ZDOID.None : zdo3.m_uid);
							zdoMan.ForceSendZDO(zdo3.m_uid);
							zdoMan.ForceSendZDO(zdo4.m_uid);
						}
					}
				}
				yield return new WaitForSeconds(this._connectPortalCoroutineWait.Value);
				prefabHashcodes = null;
			}
			yield break;
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00005196 File Offset: 0x00003396
		public MoarBuilds()
		{
		}

		// Token: 0x04000001 RID: 1
		public const string PluginGUID = "com.zarboz.moarbuilds";

		// Token: 0x04000002 RID: 2
		public const string PluginName = "MoArBuIlDs";

		// Token: 0x04000003 RID: 3
		public const string PluginVersion = "1.0.8";

		// Token: 0x04000004 RID: 4
		private Sprite goblinfence;

		// Token: 0x04000005 RID: 5
		private Sprite goblinspike;

		// Token: 0x04000006 RID: 6
		private Sprite goblinribwall2m;

		// Token: 0x04000007 RID: 7
		private Sprite roof45;

		// Token: 0x04000008 RID: 8
		private Sprite roof45corner;

		// Token: 0x04000009 RID: 9
		private Sprite woodwall1m;

		// Token: 0x0400000A RID: 10
		private Sprite woodwall2m;

		// Token: 0x0400000B RID: 11
		private Sprite dungeongate1;

		// Token: 0x0400000C RID: 12
		private Sprite goblinbanner1;

		// Token: 0x0400000D RID: 13
		private Sprite goblinsmacker1;

		// Token: 0x0400000E RID: 14
		private AssetBundle spritebundle1;

		// Token: 0x0400000F RID: 15
		private Sprite capsprite;

		// Token: 0x04000010 RID: 16
		private Sprite barrelsprite;

		// Token: 0x04000011 RID: 17
		private Sprite basketsprite;

		// Token: 0x04000012 RID: 18
		private Sprite barrelaltsprite;

		// Token: 0x04000013 RID: 19
		private Sprite boxsprite;

		// Token: 0x04000014 RID: 20
		private Sprite chestsprite;

		// Token: 0x04000015 RID: 21
		private AssetBundle assetBundle;

		// Token: 0x04000016 RID: 22
		private ConfigEntry<bool> GoblinStick;

		// Token: 0x04000017 RID: 23
		private ConfigEntry<int> BarrelWidth;

		// Token: 0x04000018 RID: 24
		private ConfigEntry<int> chestheight;

		// Token: 0x04000019 RID: 25
		private ConfigEntry<int> chestwidth;

		// Token: 0x0400001A RID: 26
		private ConfigEntry<int> basketheight;

		// Token: 0x0400001B RID: 27
		private ConfigEntry<int> basketwidth;

		// Token: 0x0400001C RID: 28
		private ConfigEntry<int> altbarrelheight;

		// Token: 0x0400001D RID: 29
		private ConfigEntry<int> altbarrelwidth;

		// Token: 0x0400001E RID: 30
		private ConfigEntry<string> CrateCraftingMat;

		// Token: 0x0400001F RID: 31
		private ConfigEntry<string> CrateCraftingMat2;

		// Token: 0x04000020 RID: 32
		private ConfigEntry<int> BarrelHeight;

		// Token: 0x04000021 RID: 33
		private global::EffectList effectList;

		// Token: 0x04000022 RID: 34
		private AssetBundle clutterassets;

		// Token: 0x04000023 RID: 35
		private global::Container roundchest;

		// Token: 0x04000024 RID: 36
		private global::Container cratechest;

		// Token: 0x04000025 RID: 37
		private global::Container basketchest;

		// Token: 0x04000026 RID: 38
		private global::Container ctn;

		// Token: 0x04000027 RID: 39
		private global::Container barrell3chest;

		// Token: 0x04000028 RID: 40
		private object _getMatchingZdosBreakCount;

		// Token: 0x04000029 RID: 41
		private ConfigEntry<bool> _isModEnabled;

		// Token: 0x0400002A RID: 42
		private static GameObject Portal;

		// Token: 0x0400002B RID: 43
		private ConfigEntry<float> _connectPortalCoroutineWait;

		// Token: 0x0400002C RID: 44
		private ConfigEntry<string> _portalPrefabName;

		// Token: 0x0400002D RID: 45
		private ConfigEntry<string> _onewayPortalTagPrefix;

		// Token: 0x0400002E RID: 46
		private long _logIntervalSeconds;

		// Token: 0x02000003 RID: 3
		[HarmonyPatch(typeof(global::TeleportWorld), "Interact")]
		private class Interact_Patch
		{
			// Token: 0x0600000C RID: 12 RVA: 0x000051C4 File Offset: 0x000033C4
			private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
			{
				List<CodeInstruction> list = new List<CodeInstruction>(instructions);
				for (int i = 0; i < list.Count; i++)
				{
					if (list[i].opcode == OpCodes.Ldc_I4_S)
					{
						list[i].operand = 127;
					}
				}
				return Enumerable.AsEnumerable<CodeInstruction>(list);
			}

			// Token: 0x0600000D RID: 13 RVA: 0x0000521A File Offset: 0x0000341A
			public Interact_Patch()
			{
			}
		}
	}
}
