using System;
using BepInEx;
using Jotunn;
using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;
using Jotunn.Utils;
using UnityEngine;

namespace ValExWeapons
{
	// Token: 0x02000002 RID: 2
	[BepInPlugin("MrRageous.ValExWeapons", "ValheimExpanded: Weapons Module", "0.4.1")]
	[BepInDependency("com.jotunn.jotunn", BepInDependency.DependencyFlags.HardDependency)]
	[NetworkCompatibility(CompatibilityLevel.OnlySyncWhenInstalled, VersionStrictness.Minor)]
	public class Setup : BaseUnityPlugin
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		private void Awake()
		{
			this.LoadAssets();
			this.RegisterOtherWeapons();
			this.RegisterBoltsAmmo();
			this.RegisterBoneWeapons();
			this.RegisterBronzeWeapons();
			this.RegisterAncientWeapons();
			this.RegisterIronWeapons();
			this.RegisterAbyssalWeapons();
			this.RegisterSilverWeapons();
			this.RegisterHeavymetalWeapons();
			this.RegisterFrometalWeapons();
			this.RegisterFlametalWeapons();
		}

		// Token: 0x06000002 RID: 2 RVA: 0x000020B4 File Offset: 0x000002B4
		private void LoadAssets()
		{
			Logger.LogInfo("Embedded resources: " + string.Join(",", typeof(Setup).Assembly.GetManifestResourceNames()));
			this.assetBundle = AssetUtils.LoadAssetBundleFromResources("zweapons", typeof(Setup).Assembly);
			Logger.LogInfo(this.assetBundle);
		}

