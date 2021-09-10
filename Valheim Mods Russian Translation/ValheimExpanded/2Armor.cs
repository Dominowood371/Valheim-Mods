using System;
using BepInEx;
using Jotunn;
using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;
using Jotunn.Utils;
using UnityEngine;

namespace ValExArmors
{
	// Token: 0x02000002 RID: 2
	[BepInPlugin("MrRageous.ValExArmor", "ValheimExpanded: Armor Module", "0.4.1")]
	[BepInDependency("com.jotunn.jotunn", BepInDependency.DependencyFlags.HardDependency)]
	[NetworkCompatibility(CompatibilityLevel.OnlySyncWhenInstalled, VersionStrictness.Minor)]
	public class Setup : BaseUnityPlugin
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		private void Awake()
		{
			this.LoadAssets();
			ItemManager.OnVanillaItemsAvailable += this.AddRagItems;
			ItemManager.OnVanillaItemsAvailable += this.AddLeatherItems;
			ItemManager.OnVanillaItemsAvailable += this.AddBoneItems;
			ItemManager.OnVanillaItemsAvailable += this.AddTrollItems;
			ItemManager.OnVanillaItemsAvailable += this.AddBronzeItems;
			ItemManager.OnVanillaItemsAvailable += this.AddAncientItems;
			ItemManager.OnVanillaItemsAvailable += this.AddIronItems;
			ItemManager.OnVanillaItemsAvailable += this.AddAbyssalItems;
			ItemManager.OnVanillaItemsAvailable += this.AddSilverItems;
			ItemManager.OnVanillaItemsAvailable += this.AddWolfItems;
			ItemManager.OnVanillaItemsAvailable += this.AddBlackMetalItems;
			ItemManager.OnVanillaItemsAvailable += this.AddPaddedItems;
			ItemManager.OnVanillaItemsAvailable += this.AddHeavymetalItems;
			ItemManager.OnVanillaItemsAvailable += this.AddHeavyscaleItems;
			ItemManager.OnVanillaItemsAvailable += this.AddFrometalItems;
			ItemManager.OnVanillaItemsAvailable += this.AddDrakescaleItems;
			ItemManager.OnVanillaItemsAvailable += this.AddFlametalItems;
			ItemManager.OnVanillaItemsAvailable += this.AddForgedscaleItems;
		}

