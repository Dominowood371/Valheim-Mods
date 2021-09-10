using System;
using BepInEx;
using Jotunn;
using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;
using Jotunn.Utils;
using UnityEngine;

namespace ValEx
{
	// Token: 0x02000002 RID: 2
	[BepInPlugin("MrRageous.ValEx", "ValheimExpanded: Core Module", "0.4.1")]
	[BepInDependency("com.jotunn.jotunn", BepInDependency.DependencyFlags.HardDependency)]
	[NetworkCompatibility(CompatibilityLevel.OnlySyncWhenInstalled, VersionStrictness.Minor)]
	public class Setup : BaseUnityPlugin
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		private void Awake()
		{
			this.LoadAssets();
			this.AddCustomConversions();
			this.CreateGlass();
			this.CreateEssences();
			this.CreateIngots();
			this.CreateCoins();
			this.CreateTools();
			this.CreateCraftingPieces();
			this.CreateIronPieces();
			this.CreateGlassPieces();
			this.CreateStoragePieces();
			this.AddWorkbenchRecipes();
			this.AddForgeRecipes();
			this.AddFoodCraftRecipes();
			this.AddCampfireRecipes();
		}

		// Token: 0x06000002 RID: 2 RVA: 0x000020C8 File Offset: 0x000002C8
		private void LoadAssets()
		{
			Logger.LogInfo("Embedded resources: " + string.Join(",", typeof(Setup).Assembly.GetManifestResourceNames()));
			this.assetBundle = AssetUtils.LoadAssetBundleFromResources("zdata", typeof(Setup).Assembly);
			Logger.LogInfo(this.assetBundle);
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002130 File Offset: 0x00000330
		private void AddCustomConversions()
		{
			CustomItemConversion itemConversion = new CustomItemConversion(new SmelterConversionConfig
			{
				Station = "smelter",
				FromItem = "Sand",
				ToItem = "GlassSlag"
			});
			ItemManager.Instance.AddItemConversion(itemConversion);
			CustomItemConversion itemConversion2 = new CustomItemConversion(new SmelterConversionConfig
			{
				Station = "smelter",
				FromItem = "Iron",
				ToItem = "HeatedIronBar"
			});
			ItemManager.Instance.AddItemConversion(itemConversion2);
		}

		// Token: 0x06000004 RID: 4 RVA: 0x000021B4 File Offset: 0x000003B4
		private void CreateBolts()
		{
			GameObject gameObject = this.assetBundle.LoadAsset<GameObject>("torch");
			ItemDrop component = gameObject.GetComponent<ItemDrop>();
			component.m_itemData.m_dropPrefab = gameObject;
			component.m_itemData.m_shared.m_name = "Adventurer's Torch";
			component.m_itemData.m_shared.m_description = "A torch for adventuring";
			component.m_itemData.m_shared.m_maxDurability = 0f;
			component.m_itemData.m_shared.m_durabilityPerLevel = 0f;
			component.m_itemData.m_shared.m_canBeReparied = true;
			component.m_itemData.m_shared.m_destroyBroken = false;
			component.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component.m_itemData.m_shared.m_damagesPerLevel.m_slash = component.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component.m_itemData.m_shared.m_deflectionForcePerLevel = component.m_itemData.m_shared.m_deflectionForce / 8f;
			component.m_itemData.m_shared.m_teleportable = true;
			component.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem = new CustomItem(gameObject, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "piece_workbench",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Wood",
						Amount = 5
					},
					new RequirementConfig
					{
						Item = "Resin",
						Amount = 10
					}
				}
			});
			ItemManager.Instance.AddItem(customItem);
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000023AC File Offset: 0x000005AC
		private void CreateGlass()
		{
			GameObject gameObject = this.assetBundle.LoadAsset<GameObject>("Sand");
			ItemDrop component = gameObject.GetComponent<ItemDrop>();
			component.m_itemData.m_dropPrefab = gameObject;
			component.m_itemData.m_shared.m_name = "Sand";
			component.m_itemData.m_shared.m_description = "A pile of unusable silicates";
			CustomItem customItem = new CustomItem(gameObject, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "piece_stonecutter",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Stone",
						Amount = 2
					}
				}
			});
			ItemManager.Instance.AddItem(customItem);
			GameObject gameObject2 = this.assetBundle.LoadAsset<GameObject>("GlassSlag");
			ItemDrop component2 = gameObject2.GetComponent<ItemDrop>();
			component2.m_itemData.m_dropPrefab = gameObject2;
			component2.m_itemData.m_shared.m_name = "Glass Slag";
			component2.m_itemData.m_shared.m_description = "A hunk of transparent glass";
			CustomItem customItem2 = new CustomItem(gameObject2, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "piece_glasscutter",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Sand",
						Amount = 2
					},
					new RequirementConfig
					{
						Item = "Resin",
						Amount = 4
					}
				}
			});
			ItemManager.Instance.AddItem(customItem2);
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002534 File Offset: 0x00000734
		private void CreateEssences()
		{
			GameObject gameObject = this.assetBundle.LoadAsset<GameObject>("FrometalEssence");
			ItemDrop component = gameObject.GetComponent<ItemDrop>();
			component.m_itemData.m_dropPrefab = gameObject;
			component.m_itemData.m_shared.m_name = "Frometal Essence";
			component.m_itemData.m_shared.m_description = "A chilly Essence for alchemizing Frometal";
			CustomItem customItem = new CustomItem(gameObject, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "piece_alchemystation",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "FreezeGland",
						Amount = 3
					},
					new RequirementConfig
					{
						Item = "DragonTear",
						Amount = 1
					},
					new RequirementConfig
					{
						Item = "Resin",
						Amount = 8
					},
					new RequirementConfig
					{
						Item = "Crystal",
						Amount = 2
					}
				}
			});
			ItemManager.Instance.AddItem(customItem);
			GameObject gameObject2 = this.assetBundle.LoadAsset<GameObject>("FlametalEssence");
			ItemDrop component2 = gameObject2.GetComponent<ItemDrop>();
			component2.m_itemData.m_dropPrefab = gameObject2;
			component2.m_itemData.m_shared.m_name = "Flametal Essence";
			component2.m_itemData.m_shared.m_description = "A fiery Essence for alchemizing Flametal";
			CustomItem customItem2 = new CustomItem(gameObject2, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "piece_alchemystation",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Coal",
						Amount = 8
					},
					new RequirementConfig
					{
						Item = "TrophyGoblinKing",
						Amount = 1
					},
					new RequirementConfig
					{
						Item = "Resin",
						Amount = 8
					},
					new RequirementConfig
					{
						Item = "SurtlingCore",
						Amount = 4
					}
				}
			});
			ItemManager.Instance.AddItem(customItem2);
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002748 File Offset: 0x00000948
		private void CreateIngots()
		{
			GameObject gameObject = this.assetBundle.LoadAsset<GameObject>("GlassBar");
			ItemDrop component = gameObject.GetComponent<ItemDrop>();
			component.m_itemData.m_dropPrefab = gameObject;
			component.m_itemData.m_shared.m_name = "Glass";
			component.m_itemData.m_shared.m_description = "An ingot made of Glass";
			CustomItem customItem = new CustomItem(gameObject, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "forge",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "GlassSlag",
						Amount = 2
					},
					new RequirementConfig
					{
						Item = "Resin",
						Amount = 4
					}
				}
			});
			ItemManager.Instance.AddItem(customItem);
			GameObject gameObject2 = this.assetBundle.LoadAsset<GameObject>("HeatedIronBar");
			ItemDrop component2 = gameObject2.GetComponent<ItemDrop>();
			component2.m_itemData.m_dropPrefab = gameObject2;
			component2.m_itemData.m_shared.m_name = "Heated Iron";
			component2.m_itemData.m_shared.m_description = "A very hot ingot of Iron";
			CustomItem customItem2 = new CustomItem(gameObject2, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "forge",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Iron",
						Amount = 2
					},
					new RequirementConfig
					{
						Item = "Coal",
						Amount = 4
					}
				}
			});
			ItemManager.Instance.AddItem(customItem2);
			GameObject gameObject3 = this.assetBundle.LoadAsset<GameObject>("HeavymetalBar");
			ItemDrop component3 = gameObject3.GetComponent<ItemDrop>();
			component3.m_itemData.m_dropPrefab = gameObject3;
			component3.m_itemData.m_shared.m_name = "Heavymetal";
			component3.m_itemData.m_shared.m_description = "An ingot made of Heavymetal";
			CustomItem customItem3 = new CustomItem(gameObject3, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "forge",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "HeatedIronBar",
						Amount = 2
					},
					new RequirementConfig
					{
						Item = "BlackMetalScrap",
						Amount = 1
					},
					new RequirementConfig
					{
						Item = "Coal",
						Amount = 4
					}
				}
			});
			ItemManager.Instance.AddItem(customItem3);
			GameObject gameObject4 = this.assetBundle.LoadAsset<GameObject>("Heavyscale");
			ItemDrop component4 = gameObject4.GetComponent<ItemDrop>();
			component4.m_itemData.m_dropPrefab = gameObject4;
			component4.m_itemData.m_shared.m_name = "Heavyscale";
			component4.m_itemData.m_shared.m_description = "A scale, which is quite heavy";
			CustomItem customItem4 = new CustomItem(gameObject4, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "forge",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "SerpentScale",
						Amount = 1
					},
					new RequirementConfig
					{
						Item = "HeavymetalBar",
						Amount = 1
					},
					new RequirementConfig
					{
						Item = "Coal",
						Amount = 2
					},
					new RequirementConfig
					{
						Item = "HeatedIronBar",
						Amount = 1
					}
				}
			});
			ItemManager.Instance.AddItem(customItem4);
			GameObject gameObject5 = this.assetBundle.LoadAsset<GameObject>("FrometalBar");
			ItemDrop component5 = gameObject5.GetComponent<ItemDrop>();
			component5.m_itemData.m_dropPrefab = gameObject5;
			component5.m_itemData.m_shared.m_name = "Frometal";
			component5.m_itemData.m_shared.m_description = "An ingot made of Frometal";
			CustomItem customItem5 = new CustomItem(gameObject5, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "forge",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "HeatedIronBar",
						Amount = 2
					},
					new RequirementConfig
					{
						Item = "FrometalEssence",
						Amount = 1
					}
				}
			});
			ItemManager.Instance.AddItem(customItem5);
			GameObject gameObject6 = this.assetBundle.LoadAsset<GameObject>("Drakescale");
			ItemDrop component6 = gameObject6.GetComponent<ItemDrop>();
			component6.m_itemData.m_dropPrefab = gameObject6;
			component6.m_itemData.m_shared.m_name = "Drakescale";
			component6.m_itemData.m_shared.m_description = "A frosty scale, cold to the touch";
			CustomItem customItem6 = new CustomItem(gameObject6, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "piece_alchemystation",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Heavyscale",
						Amount = 2
					},
					new RequirementConfig
					{
						Item = "FrometalEssence",
						Amount = 1
					}
				}
			});
			ItemManager.Instance.AddItem(customItem6);
			GameObject gameObject7 = this.assetBundle.LoadAsset<GameObject>("FlametalBar");
			ItemDrop component7 = gameObject7.GetComponent<ItemDrop>();
			component7.m_itemData.m_dropPrefab = gameObject7;
			component7.m_itemData.m_shared.m_name = "Flametal";
			component7.m_itemData.m_shared.m_description = "An ingot made of Flametal";
			CustomItem customItem7 = new CustomItem(gameObject7, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "piece_alchemystation",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "SerpentScale",
						Amount = 1
					},
					new RequirementConfig
					{
						Item = "HeavymetalBar",
						Amount = 1
					},
					new RequirementConfig
					{
						Item = "FrometalBar",
						Amount = 1
					},
					new RequirementConfig
					{
						Item = "FlametalEssence",
						Amount = 2
					}
				}
			});
			ItemManager.Instance.AddItem(customItem7);
			GameObject gameObject8 = this.assetBundle.LoadAsset<GameObject>("Forgedscale");
			ItemDrop component8 = gameObject8.GetComponent<ItemDrop>();
			component8.m_itemData.m_dropPrefab = gameObject8;
			component8.m_itemData.m_shared.m_name = "Forgedscale";
			component8.m_itemData.m_shared.m_description = "A scale, forged by a master";
			CustomItem customItem8 = new CustomItem(gameObject8, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "piece_alchemystation",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Heavyscale",
						Amount = 2
					},
					new RequirementConfig
					{
						Item = "FlametalEssence",
						Amount = 1
					}
				}
			});
			ItemManager.Instance.AddItem(customItem8);
			GameObject gameObject9 = this.assetBundle.LoadAsset<GameObject>("MistmetalBar");
			ItemDrop component9 = gameObject9.GetComponent<ItemDrop>();
			component9.m_itemData.m_dropPrefab = gameObject9;
			component9.m_itemData.m_shared.m_name = "Mistmetal";
			component9.m_itemData.m_shared.m_description = "An ingot made of Mist?";
			CustomItem customItem9 = new CustomItem(gameObject9, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "piece_alchemystation",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "YagluthDrop",
						Amount = 99
					}
				}
			});
			ItemManager.Instance.AddItem(customItem9);
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002F14 File Offset: 0x00001114
		private void CreateCoins()
		{
			GameObject gameObject = this.assetBundle.LoadAsset<GameObject>("CoinsBone");
			ItemDrop component = gameObject.GetComponent<ItemDrop>();
			component.m_itemData.m_dropPrefab = gameObject;
			component.m_itemData.m_shared.m_name = "Bone Coins";
			component.m_itemData.m_shared.m_description = "Coins made of Bone, for trading";
			component.m_itemData.m_shared.m_value = 0;
			CustomItem customItem = new CustomItem(gameObject, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "piece_workbench",
				MinStationLevel = 2,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "BoneFragments",
						Amount = 5
					}
				}
			});
			ItemManager.Instance.AddItem(customItem);
			GameObject gameObject2 = this.assetBundle.LoadAsset<GameObject>("CoinsTin");
			ItemDrop component2 = gameObject2.GetComponent<ItemDrop>();
			component2.m_itemData.m_dropPrefab = gameObject2;
			component2.m_itemData.m_shared.m_name = "Tin Coins";
			component2.m_itemData.m_shared.m_description = "Coins made of Tin, for trading";
			component2.m_itemData.m_shared.m_value = 1;
			CustomItem customItem2 = new CustomItem(gameObject2, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "forge",
				MinStationLevel = 1,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Tin",
						Amount = 5
					}
				}
			});
			ItemManager.Instance.AddItem(customItem2);
			GameObject gameObject3 = this.assetBundle.LoadAsset<GameObject>("CoinsCopper");
			ItemDrop component3 = gameObject3.GetComponent<ItemDrop>();
			component3.m_itemData.m_dropPrefab = gameObject3;
			component3.m_itemData.m_shared.m_name = "Copper Coins";
			component3.m_itemData.m_shared.m_description = "Coins made of Copper, for trading";
			component3.m_itemData.m_shared.m_value = 1;
			CustomItem customItem3 = new CustomItem(gameObject3, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "forge",
				MinStationLevel = 1,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Copper",
						Amount = 5
					}
				}
			});
			ItemManager.Instance.AddItem(customItem3);
			GameObject gameObject4 = this.assetBundle.LoadAsset<GameObject>("CoinsBronze");
			ItemDrop component4 = gameObject4.GetComponent<ItemDrop>();
			component4.m_itemData.m_dropPrefab = gameObject4;
			component4.m_itemData.m_shared.m_name = "Bronze Coins";
			component4.m_itemData.m_shared.m_description = "Coins made of Bronze, for trading";
			component4.m_itemData.m_shared.m_value = 3;
			CustomItem customItem4 = new CustomItem(gameObject4, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "forge",
				MinStationLevel = 2,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Bronze",
						Amount = 1
					}
				}
			});
			ItemManager.Instance.AddItem(customItem4);
			GameObject gameObject5 = this.assetBundle.LoadAsset<GameObject>("CoinsIron");
			ItemDrop component5 = gameObject5.GetComponent<ItemDrop>();
			component5.m_itemData.m_dropPrefab = gameObject5;
			component5.m_itemData.m_shared.m_name = "Iron Coins";
			component5.m_itemData.m_shared.m_description = "Coins made of Iron, for trading";
			component5.m_itemData.m_shared.m_value = 5;
			CustomItem customItem5 = new CustomItem(gameObject5, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "piece_mint",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Iron",
						Amount = 5
					}
				}
			});
			ItemManager.Instance.AddItem(customItem5);
			GameObject gameObject6 = this.assetBundle.LoadAsset<GameObject>("CoinsSilver");
			ItemDrop component6 = gameObject6.GetComponent<ItemDrop>();
			component6.m_itemData.m_dropPrefab = gameObject6;
			component6.m_itemData.m_shared.m_name = "Silver Coins";
			component6.m_itemData.m_shared.m_description = "Coins made of Silver, for trading";
			component6.m_itemData.m_shared.m_value = 10;
			CustomItem customItem6 = new CustomItem(gameObject6, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "piece_mint",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Silver",
						Amount = 5
					}
				}
			});
			ItemManager.Instance.AddItem(customItem6);
			GameObject gameObject7 = this.assetBundle.LoadAsset<GameObject>("CoinsBlackmetal");
			ItemDrop component7 = gameObject7.GetComponent<ItemDrop>();
			component7.m_itemData.m_dropPrefab = gameObject7;
			component7.m_itemData.m_shared.m_name = "BlackMetal Coins";
			component7.m_itemData.m_shared.m_description = "Coins made of BlackMetal, for trading";
			component7.m_itemData.m_shared.m_value = 15;
			CustomItem customItem7 = new CustomItem(gameObject7, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "piece_mint",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "BlackMetal",
						Amount = 5
					}
				}
			});
			ItemManager.Instance.AddItem(customItem7);
			GameObject gameObject8 = this.assetBundle.LoadAsset<GameObject>("CoinsHeavymetal");
			ItemDrop component8 = gameObject8.GetComponent<ItemDrop>();
			component8.m_itemData.m_dropPrefab = gameObject8;
			component8.m_itemData.m_shared.m_name = "Heavymetal Coins";
			component8.m_itemData.m_shared.m_description = "Coins made of Heavymetal, for trading";
			component8.m_itemData.m_shared.m_value = 25;
			CustomItem customItem8 = new CustomItem(gameObject8, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "piece_mint",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "HeavymetalBar",
						Amount = 5
					}
				}
			});
			ItemManager.Instance.AddItem(customItem8);
			GameObject gameObject9 = this.assetBundle.LoadAsset<GameObject>("CoinsFrometal");
			ItemDrop component9 = gameObject9.GetComponent<ItemDrop>();
			component9.m_itemData.m_dropPrefab = gameObject9;
			component9.m_itemData.m_shared.m_name = "Frometal Coins";
			component9.m_itemData.m_shared.m_description = "Coins made of Frometal, for trading";
			component9.m_itemData.m_shared.m_value = 50;
			CustomItem customItem9 = new CustomItem(gameObject9, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "piece_mint",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "FrometalBar",
						Amount = 5
					}
				}
			});
			ItemManager.Instance.AddItem(customItem9);
			GameObject gameObject10 = this.assetBundle.LoadAsset<GameObject>("CoinsFlametal");
			ItemDrop component10 = gameObject10.GetComponent<ItemDrop>();
			component10.m_itemData.m_dropPrefab = gameObject10;
			component10.m_itemData.m_shared.m_name = "Flametal Coins";
			component10.m_itemData.m_shared.m_description = "Coins made of Flametal, for trading";
			component10.m_itemData.m_shared.m_value = 75;
			CustomItem customItem10 = new CustomItem(gameObject10, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "piece_mint",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "FlametalBar",
						Amount = 5
					}
				}
			});
			ItemManager.Instance.AddItem(customItem10);
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00003704 File Offset: 0x00001904
		private void CreateTools()
		{
			GameObject gameObject = this.assetBundle.LoadAsset<GameObject>("HammerSilver");
			ItemDrop component = gameObject.GetComponent<ItemDrop>();
			component.m_itemData.m_dropPrefab = gameObject;
			component.m_itemData.m_shared.m_name = "Soulin's Hammer";
			component.m_itemData.m_shared.m_description = "A Hammer made out of Silver, I wonder what it can do?";
			CustomItem customItem = new CustomItem(gameObject, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "forge",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Silver",
						Amount = 10
					}
				}
			});
			ItemManager.Instance.AddItem(customItem);
			GameObject gameObject2 = this.assetBundle.LoadAsset<GameObject>("HoeSilver");
			ItemDrop component2 = gameObject2.GetComponent<ItemDrop>();
			component2.m_itemData.m_dropPrefab = gameObject2;
			component2.m_itemData.m_shared.m_name = "Adonis' Hoe";
			component2.m_itemData.m_shared.m_description = "A Hoe made out of Silver, I wonder what it can do?";
			CustomItem customItem2 = new CustomItem(gameObject2, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "forge",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Silver",
						Amount = 10
					}
				}
			});
			ItemManager.Instance.AddItem(customItem2);
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00003870 File Offset: 0x00001A70
		private void CreateCraftingPieces()
		{
			GameObject gameObject = this.assetBundle.LoadAsset<GameObject>("piece_alchemystation");
			Piece component = gameObject.GetComponent<Piece>();
			component.m_name = "Alchemy Station";
			component.m_description = "Alchemical Combination!";
			CraftingStation component2 = gameObject.GetComponent<CraftingStation>();
			component2.m_name = "Alchemy Station";
			CustomPiece customPiece = new CustomPiece(gameObject, new PieceConfig
			{
				PieceTable = "_HammerPieceTable",
				CraftingStation = "piece_artisanstation",
				AllowedInDungeons = false,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "RoundLog",
						Amount = 12,
						Recover = true
					},
					new RequirementConfig
					{
						Item = "YagluthDrop",
						Amount = 1,
						Recover = true
					},
					new RequirementConfig
					{
						Item = "BlackMetal",
						Amount = 10,
						Recover = true
					}
				}
			});
			PieceManager.Instance.AddPiece(customPiece);
			GameObject gameObject2 = this.assetBundle.LoadAsset<GameObject>("piece_mint");
			Piece component3 = gameObject2.GetComponent<Piece>();
			component3.m_name = "Coin Mint";
			component3.m_description = "A Coin Mint";
			CraftingStation component4 = gameObject2.GetComponent<CraftingStation>();
			component4.m_name = "Coin Mint";
			CustomPiece customPiece2 = new CustomPiece(gameObject2, new PieceConfig
			{
				PieceTable = "_HammerPieceTable",
				CraftingStation = "forge",
				AllowedInDungeons = false,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Wood",
						Amount = 20,
						Recover = true
					},
					new RequirementConfig
					{
						Item = "Bronze",
						Amount = 10,
						Recover = true
					},
					new RequirementConfig
					{
						Item = "TrollHide",
						Amount = 5,
						Recover = true
					}
				}
			});
			PieceManager.Instance.AddPiece(customPiece2);
			GameObject gameObject3 = this.assetBundle.LoadAsset<GameObject>("piece_foodcraftstation");
			Piece component5 = gameObject3.GetComponent<Piece>();
			component5.m_name = "Cooking Station+";
			component5.m_description = "A better cooking station";
			CraftingStation component6 = gameObject3.GetComponent<CraftingStation>();
			component6.m_name = "Cooking Station+";
			CustomPiece customPiece3 = new CustomPiece(gameObject3, new PieceConfig
			{
				PieceTable = "_HammerPieceTable",
				AllowedInDungeons = false,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Bronze",
						Amount = 5,
						Recover = true
					}
				}
			});
			PieceManager.Instance.AddPiece(customPiece3);
			GameObject gameObject4 = this.assetBundle.LoadAsset<GameObject>("campfire");
			Piece component7 = gameObject4.GetComponent<Piece>();
			component7.m_name = "Campfire";
			component7.m_description = "A campfire";
			CraftingStation component8 = gameObject4.GetComponent<CraftingStation>();
			component8.m_name = "Campfire";
			CustomPiece customPiece4 = new CustomPiece(gameObject4, new PieceConfig
			{
				PieceTable = "_HammerPieceTable",
				AllowedInDungeons = false,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Wood",
						Amount = 10,
						Recover = true
					},
					new RequirementConfig
					{
						Item = "Stone",
						Amount = 5,
						Recover = true
					}
				}
			});
			PieceManager.Instance.AddPiece(customPiece4);
			GameObject gameObject5 = this.assetBundle.LoadAsset<GameObject>("piece_glasscutter");
			Piece component9 = gameObject5.GetComponent<Piece>();
			component9.m_name = "Glass Cutter";
			component9.m_description = "A glass cutting station";
			CraftingStation component10 = gameObject5.GetComponent<CraftingStation>();
			component10.m_name = "Glass Cutter";
			CustomPiece customPiece5 = new CustomPiece(gameObject5, new PieceConfig
			{
				PieceTable = "_HammerPieceTable",
				CraftingStation = "forge",
				AllowedInDungeons = false,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Wood",
						Amount = 15,
						Recover = true
					},
					new RequirementConfig
					{
						Item = "Iron",
						Amount = 8,
						Recover = true
					},
					new RequirementConfig
					{
						Item = "Bronze",
						Amount = 6,
						Recover = true
					}
				}
			});
			PieceManager.Instance.AddPiece(customPiece5);
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00003D08 File Offset: 0x00001F08
		private void CreateIronPieces()
		{
			GameObject gameObject = this.assetBundle.LoadAsset<GameObject>("irondoor");
			Piece component = gameObject.GetComponent<Piece>();
			component.m_name = "Iron Door";
			component.m_description = "A door made of iron";
			CustomPiece customPiece = new CustomPiece(gameObject, new PieceConfig
			{
				PieceTable = "_HammerPieceTable",
				CraftingStation = "forge",
				AllowedInDungeons = false,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Iron",
						Amount = 2,
						Recover = true
					}
				}
			});
			PieceManager.Instance.AddPiece(customPiece);
			GameObject gameObject2 = this.assetBundle.LoadAsset<GameObject>("ironwall");
			Piece component2 = gameObject2.GetComponent<Piece>();
			component2.m_name = "Iron Wall";
			component2.m_description = "A wall of iron";
			CustomPiece customPiece2 = new CustomPiece(gameObject2, new PieceConfig
			{
				PieceTable = "_HammerPieceTable",
				CraftingStation = "forge",
				AllowedInDungeons = false,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Iron",
						Amount = 2,
						Recover = true
					}
				}
			});
			PieceManager.Instance.AddPiece(customPiece2);
			GameObject gameObject3 = this.assetBundle.LoadAsset<GameObject>("ironwallhalf");
			Piece component3 = gameObject3.GetComponent<Piece>();
			component3.m_name = "Iron Half Wall";
			component3.m_description = "A half wall of iron";
			CustomPiece customPiece3 = new CustomPiece(gameObject3, new PieceConfig
			{
				PieceTable = "_HammerPieceTable",
				CraftingStation = "forge",
				AllowedInDungeons = false,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Iron",
						Amount = 1,
						Recover = true
					}
				}
			});
			PieceManager.Instance.AddPiece(customPiece3);
			GameObject gameObject4 = this.assetBundle.LoadAsset<GameObject>("ironwallroof29");
			Piece component4 = gameObject4.GetComponent<Piece>();
			component4.m_name = "Iron Wall 26°";
			component4.m_description = "A 26° angled wall of iron";
			CustomPiece customPiece4 = new CustomPiece(gameObject4, new PieceConfig
			{
				PieceTable = "_HammerPieceTable",
				CraftingStation = "forge",
				AllowedInDungeons = false,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Iron",
						Amount = 1,
						Recover = true
					}
				}
			});
			PieceManager.Instance.AddPiece(customPiece4);
			GameObject gameObject5 = this.assetBundle.LoadAsset<GameObject>("ironwallroof45");
			Piece component5 = gameObject5.GetComponent<Piece>();
			component5.m_name = "Iron Wall 45°";
			component5.m_description = "A 45° angled wall of iron";
			CustomPiece customPiece5 = new CustomPiece(gameObject5, new PieceConfig
			{
				PieceTable = "_HammerPieceTable",
				CraftingStation = "forge",
				AllowedInDungeons = false,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Iron",
						Amount = 1,
						Recover = true
					}
				}
			});
			PieceManager.Instance.AddPiece(customPiece5);
			GameObject gameObject6 = this.assetBundle.LoadAsset<GameObject>("ironroof29");
			Piece component6 = gameObject6.GetComponent<Piece>();
			component6.m_name = "Iron Roof 26°";
			component6.m_description = "A roof of iron at a 26° angle";
			CustomPiece customPiece6 = new CustomPiece(gameObject6, new PieceConfig
			{
				PieceTable = "_HammerPieceTable",
				CraftingStation = "forge",
				AllowedInDungeons = false,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Iron",
						Amount = 3,
						Recover = true
					}
				}
			});
			PieceManager.Instance.AddPiece(customPiece6);
			GameObject gameObject7 = this.assetBundle.LoadAsset<GameObject>("ironroof45");
			Piece component7 = gameObject7.GetComponent<Piece>();
			component7.m_name = "Iron Roof 45°";
			component7.m_description = "A roof of iron at a 29° angle";
			CustomPiece customPiece7 = new CustomPiece(gameObject7, new PieceConfig
			{
				PieceTable = "_HammerPieceTable",
				CraftingStation = "forge",
				AllowedInDungeons = false,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Iron",
						Amount = 3,
						Recover = true
					}
				}
			});
			PieceManager.Instance.AddPiece(customPiece7);
			GameObject gameObject8 = this.assetBundle.LoadAsset<GameObject>("thickironwall1x1");
			Piece component8 = gameObject8.GetComponent<Piece>();
			component8.m_name = "Iron Wall 1x1";
			component8.m_description = "A 1x1 wall of iron";
			CustomPiece customPiece8 = new CustomPiece(gameObject8, new PieceConfig
			{
				PieceTable = "_HammerPieceTable",
				CraftingStation = "forge",
				AllowedInDungeons = false,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Iron",
						Amount = 4,
						Recover = true
					}
				}
			});
			PieceManager.Instance.AddPiece(customPiece8);
			GameObject gameObject9 = this.assetBundle.LoadAsset<GameObject>("thickironwall2x2");
			Piece component9 = gameObject9.GetComponent<Piece>();
			component9.m_name = "Iron Wall 2x2";
			component9.m_description = "A 2x2 wall of iron";
			CustomPiece customPiece9 = new CustomPiece(gameObject9, new PieceConfig
			{
				PieceTable = "_HammerPieceTable",
				CraftingStation = "forge",
				AllowedInDungeons = false,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Iron",
						Amount = 8,
						Recover = true
					}
				}
			});
			PieceManager.Instance.AddPiece(customPiece9);
			GameObject gameObject10 = this.assetBundle.LoadAsset<GameObject>("thickironwall4x2");
			Piece component10 = gameObject10.GetComponent<Piece>();
			component10.m_name = "Iron Wall 4x2";
			component10.m_description = "A 4x2 wall of iron";
			CustomPiece customPiece10 = new CustomPiece(gameObject10, new PieceConfig
			{
				PieceTable = "_HammerPieceTable",
				CraftingStation = "forge",
				AllowedInDungeons = false,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Iron",
						Amount = 12,
						Recover = true
					}
				}
			});
			PieceManager.Instance.AddPiece(customPiece10);
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00004394 File Offset: 0x00002594
		private void CreateGlassPieces()
		{
			GameObject gameObject = this.assetBundle.LoadAsset<GameObject>("glassdoor");
			Piece component = gameObject.GetComponent<Piece>();
			component.m_name = "Glass Door";
			component.m_description = "A door made of glass";
			CustomPiece customPiece = new CustomPiece(gameObject, new PieceConfig
			{
				PieceTable = "_HammerPieceTable",
				CraftingStation = "piece_glasscutter",
				AllowedInDungeons = false,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "GlassBar",
						Amount = 1,
						Recover = true
					}
				}
			});
			PieceManager.Instance.AddPiece(customPiece);
			GameObject gameObject2 = this.assetBundle.LoadAsset<GameObject>("glasswall");
			Piece component2 = gameObject2.GetComponent<Piece>();
			component2.m_name = "Glass Wall";
			component2.m_description = "A wall of transparent glass";
			CustomPiece customPiece2 = new CustomPiece(gameObject2, new PieceConfig
			{
				PieceTable = "_HammerPieceTable",
				CraftingStation = "piece_glasscutter",
				AllowedInDungeons = false,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "GlassBar",
						Amount = 2,
						Recover = true
					}
				}
			});
			PieceManager.Instance.AddPiece(customPiece2);
			GameObject gameObject3 = this.assetBundle.LoadAsset<GameObject>("glasswallhalf");
			Piece component3 = gameObject3.GetComponent<Piece>();
			component3.m_name = "Glass Half Wall";
			component3.m_description = "A half wall of transparent glass";
			CustomPiece customPiece3 = new CustomPiece(gameObject3, new PieceConfig
			{
				PieceTable = "_HammerPieceTable",
				CraftingStation = "piece_glasscutter",
				AllowedInDungeons = false,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "GlassBar",
						Amount = 1,
						Recover = true
					}
				}
			});
			PieceManager.Instance.AddPiece(customPiece3);
			GameObject gameObject4 = this.assetBundle.LoadAsset<GameObject>("glasswallroof29");
			Piece component4 = gameObject4.GetComponent<Piece>();
			component4.m_name = "Glass Wall 26°";
			component4.m_description = "A 29° angled wall of transparent glass";
			CustomPiece customPiece4 = new CustomPiece(gameObject4, new PieceConfig
			{
				PieceTable = "_HammerPieceTable",
				CraftingStation = "piece_glasscutter",
				AllowedInDungeons = false,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "GlassBar",
						Amount = 1,
						Recover = true
					}
				}
			});
			PieceManager.Instance.AddPiece(customPiece4);
			GameObject gameObject5 = this.assetBundle.LoadAsset<GameObject>("glasswallroof45");
			Piece component5 = gameObject5.GetComponent<Piece>();
			component5.m_name = "Glass Wall 45°";
			component5.m_description = "A 45° angled wall of transparent glass";
			CustomPiece customPiece5 = new CustomPiece(gameObject5, new PieceConfig
			{
				PieceTable = "_HammerPieceTable",
				CraftingStation = "piece_glasscutter",
				AllowedInDungeons = false,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "GlassBar",
						Amount = 1,
						Recover = true
					}
				}
			});
			PieceManager.Instance.AddPiece(customPiece5);
			GameObject gameObject6 = this.assetBundle.LoadAsset<GameObject>("glassroof29");
			Piece component6 = gameObject6.GetComponent<Piece>();
			component6.m_name = "Glass Roof 26°";
			component6.m_description = "A roof of transparent glass at a 29° angle";
			CustomPiece customPiece6 = new CustomPiece(gameObject6, new PieceConfig
			{
				PieceTable = "_HammerPieceTable",
				CraftingStation = "piece_glasscutter",
				AllowedInDungeons = false,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "GlassBar",
						Amount = 3,
						Recover = true
					}
				}
			});
			PieceManager.Instance.AddPiece(customPiece6);
			GameObject gameObject7 = this.assetBundle.LoadAsset<GameObject>("glassroof45");
			Piece component7 = gameObject7.GetComponent<Piece>();
			component7.m_name = "Glass Roof 45°";
			component7.m_description = "A roof of transparent glass at a 29° angle";
			CustomPiece customPiece7 = new CustomPiece(gameObject7, new PieceConfig
			{
				PieceTable = "_HammerPieceTable",
				CraftingStation = "piece_glasscutter",
				AllowedInDungeons = false,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "GlassBar",
						Amount = 3,
						Recover = true
					}
				}
			});
			PieceManager.Instance.AddPiece(customPiece7);
			GameObject gameObject8 = this.assetBundle.LoadAsset<GameObject>("thickglasswall1x1");
			Piece component8 = gameObject8.GetComponent<Piece>();
			component8.m_name = "Glass Wall 1x1";
			component8.m_description = "A 1x1 wall of transparent glass";
			CustomPiece customPiece8 = new CustomPiece(gameObject8, new PieceConfig
			{
				PieceTable = "_HammerPieceTable",
				CraftingStation = "piece_glasscutter",
				AllowedInDungeons = false,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "GlassBar",
						Amount = 4,
						Recover = true
					}
				}
			});
			PieceManager.Instance.AddPiece(customPiece8);
			GameObject gameObject9 = this.assetBundle.LoadAsset<GameObject>("thickglasswall2x2");
			Piece component9 = gameObject9.GetComponent<Piece>();
			component9.m_name = "Glass Wall 2x2";
			component9.m_description = "A 2x2 wall of transparent glass";
			CustomPiece customPiece9 = new CustomPiece(gameObject9, new PieceConfig
			{
				PieceTable = "_HammerPieceTable",
				CraftingStation = "piece_glasscutter",
				AllowedInDungeons = false,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "GlassBar",
						Amount = 8,
						Recover = true
					}
				}
			});
			PieceManager.Instance.AddPiece(customPiece9);
			GameObject gameObject10 = this.assetBundle.LoadAsset<GameObject>("thickglasswall4x2");
			Piece component10 = gameObject10.GetComponent<Piece>();
			component10.m_name = "Glass Wall 4x2";
			component10.m_description = "A 4x2 wall of transparent glass";
			CustomPiece customPiece10 = new CustomPiece(gameObject10, new PieceConfig
			{
				PieceTable = "_HammerPieceTable",
				CraftingStation = "piece_glasscutter",
				AllowedInDungeons = false,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "GlassBar",
						Amount = 12,
						Recover = true
					}
				}
			});
			PieceManager.Instance.AddPiece(customPiece10);
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00004A20 File Offset: 0x00002C20
		private void CreateStoragePieces()
		{
			GameObject gameObject = this.assetBundle.LoadAsset<GameObject>("CargoCrateBig");
			Piece component = gameObject.GetComponent<Piece>();
			component.m_name = "Cargo Crate";
			component.m_description = "Stackable storage container";
			Container component2 = gameObject.GetComponent<Container>();
			component2.m_name = "Cargo Crate";
			CustomPiece customPiece = new CustomPiece(gameObject, new PieceConfig
			{
				PieceTable = "_HammerPieceTable",
				CraftingStation = "piece_workbench",
				AllowedInDungeons = false,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Wood",
						Amount = 12,
						Recover = true
					},
					new RequirementConfig
					{
						Item = "Iron",
						Amount = 2,
						Recover = true
					}
				}
			});
			PieceManager.Instance.AddPiece(customPiece);
			GameObject gameObject2 = this.assetBundle.LoadAsset<GameObject>("HeavymetalSafe");
			Piece component3 = gameObject2.GetComponent<Piece>();
			component3.m_name = "Heavymetal Safe";
			component3.m_description = "The most secure container";
			Container component4 = gameObject2.GetComponent<Container>();
			component4.m_name = "Heavymetal Safe";
			CustomPiece customPiece2 = new CustomPiece(gameObject2, new PieceConfig
			{
				PieceTable = "_HammerPieceTable",
				CraftingStation = "forge",
				AllowedInDungeons = false,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "HeavymetalBar",
						Amount = 8,
						Recover = true
					}
				}
			});
			PieceManager.Instance.AddPiece(customPiece2);
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00004BC0 File Offset: 0x00002DC0
		private void AddWorkbenchRecipes()
		{
			CustomRecipe customRecipe = new CustomRecipe(new RecipeConfig
			{
				Name = "Recipe_DeerHideScraps",
				Item = "LeatherScraps",
				CraftingStation = "piece_workbench",
				MinStationLevel = 1,
				Amount = 3,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "DeerHide",
						Amount = 1
					}
				}
			});
			ItemManager.Instance.AddRecipe(customRecipe);
			CustomRecipe customRecipe2 = new CustomRecipe(new RecipeConfig
			{
				Name = "Recipe_WolfPeltScraps",
				Item = "LeatherScraps",
				CraftingStation = "piece_workbench",
				MinStationLevel = 1,
				Amount = 4,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "WolfPelt",
						Amount = 1
					}
				}
			});
			ItemManager.Instance.AddRecipe(customRecipe2);
			CustomRecipe customRecipe3 = new CustomRecipe(new RecipeConfig
			{
				Name = "Recipe_TrollHideScraps",
				Item = "LeatherScraps",
				CraftingStation = "piece_workbench",
				MinStationLevel = 1,
				Amount = 5,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "TrollHide",
						Amount = 1
					}
				}
			});
			ItemManager.Instance.AddRecipe(customRecipe3);
			CustomRecipe customRecipe4 = new CustomRecipe(new RecipeConfig
			{
				Name = "Recipe_LoxPeltScraps",
				Item = "LeatherScraps",
				CraftingStation = "piece_workbench",
				MinStationLevel = 1,
				Amount = 8,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "LoxPelt",
						Amount = 1
					}
				}
			});
			ItemManager.Instance.AddRecipe(customRecipe4);
			CustomRecipe customRecipe5 = new CustomRecipe(new RecipeConfig
			{
				Name = "Recipe_StoneSandFlint",
				Item = "Flint",
				CraftingStation = "piece_stonecutter",
				MinStationLevel = 1,
				Amount = 1,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Sand",
						Amount = 2
					},
					new RequirementConfig
					{
						Item = "Stone",
						Amount = 1
					}
				}
			});
			ItemManager.Instance.AddRecipe(customRecipe5);
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00004E64 File Offset: 0x00003064
		private void AddForgeRecipes()
		{
			CustomRecipe customRecipe = new CustomRecipe(new RecipeConfig
			{
				Item = "Chain",
				CraftingStation = "forge",
				MinStationLevel = 1,
				Amount = 1,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Iron",
						Amount = 4
					},
					new RequirementConfig
					{
						Item = "Silver",
						Amount = 2
					}
				}
			});
			ItemManager.Instance.AddRecipe(customRecipe);
			BoneReorder.ApplyOnEquipmentChanged();
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00004F00 File Offset: 0x00003100
		private void AddCampfireRecipes()
		{
			CustomRecipe customRecipe = new CustomRecipe(new RecipeConfig
			{
				Name = "Recipe_WoodCoal",
				Item = "Coal",
				CraftingStation = "campfire",
				MinStationLevel = 1,
				Amount = 1,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Wood",
						Amount = 3
					}
				}
			});
			ItemManager.Instance.AddRecipe(customRecipe);
			CustomRecipe customRecipe2 = new CustomRecipe(new RecipeConfig
			{
				Name = "Recipe_FineWoodCoal",
				Item = "Coal",
				CraftingStation = "campfire",
				MinStationLevel = 1,
				Amount = 1,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "FineWood",
						Amount = 2
					}
				}
			});
			ItemManager.Instance.AddRecipe(customRecipe2);
			CustomRecipe customRecipe3 = new CustomRecipe(new RecipeConfig
			{
				Name = "Recipe_RoundLogCoal",
				Item = "Coal",
				CraftingStation = "campfire",
				MinStationLevel = 1,
				Amount = 1,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "RoundLog",
						Amount = 1
					}
				}
			});
			ItemManager.Instance.AddRecipe(customRecipe3);
			CustomRecipe customRecipe4 = new CustomRecipe(new RecipeConfig
			{
				Name = "Recipe_NeckTailCoal",
				Item = "Coal",
				CraftingStation = "campfire",
				MinStationLevel = 1,
				Amount = 1,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "NeckTail",
						Amount = 1
					}
				}
			});
			ItemManager.Instance.AddRecipe(customRecipe4);
			CustomRecipe customRecipe5 = new CustomRecipe(new RecipeConfig
			{
				Name = "Recipe_RawMeatCoal",
				Item = "Coal",
				CraftingStation = "campfire",
				MinStationLevel = 1,
				Amount = 1,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "RawMeat",
						Amount = 1
					}
				}
			});
			ItemManager.Instance.AddRecipe(customRecipe5);
			CustomRecipe customRecipe6 = new CustomRecipe(new RecipeConfig
			{
				Name = "Recipe_FishRawCoal",
				Item = "Coal",
				CraftingStation = "campfire",
				MinStationLevel = 1,
				Amount = 1,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "FishRaw",
						Amount = 1
					}
				}
			});
			ItemManager.Instance.AddRecipe(customRecipe6);
			CustomRecipe customRecipe7 = new CustomRecipe(new RecipeConfig
			{
				Name = "Recipe_SerpentMeatCoal",
				Item = "Coal",
				CraftingStation = "campfire",
				MinStationLevel = 1,
				Amount = 1,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "SerpentMeat",
						Amount = 1
					}
				}
			});
			ItemManager.Instance.AddRecipe(customRecipe7);
			CustomRecipe customRecipe8 = new CustomRecipe(new RecipeConfig
			{
				Name = "Recipe_LoxMeatCoal",
				Item = "Coal",
				CraftingStation = "campfire",
				MinStationLevel = 1,
				Amount = 1,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "LoxMeat",
						Amount = 1
					}
				}
			});
			ItemManager.Instance.AddRecipe(customRecipe8);
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00005308 File Offset: 0x00003508
		private void AddFoodCraftRecipes()
		{
			CustomRecipe customRecipe = new CustomRecipe(new RecipeConfig
			{
				Name = "Recipe_NeckTailCooked",
				Item = "NeckTailGrilled",
				CraftingStation = "piece_foodcraftstation",
				MinStationLevel = 1,
				Amount = 1,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "NeckTail",
						Amount = 1
					},
					new RequirementConfig
					{
						Item = "Resin",
						Amount = 1
					}
				}
			});
			ItemManager.Instance.AddRecipe(customRecipe);
			CustomRecipe customRecipe2 = new CustomRecipe(new RecipeConfig
			{
				Name = "Recipe_NeckTailCooked5",
				Item = "NeckTailGrilled",
				CraftingStation = "piece_foodcraftstation",
				MinStationLevel = 1,
				Amount = 5,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "NeckTail",
						Amount = 5
					},
					new RequirementConfig
					{
						Item = "Resin",
						Amount = 5
					}
				}
			});
			ItemManager.Instance.AddRecipe(customRecipe2);
			CustomRecipe customRecipe3 = new CustomRecipe(new RecipeConfig
			{
				Name = "Recipe_RawMeatCooked",
				Item = "CookedMeat",
				CraftingStation = "piece_foodcraftstation",
				MinStationLevel = 1,
				Amount = 1,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "RawMeat",
						Amount = 1
					},
					new RequirementConfig
					{
						Item = "Resin",
						Amount = 1
					}
				}
			});
			ItemManager.Instance.AddRecipe(customRecipe3);
			CustomRecipe customRecipe4 = new CustomRecipe(new RecipeConfig
			{
				Name = "Recipe_RawMeatCooked5",
				Item = "CookedMeat",
				CraftingStation = "piece_foodcraftstation",
				MinStationLevel = 1,
				Amount = 5,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "RawMeat",
						Amount = 5
					},
					new RequirementConfig
					{
						Item = "Resin",
						Amount = 5
					}
				}
			});
			ItemManager.Instance.AddRecipe(customRecipe4);
			CustomRecipe customRecipe5 = new CustomRecipe(new RecipeConfig
			{
				Name = "Recipe_FishRawCooked",
				Item = "FishCooked",
				CraftingStation = "piece_foodcraftstation",
				MinStationLevel = 1,
				Amount = 1,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "FishRaw",
						Amount = 1
					},
					new RequirementConfig
					{
						Item = "Resin",
						Amount = 1
					}
				}
			});
			ItemManager.Instance.AddRecipe(customRecipe5);
			CustomRecipe customRecipe6 = new CustomRecipe(new RecipeConfig
			{
				Name = "Recipe_FishRawCooked5",
				Item = "FishCooked",
				CraftingStation = "piece_foodcraftstation",
				MinStationLevel = 1,
				Amount = 5,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "FishRaw",
						Amount = 5
					},
					new RequirementConfig
					{
						Item = "Resin",
						Amount = 5
					}
				}
			});
			ItemManager.Instance.AddRecipe(customRecipe6);
			CustomRecipe customRecipe7 = new CustomRecipe(new RecipeConfig
			{
				Name = "Recipe_SerpentMeatCooked",
				Item = "SerpentMeatCooked",
				CraftingStation = "piece_foodcraftstation",
				MinStationLevel = 1,
				Amount = 1,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "SerpentMeat",
						Amount = 1
					},
					new RequirementConfig
					{
						Item = "Resin",
						Amount = 1
					}
				}
			});
			ItemManager.Instance.AddRecipe(customRecipe7);
			CustomRecipe customRecipe8 = new CustomRecipe(new RecipeConfig
			{
				Name = "Recipe_SerpentMeatCooked5",
				Item = "SerpentMeatCooked",
				CraftingStation = "piece_foodcraftstation",
				MinStationLevel = 1,
				Amount = 5,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "SerpentMeat",
						Amount = 5
					},
					new RequirementConfig
					{
						Item = "Resin",
						Amount = 5
					}
				}
			});
			ItemManager.Instance.AddRecipe(customRecipe8);
			CustomRecipe customRecipe9 = new CustomRecipe(new RecipeConfig
			{
				Name = "Recipe_LoxMeatCooked",
				Item = "CookedLoxMeat",
				CraftingStation = "piece_foodcraftstation",
				MinStationLevel = 1,
				Amount = 1,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "LoxMeat",
						Amount = 1
					},
					new RequirementConfig
					{
						Item = "Resin",
						Amount = 1
					}
				}
			});
			ItemManager.Instance.AddRecipe(customRecipe9);
			CustomRecipe customRecipe10 = new CustomRecipe(new RecipeConfig
			{
				Name = "Recipe_LoxMeatCooked5",
				Item = "CookedLoxMeat",
				CraftingStation = "piece_foodcraftstation",
				MinStationLevel = 1,
				Amount = 5,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "LoxMeat",
						Amount = 5
					},
					new RequirementConfig
					{
						Item = "Resin",
						Amount = 5
					}
				}
			});
			ItemManager.Instance.AddRecipe(customRecipe10);
		}

		// Token: 0x04000001 RID: 1
		public const string PluginGUID = "MrRageous.ValEx";

		// Token: 0x04000002 RID: 2
		public const string PluginName = "ValheimExpanded: Core Module";

		// Token: 0x04000003 RID: 3
		public const string PluginVersion = "0.4.1";

		// Token: 0x04000004 RID: 4
		private AssetBundle assetBundle;
	}
}