		// Token: 0x06000003 RID: 3 RVA: 0x0000211C File Offset: 0x0000031C
		public void RegisterBoltsAmmo()
		{
			GameObject gameObject = this.assetBundle.LoadAsset<GameObject>("BoltBone");
			ItemDrop component = gameObject.GetComponent<ItemDrop>();
			component.m_itemData.m_dropPrefab = gameObject;
			component.m_itemData.m_shared.m_name = "Bone Bolt";
			component.m_itemData.m_shared.m_description = "An artisanal technology";
			component.m_itemData.m_shared.m_damages.m_pierce = 12f;
			CustomItem customItem = new CustomItem(gameObject, false, new ItemConfig
			{
				Amount = 5,
				CraftingStation = "piece_artisanstation",
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
			GameObject gameObject2 = this.assetBundle.LoadAsset<GameObject>("BoltBoneF");
			ItemDrop component2 = gameObject2.GetComponent<ItemDrop>();
			component2.m_itemData.m_dropPrefab = gameObject2;
			component2.m_itemData.m_shared.m_name = "Bone Bolt [Fire]";
			component2.m_itemData.m_shared.m_description = "An artisanal technology";
			component2.m_itemData.m_shared.m_damages.m_pierce = 12f;
			component2.m_itemData.m_shared.m_damages.m_fire = 10f;
			CustomItem customItem2 = new CustomItem(gameObject2, false, new ItemConfig
			{
				Amount = 5,
				CraftingStation = "piece_artisanstation",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "BoltBone",
						Amount = 5
					},
					new RequirementConfig
					{
						Item = "Torch",
						Amount = 1
					}
				}
			});
			ItemManager.Instance.AddItem(customItem2);
			GameObject gameObject3 = this.assetBundle.LoadAsset<GameObject>("BoltBoneFr");
			ItemDrop component3 = gameObject3.GetComponent<ItemDrop>();
			component3.m_itemData.m_dropPrefab = gameObject3;
			component3.m_itemData.m_shared.m_name = "Bone Bolt [Frost]";
			component3.m_itemData.m_shared.m_description = "An artisanal technology";
			component3.m_itemData.m_shared.m_damages.m_pierce = 12f;
			component3.m_itemData.m_shared.m_damages.m_frost = 10f;
			CustomItem customItem3 = new CustomItem(gameObject3, false, new ItemConfig
			{
				Amount = 20,
				CraftingStation = "piece_artisanstation",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "BoltBone",
						Amount = 20
					},
					new RequirementConfig
					{
						Item = "FreezeGland",
						Amount = 1
					}
				}
			});
			ItemManager.Instance.AddItem(customItem3);
			GameObject gameObject4 = this.assetBundle.LoadAsset<GameObject>("BoltBoneP");
			ItemDrop component4 = gameObject4.GetComponent<ItemDrop>();
			component4.m_itemData.m_dropPrefab = gameObject4;
			component4.m_itemData.m_shared.m_name = "Bone Bolt [Poison]";
			component4.m_itemData.m_shared.m_description = "An artisanal technology";
			component4.m_itemData.m_shared.m_damages.m_pierce = 12f;
			component4.m_itemData.m_shared.m_damages.m_poison = 10f;
			CustomItem customItem4 = new CustomItem(gameObject4, false, new ItemConfig
			{
				Amount = 10,
				CraftingStation = "piece_artisanstation",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "BoltBone",
						Amount = 10
					},
					new RequirementConfig
					{
						Item = "ElderBark",
						Amount = 1
					}
				}
			});
			ItemManager.Instance.AddItem(customItem4);
			GameObject gameObject5 = this.assetBundle.LoadAsset<GameObject>("BoltIron");
			ItemDrop component5 = gameObject5.GetComponent<ItemDrop>();
			component5.m_itemData.m_dropPrefab = gameObject5;
			component5.m_itemData.m_shared.m_name = "Iron Bolt";
			component5.m_itemData.m_shared.m_description = "An artisanal technology";
			component5.m_itemData.m_shared.m_damages.m_pierce = 27f;
			CustomItem customItem5 = new CustomItem(gameObject5, false, new ItemConfig
			{
				Amount = 5,
				CraftingStation = "piece_artisanstation",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Iron",
						Amount = 1
					}
				}
			});
			ItemManager.Instance.AddItem(customItem5);
			GameObject gameObject6 = this.assetBundle.LoadAsset<GameObject>("BoltIronF");
			ItemDrop component6 = gameObject6.GetComponent<ItemDrop>();
			component6.m_itemData.m_dropPrefab = gameObject6;
			component6.m_itemData.m_shared.m_name = "Iron Bolt [Fire]";
			component6.m_itemData.m_shared.m_description = "An artisanal technology";
			component6.m_itemData.m_shared.m_damages.m_pierce = 27f;
			component6.m_itemData.m_shared.m_damages.m_fire = 15f;
			CustomItem customItem6 = new CustomItem(gameObject6, false, new ItemConfig
			{
				Amount = 5,
				CraftingStation = "piece_artisanstation",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "BoltIron",
						Amount = 5
					},
					new RequirementConfig
					{
						Item = "Torch",
						Amount = 1
					}
				}
			});
			ItemManager.Instance.AddItem(customItem6);
			GameObject gameObject7 = this.assetBundle.LoadAsset<GameObject>("BoltIronFr");
			ItemDrop component7 = gameObject7.GetComponent<ItemDrop>();
			component7.m_itemData.m_dropPrefab = gameObject7;
			component7.m_itemData.m_shared.m_name = "Iron Bolt [Frost]";
			component7.m_itemData.m_shared.m_description = "An artisanal technology";
			component7.m_itemData.m_shared.m_damages.m_pierce = 27f;
			component7.m_itemData.m_shared.m_damages.m_frost = 15f;
			CustomItem customItem7 = new CustomItem(gameObject7, false, new ItemConfig
			{
				Amount = 20,
				CraftingStation = "piece_artisanstation",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "BoltIron",
						Amount = 20
					},
					new RequirementConfig
					{
						Item = "FreezeGland",
						Amount = 1
					}
				}
			});
			ItemManager.Instance.AddItem(customItem7);
			GameObject gameObject8 = this.assetBundle.LoadAsset<GameObject>("BoltIronP");
			ItemDrop component8 = gameObject8.GetComponent<ItemDrop>();
			component8.m_itemData.m_dropPrefab = gameObject8;
			component8.m_itemData.m_shared.m_name = "Iron Bolt [Poison]";
			component8.m_itemData.m_shared.m_description = "An artisanal technology";
			component8.m_itemData.m_shared.m_damages.m_pierce = 27f;
			component8.m_itemData.m_shared.m_damages.m_poison = 15f;
			CustomItem customItem8 = new CustomItem(gameObject8, false, new ItemConfig
			{
				Amount = 10,
				CraftingStation = "piece_artisanstation",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "BoltIron",
						Amount = 10
					},
					new RequirementConfig
					{
						Item = "ElderBark",
						Amount = 1
					}
				}
			});
			ItemManager.Instance.AddItem(customItem8);
			GameObject gameObject9 = this.assetBundle.LoadAsset<GameObject>("BoltSilver");
			ItemDrop component9 = gameObject9.GetComponent<ItemDrop>();
			component9.m_itemData.m_dropPrefab = gameObject9;
			component9.m_itemData.m_shared.m_name = "Silver Bolt";
			component9.m_itemData.m_shared.m_description = "An artisanal technology";
			component9.m_itemData.m_shared.m_damages.m_pierce = 26f;
			component9.m_itemData.m_shared.m_damages.m_spirit = 20f;
			CustomItem customItem9 = new CustomItem(gameObject9, false, new ItemConfig
			{
				Amount = 5,
				CraftingStation = "piece_artisanstation",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Silver",
						Amount = 1
					}
				}
			});
			ItemManager.Instance.AddItem(customItem9);
			GameObject gameObject10 = this.assetBundle.LoadAsset<GameObject>("BoltSilverF");
			ItemDrop component10 = gameObject10.GetComponent<ItemDrop>();
			component10.m_itemData.m_dropPrefab = gameObject10;
			component10.m_itemData.m_shared.m_name = "Silver Bolt [Fire]";
			component10.m_itemData.m_shared.m_description = "An artisanal technology";
			component10.m_itemData.m_shared.m_damages.m_pierce = 26f;
			component10.m_itemData.m_shared.m_damages.m_fire = 20f;
			component10.m_itemData.m_shared.m_damages.m_spirit = 20f;
			CustomItem customItem10 = new CustomItem(gameObject10, false, new ItemConfig
			{
				Amount = 5,
				CraftingStation = "piece_artisanstation",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "BoltSilver",
						Amount = 5
					},
					new RequirementConfig
					{
						Item = "Torch",
						Amount = 1
					}
				}
			});
			ItemManager.Instance.AddItem(customItem10);
			GameObject gameObject11 = this.assetBundle.LoadAsset<GameObject>("BoltSilverFr");
			ItemDrop component11 = gameObject11.GetComponent<ItemDrop>();
			component11.m_itemData.m_dropPrefab = gameObject11;
			component11.m_itemData.m_shared.m_name = "Silver Bolt [Frost]";
			component11.m_itemData.m_shared.m_description = "An artisanal technology";
			component11.m_itemData.m_shared.m_damages.m_pierce = 26f;
			component11.m_itemData.m_shared.m_damages.m_frost = 20f;
			component11.m_itemData.m_shared.m_damages.m_spirit = 20f;
			CustomItem customItem11 = new CustomItem(gameObject11, false, new ItemConfig
			{
				Amount = 20,
				CraftingStation = "piece_artisanstation",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "BoltSilver",
						Amount = 20
					},
					new RequirementConfig
					{
						Item = "FreezeGland",
						Amount = 1
					}
				}
			});
			ItemManager.Instance.AddItem(customItem11);
			GameObject gameObject12 = this.assetBundle.LoadAsset<GameObject>("BoltSilverP");
			ItemDrop component12 = gameObject12.GetComponent<ItemDrop>();
			component12.m_itemData.m_dropPrefab = gameObject12;
			component12.m_itemData.m_shared.m_name = "Silver Bolt [Poison]";
			component12.m_itemData.m_shared.m_description = "An artisanal technology";
			component12.m_itemData.m_shared.m_damages.m_pierce = 26f;
			component12.m_itemData.m_shared.m_damages.m_poison = 20f;
			component12.m_itemData.m_shared.m_damages.m_spirit = 20f;
			CustomItem customItem12 = new CustomItem(gameObject12, false, new ItemConfig
			{
				Amount = 10,
				CraftingStation = "piece_artisanstation",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "BoltSilver",
						Amount = 10
					},
					new RequirementConfig
					{
						Item = "ElderBark",
						Amount = 1
					}
				}
			});
			ItemManager.Instance.AddItem(customItem12);
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002D44 File Offset: 0x00000F44
		public void RegisterOtherWeapons()
		{
			GameObject gameObject = this.assetBundle.LoadAsset<GameObject>("crossbow");
			ItemDrop component = gameObject.GetComponent<ItemDrop>();
			component.m_itemData.m_dropPrefab = gameObject;
			component.m_itemData.m_shared.m_name = "Crossbow";
			component.m_itemData.m_shared.m_description = "An artisanal technology";
			component.m_itemData.m_shared.m_maxDurability = 100f;
			component.m_itemData.m_shared.m_durabilityPerLevel = 100f;
			component.m_itemData.m_shared.m_canBeReparied = true;
			component.m_itemData.m_shared.m_destroyBroken = false;
			component.m_itemData.m_shared.m_damages.m_blunt = 0f;
			component.m_itemData.m_shared.m_damages.m_pierce = 5f;
			component.m_itemData.m_shared.m_damages.m_slash = 0f;
			component.m_itemData.m_shared.m_damagesPerLevel.m_blunt = 0f;
			component.m_itemData.m_shared.m_damagesPerLevel.m_pierce = 5f;
			component.m_itemData.m_shared.m_damagesPerLevel.m_slash = 0f;
			component.m_itemData.m_shared.m_deflectionForcePerLevel = 5f;
			component.m_itemData.m_shared.m_teleportable = true;
			component.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem = new CustomItem(gameObject, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "piece_artisanstation",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Wood",
						Amount = 10
					},
					new RequirementConfig
					{
						Item = "Iron",
						Amount = 4
					},
					new RequirementConfig
					{
						Item = "BowHuntsman",
						Amount = 1
					}
				}
			});
			ItemManager.Instance.AddItem(customItem);
			GameObject gameObject2 = this.assetBundle.LoadAsset<GameObject>("torch");
			ItemDrop component2 = gameObject2.GetComponent<ItemDrop>();
			component2.m_itemData.m_dropPrefab = gameObject2;
			component2.m_itemData.m_shared.m_name = "Adventurer's Torch";
			component2.m_itemData.m_shared.m_description = "A torch for adventuring";
			component2.m_itemData.m_shared.m_maxDurability = 250f;
			component2.m_itemData.m_shared.m_durabilityPerLevel = 50f;
			component2.m_itemData.m_shared.m_canBeReparied = true;
			component2.m_itemData.m_shared.m_destroyBroken = false;
			component2.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component2.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component2.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component2.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component2.m_itemData.m_shared.m_damagesPerLevel.m_slash = component2.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component2.m_itemData.m_shared.m_deflectionForcePerLevel = component2.m_itemData.m_shared.m_deflectionForce / 8f;
			component2.m_itemData.m_shared.m_teleportable = true;
			component2.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem2 = new CustomItem(gameObject2, false, new ItemConfig
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
			ItemManager.Instance.AddItem(customItem2);
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00003158 File Offset: 0x00001358
		public void RegisterBoneWeapons()
		{
			GameObject gameObject = this.assetBundle.LoadAsset<GameObject>("BowBone");
			ItemDrop component = gameObject.GetComponent<ItemDrop>();
			component.m_itemData.m_dropPrefab = gameObject;
			component.m_itemData.m_shared.m_name = "Bone Bow";
			component.m_itemData.m_shared.m_description = "A Bow made out of Bone";
			component.m_itemData.m_shared.m_maxDurability = 100f;
			component.m_itemData.m_shared.m_durabilityPerLevel = 50f;
			component.m_itemData.m_shared.m_canBeReparied = false;
			component.m_itemData.m_shared.m_destroyBroken = true;
			component.m_itemData.m_shared.m_damagesPerLevel.m_chop = 0f;
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
						Item = "Bow",
						Amount = 1
					},
					new RequirementConfig
					{
						Item = "BoneFragments",
						Amount = 6,
						AmountPerLevel = 3
					},
					new RequirementConfig
					{
						Item = "DeerHide",
						Amount = 1
					}
				}
			});
			ItemManager.Instance.AddItem(customItem);
			GameObject gameObject2 = this.assetBundle.LoadAsset<GameObject>("AtgeirBone");
			ItemDrop component2 = gameObject2.GetComponent<ItemDrop>();
			component2.m_itemData.m_dropPrefab = gameObject2;
			component2.m_itemData.m_shared.m_name = "Bone Atgeir";
			component2.m_itemData.m_shared.m_description = "An Atgeir made out of Bone";
			component2.m_itemData.m_shared.m_maxDurability = 100f;
			component2.m_itemData.m_shared.m_durabilityPerLevel = 50f;
			component2.m_itemData.m_shared.m_canBeReparied = false;
			component2.m_itemData.m_shared.m_destroyBroken = true;
			component2.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component2.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component2.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component2.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component2.m_itemData.m_shared.m_damagesPerLevel.m_slash = component2.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component2.m_itemData.m_shared.m_deflectionForcePerLevel = component2.m_itemData.m_shared.m_deflectionForce / 8f;
			component2.m_itemData.m_shared.m_teleportable = true;
			component2.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem2 = new CustomItem(gameObject2, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "piece_workbench",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Club",
						Amount = 1
					},
					new RequirementConfig
					{
						Item = "BoneFragments",
						Amount = 8,
						AmountPerLevel = 4
					},
					new RequirementConfig
					{
						Item = "DeerHide",
						Amount = 2
					}
				}
			});
			ItemManager.Instance.AddItem(customItem2);
			GameObject gameObject3 = this.assetBundle.LoadAsset<GameObject>("ClubBone");
			ItemDrop component3 = gameObject3.GetComponent<ItemDrop>();
			component3.m_itemData.m_dropPrefab = gameObject3;
			component3.m_itemData.m_shared.m_name = "Bone Club";
			component3.m_itemData.m_shared.m_description = "A Club made out of Bone";
			component3.m_itemData.m_shared.m_maxDurability = 100f;
			component3.m_itemData.m_shared.m_durabilityPerLevel = 50f;
			component3.m_itemData.m_shared.m_canBeReparied = false;
			component3.m_itemData.m_shared.m_destroyBroken = true;
			component3.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component3.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component3.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component3.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component3.m_itemData.m_shared.m_damagesPerLevel.m_slash = component3.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component3.m_itemData.m_shared.m_deflectionForcePerLevel = component3.m_itemData.m_shared.m_deflectionForce / 8f;
			component3.m_itemData.m_shared.m_teleportable = true;
			component3.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem3 = new CustomItem(gameObject3, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "piece_workbench",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "BoneFragments",
						Amount = 6,
						AmountPerLevel = 3
					}
				}
			});
			ItemManager.Instance.AddItem(customItem3);
			GameObject gameObject4 = this.assetBundle.LoadAsset<GameObject>("SledgeBone");
			ItemDrop component4 = gameObject4.GetComponent<ItemDrop>();
			component4.m_itemData.m_dropPrefab = gameObject4;
			component4.m_itemData.m_shared.m_name = "Bone Sledge";
			component4.m_itemData.m_shared.m_description = "A Sledge made out of Bone";
			component4.m_itemData.m_shared.m_maxDurability = 100f;
			component4.m_itemData.m_shared.m_durabilityPerLevel = 50f;
			component4.m_itemData.m_shared.m_canBeReparied = false;
			component4.m_itemData.m_shared.m_destroyBroken = true;
			component4.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component4.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component4.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component4.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component4.m_itemData.m_shared.m_damagesPerLevel.m_slash = component4.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component4.m_itemData.m_shared.m_deflectionForcePerLevel = component4.m_itemData.m_shared.m_deflectionForce / 8f;
			component4.m_itemData.m_shared.m_teleportable = true;
			component4.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem4 = new CustomItem(gameObject4, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "piece_workbench",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Club",
						Amount = 15
					},
					new RequirementConfig
					{
						Item = "BoneFragments",
						Amount = 10,
						AmountPerLevel = 5
					},
					new RequirementConfig
					{
						Item = "DeerHide",
						Amount = 2
					}
				}
			});
			ItemManager.Instance.AddItem(customItem4);
			GameObject gameObject5 = this.assetBundle.LoadAsset<GameObject>("BattleaxeBone");
			ItemDrop component5 = gameObject5.GetComponent<ItemDrop>();
			component5.m_itemData.m_dropPrefab = gameObject5;
			component5.m_itemData.m_shared.m_name = "Bone Battleaxe";
			component5.m_itemData.m_shared.m_description = "A Battleaxe made out of Bone";
			component5.m_itemData.m_shared.m_maxDurability = 100f;
			component5.m_itemData.m_shared.m_durabilityPerLevel = 50f;
			component5.m_itemData.m_shared.m_canBeReparied = false;
			component5.m_itemData.m_shared.m_destroyBroken = true;
			component5.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component5.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component5.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component5.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component5.m_itemData.m_shared.m_damagesPerLevel.m_slash = component5.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component5.m_itemData.m_shared.m_deflectionForcePerLevel = component5.m_itemData.m_shared.m_deflectionForce / 8f;
			component5.m_itemData.m_shared.m_teleportable = true;
			component5.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem5 = new CustomItem(gameObject5, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "piece_workbench",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Club",
						Amount = 5
					},
					new RequirementConfig
					{
						Item = "FineWood",
						Amount = 5
					},
					new RequirementConfig
					{
						Item = "BoneFragments",
						Amount = 10,
						AmountPerLevel = 5
					},
					new RequirementConfig
					{
						Item = "DeerHide",
						Amount = 2
					}
				}
			});
			ItemManager.Instance.AddItem(customItem5);
			GameObject gameObject6 = this.assetBundle.LoadAsset<GameObject>("SpearBone");
			ItemDrop component6 = gameObject6.GetComponent<ItemDrop>();
			component6.m_itemData.m_dropPrefab = gameObject6;
			component6.m_itemData.m_shared.m_name = "Bone Spear";
			component6.m_itemData.m_shared.m_description = "A Spear made out of Bone";
			component6.m_itemData.m_shared.m_maxDurability = 100f;
			component6.m_itemData.m_shared.m_durabilityPerLevel = 50f;
			component6.m_itemData.m_shared.m_canBeReparied = false;
			component6.m_itemData.m_shared.m_destroyBroken = true;
			component6.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component6.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component6.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component6.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component6.m_itemData.m_shared.m_damagesPerLevel.m_slash = component6.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component6.m_itemData.m_shared.m_deflectionForcePerLevel = component6.m_itemData.m_shared.m_deflectionForce / 8f;
			component6.m_itemData.m_shared.m_teleportable = true;
			component6.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem6 = new CustomItem(gameObject6, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "piece_workbench",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Club",
						Amount = 5
					},
					new RequirementConfig
					{
						Item = "BoneFragments",
						Amount = 6,
						AmountPerLevel = 3
					},
					new RequirementConfig
					{
						Item = "DeerHide",
						Amount = 2
					}
				}
			});
			ItemManager.Instance.AddItem(customItem6);
			GameObject gameObject7 = this.assetBundle.LoadAsset<GameObject>("KnifeBone");
			ItemDrop component7 = gameObject7.GetComponent<ItemDrop>();
			component7.m_itemData.m_dropPrefab = gameObject7;
			component7.m_itemData.m_shared.m_name = "Bone Knife";
			component7.m_itemData.m_shared.m_description = "A Knife made out of Bone";
			component7.m_itemData.m_shared.m_maxDurability = 100f;
			component7.m_itemData.m_shared.m_durabilityPerLevel = 50f;
			component7.m_itemData.m_shared.m_canBeReparied = false;
			component7.m_itemData.m_shared.m_destroyBroken = true;
			component7.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component7.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component7.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component7.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component7.m_itemData.m_shared.m_damagesPerLevel.m_slash = component7.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component7.m_itemData.m_shared.m_deflectionForcePerLevel = component7.m_itemData.m_shared.m_deflectionForce / 8f;
			component7.m_itemData.m_shared.m_teleportable = true;
			component7.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem7 = new CustomItem(gameObject7, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "piece_workbench",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Wood",
						Amount = 2
					},
					new RequirementConfig
					{
						Item = "BoneFragments",
						Amount = 8,
						AmountPerLevel = 4
					}
				}
			});
			ItemManager.Instance.AddItem(customItem7);
			GameObject gameObject8 = this.assetBundle.LoadAsset<GameObject>("MaceBone");
			ItemDrop component8 = gameObject8.GetComponent<ItemDrop>();
			component8.m_itemData.m_dropPrefab = gameObject8;
			component8.m_itemData.m_shared.m_name = "Bone Mace";
			component8.m_itemData.m_shared.m_description = "A Mace made out of Bone";
			component8.m_itemData.m_shared.m_maxDurability = 100f;
			component8.m_itemData.m_shared.m_durabilityPerLevel = 50f;
			component8.m_itemData.m_shared.m_canBeReparied = false;
			component8.m_itemData.m_shared.m_destroyBroken = true;
			component8.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component8.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component8.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component8.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component8.m_itemData.m_shared.m_damagesPerLevel.m_slash = component8.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component8.m_itemData.m_shared.m_deflectionForcePerLevel = component8.m_itemData.m_shared.m_deflectionForce / 8f;
			component8.m_itemData.m_shared.m_teleportable = true;
			component8.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem8 = new CustomItem(gameObject8, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "piece_workbench",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Wood",
						Amount = 4
					},
					new RequirementConfig
					{
						Item = "BoneFragments",
						Amount = 8,
						AmountPerLevel = 4
					},
					new RequirementConfig
					{
						Item = "DeerHide",
						Amount = 2
					}
				}
			});
			ItemManager.Instance.AddItem(customItem8);
			GameObject gameObject9 = this.assetBundle.LoadAsset<GameObject>("SwordBone");
			ItemDrop component9 = gameObject9.GetComponent<ItemDrop>();
			component9.m_itemData.m_dropPrefab = gameObject9;
			component9.m_itemData.m_shared.m_name = "Bone Sword";
			component9.m_itemData.m_shared.m_description = "A Sword made out of Bone";
			component9.m_itemData.m_shared.m_maxDurability = 100f;
			component9.m_itemData.m_shared.m_durabilityPerLevel = 50f;
			component9.m_itemData.m_shared.m_canBeReparied = false;
			component9.m_itemData.m_shared.m_destroyBroken = true;
			component9.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component9.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component9.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component9.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component9.m_itemData.m_shared.m_damagesPerLevel.m_slash = component9.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component9.m_itemData.m_shared.m_deflectionForcePerLevel = component9.m_itemData.m_shared.m_deflectionForce / 8f;
			component9.m_itemData.m_shared.m_teleportable = true;
			component9.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem9 = new CustomItem(gameObject9, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "piece_workbench",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Wood",
						Amount = 4
					},
					new RequirementConfig
					{
						Item = "BoneFragments",
						Amount = 8,
						AmountPerLevel = 4
					},
					new RequirementConfig
					{
						Item = "DeerHide",
						Amount = 2
					}
				}
			});
			ItemManager.Instance.AddItem(customItem9);
			GameObject gameObject10 = this.assetBundle.LoadAsset<GameObject>("ShieldBone");
			ItemDrop component10 = gameObject10.GetComponent<ItemDrop>();
			component10.m_itemData.m_dropPrefab = gameObject10;
			component10.m_itemData.m_shared.m_name = "Bone Shield";
			component10.m_itemData.m_shared.m_description = "A Shield made out of Bone";
			component10.m_itemData.m_shared.m_maxDurability = 100f;
			component10.m_itemData.m_shared.m_durabilityPerLevel = 50f;
			component10.m_itemData.m_shared.m_canBeReparied = false;
			component10.m_itemData.m_shared.m_destroyBroken = true;
			component10.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component10.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component10.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component10.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component10.m_itemData.m_shared.m_damagesPerLevel.m_slash = component10.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component10.m_itemData.m_shared.m_deflectionForcePerLevel = component10.m_itemData.m_shared.m_deflectionForce / 8f;
			component10.m_itemData.m_shared.m_teleportable = true;
			component10.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem10 = new CustomItem(gameObject10, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "piece_workbench",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "ShieldWood",
						Amount = 4
					},
					new RequirementConfig
					{
						Item = "Resin",
						Amount = 10
					},
					new RequirementConfig
					{
						Item = "BoneFragments",
						Amount = 10,
						AmountPerLevel = 5
					}
				}
			});
			ItemManager.Instance.AddItem(customItem10);
			GameObject gameObject11 = this.assetBundle.LoadAsset<GameObject>("ShieldBoneTower");
			ItemDrop component11 = gameObject11.GetComponent<ItemDrop>();
			component11.m_itemData.m_dropPrefab = gameObject11;
			component11.m_itemData.m_shared.m_name = "Bone Tower Shield";
			component11.m_itemData.m_shared.m_description = "A Tower Shield made out of Bone";
			component11.m_itemData.m_shared.m_maxDurability = 100f;
			component11.m_itemData.m_shared.m_durabilityPerLevel = 50f;
			component11.m_itemData.m_shared.m_canBeReparied = false;
			component11.m_itemData.m_shared.m_destroyBroken = true;
			component11.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component11.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component11.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component11.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component11.m_itemData.m_shared.m_damagesPerLevel.m_slash = component11.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component11.m_itemData.m_shared.m_deflectionForcePerLevel = component11.m_itemData.m_shared.m_deflectionForce / 8f;
			component11.m_itemData.m_shared.m_teleportable = true;
			component11.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem11 = new CustomItem(gameObject11, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "piece_workbench",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "ShieldWoodTower",
						Amount = 4
					},
					new RequirementConfig
					{
						Item = "BoneFragments",
						Amount = 14,
						AmountPerLevel = 7
					}
				}
			});
			ItemManager.Instance.AddItem(customItem11);
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000048C4 File Offset: 0x00002AC4
		public void RegisterBronzeWeapons()
		{
			GameObject gameObject = this.assetBundle.LoadAsset<GameObject>("SledgeBronze");
			ItemDrop component = gameObject.GetComponent<ItemDrop>();
			component.m_itemData.m_dropPrefab = gameObject;
			component.m_itemData.m_shared.m_name = "Bronze Sledge";
			component.m_itemData.m_shared.m_description = "A Sledge made out of Bronze";
			component.m_itemData.m_shared.m_maxDurability = 125f;
			component.m_itemData.m_shared.m_durabilityPerLevel = 50f;
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
				CraftingStation = "forge",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Wood",
						Amount = 15
					},
					new RequirementConfig
					{
						Item = "Bronze",
						Amount = 10,
						AmountPerLevel = 5
					},
					new RequirementConfig
					{
						Item = "DeerHide",
						Amount = 2
					}
				}
			});
			ItemManager.Instance.AddItem(customItem);
			GameObject gameObject2 = this.assetBundle.LoadAsset<GameObject>("BattleaxeBronze");
			ItemDrop component2 = gameObject2.GetComponent<ItemDrop>();
			component2.m_itemData.m_dropPrefab = gameObject2;
			component2.m_itemData.m_shared.m_name = "Bronze Battleaxe";
			component2.m_itemData.m_shared.m_description = "A Battleaxe made out of Bronze";
			component2.m_itemData.m_shared.m_maxDurability = 125f;
			component2.m_itemData.m_shared.m_durabilityPerLevel = 50f;
			component2.m_itemData.m_shared.m_canBeReparied = true;
			component2.m_itemData.m_shared.m_destroyBroken = false;
			component2.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component2.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component2.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component2.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component2.m_itemData.m_shared.m_damagesPerLevel.m_slash = component2.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component2.m_itemData.m_shared.m_deflectionForcePerLevel = component2.m_itemData.m_shared.m_deflectionForce / 8f;
			component2.m_itemData.m_shared.m_teleportable = true;
			component2.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem2 = new CustomItem(gameObject2, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "forge",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Wood",
						Amount = 5
					},
					new RequirementConfig
					{
						Item = "FineWood",
						Amount = 5
					},
					new RequirementConfig
					{
						Item = "Bronze",
						Amount = 10,
						AmountPerLevel = 5
					},
					new RequirementConfig
					{
						Item = "DeerHide",
						Amount = 2
					}
				}
			});
			ItemManager.Instance.AddItem(customItem2);
			GameObject gameObject3 = this.assetBundle.LoadAsset<GameObject>("KnifeBronze");
			ItemDrop component3 = gameObject3.GetComponent<ItemDrop>();
			component3.m_itemData.m_dropPrefab = gameObject3;
			component3.m_itemData.m_shared.m_name = "Bronze Knife";
			component3.m_itemData.m_shared.m_description = "A Knife made out of Bronze";
			component3.m_itemData.m_shared.m_maxDurability = 125f;
			component3.m_itemData.m_shared.m_durabilityPerLevel = 50f;
			component3.m_itemData.m_shared.m_canBeReparied = true;
			component3.m_itemData.m_shared.m_destroyBroken = false;
			component3.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component3.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component3.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component3.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component3.m_itemData.m_shared.m_damagesPerLevel.m_slash = component3.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component3.m_itemData.m_shared.m_deflectionForcePerLevel = component3.m_itemData.m_shared.m_deflectionForce / 8f;
			component3.m_itemData.m_shared.m_teleportable = true;
			component3.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem3 = new CustomItem(gameObject3, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "forge",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Wood",
						Amount = 2
					},
					new RequirementConfig
					{
						Item = "Bronze",
						Amount = 8,
						AmountPerLevel = 4
					}
				}
			});
			ItemManager.Instance.AddItem(customItem3);
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00004F30 File Offset: 0x00003130
		public void RegisterAncientWeapons()
		{
			GameObject gameObject = this.assetBundle.LoadAsset<GameObject>("BowAncient");
			ItemDrop component = gameObject.GetComponent<ItemDrop>();
			component.m_itemData.m_dropPrefab = gameObject;
			component.m_itemData.m_shared.m_name = "Ancient Bow";
			component.m_itemData.m_shared.m_description = "A Bow made out of Ancient bark. It can't be repaired and will break eventually.";
			component.m_itemData.m_shared.m_maxDurability = 125f;
			component.m_itemData.m_shared.m_durabilityPerLevel = 50f;
			component.m_itemData.m_shared.m_canBeReparied = false;
			component.m_itemData.m_shared.m_destroyBroken = true;
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
						Item = "FineWood",
						Amount = 5
					},
					new RequirementConfig
					{
						Item = "ElderBark",
						Amount = 6,
						AmountPerLevel = 3
					},
					new RequirementConfig
					{
						Item = "DeerHide",
						Amount = 1
					}
				}
			});
			ItemManager.Instance.AddItem(customItem);
			GameObject gameObject2 = this.assetBundle.LoadAsset<GameObject>("AtgeirAncient");
			ItemDrop component2 = gameObject2.GetComponent<ItemDrop>();
			component2.m_itemData.m_dropPrefab = gameObject2;
			component2.m_itemData.m_shared.m_name = "Ancient Atgeir";
			component2.m_itemData.m_shared.m_description = "An Atgeir made out of Ancient bark. It can't be repaired and will break eventually.";
			component2.m_itemData.m_shared.m_maxDurability = 125f;
			component2.m_itemData.m_shared.m_durabilityPerLevel = 50f;
			component2.m_itemData.m_shared.m_canBeReparied = false;
			component2.m_itemData.m_shared.m_destroyBroken = true;
			component2.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component2.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component2.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component2.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component2.m_itemData.m_shared.m_damagesPerLevel.m_slash = component2.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component2.m_itemData.m_shared.m_deflectionForcePerLevel = component2.m_itemData.m_shared.m_deflectionForce / 8f;
			component2.m_itemData.m_shared.m_teleportable = true;
			component2.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem2 = new CustomItem(gameObject2, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "piece_workbench",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Wood",
						Amount = 10
					},
					new RequirementConfig
					{
						Item = "ElderBark",
						Amount = 8,
						AmountPerLevel = 4
					},
					new RequirementConfig
					{
						Item = "DeerHide",
						Amount = 2
					}
				}
			});
			ItemManager.Instance.AddItem(customItem2);
			GameObject gameObject3 = this.assetBundle.LoadAsset<GameObject>("ClubAncient");
			ItemDrop component3 = gameObject3.GetComponent<ItemDrop>();
			component3.m_itemData.m_dropPrefab = gameObject3;
			component3.m_itemData.m_shared.m_name = "Ancient Club";
			component3.m_itemData.m_shared.m_description = "A Club made out of Ancient bark. It can't be repaired and will break eventually.";
			component3.m_itemData.m_shared.m_maxDurability = 125f;
			component3.m_itemData.m_shared.m_durabilityPerLevel = 50f;
			component3.m_itemData.m_shared.m_canBeReparied = false;
			component3.m_itemData.m_shared.m_destroyBroken = true;
			component3.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component3.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component3.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component3.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component3.m_itemData.m_shared.m_damagesPerLevel.m_slash = component3.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component3.m_itemData.m_shared.m_deflectionForcePerLevel = component3.m_itemData.m_shared.m_deflectionForce / 8f;
			component3.m_itemData.m_shared.m_teleportable = true;
			component3.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem3 = new CustomItem(gameObject3, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "piece_workbench",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "ElderBark",
						Amount = 8,
						AmountPerLevel = 4
					}
				}
			});
			ItemManager.Instance.AddItem(customItem3);
			GameObject gameObject4 = this.assetBundle.LoadAsset<GameObject>("SledgeAncient");
			ItemDrop component4 = gameObject4.GetComponent<ItemDrop>();
			component4.m_itemData.m_dropPrefab = gameObject4;
			component4.m_itemData.m_shared.m_name = "Ancient Sledge";
			component4.m_itemData.m_shared.m_description = "A Sledge made out of Ancient bark. It can't be repaired and will break eventually.";
			component4.m_itemData.m_shared.m_maxDurability = 125f;
			component4.m_itemData.m_shared.m_durabilityPerLevel = 50f;
			component4.m_itemData.m_shared.m_canBeReparied = false;
			component4.m_itemData.m_shared.m_destroyBroken = true;
			component4.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component4.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component4.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component4.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component4.m_itemData.m_shared.m_damagesPerLevel.m_slash = component4.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component4.m_itemData.m_shared.m_deflectionForcePerLevel = component4.m_itemData.m_shared.m_deflectionForce / 8f;
			component4.m_itemData.m_shared.m_teleportable = true;
			component4.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem4 = new CustomItem(gameObject4, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "piece_workbench",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Wood",
						Amount = 15
					},
					new RequirementConfig
					{
						Item = "ElderBark",
						Amount = 10,
						AmountPerLevel = 5
					},
					new RequirementConfig
					{
						Item = "DeerHide",
						Amount = 2
					}
				}
			});
			ItemManager.Instance.AddItem(customItem4);
			GameObject gameObject5 = this.assetBundle.LoadAsset<GameObject>("BattleaxeAncient");
			ItemDrop component5 = gameObject5.GetComponent<ItemDrop>();
			component5.m_itemData.m_dropPrefab = gameObject5;
			component5.m_itemData.m_shared.m_name = "Ancient Battleaxe";
			component5.m_itemData.m_shared.m_description = "A Battleaxe made out of Ancient bark. It can't be repaired and will break eventually.";
			component5.m_itemData.m_shared.m_maxDurability = 125f;
			component5.m_itemData.m_shared.m_durabilityPerLevel = 50f;
			component5.m_itemData.m_shared.m_canBeReparied = false;
			component5.m_itemData.m_shared.m_destroyBroken = true;
			component5.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component5.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component5.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component5.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component5.m_itemData.m_shared.m_damagesPerLevel.m_slash = component5.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component5.m_itemData.m_shared.m_deflectionForcePerLevel = component5.m_itemData.m_shared.m_deflectionForce / 8f;
			component5.m_itemData.m_shared.m_teleportable = true;
			component5.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem5 = new CustomItem(gameObject5, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "piece_workbench",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "FineWood",
						Amount = 5
					},
					new RequirementConfig
					{
						Item = "ElderBark",
						Amount = 10,
						AmountPerLevel = 5
					},
					new RequirementConfig
					{
						Item = "DeerHide",
						Amount = 2
					}
				}
			});
			ItemManager.Instance.AddItem(customItem5);
			GameObject gameObject6 = this.assetBundle.LoadAsset<GameObject>("SwordAncient");
			ItemDrop component6 = gameObject6.GetComponent<ItemDrop>();
			component6.m_itemData.m_dropPrefab = gameObject6;
			component6.m_itemData.m_shared.m_name = "Ancient Sword";
			component6.m_itemData.m_shared.m_description = "A Sword made out of Ancient bark. It can't be repaired and will break eventually.";
			component6.m_itemData.m_shared.m_maxDurability = 125f;
			component6.m_itemData.m_shared.m_durabilityPerLevel = 50f;
			component6.m_itemData.m_shared.m_canBeReparied = false;
			component6.m_itemData.m_shared.m_destroyBroken = true;
			component6.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component6.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component6.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component6.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component6.m_itemData.m_shared.m_damagesPerLevel.m_slash = component6.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component6.m_itemData.m_shared.m_deflectionForcePerLevel = component6.m_itemData.m_shared.m_deflectionForce / 8f;
			component6.m_itemData.m_shared.m_teleportable = true;
			component6.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem6 = new CustomItem(gameObject6, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "piece_workbench",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Wood",
						Amount = 4
					},
					new RequirementConfig
					{
						Item = "ElderBark",
						Amount = 8,
						AmountPerLevel = 5
					},
					new RequirementConfig
					{
						Item = "DeerHide",
						Amount = 2
					}
				}
			});
			ItemManager.Instance.AddItem(customItem6);
			GameObject gameObject7 = this.assetBundle.LoadAsset<GameObject>("MaceAncient");
			ItemDrop component7 = gameObject7.GetComponent<ItemDrop>();
			component7.m_itemData.m_dropPrefab = gameObject7;
			component7.m_itemData.m_shared.m_name = "Ancient Mace";
			component7.m_itemData.m_shared.m_description = "A Mace made out of Ancient bark. It can't be repaired and will break eventually.";
			component7.m_itemData.m_shared.m_maxDurability = 125f;
			component7.m_itemData.m_shared.m_durabilityPerLevel = 50f;
			component7.m_itemData.m_shared.m_canBeReparied = false;
			component7.m_itemData.m_shared.m_destroyBroken = true;
			component7.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component7.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component7.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component7.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component7.m_itemData.m_shared.m_damagesPerLevel.m_slash = component7.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component7.m_itemData.m_shared.m_deflectionForcePerLevel = component7.m_itemData.m_shared.m_deflectionForce / 8f;
			component7.m_itemData.m_shared.m_teleportable = true;
			component7.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem7 = new CustomItem(gameObject7, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "piece_workbench",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Wood",
						Amount = 4
					},
					new RequirementConfig
					{
						Item = "ElderBark",
						Amount = 8,
						AmountPerLevel = 4
					},
					new RequirementConfig
					{
						Item = "DeerHide",
						Amount = 2
					}
				}
			});
			ItemManager.Instance.AddItem(customItem7);
			GameObject gameObject8 = this.assetBundle.LoadAsset<GameObject>("ShieldAncient");
			ItemDrop component8 = gameObject8.GetComponent<ItemDrop>();
			component8.m_itemData.m_dropPrefab = gameObject8;
			component8.m_itemData.m_shared.m_name = "Ancient Shield";
			component8.m_itemData.m_shared.m_description = "A Shield made out of Ancient bark. It can't be repaired and will break eventually.";
			component8.m_itemData.m_shared.m_maxDurability = 125f;
			component8.m_itemData.m_shared.m_durabilityPerLevel = 50f;
			component8.m_itemData.m_shared.m_canBeReparied = false;
			component8.m_itemData.m_shared.m_destroyBroken = true;
			component8.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component8.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component8.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component8.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component8.m_itemData.m_shared.m_damagesPerLevel.m_slash = component8.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component8.m_itemData.m_shared.m_deflectionForcePerLevel = component8.m_itemData.m_shared.m_deflectionForce / 8f;
			component8.m_itemData.m_shared.m_teleportable = true;
			component8.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem8 = new CustomItem(gameObject8, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "piece_workbench",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Wood",
						Amount = 4
					},
					new RequirementConfig
					{
						Item = "Resin",
						Amount = 10
					},
					new RequirementConfig
					{
						Item = "ElderBark",
						Amount = 10,
						AmountPerLevel = 5
					}
				}
			});
			ItemManager.Instance.AddItem(customItem8);
			GameObject gameObject9 = this.assetBundle.LoadAsset<GameObject>("ShieldAncientTower");
			ItemDrop component9 = gameObject9.GetComponent<ItemDrop>();
			component9.m_itemData.m_dropPrefab = gameObject9;
			component9.m_itemData.m_shared.m_name = "Ancient Tower Shield";
			component9.m_itemData.m_shared.m_description = "A Tower Shield made out of Ancient bark. It can't be repaired and will break eventually.";
			component9.m_itemData.m_shared.m_maxDurability = 125f;
			component9.m_itemData.m_shared.m_durabilityPerLevel = 50f;
			component9.m_itemData.m_shared.m_canBeReparied = false;
			component9.m_itemData.m_shared.m_destroyBroken = true;
			component9.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component9.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component9.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component9.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component9.m_itemData.m_shared.m_damagesPerLevel.m_slash = component9.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component9.m_itemData.m_shared.m_deflectionForcePerLevel = component9.m_itemData.m_shared.m_deflectionForce / 8f;
			component9.m_itemData.m_shared.m_teleportable = true;
			component9.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem9 = new CustomItem(gameObject9, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "piece_workbench",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Wood",
						Amount = 4
					},
					new RequirementConfig
					{
						Item = "ElderBark",
						Amount = 14,
						AmountPerLevel = 5
					}
				}
			});
			ItemManager.Instance.AddItem(customItem9);
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00006234 File Offset: 0x00004434
		public void RegisterIronWeapons()
		{
			GameObject gameObject = this.assetBundle.LoadAsset<GameObject>("SpearIron");
			ItemDrop component = gameObject.GetComponent<ItemDrop>();
			component.m_itemData.m_dropPrefab = gameObject;
			component.m_itemData.m_shared.m_name = "Iron Spear";
			component.m_itemData.m_shared.m_description = "A  made out of Iron";
			component.m_itemData.m_shared.m_maxDurability = 175f;
			component.m_itemData.m_shared.m_durabilityPerLevel = 50f;
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
				CraftingStation = "forge",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Wood",
						Amount = 10,
						AmountPerLevel = 5
					},
					new RequirementConfig
					{
						Item = "Iron",
						Amount = 30,
						AmountPerLevel = 15
					},
					new RequirementConfig
					{
						Item = "LeatherScraps",
						Amount = 2,
						AmountPerLevel = 2
					}
				}
			});
			ItemManager.Instance.AddItem(customItem);
			GameObject gameObject2 = this.assetBundle.LoadAsset<GameObject>("KnifeIron");
			ItemDrop component2 = gameObject2.GetComponent<ItemDrop>();
			component2.m_itemData.m_dropPrefab = gameObject2;
			component2.m_itemData.m_shared.m_name = "Iron Knife";
			component2.m_itemData.m_shared.m_description = "A  made out of Iron";
			component2.m_itemData.m_shared.m_maxDurability = 175f;
			component2.m_itemData.m_shared.m_durabilityPerLevel = 50f;
			component2.m_itemData.m_shared.m_canBeReparied = true;
			component2.m_itemData.m_shared.m_destroyBroken = false;
			component2.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component2.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component2.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component2.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component2.m_itemData.m_shared.m_damagesPerLevel.m_slash = component2.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component2.m_itemData.m_shared.m_deflectionForcePerLevel = component2.m_itemData.m_shared.m_deflectionForce / 8f;
			component2.m_itemData.m_shared.m_teleportable = true;
			component2.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem2 = new CustomItem(gameObject2, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "forge",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Wood",
						Amount = 2,
						AmountPerLevel = 2
					},
					new RequirementConfig
					{
						Item = "Iron",
						Amount = 8,
						AmountPerLevel = 4
					}
				}
			});
			ItemManager.Instance.AddItem(customItem2);
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00006674 File Offset: 0x00004874
		public void RegisterAbyssalWeapons()
		{
			GameObject gameObject = this.assetBundle.LoadAsset<GameObject>("BowAbyssal");
			ItemDrop component = gameObject.GetComponent<ItemDrop>();
			component.m_itemData.m_dropPrefab = gameObject;
			component.m_itemData.m_shared.m_name = "Abyssal Bow";
			component.m_itemData.m_shared.m_description = "A Bow made out of Chitin. It can't be repaired and will break eventually.";
			component.m_itemData.m_shared.m_maxDurability = 175f;
			component.m_itemData.m_shared.m_durabilityPerLevel = 50f;
			component.m_itemData.m_shared.m_canBeReparied = false;
			component.m_itemData.m_shared.m_destroyBroken = true;
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
						Item = "RoundLog",
						Amount = 10,
						AmountPerLevel = 5
					},
					new RequirementConfig
					{
						Item = "Chitin",
						Amount = 10,
						AmountPerLevel = 10
					},
					new RequirementConfig
					{
						Item = "TrollHide",
						Amount = 2,
						AmountPerLevel = 1
					},
					new RequirementConfig
					{
						Item = "Iron",
						Amount = 4,
						AmountPerLevel = 2
					}
				}
			});
			ItemManager.Instance.AddItem(customItem);
			GameObject gameObject2 = this.assetBundle.LoadAsset<GameObject>("AtgeirAbyssal");
			ItemDrop component2 = gameObject2.GetComponent<ItemDrop>();
			component2.m_itemData.m_dropPrefab = gameObject2;
			component2.m_itemData.m_shared.m_name = "Abyssal Atgeir";
			component2.m_itemData.m_shared.m_description = "An Atgeir made out of Chitin. It can't be repaired and will break eventually.";
			component2.m_itemData.m_shared.m_maxDurability = 175f;
			component2.m_itemData.m_shared.m_durabilityPerLevel = 50f;
			component2.m_itemData.m_shared.m_canBeReparied = false;
			component2.m_itemData.m_shared.m_destroyBroken = true;
			component2.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component2.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component2.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component2.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component2.m_itemData.m_shared.m_damagesPerLevel.m_slash = component2.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component2.m_itemData.m_shared.m_deflectionForcePerLevel = component2.m_itemData.m_shared.m_deflectionForce / 8f;
			component2.m_itemData.m_shared.m_teleportable = true;
			component2.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem2 = new CustomItem(gameObject2, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "piece_workbench",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "RoundLog",
						Amount = 10,
						AmountPerLevel = 5
					},
					new RequirementConfig
					{
						Item = "Chitin",
						Amount = 10,
						AmountPerLevel = 5
					},
					new RequirementConfig
					{
						Item = "TrollHide",
						Amount = 2,
						AmountPerLevel = 1
					},
					new RequirementConfig
					{
						Item = "Iron",
						Amount = 4,
						AmountPerLevel = 2
					}
				}
			});
			ItemManager.Instance.AddItem(customItem2);
			GameObject gameObject3 = this.assetBundle.LoadAsset<GameObject>("ClubAbyssal");
			ItemDrop component3 = gameObject3.GetComponent<ItemDrop>();
			component3.m_itemData.m_dropPrefab = gameObject3;
			component3.m_itemData.m_shared.m_name = "Abyssal Club";
			component3.m_itemData.m_shared.m_description = "A Club made out of Chitin. It can't be repaired and will break eventually.";
			component3.m_itemData.m_shared.m_maxDurability = 175f;
			component3.m_itemData.m_shared.m_durabilityPerLevel = 50f;
			component3.m_itemData.m_shared.m_canBeReparied = false;
			component3.m_itemData.m_shared.m_destroyBroken = true;
			component3.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component3.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component3.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component3.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component3.m_itemData.m_shared.m_damagesPerLevel.m_slash = component3.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component3.m_itemData.m_shared.m_deflectionForcePerLevel = component3.m_itemData.m_shared.m_deflectionForce / 8f;
			component3.m_itemData.m_shared.m_teleportable = true;
			component3.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem3 = new CustomItem(gameObject3, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "piece_workbench",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Chitin",
						Amount = 7,
						AmountPerLevel = 3
					},
					new RequirementConfig
					{
						Item = "Iron",
						Amount = 4,
						AmountPerLevel = 2
					}
				}
			});
			ItemManager.Instance.AddItem(customItem3);
			GameObject gameObject4 = this.assetBundle.LoadAsset<GameObject>("SledgeAbyssal");
			ItemDrop component4 = gameObject4.GetComponent<ItemDrop>();
			component4.m_itemData.m_dropPrefab = gameObject4;
			component4.m_itemData.m_shared.m_name = "Abyssal Sledge";
			component4.m_itemData.m_shared.m_description = "A Sledge made out of Chitin. It can't be repaired and will break eventually.";
			component4.m_itemData.m_shared.m_maxDurability = 175f;
			component4.m_itemData.m_shared.m_durabilityPerLevel = 50f;
			component4.m_itemData.m_shared.m_destroyBroken = true;
			component4.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component4.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component4.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component4.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component4.m_itemData.m_shared.m_damagesPerLevel.m_slash = component4.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component4.m_itemData.m_shared.m_deflectionForcePerLevel = component4.m_itemData.m_shared.m_deflectionForce / 8f;
			component4.m_itemData.m_shared.m_teleportable = true;
			component4.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem4 = new CustomItem(gameObject4, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "piece_workbench",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "RoundLog",
						Amount = 15,
						AmountPerLevel = 8
					},
					new RequirementConfig
					{
						Item = "Chitin",
						Amount = 10,
						AmountPerLevel = 5
					},
					new RequirementConfig
					{
						Item = "TrollHide",
						Amount = 2,
						AmountPerLevel = 1
					},
					new RequirementConfig
					{
						Item = "Iron",
						Amount = 4,
						AmountPerLevel = 2
					}
				}
			});
			ItemManager.Instance.AddItem(customItem4);
			GameObject gameObject5 = this.assetBundle.LoadAsset<GameObject>("BattleaxeAbyssal");
			ItemDrop component5 = gameObject5.GetComponent<ItemDrop>();
			component5.m_itemData.m_dropPrefab = gameObject5;
			component5.m_itemData.m_shared.m_name = "Abyssal Battleaxe";
			component5.m_itemData.m_shared.m_description = "A Battleaxe made out of Chitin. It can't be repaired and will break eventually.";
			component5.m_itemData.m_shared.m_maxDurability = 175f;
			component5.m_itemData.m_shared.m_durabilityPerLevel = 50f;
			component5.m_itemData.m_shared.m_canBeReparied = false;
			component5.m_itemData.m_shared.m_destroyBroken = true;
			component5.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component5.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component5.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component5.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component5.m_itemData.m_shared.m_damagesPerLevel.m_slash = component5.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component5.m_itemData.m_shared.m_deflectionForcePerLevel = component5.m_itemData.m_shared.m_deflectionForce / 8f;
			component5.m_itemData.m_shared.m_teleportable = true;
			component5.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem5 = new CustomItem(gameObject5, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "piece_workbench",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "RoundLog",
						Amount = 30,
						AmountPerLevel = 15
					},
					new RequirementConfig
					{
						Item = "Chitin",
						Amount = 20,
						AmountPerLevel = 10
					},
					new RequirementConfig
					{
						Item = "TrollHide",
						Amount = 2,
						AmountPerLevel = 1
					},
					new RequirementConfig
					{
						Item = "Iron",
						Amount = 4,
						AmountPerLevel = 2
					}
				}
			});
			ItemManager.Instance.AddItem(customItem5);
			GameObject gameObject6 = this.assetBundle.LoadAsset<GameObject>("MaceAbyssal");
			ItemDrop component6 = gameObject6.GetComponent<ItemDrop>();
			component6.m_itemData.m_dropPrefab = gameObject6;
			component6.m_itemData.m_shared.m_name = "Abyssal Mace";
			component6.m_itemData.m_shared.m_description = "A Mace made out of Chitin. It can't be repaired and will break eventually.";
			component6.m_itemData.m_shared.m_maxDurability = 175f;
			component6.m_itemData.m_shared.m_durabilityPerLevel = 50f;
			component6.m_itemData.m_shared.m_canBeReparied = false;
			component6.m_itemData.m_shared.m_destroyBroken = true;
			component6.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component6.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component6.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component6.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component6.m_itemData.m_shared.m_damagesPerLevel.m_slash = component6.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component6.m_itemData.m_shared.m_deflectionForcePerLevel = component6.m_itemData.m_shared.m_deflectionForce / 8f;
			component6.m_itemData.m_shared.m_teleportable = true;
			component6.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem6 = new CustomItem(gameObject6, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "piece_workbench",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "RoundLog",
						Amount = 4,
						AmountPerLevel = 2
					},
					new RequirementConfig
					{
						Item = "Chitin",
						Amount = 10,
						AmountPerLevel = 5
					},
					new RequirementConfig
					{
						Item = "TrollHide",
						Amount = 3,
						AmountPerLevel = 2
					},
					new RequirementConfig
					{
						Item = "Iron",
						Amount = 4,
						AmountPerLevel = 3
					}
				}
			});
			ItemManager.Instance.AddItem(customItem6);
			GameObject gameObject7 = this.assetBundle.LoadAsset<GameObject>("SwordAbyssal");
			ItemDrop component7 = gameObject7.GetComponent<ItemDrop>();
			component7.m_itemData.m_dropPrefab = gameObject7;
			component7.m_itemData.m_shared.m_name = "Abyssal Sword";
			component7.m_itemData.m_shared.m_description = "A Sword made out of Chitin. It can't be repaired and will break eventually.";
			component7.m_itemData.m_shared.m_maxDurability = 175f;
			component7.m_itemData.m_shared.m_durabilityPerLevel = 50f;
			component7.m_itemData.m_shared.m_canBeReparied = false;
			component7.m_itemData.m_shared.m_destroyBroken = true;
			component7.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component7.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component7.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component7.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component7.m_itemData.m_shared.m_damagesPerLevel.m_slash = component7.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component7.m_itemData.m_shared.m_deflectionForcePerLevel = component7.m_itemData.m_shared.m_deflectionForce / 8f;
			component7.m_itemData.m_shared.m_teleportable = true;
			component7.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem7 = new CustomItem(gameObject7, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "piece_workbench",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "RoundLog",
						Amount = 4,
						AmountPerLevel = 2
					},
					new RequirementConfig
					{
						Item = "Chitin",
						Amount = 10,
						AmountPerLevel = 5
					},
					new RequirementConfig
					{
						Item = "TrollHide",
						Amount = 3,
						AmountPerLevel = 2
					},
					new RequirementConfig
					{
						Item = "Iron",
						Amount = 4,
						AmountPerLevel = 2
					}
				}
			});
			ItemManager.Instance.AddItem(customItem7);
			GameObject gameObject8 = this.assetBundle.LoadAsset<GameObject>("ShieldAbyssal");
			ItemDrop component8 = gameObject8.GetComponent<ItemDrop>();
			component8.m_itemData.m_dropPrefab = gameObject8;
			component8.m_itemData.m_shared.m_name = "Abyssal Shield";
			component8.m_itemData.m_shared.m_description = "A Shield made out of Chitin. It can't be repaired and will break eventually.";
			component8.m_itemData.m_shared.m_maxDurability = 175f;
			component8.m_itemData.m_shared.m_durabilityPerLevel = 50f;
			component8.m_itemData.m_shared.m_canBeReparied = false;
			component8.m_itemData.m_shared.m_destroyBroken = true;
			component8.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component8.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component8.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component8.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component8.m_itemData.m_shared.m_damagesPerLevel.m_slash = component8.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component8.m_itemData.m_shared.m_deflectionForcePerLevel = component8.m_itemData.m_shared.m_deflectionForce / 8f;
			component8.m_itemData.m_shared.m_teleportable = true;
			component8.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem8 = new CustomItem(gameObject8, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "piece_workbench",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "RoundLog",
						Amount = 10,
						AmountPerLevel = 5
					},
					new RequirementConfig
					{
						Item = "Chitin",
						Amount = 8,
						AmountPerLevel = 4
					},
					new RequirementConfig
					{
						Item = "Iron",
						Amount = 4,
						AmountPerLevel = 2
					}
				}
			});
			ItemManager.Instance.AddItem(customItem8);
			GameObject gameObject9 = this.assetBundle.LoadAsset<GameObject>("ShieldAbyssalTower");
			ItemDrop component9 = gameObject9.GetComponent<ItemDrop>();
			component9.m_itemData.m_dropPrefab = gameObject9;
			component9.m_itemData.m_shared.m_name = "Abyssal Tower Shield";
			component9.m_itemData.m_shared.m_description = "A  made out of Chitin. It can't be repaired and will break eventually.";
			component9.m_itemData.m_shared.m_maxDurability = 175f;
			component9.m_itemData.m_shared.m_durabilityPerLevel = 50f;
			component9.m_itemData.m_shared.m_canBeReparied = false;
			component9.m_itemData.m_shared.m_destroyBroken = true;
			component9.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component9.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component9.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component9.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component9.m_itemData.m_shared.m_damagesPerLevel.m_slash = component9.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component9.m_itemData.m_shared.m_deflectionForcePerLevel = component9.m_itemData.m_shared.m_deflectionForce / 8f;
			component9.m_itemData.m_shared.m_teleportable = true;
			component9.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem9 = new CustomItem(gameObject9, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "piece_workbench",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "RoundLog",
						Amount = 15,
						AmountPerLevel = 8
					},
					new RequirementConfig
					{
						Item = "Chitin",
						Amount = 10,
						AmountPerLevel = 5
					},
					new RequirementConfig
					{
						Item = "Iron",
						Amount = 4,
						AmountPerLevel = 2
					}
				}
			});
			ItemManager.Instance.AddItem(customItem9);
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00007B08 File Offset: 0x00005D08
		public void RegisterSilverWeapons()
		{
			GameObject gameObject = this.assetBundle.LoadAsset<GameObject>("BowSilver");
			ItemDrop component = gameObject.GetComponent<ItemDrop>();
			component.m_itemData.m_dropPrefab = gameObject;
			component.m_itemData.m_shared.m_name = "Silver Bow";
			component.m_itemData.m_shared.m_description = "A Bow made out of Silver";
			component.m_itemData.m_shared.m_maxDurability = 200f;
			component.m_itemData.m_shared.m_durabilityPerLevel = 50f;
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
				CraftingStation = "forge",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "RoundLog",
						Amount = 10,
						AmountPerLevel = 5
					},
					new RequirementConfig
					{
						Item = "Silver",
						Amount = 20,
						AmountPerLevel = 10
					},
					new RequirementConfig
					{
						Item = "WolfPelt",
						Amount = 2,
						AmountPerLevel = 1
					},
					new RequirementConfig
					{
						Item = "Iron",
						Amount = 4,
						AmountPerLevel = 2
					}
				}
			});
			ItemManager.Instance.AddItem(customItem);
			GameObject gameObject2 = this.assetBundle.LoadAsset<GameObject>("AtgeirSilver");
			ItemDrop component2 = gameObject2.GetComponent<ItemDrop>();
			component2.m_itemData.m_dropPrefab = gameObject2;
			component2.m_itemData.m_shared.m_name = "Silver Atgeir";
			component2.m_itemData.m_shared.m_description = "An Atgeir made out of Silver";
			component2.m_itemData.m_shared.m_maxDurability = 200f;
			component2.m_itemData.m_shared.m_durabilityPerLevel = 50f;
			component2.m_itemData.m_shared.m_canBeReparied = true;
			component2.m_itemData.m_shared.m_destroyBroken = false;
			component2.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component2.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component2.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component2.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component2.m_itemData.m_shared.m_damagesPerLevel.m_slash = component2.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component2.m_itemData.m_shared.m_deflectionForcePerLevel = component2.m_itemData.m_shared.m_deflectionForce / 8f;
			component2.m_itemData.m_shared.m_teleportable = true;
			component2.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem2 = new CustomItem(gameObject2, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "forge",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "RoundLog",
						Amount = 10,
						AmountPerLevel = 5
					},
					new RequirementConfig
					{
						Item = "Silver",
						Amount = 10,
						AmountPerLevel = 5
					},
					new RequirementConfig
					{
						Item = "WolfPelt",
						Amount = 2,
						AmountPerLevel = 1
					},
					new RequirementConfig
					{
						Item = "Iron",
						Amount = 4,
						AmountPerLevel = 2
					}
				}
			});
			ItemManager.Instance.AddItem(customItem2);
			GameObject gameObject3 = this.assetBundle.LoadAsset<GameObject>("ClubSilver");
			ItemDrop component3 = gameObject3.GetComponent<ItemDrop>();
			component3.m_itemData.m_dropPrefab = gameObject3;
			component3.m_itemData.m_shared.m_name = "Silver Club";
			component3.m_itemData.m_shared.m_description = "A Club made out of Silver";
			component3.m_itemData.m_shared.m_maxDurability = 200f;
			component3.m_itemData.m_shared.m_durabilityPerLevel = 50f;
			component3.m_itemData.m_shared.m_canBeReparied = true;
			component3.m_itemData.m_shared.m_destroyBroken = false;
			component3.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component3.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component3.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component3.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component3.m_itemData.m_shared.m_damagesPerLevel.m_slash = component3.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component3.m_itemData.m_shared.m_deflectionForcePerLevel = component3.m_itemData.m_shared.m_deflectionForce / 8f;
			component3.m_itemData.m_shared.m_teleportable = true;
			component3.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem3 = new CustomItem(gameObject3, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "forge",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Silver",
						Amount = 7,
						AmountPerLevel = 4
					},
					new RequirementConfig
					{
						Item = "Iron",
						Amount = 4,
						AmountPerLevel = 2
					}
				}
			});
			ItemManager.Instance.AddItem(customItem3);
			GameObject gameObject4 = this.assetBundle.LoadAsset<GameObject>("SledgeSilver");
			ItemDrop component4 = gameObject4.GetComponent<ItemDrop>();
			component4.m_itemData.m_dropPrefab = gameObject4;
			component4.m_itemData.m_shared.m_name = "Silver Sledge";
			component4.m_itemData.m_shared.m_description = "A Sledge made out of Silver";
			component4.m_itemData.m_shared.m_maxDurability = 200f;
			component4.m_itemData.m_shared.m_durabilityPerLevel = 50f;
			component4.m_itemData.m_shared.m_canBeReparied = true;
			component4.m_itemData.m_shared.m_destroyBroken = false;
			component4.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component4.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component4.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component4.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component4.m_itemData.m_shared.m_damagesPerLevel.m_slash = component4.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component4.m_itemData.m_shared.m_deflectionForcePerLevel = component4.m_itemData.m_shared.m_deflectionForce / 8f;
			component4.m_itemData.m_shared.m_teleportable = true;
			component4.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem4 = new CustomItem(gameObject4, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "forge",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "RoundLog",
						Amount = 15,
						AmountPerLevel = 8
					},
					new RequirementConfig
					{
						Item = "Silver",
						Amount = 10,
						AmountPerLevel = 5
					},
					new RequirementConfig
					{
						Item = "WolfPelt",
						Amount = 2,
						AmountPerLevel = 1
					},
					new RequirementConfig
					{
						Item = "Iron",
						Amount = 4,
						AmountPerLevel = 2
					}
				}
			});
			ItemManager.Instance.AddItem(customItem4);
			GameObject gameObject5 = this.assetBundle.LoadAsset<GameObject>("BattleaxeSilver");
			ItemDrop component5 = gameObject5.GetComponent<ItemDrop>();
			component5.m_itemData.m_dropPrefab = gameObject5;
			component5.m_itemData.m_shared.m_name = "Silver Battleaxe";
			component5.m_itemData.m_shared.m_description = "A Battleaxe made out of Silver";
			component5.m_itemData.m_shared.m_maxDurability = 200f;
			component5.m_itemData.m_shared.m_durabilityPerLevel = 50f;
			component5.m_itemData.m_shared.m_canBeReparied = true;
			component5.m_itemData.m_shared.m_destroyBroken = false;
			component5.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component5.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component5.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component5.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component5.m_itemData.m_shared.m_damagesPerLevel.m_slash = component5.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component5.m_itemData.m_shared.m_deflectionForcePerLevel = component5.m_itemData.m_shared.m_deflectionForce / 8f;
			component5.m_itemData.m_shared.m_teleportable = true;
			component5.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem5 = new CustomItem(gameObject5, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "forge",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "RoundLog",
						Amount = 10,
						AmountPerLevel = 10
					},
					new RequirementConfig
					{
						Item = "Silver",
						Amount = 30,
						AmountPerLevel = 15
					},
					new RequirementConfig
					{
						Item = "Iron",
						Amount = 2,
						AmountPerLevel = 1
					}
				}
			});
			ItemManager.Instance.AddItem(customItem5);
			GameObject gameObject6 = this.assetBundle.LoadAsset<GameObject>("SpearSilver");
			ItemDrop component6 = gameObject6.GetComponent<ItemDrop>();
			component6.m_itemData.m_dropPrefab = gameObject6;
			component6.m_itemData.m_shared.m_name = "Silver Spear";
			component6.m_itemData.m_shared.m_description = "A Spear made out of Silver";
			component6.m_itemData.m_shared.m_maxDurability = 200f;
			component6.m_itemData.m_shared.m_durabilityPerLevel = 50f;
			component6.m_itemData.m_shared.m_canBeReparied = true;
			component6.m_itemData.m_shared.m_destroyBroken = false;
			component6.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component6.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component6.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component6.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component6.m_itemData.m_shared.m_damagesPerLevel.m_slash = component6.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component6.m_itemData.m_shared.m_deflectionForcePerLevel = component6.m_itemData.m_shared.m_deflectionForce / 8f;
			component6.m_itemData.m_shared.m_teleportable = true;
			component6.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem6 = new CustomItem(gameObject6, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "forge",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "RoundLog",
						Amount = 5,
						AmountPerLevel = 3
					},
					new RequirementConfig
					{
						Item = "Silver",
						Amount = 10,
						AmountPerLevel = 5
					},
					new RequirementConfig
					{
						Item = "WolfPelt",
						Amount = 2,
						AmountPerLevel = 1
					},
					new RequirementConfig
					{
						Item = "Iron",
						Amount = 5,
						AmountPerLevel = 3
					}
				}
			});
			ItemManager.Instance.AddItem(customItem6);
			GameObject gameObject7 = this.assetBundle.LoadAsset<GameObject>("KnifeSilver");
			ItemDrop component7 = gameObject7.GetComponent<ItemDrop>();
			component7.m_itemData.m_dropPrefab = gameObject7;
			component7.m_itemData.m_shared.m_name = "Silver Knife";
			component7.m_itemData.m_shared.m_description = "A Knife made out of Silver";
			component7.m_itemData.m_shared.m_maxDurability = 200f;
			component7.m_itemData.m_shared.m_durabilityPerLevel = 50f;
			component7.m_itemData.m_shared.m_canBeReparied = true;
			component7.m_itemData.m_shared.m_destroyBroken = false;
			component7.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component7.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component7.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component7.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component7.m_itemData.m_shared.m_damagesPerLevel.m_slash = component7.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component7.m_itemData.m_shared.m_deflectionForcePerLevel = component7.m_itemData.m_shared.m_deflectionForce / 8f;
			component7.m_itemData.m_shared.m_teleportable = true;
			component7.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem7 = new CustomItem(gameObject7, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "forge",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "RoundLog",
						Amount = 2,
						AmountPerLevel = 1
					},
					new RequirementConfig
					{
						Item = "Silver",
						Amount = 8,
						AmountPerLevel = 4
					},
					new RequirementConfig
					{
						Item = "Iron",
						Amount = 2,
						AmountPerLevel = 1
					}
				}
			});
			ItemManager.Instance.AddItem(customItem7);
			GameObject gameObject8 = this.assetBundle.LoadAsset<GameObject>("ShieldSilverTower");
			ItemDrop component8 = gameObject8.GetComponent<ItemDrop>();
			component8.m_itemData.m_dropPrefab = gameObject8;
			component8.m_itemData.m_shared.m_name = "Silver Tower Shield";
			component8.m_itemData.m_shared.m_description = "A Tower Shield made out of Silver";
			component8.m_itemData.m_shared.m_maxDurability = 200f;
			component8.m_itemData.m_shared.m_durabilityPerLevel = 50f;
			component8.m_itemData.m_shared.m_canBeReparied = true;
			component8.m_itemData.m_shared.m_destroyBroken = false;
			component8.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component8.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component8.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component8.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component8.m_itemData.m_shared.m_damagesPerLevel.m_slash = component8.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component8.m_itemData.m_shared.m_deflectionForcePerLevel = component8.m_itemData.m_shared.m_deflectionForce / 8f;
			component8.m_itemData.m_shared.m_teleportable = true;
			component8.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem8 = new CustomItem(gameObject8, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "forge",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "RoundLog",
						Amount = 10,
						AmountPerLevel = 5
					},
					new RequirementConfig
					{
						Item = "Silver",
						Amount = 8,
						AmountPerLevel = 4
					},
					new RequirementConfig
					{
						Item = "Iron",
						Amount = 4,
						AmountPerLevel = 2
					}
				}
			});
			ItemManager.Instance.AddItem(customItem8);
			GameObject gameObject9 = this.assetBundle.LoadAsset<GameObject>("AxeSilver");
			ItemDrop component9 = gameObject9.GetComponent<ItemDrop>();
			component9.m_itemData.m_dropPrefab = gameObject9;
			component9.m_itemData.m_shared.m_name = "Silver Axe";
			component9.m_itemData.m_shared.m_description = "An Axe made out of Silver";
			component9.m_itemData.m_shared.m_maxDurability = 200f;
			component9.m_itemData.m_shared.m_durabilityPerLevel = 50f;
			component9.m_itemData.m_shared.m_canBeReparied = true;
			component9.m_itemData.m_shared.m_destroyBroken = false;
			component9.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component9.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component9.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component9.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component9.m_itemData.m_shared.m_damagesPerLevel.m_slash = component9.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component9.m_itemData.m_shared.m_deflectionForcePerLevel = component9.m_itemData.m_shared.m_deflectionForce / 8f;
			component9.m_itemData.m_shared.m_teleportable = true;
			component9.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem9 = new CustomItem(gameObject9, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "forge",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "RoundLog",
						Amount = 4,
						AmountPerLevel = 2
					},
					new RequirementConfig
					{
						Item = "Silver",
						Amount = 20,
						AmountPerLevel = 10
					},
					new RequirementConfig
					{
						Item = "Iron",
						Amount = 2,
						AmountPerLevel = 1
					}
				}
			});
			ItemManager.Instance.AddItem(customItem9);
			GameObject gameObject10 = this.assetBundle.LoadAsset<GameObject>("PickaxeSilver");
			ItemDrop component10 = gameObject10.GetComponent<ItemDrop>();
			component10.m_itemData.m_dropPrefab = gameObject10;
			component10.m_itemData.m_shared.m_name = "Silver Pickaxe";
			component10.m_itemData.m_shared.m_description = "A Pickaxe made out of Silver";
			component10.m_itemData.m_shared.m_maxDurability = 200f;
			component10.m_itemData.m_shared.m_durabilityPerLevel = 50f;
			component10.m_itemData.m_shared.m_canBeReparied = true;
			component10.m_itemData.m_shared.m_destroyBroken = false;
			component10.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component10.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component10.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component10.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component10.m_itemData.m_shared.m_damagesPerLevel.m_slash = component10.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component10.m_itemData.m_shared.m_deflectionForcePerLevel = component10.m_itemData.m_shared.m_deflectionForce / 8f;
			component10.m_itemData.m_shared.m_teleportable = true;
			component10.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem10 = new CustomItem(gameObject10, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "forge",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "RoundLog",
						Amount = 3,
						AmountPerLevel = 2
					},
					new RequirementConfig
					{
						Item = "Silver",
						Amount = 20,
						AmountPerLevel = 10
					},
					new RequirementConfig
					{
						Item = "Iron",
						Amount = 2,
						AmountPerLevel = 2
					}
				}
			});
			ItemManager.Instance.AddItem(customItem10);
		}

		// Token: 0x0600000B RID: 11 RVA: 0x000091A0 File Offset: 0x000073A0
		public void RegisterHeavymetalWeapons()
		{
			GameObject gameObject = this.assetBundle.LoadAsset<GameObject>("BowHeavymetal");
			ItemDrop component = gameObject.GetComponent<ItemDrop>();
			component.m_itemData.m_dropPrefab = gameObject;
			component.m_itemData.m_shared.m_name = "Heavymetal Bow";
			component.m_itemData.m_shared.m_description = "A Bow made out of Heavymetal";
			component.m_itemData.m_shared.m_maxDurability = 250f;
			component.m_itemData.m_shared.m_durabilityPerLevel = 50f;
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
				CraftingStation = "forge",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "RoundLog",
						Amount = 10,
						AmountPerLevel = 5
					},
					new RequirementConfig
					{
						Item = "HeavymetalBar",
						Amount = 20,
						AmountPerLevel = 10
					},
					new RequirementConfig
					{
						Item = "WolfPelt",
						Amount = 2,
						AmountPerLevel = 1
					},
					new RequirementConfig
					{
						Item = "HeatedIronBar",
						Amount = 4,
						AmountPerLevel = 2
					}
				}
			});
			ItemManager.Instance.AddItem(customItem);
			GameObject gameObject2 = this.assetBundle.LoadAsset<GameObject>("ClubHeavymetal");
			ItemDrop component2 = gameObject2.GetComponent<ItemDrop>();
			component2.m_itemData.m_dropPrefab = gameObject2;
			component2.m_itemData.m_shared.m_name = "Heavymetal Club";
			component2.m_itemData.m_shared.m_description = "A Club made out of Heavymetal";
			component2.m_itemData.m_shared.m_maxDurability = 250f;
			component2.m_itemData.m_shared.m_durabilityPerLevel = 50f;
			component2.m_itemData.m_shared.m_canBeReparied = true;
			component2.m_itemData.m_shared.m_destroyBroken = false;
			component2.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component2.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component2.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component2.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component2.m_itemData.m_shared.m_damagesPerLevel.m_slash = component2.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component2.m_itemData.m_shared.m_deflectionForcePerLevel = component2.m_itemData.m_shared.m_deflectionForce / 8f;
			component2.m_itemData.m_shared.m_teleportable = true;
			component2.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem2 = new CustomItem(gameObject2, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "forge",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "HeavymetalBar",
						Amount = 7,
						AmountPerLevel = 4
					},
					new RequirementConfig
					{
						Item = "HeatedIronBar",
						Amount = 4,
						AmountPerLevel = 2
					}
				}
			});
			ItemManager.Instance.AddItem(customItem2);
			GameObject gameObject3 = this.assetBundle.LoadAsset<GameObject>("SledgeHeavymetal");
			ItemDrop component3 = gameObject3.GetComponent<ItemDrop>();
			component3.m_itemData.m_dropPrefab = gameObject3;
			component3.m_itemData.m_shared.m_name = "Heavymetal Sledge";
			component3.m_itemData.m_shared.m_description = "A Sledge made out of Heavymetal";
			component3.m_itemData.m_shared.m_maxDurability = 250f;
			component3.m_itemData.m_shared.m_durabilityPerLevel = 50f;
			component3.m_itemData.m_shared.m_canBeReparied = true;
			component3.m_itemData.m_shared.m_destroyBroken = false;
			component3.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component3.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component3.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component3.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component3.m_itemData.m_shared.m_damagesPerLevel.m_slash = component3.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component3.m_itemData.m_shared.m_deflectionForcePerLevel = component3.m_itemData.m_shared.m_deflectionForce / 8f;
			component3.m_itemData.m_shared.m_teleportable = true;
			component3.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem3 = new CustomItem(gameObject3, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "forge",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "RoundLog",
						Amount = 15,
						AmountPerLevel = 8
					},
					new RequirementConfig
					{
						Item = "HeavymetalBar",
						Amount = 10,
						AmountPerLevel = 5
					},
					new RequirementConfig
					{
						Item = "WolfPelt",
						Amount = 2,
						AmountPerLevel = 1
					},
					new RequirementConfig
					{
						Item = "HeatedIronBar",
						Amount = 4,
						AmountPerLevel = 2
					}
				}
			});
			ItemManager.Instance.AddItem(customItem3);
			GameObject gameObject4 = this.assetBundle.LoadAsset<GameObject>("BattleaxeHeavymetal");
			ItemDrop component4 = gameObject4.GetComponent<ItemDrop>();
			component4.m_itemData.m_dropPrefab = gameObject4;
			component4.m_itemData.m_shared.m_name = "Heavymetal Battleaxe";
			component4.m_itemData.m_shared.m_description = "A Battleaxe made out of Heavymetal";
			component4.m_itemData.m_shared.m_maxDurability = 250f;
			component4.m_itemData.m_shared.m_durabilityPerLevel = 50f;
			component4.m_itemData.m_shared.m_canBeReparied = true;
			component4.m_itemData.m_shared.m_destroyBroken = false;
			component4.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component4.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component4.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component4.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component4.m_itemData.m_shared.m_damagesPerLevel.m_slash = component4.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component4.m_itemData.m_shared.m_deflectionForcePerLevel = component4.m_itemData.m_shared.m_deflectionForce / 8f;
			component4.m_itemData.m_shared.m_teleportable = true;
			component4.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem4 = new CustomItem(gameObject4, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "forge",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "RoundLog",
						Amount = 5,
						AmountPerLevel = 3
					},
					new RequirementConfig
					{
						Item = "HeavymetalBar",
						Amount = 10,
						AmountPerLevel = 5
					},
					new RequirementConfig
					{
						Item = "WolfPelt",
						Amount = 2,
						AmountPerLevel = 1
					},
					new RequirementConfig
					{
						Item = "HeatedIronBar",
						Amount = 5,
						AmountPerLevel = 3
					}
				}
			});
			ItemManager.Instance.AddItem(customItem4);
			GameObject gameObject5 = this.assetBundle.LoadAsset<GameObject>("SpearHeavymetal");
			ItemDrop component5 = gameObject5.GetComponent<ItemDrop>();
			component5.m_itemData.m_dropPrefab = gameObject5;
			component5.m_itemData.m_shared.m_name = "Heavymetal Spear";
			component5.m_itemData.m_shared.m_description = "A Spear made out of Heavymetal";
			component5.m_itemData.m_shared.m_maxDurability = 250f;
			component5.m_itemData.m_shared.m_durabilityPerLevel = 50f;
			component5.m_itemData.m_shared.m_canBeReparied = true;
			component5.m_itemData.m_shared.m_destroyBroken = false;
			component5.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component5.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component5.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component5.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component5.m_itemData.m_shared.m_damagesPerLevel.m_slash = component5.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component5.m_itemData.m_shared.m_deflectionForcePerLevel = component5.m_itemData.m_shared.m_deflectionForce / 8f;
			component5.m_itemData.m_shared.m_teleportable = true;
			component5.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem5 = new CustomItem(gameObject5, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "forge",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "RoundLog",
						Amount = 10,
						AmountPerLevel = 5
					},
					new RequirementConfig
					{
						Item = "HeavymetalBar",
						Amount = 30,
						AmountPerLevel = 15
					},
					new RequirementConfig
					{
						Item = "HeatedIronBar",
						Amount = 2,
						AmountPerLevel = 1
					}
				}
			});
			ItemManager.Instance.AddItem(customItem5);
			GameObject gameObject6 = this.assetBundle.LoadAsset<GameObject>("MaceHeavymetal");
			ItemDrop component6 = gameObject6.GetComponent<ItemDrop>();
			component6.m_itemData.m_dropPrefab = gameObject6;
			component6.m_itemData.m_shared.m_name = "Heavymetal Mace";
			component6.m_itemData.m_shared.m_description = "A Mace made out of Heavymetal";
			component6.m_itemData.m_shared.m_maxDurability = 250f;
			component6.m_itemData.m_shared.m_durabilityPerLevel = 50f;
			component6.m_itemData.m_shared.m_canBeReparied = true;
			component6.m_itemData.m_shared.m_destroyBroken = false;
			component6.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component6.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component6.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component6.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component6.m_itemData.m_shared.m_damagesPerLevel.m_slash = component6.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component6.m_itemData.m_shared.m_deflectionForcePerLevel = component6.m_itemData.m_shared.m_deflectionForce / 8f;
			component6.m_itemData.m_shared.m_teleportable = true;
			component6.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem6 = new CustomItem(gameObject6, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "forge",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "RoundLog",
						Amount = 4,
						AmountPerLevel = 2
					},
					new RequirementConfig
					{
						Item = "HeavymetalBar",
						Amount = 10,
						AmountPerLevel = 5
					},
					new RequirementConfig
					{
						Item = "WolfPelt",
						Amount = 3,
						AmountPerLevel = 2
					},
					new RequirementConfig
					{
						Item = "HeatedIronBar",
						Amount = 4,
						AmountPerLevel = 2
					}
				}
			});
			ItemManager.Instance.AddItem(customItem6);
			GameObject gameObject7 = this.assetBundle.LoadAsset<GameObject>("PickaxeHeavymetal");
			ItemDrop component7 = gameObject7.GetComponent<ItemDrop>();
			component7.m_itemData.m_dropPrefab = gameObject7;
			component7.m_itemData.m_shared.m_name = "Heavymetal Pickaxe";
			component7.m_itemData.m_shared.m_description = "A Pickaxe made out of Heavymetal";
			component7.m_itemData.m_shared.m_maxDurability = 250f;
			component7.m_itemData.m_shared.m_durabilityPerLevel = 50f;
			component7.m_itemData.m_shared.m_canBeReparied = true;
			component7.m_itemData.m_shared.m_destroyBroken = false;
			component7.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component7.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component7.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component7.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component7.m_itemData.m_shared.m_damagesPerLevel.m_slash = component7.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component7.m_itemData.m_shared.m_deflectionForcePerLevel = component7.m_itemData.m_shared.m_deflectionForce / 8f;
			component7.m_itemData.m_shared.m_teleportable = true;
			component7.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem7 = new CustomItem(gameObject7, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "forge",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "RoundLog",
						Amount = 3,
						AmountPerLevel = 3
					},
					new RequirementConfig
					{
						Item = "HeavymetalBar",
						Amount = 20,
						AmountPerLevel = 3
					}
				}
			});
			ItemManager.Instance.AddItem(customItem7);
			GameObject gameObject8 = this.assetBundle.LoadAsset<GameObject>("SledgeaxeHeavymetal");
			ItemDrop component8 = gameObject8.GetComponent<ItemDrop>();
			component8.m_itemData.m_dropPrefab = gameObject8;
			component8.m_itemData.m_shared.m_name = "Heavymetal Sledgeaxe";
			component8.m_itemData.m_shared.m_description = "A Sledgeaxe made out of Heavymetal";
			component8.m_itemData.m_shared.m_maxDurability = 250f;
			component8.m_itemData.m_shared.m_durabilityPerLevel = 50f;
			component8.m_itemData.m_shared.m_canBeReparied = true;
			component8.m_itemData.m_shared.m_destroyBroken = false;
			component8.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component8.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component8.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component8.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component8.m_itemData.m_shared.m_damagesPerLevel.m_slash = component8.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component8.m_itemData.m_shared.m_deflectionForcePerLevel = component8.m_itemData.m_shared.m_deflectionForce / 8f;
			component8.m_itemData.m_shared.m_teleportable = true;
			component8.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem8 = new CustomItem(gameObject8, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "forge",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "SledgeHeavymetal",
						Amount = 1,
						AmountPerLevel = 0
					},
					new RequirementConfig
					{
						Item = "BattleaxeHeavymetal",
						Amount = 1,
						AmountPerLevel = 0
					},
					new RequirementConfig
					{
						Item = "PickaxeHeavymetal",
						Amount = 1,
						AmountPerLevel = 0
					}
				}
			});
			ItemManager.Instance.AddItem(customItem8);
		}

		// Token: 0x0600000C RID: 12 RVA: 0x0000A3A0 File Offset: 0x000085A0
		public void RegisterFrometalWeapons()
		{
			GameObject gameObject = this.assetBundle.LoadAsset<GameObject>("BowFrometal");
			ItemDrop component = gameObject.GetComponent<ItemDrop>();
			component.m_itemData.m_dropPrefab = gameObject;
			component.m_itemData.m_shared.m_name = "Frometal Bow";
			component.m_itemData.m_shared.m_description = "A Bow made out of Frometal";
			component.m_itemData.m_shared.m_maxDurability = 300f;
			component.m_itemData.m_shared.m_durabilityPerLevel = 50f;
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
				CraftingStation = "forge",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "ElderBark",
						Amount = 10,
						AmountPerLevel = 5
					},
					new RequirementConfig
					{
						Item = "FrometalBar",
						Amount = 20,
						AmountPerLevel = 10
					},
					new RequirementConfig
					{
						Item = "LoxPelt",
						Amount = 2,
						AmountPerLevel = 1
					},
					new RequirementConfig
					{
						Item = "HeavymetalBar",
						Amount = 4,
						AmountPerLevel = 2
					}
				}
			});
			ItemManager.Instance.AddItem(customItem);
			GameObject gameObject2 = this.assetBundle.LoadAsset<GameObject>("AtgeirFrometal");
			ItemDrop component2 = gameObject2.GetComponent<ItemDrop>();
			component2.m_itemData.m_dropPrefab = gameObject2;
			component2.m_itemData.m_shared.m_name = "Frometal Atgeir";
			component2.m_itemData.m_shared.m_description = "An Atgeir made out of Frometal";
			component2.m_itemData.m_shared.m_maxDurability = 300f;
			component2.m_itemData.m_shared.m_durabilityPerLevel = 50f;
			component2.m_itemData.m_shared.m_canBeReparied = true;
			component2.m_itemData.m_shared.m_destroyBroken = false;
			component2.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component2.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component2.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component2.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component2.m_itemData.m_shared.m_damagesPerLevel.m_slash = component2.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component2.m_itemData.m_shared.m_deflectionForcePerLevel = component2.m_itemData.m_shared.m_deflectionForce / 8f;
			component2.m_itemData.m_shared.m_teleportable = true;
			component2.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem2 = new CustomItem(gameObject2, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "forge",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "ElderBark",
						Amount = 10,
						AmountPerLevel = 5
					},
					new RequirementConfig
					{
						Item = "FrometalBar",
						Amount = 10,
						AmountPerLevel = 5
					},
					new RequirementConfig
					{
						Item = "LoxPelt",
						Amount = 2,
						AmountPerLevel = 1
					},
					new RequirementConfig
					{
						Item = "HeavymetalBar",
						Amount = 4,
						AmountPerLevel = 2
					}
				}
			});
			ItemManager.Instance.AddItem(customItem2);
			GameObject gameObject3 = this.assetBundle.LoadAsset<GameObject>("ClubFrometal");
			ItemDrop component3 = gameObject3.GetComponent<ItemDrop>();
			component3.m_itemData.m_dropPrefab = gameObject3;
			component3.m_itemData.m_shared.m_name = "Frometal Club";
			component3.m_itemData.m_shared.m_description = "A Club made out of Frometal";
			component3.m_itemData.m_shared.m_maxDurability = 300f;
			component3.m_itemData.m_shared.m_durabilityPerLevel = 50f;
			component3.m_itemData.m_shared.m_canBeReparied = true;
			component3.m_itemData.m_shared.m_destroyBroken = false;
			component3.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component3.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component3.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component3.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component3.m_itemData.m_shared.m_damagesPerLevel.m_slash = component3.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component3.m_itemData.m_shared.m_deflectionForcePerLevel = component3.m_itemData.m_shared.m_deflectionForce / 8f;
			component3.m_itemData.m_shared.m_teleportable = true;
			component3.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem3 = new CustomItem(gameObject3, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "forge",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "FrometalBar",
						Amount = 7,
						AmountPerLevel = 4
					},
					new RequirementConfig
					{
						Item = "HeavymetalBar",
						Amount = 4,
						AmountPerLevel = 2
					}
				}
			});
			ItemManager.Instance.AddItem(customItem3);
			GameObject gameObject4 = this.assetBundle.LoadAsset<GameObject>("SledgeFrometal");
			ItemDrop component4 = gameObject4.GetComponent<ItemDrop>();
			component4.m_itemData.m_dropPrefab = gameObject4;
			component4.m_itemData.m_shared.m_name = "Frometal Sledge";
			component4.m_itemData.m_shared.m_description = "A Sledge made out of Frometal";
			component4.m_itemData.m_shared.m_maxDurability = 300f;
			component4.m_itemData.m_shared.m_durabilityPerLevel = 50f;
			component4.m_itemData.m_shared.m_canBeReparied = true;
			component4.m_itemData.m_shared.m_destroyBroken = false;
			component4.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component4.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component4.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component4.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component4.m_itemData.m_shared.m_damagesPerLevel.m_slash = component4.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component4.m_itemData.m_shared.m_deflectionForcePerLevel = component4.m_itemData.m_shared.m_deflectionForce / 8f;
			component4.m_itemData.m_shared.m_teleportable = true;
			component4.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem4 = new CustomItem(gameObject4, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "forge",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "ElderBark",
						Amount = 15,
						AmountPerLevel = 8
					},
					new RequirementConfig
					{
						Item = "FrometalBar",
						Amount = 10,
						AmountPerLevel = 5
					},
					new RequirementConfig
					{
						Item = "LoxPelt",
						Amount = 2,
						AmountPerLevel = 1
					},
					new RequirementConfig
					{
						Item = "HeavymetalBar",
						Amount = 4,
						AmountPerLevel = 2
					}
				}
			});
			ItemManager.Instance.AddItem(customItem4);
			GameObject gameObject5 = this.assetBundle.LoadAsset<GameObject>("BattleaxeFrometal");
			ItemDrop component5 = gameObject5.GetComponent<ItemDrop>();
			component5.m_itemData.m_dropPrefab = gameObject5;
			component5.m_itemData.m_shared.m_name = "Frometal Battleaxe";
			component5.m_itemData.m_shared.m_description = "A Battleaxe made out of Frometal";
			component5.m_itemData.m_shared.m_maxDurability = 300f;
			component5.m_itemData.m_shared.m_durabilityPerLevel = 50f;
			component5.m_itemData.m_shared.m_canBeReparied = true;
			component5.m_itemData.m_shared.m_destroyBroken = false;
			component5.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component5.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component5.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component5.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component5.m_itemData.m_shared.m_damagesPerLevel.m_slash = component5.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component5.m_itemData.m_shared.m_deflectionForcePerLevel = component5.m_itemData.m_shared.m_deflectionForce / 8f;
			component5.m_itemData.m_shared.m_teleportable = true;
			component5.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem5 = new CustomItem(gameObject5, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "forge",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "ElderBark",
						Amount = 5,
						AmountPerLevel = 3
					},
					new RequirementConfig
					{
						Item = "FrometalBar",
						Amount = 10,
						AmountPerLevel = 5
					},
					new RequirementConfig
					{
						Item = "LoxPelt",
						Amount = 2,
						AmountPerLevel = 1
					},
					new RequirementConfig
					{
						Item = "HeavymetalBar",
						Amount = 5,
						AmountPerLevel = 3
					}
				}
			});
			ItemManager.Instance.AddItem(customItem5);
			GameObject gameObject6 = this.assetBundle.LoadAsset<GameObject>("SpearFrometal");
			ItemDrop component6 = gameObject6.GetComponent<ItemDrop>();
			component6.m_itemData.m_dropPrefab = gameObject6;
			component6.m_itemData.m_shared.m_name = "Frometal Spear";
			component6.m_itemData.m_shared.m_description = "A Spear made out of Frometal";
			component6.m_itemData.m_shared.m_maxDurability = 300f;
			component6.m_itemData.m_shared.m_durabilityPerLevel = 50f;
			component6.m_itemData.m_shared.m_canBeReparied = true;
			component6.m_itemData.m_shared.m_destroyBroken = false;
			component6.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component6.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component6.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component6.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component6.m_itemData.m_shared.m_damagesPerLevel.m_slash = component6.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component6.m_itemData.m_shared.m_deflectionForcePerLevel = component6.m_itemData.m_shared.m_deflectionForce / 8f;
			component6.m_itemData.m_shared.m_teleportable = true;
			component6.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem6 = new CustomItem(gameObject6, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "forge",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "ElderBark",
						Amount = 10,
						AmountPerLevel = 5
					},
					new RequirementConfig
					{
						Item = "FrometalBar",
						Amount = 30,
						AmountPerLevel = 15
					},
					new RequirementConfig
					{
						Item = "HeavymetalBar",
						Amount = 2,
						AmountPerLevel = 1
					}
				}
			});
			ItemManager.Instance.AddItem(customItem6);
			GameObject gameObject7 = this.assetBundle.LoadAsset<GameObject>("KnifeFrometal");
			ItemDrop component7 = gameObject7.GetComponent<ItemDrop>();
			component7.m_itemData.m_dropPrefab = gameObject7;
			component7.m_itemData.m_shared.m_name = "Frometal Knife";
			component7.m_itemData.m_shared.m_description = "A Knife made out of Frometal";
			component7.m_itemData.m_shared.m_maxDurability = 300f;
			component7.m_itemData.m_shared.m_durabilityPerLevel = 50f;
			component7.m_itemData.m_shared.m_canBeReparied = true;
			component7.m_itemData.m_shared.m_destroyBroken = false;
			component7.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component7.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component7.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component7.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component7.m_itemData.m_shared.m_damagesPerLevel.m_slash = component7.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component7.m_itemData.m_shared.m_deflectionForcePerLevel = component7.m_itemData.m_shared.m_deflectionForce / 8f;
			component7.m_itemData.m_shared.m_teleportable = true;
			component7.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem7 = new CustomItem(gameObject7, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "forge",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "ElderBark",
						Amount = 2,
						AmountPerLevel = 1
					},
					new RequirementConfig
					{
						Item = "FrometalBar",
						Amount = 8,
						AmountPerLevel = 4
					},
					new RequirementConfig
					{
						Item = "HeavymetalBar",
						Amount = 2,
						AmountPerLevel = 1
					}
				}
			});
			ItemManager.Instance.AddItem(customItem7);
			GameObject gameObject8 = this.assetBundle.LoadAsset<GameObject>("MaceFrometal");
			ItemDrop component8 = gameObject8.GetComponent<ItemDrop>();
			component8.m_itemData.m_dropPrefab = gameObject8;
			component8.m_itemData.m_shared.m_name = "Frometal Mace";
			component8.m_itemData.m_shared.m_description = "A Mace made out of Frometal";
			component8.m_itemData.m_shared.m_maxDurability = 300f;
			component8.m_itemData.m_shared.m_durabilityPerLevel = 50f;
			component8.m_itemData.m_shared.m_canBeReparied = true;
			component8.m_itemData.m_shared.m_destroyBroken = false;
			component8.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component8.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component8.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component8.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component8.m_itemData.m_shared.m_damagesPerLevel.m_slash = component8.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component8.m_itemData.m_shared.m_deflectionForcePerLevel = component8.m_itemData.m_shared.m_deflectionForce / 8f;
			component8.m_itemData.m_shared.m_teleportable = true;
			component8.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem8 = new CustomItem(gameObject8, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "forge",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "ElderBark",
						Amount = 4,
						AmountPerLevel = 2
					},
					new RequirementConfig
					{
						Item = "FrometalBar",
						Amount = 10,
						AmountPerLevel = 5
					},
					new RequirementConfig
					{
						Item = "LoxPelt",
						Amount = 3,
						AmountPerLevel = 2
					},
					new RequirementConfig
					{
						Item = "HeavymetalBar",
						Amount = 4,
						AmountPerLevel = 2
					}
				}
			});
			ItemManager.Instance.AddItem(customItem8);
			GameObject gameObject9 = this.assetBundle.LoadAsset<GameObject>("SwordFrometal");
			ItemDrop component9 = gameObject9.GetComponent<ItemDrop>();
			component9.m_itemData.m_dropPrefab = gameObject9;
			component9.m_itemData.m_shared.m_name = "Frometal Sword";
			component9.m_itemData.m_shared.m_description = "A Sword made out of Frometal";
			component9.m_itemData.m_shared.m_maxDurability = 300f;
			component9.m_itemData.m_shared.m_durabilityPerLevel = 50f;
			component9.m_itemData.m_shared.m_canBeReparied = true;
			component9.m_itemData.m_shared.m_destroyBroken = false;
			component9.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component9.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component9.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component9.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component9.m_itemData.m_shared.m_damagesPerLevel.m_slash = component9.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component9.m_itemData.m_shared.m_deflectionForcePerLevel = component9.m_itemData.m_shared.m_deflectionForce / 8f;
			component9.m_itemData.m_shared.m_teleportable = true;
			component9.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem9 = new CustomItem(gameObject9, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "forge",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "ElderBark",
						Amount = 4,
						AmountPerLevel = 2
					},
					new RequirementConfig
					{
						Item = "FrometalBar",
						Amount = 10,
						AmountPerLevel = 5
					},
					new RequirementConfig
					{
						Item = "LoxPelt",
						Amount = 3,
						AmountPerLevel = 2
					},
					new RequirementConfig
					{
						Item = "HeavymetalBar",
						Amount = 4,
						AmountPerLevel = 2
					}
				}
			});
			ItemManager.Instance.AddItem(customItem9);
			GameObject gameObject10 = this.assetBundle.LoadAsset<GameObject>("ShieldFrometal");
			ItemDrop component10 = gameObject10.GetComponent<ItemDrop>();
			component10.m_itemData.m_dropPrefab = gameObject10;
			component10.m_itemData.m_shared.m_name = "Frometal Shield";
			component10.m_itemData.m_shared.m_description = "A Shield made out of Frometal";
			component10.m_itemData.m_shared.m_maxDurability = 300f;
			component10.m_itemData.m_shared.m_durabilityPerLevel = 50f;
			component10.m_itemData.m_shared.m_canBeReparied = true;
			component10.m_itemData.m_shared.m_destroyBroken = false;
			component10.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component10.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component10.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component10.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component10.m_itemData.m_shared.m_damagesPerLevel.m_slash = component10.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component10.m_itemData.m_shared.m_deflectionForcePerLevel = component10.m_itemData.m_shared.m_deflectionForce / 8f;
			component10.m_itemData.m_shared.m_teleportable = true;
			component10.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem10 = new CustomItem(gameObject10, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "forge",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "ElderBark",
						Amount = 10,
						AmountPerLevel = 5
					},
					new RequirementConfig
					{
						Item = "FrometalBar",
						Amount = 8,
						AmountPerLevel = 4
					},
					new RequirementConfig
					{
						Item = "HeavymetalBar",
						Amount = 4,
						AmountPerLevel = 2
					}
				}
			});
			ItemManager.Instance.AddItem(customItem10);
			GameObject gameObject11 = this.assetBundle.LoadAsset<GameObject>("ShieldFrometalTower");
			ItemDrop component11 = gameObject11.GetComponent<ItemDrop>();
			component11.m_itemData.m_dropPrefab = gameObject11;
			component11.m_itemData.m_shared.m_name = "Frometal Tower Shield";
			component11.m_itemData.m_shared.m_description = "A Tower Shield made out of Frometal";
			component11.m_itemData.m_shared.m_maxDurability = 300f;
			component11.m_itemData.m_shared.m_durabilityPerLevel = 50f;
			component11.m_itemData.m_shared.m_canBeReparied = true;
			component11.m_itemData.m_shared.m_destroyBroken = false;
			component11.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component11.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component11.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component11.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component11.m_itemData.m_shared.m_damagesPerLevel.m_slash = component11.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component11.m_itemData.m_shared.m_deflectionForcePerLevel = component11.m_itemData.m_shared.m_deflectionForce / 8f;
			component11.m_itemData.m_shared.m_teleportable = true;
			component11.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem11 = new CustomItem(gameObject11, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "forge",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "ElderBark",
						Amount = 10,
						AmountPerLevel = 5
					},
					new RequirementConfig
					{
						Item = "FrometalBar",
						Amount = 8,
						AmountPerLevel = 4
					},
					new RequirementConfig
					{
						Item = "HeavymetalBar",
						Amount = 4,
						AmountPerLevel = 2
					}
				}
			});
			ItemManager.Instance.AddItem(customItem11);
			GameObject gameObject12 = this.assetBundle.LoadAsset<GameObject>("AxeFrometal");
			ItemDrop component12 = gameObject12.GetComponent<ItemDrop>();
			component12.m_itemData.m_dropPrefab = gameObject12;
			component12.m_itemData.m_shared.m_name = "Frometal Axe";
			component12.m_itemData.m_shared.m_description = "An Axe made out of Frometal";
			component12.m_itemData.m_shared.m_maxDurability = 300f;
			component12.m_itemData.m_shared.m_durabilityPerLevel = 50f;
			component12.m_itemData.m_shared.m_canBeReparied = true;
			component12.m_itemData.m_shared.m_destroyBroken = false;
			component12.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component12.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component12.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component12.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component12.m_itemData.m_shared.m_damagesPerLevel.m_slash = component12.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component12.m_itemData.m_shared.m_deflectionForcePerLevel = component12.m_itemData.m_shared.m_deflectionForce / 8f;
			component12.m_itemData.m_shared.m_teleportable = true;
			component12.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem12 = new CustomItem(gameObject12, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "forge",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "ElderBark",
						Amount = 4,
						AmountPerLevel = 2
					},
					new RequirementConfig
					{
						Item = "FrometalBar",
						Amount = 20,
						AmountPerLevel = 10
					},
					new RequirementConfig
					{
						Item = "HeavymetalBar",
						Amount = 2,
						AmountPerLevel = 1
					}
				}
			});
			ItemManager.Instance.AddItem(customItem12);
			GameObject gameObject13 = this.assetBundle.LoadAsset<GameObject>("PickaxeFrometal");
			ItemDrop component13 = gameObject13.GetComponent<ItemDrop>();
			component13.m_itemData.m_dropPrefab = gameObject13;
			component13.m_itemData.m_shared.m_name = "Frometal Pickaxe";
			component13.m_itemData.m_shared.m_description = "A Pickaxe made out of Frometal";
			component13.m_itemData.m_shared.m_maxDurability = 300f;
			component13.m_itemData.m_shared.m_durabilityPerLevel = 50f;
			component13.m_itemData.m_shared.m_canBeReparied = true;
			component13.m_itemData.m_shared.m_destroyBroken = false;
			component13.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component13.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component13.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component13.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component13.m_itemData.m_shared.m_damagesPerLevel.m_slash = component13.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component13.m_itemData.m_shared.m_deflectionForcePerLevel = component13.m_itemData.m_shared.m_deflectionForce / 8f;
			component13.m_itemData.m_shared.m_teleportable = true;
			component13.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem13 = new CustomItem(gameObject13, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "forge",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "ElderBark",
						Amount = 3,
						AmountPerLevel = 2
					},
					new RequirementConfig
					{
						Item = "FrometalBar",
						Amount = 20,
						AmountPerLevel = 10
					},
					new RequirementConfig
					{
						Item = "HeavymetalBar",
						Amount = 2,
						AmountPerLevel = 1
					}
				}
			});
			ItemManager.Instance.AddItem(customItem13);
			GameObject gameObject14 = this.assetBundle.LoadAsset<GameObject>("SledgeaxeFrometal");
			ItemDrop component14 = gameObject14.GetComponent<ItemDrop>();
			component14.m_itemData.m_dropPrefab = gameObject14;
			component14.m_itemData.m_shared.m_name = "Frometal Sledgeaxe";
			component14.m_itemData.m_shared.m_description = "A Sledgeaxe made out of Frometal";
			component14.m_itemData.m_shared.m_maxDurability = 300f;
			component14.m_itemData.m_shared.m_durabilityPerLevel = 50f;
			component14.m_itemData.m_shared.m_canBeReparied = true;
			component14.m_itemData.m_shared.m_destroyBroken = false;
			component14.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component14.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component14.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component14.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component14.m_itemData.m_shared.m_damagesPerLevel.m_slash = component14.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component14.m_itemData.m_shared.m_deflectionForcePerLevel = component14.m_itemData.m_shared.m_deflectionForce / 8f;
			component14.m_itemData.m_shared.m_teleportable = true;
			component14.m_itemData.m_shared.m_maxQuality = 1;
			component14.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem14 = new CustomItem(gameObject14, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "forge",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "SledgeFrometal",
						Amount = 1,
						AmountPerLevel = 0
					},
					new RequirementConfig
					{
						Item = "AxeFrometal",
						Amount = 1,
						AmountPerLevel = 0
					},
					new RequirementConfig
					{
						Item = "PickaxeFrometal",
						Amount = 1,
						AmountPerLevel = 0
					}
				}
			});
			ItemManager.Instance.AddItem(customItem14);
		}

		// Token: 0x0600000D RID: 13 RVA: 0x0000C370 File Offset: 0x0000A570
		public void RegisterFlametalWeapons()
		{
			GameObject gameObject = this.assetBundle.LoadAsset<GameObject>("BowFlametal");
			ItemDrop component = gameObject.GetComponent<ItemDrop>();
			component.m_itemData.m_dropPrefab = gameObject;
			component.m_itemData.m_shared.m_name = "Flametal Bow";
			component.m_itemData.m_shared.m_description = "A Bow made out of Flametal";
			component.m_itemData.m_shared.m_maxDurability = 400f;
			component.m_itemData.m_shared.m_durabilityPerLevel = 75f;
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
				CraftingStation = "forge",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "ElderBark",
						Amount = 10,
						AmountPerLevel = 5
					},
					new RequirementConfig
					{
						Item = "FlametalBar",
						Amount = 20,
						AmountPerLevel = 10
					},
					new RequirementConfig
					{
						Item = "LoxPelt",
						Amount = 2,
						AmountPerLevel = 1
					},
					new RequirementConfig
					{
						Item = "HeavymetalBar",
						Amount = 4,
						AmountPerLevel = 2
					}
				}
			});
			ItemManager.Instance.AddItem(customItem);
			GameObject gameObject2 = this.assetBundle.LoadAsset<GameObject>("AtgeirFlametal");
			ItemDrop component2 = gameObject2.GetComponent<ItemDrop>();
			component2.m_itemData.m_dropPrefab = gameObject2;
			component2.m_itemData.m_shared.m_name = "Flametal Atgeir";
			component2.m_itemData.m_shared.m_description = "An Atgeir made out of Flametal";
			component2.m_itemData.m_shared.m_maxDurability = 400f;
			component2.m_itemData.m_shared.m_durabilityPerLevel = 75f;
			component2.m_itemData.m_shared.m_canBeReparied = true;
			component2.m_itemData.m_shared.m_destroyBroken = false;
			component2.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component2.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component2.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component2.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component2.m_itemData.m_shared.m_damagesPerLevel.m_slash = component2.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component2.m_itemData.m_shared.m_deflectionForcePerLevel = component2.m_itemData.m_shared.m_deflectionForce / 8f;
			component2.m_itemData.m_shared.m_teleportable = true;
			component2.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem2 = new CustomItem(gameObject2, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "forge",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "ElderBark",
						Amount = 10,
						AmountPerLevel = 5
					},
					new RequirementConfig
					{
						Item = "FlametalBar",
						Amount = 10,
						AmountPerLevel = 5
					},
					new RequirementConfig
					{
						Item = "LoxPelt",
						Amount = 2,
						AmountPerLevel = 1
					},
					new RequirementConfig
					{
						Item = "HeavymetalBar",
						Amount = 4,
						AmountPerLevel = 2
					}
				}
			});
			ItemManager.Instance.AddItem(customItem2);
			GameObject gameObject3 = this.assetBundle.LoadAsset<GameObject>("ClubFlametal");
			ItemDrop component3 = gameObject3.GetComponent<ItemDrop>();
			component3.m_itemData.m_dropPrefab = gameObject3;
			component3.m_itemData.m_shared.m_name = "Flametal Club";
			component3.m_itemData.m_shared.m_description = "A Club made out of Flametal";
			component3.m_itemData.m_shared.m_maxDurability = 400f;
			component3.m_itemData.m_shared.m_durabilityPerLevel = 75f;
			component3.m_itemData.m_shared.m_canBeReparied = true;
			component3.m_itemData.m_shared.m_destroyBroken = false;
			component3.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component3.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component3.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component3.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component3.m_itemData.m_shared.m_damagesPerLevel.m_slash = component3.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component3.m_itemData.m_shared.m_deflectionForcePerLevel = component3.m_itemData.m_shared.m_deflectionForce / 8f;
			component3.m_itemData.m_shared.m_teleportable = true;
			component3.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem3 = new CustomItem(gameObject3, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "forge",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "FlametalBar",
						Amount = 7,
						AmountPerLevel = 4
					},
					new RequirementConfig
					{
						Item = "HeavymetalBar",
						Amount = 4,
						AmountPerLevel = 2
					}
				}
			});
			ItemManager.Instance.AddItem(customItem3);
			GameObject gameObject4 = this.assetBundle.LoadAsset<GameObject>("SledgeFlametal");
			ItemDrop component4 = gameObject4.GetComponent<ItemDrop>();
			component4.m_itemData.m_dropPrefab = gameObject4;
			component4.m_itemData.m_shared.m_name = "Flametal Sledge";
			component4.m_itemData.m_shared.m_description = "A Sledge made out of Flametal";
			component4.m_itemData.m_shared.m_maxDurability = 400f;
			component4.m_itemData.m_shared.m_durabilityPerLevel = 75f;
			component4.m_itemData.m_shared.m_canBeReparied = true;
			component4.m_itemData.m_shared.m_destroyBroken = false;
			component4.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component4.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component4.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component4.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component4.m_itemData.m_shared.m_damagesPerLevel.m_slash = component4.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component4.m_itemData.m_shared.m_deflectionForcePerLevel = component4.m_itemData.m_shared.m_deflectionForce / 8f;
			component4.m_itemData.m_shared.m_teleportable = true;
			component4.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem4 = new CustomItem(gameObject4, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "forge",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "ElderBark",
						Amount = 15,
						AmountPerLevel = 8
					},
					new RequirementConfig
					{
						Item = "FlametalBar",
						Amount = 10,
						AmountPerLevel = 15
					},
					new RequirementConfig
					{
						Item = "LoxPelt",
						Amount = 2,
						AmountPerLevel = 1
					},
					new RequirementConfig
					{
						Item = "HeavymetalBar",
						Amount = 4,
						AmountPerLevel = 2
					}
				}
			});
			ItemManager.Instance.AddItem(customItem4);
			GameObject gameObject5 = this.assetBundle.LoadAsset<GameObject>("BattleaxeFlametal");
			ItemDrop component5 = gameObject5.GetComponent<ItemDrop>();
			component5.m_itemData.m_dropPrefab = gameObject5;
			component5.m_itemData.m_shared.m_name = "Flametal Battleaxe";
			component5.m_itemData.m_shared.m_description = "A Battleaxe made out of Flametal";
			component5.m_itemData.m_shared.m_maxDurability = 400f;
			component5.m_itemData.m_shared.m_durabilityPerLevel = 75f;
			component5.m_itemData.m_shared.m_canBeReparied = true;
			component5.m_itemData.m_shared.m_destroyBroken = false;
			component5.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component5.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component5.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component5.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component5.m_itemData.m_shared.m_damagesPerLevel.m_slash = component5.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component5.m_itemData.m_shared.m_deflectionForcePerLevel = component5.m_itemData.m_shared.m_deflectionForce / 8f;
			component5.m_itemData.m_shared.m_teleportable = true;
			component5.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem5 = new CustomItem(gameObject5, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "forge",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "ElderBark",
						Amount = 5,
						AmountPerLevel = 3
					},
					new RequirementConfig
					{
						Item = "FlametalBar",
						Amount = 10,
						AmountPerLevel = 5
					},
					new RequirementConfig
					{
						Item = "LoxPelt",
						Amount = 2,
						AmountPerLevel = 1
					},
					new RequirementConfig
					{
						Item = "HeavymetalBar",
						Amount = 5,
						AmountPerLevel = 3
					}
				}
			});
			ItemManager.Instance.AddItem(customItem5);
			GameObject gameObject6 = this.assetBundle.LoadAsset<GameObject>("SpearFlametal");
			ItemDrop component6 = gameObject6.GetComponent<ItemDrop>();
			component6.m_itemData.m_dropPrefab = gameObject6;
			component6.m_itemData.m_shared.m_name = "Flametal Spear";
			component6.m_itemData.m_shared.m_description = "A Spear made out of Flametal";
			component6.m_itemData.m_shared.m_maxDurability = 400f;
			component6.m_itemData.m_shared.m_durabilityPerLevel = 75f;
			component6.m_itemData.m_shared.m_canBeReparied = true;
			component6.m_itemData.m_shared.m_destroyBroken = false;
			component6.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component6.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component6.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component6.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component6.m_itemData.m_shared.m_damagesPerLevel.m_slash = component6.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component6.m_itemData.m_shared.m_deflectionForcePerLevel = component6.m_itemData.m_shared.m_deflectionForce / 8f;
			component6.m_itemData.m_shared.m_teleportable = true;
			component6.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem6 = new CustomItem(gameObject6, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "forge",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "ElderBark",
						Amount = 10,
						AmountPerLevel = 5
					},
					new RequirementConfig
					{
						Item = "FlametalBar",
						Amount = 30,
						AmountPerLevel = 15
					},
					new RequirementConfig
					{
						Item = "HeavymetalBar",
						Amount = 2,
						AmountPerLevel = 1
					}
				}
			});
			ItemManager.Instance.AddItem(customItem6);
			GameObject gameObject7 = this.assetBundle.LoadAsset<GameObject>("KnifeFlametal");
			ItemDrop component7 = gameObject7.GetComponent<ItemDrop>();
			component7.m_itemData.m_dropPrefab = gameObject7;
			component7.m_itemData.m_shared.m_name = "Flametal Knife";
			component7.m_itemData.m_shared.m_description = "A Knife made out of Flametal";
			component7.m_itemData.m_shared.m_maxDurability = 400f;
			component7.m_itemData.m_shared.m_durabilityPerLevel = 75f;
			component7.m_itemData.m_shared.m_canBeReparied = true;
			component7.m_itemData.m_shared.m_destroyBroken = false;
			component7.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component7.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component7.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component7.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component7.m_itemData.m_shared.m_damagesPerLevel.m_slash = component7.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component7.m_itemData.m_shared.m_deflectionForcePerLevel = component7.m_itemData.m_shared.m_deflectionForce / 8f;
			component7.m_itemData.m_shared.m_teleportable = true;
			component7.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem7 = new CustomItem(gameObject7, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "forge",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "ElderBark",
						Amount = 2,
						AmountPerLevel = 1
					},
					new RequirementConfig
					{
						Item = "FlametalBar",
						Amount = 8,
						AmountPerLevel = 2
					},
					new RequirementConfig
					{
						Item = "HeavymetalBar",
						Amount = 2,
						AmountPerLevel = 1
					}
				}
			});
			ItemManager.Instance.AddItem(customItem7);
			GameObject gameObject8 = this.assetBundle.LoadAsset<GameObject>("MaceFlametal");
			ItemDrop component8 = gameObject8.GetComponent<ItemDrop>();
			component8.m_itemData.m_dropPrefab = gameObject8;
			component8.m_itemData.m_shared.m_name = "Flametal Mace";
			component8.m_itemData.m_shared.m_description = "A Mace made out of Flametal";
			component8.m_itemData.m_shared.m_maxDurability = 400f;
			component8.m_itemData.m_shared.m_durabilityPerLevel = 75f;
			component8.m_itemData.m_shared.m_canBeReparied = true;
			component8.m_itemData.m_shared.m_destroyBroken = false;
			component8.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component8.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component8.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component8.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component8.m_itemData.m_shared.m_damagesPerLevel.m_slash = component8.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component8.m_itemData.m_shared.m_deflectionForcePerLevel = component8.m_itemData.m_shared.m_deflectionForce / 8f;
			component8.m_itemData.m_shared.m_teleportable = true;
			component8.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem8 = new CustomItem(gameObject8, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "forge",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "ElderBark",
						Amount = 4,
						AmountPerLevel = 2
					},
					new RequirementConfig
					{
						Item = "FlametalBar",
						Amount = 10,
						AmountPerLevel = 5
					},
					new RequirementConfig
					{
						Item = "LoxPelt",
						Amount = 3,
						AmountPerLevel = 2
					},
					new RequirementConfig
					{
						Item = "HeavymetalBar",
						Amount = 4,
						AmountPerLevel = 2
					}
				}
			});
			ItemManager.Instance.AddItem(customItem8);
			GameObject gameObject9 = this.assetBundle.LoadAsset<GameObject>("SwordFlametal");
			ItemDrop component9 = gameObject9.GetComponent<ItemDrop>();
			component9.m_itemData.m_dropPrefab = gameObject9;
			component9.m_itemData.m_shared.m_name = "Flametal Sword";
			component9.m_itemData.m_shared.m_description = "A Sword made out of Flametal";
			component9.m_itemData.m_shared.m_maxDurability = 400f;
			component9.m_itemData.m_shared.m_durabilityPerLevel = 75f;
			component9.m_itemData.m_shared.m_canBeReparied = true;
			component9.m_itemData.m_shared.m_destroyBroken = false;
			component9.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component9.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component9.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component9.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component9.m_itemData.m_shared.m_damagesPerLevel.m_slash = component9.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component9.m_itemData.m_shared.m_deflectionForcePerLevel = component9.m_itemData.m_shared.m_deflectionForce / 8f;
			component9.m_itemData.m_shared.m_teleportable = true;
			component9.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem9 = new CustomItem(gameObject9, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "forge",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "ElderBark",
						Amount = 4,
						AmountPerLevel = 2
					},
					new RequirementConfig
					{
						Item = "FlametalBar",
						Amount = 10,
						AmountPerLevel = 5
					},
					new RequirementConfig
					{
						Item = "LoxPelt",
						Amount = 3,
						AmountPerLevel = 2
					},
					new RequirementConfig
					{
						Item = "HeavymetalBar",
						Amount = 4,
						AmountPerLevel = 2
					}
				}
			});
			ItemManager.Instance.AddItem(customItem9);
			GameObject gameObject10 = this.assetBundle.LoadAsset<GameObject>("ShieldFlametal");
			ItemDrop component10 = gameObject10.GetComponent<ItemDrop>();
			component10.m_itemData.m_dropPrefab = gameObject10;
			component10.m_itemData.m_shared.m_name = "Flametal Shield";
			component10.m_itemData.m_shared.m_description = "A Shield made out of Flametal";
			component10.m_itemData.m_shared.m_maxDurability = 400f;
			component10.m_itemData.m_shared.m_durabilityPerLevel = 75f;
			component10.m_itemData.m_shared.m_canBeReparied = true;
			component10.m_itemData.m_shared.m_destroyBroken = false;
			component10.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component10.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component10.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component10.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component10.m_itemData.m_shared.m_damagesPerLevel.m_slash = component10.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component10.m_itemData.m_shared.m_deflectionForcePerLevel = component10.m_itemData.m_shared.m_deflectionForce / 8f;
			component10.m_itemData.m_shared.m_teleportable = true;
			component10.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem10 = new CustomItem(gameObject10, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "forge",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "ElderBark",
						Amount = 10,
						AmountPerLevel = 5
					},
					new RequirementConfig
					{
						Item = "FlametalBar",
						Amount = 8,
						AmountPerLevel = 4
					},
					new RequirementConfig
					{
						Item = "HeavymetalBar",
						Amount = 4,
						AmountPerLevel = 2
					}
				}
			});
			ItemManager.Instance.AddItem(customItem10);
			GameObject gameObject11 = this.assetBundle.LoadAsset<GameObject>("ShieldFlametalTower");
			ItemDrop component11 = gameObject11.GetComponent<ItemDrop>();
			component11.m_itemData.m_dropPrefab = gameObject11;
			component11.m_itemData.m_shared.m_name = "Flametal Tower Shield";
			component11.m_itemData.m_shared.m_description = "A Tower Shield  made out of Flametal";
			component11.m_itemData.m_shared.m_maxDurability = 400f;
			component11.m_itemData.m_shared.m_durabilityPerLevel = 75f;
			component11.m_itemData.m_shared.m_canBeReparied = true;
			component11.m_itemData.m_shared.m_destroyBroken = false;
			component11.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component11.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component11.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component11.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component11.m_itemData.m_shared.m_damagesPerLevel.m_slash = component11.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component11.m_itemData.m_shared.m_deflectionForcePerLevel = component11.m_itemData.m_shared.m_deflectionForce / 8f;
			component11.m_itemData.m_shared.m_teleportable = true;
			component11.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem11 = new CustomItem(gameObject11, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "forge",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "ElderBark",
						Amount = 10,
						AmountPerLevel = 5
					},
					new RequirementConfig
					{
						Item = "FlametalBar",
						Amount = 8,
						AmountPerLevel = 2
					},
					new RequirementConfig
					{
						Item = "HeavymetalBar",
						Amount = 4,
						AmountPerLevel = 2
					}
				}
			});
			ItemManager.Instance.AddItem(customItem11);
			GameObject gameObject12 = this.assetBundle.LoadAsset<GameObject>("AxeFlametal");
			ItemDrop component12 = gameObject12.GetComponent<ItemDrop>();
			component12.m_itemData.m_dropPrefab = gameObject12;
			component12.m_itemData.m_shared.m_name = "Flametal Axe";
			component12.m_itemData.m_shared.m_description = "An Axe made out of Flametal";
			component12.m_itemData.m_shared.m_maxDurability = 400f;
			component12.m_itemData.m_shared.m_durabilityPerLevel = 75f;
			component12.m_itemData.m_shared.m_canBeReparied = true;
			component12.m_itemData.m_shared.m_destroyBroken = false;
			component12.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component12.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component12.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component12.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component12.m_itemData.m_shared.m_damagesPerLevel.m_slash = component12.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component12.m_itemData.m_shared.m_deflectionForcePerLevel = component12.m_itemData.m_shared.m_deflectionForce / 8f;
			component12.m_itemData.m_shared.m_teleportable = true;
			component12.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem12 = new CustomItem(gameObject12, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "forge",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "ElderBark",
						Amount = 4,
						AmountPerLevel = 2
					},
					new RequirementConfig
					{
						Item = "FlametalBar",
						Amount = 20,
						AmountPerLevel = 10
					},
					new RequirementConfig
					{
						Item = "HeavymetalBar",
						Amount = 2,
						AmountPerLevel = 1
					}
				}
			});
			ItemManager.Instance.AddItem(customItem12);
			GameObject gameObject13 = this.assetBundle.LoadAsset<GameObject>("PickaxeFlametal");
			ItemDrop component13 = gameObject13.GetComponent<ItemDrop>();
			component13.m_itemData.m_dropPrefab = gameObject13;
			component13.m_itemData.m_shared.m_name = "Flametal Pickaxe";
			component13.m_itemData.m_shared.m_description = "A Pickaxe made out of Flametal";
			component13.m_itemData.m_shared.m_maxDurability = 400f;
			component13.m_itemData.m_shared.m_durabilityPerLevel = 75f;
			component13.m_itemData.m_shared.m_canBeReparied = true;
			component13.m_itemData.m_shared.m_destroyBroken = false;
			component13.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component13.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component13.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component13.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component13.m_itemData.m_shared.m_damagesPerLevel.m_slash = component13.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component13.m_itemData.m_shared.m_deflectionForcePerLevel = component13.m_itemData.m_shared.m_deflectionForce / 8f;
			component13.m_itemData.m_shared.m_teleportable = true;
			component13.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem13 = new CustomItem(gameObject13, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "forge",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "ElderBark",
						Amount = 3,
						AmountPerLevel = 2
					},
					new RequirementConfig
					{
						Item = "FlametalBar",
						Amount = 20,
						AmountPerLevel = 10
					},
					new RequirementConfig
					{
						Item = "HeavymetalBar",
						Amount = 2,
						AmountPerLevel = 1
					}
				}
			});
			ItemManager.Instance.AddItem(customItem13);
		}

		// Token: 0x0600000E RID: 14 RVA: 0x0000E0F8 File Offset: 0x0000C2F8
		public void RegisterMistmetalWeapons()
		{
			GameObject gameObject = this.assetBundle.LoadAsset<GameObject>("BowMistmetal");
			ItemDrop component = gameObject.GetComponent<ItemDrop>();
			component.m_itemData.m_dropPrefab = gameObject;
			component.m_itemData.m_shared.m_name = "Mistmetal Bow";
			component.m_itemData.m_shared.m_description = "A Bow made out of Mistmetal";
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
				CraftingStation = "piece_artisanstation",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Mistmetal",
						Amount = 8
					}
				}
			});
			ItemManager.Instance.AddItem(customItem);
			GameObject gameObject2 = this.assetBundle.LoadAsset<GameObject>("AtgeirMistmetal");
			ItemDrop component2 = gameObject2.GetComponent<ItemDrop>();
			component2.m_itemData.m_dropPrefab = gameObject2;
			component2.m_itemData.m_shared.m_name = "Mistmetal Atgeir";
			component2.m_itemData.m_shared.m_description = "An Atgeir made out of Mistmetal";
			component2.m_itemData.m_shared.m_maxDurability = 0f;
			component2.m_itemData.m_shared.m_durabilityPerLevel = 0f;
			component2.m_itemData.m_shared.m_canBeReparied = true;
			component2.m_itemData.m_shared.m_destroyBroken = false;
			component2.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component2.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component2.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component2.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component2.m_itemData.m_shared.m_damagesPerLevel.m_slash = component2.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component2.m_itemData.m_shared.m_deflectionForcePerLevel = component2.m_itemData.m_shared.m_deflectionForce / 8f;
			component2.m_itemData.m_shared.m_teleportable = true;
			component2.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem2 = new CustomItem(gameObject2, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "piece_artisanstation",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Mistmetal",
						Amount = 8
					}
				}
			});
			ItemManager.Instance.AddItem(customItem2);
			GameObject gameObject3 = this.assetBundle.LoadAsset<GameObject>("ClubMistmetal");
			ItemDrop component3 = gameObject3.GetComponent<ItemDrop>();
			component3.m_itemData.m_dropPrefab = gameObject3;
			component3.m_itemData.m_shared.m_name = "Mistmetal Club";
			component3.m_itemData.m_shared.m_description = "A Club made out of Mistmetal";
			component3.m_itemData.m_shared.m_maxDurability = 0f;
			component3.m_itemData.m_shared.m_durabilityPerLevel = 0f;
			component3.m_itemData.m_shared.m_canBeReparied = true;
			component3.m_itemData.m_shared.m_destroyBroken = false;
			component3.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component3.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component3.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component3.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component3.m_itemData.m_shared.m_damagesPerLevel.m_slash = component3.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component3.m_itemData.m_shared.m_deflectionForcePerLevel = component3.m_itemData.m_shared.m_deflectionForce / 8f;
			component3.m_itemData.m_shared.m_teleportable = true;
			component3.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem3 = new CustomItem(gameObject3, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "piece_artisanstation",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Mistmetal",
						Amount = 8
					}
				}
			});
			ItemManager.Instance.AddItem(customItem3);
			GameObject gameObject4 = this.assetBundle.LoadAsset<GameObject>("SledgeMistmetal");
			ItemDrop component4 = gameObject4.GetComponent<ItemDrop>();
			component4.m_itemData.m_dropPrefab = gameObject4;
			component4.m_itemData.m_shared.m_name = "Mistmetal Sledge";
			component4.m_itemData.m_shared.m_description = "A Sledge made out of Mistmetal";
			component4.m_itemData.m_shared.m_maxDurability = 0f;
			component4.m_itemData.m_shared.m_durabilityPerLevel = 0f;
			component4.m_itemData.m_shared.m_canBeReparied = true;
			component4.m_itemData.m_shared.m_destroyBroken = false;
			component4.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component4.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component4.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component4.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component4.m_itemData.m_shared.m_damagesPerLevel.m_slash = component4.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component4.m_itemData.m_shared.m_deflectionForcePerLevel = component4.m_itemData.m_shared.m_deflectionForce / 8f;
			component4.m_itemData.m_shared.m_teleportable = true;
			component4.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem4 = new CustomItem(gameObject4, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "piece_artisanstation",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Mistmetal",
						Amount = 8
					}
				}
			});
			ItemManager.Instance.AddItem(customItem4);
			GameObject gameObject5 = this.assetBundle.LoadAsset<GameObject>("SledgeaxeMistmetal");
			ItemDrop component5 = gameObject5.GetComponent<ItemDrop>();
			component5.m_itemData.m_dropPrefab = gameObject5;
			component5.m_itemData.m_shared.m_name = "Mistmetal Sledgeaxe";
			component5.m_itemData.m_shared.m_description = "A Sledgeaxe made out of Mistmetal";
			component5.m_itemData.m_shared.m_maxDurability = 0f;
			component5.m_itemData.m_shared.m_durabilityPerLevel = 0f;
			component5.m_itemData.m_shared.m_canBeReparied = true;
			component5.m_itemData.m_shared.m_destroyBroken = false;
			component5.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component5.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component5.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component5.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component5.m_itemData.m_shared.m_damagesPerLevel.m_slash = component5.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component5.m_itemData.m_shared.m_deflectionForcePerLevel = component5.m_itemData.m_shared.m_deflectionForce / 8f;
			component5.m_itemData.m_shared.m_teleportable = true;
			component5.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem5 = new CustomItem(gameObject5, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "piece_artisanstation",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Mistmetal",
						Amount = 8
					}
				}
			});
			ItemManager.Instance.AddItem(customItem5);
			GameObject gameObject6 = this.assetBundle.LoadAsset<GameObject>("BattleaxeMistmetal");
			ItemDrop component6 = gameObject6.GetComponent<ItemDrop>();
			component6.m_itemData.m_dropPrefab = gameObject6;
			component6.m_itemData.m_shared.m_name = "Mistmetal Battleaxe";
			component6.m_itemData.m_shared.m_description = "A Battleaxe made out of Mistmetal";
			component6.m_itemData.m_shared.m_maxDurability = 0f;
			component6.m_itemData.m_shared.m_durabilityPerLevel = 0f;
			component6.m_itemData.m_shared.m_canBeReparied = true;
			component6.m_itemData.m_shared.m_destroyBroken = false;
			component6.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component6.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component6.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component6.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component6.m_itemData.m_shared.m_damagesPerLevel.m_slash = component6.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component6.m_itemData.m_shared.m_deflectionForcePerLevel = component6.m_itemData.m_shared.m_deflectionForce / 8f;
			component6.m_itemData.m_shared.m_teleportable = true;
			component6.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem6 = new CustomItem(gameObject6, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "piece_artisanstation",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Mistmetal",
						Amount = 8
					}
				}
			});
			ItemManager.Instance.AddItem(customItem6);
			GameObject gameObject7 = this.assetBundle.LoadAsset<GameObject>("SpearMistmetal");
			ItemDrop component7 = gameObject7.GetComponent<ItemDrop>();
			component7.m_itemData.m_dropPrefab = gameObject7;
			component7.m_itemData.m_shared.m_name = "Mistmetal Spear";
			component7.m_itemData.m_shared.m_description = "A Spear made out of Mistmetal";
			component7.m_itemData.m_shared.m_maxDurability = 0f;
			component7.m_itemData.m_shared.m_durabilityPerLevel = 0f;
			component7.m_itemData.m_shared.m_canBeReparied = true;
			component7.m_itemData.m_shared.m_destroyBroken = false;
			component7.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component7.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component7.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component7.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component7.m_itemData.m_shared.m_damagesPerLevel.m_slash = component7.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component7.m_itemData.m_shared.m_deflectionForcePerLevel = component7.m_itemData.m_shared.m_deflectionForce / 8f;
			component7.m_itemData.m_shared.m_teleportable = true;
			component7.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem7 = new CustomItem(gameObject7, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "piece_artisanstation",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Mistmetal",
						Amount = 8
					}
				}
			});
			ItemManager.Instance.AddItem(customItem7);
			GameObject gameObject8 = this.assetBundle.LoadAsset<GameObject>("KnifeMistmetal");
			ItemDrop component8 = gameObject8.GetComponent<ItemDrop>();
			component8.m_itemData.m_dropPrefab = gameObject8;
			component8.m_itemData.m_shared.m_name = "Mistmetal Knife";
			component8.m_itemData.m_shared.m_description = "A Knife made out of Mistmetal";
			component8.m_itemData.m_shared.m_maxDurability = 0f;
			component8.m_itemData.m_shared.m_durabilityPerLevel = 0f;
			component8.m_itemData.m_shared.m_canBeReparied = true;
			component8.m_itemData.m_shared.m_destroyBroken = false;
			component8.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component8.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component8.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component8.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component8.m_itemData.m_shared.m_damagesPerLevel.m_slash = component8.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component8.m_itemData.m_shared.m_deflectionForcePerLevel = component8.m_itemData.m_shared.m_deflectionForce / 8f;
			component8.m_itemData.m_shared.m_teleportable = true;
			component8.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem8 = new CustomItem(gameObject8, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "piece_artisanstation",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Mistmetal",
						Amount = 8
					}
				}
			});
			ItemManager.Instance.AddItem(customItem8);
			GameObject gameObject9 = this.assetBundle.LoadAsset<GameObject>("MaceMistmetal");
			ItemDrop component9 = gameObject9.GetComponent<ItemDrop>();
			component9.m_itemData.m_dropPrefab = gameObject9;
			component9.m_itemData.m_shared.m_name = "Mistmetal Mace";
			component9.m_itemData.m_shared.m_description = "A Mace made out of Mistmetal";
			component9.m_itemData.m_shared.m_maxDurability = 0f;
			component9.m_itemData.m_shared.m_durabilityPerLevel = 0f;
			component9.m_itemData.m_shared.m_canBeReparied = true;
			component9.m_itemData.m_shared.m_destroyBroken = false;
			component9.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component9.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component9.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component9.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component9.m_itemData.m_shared.m_damagesPerLevel.m_slash = component9.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component9.m_itemData.m_shared.m_deflectionForcePerLevel = component9.m_itemData.m_shared.m_deflectionForce / 8f;
			component9.m_itemData.m_shared.m_teleportable = true;
			component9.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem9 = new CustomItem(gameObject9, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "piece_artisanstation",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Mistmetal",
						Amount = 8
					}
				}
			});
			ItemManager.Instance.AddItem(customItem9);
			GameObject gameObject10 = this.assetBundle.LoadAsset<GameObject>("SwordMistmetal");
			ItemDrop component10 = gameObject10.GetComponent<ItemDrop>();
			component10.m_itemData.m_dropPrefab = gameObject10;
			component10.m_itemData.m_shared.m_name = "Mistmetal Sword";
			component10.m_itemData.m_shared.m_description = "A Sword made out of Mistmetal";
			component10.m_itemData.m_shared.m_maxDurability = 0f;
			component10.m_itemData.m_shared.m_durabilityPerLevel = 0f;
			component10.m_itemData.m_shared.m_canBeReparied = true;
			component10.m_itemData.m_shared.m_destroyBroken = false;
			component10.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component10.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component10.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component10.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component10.m_itemData.m_shared.m_damagesPerLevel.m_slash = component10.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component10.m_itemData.m_shared.m_deflectionForcePerLevel = component10.m_itemData.m_shared.m_deflectionForce / 8f;
			component10.m_itemData.m_shared.m_teleportable = true;
			component10.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem10 = new CustomItem(gameObject10, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "piece_artisanstation",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Mistmetal",
						Amount = 8
					}
				}
			});
			ItemManager.Instance.AddItem(customItem10);
			GameObject gameObject11 = this.assetBundle.LoadAsset<GameObject>("ShieldMistmetal");
			ItemDrop component11 = gameObject11.GetComponent<ItemDrop>();
			component11.m_itemData.m_dropPrefab = gameObject11;
			component11.m_itemData.m_shared.m_name = "Mistmetal Shield";
			component11.m_itemData.m_shared.m_description = "A Shield made out of Mistmetal";
			component11.m_itemData.m_shared.m_maxDurability = 0f;
			component11.m_itemData.m_shared.m_durabilityPerLevel = 0f;
			component11.m_itemData.m_shared.m_canBeReparied = true;
			component11.m_itemData.m_shared.m_destroyBroken = false;
			component11.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component11.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component11.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component11.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component11.m_itemData.m_shared.m_damagesPerLevel.m_slash = component11.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component11.m_itemData.m_shared.m_deflectionForcePerLevel = component11.m_itemData.m_shared.m_deflectionForce / 8f;
			component11.m_itemData.m_shared.m_teleportable = true;
			component11.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem11 = new CustomItem(gameObject11, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "piece_artisanstation",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Mistmetal",
						Amount = 8
					}
				}
			});
			ItemManager.Instance.AddItem(customItem11);
			GameObject gameObject12 = this.assetBundle.LoadAsset<GameObject>("ShieldMistmetalTower");
			ItemDrop component12 = gameObject12.GetComponent<ItemDrop>();
			component12.m_itemData.m_dropPrefab = gameObject12;
			component12.m_itemData.m_shared.m_name = "Mistmetal Tower Shield";
			component12.m_itemData.m_shared.m_description = "A Tower Shield made out of Mistmetal";
			component12.m_itemData.m_shared.m_maxDurability = 0f;
			component12.m_itemData.m_shared.m_durabilityPerLevel = 0f;
			component12.m_itemData.m_shared.m_canBeReparied = true;
			component12.m_itemData.m_shared.m_destroyBroken = false;
			component12.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component12.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component12.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component12.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component12.m_itemData.m_shared.m_damagesPerLevel.m_slash = component12.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component12.m_itemData.m_shared.m_deflectionForcePerLevel = component12.m_itemData.m_shared.m_deflectionForce / 8f;
			component12.m_itemData.m_shared.m_teleportable = true;
			component12.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem12 = new CustomItem(gameObject12, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "piece_artisanstation",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Mistmetal",
						Amount = 8
					}
				}
			});
			ItemManager.Instance.AddItem(customItem12);
			GameObject gameObject13 = this.assetBundle.LoadAsset<GameObject>("AxeMistmetal");
			ItemDrop component13 = gameObject13.GetComponent<ItemDrop>();
			component13.m_itemData.m_dropPrefab = gameObject13;
			component13.m_itemData.m_shared.m_name = "Mistmetal Axe";
			component13.m_itemData.m_shared.m_description = "An Axe made out of Frometal";
			component13.m_itemData.m_shared.m_maxDurability = 0f;
			component13.m_itemData.m_shared.m_durabilityPerLevel = 0f;
			component13.m_itemData.m_shared.m_canBeReparied = true;
			component13.m_itemData.m_shared.m_destroyBroken = false;
			component13.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component13.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component13.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component13.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component13.m_itemData.m_shared.m_damagesPerLevel.m_slash = component13.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component13.m_itemData.m_shared.m_deflectionForcePerLevel = component13.m_itemData.m_shared.m_deflectionForce / 8f;
			component13.m_itemData.m_shared.m_teleportable = true;
			component13.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem13 = new CustomItem(gameObject13, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "piece_artisanstation",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Mistmetal",
						Amount = 8
					}
				}
			});
			ItemManager.Instance.AddItem(customItem13);
			GameObject gameObject14 = this.assetBundle.LoadAsset<GameObject>("PickaxeMistmetal");
			ItemDrop component14 = gameObject14.GetComponent<ItemDrop>();
			component14.m_itemData.m_dropPrefab = gameObject14;
			component14.m_itemData.m_shared.m_name = "Mistmetal Pickaxe";
			component14.m_itemData.m_shared.m_description = "A Pickaxe made out of Mistmetal";
			component14.m_itemData.m_shared.m_maxDurability = 0f;
			component14.m_itemData.m_shared.m_durabilityPerLevel = 0f;
			component14.m_itemData.m_shared.m_canBeReparied = true;
			component14.m_itemData.m_shared.m_destroyBroken = false;
			component14.m_itemData.m_shared.m_damagesPerLevel.m_blunt = component14.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component14.m_itemData.m_shared.m_damagesPerLevel.m_pierce = component14.m_itemData.m_shared.m_damages.m_pierce / 2f;
			component14.m_itemData.m_shared.m_damagesPerLevel.m_slash = component14.m_itemData.m_shared.m_damages.m_blunt / 2f;
			component14.m_itemData.m_shared.m_deflectionForcePerLevel = component14.m_itemData.m_shared.m_deflectionForce / 8f;
			component14.m_itemData.m_shared.m_teleportable = true;
			component14.m_itemData.m_shared.m_variants = 0;
			CustomItem customItem14 = new CustomItem(gameObject14, false, new ItemConfig
			{
				Amount = 1,
				CraftingStation = "piece_artisanstation",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Mistmetal",
						Amount = 8
					}
				}
			});
			ItemManager.Instance.AddItem(customItem14);
		}

		// Token: 0x04000001 RID: 1
		public const string PluginGUID = "MrRageous.ValExWeapons";

		// Token: 0x04000002 RID: 2
		public const string PluginName = "ValheimExpanded: Weapons Module";

		// Token: 0x04000003 RID: 3
		public const string PluginVersion = "0.4.1";

		// Token: 0x04000004 RID: 4
		private AssetBundle assetBundle;
	}
}