		// Token: 0x06000002 RID: 2 RVA: 0x000021AC File Offset: 0x000003AC
		private void LoadAssets()
		{
			Logger.LogInfo("Embedded resources: " + string.Join(",", typeof(Setup).Assembly.GetManifestResourceNames()));
			this.assetBundle = AssetUtils.LoadAssetBundleFromResources("zarmors", typeof(Setup).Assembly);
			Logger.LogInfo(this.assetBundle);
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002214 File Offset: 0x00000414
		private void AddRagItems()
		{
			try
			{
				CustomItem customItem = new CustomItem("HelmetRag", "HelmetLeather");
				ItemDrop itemDrop = customItem.ItemDrop;
				itemDrop.m_itemData.m_shared.m_name = "Rag Hat";
				itemDrop.m_itemData.m_shared.m_description = string.Concat(new string[]
				{
					"This item can be reforged into the following;",
					Environment.NewLine,
					"- Leather Helmet",
					Environment.NewLine,
					"> Workbench"
				});
				itemDrop.m_itemData.m_shared.m_armorPerLevel = 1f;
				itemDrop.m_itemData.m_shared.m_maxDurability = 100f;
				itemDrop.m_itemData.m_shared.m_durabilityPerLevel = 25f;
				itemDrop.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop.m_itemData.m_shared.m_destroyBroken = false;
				itemDrop.m_itemData.m_shared.m_armor = 1f;
				itemDrop.m_itemData.m_shared.m_setName = "Rag Armor";
				itemDrop.m_itemData.m_shared.m_setSize = 3;
				ItemManager.Instance.AddItem(customItem);
				CustomRecipe customRecipe = new CustomRecipe(new RecipeConfig
				{
					Item = "HelmetRag",
					CraftingStation = "piece_workbench",
					MinStationLevel = 2,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "LeatherScraps",
							Amount = 5,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe);
				GameObject gameObject = GameObject.Find("ArmorRagsChest");
				CustomItem customItem2 = new CustomItem("ArmorRagsChes", "ArmorRagsChest");
				ItemDrop itemDrop2 = customItem2.ItemDrop;
				itemDrop2.m_itemData.m_shared.m_name = "Rag Tunic";
				itemDrop2.m_itemData.m_shared.m_description = string.Concat(new string[]
				{
					"This item can be reforged into the following;",
					Environment.NewLine,
					"- Leather Tunic",
					Environment.NewLine,
					"> Workbench"
				});
				itemDrop2.m_itemData.m_shared.m_armorPerLevel = 1f;
				itemDrop2.m_itemData.m_shared.m_maxDurability = 100f;
				itemDrop2.m_itemData.m_shared.m_durabilityPerLevel = 25f;
				itemDrop2.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop2.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop2.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop2.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop2.m_itemData.m_shared.m_destroyBroken = false;
				itemDrop2.m_itemData.m_shared.m_armor = 1f;
				itemDrop2.m_itemData.m_shared.m_setName = "Rag Armor";
				itemDrop2.m_itemData.m_shared.m_setSize = 3;
				ItemManager.Instance.AddItem(customItem2);
				CustomRecipe customRecipe2 = new CustomRecipe(new RecipeConfig
				{
					Item = "ArmorRagsChes",
					CraftingStation = "piece_workbench",
					MinStationLevel = 2,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "LeatherScraps",
							Amount = 5,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe2);
				gameObject = GameObject.Find("ArmorRagsLegs");
				CustomItem customItem3 = new CustomItem("ArmorRagsLeg", "ArmorRagsLegs");
				ItemDrop itemDrop3 = customItem3.ItemDrop;
				itemDrop3.m_itemData.m_shared.m_name = "Rag Pants";
				itemDrop3.m_itemData.m_shared.m_description = string.Concat(new string[]
				{
					"This item can be reforged into the following;",
					Environment.NewLine,
					"- Leather Pants",
					Environment.NewLine,
					"> Workbench"
				});
				itemDrop3.m_itemData.m_shared.m_armorPerLevel = 1f;
				itemDrop3.m_itemData.m_shared.m_maxDurability = 100f;
				itemDrop3.m_itemData.m_shared.m_durabilityPerLevel = 25f;
				itemDrop3.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop3.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop3.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop3.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop3.m_itemData.m_shared.m_destroyBroken = false;
				itemDrop3.m_itemData.m_shared.m_armor = 1f;
				itemDrop3.m_itemData.m_shared.m_setName = "Rag Armor";
				itemDrop3.m_itemData.m_shared.m_setSize = 3;
				ItemManager.Instance.AddItem(customItem3);
				CustomRecipe customRecipe3 = new CustomRecipe(new RecipeConfig
				{
					Item = "ArmorRagsLeg",
					CraftingStation = "piece_workbench",
					MinStationLevel = 2,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "LeatherScraps",
							Amount = 5,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe3);
				CustomItem customItem4 = new CustomItem("CapeRag", "CapeDeerHide");
				ItemDrop itemDrop4 = customItem4.ItemDrop;
				itemDrop4.m_itemData.m_shared.m_name = "Rag Cape";
				itemDrop4.m_itemData.m_shared.m_description = string.Concat(new string[]
				{
					"This item can be reforged into the following;",
					Environment.NewLine,
					"- Deerskin Cape",
					Environment.NewLine,
					"> Workbench"
				});
				itemDrop4.m_itemData.m_shared.m_armorPerLevel = 1f;
				itemDrop4.m_itemData.m_shared.m_maxDurability = 100f;
				itemDrop4.m_itemData.m_shared.m_durabilityPerLevel = 25f;
				itemDrop4.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop4.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop4.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop4.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop4.m_itemData.m_shared.m_destroyBroken = false;
				itemDrop4.m_itemData.m_shared.m_armor = 1f;
				itemDrop4.m_itemData.m_shared.m_setName = "Rag Gear";
				itemDrop4.m_itemData.m_shared.m_setSize = 2;
				ItemManager.Instance.AddItem(customItem4);
				CustomRecipe customRecipe4 = new CustomRecipe(new RecipeConfig
				{
					Item = "CapeRag",
					CraftingStation = "piece_workbench",
					MinStationLevel = 2,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "LeatherScraps",
							Amount = 5,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe4);
				CustomItem customItem5 = new CustomItem("BeltRag", "BeltStrength");
				ItemDrop itemDrop5 = customItem5.ItemDrop;
				itemDrop5.m_itemData.m_shared.m_name = "Rag Belt";
				itemDrop5.m_itemData.m_shared.m_description = string.Concat(new string[]
				{
					"This item can be reforged into the following;",
					Environment.NewLine,
					"- Leather Belt",
					Environment.NewLine,
					"> Workbench"
				});
				itemDrop5.m_itemData.m_shared.m_armorPerLevel = 1f;
				itemDrop5.m_itemData.m_shared.m_maxDurability = 100f;
				itemDrop5.m_itemData.m_shared.m_durabilityPerLevel = 25f;
				itemDrop5.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop5.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop5.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop5.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop5.m_itemData.m_shared.m_destroyBroken = false;
				itemDrop5.m_itemData.m_shared.m_armor = 1f;
				itemDrop5.m_itemData.m_shared.m_setName = "Rag Gear";
				itemDrop5.m_itemData.m_shared.m_setSize = 2;
				ItemManager.Instance.AddItem(customItem5);
				CustomRecipe customRecipe5 = new CustomRecipe(new RecipeConfig
				{
					Item = "BeltRag",
					CraftingStation = "piece_workbench",
					MinStationLevel = 2,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "LeatherScraps",
							Amount = 5,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe5);
			}
			catch (Exception ex)
			{
				Logger.LogError("Error while adding Rag items: " + ex.Message);
			}
			finally
			{
				ItemManager.OnVanillaItemsAvailable -= this.AddRagItems;
			}
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002BD4 File Offset: 0x00000DD4
		private void AddLeatherItems()
		{
			try
			{
				GameObject gameObject = GameObject.Find("HelmetLeather");
				CustomItem customItem = new CustomItem("HelmetLeathe", "HelmetLeather");
				ItemDrop itemDrop = customItem.ItemDrop;
				itemDrop.m_itemData.m_shared.m_name = "Leather Helmet";
				itemDrop.m_itemData.m_shared.m_description = string.Concat(new string[]
				{
					"This item can be reforged into the following;",
					Environment.NewLine,
					"- Bone Helmet",
					Environment.NewLine,
					"> Workbench",
					Environment.NewLine,
					"or",
					Environment.NewLine,
					" - Trollskin Hood",
					Environment.NewLine,
					" > Workbench"
				});
				itemDrop.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop.m_itemData.m_shared.m_maxDurability = 400f;
				itemDrop.m_itemData.m_shared.m_durabilityPerLevel = 50f;
				itemDrop.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop.m_itemData.m_shared.m_destroyBroken = false;
				itemDrop.m_itemData.m_shared.m_armor = 5f;
				itemDrop.m_itemData.m_shared.m_setName = "Leather Armor";
				itemDrop.m_itemData.m_shared.m_setSize = 3;
				ItemManager.Instance.AddItem(customItem);
				CustomRecipe customRecipe = new CustomRecipe(new RecipeConfig
				{
					Item = "HelmetLeathe",
					CraftingStation = "piece_workbench",
					RepairStation = "piece_workbench",
					MinStationLevel = 2,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "DeerHide",
							Amount = 6,
							AmountPerLevel = 3
						},
						new RequirementConfig
						{
							Item = "HelmetRag",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe);
				gameObject = GameObject.Find("ArmorLeatherChest");
				CustomItem customItem2 = new CustomItem("ArmorLeatherChes", "ArmorLeatherChest");
				ItemDrop itemDrop2 = customItem.ItemDrop;
				itemDrop2.m_itemData.m_shared.m_name = "Leather Tunic";
				itemDrop2.m_itemData.m_shared.m_description = string.Concat(new string[]
				{
					"This item can be reforged into the following;",
					Environment.NewLine,
					"- Bone Chestplate",
					Environment.NewLine,
					"> Workbench",
					Environment.NewLine,
					"or",
					Environment.NewLine,
					" - Trollskin Tunic",
					Environment.NewLine,
					" > Forge"
				});
				itemDrop2.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop2.m_itemData.m_shared.m_maxDurability = 400f;
				itemDrop2.m_itemData.m_shared.m_durabilityPerLevel = 50f;
				itemDrop2.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop2.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop2.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop2.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop2.m_itemData.m_shared.m_destroyBroken = false;
				itemDrop2.m_itemData.m_shared.m_armor = 5f;
				itemDrop2.m_itemData.m_shared.m_setName = "Leather Armor";
				itemDrop2.m_itemData.m_shared.m_setSize = 3;
				ItemManager.Instance.AddItem(customItem2);
				CustomRecipe customRecipe2 = new CustomRecipe(new RecipeConfig
				{
					Item = "ArmorLeatherChes",
					CraftingStation = "piece_workbench",
					RepairStation = "piece_workbench",
					MinStationLevel = 2,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "DeerHide",
							Amount = 6,
							AmountPerLevel = 3
						},
						new RequirementConfig
						{
							Item = "ArmorRagsChes",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe2);
				gameObject = GameObject.Find("ArmorLeatherLegs");
				CustomItem customItem3 = new CustomItem("ArmorLeatherLeg", "ArmorLeatherLegs");
				ItemDrop itemDrop3 = customItem3.ItemDrop;
				itemDrop3.m_itemData.m_shared.m_name = "Leather Pants";
				itemDrop3.m_itemData.m_shared.m_description = string.Concat(new string[]
				{
					"This item can be reforged into the following;",
					Environment.NewLine,
					"- Bone Chestplate",
					Environment.NewLine,
					"> Workbench",
					Environment.NewLine,
					"or",
					Environment.NewLine,
					" - Trollskin Pants",
					Environment.NewLine,
					" > Forge"
				});
				itemDrop3.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop3.m_itemData.m_shared.m_maxDurability = 400f;
				itemDrop3.m_itemData.m_shared.m_durabilityPerLevel = 50f;
				itemDrop3.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop3.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop3.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop3.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop3.m_itemData.m_shared.m_destroyBroken = false;
				itemDrop3.m_itemData.m_shared.m_armor = 5f;
				itemDrop3.m_itemData.m_shared.m_setName = "Leather Armor";
				itemDrop3.m_itemData.m_shared.m_setSize = 3;
				ItemManager.Instance.AddItem(customItem3);
				CustomRecipe customRecipe3 = new CustomRecipe(new RecipeConfig
				{
					Item = "ArmorLeatherLeg",
					CraftingStation = "piece_workbench",
					RepairStation = "piece_workbench",
					MinStationLevel = 2,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "DeerHide",
							Amount = 6,
							AmountPerLevel = 3
						},
						new RequirementConfig
						{
							Item = "ArmorRagsLeg",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe3);
				gameObject = GameObject.Find("CapeDeerHide");
				CustomItem customItem4 = new CustomItem("CapeDeerHid", "CapeDeerHide");
				ItemDrop itemDrop4 = customItem4.ItemDrop;
				itemDrop4.m_itemData.m_shared.m_name = "Deerskin Cape";
				itemDrop4.m_itemData.m_shared.m_description = string.Concat(new string[]
				{
					"This item can be reforged into the following;",
					Environment.NewLine,
					"- Bone Cape",
					Environment.NewLine,
					"> Workbench",
					Environment.NewLine,
					"or",
					Environment.NewLine,
					" - Trollskin Cape",
					Environment.NewLine,
					" > Forge"
				});
				itemDrop4.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop4.m_itemData.m_shared.m_maxDurability = 400f;
				itemDrop4.m_itemData.m_shared.m_durabilityPerLevel = 50f;
				itemDrop4.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop4.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop4.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop4.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop4.m_itemData.m_shared.m_destroyBroken = false;
				itemDrop4.m_itemData.m_shared.m_armor = 5f;
				itemDrop4.m_itemData.m_shared.m_setName = "Leather Gear";
				itemDrop4.m_itemData.m_shared.m_setSize = 2;
				ItemManager.Instance.AddItem(customItem4);
				CustomRecipe customRecipe4 = new CustomRecipe(new RecipeConfig
				{
					Item = "CapeDeerHid",
					CraftingStation = "piece_workbench",
					RepairStation = "piece_workbench",
					MinStationLevel = 2,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "DeerHide",
							Amount = 6,
							AmountPerLevel = 3
						},
						new RequirementConfig
						{
							Item = "CapeRag",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe4);
				CustomItem customItem5 = new CustomItem("BeltLeather", "BeltStrength");
				ItemDrop itemDrop5 = customItem5.ItemDrop;
				itemDrop5.m_itemData.m_shared.m_name = "Leather Belt";
				itemDrop5.m_itemData.m_shared.m_description = string.Concat(new string[]
				{
					"This item can be reforged into the following;",
					Environment.NewLine,
					"- Bone Belt",
					Environment.NewLine,
					"> Workbench",
					Environment.NewLine,
					"or",
					Environment.NewLine,
					" - Trollskin Belt",
					Environment.NewLine,
					" > Forge"
				});
				itemDrop5.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop5.m_itemData.m_shared.m_maxDurability = 400f;
				itemDrop5.m_itemData.m_shared.m_durabilityPerLevel = 50f;
				itemDrop5.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop5.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop5.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop5.m_itemData.m_shared.m_canBeReparied = false;
				itemDrop5.m_itemData.m_shared.m_destroyBroken = true;
				itemDrop5.m_itemData.m_shared.m_armor = 5f;
				itemDrop5.m_itemData.m_shared.m_setName = "Leather Gear";
				itemDrop5.m_itemData.m_shared.m_setSize = 2;
				ItemManager.Instance.AddItem(customItem5);
				CustomRecipe customRecipe5 = new CustomRecipe(new RecipeConfig
				{
					Item = "BeltLeather",
					CraftingStation = "piece_workbench",
					RepairStation = "piece_workbench",
					MinStationLevel = 2,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "DeerHide",
							Amount = 6,
							AmountPerLevel = 3
						},
						new RequirementConfig
						{
							Item = "BeltRag",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe5);
			}
			catch (Exception ex)
			{
				Logger.LogError("Error while adding Leather items: " + ex.Message);
			}
			finally
			{
				ItemManager.OnVanillaItemsAvailable -= this.AddLeatherItems;
			}
		}

		// Token: 0x06000005 RID: 5 RVA: 0x0000379C File Offset: 0x0000199C
		private void AddBoneItems()
		{
			try
			{
				GameObject gameObject = this.assetBundle.LoadAsset<GameObject>("HelmetBone");
				ItemDrop component = gameObject.GetComponent<ItemDrop>();
				component.m_itemData.m_shared.m_name = "Bone Helmet";
				component.m_itemData.m_shared.m_description = "This item cannot be repaired and will break eventually.";
				component.m_itemData.m_shared.m_armorPerLevel = 2f;
				component.m_itemData.m_shared.m_maxDurability = 450f;
				component.m_itemData.m_shared.m_durabilityPerLevel = 75f;
				component.m_itemData.m_shared.m_movementModifier = 0f;
				component.m_itemData.m_shared.m_setStatusEffect = null;
				component.m_itemData.m_shared.m_equipStatusEffect = null;
				component.m_itemData.m_shared.m_canBeReparied = false;
				component.m_itemData.m_shared.m_destroyBroken = true;
				component.m_itemData.m_shared.m_armor = 5f;
				component.m_itemData.m_shared.m_setName = "Bone Armor";
				component.m_itemData.m_shared.m_setSize = 3;
				CustomItem customItem = new CustomItem(gameObject, false, new ItemConfig
				{
					CraftingStation = "piece_workbench",
					RepairStation = "piece_workbench",
					MinStationLevel = 2,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "BoneFragments",
							Amount = 6,
							AmountPerLevel = 3
						},
						new RequirementConfig
						{
							Item = "HelmetLeathe",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddItem(customItem);
				GameObject gameObject2 = this.assetBundle.LoadAsset<GameObject>("ArmorBoneChest");
				ItemDrop component2 = gameObject2.GetComponent<ItemDrop>();
				component2.m_itemData.m_shared.m_name = "Bone Chestplate";
				component2.m_itemData.m_shared.m_description = "This item cannot be repaired and will break eventually.";
				component2.m_itemData.m_shared.m_armorPerLevel = 2f;
				component2.m_itemData.m_shared.m_maxDurability = 500f;
				component2.m_itemData.m_shared.m_durabilityPerLevel = 200f;
				component2.m_itemData.m_shared.m_movementModifier = 0f;
				component2.m_itemData.m_shared.m_setStatusEffect = null;
				component2.m_itemData.m_shared.m_equipStatusEffect = null;
				component2.m_itemData.m_shared.m_canBeReparied = false;
				component2.m_itemData.m_shared.m_destroyBroken = true;
				component2.m_itemData.m_shared.m_armor = 5f;
				component2.m_itemData.m_shared.m_setName = "Bone Armor";
				component2.m_itemData.m_shared.m_setSize = 3;
				CustomItem customItem2 = new CustomItem(gameObject2, false, new ItemConfig
				{
					CraftingStation = "piece_workbench",
					RepairStation = "piece_workbench",
					MinStationLevel = 2,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "BoneFragments",
							Amount = 6,
							AmountPerLevel = 3
						},
						new RequirementConfig
						{
							Item = "ArmorLeatherChes",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddItem(customItem2);
				GameObject gameObject3 = this.assetBundle.LoadAsset<GameObject>("ArmorBoneLegs");
				ItemDrop component3 = gameObject3.GetComponent<ItemDrop>();
				component3.m_itemData.m_shared.m_name = "Bone Greaves";
				component3.m_itemData.m_shared.m_description = "This item cannot be repaired and will break eventually.";
				component3.m_itemData.m_shared.m_armorPerLevel = 2f;
				component3.m_itemData.m_shared.m_maxDurability = 500f;
				component3.m_itemData.m_shared.m_durabilityPerLevel = 200f;
				component3.m_itemData.m_shared.m_movementModifier = 0f;
				component3.m_itemData.m_shared.m_setStatusEffect = null;
				component3.m_itemData.m_shared.m_equipStatusEffect = null;
				component3.m_itemData.m_shared.m_canBeReparied = false;
				component3.m_itemData.m_shared.m_destroyBroken = true;
				component3.m_itemData.m_shared.m_armor = 5f;
				component3.m_itemData.m_shared.m_setName = "Bone Armor";
				component3.m_itemData.m_shared.m_setSize = 3;
				CustomItem customItem3 = new CustomItem(gameObject3, false, new ItemConfig
				{
					CraftingStation = "piece_workbench",
					RepairStation = "piece_workbench",
					MinStationLevel = 2,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "BoneFragments",
							Amount = 6,
							AmountPerLevel = 3
						},
						new RequirementConfig
						{
							Item = "ArmorLeatherLeg",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddItem(customItem3);
				GameObject gameObject4 = this.assetBundle.LoadAsset<GameObject>("CapeBone");
				ItemDrop component4 = gameObject4.GetComponent<ItemDrop>();
				component4.m_itemData.m_shared.m_name = "Bone Cape";
				component4.m_itemData.m_shared.m_description = "This item cannot be repaired and will break eventually.";
				component4.m_itemData.m_shared.m_armorPerLevel = 2f;
				component4.m_itemData.m_shared.m_maxDurability = 500f;
				component4.m_itemData.m_shared.m_durabilityPerLevel = 200f;
				component4.m_itemData.m_shared.m_movementModifier = 0f;
				component4.m_itemData.m_shared.m_setStatusEffect = null;
				component4.m_itemData.m_shared.m_equipStatusEffect = null;
				component4.m_itemData.m_shared.m_canBeReparied = false;
				component4.m_itemData.m_shared.m_destroyBroken = true;
				component4.m_itemData.m_shared.m_armor = 5f;
				component4.m_itemData.m_shared.m_setName = "Bone Gear";
				component4.m_itemData.m_shared.m_setSize = 2;
				CustomItem customItem4 = new CustomItem(gameObject4, false, new ItemConfig
				{
					CraftingStation = "piece_workbench",
					RepairStation = "piece_workbench",
					MinStationLevel = 2,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "BoneFragments",
							Amount = 6,
							AmountPerLevel = 3
						},
						new RequirementConfig
						{
							Item = "CapeDeerHid",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddItem(customItem4);
				GameObject gameObject5 = this.assetBundle.LoadAsset<GameObject>("BeltBone");
				ItemDrop component5 = gameObject5.GetComponent<ItemDrop>();
				component5.m_itemData.m_shared.m_name = "Bone Belt";
				component5.m_itemData.m_shared.m_description = "This item cannot be repaired and will break eventually.";
				component5.m_itemData.m_shared.m_armorPerLevel = 2f;
				component5.m_itemData.m_shared.m_maxDurability = 500f;
				component5.m_itemData.m_shared.m_durabilityPerLevel = 200f;
				component5.m_itemData.m_shared.m_movementModifier = 0f;
				component5.m_itemData.m_shared.m_setStatusEffect = null;
				component5.m_itemData.m_shared.m_equipStatusEffect = null;
				component5.m_itemData.m_shared.m_canBeReparied = false;
				component5.m_itemData.m_shared.m_destroyBroken = true;
				component5.m_itemData.m_shared.m_armor = 5f;
				component5.m_itemData.m_shared.m_setName = "Bone Gear";
				component5.m_itemData.m_shared.m_setSize = 2;
				CustomItem customItem5 = new CustomItem(gameObject5, false, new ItemConfig
				{
					CraftingStation = "piece_workbench",
					RepairStation = "piece_workbench",
					MinStationLevel = 2,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "BoneFragments",
							Amount = 6,
							AmountPerLevel = 3
						},
						new RequirementConfig
						{
							Item = "BeltLeather",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddItem(customItem5);
			}
			catch (Exception ex)
			{
				Logger.LogError("Error while adding Bone items: " + ex.Message);
			}
			finally
			{
				ItemManager.OnVanillaItemsAvailable -= this.AddBoneItems;
			}
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000040E4 File Offset: 0x000022E4
		private void AddTrollItems()
		{
			try
			{
				GameObject gameObject = GameObject.Find("HelmetTrollLeather");
				CustomItem customItem = new CustomItem("HelmetTrollLeathe", "HelmetTrollLeather");
				ItemDrop itemDrop = customItem.ItemDrop;
				itemDrop.m_itemData.m_shared.m_name = "Trollskin Hood";
				itemDrop.m_itemData.m_shared.m_description = string.Concat(new string[]
				{
					"This item can be reforged into the following;",
					Environment.NewLine,
					" - Bronze Helmet",
					Environment.NewLine,
					" > Forge"
				});
				itemDrop.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop.m_itemData.m_shared.m_maxDurability = 500f;
				itemDrop.m_itemData.m_shared.m_durabilityPerLevel = 200f;
				itemDrop.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop.m_itemData.m_shared.m_destroyBroken = false;
				itemDrop.m_itemData.m_shared.m_armor = 6f;
				itemDrop.m_itemData.m_shared.m_setName = "Trollskin Armor";
				itemDrop.m_itemData.m_shared.m_setSize = 3;
				ItemManager.Instance.AddItem(customItem);
				CustomRecipe customRecipe = new CustomRecipe(new RecipeConfig
				{
					Item = "HelmetTrollLeathe",
					CraftingStation = "piece_workbench",
					RepairStation = "piece_workbench",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "TrollHide",
							Amount = 6,
							AmountPerLevel = 3
						},
						new RequirementConfig
						{
							Item = "HelmetLeathe",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe);
				gameObject = GameObject.Find("ArmorTrollLeatherChest");
				CustomItem customItem2 = new CustomItem("ArmorTrollLeatherChes", "ArmorTrollLeatherChest");
				ItemDrop itemDrop2 = customItem2.ItemDrop;
				itemDrop2.m_itemData.m_shared.m_name = "Trollskin Tunic";
				itemDrop2.m_itemData.m_shared.m_description = string.Concat(new string[]
				{
					"This item can be reforged into the following;",
					Environment.NewLine,
					" - Bronze Cuirass",
					Environment.NewLine,
					" > Forge"
				});
				itemDrop2.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop2.m_itemData.m_shared.m_maxDurability = 500f;
				itemDrop2.m_itemData.m_shared.m_durabilityPerLevel = 200f;
				itemDrop2.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop2.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop2.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop2.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop2.m_itemData.m_shared.m_destroyBroken = false;
				itemDrop2.m_itemData.m_shared.m_armor = 6f;
				itemDrop2.m_itemData.m_shared.m_setName = "Trollskin Armor";
				itemDrop2.m_itemData.m_shared.m_setSize = 3;
				ItemManager.Instance.AddItem(customItem2);
				CustomRecipe customRecipe2 = new CustomRecipe(new RecipeConfig
				{
					Item = "ArmorTrollLeatherChes",
					CraftingStation = "piece_workbench",
					RepairStation = "piece_workbench",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "TrollHide",
							Amount = 6,
							AmountPerLevel = 3
						},
						new RequirementConfig
						{
							Item = "ArmorLeatherChes",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe2);
				gameObject = GameObject.Find("ArmorTrollLeatherLegs");
				CustomItem customItem3 = new CustomItem("ArmorTrollLeatherLeg", "ArmorTrollLeatherLegs");
				ItemDrop itemDrop3 = customItem3.ItemDrop;
				itemDrop3.m_itemData.m_shared.m_name = "Trollskin Pants";
				itemDrop3.m_itemData.m_shared.m_description = string.Concat(new string[]
				{
					"This item can be reforged into the following;",
					Environment.NewLine,
					" - Bronze Greaves",
					Environment.NewLine,
					" > Forge"
				});
				itemDrop3.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop3.m_itemData.m_shared.m_maxDurability = 500f;
				itemDrop3.m_itemData.m_shared.m_durabilityPerLevel = 200f;
				itemDrop3.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop3.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop3.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop3.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop3.m_itemData.m_shared.m_destroyBroken = false;
				itemDrop3.m_itemData.m_shared.m_armor = 6f;
				itemDrop3.m_itemData.m_shared.m_setName = "Trollskin Armor";
				itemDrop3.m_itemData.m_shared.m_setSize = 3;
				ItemManager.Instance.AddItem(customItem3);
				CustomRecipe customRecipe3 = new CustomRecipe(new RecipeConfig
				{
					Item = "ArmorTrollLeatherLeg",
					CraftingStation = "piece_workbench",
					RepairStation = "piece_workbench",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "TrollHide",
							Amount = 6,
							AmountPerLevel = 3
						},
						new RequirementConfig
						{
							Item = "ArmorLeatherLeg",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe3);
				gameObject = GameObject.Find("CapeTrollHide");
				CustomItem customItem4 = new CustomItem("CapeTrollHid", "CapeTrollHide");
				ItemDrop itemDrop4 = customItem4.ItemDrop;
				itemDrop4.m_itemData.m_shared.m_name = "Trollskin Cape";
				itemDrop4.m_itemData.m_shared.m_description = string.Concat(new string[]
				{
					"This item can be reforged into the following;",
					Environment.NewLine,
					" - Bronze Cape",
					Environment.NewLine,
					" > Forge"
				});
				itemDrop4.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop4.m_itemData.m_shared.m_maxDurability = 500f;
				itemDrop4.m_itemData.m_shared.m_durabilityPerLevel = 200f;
				itemDrop4.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop4.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop4.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop4.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop4.m_itemData.m_shared.m_destroyBroken = false;
				itemDrop4.m_itemData.m_shared.m_armor = 6f;
				itemDrop4.m_itemData.m_shared.m_setName = "Trollskin Gear";
				itemDrop4.m_itemData.m_shared.m_setSize = 2;
				ItemManager.Instance.AddItem(customItem4);
				CustomRecipe customRecipe4 = new CustomRecipe(new RecipeConfig
				{
					Item = "CapeTrollHid",
					CraftingStation = "piece_workbench",
					RepairStation = "piece_workbench",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "TrollHide",
							Amount = 6,
							AmountPerLevel = 3
						},
						new RequirementConfig
						{
							Item = "CapeDeerHid",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe4);
				CustomItem customItem5 = new CustomItem("BeltTrollHide", "BeltStrength");
				ItemDrop itemDrop5 = customItem5.ItemDrop;
				itemDrop5.m_itemData.m_shared.m_name = "Trollskin Belt";
				itemDrop5.m_itemData.m_shared.m_description = string.Concat(new string[]
				{
					"This item can be reforged into the following;",
					Environment.NewLine,
					" - Bronze Belt",
					Environment.NewLine,
					" > Forge"
				});
				itemDrop5.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop5.m_itemData.m_shared.m_maxDurability = 500f;
				itemDrop5.m_itemData.m_shared.m_durabilityPerLevel = 200f;
				itemDrop5.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop5.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop5.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop5.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop5.m_itemData.m_shared.m_destroyBroken = false;
				itemDrop5.m_itemData.m_shared.m_armor = 6f;
				itemDrop5.m_itemData.m_shared.m_setName = "Trollskin Gear";
				itemDrop5.m_itemData.m_shared.m_setSize = 2;
				ItemManager.Instance.AddItem(customItem5);
				CustomRecipe customRecipe5 = new CustomRecipe(new RecipeConfig
				{
					Item = "BeltTrollHide",
					CraftingStation = "piece_workbench",
					RepairStation = "piece_workbench",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "TrollHide",
							Amount = 6,
							AmountPerLevel = 3
						},
						new RequirementConfig
						{
							Item = "BeltLeather",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe5);
			}
			catch (Exception ex)
			{
				Logger.LogError("Error while adding Troll items: " + ex.Message);
			}
			finally
			{
				ItemManager.OnVanillaItemsAvailable -= this.AddTrollItems;
			}
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00004BB0 File Offset: 0x00002DB0
		private void AddBronzeItems()
		{
			try
			{
				GameObject gameObject = GameObject.Find("HelmetBronze");
				CustomItem customItem = new CustomItem("HelmetBronz", "HelmetBronze");
				ItemDrop itemDrop = customItem.ItemDrop;
				itemDrop.m_itemData.m_shared.m_name = "Bronze Helmet";
				itemDrop.m_itemData.m_shared.m_description = string.Concat(new string[]
				{
					"This item can be reforged into the following;",
					Environment.NewLine,
					"- Ancient Helmet",
					Environment.NewLine,
					"> Workbench",
					Environment.NewLine,
					"or",
					Environment.NewLine,
					" - Iron Helmet",
					Environment.NewLine,
					" > Forge"
				});
				itemDrop.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop.m_itemData.m_shared.m_maxDurability = 1000f;
				itemDrop.m_itemData.m_shared.m_durabilityPerLevel = 200f;
				itemDrop.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop.m_itemData.m_shared.m_destroyBroken = false;
				itemDrop.m_itemData.m_shared.m_armor = 8f;
				itemDrop.m_itemData.m_shared.m_setName = "Bronze Armor";
				itemDrop.m_itemData.m_shared.m_setSize = 3;
				ItemManager.Instance.AddItem(customItem);
				CustomRecipe customRecipe = new CustomRecipe(new RecipeConfig
				{
					Item = "HelmetBronz",
					CraftingStation = "forge",
					RepairStation = "forge",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "Bronze",
							Amount = 5,
							AmountPerLevel = 3
						},
						new RequirementConfig
						{
							Item = "DeerHide",
							Amount = 2,
							AmountPerLevel = 0
						},
						new RequirementConfig
						{
							Item = "HelmetTrollLeathe",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe);
				gameObject = GameObject.Find("ArmorBronzeChest");
				CustomItem customItem2 = new CustomItem("ArmorBronzeChes", "ArmorBronzeChest");
				ItemDrop itemDrop2 = customItem2.ItemDrop;
				itemDrop2.m_itemData.m_shared.m_name = "Bronze Cuirass";
				itemDrop2.m_itemData.m_shared.m_description = string.Concat(new string[]
				{
					"This item can be reforged into the following;",
					Environment.NewLine,
					"- Ancient Chestplate",
					Environment.NewLine,
					"> Workbench",
					Environment.NewLine,
					"or",
					Environment.NewLine,
					" - Iron Cuirass",
					Environment.NewLine,
					" > Forge"
				});
				itemDrop2.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop2.m_itemData.m_shared.m_maxDurability = 1000f;
				itemDrop2.m_itemData.m_shared.m_durabilityPerLevel = 200f;
				itemDrop2.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop2.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop2.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop2.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop2.m_itemData.m_shared.m_destroyBroken = false;
				itemDrop2.m_itemData.m_shared.m_armor = 8f;
				itemDrop2.m_itemData.m_shared.m_setName = "Bronze Armor";
				itemDrop2.m_itemData.m_shared.m_setSize = 3;
				ItemManager.Instance.AddItem(customItem2);
				CustomRecipe customRecipe2 = new CustomRecipe(new RecipeConfig
				{
					Item = "ArmorBronzeChes",
					CraftingStation = "forge",
					RepairStation = "forge",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "Bronze",
							Amount = 5,
							AmountPerLevel = 3
						},
						new RequirementConfig
						{
							Item = "DeerHide",
							Amount = 2,
							AmountPerLevel = 0
						},
						new RequirementConfig
						{
							Item = "ArmorTrollLeatherChes",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe2);
				gameObject = GameObject.Find("ArmorBronzeLegs");
				CustomItem customItem3 = new CustomItem("ArmorBronzeLeg", "ArmorBronzeLegs");
				ItemDrop itemDrop3 = customItem3.ItemDrop;
				itemDrop3.m_itemData.m_shared.m_name = "Bronze Greaves";
				itemDrop3.m_itemData.m_shared.m_description = string.Concat(new string[]
				{
					"This item can be reforged into the following;",
					Environment.NewLine,
					"- Ancient Greaves",
					Environment.NewLine,
					"> Workbench",
					Environment.NewLine,
					"or",
					Environment.NewLine,
					" - Iron Greaves",
					Environment.NewLine,
					" > Forge"
				});
				itemDrop3.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop3.m_itemData.m_shared.m_maxDurability = 1000f;
				itemDrop3.m_itemData.m_shared.m_durabilityPerLevel = 200f;
				itemDrop3.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop3.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop3.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop3.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop3.m_itemData.m_shared.m_destroyBroken = false;
				itemDrop3.m_itemData.m_shared.m_armor = 8f;
				itemDrop3.m_itemData.m_shared.m_setName = "Bronze Armor";
				itemDrop3.m_itemData.m_shared.m_setSize = 3;
				ItemManager.Instance.AddItem(customItem3);
				CustomRecipe customRecipe3 = new CustomRecipe(new RecipeConfig
				{
					Item = "ArmorBronzeLeg",
					CraftingStation = "forge",
					RepairStation = "forge",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "Bronze",
							Amount = 5,
							AmountPerLevel = 3
						},
						new RequirementConfig
						{
							Item = "DeerHide",
							Amount = 2,
							AmountPerLevel = 0
						},
						new RequirementConfig
						{
							Item = "ArmorTrollLeatherLeg",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe3);
				CustomItem customItem4 = new CustomItem("CapeBronze", "CapeDeerHide");
				ItemDrop itemDrop4 = customItem4.ItemDrop;
				itemDrop4.m_itemData.m_shared.m_name = "Bronze Cape";
				itemDrop4.m_itemData.m_shared.m_description = string.Concat(new string[]
				{
					"This item can be reforged into the following;",
					Environment.NewLine,
					"- Ancient Cape",
					Environment.NewLine,
					"> Workbench",
					Environment.NewLine,
					"or",
					Environment.NewLine,
					" - Iron Cape",
					Environment.NewLine,
					" > Forge"
				});
				itemDrop4.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop4.m_itemData.m_shared.m_maxDurability = 1000f;
				itemDrop4.m_itemData.m_shared.m_durabilityPerLevel = 200f;
				itemDrop4.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop4.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop4.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop4.m_itemData.m_shared.m_canBeReparied = false;
				itemDrop4.m_itemData.m_shared.m_destroyBroken = true;
				itemDrop4.m_itemData.m_shared.m_armor = 8f;
				itemDrop4.m_itemData.m_shared.m_setName = "Bronze Gear";
				itemDrop4.m_itemData.m_shared.m_setSize = 2;
				ItemManager.Instance.AddItem(customItem4);
				CustomRecipe customRecipe4 = new CustomRecipe(new RecipeConfig
				{
					Item = "CapeBronze",
					CraftingStation = "forge",
					RepairStation = "forge",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "Bronze",
							Amount = 5,
							AmountPerLevel = 3
						},
						new RequirementConfig
						{
							Item = "DeerHide",
							Amount = 2,
							AmountPerLevel = 0
						},
						new RequirementConfig
						{
							Item = "CapeTrollHid",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe4);
				CustomItem customItem5 = new CustomItem("BeltBronze", "BeltStrength");
				ItemDrop itemDrop5 = customItem5.ItemDrop;
				itemDrop5.m_itemData.m_shared.m_name = "Bronze Belt";
				itemDrop5.m_itemData.m_shared.m_description = string.Concat(new string[]
				{
					"This item can be reforged into the following;",
					Environment.NewLine,
					"- Ancient Belt",
					Environment.NewLine,
					"> Workbench",
					Environment.NewLine,
					"or",
					Environment.NewLine,
					" - Iron Belt",
					Environment.NewLine,
					" > Forge"
				});
				itemDrop5.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop5.m_itemData.m_shared.m_maxDurability = 1000f;
				itemDrop5.m_itemData.m_shared.m_durabilityPerLevel = 200f;
				itemDrop5.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop5.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop5.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop5.m_itemData.m_shared.m_canBeReparied = false;
				itemDrop5.m_itemData.m_shared.m_destroyBroken = true;
				itemDrop5.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop5.m_itemData.m_shared.m_armor = 8f;
				itemDrop5.m_itemData.m_shared.m_setName = "Bronze Gear";
				itemDrop5.m_itemData.m_shared.m_setSize = 2;
				ItemManager.Instance.AddItem(customItem5);
				CustomRecipe customRecipe5 = new CustomRecipe(new RecipeConfig
				{
					Item = "BeltBronze",
					CraftingStation = "forge",
					RepairStation = "forge",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "Bronze",
							Amount = 5,
							AmountPerLevel = 3
						},
						new RequirementConfig
						{
							Item = "DeerHide",
							Amount = 2,
							AmountPerLevel = 0
						},
						new RequirementConfig
						{
							Item = "BeltTrollHide",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe5);
			}
			catch (Exception ex)
			{
				Logger.LogError("Error while adding Bronze items: " + ex.Message);
			}
			finally
			{
				ItemManager.OnVanillaItemsAvailable -= this.AddBronzeItems;
			}
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00005834 File Offset: 0x00003A34
		private void AddAncientItems()
		{
			try
			{
				CustomItem customItem = new CustomItem("HelmetAncient", "HelmetBronze");
				ItemDrop itemDrop = customItem.ItemDrop;
				itemDrop.m_itemData.m_shared.m_name = "Ancient Helmet";
				itemDrop.m_itemData.m_shared.m_description = "This item cannot be repaired and will break eventually.";
				itemDrop.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop.m_itemData.m_shared.m_maxDurability = 1000f;
				itemDrop.m_itemData.m_shared.m_durabilityPerLevel = 200f;
				itemDrop.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop.m_itemData.m_shared.m_canBeReparied = false;
				itemDrop.m_itemData.m_shared.m_destroyBroken = true;
				itemDrop.m_itemData.m_shared.m_armor = 10f;
				itemDrop.m_itemData.m_shared.m_setName = "Ancient Bark Armor";
				itemDrop.m_itemData.m_shared.m_setSize = 3;
				ItemManager.Instance.AddItem(customItem);
				CustomRecipe customRecipe = new CustomRecipe(new RecipeConfig
				{
					Item = "HelmetAncient",
					CraftingStation = "piece_workbench",
					MinStationLevel = 2,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "Bronze",
							Amount = 5,
							AmountPerLevel = 3
						},
						new RequirementConfig
						{
							Item = "ElderBark",
							Amount = 2,
							AmountPerLevel = 2
						},
						new RequirementConfig
						{
							Item = "HelmetBronz",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe);
				CustomItem customItem2 = new CustomItem("ArmorAncientChest", "ArmorBronzeChest");
				ItemDrop itemDrop2 = customItem2.ItemDrop;
				itemDrop2.m_itemData.m_shared.m_name = "Ancient Chestplate";
				itemDrop2.m_itemData.m_shared.m_description = "This item cannot be repaired and will break eventually.";
				itemDrop2.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop2.m_itemData.m_shared.m_maxDurability = 1000f;
				itemDrop2.m_itemData.m_shared.m_durabilityPerLevel = 200f;
				itemDrop2.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop2.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop2.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop2.m_itemData.m_shared.m_canBeReparied = false;
				itemDrop2.m_itemData.m_shared.m_destroyBroken = true;
				itemDrop2.m_itemData.m_shared.m_armor = 10f;
				itemDrop2.m_itemData.m_shared.m_setName = "Ancient Bark Armor";
				itemDrop2.m_itemData.m_shared.m_setSize = 3;
				ItemManager.Instance.AddItem(customItem2);
				CustomRecipe customRecipe2 = new CustomRecipe(new RecipeConfig
				{
					Item = "ArmorAncientChest",
					CraftingStation = "piece_workbench",
					MinStationLevel = 2,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "Bronze",
							Amount = 5,
							AmountPerLevel = 3
						},
						new RequirementConfig
						{
							Item = "ElderBark",
							Amount = 2,
							AmountPerLevel = 2
						},
						new RequirementConfig
						{
							Item = "ArmorBronzeChes",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe2);
				CustomItem customItem3 = new CustomItem("ArmorAncientLegs", "ArmorBronzeLegs");
				ItemDrop itemDrop3 = customItem3.ItemDrop;
				itemDrop3.m_itemData.m_shared.m_name = "Ancient Greaves";
				itemDrop3.m_itemData.m_shared.m_description = "This item cannot be repaired and will break eventually.";
				itemDrop3.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop3.m_itemData.m_shared.m_maxDurability = 1000f;
				itemDrop3.m_itemData.m_shared.m_durabilityPerLevel = 200f;
				itemDrop3.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop3.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop3.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop3.m_itemData.m_shared.m_canBeReparied = false;
				itemDrop3.m_itemData.m_shared.m_destroyBroken = true;
				itemDrop3.m_itemData.m_shared.m_armor = 10f;
				itemDrop3.m_itemData.m_shared.m_setName = "Ancient Bark Armor";
				itemDrop3.m_itemData.m_shared.m_setSize = 3;
				ItemManager.Instance.AddItem(customItem3);
				CustomRecipe customRecipe3 = new CustomRecipe(new RecipeConfig
				{
					Item = "ArmorAncientLegs",
					CraftingStation = "piece_workbench",
					MinStationLevel = 2,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "Bronze",
							Amount = 5,
							AmountPerLevel = 3
						},
						new RequirementConfig
						{
							Item = "ElderBark",
							Amount = 2,
							AmountPerLevel = 2
						},
						new RequirementConfig
						{
							Item = "ArmorBronzeLeg",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe3);
				CustomItem customItem4 = new CustomItem("CapeAncient", "CapeTrollHide");
				ItemDrop itemDrop4 = customItem4.ItemDrop;
				itemDrop4.m_itemData.m_shared.m_name = "Ancient Cape";
				itemDrop4.m_itemData.m_shared.m_description = "This item cannot be repaired and will break eventually.";
				itemDrop4.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop4.m_itemData.m_shared.m_maxDurability = 1000f;
				itemDrop4.m_itemData.m_shared.m_durabilityPerLevel = 200f;
				itemDrop4.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop4.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop4.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop4.m_itemData.m_shared.m_canBeReparied = false;
				itemDrop4.m_itemData.m_shared.m_destroyBroken = true;
				itemDrop4.m_itemData.m_shared.m_armor = 10f;
				itemDrop4.m_itemData.m_shared.m_setName = "Ancient Bark Gear";
				itemDrop4.m_itemData.m_shared.m_setSize = 2;
				itemDrop4.m_itemData.m_shared.m_setStatusEffect = null;
				ItemManager.Instance.AddItem(customItem4);
				CustomRecipe customRecipe4 = new CustomRecipe(new RecipeConfig
				{
					Item = "CapeAncient",
					CraftingStation = "piece_workbench",
					MinStationLevel = 2,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "Bronze",
							Amount = 5,
							AmountPerLevel = 3
						},
						new RequirementConfig
						{
							Item = "ElderBark",
							Amount = 2,
							AmountPerLevel = 2
						},
						new RequirementConfig
						{
							Item = "CapeBronze",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe4);
				CustomItem customItem5 = new CustomItem("BeltAncient", "BeltStrength");
				ItemDrop itemDrop5 = customItem5.ItemDrop;
				itemDrop5.m_itemData.m_shared.m_name = "Ancient Belt";
				itemDrop5.m_itemData.m_shared.m_description = "This item cannot be repaired and will break eventually.";
				itemDrop5.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop5.m_itemData.m_shared.m_maxDurability = 1000f;
				itemDrop5.m_itemData.m_shared.m_durabilityPerLevel = 200f;
				itemDrop5.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop5.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop5.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop5.m_itemData.m_shared.m_canBeReparied = false;
				itemDrop5.m_itemData.m_shared.m_destroyBroken = true;
				itemDrop5.m_itemData.m_shared.m_armor = 10f;
				itemDrop5.m_itemData.m_shared.m_setName = "Ancient Bark Gear";
				itemDrop5.m_itemData.m_shared.m_setSize = 2;
				ItemManager.Instance.AddItem(customItem5);
				CustomRecipe customRecipe5 = new CustomRecipe(new RecipeConfig
				{
					Item = "BeltAncient",
					CraftingStation = "piece_workbench",
					MinStationLevel = 2,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "Bronze",
							Amount = 5,
							AmountPerLevel = 3
						},
						new RequirementConfig
						{
							Item = "ElderBark",
							Amount = 2,
							AmountPerLevel = 2
						},
						new RequirementConfig
						{
							Item = "BeltBronze",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe5);
			}
			catch (Exception ex)
			{
				Logger.LogError("Error while adding Ancient items: " + ex.Message);
			}
			finally
			{
				ItemManager.OnVanillaItemsAvailable -= this.AddAncientItems;
			}
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00006270 File Offset: 0x00004470
		private void AddIronItems()
		{
			try
			{
				GameObject gameObject = GameObject.Find("HelmetIron");
				CustomItem customItem = new CustomItem("HelmetIro", "HelmetIron");
				ItemDrop itemDrop = customItem.ItemDrop;
				itemDrop.m_itemData.m_shared.m_name = "Iron Helmet";
				itemDrop.m_itemData.m_shared.m_description = string.Concat(new string[]
				{
					"This item can be reforged into the following;",
					Environment.NewLine,
					"- Abyssal Helmet",
					Environment.NewLine,
					"> Workbench",
					Environment.NewLine,
					"or",
					Environment.NewLine,
					" - Silver Helmet",
					Environment.NewLine,
					" > Forge"
				});
				itemDrop.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop.m_itemData.m_shared.m_maxDurability = 1200f;
				itemDrop.m_itemData.m_shared.m_durabilityPerLevel = 200f;
				itemDrop.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop.m_itemData.m_shared.m_destroyBroken = false;
				itemDrop.m_itemData.m_shared.m_armor = 14f;
				itemDrop.m_itemData.m_shared.m_setName = "Iron Armor";
				itemDrop.m_itemData.m_shared.m_setSize = 3;
				ItemManager.Instance.AddItem(customItem);
				CustomRecipe customRecipe = new CustomRecipe(new RecipeConfig
				{
					Item = "HelmetIro",
					CraftingStation = "forge",
					RepairStation = "forge",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "Iron",
							Amount = 20,
							AmountPerLevel = 5
						},
						new RequirementConfig
						{
							Item = "DeerHide",
							Amount = 2,
							AmountPerLevel = 0
						},
						new RequirementConfig
						{
							Item = "HelmetBronz",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe);
				gameObject = GameObject.Find("ArmorIronChest");
				CustomItem customItem2 = new CustomItem("ArmorIronChes", "ArmorIronChest");
				ItemDrop itemDrop2 = customItem2.ItemDrop;
				itemDrop2.m_itemData.m_shared.m_name = "Iron Plate Cuirass";
				itemDrop2.m_itemData.m_shared.m_description = string.Concat(new string[]
				{
					"This item can be reforged into the following;",
					Environment.NewLine,
					"- Abyssal Chestplate",
					Environment.NewLine,
					"> Workbench",
					Environment.NewLine,
					"or",
					Environment.NewLine,
					" - Silver Cuirass",
					Environment.NewLine,
					" > Forge"
				});
				itemDrop2.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop2.m_itemData.m_shared.m_maxDurability = 1200f;
				itemDrop2.m_itemData.m_shared.m_durabilityPerLevel = 200f;
				itemDrop2.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop2.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop2.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop2.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop2.m_itemData.m_shared.m_destroyBroken = false;
				itemDrop2.m_itemData.m_shared.m_armor = 14f;
				itemDrop2.m_itemData.m_shared.m_setName = "Iron Armor";
				itemDrop2.m_itemData.m_shared.m_setSize = 3;
				ItemManager.Instance.AddItem(customItem2);
				CustomRecipe customRecipe2 = new CustomRecipe(new RecipeConfig
				{
					Item = "ArmorIronChes",
					CraftingStation = "forge",
					RepairStation = "forge",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "Iron",
							Amount = 20,
							AmountPerLevel = 5
						},
						new RequirementConfig
						{
							Item = "DeerHide",
							Amount = 2,
							AmountPerLevel = 0
						},
						new RequirementConfig
						{
							Item = "ArmorBronzeChes",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe2);
				gameObject = GameObject.Find("ArmorIronLegs");
				CustomItem customItem3 = new CustomItem("ArmorIronLeg", "ArmorIronLegs");
				ItemDrop itemDrop3 = customItem3.ItemDrop;
				itemDrop3.m_itemData.m_shared.m_name = "Iron Plate Greaves";
				itemDrop3.m_itemData.m_shared.m_description = string.Concat(new string[]
				{
					"This item can be reforged into the following;",
					Environment.NewLine,
					"- Abyssal Greaves",
					Environment.NewLine,
					"> Workbench",
					Environment.NewLine,
					"or",
					Environment.NewLine,
					" - Silver Greaves",
					Environment.NewLine,
					" > Forge"
				});
				itemDrop3.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop3.m_itemData.m_shared.m_maxDurability = 1200f;
				itemDrop3.m_itemData.m_shared.m_durabilityPerLevel = 200f;
				itemDrop3.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop3.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop3.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop3.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop3.m_itemData.m_shared.m_destroyBroken = false;
				itemDrop3.m_itemData.m_shared.m_armor = 14f;
				ItemManager.Instance.AddItem(customItem3);
				CustomRecipe customRecipe3 = new CustomRecipe(new RecipeConfig
				{
					Item = "ArmorIronLeg",
					CraftingStation = "forge",
					RepairStation = "forge",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "Iron",
							Amount = 20,
							AmountPerLevel = 5
						},
						new RequirementConfig
						{
							Item = "DeerHide",
							Amount = 2,
							AmountPerLevel = 0
						},
						new RequirementConfig
						{
							Item = "ArmorBronzeLeg",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe3);
				CustomItem customItem4 = new CustomItem("CapeIron", "CapeTrollHide");
				ItemDrop itemDrop4 = customItem4.ItemDrop;
				itemDrop4.m_itemData.m_shared.m_name = "Iron Cape";
				itemDrop4.m_itemData.m_shared.m_description = string.Concat(new string[]
				{
					"This item can be reforged into the following;",
					Environment.NewLine,
					"- Abyssal Cape",
					Environment.NewLine,
					"> Workbench",
					Environment.NewLine,
					"or",
					Environment.NewLine,
					" - Silver Cape",
					Environment.NewLine,
					" > Forge"
				});
				itemDrop4.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop4.m_itemData.m_shared.m_maxDurability = 1200f;
				itemDrop4.m_itemData.m_shared.m_durabilityPerLevel = 200f;
				itemDrop4.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop4.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop4.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop4.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop4.m_itemData.m_shared.m_destroyBroken = false;
				itemDrop4.m_itemData.m_shared.m_armor = 14f;
				itemDrop4.m_itemData.m_shared.m_setName = "Iron Gear";
				itemDrop4.m_itemData.m_shared.m_setSize = 2;
				ItemManager.Instance.AddItem(customItem4);
				CustomRecipe customRecipe4 = new CustomRecipe(new RecipeConfig
				{
					Item = "CapeIron",
					CraftingStation = "forge",
					RepairStation = "forge",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "Iron",
							Amount = 20,
							AmountPerLevel = 5
						},
						new RequirementConfig
						{
							Item = "DeerHide",
							Amount = 2,
							AmountPerLevel = 0
						},
						new RequirementConfig
						{
							Item = "CapeBronze",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe4);
				CustomItem customItem5 = new CustomItem("BeltIron", "BeltStrength");
				ItemDrop itemDrop5 = customItem5.ItemDrop;
				itemDrop5.m_itemData.m_shared.m_name = "Iron Belt";
				itemDrop5.m_itemData.m_shared.m_description = string.Concat(new string[]
				{
					"This item can be reforged into the following;",
					Environment.NewLine,
					"- Abyssal Belt",
					Environment.NewLine,
					"> Workbench",
					Environment.NewLine,
					"or",
					Environment.NewLine,
					" - Silver Belt",
					Environment.NewLine,
					" > Forge"
				});
				itemDrop5.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop5.m_itemData.m_shared.m_maxDurability = 1200f;
				itemDrop5.m_itemData.m_shared.m_durabilityPerLevel = 200f;
				itemDrop5.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop5.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop5.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop5.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop5.m_itemData.m_shared.m_destroyBroken = false;
				itemDrop5.m_itemData.m_shared.m_armor = 14f;
				itemDrop5.m_itemData.m_shared.m_setName = "Iron Gear";
				itemDrop5.m_itemData.m_shared.m_setSize = 2;
				ItemManager.Instance.AddItem(customItem5);
				CustomRecipe customRecipe5 = new CustomRecipe(new RecipeConfig
				{
					Item = "BeltIron",
					CraftingStation = "forge",
					RepairStation = "forge",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "Iron",
							Amount = 20,
							AmountPerLevel = 5
						},
						new RequirementConfig
						{
							Item = "DeerHide",
							Amount = 2,
							AmountPerLevel = 0
						},
						new RequirementConfig
						{
							Item = "BeltBronze",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe5);
			}
			catch (Exception ex)
			{
				Logger.LogError("Error while adding Iron items: " + ex.Message);
			}
			finally
			{
				ItemManager.OnVanillaItemsAvailable -= this.AddIronItems;
			}
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00006EC0 File Offset: 0x000050C0
		private void AddAbyssalItems()
		{
			try
			{
				CustomItem customItem = new CustomItem("HelmetAbyssal", "HelmetIron");
				ItemDrop itemDrop = customItem.ItemDrop;
				itemDrop.m_itemData.m_shared.m_name = "Abyssal Helmet";
				itemDrop.m_itemData.m_shared.m_description = "This item cannot be repaired and will break eventually.";
				itemDrop.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop.m_itemData.m_shared.m_maxDurability = 500f;
				itemDrop.m_itemData.m_shared.m_durabilityPerLevel = 200f;
				itemDrop.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop.m_itemData.m_shared.m_canBeReparied = false;
				itemDrop.m_itemData.m_shared.m_destroyBroken = true;
				itemDrop.m_itemData.m_shared.m_armor = 22f;
				itemDrop.m_itemData.m_shared.m_setName = "Abyssal Armor";
				itemDrop.m_itemData.m_shared.m_setSize = 3;
				ItemManager.Instance.AddItem(customItem);
				CustomRecipe customRecipe = new CustomRecipe(new RecipeConfig
				{
					Item = "HelmetAbyssal",
					CraftingStation = "piece_workbench",
					MinStationLevel = 2,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "Chitin",
							Amount = 20,
							AmountPerLevel = 5
						},
						new RequirementConfig
						{
							Item = "DeerHide",
							Amount = 2,
							AmountPerLevel = 0
						},
						new RequirementConfig
						{
							Item = "HelmetIro",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe);
				CustomItem customItem2 = new CustomItem("ArmorAbyssalChest", "ArmorIronChest");
				ItemDrop itemDrop2 = customItem2.ItemDrop;
				itemDrop2.m_itemData.m_shared.m_name = "Abyssal Chestplate";
				itemDrop2.m_itemData.m_shared.m_description = "This item cannot be repaired and will break eventually.";
				itemDrop2.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop2.m_itemData.m_shared.m_maxDurability = 500f;
				itemDrop2.m_itemData.m_shared.m_durabilityPerLevel = 200f;
				itemDrop2.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop2.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop2.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop2.m_itemData.m_shared.m_canBeReparied = false;
				itemDrop2.m_itemData.m_shared.m_destroyBroken = true;
				itemDrop2.m_itemData.m_shared.m_armor = 22f;
				itemDrop2.m_itemData.m_shared.m_setName = "Abyssal Armor";
				itemDrop2.m_itemData.m_shared.m_setSize = 3;
				ItemManager.Instance.AddItem(customItem2);
				CustomRecipe customRecipe2 = new CustomRecipe(new RecipeConfig
				{
					Item = "ArmorAbyssalChest",
					CraftingStation = "piece_workbench",
					MinStationLevel = 2,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "Chitin",
							Amount = 20,
							AmountPerLevel = 5
						},
						new RequirementConfig
						{
							Item = "DeerHide",
							Amount = 2,
							AmountPerLevel = 0
						},
						new RequirementConfig
						{
							Item = "ArmorIronChes",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe2);
				CustomItem customItem3 = new CustomItem("ArmorAbyssalLegs", "ArmorIronLegs");
				ItemDrop itemDrop3 = customItem3.ItemDrop;
				itemDrop3.m_itemData.m_shared.m_name = "Abyssal Greaves";
				itemDrop3.m_itemData.m_shared.m_description = "This item cannot be repaired and will break eventually.";
				itemDrop3.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop3.m_itemData.m_shared.m_maxDurability = 500f;
				itemDrop3.m_itemData.m_shared.m_durabilityPerLevel = 200f;
				itemDrop3.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop3.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop3.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop3.m_itemData.m_shared.m_canBeReparied = false;
				itemDrop3.m_itemData.m_shared.m_destroyBroken = true;
				itemDrop3.m_itemData.m_shared.m_armor = 22f;
				itemDrop3.m_itemData.m_shared.m_setName = "Abyssal Armor";
				itemDrop3.m_itemData.m_shared.m_setSize = 3;
				ItemManager.Instance.AddItem(customItem3);
				CustomRecipe customRecipe3 = new CustomRecipe(new RecipeConfig
				{
					Item = "ArmorAbyssalLegs",
					CraftingStation = "piece_workbench",
					MinStationLevel = 2,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "Chitin",
							Amount = 20,
							AmountPerLevel = 5
						},
						new RequirementConfig
						{
							Item = "DeerHide",
							Amount = 2,
							AmountPerLevel = 0
						},
						new RequirementConfig
						{
							Item = "ArmorIronLeg",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe3);
				CustomItem customItem4 = new CustomItem("CapeAbyssal", "CapeTrollHide");
				ItemDrop itemDrop4 = customItem4.ItemDrop;
				itemDrop4.m_itemData.m_shared.m_name = "Abyssal Cape";
				itemDrop4.m_itemData.m_shared.m_description = "This item cannot be repaired and will break eventually.";
				itemDrop4.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop4.m_itemData.m_shared.m_maxDurability = 500f;
				itemDrop4.m_itemData.m_shared.m_durabilityPerLevel = 200f;
				itemDrop4.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop4.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop4.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop4.m_itemData.m_shared.m_canBeReparied = false;
				itemDrop4.m_itemData.m_shared.m_destroyBroken = true;
				itemDrop4.m_itemData.m_shared.m_armor = 22f;
				itemDrop4.m_itemData.m_shared.m_setName = "Abyssal Gear";
				itemDrop4.m_itemData.m_shared.m_setSize = 2;
				itemDrop4.m_itemData.m_shared.m_setStatusEffect = null;
				ItemManager.Instance.AddItem(customItem4);
				CustomRecipe customRecipe4 = new CustomRecipe(new RecipeConfig
				{
					Item = "CapeAbyssal",
					CraftingStation = "piece_workbench",
					MinStationLevel = 2,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "Chitin",
							Amount = 20,
							AmountPerLevel = 5
						},
						new RequirementConfig
						{
							Item = "DeerHide",
							Amount = 2,
							AmountPerLevel = 0
						},
						new RequirementConfig
						{
							Item = "CapeIron",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe4);
				CustomItem customItem5 = new CustomItem("BeltAbyssal", "BeltStrength");
				ItemDrop itemDrop5 = customItem5.ItemDrop;
				itemDrop5.m_itemData.m_shared.m_name = "Abyssal Belt";
				itemDrop5.m_itemData.m_shared.m_description = "This item cannot be repaired and will break eventually.";
				itemDrop5.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop5.m_itemData.m_shared.m_maxDurability = 500f;
				itemDrop5.m_itemData.m_shared.m_durabilityPerLevel = 200f;
				itemDrop5.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop5.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop5.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop5.m_itemData.m_shared.m_canBeReparied = false;
				itemDrop5.m_itemData.m_shared.m_destroyBroken = true;
				itemDrop5.m_itemData.m_shared.m_armor = 22f;
				itemDrop5.m_itemData.m_shared.m_setName = "Abyssal Gear";
				itemDrop5.m_itemData.m_shared.m_setSize = 2;
				ItemManager.Instance.AddItem(customItem5);
				CustomRecipe customRecipe5 = new CustomRecipe(new RecipeConfig
				{
					Item = "BeltAbyssal",
					CraftingStation = "piece_workbench",
					MinStationLevel = 2,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "Chitin",
							Amount = 20,
							AmountPerLevel = 5
						},
						new RequirementConfig
						{
							Item = "DeerHide",
							Amount = 2,
							AmountPerLevel = 0
						},
						new RequirementConfig
						{
							Item = "BeltIron",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe5);
			}
			catch (Exception ex)
			{
				Logger.LogError("Error while adding Abyssal items: " + ex.Message);
			}
			finally
			{
				ItemManager.OnVanillaItemsAvailable -= this.AddAbyssalItems;
			}
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00007900 File Offset: 0x00005B00
		private void AddSilverItems()
		{
			try
			{
				CustomItem customItem = new CustomItem("HelmetSilver", "HelmetDrake");
				ItemDrop itemDrop = customItem.ItemDrop;
				itemDrop.m_itemData.m_shared.m_name = "Silver Helmet";
				itemDrop.m_itemData.m_shared.m_description = string.Concat(new string[]
				{
					"This item can be reforged into the following;",
					Environment.NewLine,
					"- Wolfskin Helmet",
					Environment.NewLine,
					"> Workbench",
					Environment.NewLine,
					"or",
					Environment.NewLine,
					" - BlackMetal Helmet",
					Environment.NewLine,
					" > Forge"
				});
				itemDrop.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop.m_itemData.m_shared.m_maxDurability = 1000f;
				itemDrop.m_itemData.m_shared.m_durabilityPerLevel = 200f;
				itemDrop.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop.m_itemData.m_shared.m_destroyBroken = false;
				itemDrop.m_itemData.m_shared.m_armor = 18f;
				itemDrop.m_itemData.m_shared.m_setName = "Silver Armor";
				itemDrop.m_itemData.m_shared.m_setSize = 3;
				ItemManager.Instance.AddItem(customItem);
				CustomRecipe customRecipe = new CustomRecipe(new RecipeConfig
				{
					Item = "HelmetSilver",
					CraftingStation = "forge",
					RepairStation = "forge",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "Silver",
							Amount = 15,
							AmountPerLevel = 5
						},
						new RequirementConfig
						{
							Item = "Iron",
							Amount = 5,
							AmountPerLevel = 2
						},
						new RequirementConfig
						{
							Item = "TrollHide",
							Amount = 2,
							AmountPerLevel = 1
						},
						new RequirementConfig
						{
							Item = "HelmetIro",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe);
				CustomItem customItem2 = new CustomItem("ArmorSilverChest", "ArmorWolfChest");
				ItemDrop itemDrop2 = customItem2.ItemDrop;
				itemDrop2.m_itemData.m_shared.m_name = "Silver Cuirass";
				itemDrop2.m_itemData.m_shared.m_description = string.Concat(new string[]
				{
					"This item can be reforged into the following;",
					Environment.NewLine,
					"- Wolfskin Chestplate",
					Environment.NewLine,
					"> Workbench",
					Environment.NewLine,
					"or",
					Environment.NewLine,
					" - BlackMetal Cuirass",
					Environment.NewLine,
					" > Forge"
				});
				itemDrop2.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop2.m_itemData.m_shared.m_maxDurability = 1000f;
				itemDrop2.m_itemData.m_shared.m_durabilityPerLevel = 200f;
				itemDrop2.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop2.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop2.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop2.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop2.m_itemData.m_shared.m_destroyBroken = false;
				itemDrop2.m_itemData.m_shared.m_armor = 18f;
				itemDrop2.m_itemData.m_shared.m_setName = "Silver Armor";
				itemDrop2.m_itemData.m_shared.m_setSize = 3;
				ItemManager.Instance.AddItem(customItem2);
				CustomRecipe customRecipe2 = new CustomRecipe(new RecipeConfig
				{
					Item = "ArmorSilverChest",
					CraftingStation = "forge",
					RepairStation = "forge",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "Silver",
							Amount = 15,
							AmountPerLevel = 5
						},
						new RequirementConfig
						{
							Item = "Iron",
							Amount = 5,
							AmountPerLevel = 2
						},
						new RequirementConfig
						{
							Item = "TrollHide",
							Amount = 2,
							AmountPerLevel = 1
						},
						new RequirementConfig
						{
							Item = "ArmorIronChes",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe2);
				CustomItem customItem3 = new CustomItem("ArmorSilverLegs", "ArmorWolfLegs");
				ItemDrop itemDrop3 = customItem3.ItemDrop;
				itemDrop3.m_itemData.m_shared.m_name = "Silver Greaves";
				itemDrop3.m_itemData.m_shared.m_description = string.Concat(new string[]
				{
					"This item can be reforged into the following;",
					Environment.NewLine,
					"- Wolfskin Greaves",
					Environment.NewLine,
					"> Workbench",
					Environment.NewLine,
					"or",
					Environment.NewLine,
					" - BlackMetal Greaves",
					Environment.NewLine,
					" > Forge"
				});
				itemDrop3.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop3.m_itemData.m_shared.m_maxDurability = 1000f;
				itemDrop3.m_itemData.m_shared.m_durabilityPerLevel = 200f;
				itemDrop3.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop3.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop3.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop3.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop3.m_itemData.m_shared.m_destroyBroken = false;
				itemDrop3.m_itemData.m_shared.m_armor = 18f;
				itemDrop3.m_itemData.m_shared.m_setName = "Silver Armor";
				itemDrop3.m_itemData.m_shared.m_setSize = 3;
				ItemManager.Instance.AddItem(customItem3);
				CustomRecipe customRecipe3 = new CustomRecipe(new RecipeConfig
				{
					Item = "ArmorSilverLegs",
					CraftingStation = "forge",
					RepairStation = "forge",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "Silver",
							Amount = 15,
							AmountPerLevel = 5
						},
						new RequirementConfig
						{
							Item = "Iron",
							Amount = 5,
							AmountPerLevel = 2
						},
						new RequirementConfig
						{
							Item = "TrollHide",
							Amount = 2,
							AmountPerLevel = 1
						},
						new RequirementConfig
						{
							Item = "ArmorIronLeg",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe3);
				CustomItem customItem4 = new CustomItem("CapeSilver", "CapeWolf");
				ItemDrop itemDrop4 = customItem4.ItemDrop;
				itemDrop4.m_itemData.m_shared.m_name = "Silver Cape";
				itemDrop4.m_itemData.m_shared.m_description = string.Concat(new string[]
				{
					"This item can be reforged into the following;",
					Environment.NewLine,
					"- Wolfskin Cape",
					Environment.NewLine,
					"> Workbench",
					Environment.NewLine,
					"or",
					Environment.NewLine,
					" - BlackMetal Cape",
					Environment.NewLine,
					" > Forge"
				});
				itemDrop4.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop4.m_itemData.m_shared.m_maxDurability = 1000f;
				itemDrop4.m_itemData.m_shared.m_durabilityPerLevel = 200f;
				itemDrop4.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop4.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop4.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop4.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop4.m_itemData.m_shared.m_destroyBroken = false;
				itemDrop4.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop4.m_itemData.m_shared.m_armor = 18f;
				itemDrop4.m_itemData.m_shared.m_setName = "Silver Gear";
				itemDrop4.m_itemData.m_shared.m_setSize = 2;
				ItemManager.Instance.AddItem(customItem4);
				CustomRecipe customRecipe4 = new CustomRecipe(new RecipeConfig
				{
					Item = "CapeSilver",
					CraftingStation = "forge",
					RepairStation = "forge",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "Silver",
							Amount = 15,
							AmountPerLevel = 5
						},
						new RequirementConfig
						{
							Item = "Iron",
							Amount = 5,
							AmountPerLevel = 2
						},
						new RequirementConfig
						{
							Item = "TrollHide",
							Amount = 2,
							AmountPerLevel = 1
						},
						new RequirementConfig
						{
							Item = "CapeIron",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe4);
				CustomItem customItem5 = new CustomItem("BeltSilver", "BeltStrength");
				ItemDrop itemDrop5 = customItem5.ItemDrop;
				itemDrop5.m_itemData.m_shared.m_name = "Silver Belt";
				itemDrop5.m_itemData.m_shared.m_description = string.Concat(new string[]
				{
					"This item can be reforged into the following;",
					Environment.NewLine,
					"- Wolfskin Belt",
					Environment.NewLine,
					"> Workbench",
					Environment.NewLine,
					"or",
					Environment.NewLine,
					" - BlackMetal Belt",
					Environment.NewLine,
					" > Forge"
				});
				itemDrop5.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop5.m_itemData.m_shared.m_maxDurability = 1000f;
				itemDrop5.m_itemData.m_shared.m_durabilityPerLevel = 200f;
				itemDrop5.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop5.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop5.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop5.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop5.m_itemData.m_shared.m_destroyBroken = false;
				itemDrop5.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop5.m_itemData.m_shared.m_armor = 18f;
				itemDrop5.m_itemData.m_shared.m_setName = "Silver Gear";
				itemDrop5.m_itemData.m_shared.m_setSize = 2;
				ItemManager.Instance.AddItem(customItem5);
				CustomRecipe customRecipe5 = new CustomRecipe(new RecipeConfig
				{
					Item = "BeltSilver",
					CraftingStation = "forge",
					RepairStation = "forge",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "Silver",
							Amount = 15,
							AmountPerLevel = 5
						},
						new RequirementConfig
						{
							Item = "Iron",
							Amount = 5,
							AmountPerLevel = 2
						},
						new RequirementConfig
						{
							Item = "TrollHide",
							Amount = 2,
							AmountPerLevel = 1
						},
						new RequirementConfig
						{
							Item = "BeltIron",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe5);
			}
			catch (Exception ex)
			{
				Logger.LogError("Error while adding Silver items: " + ex.Message);
			}
			finally
			{
				ItemManager.OnVanillaItemsAvailable -= this.AddSilverItems;
			}
		}

		// Token: 0x0600000C RID: 12 RVA: 0x0000862C File Offset: 0x0000682C
		private void AddWolfItems()
		{
			try
			{
				GameObject gameObject = GameObject.Find("HelmetDrake");
				CustomItem customItem = new CustomItem("HelmetDrak", "HelmetDrake");
				ItemDrop itemDrop = customItem.ItemDrop;
				itemDrop.m_itemData.m_shared.m_name = "Wolfskin Helmet";
				itemDrop.m_itemData.m_shared.m_description = "This item cannot be repaired and will break eventually.";
				itemDrop.m_itemData.m_shared.m_armorPerLevel = 1f;
				itemDrop.m_itemData.m_shared.m_maxDurability = 100f;
				itemDrop.m_itemData.m_shared.m_durabilityPerLevel = 25f;
				itemDrop.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop.m_itemData.m_shared.m_destroyBroken = false;
				itemDrop.m_itemData.m_shared.m_armor = 1f;
				itemDrop.m_itemData.m_shared.m_setName = "Wolfskin Armor";
				itemDrop.m_itemData.m_shared.m_setSize = 3;
				ItemManager.Instance.AddItem(customItem);
				CustomRecipe customRecipe = new CustomRecipe(new RecipeConfig
				{
					Item = "HelmetDrak",
					CraftingStation = "forge",
					RepairStation = "forge",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "Silver",
							Amount = 15,
							AmountPerLevel = 5
						},
						new RequirementConfig
						{
							Item = "Iron",
							Amount = 5,
							AmountPerLevel = 2
						},
						new RequirementConfig
						{
							Item = "WolfPelt",
							Amount = 2,
							AmountPerLevel = 1
						},
						new RequirementConfig
						{
							Item = "HelmetSilver",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe);
				gameObject = GameObject.Find("ArmorWolfChest");
				CustomItem customItem2 = new CustomItem("ArmorWolfChes", "ArmorWolfChest");
				ItemDrop itemDrop2 = customItem2.ItemDrop;
				itemDrop2.m_itemData.m_shared.m_name = "Wolfskin Chestplate";
				itemDrop2.m_itemData.m_shared.m_description = "This item cannot be repaired and will break eventually.";
				itemDrop2.m_itemData.m_shared.m_armorPerLevel = 1f;
				itemDrop2.m_itemData.m_shared.m_maxDurability = 100f;
				itemDrop2.m_itemData.m_shared.m_durabilityPerLevel = 25f;
				itemDrop2.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop2.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop2.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop2.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop2.m_itemData.m_shared.m_destroyBroken = false;
				itemDrop2.m_itemData.m_shared.m_armor = 1f;
				itemDrop2.m_itemData.m_shared.m_setName = "Wolfskin Armor";
				itemDrop2.m_itemData.m_shared.m_setSize = 3;
				ItemManager.Instance.AddItem(customItem2);
				CustomRecipe customRecipe2 = new CustomRecipe(new RecipeConfig
				{
					Item = "ArmorWolfChes",
					CraftingStation = "forge",
					RepairStation = "forge",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "Silver",
							Amount = 15,
							AmountPerLevel = 5
						},
						new RequirementConfig
						{
							Item = "Iron",
							Amount = 5,
							AmountPerLevel = 2
						},
						new RequirementConfig
						{
							Item = "WolfPelt",
							Amount = 2,
							AmountPerLevel = 1
						},
						new RequirementConfig
						{
							Item = "ArmorSilverChest",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe2);
				gameObject = GameObject.Find("ArmorWolfLegs");
				CustomItem customItem3 = new CustomItem("ArmorWolfLeg", "ArmorWolfLegs");
				ItemDrop itemDrop3 = customItem2.ItemDrop;
				itemDrop3.m_itemData.m_shared.m_name = "Wolfskin Greaves";
				itemDrop3.m_itemData.m_shared.m_description = "This item cannot be repaired and will break eventually.";
				itemDrop3.m_itemData.m_shared.m_armorPerLevel = 1f;
				itemDrop3.m_itemData.m_shared.m_maxDurability = 100f;
				itemDrop3.m_itemData.m_shared.m_durabilityPerLevel = 25f;
				itemDrop3.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop3.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop3.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop3.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop3.m_itemData.m_shared.m_destroyBroken = false;
				itemDrop3.m_itemData.m_shared.m_armor = 1f;
				itemDrop3.m_itemData.m_shared.m_setName = "Wolfskin Armor";
				itemDrop3.m_itemData.m_shared.m_setSize = 3;
				ItemManager.Instance.AddItem(customItem3);
				CustomRecipe customRecipe3 = new CustomRecipe(new RecipeConfig
				{
					Item = "ArmorWolfLeg",
					CraftingStation = "forge",
					RepairStation = "forge",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "Silver",
							Amount = 15,
							AmountPerLevel = 5
						},
						new RequirementConfig
						{
							Item = "Iron",
							Amount = 5,
							AmountPerLevel = 2
						},
						new RequirementConfig
						{
							Item = "WolfPelt",
							Amount = 2,
							AmountPerLevel = 1
						},
						new RequirementConfig
						{
							Item = "ArmorSilverLegs",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe3);
				gameObject = GameObject.Find("CapeWolf");
				CustomItem customItem4 = new CustomItem("CapeWol", "CapeWolf");
				ItemDrop itemDrop4 = customItem4.ItemDrop;
				itemDrop4.m_itemData.m_shared.m_name = "WolfPelt Cape";
				itemDrop4.m_itemData.m_shared.m_description = "This item cannot be repaired and will break eventually.";
				itemDrop4.m_itemData.m_shared.m_armorPerLevel = 1f;
				itemDrop4.m_itemData.m_shared.m_maxDurability = 100f;
				itemDrop4.m_itemData.m_shared.m_durabilityPerLevel = 25f;
				itemDrop4.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop4.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop4.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop4.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop4.m_itemData.m_shared.m_destroyBroken = false;
				itemDrop4.m_itemData.m_shared.m_armor = 1f;
				itemDrop4.m_itemData.m_shared.m_setName = "Wolfskin Gear";
				itemDrop4.m_itemData.m_shared.m_setSize = 3;
				ItemManager.Instance.AddItem(customItem4);
				CustomRecipe customRecipe4 = new CustomRecipe(new RecipeConfig
				{
					Item = "CapeWol",
					CraftingStation = "forge",
					RepairStation = "forge",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "Silver",
							Amount = 15,
							AmountPerLevel = 5
						},
						new RequirementConfig
						{
							Item = "Iron",
							Amount = 5,
							AmountPerLevel = 2
						},
						new RequirementConfig
						{
							Item = "WolfPelt",
							Amount = 2,
							AmountPerLevel = 1
						},
						new RequirementConfig
						{
							Item = "CapeSilver",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe4);
				CustomItem customItem5 = new CustomItem("BeltWolf", "BeltStrength");
				ItemDrop itemDrop5 = customItem5.ItemDrop;
				itemDrop5.m_itemData.m_shared.m_name = "WolfPelt Belt";
				itemDrop5.m_itemData.m_shared.m_description = "This item cannot be repaired and will break eventually.";
				itemDrop5.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop5.m_itemData.m_shared.m_maxDurability = 100f;
				itemDrop5.m_itemData.m_shared.m_durabilityPerLevel = 25f;
				itemDrop5.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop5.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop5.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop5.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop5.m_itemData.m_shared.m_destroyBroken = false;
				itemDrop5.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop5.m_itemData.m_shared.m_armor = 18f;
				itemDrop5.m_itemData.m_shared.m_setName = "Wolfskin Gear";
				itemDrop5.m_itemData.m_shared.m_setSize = 2;
				ItemManager.Instance.AddItem(customItem5);
				CustomRecipe customRecipe5 = new CustomRecipe(new RecipeConfig
				{
					Item = "BeltWolf",
					CraftingStation = "forge",
					RepairStation = "forge",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "Silver",
							Amount = 15,
							AmountPerLevel = 5
						},
						new RequirementConfig
						{
							Item = "Iron",
							Amount = 5,
							AmountPerLevel = 2
						},
						new RequirementConfig
						{
							Item = "WolfPelt",
							Amount = 2,
							AmountPerLevel = 1
						},
						new RequirementConfig
						{
							Item = "BeltSilver",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe5);
			}
			catch (Exception ex)
			{
				Logger.LogError("Error while adding Wolf items: " + ex.Message);
			}
			finally
			{
				ItemManager.OnVanillaItemsAvailable -= this.AddWolfItems;
			}
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00009190 File Offset: 0x00007390
		private void AddBlackMetalItems()
		{
			try
			{
				CustomItem customItem = new CustomItem("HelmetBlackMetal", "HelmetPadded");
				ItemDrop itemDrop = customItem.ItemDrop;
				itemDrop.m_itemData.m_shared.m_name = "BlackMetal Helmet";
				itemDrop.m_itemData.m_shared.m_description = string.Concat(new string[]
				{
					"This item can be reforged into the following;",
					Environment.NewLine,
					"- Padded Combat Helmet",
					Environment.NewLine,
					"> Workbench",
					Environment.NewLine,
					"or",
					Environment.NewLine,
					" - Heavymetal Helmet",
					Environment.NewLine,
					" > Forge"
				});
				itemDrop.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop.m_itemData.m_shared.m_maxDurability = 1200f;
				itemDrop.m_itemData.m_shared.m_durabilityPerLevel = 200f;
				itemDrop.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop.m_itemData.m_shared.m_destroyBroken = false;
				itemDrop.m_itemData.m_shared.m_armor = 30f;
				itemDrop.m_itemData.m_shared.m_setName = "BlackMetal Armor";
				itemDrop.m_itemData.m_shared.m_setSize = 3;
				ItemManager.Instance.AddItem(customItem);
				CustomRecipe customRecipe = new CustomRecipe(new RecipeConfig
				{
					Item = "HelmetBlackMetal",
					CraftingStation = "forge",
					RepairStation = "forge",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "BlackMetal",
							Amount = 20,
							AmountPerLevel = 5
						},
						new RequirementConfig
						{
							Item = "LinenThread",
							Amount = 12,
							AmountPerLevel = 3
						},
						new RequirementConfig
						{
							Item = "TrollHide",
							Amount = 2,
							AmountPerLevel = 1
						},
						new RequirementConfig
						{
							Item = "HelmetSilver",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe);
				CustomItem customItem2 = new CustomItem("ArmorBlackMetalChest", "ArmorPaddedCuirass");
				ItemDrop itemDrop2 = customItem2.ItemDrop;
				itemDrop2.m_itemData.m_shared.m_name = "BlackMetal Chestplate";
				itemDrop2.m_itemData.m_shared.m_description = string.Concat(new string[]
				{
					"This item can be reforged into the following;",
					Environment.NewLine,
					"- Padded Combat Chestplate",
					Environment.NewLine,
					"> Workbench",
					Environment.NewLine,
					"or",
					Environment.NewLine,
					" - Heavymetal Cuirass",
					Environment.NewLine,
					" > Forge"
				});
				itemDrop2.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop2.m_itemData.m_shared.m_maxDurability = 1200f;
				itemDrop2.m_itemData.m_shared.m_durabilityPerLevel = 200f;
				itemDrop2.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop2.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop2.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop2.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop2.m_itemData.m_shared.m_destroyBroken = false;
				itemDrop2.m_itemData.m_shared.m_armor = 30f;
				itemDrop2.m_itemData.m_shared.m_setName = "BlackMetal Armor";
				itemDrop2.m_itemData.m_shared.m_setSize = 3;
				ItemManager.Instance.AddItem(customItem2);
				CustomRecipe customRecipe2 = new CustomRecipe(new RecipeConfig
				{
					Item = "ArmorBlackMetalChest",
					CraftingStation = "forge",
					RepairStation = "forge",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "BlackMetal",
							Amount = 20,
							AmountPerLevel = 5
						},
						new RequirementConfig
						{
							Item = "LinenThread",
							Amount = 12,
							AmountPerLevel = 3
						},
						new RequirementConfig
						{
							Item = "TrollHide",
							Amount = 2,
							AmountPerLevel = 1
						},
						new RequirementConfig
						{
							Item = "ArmorSilverChest",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe2);
				CustomItem customItem3 = new CustomItem("ArmorBlackMetalLegs", "ArmorPaddedGreaves");
				ItemDrop itemDrop3 = customItem3.ItemDrop;
				itemDrop3.m_itemData.m_shared.m_name = "BlackMetal Greaves";
				itemDrop3.m_itemData.m_shared.m_description = string.Concat(new string[]
				{
					"This item can be reforged into the following;",
					Environment.NewLine,
					"- Padded Combat Greaves",
					Environment.NewLine,
					"> Workbench",
					Environment.NewLine,
					"or",
					Environment.NewLine,
					" - Heavymetal Greaves",
					Environment.NewLine,
					" > Forge"
				});
				itemDrop3.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop3.m_itemData.m_shared.m_maxDurability = 1200f;
				itemDrop3.m_itemData.m_shared.m_durabilityPerLevel = 200f;
				itemDrop3.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop3.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop3.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop3.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop3.m_itemData.m_shared.m_destroyBroken = false;
				itemDrop3.m_itemData.m_shared.m_armor = 30f;
				itemDrop3.m_itemData.m_shared.m_setName = "BlackMetal Armor";
				itemDrop3.m_itemData.m_shared.m_setSize = 3;
				ItemManager.Instance.AddItem(customItem3);
				CustomRecipe customRecipe3 = new CustomRecipe(new RecipeConfig
				{
					Item = "ArmorBlackMetalLegs",
					CraftingStation = "forge",
					RepairStation = "forge",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "BlackMetal",
							Amount = 20,
							AmountPerLevel = 5
						},
						new RequirementConfig
						{
							Item = "LinenThread",
							Amount = 12,
							AmountPerLevel = 3
						},
						new RequirementConfig
						{
							Item = "TrollHide",
							Amount = 2,
							AmountPerLevel = 1
						},
						new RequirementConfig
						{
							Item = "ArmorSilverLegs",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe3);
				CustomItem customItem4 = new CustomItem("CapeBlackMetal", "CapeWolf");
				ItemDrop itemDrop4 = customItem4.ItemDrop;
				itemDrop4.m_itemData.m_shared.m_name = "BlackMetal Cape";
				itemDrop4.m_itemData.m_shared.m_description = string.Concat(new string[]
				{
					"This item can be reforged into the following;",
					Environment.NewLine,
					"- Padded Combat Cape",
					Environment.NewLine,
					"> Workbench",
					Environment.NewLine,
					"or",
					Environment.NewLine,
					" - Heavymetal Cape",
					Environment.NewLine,
					" > Forge"
				});
				itemDrop4.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop4.m_itemData.m_shared.m_maxDurability = 1200f;
				itemDrop4.m_itemData.m_shared.m_durabilityPerLevel = 200f;
				itemDrop4.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop4.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop4.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop4.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop4.m_itemData.m_shared.m_destroyBroken = false;
				itemDrop4.m_itemData.m_shared.m_armor = 30f;
				itemDrop4.m_itemData.m_shared.m_setName = "BlackMetal Gear";
				itemDrop4.m_itemData.m_shared.m_setSize = 2;
				ItemManager.Instance.AddItem(customItem4);
				CustomRecipe customRecipe4 = new CustomRecipe(new RecipeConfig
				{
					Item = "CapeBlackMetal",
					CraftingStation = "forge",
					RepairStation = "forge",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "BlackMetal",
							Amount = 20,
							AmountPerLevel = 5
						},
						new RequirementConfig
						{
							Item = "LinenThread",
							Amount = 12,
							AmountPerLevel = 3
						},
						new RequirementConfig
						{
							Item = "TrollHide",
							Amount = 2,
							AmountPerLevel = 1
						},
						new RequirementConfig
						{
							Item = "CapeSilver",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe4);
				CustomItem customItem5 = new CustomItem("BeltBlackMetal", "BeltStrength");
				ItemDrop itemDrop5 = customItem5.ItemDrop;
				itemDrop5.m_itemData.m_shared.m_name = "BlackMetal Belt";
				itemDrop5.m_itemData.m_shared.m_description = string.Concat(new string[]
				{
					"This item can be reforged into the following;",
					Environment.NewLine,
					"- Padded Combat Belt",
					Environment.NewLine,
					"> Workbench",
					Environment.NewLine,
					"or",
					Environment.NewLine,
					" - Heavymetal Belt",
					Environment.NewLine,
					" > Forge"
				});
				itemDrop5.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop5.m_itemData.m_shared.m_maxDurability = 1200f;
				itemDrop5.m_itemData.m_shared.m_durabilityPerLevel = 200f;
				itemDrop5.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop5.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop5.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop5.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop4.m_itemData.m_shared.m_destroyBroken = false;
				itemDrop5.m_itemData.m_shared.m_armor = 30f;
				itemDrop5.m_itemData.m_shared.m_setName = "BlackMetal Gear";
				itemDrop5.m_itemData.m_shared.m_setSize = 2;
				ItemManager.Instance.AddItem(customItem5);
				CustomRecipe customRecipe5 = new CustomRecipe(new RecipeConfig
				{
					Item = "BeltBlackMetal",
					CraftingStation = "forge",
					RepairStation = "forge",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "BlackMetal",
							Amount = 20,
							AmountPerLevel = 5
						},
						new RequirementConfig
						{
							Item = "LinenThread",
							Amount = 12,
							AmountPerLevel = 3
						},
						new RequirementConfig
						{
							Item = "TrollHide",
							Amount = 2,
							AmountPerLevel = 1
						},
						new RequirementConfig
						{
							Item = "BeltSilver",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe5);
			}
			catch (Exception ex)
			{
				Logger.LogError("Error while adding BlackMetal items: " + ex.Message);
			}
			finally
			{
				ItemManager.OnVanillaItemsAvailable -= this.AddBlackMetalItems;
			}
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00009E9C File Offset: 0x0000809C
		private void AddPaddedItems()
		{
			try
			{
				CustomItem customItem = new CustomItem("HelmetPadde", "HelmetPadded");
				ItemDrop itemDrop = customItem.ItemDrop;
				itemDrop.m_itemData.m_shared.m_name = "Padded Combat Helmet";
				itemDrop.m_itemData.m_shared.m_description = "This is the end of this item's Forging path";
				itemDrop.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop.m_itemData.m_shared.m_maxDurability = 1200f;
				itemDrop.m_itemData.m_shared.m_durabilityPerLevel = 200f;
				itemDrop.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop.m_itemData.m_shared.m_destroyBroken = false;
				itemDrop.m_itemData.m_shared.m_armor = 20f;
				itemDrop.m_itemData.m_shared.m_setName = "Padded Armor";
				itemDrop.m_itemData.m_shared.m_setSize = 3;
				ItemManager.Instance.AddItem(customItem);
				CustomRecipe customRecipe = new CustomRecipe(new RecipeConfig
				{
					Item = "HelmetPadde",
					CraftingStation = "forge",
					RepairStation = "forge",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "BlackMetal",
							Amount = 15,
							AmountPerLevel = 5
						},
						new RequirementConfig
						{
							Item = "LinenThread",
							Amount = 5,
							AmountPerLevel = 2
						},
						new RequirementConfig
						{
							Item = "LoxPelt",
							Amount = 2,
							AmountPerLevel = 1
						},
						new RequirementConfig
						{
							Item = "HelmetBlackMetal",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe);
				CustomItem customItem2 = new CustomItem("ArmorPaddedChes", "ArmorPaddedCuirass");
				ItemDrop itemDrop2 = customItem2.ItemDrop;
				itemDrop.m_itemData.m_shared.m_name = "Padded Combat Chestplate";
				itemDrop.m_itemData.m_shared.m_description = "This is the end of this item's Forging path";
				itemDrop.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop.m_itemData.m_shared.m_maxDurability = 1200f;
				itemDrop.m_itemData.m_shared.m_durabilityPerLevel = 200f;
				itemDrop.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop.m_itemData.m_shared.m_destroyBroken = false;
				itemDrop.m_itemData.m_shared.m_armor = 20f;
				itemDrop2.m_itemData.m_shared.m_setName = "Padded Armor";
				itemDrop2.m_itemData.m_shared.m_setSize = 3;
				ItemManager.Instance.AddItem(customItem2);
				CustomRecipe customRecipe2 = new CustomRecipe(new RecipeConfig
				{
					Item = "ArmorPaddedChes",
					CraftingStation = "forge",
					RepairStation = "forge",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "BlackMetal",
							Amount = 15,
							AmountPerLevel = 5
						},
						new RequirementConfig
						{
							Item = "LinenThread",
							Amount = 5,
							AmountPerLevel = 2
						},
						new RequirementConfig
						{
							Item = "LoxPelt",
							Amount = 2,
							AmountPerLevel = 1
						},
						new RequirementConfig
						{
							Item = "ArmorBlackMetalChest",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe2);
				CustomItem customItem3 = new CustomItem("ArmorPaddedLeg", "ArmorPaddedGreaves");
				ItemDrop itemDrop3 = customItem3.ItemDrop;
				itemDrop.m_itemData.m_shared.m_name = "Padded Combat Greaves";
				itemDrop.m_itemData.m_shared.m_description = "This is the end of this item's Forging path";
				itemDrop.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop.m_itemData.m_shared.m_maxDurability = 1200f;
				itemDrop.m_itemData.m_shared.m_durabilityPerLevel = 200f;
				itemDrop.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop.m_itemData.m_shared.m_destroyBroken = false;
				itemDrop.m_itemData.m_shared.m_armor = 20f;
				itemDrop3.m_itemData.m_shared.m_setName = "Padded Armor";
				itemDrop3.m_itemData.m_shared.m_setSize = 3;
				ItemManager.Instance.AddItem(customItem3);
				CustomRecipe customRecipe3 = new CustomRecipe(new RecipeConfig
				{
					Item = "ArmorPaddedLeg",
					CraftingStation = "forge",
					RepairStation = "forge",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "BlackMetal",
							Amount = 15,
							AmountPerLevel = 5
						},
						new RequirementConfig
						{
							Item = "LinenThread",
							Amount = 5,
							AmountPerLevel = 2
						},
						new RequirementConfig
						{
							Item = "LoxPelt",
							Amount = 2,
							AmountPerLevel = 1
						},
						new RequirementConfig
						{
							Item = "ArmorBlackMetalLegs",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe3);
				CustomItem customItem4 = new CustomItem("CapePadded", "CapeLox");
				ItemDrop itemDrop4 = customItem4.ItemDrop;
				itemDrop4.m_itemData.m_shared.m_name = "Padded Combat Cape";
				itemDrop4.m_itemData.m_shared.m_description = "This is the end of this item's Forging path";
				itemDrop4.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop4.m_itemData.m_shared.m_maxDurability = 1200f;
				itemDrop4.m_itemData.m_shared.m_durabilityPerLevel = 200f;
				itemDrop4.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop4.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop4.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop4.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop4.m_itemData.m_shared.m_destroyBroken = false;
				itemDrop4.m_itemData.m_shared.m_armor = 20f;
				itemDrop4.m_itemData.m_shared.m_setName = "Padded Gear";
				itemDrop4.m_itemData.m_shared.m_setSize = 3;
				ItemManager.Instance.AddItem(customItem4);
				CustomRecipe customRecipe4 = new CustomRecipe(new RecipeConfig
				{
					Item = "CapePadded",
					CraftingStation = "forge",
					RepairStation = "forge",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "BlackMetal",
							Amount = 15,
							AmountPerLevel = 5
						},
						new RequirementConfig
						{
							Item = "LinenThread",
							Amount = 5,
							AmountPerLevel = 2
						},
						new RequirementConfig
						{
							Item = "LoxPelt",
							Amount = 2,
							AmountPerLevel = 1
						},
						new RequirementConfig
						{
							Item = "CapeBlackMetal",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe4);
				CustomItem customItem5 = new CustomItem("BeltPadded", "BeltStrength");
				ItemDrop itemDrop5 = customItem5.ItemDrop;
				itemDrop5.m_itemData.m_shared.m_name = "Padded Combat Belt";
				itemDrop5.m_itemData.m_shared.m_description = "This is the end of this item's Forging path";
				itemDrop5.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop5.m_itemData.m_shared.m_maxDurability = 1200f;
				itemDrop5.m_itemData.m_shared.m_durabilityPerLevel = 20f;
				itemDrop5.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop5.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop5.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop5.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop5.m_itemData.m_shared.m_destroyBroken = false;
				itemDrop5.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop5.m_itemData.m_shared.m_armor = 20f;
				itemDrop5.m_itemData.m_shared.m_setName = "Padded Gear";
				itemDrop5.m_itemData.m_shared.m_setSize = 2;
				ItemManager.Instance.AddItem(customItem5);
				CustomRecipe customRecipe5 = new CustomRecipe(new RecipeConfig
				{
					Item = "BeltPadded",
					CraftingStation = "forge",
					RepairStation = "forge",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "BlackMetal",
							Amount = 15,
							AmountPerLevel = 5
						},
						new RequirementConfig
						{
							Item = "LinenThread",
							Amount = 5,
							AmountPerLevel = 2
						},
						new RequirementConfig
						{
							Item = "LoxPelt",
							Amount = 2,
							AmountPerLevel = 1
						},
						new RequirementConfig
						{
							Item = "BeltBlackMetal",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe5);
			}
			catch (Exception ex)
			{
				Logger.LogError("Error while adding Padded items: " + ex.Message);
			}
			finally
			{
				ItemManager.OnVanillaItemsAvailable -= this.AddPaddedItems;
			}
		}

		// Token: 0x0600000F RID: 15 RVA: 0x0000A9BC File Offset: 0x00008BBC
		private void AddHeavymetalItems()
		{
			try
			{
				GameObject gameObject = this.assetBundle.LoadAsset<GameObject>("HelmetHeavymetal");
				ItemDrop component = gameObject.GetComponent<ItemDrop>();
				component.m_itemData.m_shared.m_name = "Heavymetal Helmet";
				component.m_itemData.m_shared.m_description = string.Concat(new string[]
				{
					"This item can be reforged into the following;",
					Environment.NewLine,
					"- Frometal Helmet",
					Environment.NewLine,
					"> Forge",
					Environment.NewLine,
					"or",
					Environment.NewLine,
					"- Heavyscale Helmet",
					Environment.NewLine,
					"> Forge"
				});
				component.m_itemData.m_shared.m_armorPerLevel = 2f;
				component.m_itemData.m_shared.m_maxDurability = 1400f;
				component.m_itemData.m_shared.m_durabilityPerLevel = 250f;
				component.m_itemData.m_shared.m_movementModifier = 0f;
				component.m_itemData.m_shared.m_setStatusEffect = null;
				component.m_itemData.m_shared.m_equipStatusEffect = null;
				component.m_itemData.m_shared.m_canBeReparied = true;
				component.m_itemData.m_shared.m_destroyBroken = false;
				component.m_itemData.m_shared.m_armor = 36f;
				component.m_itemData.m_shared.m_setName = "Heavymetal Armor";
				component.m_itemData.m_shared.m_setSize = 3;
				CustomItem customItem = new CustomItem(gameObject, false, new ItemConfig
				{
					CraftingStation = "forge",
					RepairStation = "forge",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "HeavymetalBar",
							Amount = 10,
							AmountPerLevel = 5
						},
						new RequirementConfig
						{
							Item = "LinenThread",
							Amount = 4,
							AmountPerLevel = 4
						},
						new RequirementConfig
						{
							Item = "TrollHide",
							Amount = 1,
							AmountPerLevel = 2
						},
						new RequirementConfig
						{
							Item = "HelmetBlackMetal",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddItem(customItem);
				GameObject gameObject2 = this.assetBundle.LoadAsset<GameObject>("ArmorHeavymetalChest");
				ItemDrop component2 = gameObject2.GetComponent<ItemDrop>();
				component2.m_itemData.m_shared.m_name = "Heavymetal Cuirass";
				component2.m_itemData.m_shared.m_description = string.Concat(new string[]
				{
					"This item can be reforged into the following;",
					Environment.NewLine,
					"- Frometal Cuirass",
					Environment.NewLine,
					"> Forge",
					Environment.NewLine,
					"or",
					Environment.NewLine,
					"- Heavyscale Cuirass",
					Environment.NewLine,
					"> Forge"
				});
				component2.m_itemData.m_shared.m_armorPerLevel = 2f;
				component2.m_itemData.m_shared.m_maxDurability = 1400f;
				component2.m_itemData.m_shared.m_durabilityPerLevel = 250f;
				component2.m_itemData.m_shared.m_movementModifier = 0f;
				component2.m_itemData.m_shared.m_setStatusEffect = null;
				component2.m_itemData.m_shared.m_equipStatusEffect = null;
				component2.m_itemData.m_shared.m_canBeReparied = true;
				component2.m_itemData.m_shared.m_destroyBroken = false;
				component2.m_itemData.m_shared.m_armor = 36f;
				component2.m_itemData.m_shared.m_setName = "Heavymetal Armor";
				component2.m_itemData.m_shared.m_setSize = 3;
				CustomItem customItem2 = new CustomItem(gameObject2, false, new ItemConfig
				{
					CraftingStation = "forge",
					RepairStation = "forge",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "HeavymetalBar",
							Amount = 10,
							AmountPerLevel = 5
						},
						new RequirementConfig
						{
							Item = "LinenThread",
							Amount = 4,
							AmountPerLevel = 4
						},
						new RequirementConfig
						{
							Item = "TrollHide",
							Amount = 1,
							AmountPerLevel = 2
						},
						new RequirementConfig
						{
							Item = "ArmorBlackMetalChest",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddItem(customItem2);
				GameObject gameObject3 = this.assetBundle.LoadAsset<GameObject>("ArmorHeavymetalLegs");
				ItemDrop component3 = gameObject3.GetComponent<ItemDrop>();
				component3.m_itemData.m_shared.m_name = "Heavymetal Greaves";
				component3.m_itemData.m_shared.m_description = string.Concat(new string[]
				{
					"This item can be reforged into the following;",
					Environment.NewLine,
					"- Frometal Greaves",
					Environment.NewLine,
					"> Forge",
					Environment.NewLine,
					"or",
					Environment.NewLine,
					"- Heavyscale Greaves",
					Environment.NewLine,
					"> Forge"
				});
				component3.m_itemData.m_shared.m_armorPerLevel = 2f;
				component3.m_itemData.m_shared.m_maxDurability = 1400f;
				component3.m_itemData.m_shared.m_durabilityPerLevel = 250f;
				component3.m_itemData.m_shared.m_movementModifier = 0f;
				component3.m_itemData.m_shared.m_setStatusEffect = null;
				component3.m_itemData.m_shared.m_equipStatusEffect = null;
				component3.m_itemData.m_shared.m_canBeReparied = true;
				component3.m_itemData.m_shared.m_destroyBroken = false;
				component3.m_itemData.m_shared.m_armor = 36f;
				component3.m_itemData.m_shared.m_setName = "Heavymetal Armor";
				component3.m_itemData.m_shared.m_setSize = 3;
				CustomItem customItem3 = new CustomItem(gameObject3, false, new ItemConfig
				{
					CraftingStation = "forge",
					RepairStation = "forge",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "HeavymetalBar",
							Amount = 10,
							AmountPerLevel = 5
						},
						new RequirementConfig
						{
							Item = "LinenThread",
							Amount = 4,
							AmountPerLevel = 4
						},
						new RequirementConfig
						{
							Item = "TrollHide",
							Amount = 1,
							AmountPerLevel = 2
						},
						new RequirementConfig
						{
							Item = "ArmorBlackMetalLegs",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddItem(customItem3);
				GameObject gameObject4 = this.assetBundle.LoadAsset<GameObject>("CapeHeavymetal");
				ItemDrop component4 = gameObject4.GetComponent<ItemDrop>();
				component4.m_itemData.m_shared.m_name = "Heavymetal Cape";
				component4.m_itemData.m_shared.m_description = string.Concat(new string[]
				{
					"This item can be reforged into the following;",
					Environment.NewLine,
					"- Frometal Cape",
					Environment.NewLine,
					"> Forge",
					Environment.NewLine,
					"or",
					Environment.NewLine,
					"- Heavyscale Cape",
					Environment.NewLine,
					"> Forge"
				});
				component4.m_itemData.m_shared.m_armorPerLevel = 2f;
				component4.m_itemData.m_shared.m_maxDurability = 1400f;
				component4.m_itemData.m_shared.m_durabilityPerLevel = 250f;
				component4.m_itemData.m_shared.m_movementModifier = 0f;
				component4.m_itemData.m_shared.m_setStatusEffect = null;
				component4.m_itemData.m_shared.m_equipStatusEffect = null;
				component4.m_itemData.m_shared.m_canBeReparied = true;
				component4.m_itemData.m_shared.m_destroyBroken = false;
				component4.m_itemData.m_shared.m_armor = 36f;
				component4.m_itemData.m_shared.m_setName = "Heavymetal Gear";
				component4.m_itemData.m_shared.m_setSize = 2;
				CustomItem customItem4 = new CustomItem(gameObject4, false, new ItemConfig
				{
					CraftingStation = "forge",
					RepairStation = "forge",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "HeavymetalBar",
							Amount = 10,
							AmountPerLevel = 5
						},
						new RequirementConfig
						{
							Item = "LinenThread",
							Amount = 4,
							AmountPerLevel = 4
						},
						new RequirementConfig
						{
							Item = "TrollHide",
							Amount = 1,
							AmountPerLevel = 2
						},
						new RequirementConfig
						{
							Item = "CapeBlackMetal",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddItem(customItem4);
				GameObject gameObject5 = this.assetBundle.LoadAsset<GameObject>("BeltHeavymetal");
				ItemDrop component5 = gameObject5.GetComponent<ItemDrop>();
				component5.m_itemData.m_shared.m_name = "Heavymetal Belt";
				component5.m_itemData.m_shared.m_description = string.Concat(new string[]
				{
					"This item can be reforged into the following;",
					Environment.NewLine,
					"- Frometal Belt",
					Environment.NewLine,
					"> Forge",
					Environment.NewLine,
					"or",
					Environment.NewLine,
					"- Heavyscale Belt",
					Environment.NewLine,
					"> Forge"
				});
				component5.m_itemData.m_shared.m_armorPerLevel = 2f;
				component5.m_itemData.m_shared.m_maxDurability = 1400f;
				component5.m_itemData.m_shared.m_durabilityPerLevel = 250f;
				component5.m_itemData.m_shared.m_movementModifier = 0f;
				component5.m_itemData.m_shared.m_setStatusEffect = null;
				component5.m_itemData.m_shared.m_equipStatusEffect = null;
				component5.m_itemData.m_shared.m_canBeReparied = true;
				component5.m_itemData.m_shared.m_destroyBroken = false;
				component5.m_itemData.m_shared.m_armor = 36f;
				component5.m_itemData.m_shared.m_setName = "Heavymetal Gear";
				component5.m_itemData.m_shared.m_setSize = 2;
				CustomItem customItem5 = new CustomItem(gameObject5, false, new ItemConfig
				{
					Amount = 1,
					CraftingStation = "forge",
					RepairStation = "forge",
					MinStationLevel = 3,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "HeavymetalBar",
							Amount = 10,
							AmountPerLevel = 5
						},
						new RequirementConfig
						{
							Item = "LinenThread",
							Amount = 4,
							AmountPerLevel = 4
						},
						new RequirementConfig
						{
							Item = "TrollHide",
							Amount = 1,
							AmountPerLevel = 2
						},
						new RequirementConfig
						{
							Item = "BeltBlackMetal",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddItem(customItem5);
			}
			catch (Exception ex)
			{
				Logger.LogError("Error while adding Heavymetal items: " + ex.Message);
			}
			finally
			{
				ItemManager.OnVanillaItemsAvailable -= this.AddHeavymetalItems;
			}
		}

		// Token: 0x06000010 RID: 16 RVA: 0x0000B658 File Offset: 0x00009858
		private void AddHeavyscaleItems()
		{
			try
			{
				CustomItem customItem = new CustomItem("HelmetHeavyscale", "HelmetPadded");
				ItemDrop itemDrop = customItem.ItemDrop;
				itemDrop.m_itemData.m_shared.m_name = "Heavyscale Helmet";
				itemDrop.m_itemData.m_shared.m_description = string.Concat(new string[]
				{
					"This item can be reforged into the following;",
					Environment.NewLine,
					"- Drakescale Helmet",
					Environment.NewLine,
					"> Forge",
					Environment.NewLine,
					"or",
					Environment.NewLine,
					"- Forgescale Helmet",
					Environment.NewLine,
					"> Forge"
				});
				itemDrop.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop.m_itemData.m_shared.m_maxDurability = 1500f;
				itemDrop.m_itemData.m_shared.m_durabilityPerLevel = 300f;
				itemDrop.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop.m_itemData.m_shared.m_destroyBroken = false;
				itemDrop.m_itemData.m_shared.m_armor = 44f;
				itemDrop.m_itemData.m_shared.m_setName = "Heavyscale Armor";
				itemDrop.m_itemData.m_shared.m_setSize = 3;
				ItemManager.Instance.AddItem(customItem);
				CustomRecipe customRecipe = new CustomRecipe(new RecipeConfig
				{
					Item = "HelmetHeavyscale",
					CraftingStation = "forge",
					RepairStation = "forge",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "Heavyscale",
							Amount = 20,
							AmountPerLevel = 5
						},
						new RequirementConfig
						{
							Item = "LinenThread",
							Amount = 12,
							AmountPerLevel = 4
						},
						new RequirementConfig
						{
							Item = "TrollHide",
							Amount = 2,
							AmountPerLevel = 2
						},
						new RequirementConfig
						{
							Item = "HelmetHeavymetal",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe);
				CustomItem customItem2 = new CustomItem("ArmorHeavyscaleChest", "ArmorPaddedCuirass");
				ItemDrop itemDrop2 = customItem2.ItemDrop;
				itemDrop2.m_itemData.m_shared.m_name = "Heavyscale Cuirass";
				itemDrop2.m_itemData.m_shared.m_description = string.Concat(new string[]
				{
					"This item can be reforged into the following;",
					Environment.NewLine,
					"- Drakescale Cuirass",
					Environment.NewLine,
					"> Forge",
					Environment.NewLine,
					"or",
					Environment.NewLine,
					"- Forgescale Cuirass",
					Environment.NewLine,
					"> Forge"
				});
				itemDrop2.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop2.m_itemData.m_shared.m_maxDurability = 1500f;
				itemDrop2.m_itemData.m_shared.m_durabilityPerLevel = 300f;
				itemDrop2.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop2.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop2.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop2.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop2.m_itemData.m_shared.m_destroyBroken = false;
				itemDrop2.m_itemData.m_shared.m_armor = 44f;
				itemDrop2.m_itemData.m_shared.m_setName = "Heavyscale Armor";
				itemDrop2.m_itemData.m_shared.m_setSize = 3;
				ItemManager.Instance.AddItem(customItem2);
				CustomRecipe customRecipe2 = new CustomRecipe(new RecipeConfig
				{
					Item = "ArmorHeavyscaleChest",
					CraftingStation = "forge",
					RepairStation = "forge",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "Heavyscale",
							Amount = 20,
							AmountPerLevel = 5
						},
						new RequirementConfig
						{
							Item = "LinenThread",
							Amount = 12,
							AmountPerLevel = 4
						},
						new RequirementConfig
						{
							Item = "TrollHide",
							Amount = 2,
							AmountPerLevel = 2
						},
						new RequirementConfig
						{
							Item = "ArmorHeavymetalChest",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe2);
				CustomItem customItem3 = new CustomItem("ArmorHeavyscaleLegs", "ArmorPaddedGreaves");
				ItemDrop itemDrop3 = customItem3.ItemDrop;
				itemDrop3.m_itemData.m_shared.m_name = "Heavyscale Greaves";
				itemDrop3.m_itemData.m_shared.m_description = string.Concat(new string[]
				{
					"This item can be reforged into the following;",
					Environment.NewLine,
					"- Drakescale Greaves",
					Environment.NewLine,
					"> Forge",
					Environment.NewLine,
					"or",
					Environment.NewLine,
					"- Forgescale Greaves",
					Environment.NewLine,
					"> Forge"
				});
				itemDrop3.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop3.m_itemData.m_shared.m_maxDurability = 1500f;
				itemDrop3.m_itemData.m_shared.m_durabilityPerLevel = 300f;
				itemDrop3.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop3.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop3.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop3.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop3.m_itemData.m_shared.m_destroyBroken = false;
				itemDrop3.m_itemData.m_shared.m_armor = 44f;
				itemDrop3.m_itemData.m_shared.m_setName = "Heavyscale Armor";
				itemDrop3.m_itemData.m_shared.m_setSize = 3;
				ItemManager.Instance.AddItem(customItem3);
				CustomRecipe customRecipe3 = new CustomRecipe(new RecipeConfig
				{
					Item = "ArmorHeavyscaleLegs",
					CraftingStation = "forge",
					RepairStation = "forge",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "Heavyscale",
							Amount = 20,
							AmountPerLevel = 5
						},
						new RequirementConfig
						{
							Item = "LinenThread",
							Amount = 12,
							AmountPerLevel = 4
						},
						new RequirementConfig
						{
							Item = "TrollHide",
							Amount = 2,
							AmountPerLevel = 2
						},
						new RequirementConfig
						{
							Item = "ArmorHeavymetalLegs",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe3);
				CustomItem customItem4 = new CustomItem("CapeHeavyscale", "CapeWolf");
				ItemDrop itemDrop4 = customItem4.ItemDrop;
				itemDrop4.m_itemData.m_shared.m_name = "Heavyscale Cape";
				itemDrop4.m_itemData.m_shared.m_description = string.Concat(new string[]
				{
					"This item can be reforged into the following;",
					Environment.NewLine,
					"- Drakescale Cape",
					Environment.NewLine,
					"> Forge",
					Environment.NewLine,
					"or",
					Environment.NewLine,
					"- Forgescale Cape",
					Environment.NewLine,
					"> Forge"
				});
				itemDrop4.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop4.m_itemData.m_shared.m_maxDurability = 1500f;
				itemDrop4.m_itemData.m_shared.m_durabilityPerLevel = 300f;
				itemDrop4.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop4.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop4.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop4.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop4.m_itemData.m_shared.m_destroyBroken = false;
				itemDrop4.m_itemData.m_shared.m_armor = 44f;
				itemDrop4.m_itemData.m_shared.m_setName = "Heavyscale Gear";
				itemDrop4.m_itemData.m_shared.m_setSize = 2;
				ItemManager.Instance.AddItem(customItem4);
				CustomRecipe customRecipe4 = new CustomRecipe(new RecipeConfig
				{
					Item = "CapeHeavyscale",
					CraftingStation = "forge",
					RepairStation = "forge",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "Heavyscale",
							Amount = 20,
							AmountPerLevel = 5
						},
						new RequirementConfig
						{
							Item = "LinenThread",
							Amount = 12,
							AmountPerLevel = 4
						},
						new RequirementConfig
						{
							Item = "TrollHide",
							Amount = 2,
							AmountPerLevel = 2
						},
						new RequirementConfig
						{
							Item = "CapeHeavymetal",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe4);
				CustomItem customItem5 = new CustomItem("BeltHeavyscale", "BeltStrength");
				ItemDrop itemDrop5 = customItem5.ItemDrop;
				itemDrop5.m_itemData.m_shared.m_name = "Heavyscale Belt";
				itemDrop5.m_itemData.m_shared.m_description = string.Concat(new string[]
				{
					"This item can be reforged into the following;",
					Environment.NewLine,
					"- Drakescale Belt",
					Environment.NewLine,
					"> Forge",
					Environment.NewLine,
					"or",
					Environment.NewLine,
					"- Forgescale Belt",
					Environment.NewLine,
					"> Forge"
				});
				itemDrop5.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop5.m_itemData.m_shared.m_maxDurability = 1500f;
				itemDrop5.m_itemData.m_shared.m_durabilityPerLevel = 300f;
				itemDrop5.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop5.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop5.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop5.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop5.m_itemData.m_shared.m_destroyBroken = false;
				itemDrop5.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop5.m_itemData.m_shared.m_armor = 44f;
				itemDrop5.m_itemData.m_shared.m_setName = "Heavyscale Gear";
				itemDrop5.m_itemData.m_shared.m_setSize = 2;
				ItemManager.Instance.AddItem(customItem5);
				CustomRecipe customRecipe5 = new CustomRecipe(new RecipeConfig
				{
					Item = "BeltHeavyscale",
					CraftingStation = "forge",
					RepairStation = "forge",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "Heavyscale",
							Amount = 20,
							AmountPerLevel = 5
						},
						new RequirementConfig
						{
							Item = "LinenThread",
							Amount = 12,
							AmountPerLevel = 4
						},
						new RequirementConfig
						{
							Item = "TrollHide",
							Amount = 2,
							AmountPerLevel = 2
						},
						new RequirementConfig
						{
							Item = "BeltHeavymetal",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe5);
			}
			catch (Exception ex)
			{
				Logger.LogError("Error while adding Heavyscale items: " + ex.Message);
			}
			finally
			{
				ItemManager.OnVanillaItemsAvailable -= this.AddHeavyscaleItems;
			}
		}

		// Token: 0x06000011 RID: 17 RVA: 0x0000C378 File Offset: 0x0000A578
		private void AddFrometalItems()
		{
			try
			{
				CustomItem customItem = new CustomItem("HelmetFrometal", "HelmetPadded");
				ItemDrop itemDrop = customItem.ItemDrop;
				itemDrop.m_itemData.m_shared.m_name = "Frometal Helmet";
				itemDrop.m_itemData.m_shared.m_description = "This is the end of this item's Forging path";
				itemDrop.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop.m_itemData.m_shared.m_maxDurability = 1600f;
				itemDrop.m_itemData.m_shared.m_durabilityPerLevel = 350f;
				itemDrop.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop.m_itemData.m_shared.m_armor = 50f;
				itemDrop.m_itemData.m_shared.m_setName = "Frometal Armor";
				itemDrop.m_itemData.m_shared.m_setSize = 3;
				ItemManager.Instance.AddItem(customItem);
				CustomRecipe customRecipe = new CustomRecipe(new RecipeConfig
				{
					Item = "HelmetFrometal",
					CraftingStation = "forge",
					RepairStation = "forge",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "FrometalBar",
							Amount = 12,
							AmountPerLevel = 4
						},
						new RequirementConfig
						{
							Item = "HeavymetalBar",
							Amount = 8,
							AmountPerLevel = 4
						},
						new RequirementConfig
						{
							Item = "LoxPelt",
							Amount = 2,
							AmountPerLevel = 2
						},
						new RequirementConfig
						{
							Item = "HelmetHeavymetal",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe);
				CustomItem customItem2 = new CustomItem("ArmorFrometalChest", "ArmorPaddedCuirass");
				ItemDrop itemDrop2 = customItem2.ItemDrop;
				itemDrop2.m_itemData.m_shared.m_name = "Frometal Chestplate";
				itemDrop2.m_itemData.m_shared.m_description = "This is the end of this item's Forging path";
				itemDrop2.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop2.m_itemData.m_shared.m_maxDurability = 1600f;
				itemDrop2.m_itemData.m_shared.m_durabilityPerLevel = 350f;
				itemDrop2.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop2.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop2.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop2.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop2.m_itemData.m_shared.m_armor = 50f;
				itemDrop2.m_itemData.m_shared.m_setName = "Frometal Armor";
				itemDrop2.m_itemData.m_shared.m_setSize = 3;
				ItemManager.Instance.AddItem(customItem2);
				CustomRecipe customRecipe2 = new CustomRecipe(new RecipeConfig
				{
					Item = "ArmorFrometalChest",
					CraftingStation = "forge",
					RepairStation = "forge",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "FrometalBar",
							Amount = 12,
							AmountPerLevel = 4
						},
						new RequirementConfig
						{
							Item = "HeavymetalBar",
							Amount = 8,
							AmountPerLevel = 4
						},
						new RequirementConfig
						{
							Item = "LoxPelt",
							Amount = 2,
							AmountPerLevel = 2
						},
						new RequirementConfig
						{
							Item = "ArmorHeavymetalChest",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe2);
				CustomItem customItem3 = new CustomItem("ArmorFrometalLegs", "ArmorPaddedGreaves");
				ItemDrop itemDrop3 = customItem3.ItemDrop;
				itemDrop3.m_itemData.m_shared.m_name = "Frometal Greaves";
				itemDrop3.m_itemData.m_shared.m_description = "This is the end of this item's Forging path";
				itemDrop3.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop3.m_itemData.m_shared.m_maxDurability = 1600f;
				itemDrop3.m_itemData.m_shared.m_durabilityPerLevel = 350f;
				itemDrop3.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop3.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop3.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop3.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop3.m_itemData.m_shared.m_armor = 50f;
				itemDrop3.m_itemData.m_shared.m_setName = "Frometal Armor";
				itemDrop3.m_itemData.m_shared.m_setSize = 3;
				ItemManager.Instance.AddItem(customItem3);
				CustomRecipe customRecipe3 = new CustomRecipe(new RecipeConfig
				{
					Item = "ArmorFrometalLegs",
					CraftingStation = "forge",
					RepairStation = "forge",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "FrometalBar",
							Amount = 12,
							AmountPerLevel = 4
						},
						new RequirementConfig
						{
							Item = "HeavymetalBar",
							Amount = 8,
							AmountPerLevel = 4
						},
						new RequirementConfig
						{
							Item = "LoxPelt",
							Amount = 2,
							AmountPerLevel = 2
						},
						new RequirementConfig
						{
							Item = "ArmorHeavymetalLegs",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe3);
				CustomItem customItem4 = new CustomItem("CapeFrometal", "CapeLox");
				ItemDrop itemDrop4 = customItem4.ItemDrop;
				itemDrop4.m_itemData.m_shared.m_name = "Frometal Cape";
				itemDrop4.m_itemData.m_shared.m_description = "This is the end of this item's Forging path";
				itemDrop4.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop4.m_itemData.m_shared.m_maxDurability = 1600f;
				itemDrop4.m_itemData.m_shared.m_durabilityPerLevel = 350f;
				itemDrop4.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop4.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop4.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop4.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop4.m_itemData.m_shared.m_armor = 50f;
				itemDrop4.m_itemData.m_shared.m_setName = "Frometal Gear";
				itemDrop4.m_itemData.m_shared.m_setSize = 2;
				ItemManager.Instance.AddItem(customItem4);
				CustomRecipe customRecipe4 = new CustomRecipe(new RecipeConfig
				{
					Item = "CapeFrometal",
					CraftingStation = "forge",
					RepairStation = "forge",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "FrometalBar",
							Amount = 12,
							AmountPerLevel = 4
						},
						new RequirementConfig
						{
							Item = "HeavymetalBar",
							Amount = 8,
							AmountPerLevel = 4
						},
						new RequirementConfig
						{
							Item = "LoxPelt",
							Amount = 2,
							AmountPerLevel = 2
						},
						new RequirementConfig
						{
							Item = "CapeHeavymetal",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe4);
				CustomItem customItem5 = new CustomItem("BeltFrometal", "BeltStrength");
				ItemDrop itemDrop5 = customItem5.ItemDrop;
				itemDrop5.m_itemData.m_shared.m_name = "Frometal Belt";
				itemDrop5.m_itemData.m_shared.m_description = "This is the end of this item's Forging path";
				itemDrop5.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop5.m_itemData.m_shared.m_maxDurability = 1600f;
				itemDrop5.m_itemData.m_shared.m_durabilityPerLevel = 350f;
				itemDrop5.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop5.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop5.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop5.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop5.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop5.m_itemData.m_shared.m_armor = 50f;
				itemDrop5.m_itemData.m_shared.m_setName = "Frometal Gear";
				itemDrop5.m_itemData.m_shared.m_setSize = 2;
				ItemManager.Instance.AddItem(customItem5);
				CustomRecipe customRecipe5 = new CustomRecipe(new RecipeConfig
				{
					Item = "BeltFrometal",
					CraftingStation = "forge",
					RepairStation = "forge",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "FrometalBar",
							Amount = 15,
							AmountPerLevel = 4
						},
						new RequirementConfig
						{
							Item = "HeavymetalBar",
							Amount = 5,
							AmountPerLevel = 4
						},
						new RequirementConfig
						{
							Item = "LoxPelt",
							Amount = 2,
							AmountPerLevel = 2
						},
						new RequirementConfig
						{
							Item = "BeltHeavymetal",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe5);
			}
			catch (Exception ex)
			{
				Logger.LogError("Error while adding Frometal items: " + ex.Message);
			}
			finally
			{
				ItemManager.OnVanillaItemsAvailable -= this.AddFrometalItems;
			}
		}

		// Token: 0x06000012 RID: 18 RVA: 0x0000CE54 File Offset: 0x0000B054
		private void AddDrakescaleItems()
		{
			try
			{
				CustomItem customItem = new CustomItem("HelmetDrakescale", "HelmetPadded");
				ItemDrop itemDrop = customItem.ItemDrop;
				itemDrop.m_itemData.m_shared.m_name = "Drakescale Helmet";
				itemDrop.m_itemData.m_shared.m_description = "This is the end of this item's Forging path";
				itemDrop.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop.m_itemData.m_shared.m_maxDurability = 1750f;
				itemDrop.m_itemData.m_shared.m_durabilityPerLevel = 400f;
				itemDrop.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop.m_itemData.m_shared.m_destroyBroken = false;
				itemDrop.m_itemData.m_shared.m_armor = 70f;
				itemDrop.m_itemData.m_shared.m_setName = "Drakescale Armor";
				itemDrop.m_itemData.m_shared.m_setSize = 3;
				ItemManager.Instance.AddItem(customItem);
				CustomRecipe customRecipe = new CustomRecipe(new RecipeConfig
				{
					Item = "HelmetDrakescale",
					CraftingStation = "forge",
					RepairStation = "forge",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "Drakescale",
							Amount = 12,
							AmountPerLevel = 4
						},
						new RequirementConfig
						{
							Item = "HeavymetalBar",
							Amount = 8,
							AmountPerLevel = 4
						},
						new RequirementConfig
						{
							Item = "LoxPelt",
							Amount = 2,
							AmountPerLevel = 2
						},
						new RequirementConfig
						{
							Item = "HelmetHeavyscale",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe);
				CustomItem customItem2 = new CustomItem("ArmorDrakescaleChest", "ArmorPaddedCuirass");
				ItemDrop itemDrop2 = customItem2.ItemDrop;
				itemDrop2.m_itemData.m_shared.m_name = "Drakescale Chestplate";
				itemDrop2.m_itemData.m_shared.m_description = "This is the end of this item's Forging path";
				itemDrop2.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop2.m_itemData.m_shared.m_maxDurability = 1750f;
				itemDrop2.m_itemData.m_shared.m_durabilityPerLevel = 400f;
				itemDrop2.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop2.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop2.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop2.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop2.m_itemData.m_shared.m_destroyBroken = false;
				itemDrop2.m_itemData.m_shared.m_armor = 70f;
				itemDrop2.m_itemData.m_shared.m_setName = "Drakescale Armor";
				itemDrop2.m_itemData.m_shared.m_setSize = 3;
				ItemManager.Instance.AddItem(customItem2);
				CustomRecipe customRecipe2 = new CustomRecipe(new RecipeConfig
				{
					Item = "ArmorDrakescaleChest",
					CraftingStation = "forge",
					RepairStation = "forge",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "Drakescale",
							Amount = 12,
							AmountPerLevel = 4
						},
						new RequirementConfig
						{
							Item = "HeavymetalBar",
							Amount = 8,
							AmountPerLevel = 4
						},
						new RequirementConfig
						{
							Item = "LoxPelt",
							Amount = 2,
							AmountPerLevel = 2
						},
						new RequirementConfig
						{
							Item = "ArmorHeavyscaleChest",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe2);
				CustomItem customItem3 = new CustomItem("ArmorDrakescaleLegs", "ArmorPaddedGreaves");
				ItemDrop itemDrop3 = customItem3.ItemDrop;
				itemDrop3.m_itemData.m_shared.m_name = "Drakescale Greaves";
				itemDrop3.m_itemData.m_shared.m_description = "This is the end of this item's Forging path";
				itemDrop3.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop3.m_itemData.m_shared.m_maxDurability = 1750f;
				itemDrop3.m_itemData.m_shared.m_durabilityPerLevel = 400f;
				itemDrop3.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop3.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop3.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop3.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop3.m_itemData.m_shared.m_destroyBroken = false;
				itemDrop3.m_itemData.m_shared.m_armor = 70f;
				itemDrop3.m_itemData.m_shared.m_setName = "Drakescale Armor";
				itemDrop3.m_itemData.m_shared.m_setSize = 3;
				ItemManager.Instance.AddItem(customItem3);
				CustomRecipe customRecipe3 = new CustomRecipe(new RecipeConfig
				{
					Item = "ArmorDrakescaleLegs",
					CraftingStation = "forge",
					RepairStation = "forge",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "Drakescale",
							Amount = 12,
							AmountPerLevel = 4
						},
						new RequirementConfig
						{
							Item = "HeavymetalBar",
							Amount = 8,
							AmountPerLevel = 4
						},
						new RequirementConfig
						{
							Item = "LoxPelt",
							Amount = 2,
							AmountPerLevel = 2
						},
						new RequirementConfig
						{
							Item = "ArmorHeavyscaleLegs",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe3);
				CustomItem customItem4 = new CustomItem("CapeDrakescale", "CapeLox");
				ItemDrop itemDrop4 = customItem4.ItemDrop;
				itemDrop4.m_itemData.m_shared.m_name = "Drakescale Cape";
				itemDrop4.m_itemData.m_shared.m_description = "This is the end of this item's Forging path";
				itemDrop4.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop4.m_itemData.m_shared.m_maxDurability = 1750f;
				itemDrop4.m_itemData.m_shared.m_durabilityPerLevel = 400f;
				itemDrop4.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop4.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop4.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop4.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop4.m_itemData.m_shared.m_destroyBroken = false;
				itemDrop4.m_itemData.m_shared.m_armor = 70f;
				itemDrop4.m_itemData.m_shared.m_setName = "Drakescale Gear";
				itemDrop4.m_itemData.m_shared.m_setSize = 2;
				ItemManager.Instance.AddItem(customItem4);
				CustomRecipe customRecipe4 = new CustomRecipe(new RecipeConfig
				{
					Item = "CapeDrakescale",
					CraftingStation = "forge",
					RepairStation = "forge",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "Drakescale",
							Amount = 12,
							AmountPerLevel = 4
						},
						new RequirementConfig
						{
							Item = "HeavymetalBar",
							Amount = 8,
							AmountPerLevel = 4
						},
						new RequirementConfig
						{
							Item = "LoxPelt",
							Amount = 2,
							AmountPerLevel = 2
						},
						new RequirementConfig
						{
							Item = "CapeHeavyscale",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe4);
				CustomItem customItem5 = new CustomItem("BeltDrakescale", "BeltStrength");
				ItemDrop itemDrop5 = customItem5.ItemDrop;
				itemDrop5.m_itemData.m_shared.m_name = "Drakescale Belt";
				itemDrop5.m_itemData.m_shared.m_description = "This is the end of this item's Forging path";
				itemDrop5.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop5.m_itemData.m_shared.m_maxDurability = 1750f;
				itemDrop5.m_itemData.m_shared.m_durabilityPerLevel = 400f;
				itemDrop5.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop5.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop5.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop5.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop5.m_itemData.m_shared.m_destroyBroken = false;
				itemDrop5.m_itemData.m_shared.m_armor = 70f;
				itemDrop5.m_itemData.m_shared.m_setName = "Drakescale Gear";
				itemDrop5.m_itemData.m_shared.m_setSize = 2;
				ItemManager.Instance.AddItem(customItem5);
				CustomRecipe customRecipe5 = new CustomRecipe(new RecipeConfig
				{
					Item = "BeltDrakescale",
					CraftingStation = "forge",
					RepairStation = "forge",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "Drakescale",
							Amount = 12,
							AmountPerLevel = 4
						},
						new RequirementConfig
						{
							Item = "HeavymetalBar",
							Amount = 8,
							AmountPerLevel = 4
						},
						new RequirementConfig
						{
							Item = "LoxPelt",
							Amount = 2,
							AmountPerLevel = 2
						},
						new RequirementConfig
						{
							Item = "BeltHeavyscale",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe5);
			}
			catch (Exception ex)
			{
				Logger.LogError("Error while adding Drakescale items: " + ex.Message);
			}
			finally
			{
				ItemManager.OnVanillaItemsAvailable -= this.AddDrakescaleItems;
			}
		}

		// Token: 0x06000013 RID: 19 RVA: 0x0000D978 File Offset: 0x0000BB78
		private void AddFlametalItems()
		{
			try
			{
				CustomItem customItem = new CustomItem("HelmetFlametal", "HelmetPadded");
				ItemDrop itemDrop = customItem.ItemDrop;
				itemDrop.m_itemData.m_shared.m_name = "Flametal Helmet";
				itemDrop.m_itemData.m_shared.m_description = "This is the end of this item's Forging path";
				itemDrop.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop.m_itemData.m_shared.m_maxDurability = 2000f;
				itemDrop.m_itemData.m_shared.m_durabilityPerLevel = 500f;
				itemDrop.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop.m_itemData.m_shared.m_destroyBroken = false;
				itemDrop.m_itemData.m_shared.m_armor = 85f;
				itemDrop.m_itemData.m_shared.m_setName = "Flametal Armor";
				itemDrop.m_itemData.m_shared.m_setSize = 3;
				ItemManager.Instance.AddItem(customItem);
				CustomRecipe customRecipe = new CustomRecipe(new RecipeConfig
				{
					Item = "HelmetFlametal",
					CraftingStation = "forge",
					RepairStation = "forge",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "FlametalBar",
							Amount = 12,
							AmountPerLevel = 4
						},
						new RequirementConfig
						{
							Item = "HeavymetalBar",
							Amount = 8,
							AmountPerLevel = 4
						},
						new RequirementConfig
						{
							Item = "LoxPelt",
							Amount = 2,
							AmountPerLevel = 2
						},
						new RequirementConfig
						{
							Item = "HelmetHeavymetal",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe);
				CustomItem customItem2 = new CustomItem("ArmorFlametalChest", "ArmorPaddedCuirass");
				ItemDrop itemDrop2 = customItem2.ItemDrop;
				itemDrop2.m_itemData.m_shared.m_name = "Flametal Chestplate";
				itemDrop2.m_itemData.m_shared.m_description = "This is the end of this item's Forging path";
				itemDrop2.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop2.m_itemData.m_shared.m_maxDurability = 2000f;
				itemDrop2.m_itemData.m_shared.m_durabilityPerLevel = 500f;
				itemDrop2.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop2.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop2.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop2.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop2.m_itemData.m_shared.m_destroyBroken = false;
				itemDrop2.m_itemData.m_shared.m_armor = 85f;
				itemDrop2.m_itemData.m_shared.m_setName = "Flametal Armor";
				itemDrop2.m_itemData.m_shared.m_setSize = 3;
				ItemManager.Instance.AddItem(customItem2);
				CustomRecipe customRecipe2 = new CustomRecipe(new RecipeConfig
				{
					Item = "ArmorFlametalChest",
					CraftingStation = "forge",
					RepairStation = "forge",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "FlametalBar",
							Amount = 12,
							AmountPerLevel = 4
						},
						new RequirementConfig
						{
							Item = "HeavymetalBar",
							Amount = 8,
							AmountPerLevel = 4
						},
						new RequirementConfig
						{
							Item = "LoxPelt",
							Amount = 2,
							AmountPerLevel = 2
						},
						new RequirementConfig
						{
							Item = "ArmorHeavymetalChest",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe2);
				CustomItem customItem3 = new CustomItem("ArmorFlametalLegs", "ArmorPaddedGreaves");
				ItemDrop itemDrop3 = customItem3.ItemDrop;
				itemDrop3.m_itemData.m_shared.m_name = "Flametal Greaves";
				itemDrop3.m_itemData.m_shared.m_description = "This is the end of this item's Forging path";
				itemDrop3.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop3.m_itemData.m_shared.m_maxDurability = 2000f;
				itemDrop3.m_itemData.m_shared.m_durabilityPerLevel = 500f;
				itemDrop3.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop3.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop3.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop3.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop3.m_itemData.m_shared.m_destroyBroken = false;
				itemDrop3.m_itemData.m_shared.m_armor = 85f;
				itemDrop3.m_itemData.m_shared.m_setName = "Flametal Armor";
				itemDrop3.m_itemData.m_shared.m_setSize = 3;
				ItemManager.Instance.AddItem(customItem3);
				CustomRecipe customRecipe3 = new CustomRecipe(new RecipeConfig
				{
					Item = "ArmorFlametalLegs",
					CraftingStation = "forge",
					RepairStation = "forge",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "FlametalBar",
							Amount = 12,
							AmountPerLevel = 4
						},
						new RequirementConfig
						{
							Item = "HeavymetalBar",
							Amount = 8,
							AmountPerLevel = 4
						},
						new RequirementConfig
						{
							Item = "LoxPelt",
							Amount = 2,
							AmountPerLevel = 2
						},
						new RequirementConfig
						{
							Item = "ArmorHeavymetalLegs",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe3);
				CustomItem customItem4 = new CustomItem("CapeFlametal", "CapeLox");
				ItemDrop itemDrop4 = customItem4.ItemDrop;
				itemDrop4.m_itemData.m_shared.m_name = "Flametal Cape";
				itemDrop4.m_itemData.m_shared.m_description = "This is the end of this item's Forging path";
				itemDrop4.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop4.m_itemData.m_shared.m_maxDurability = 2000f;
				itemDrop4.m_itemData.m_shared.m_durabilityPerLevel = 500f;
				itemDrop4.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop4.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop4.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop4.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop4.m_itemData.m_shared.m_destroyBroken = false;
				itemDrop4.m_itemData.m_shared.m_armor = 85f;
				itemDrop4.m_itemData.m_shared.m_setName = "Flametal Gear";
				itemDrop4.m_itemData.m_shared.m_setSize = 2;
				ItemManager.Instance.AddItem(customItem4);
				CustomRecipe customRecipe4 = new CustomRecipe(new RecipeConfig
				{
					Item = "CapeFlametal",
					CraftingStation = "forge",
					RepairStation = "forge",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "FlametalBar",
							Amount = 12,
							AmountPerLevel = 4
						},
						new RequirementConfig
						{
							Item = "HeavymetalBar",
							Amount = 8,
							AmountPerLevel = 4
						},
						new RequirementConfig
						{
							Item = "LoxPelt",
							Amount = 2,
							AmountPerLevel = 2
						},
						new RequirementConfig
						{
							Item = "CapeHeavymetal",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe4);
				CustomItem customItem5 = new CustomItem("BeltFlametal", "BeltStrength");
				ItemDrop itemDrop5 = customItem5.ItemDrop;
				itemDrop5.m_itemData.m_shared.m_name = "Flametal Belt";
				itemDrop5.m_itemData.m_shared.m_description = "This is the end of this item's Forging path";
				itemDrop5.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop5.m_itemData.m_shared.m_maxDurability = 2000f;
				itemDrop5.m_itemData.m_shared.m_durabilityPerLevel = 500f;
				itemDrop5.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop5.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop5.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop5.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop5.m_itemData.m_shared.m_destroyBroken = false;
				itemDrop5.m_itemData.m_shared.m_armor = 85f;
				itemDrop5.m_itemData.m_shared.m_setName = "Flametal Gear";
				itemDrop5.m_itemData.m_shared.m_setSize = 2;
				ItemManager.Instance.AddItem(customItem5);
				CustomRecipe customRecipe5 = new CustomRecipe(new RecipeConfig
				{
					Item = "BeltFlametal",
					CraftingStation = "forge",
					RepairStation = "forge",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "FlametalBar",
							Amount = 15,
							AmountPerLevel = 4
						},
						new RequirementConfig
						{
							Item = "HeavymetalBar",
							Amount = 5,
							AmountPerLevel = 4
						},
						new RequirementConfig
						{
							Item = "LoxPelt",
							Amount = 2,
							AmountPerLevel = 2
						},
						new RequirementConfig
						{
							Item = "BeltHeavymetal",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe5);
			}
			catch (Exception ex)
			{
				Logger.LogError("Error while adding Flametal items: " + ex.Message);
			}
			finally
			{
				ItemManager.OnVanillaItemsAvailable -= this.AddFlametalItems;
			}
		}

		// Token: 0x06000014 RID: 20 RVA: 0x0000E49C File Offset: 0x0000C69C
		private void AddForgedscaleItems()
		{
			try
			{
				CustomItem customItem = new CustomItem("HelmetForgedscale", "HelmetPadded");
				ItemDrop itemDrop = customItem.ItemDrop;
				itemDrop.m_itemData.m_shared.m_name = "Forgedscale Helmet";
				itemDrop.m_itemData.m_shared.m_description = "This is the end of this item's Forging path";
				itemDrop.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop.m_itemData.m_shared.m_maxDurability = 2500f;
				itemDrop.m_itemData.m_shared.m_durabilityPerLevel = 650f;
				itemDrop.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop.m_itemData.m_shared.m_destroyBroken = false;
				itemDrop.m_itemData.m_shared.m_armor = 100f;
				itemDrop.m_itemData.m_shared.m_setName = "Forgedscale Armor";
				itemDrop.m_itemData.m_shared.m_setSize = 3;
				ItemManager.Instance.AddItem(customItem);
				CustomRecipe customRecipe = new CustomRecipe(new RecipeConfig
				{
					Item = "HelmetForgedscale",
					CraftingStation = "forge",
					RepairStation = "forge",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "Forgedscale",
							Amount = 12,
							AmountPerLevel = 4
						},
						new RequirementConfig
						{
							Item = "HeavymetalBar",
							Amount = 8,
							AmountPerLevel = 4
						},
						new RequirementConfig
						{
							Item = "LoxPelt",
							Amount = 2,
							AmountPerLevel = 2
						},
						new RequirementConfig
						{
							Item = "HelmetHeavyscale",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe);
				CustomItem customItem2 = new CustomItem("ArmorForgedscaleChest", "ArmorPaddedCuirass");
				ItemDrop itemDrop2 = customItem2.ItemDrop;
				itemDrop2.m_itemData.m_shared.m_name = "Forgedscale Chestplate";
				itemDrop2.m_itemData.m_shared.m_description = "This is the end of this item's Forging path";
				itemDrop2.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop2.m_itemData.m_shared.m_maxDurability = 2500f;
				itemDrop2.m_itemData.m_shared.m_durabilityPerLevel = 650f;
				itemDrop2.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop2.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop2.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop2.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop2.m_itemData.m_shared.m_destroyBroken = false;
				itemDrop2.m_itemData.m_shared.m_armor = 100f;
				itemDrop2.m_itemData.m_shared.m_setName = "Forgedscale Armor";
				itemDrop2.m_itemData.m_shared.m_setSize = 3;
				ItemManager.Instance.AddItem(customItem2);
				CustomRecipe customRecipe2 = new CustomRecipe(new RecipeConfig
				{
					Item = "ArmorForgedscaleChest",
					CraftingStation = "forge",
					RepairStation = "forge",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "Forgedscale",
							Amount = 12,
							AmountPerLevel = 4
						},
						new RequirementConfig
						{
							Item = "HeavymetalBar",
							Amount = 8,
							AmountPerLevel = 4
						},
						new RequirementConfig
						{
							Item = "LoxPelt",
							Amount = 2,
							AmountPerLevel = 2
						},
						new RequirementConfig
						{
							Item = "ArmorHeavyscaleChest",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe2);
				CustomItem customItem3 = new CustomItem("ArmorForgedscaleLegs", "ArmorPaddedGreaves");
				ItemDrop itemDrop3 = customItem3.ItemDrop;
				itemDrop3.m_itemData.m_shared.m_name = "Forgedscale Greaves";
				itemDrop3.m_itemData.m_shared.m_description = "This is the end of this item's Forging path";
				itemDrop3.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop3.m_itemData.m_shared.m_maxDurability = 2500f;
				itemDrop3.m_itemData.m_shared.m_durabilityPerLevel = 650f;
				itemDrop3.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop3.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop3.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop3.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop3.m_itemData.m_shared.m_destroyBroken = false;
				itemDrop3.m_itemData.m_shared.m_armor = 100f;
				itemDrop3.m_itemData.m_shared.m_setName = "Forgedscale Armor";
				itemDrop3.m_itemData.m_shared.m_setSize = 3;
				ItemManager.Instance.AddItem(customItem3);
				CustomRecipe customRecipe3 = new CustomRecipe(new RecipeConfig
				{
					Item = "ArmorForgedscaleLegs",
					CraftingStation = "forge",
					RepairStation = "forge",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "Forgedscale",
							Amount = 12,
							AmountPerLevel = 4
						},
						new RequirementConfig
						{
							Item = "HeavymetalBar",
							Amount = 8,
							AmountPerLevel = 4
						},
						new RequirementConfig
						{
							Item = "LoxPelt",
							Amount = 2,
							AmountPerLevel = 2
						},
						new RequirementConfig
						{
							Item = "ArmorHeavyscaleLegs",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe3);
				CustomItem customItem4 = new CustomItem("CapeForgedscale", "CapeLox");
				ItemDrop itemDrop4 = customItem4.ItemDrop;
				itemDrop4.m_itemData.m_shared.m_name = "Forgedscale Cape";
				itemDrop4.m_itemData.m_shared.m_description = "This is the end of this item's Forging path";
				itemDrop4.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop4.m_itemData.m_shared.m_maxDurability = 2500f;
				itemDrop4.m_itemData.m_shared.m_durabilityPerLevel = 650f;
				itemDrop4.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop4.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop4.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop4.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop4.m_itemData.m_shared.m_destroyBroken = false;
				itemDrop4.m_itemData.m_shared.m_armor = 100f;
				itemDrop4.m_itemData.m_shared.m_setName = "Forgedscale Gear";
				itemDrop4.m_itemData.m_shared.m_setSize = 2;
				ItemManager.Instance.AddItem(customItem4);
				CustomRecipe customRecipe4 = new CustomRecipe(new RecipeConfig
				{
					Item = "CapeForgedscale",
					CraftingStation = "forge",
					RepairStation = "forge",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "Forgedscale",
							Amount = 12,
							AmountPerLevel = 4
						},
						new RequirementConfig
						{
							Item = "HeavymetalBar",
							Amount = 8,
							AmountPerLevel = 4
						},
						new RequirementConfig
						{
							Item = "LoxPelt",
							Amount = 2,
							AmountPerLevel = 2
						},
						new RequirementConfig
						{
							Item = "CapeHeavyscale",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe4);
				CustomItem customItem5 = new CustomItem("BeltForgedscale", "BeltStrength");
				ItemDrop itemDrop5 = customItem5.ItemDrop;
				itemDrop5.m_itemData.m_shared.m_name = "Forgedscale Belt";
				itemDrop5.m_itemData.m_shared.m_description = "This is the end of this item's Forging path";
				itemDrop5.m_itemData.m_shared.m_armorPerLevel = 2f;
				itemDrop5.m_itemData.m_shared.m_maxDurability = 2500f;
				itemDrop5.m_itemData.m_shared.m_durabilityPerLevel = 650f;
				itemDrop5.m_itemData.m_shared.m_movementModifier = 0f;
				itemDrop5.m_itemData.m_shared.m_setStatusEffect = null;
				itemDrop5.m_itemData.m_shared.m_equipStatusEffect = null;
				itemDrop5.m_itemData.m_shared.m_canBeReparied = true;
				itemDrop5.m_itemData.m_shared.m_destroyBroken = false;
				itemDrop5.m_itemData.m_shared.m_armor = 100f;
				itemDrop5.m_itemData.m_shared.m_setName = "Forgedscale Gear";
				itemDrop5.m_itemData.m_shared.m_setSize = 2;
				ItemManager.Instance.AddItem(customItem5);
				CustomRecipe customRecipe5 = new CustomRecipe(new RecipeConfig
				{
					Item = "BeltForgedscale",
					CraftingStation = "forge",
					RepairStation = "forge",
					MinStationLevel = 3,
					Amount = 1,
					Requirements = new RequirementConfig[]
					{
						new RequirementConfig
						{
							Item = "Forgedscale",
							Amount = 15,
							AmountPerLevel = 4
						},
						new RequirementConfig
						{
							Item = "HeavymetalBar",
							Amount = 8,
							AmountPerLevel = 4
						},
						new RequirementConfig
						{
							Item = "LoxPelt",
							Amount = 2,
							AmountPerLevel = 2
						},
						new RequirementConfig
						{
							Item = "BeltHeavyscale",
							Amount = 1,
							AmountPerLevel = 0
						}
					}
				});
				ItemManager.Instance.AddRecipe(customRecipe5);
			}
			catch (Exception ex)
			{
				Logger.LogError("Error while adding Forgedscale items: " + ex.Message);
			}
			finally
			{
				ItemManager.OnVanillaItemsAvailable -= this.AddForgedscaleItems;
			}
		}

		// Token: 0x04000001 RID: 1
		public const string PluginGUID = "MrRageous.ValExArmor";

		// Token: 0x04000002 RID: 2
		public const string PluginName = "ValheimExpanded: Armor Module";

		// Token: 0x04000003 RID: 3
		public const string PluginVersion = "0.4.1";

		// Token: 0x04000004 RID: 4
		private AssetBundle assetBundle;
	}
}
