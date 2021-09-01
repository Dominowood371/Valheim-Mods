using System;
using System.Reflection;
using BepInEx;
using BepInEx.Configuration;
using Jotunn;
using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;
using Jotunn.Utils;
using UnityEngine;

namespace Fisticuffs
{
	// Token: 0x02000002 RID: 2
	[BepInPlugin("com.zarboz.fisticuffs", "Fisticuffs", "1.1.8")]
	[BepInDependency("com.jotunn.jotunn", BepInDependency.DependencyFlags.HardDependency)]
	[NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Major)]
	internal class Fisticuffs : BaseUnityPlugin
	{
		// Token: 0x06000001 RID: 1 RVA: 0x000020B8 File Offset: 0x000002B8
		private void Awake()
		{
			this.CreateConfigs();
			this.LoadAssets();
			this.BlackMetal();
			this.BronzeCestus();
			this.SilverCestus();
			this.IronCestus();
			this.BoneKnuckle();
			this.WoodKnuckle();
			this.IronChain();
			SynchronizationManager.OnConfigurationSynchronized += delegate(object obj, ConfigurationSynchronizationEventArgs attr)
			{
				if (attr.InitialSynchronization)
				{
					Jotunn.Logger.LogMessage("Initial Config sync event received");
					this.SyncConfigVal();
					return;
				}
				Jotunn.Logger.LogMessage("Config sync event received");
			};
		}

		// Token: 0x06000002 RID: 2 RVA: 0x0000210C File Offset: 0x0000030C
		private void SyncConfigVal()
		{
			if (this.damagealter.Value)
			{
				this.bmetal.ItemDrop.m_itemData.m_shared.m_damages.m_damage = (float)this.damage.Value;
				this.bmetal.ItemDrop.m_itemData.m_shared.m_damages.m_blunt = (float)this.blunt.Value;
				this.bmetal.ItemDrop.m_itemData.m_shared.m_toolTier = this.tier.Value;
				this.bmetal.ItemDrop.m_itemData.m_shared.m_damages.m_slash = (float)this.slashval.Value;
				this.bmetal.ItemDrop.m_itemData.m_shared.m_damages.m_pierce = (float)this.pierce.Value;
				this.bmetal.ItemDrop.m_itemData.m_shared.m_damages.m_chop = (float)this.chop.Value;
				this.bmetal.ItemDrop.m_itemData.m_shared.m_damages.m_pickaxe = (float)this.pickaxe.Value;
				this.bmetal.ItemDrop.m_itemData.m_shared.m_damages.m_fire = (float)this.fire.Value;
				this.bmetal.ItemDrop.m_itemData.m_shared.m_damages.m_frost = (float)this.frost.Value;
				this.bmetal.ItemDrop.m_itemData.m_shared.m_damages.m_lightning = (float)this.lightning.Value;
				this.bmetal.ItemDrop.m_itemData.m_shared.m_damages.m_poison = (float)this.poison.Value;
				this.bmetal.ItemDrop.m_itemData.m_shared.m_damages.m_spirit = (float)this.spirit.Value;
				this.bmetal.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_damage = (float)this.damageper.Value;
				this.bmetal.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_blunt = (float)this.bluntper.Value;
				this.bmetal.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_slash = (float)this.slashper.Value;
				this.bmetal.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pierce = (float)this.pierceper.Value;
				this.bmetal.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_chop = (float)this.chopper.Value;
				this.bmetal.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pickaxe = (float)this.pickaxeper.Value;
				this.bmetal.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_fire = (float)this.fireper.Value;
				this.bmetal.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_frost = (float)this.frostper.Value;
				this.bmetal.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_lightning = (float)this.lightningper.Value;
				this.bmetal.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_poison = (float)this.poisonper.Value;
				this.bmetal.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_spirit = (float)this.spiritper.Value;
				this.bmetal.ItemDrop.m_itemData.m_shared.m_attackForce = (float)this.attackforce.Value;
				this.bcestus.ItemDrop.m_itemData.m_shared.m_damages.m_damage = (float)this.bronzedamage.Value;
				this.bcestus.ItemDrop.m_itemData.m_shared.m_damages.m_blunt = (float)this.bronzeblunt.Value;
				this.bcestus.ItemDrop.m_itemData.m_shared.m_toolTier = this.bronzetier.Value;
				this.bcestus.ItemDrop.m_itemData.m_shared.m_damages.m_slash = (float)this.bronzeslashval.Value;
				this.bcestus.ItemDrop.m_itemData.m_shared.m_damages.m_pierce = (float)this.bronzepierce.Value;
				this.bcestus.ItemDrop.m_itemData.m_shared.m_damages.m_chop = (float)this.bronzechop.Value;
				this.bcestus.ItemDrop.m_itemData.m_shared.m_damages.m_pickaxe = (float)this.bronzepickaxe.Value;
				this.bcestus.ItemDrop.m_itemData.m_shared.m_damages.m_fire = (float)this.bronzefire.Value;
				this.bcestus.ItemDrop.m_itemData.m_shared.m_damages.m_frost = (float)this.bronzefrost.Value;
				this.bcestus.ItemDrop.m_itemData.m_shared.m_damages.m_lightning = (float)this.bronzelightning.Value;
				this.bcestus.ItemDrop.m_itemData.m_shared.m_damages.m_poison = (float)this.bronzepoison.Value;
				this.bcestus.ItemDrop.m_itemData.m_shared.m_damages.m_spirit = (float)this.bronzespirit.Value;
				this.bcestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_damage = (float)this.bronzedamageper.Value;
				this.bcestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_blunt = (float)this.bronzebluntper.Value;
				this.bcestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_slash = (float)this.bronzeslashper.Value;
				this.bcestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pierce = (float)this.bronzepierceper.Value;
				this.bcestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_chop = (float)this.bronzechopper.Value;
				this.bcestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pickaxe = (float)this.bronzepickaxeper.Value;
				this.bcestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_fire = (float)this.bronzefireper.Value;
				this.bcestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_frost = (float)this.bronzefrostper.Value;
				this.bcestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_lightning = (float)this.bronzelightningper.Value;
				this.bcestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_poison = (float)this.bronzepoisonper.Value;
				this.bcestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_spirit = (float)this.bronzespiritper.Value;
				this.bcestus.ItemDrop.m_itemData.m_shared.m_attackForce = (float)this.bronzeattackforce.Value;
				this.silvercestus.ItemDrop.m_itemData.m_shared.m_damages.m_damage = (float)this.silverdamage.Value;
				this.silvercestus.ItemDrop.m_itemData.m_shared.m_damages.m_blunt = (float)this.silverblunt.Value;
				this.silvercestus.ItemDrop.m_itemData.m_shared.m_toolTier = this.silvertier.Value;
				this.silvercestus.ItemDrop.m_itemData.m_shared.m_damages.m_slash = (float)this.silverslashval.Value;
				this.silvercestus.ItemDrop.m_itemData.m_shared.m_damages.m_pierce = (float)this.silverpierce.Value;
				this.silvercestus.ItemDrop.m_itemData.m_shared.m_damages.m_chop = (float)this.silverchop.Value;
				this.silvercestus.ItemDrop.m_itemData.m_shared.m_damages.m_pickaxe = (float)this.silverpickaxe.Value;
				this.silvercestus.ItemDrop.m_itemData.m_shared.m_damages.m_fire = (float)this.silverfire.Value;
				this.silvercestus.ItemDrop.m_itemData.m_shared.m_damages.m_frost = (float)this.silverfrost.Value;
				this.silvercestus.ItemDrop.m_itemData.m_shared.m_damages.m_lightning = (float)this.silverlightning.Value;
				this.silvercestus.ItemDrop.m_itemData.m_shared.m_damages.m_poison = (float)this.silverpoison.Value;
				this.silvercestus.ItemDrop.m_itemData.m_shared.m_damages.m_spirit = (float)this.silverspirit.Value;
				this.silvercestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_damage = (float)this.silverdamageper.Value;
				this.silvercestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_blunt = (float)this.silverbluntper.Value;
				this.silvercestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_slash = (float)this.silverslashper.Value;
				this.silvercestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pierce = (float)this.silverpierceper.Value;
				this.silvercestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_chop = (float)this.silverchopper.Value;
				this.silvercestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pickaxe = (float)this.silverpickaxeper.Value;
				this.silvercestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_fire = (float)this.silverfireper.Value;
				this.silvercestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_frost = (float)this.silverfrostper.Value;
				this.silvercestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_lightning = (float)this.silverlightningper.Value;
				this.silvercestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_poison = (float)this.silverpoisonper.Value;
				this.silvercestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_spirit = (float)this.silverspiritper.Value;
				this.silvercestus.ItemDrop.m_itemData.m_shared.m_attackForce = (float)this.silverattackforce.Value;
				this.ironcestus.ItemDrop.m_itemData.m_shared.m_damages.m_damage = (float)this.irondamage.Value;
				this.ironcestus.ItemDrop.m_itemData.m_shared.m_damages.m_blunt = (float)this.ironblunt.Value;
				this.ironcestus.ItemDrop.m_itemData.m_shared.m_toolTier = this.irontier.Value;
				this.ironcestus.ItemDrop.m_itemData.m_shared.m_damages.m_slash = (float)this.ironslashval.Value;
				this.ironcestus.ItemDrop.m_itemData.m_shared.m_damages.m_pierce = (float)this.ironpierce.Value;
				this.ironcestus.ItemDrop.m_itemData.m_shared.m_damages.m_chop = (float)this.ironchop.Value;
				this.ironcestus.ItemDrop.m_itemData.m_shared.m_damages.m_pickaxe = (float)this.ironpickaxe.Value;
				this.ironcestus.ItemDrop.m_itemData.m_shared.m_damages.m_fire = (float)this.ironfire.Value;
				this.ironcestus.ItemDrop.m_itemData.m_shared.m_damages.m_frost = (float)this.ironfrost.Value;
				this.ironcestus.ItemDrop.m_itemData.m_shared.m_damages.m_lightning = (float)this.ironlightning.Value;
				this.ironcestus.ItemDrop.m_itemData.m_shared.m_damages.m_poison = (float)this.ironpoison.Value;
				this.ironcestus.ItemDrop.m_itemData.m_shared.m_damages.m_spirit = (float)this.ironspirit.Value;
				this.ironcestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_damage = (float)this.irondamageper.Value;
				this.ironcestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_blunt = (float)this.ironbluntper.Value;
				this.ironcestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_slash = (float)this.ironslashper.Value;
				this.ironcestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pierce = (float)this.ironpierceper.Value;
				this.ironcestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_chop = (float)this.ironchopper.Value;
				this.ironcestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pickaxe = (float)this.ironpickaxeper.Value;
				this.ironcestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_fire = (float)this.ironfireper.Value;
				this.ironcestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_frost = (float)this.ironfrostper.Value;
				this.ironcestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_lightning = (float)this.ironlightningper.Value;
				this.ironcestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_poison = (float)this.ironpoisonper.Value;
				this.ironcestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_spirit = (float)this.ironspiritper.Value;
				this.ironcestus.ItemDrop.m_itemData.m_shared.m_attackForce = (float)this.ironattackforce.Value;
				this.boneknuck.ItemDrop.m_itemData.m_shared.m_damages.m_damage = (float)this.bonedamage.Value;
				this.boneknuck.ItemDrop.m_itemData.m_shared.m_damages.m_blunt = (float)this.boneblunt.Value;
				this.boneknuck.ItemDrop.m_itemData.m_shared.m_toolTier = this.bonetier.Value;
				this.boneknuck.ItemDrop.m_itemData.m_shared.m_damages.m_slash = (float)this.boneslashval.Value;
				this.boneknuck.ItemDrop.m_itemData.m_shared.m_damages.m_pierce = (float)this.bonepierce.Value;
				this.boneknuck.ItemDrop.m_itemData.m_shared.m_damages.m_chop = (float)this.bonechop.Value;
				this.boneknuck.ItemDrop.m_itemData.m_shared.m_damages.m_pickaxe = (float)this.bonepickaxe.Value;
				this.boneknuck.ItemDrop.m_itemData.m_shared.m_damages.m_fire = (float)this.bonefire.Value;
				this.boneknuck.ItemDrop.m_itemData.m_shared.m_damages.m_frost = (float)this.bonefrost.Value;
				this.boneknuck.ItemDrop.m_itemData.m_shared.m_damages.m_lightning = (float)this.bonelightning.Value;
				this.boneknuck.ItemDrop.m_itemData.m_shared.m_damages.m_poison = (float)this.bonepoison.Value;
				this.boneknuck.ItemDrop.m_itemData.m_shared.m_damages.m_spirit = (float)this.bonespirit.Value;
				this.boneknuck.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_damage = (float)this.bonedamageper.Value;
				this.boneknuck.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_blunt = (float)this.bonebluntper.Value;
				this.boneknuck.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_slash = (float)this.boneslashper.Value;
				this.boneknuck.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pierce = (float)this.bonepierceper.Value;
				this.boneknuck.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_chop = (float)this.bonechopper.Value;
				this.boneknuck.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pickaxe = (float)this.bonepickaxeper.Value;
				this.boneknuck.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_fire = (float)this.bonefireper.Value;
				this.boneknuck.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_frost = (float)this.bonefrostper.Value;
				this.boneknuck.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_lightning = (float)this.bonelightningper.Value;
				this.boneknuck.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_poison = (float)this.bonepoisonper.Value;
				this.boneknuck.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_spirit = (float)this.bonespiritper.Value;
				this.boneknuck.ItemDrop.m_itemData.m_shared.m_attackForce = (float)this.boneattackforce.Value;
				this.twig.ItemDrop.m_itemData.m_shared.m_damages.m_damage = (float)this.wooddamage.Value;
				this.twig.ItemDrop.m_itemData.m_shared.m_damages.m_blunt = (float)this.woodblunt.Value;
				this.twig.ItemDrop.m_itemData.m_shared.m_toolTier = this.woodtier.Value;
				this.twig.ItemDrop.m_itemData.m_shared.m_damages.m_slash = (float)this.woodslashval.Value;
				this.twig.ItemDrop.m_itemData.m_shared.m_damages.m_pierce = (float)this.woodpierce.Value;
				this.twig.ItemDrop.m_itemData.m_shared.m_damages.m_chop = (float)this.woodchop.Value;
				this.twig.ItemDrop.m_itemData.m_shared.m_damages.m_pickaxe = (float)this.woodpickaxe.Value;
				this.twig.ItemDrop.m_itemData.m_shared.m_damages.m_fire = (float)this.woodfire.Value;
				this.twig.ItemDrop.m_itemData.m_shared.m_damages.m_frost = (float)this.woodfrost.Value;
				this.twig.ItemDrop.m_itemData.m_shared.m_damages.m_lightning = (float)this.woodlightning.Value;
				this.twig.ItemDrop.m_itemData.m_shared.m_damages.m_poison = (float)this.woodpoison.Value;
				this.twig.ItemDrop.m_itemData.m_shared.m_damages.m_spirit = (float)this.woodspirit.Value;
				this.twig.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_damage = (float)this.wooddamageper.Value;
				this.twig.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_blunt = (float)this.woodbluntper.Value;
				this.twig.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_slash = (float)this.woodslashper.Value;
				this.twig.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pierce = (float)this.woodpierceper.Value;
				this.twig.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_chop = (float)this.woodchopper.Value;
				this.twig.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pickaxe = (float)this.woodpickaxeper.Value;
				this.twig.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_fire = (float)this.woodfireper.Value;
				this.twig.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_frost = (float)this.woodfrostper.Value;
				this.twig.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_lightning = (float)this.woodlightningper.Value;
				this.twig.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_poison = (float)this.woodpoisonper.Value;
				this.twig.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_spirit = (float)this.woodspiritper.Value;
				this.twig.ItemDrop.m_itemData.m_shared.m_attackForce = (float)this.woodattackforce.Value;
			}
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00003918 File Offset: 0x00001B18
		private void CreateConfigs()
		{
			base.Config.SaveOnConfigSet = true;
			this.NexusID = base.Config.Bind<int>("FisticuffsConf", "NexusID", 1080, new ConfigDescription("NexusID", new AcceptableValueList<int>(new int[]
			{
				1080
			}), new object[]
			{
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.configBlackmetal = base.Config.Bind<bool>("FisticuffsConf", "BlackMetalEnabled", true, new ConfigDescription("Setting To Enable Black Metal Cestus", null, new object[]
			{
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.Blackmetalcost = base.Config.Bind<int>("FisticuffsConf", "Chain_Cost", 4, new ConfigDescription("Chain Cost for Black Metal Cestus", new AcceptableValueRange<int>(0, 4), new object[]
			{
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.configBronze = base.Config.Bind<bool>("FisticuffsConf", "BronzeCuffEnabled", true, new ConfigDescription("Setting To Enable Bronze Cestus", null, new object[]
			{
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.configIron = base.Config.Bind<bool>("FisticuffsConf", "IronCuffEnabled", true, new ConfigDescription("Setting To Enable Iron Cestus", null, new object[]
			{
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.configSilver = base.Config.Bind<bool>("FisticuffsConf", "SilverCuffEnabled", true, new ConfigDescription("Setting To Enable Silver Cestus", null, new object[]
			{
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.configBone = base.Config.Bind<bool>("FisticuffsConf", "BoneCuffEnabled", true, new ConfigDescription("Setting To Enable Bone Knuckles", null, new object[]
			{
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.configwood = base.Config.Bind<bool>("FisticuffsConf", "twigEnabled", true, new ConfigDescription("Setting To Enable Twig", null, new object[]
			{
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.Chainironcost = base.Config.Bind<int>("FisticuffsConf", "Chain Iron Cost", 5, new ConfigDescription("Iron Cost for Chain", new AcceptableValueRange<int>(0, 10), new object[]
			{
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.configChains = base.Config.Bind<bool>("FisticuffsConf", "Iron Chain Enable", true, new ConfigDescription("Enables Crafting recipe for Iron Chain", null, new object[]
			{
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.damagealter = base.Config.Bind<bool>("FisticuffsConf", "Alter Damage Vals", false, new ConfigDescription("Enables Crafting recipe for Iron Chain", null, new object[]
			{
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			if (this.damagealter.Value)
			{
				this.damage = base.Config.Bind<int>("Black Metal Cuff", "Overall Damage", 0, new ConfigDescription("Overall Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.blunt = base.Config.Bind<int>("Black Metal Cuff", "Blunt Damge", 0, new ConfigDescription("Blunt Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.slashval = base.Config.Bind<int>("Black Metal Cuff", "Slash Damage", 300, new ConfigDescription("Slash Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.pierce = base.Config.Bind<int>("Black Metal Cuff", "Pierce Damge", 135, new ConfigDescription("Pierce Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.chop = base.Config.Bind<int>("Black Metal Cuff", "Chop Damage", 0, new ConfigDescription("Chop Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.pickaxe = base.Config.Bind<int>("Black Metal Cuff", "PickAxe Damage", 0, new ConfigDescription("Pickaxe Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.fire = base.Config.Bind<int>("Black Metal Cuff", "Fire Damage", 0, new ConfigDescription("Fire Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.frost = base.Config.Bind<int>("Black Metal Cuff", "Frost Damage", 0, new ConfigDescription("Frost Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.lightning = base.Config.Bind<int>("Black Metal Cuff", "Lightning Damage", 0, new ConfigDescription("Lightning Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.poison = base.Config.Bind<int>("Black Metal Cuff", "Poison Damage", 250, new ConfigDescription("Poison Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.spirit = base.Config.Bind<int>("Black Metal Cuff", "Spirit Damage", 100, new ConfigDescription("Spirit Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.damageper = base.Config.Bind<int>("Black Metal Cuff", "Overall Damage Per Level", 50, new ConfigDescription("Overall Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.bluntper = base.Config.Bind<int>("Black Metal Cuff", "Blunt Damage Per Level", 50, new ConfigDescription("Blunt Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.slashper = base.Config.Bind<int>("Black Metal Cuff", "Slash Damage Per Level", 50, new ConfigDescription("Slash Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.pierceper = base.Config.Bind<int>("Black Metal Cuff", "Pierce Damage Per Level", 50, new ConfigDescription("Pierce Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.chopper = base.Config.Bind<int>("Black Metal Cuff", "Chop Damage Per Level", 50, new ConfigDescription("Chop Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.pickaxeper = base.Config.Bind<int>("Black Metal Cuff", "PickAxe Damage Per Level", 50, new ConfigDescription("PickAxe Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.fireper = base.Config.Bind<int>("Black Metal Cuff", "Fire Damage Per Level", 50, new ConfigDescription("Fire Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.frostper = base.Config.Bind<int>("Black Metal Cuff", "Frost Damage Per Level", 50, new ConfigDescription("Frost Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.lightningper = base.Config.Bind<int>("Black Metal Cuff", "Lightning Damage Per Level", 50, new ConfigDescription("Lightning Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.poisonper = base.Config.Bind<int>("Black Metal Cuff", "Poison Damage Per Level", 50, new ConfigDescription("Poison Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.spiritper = base.Config.Bind<int>("Black Metal Cuff", "Spirit Damage Per Level", 50, new ConfigDescription("Spirit Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.tier = base.Config.Bind<int>("Black Metal Cuff", "Tool Tier", 5, new ConfigDescription("Tool Tier", new AcceptableValueRange<int>(0, 10), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.attackforce = base.Config.Bind<int>("Black Metal Cuff", "Attack Force", 90, new ConfigDescription("Attack Force", new AcceptableValueRange<int>(0, 100), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.bronzedamage = base.Config.Bind<int>("Bronze Cuff", "Overall Damage", 0, new ConfigDescription("Overall Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.bronzeblunt = base.Config.Bind<int>("Bronze Cuff", "Blunt Damge", 0, new ConfigDescription("Blunt Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.bronzeslashval = base.Config.Bind<int>("Bronze Cuff", "Slash Damage", 300, new ConfigDescription("Slash Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.bronzepierce = base.Config.Bind<int>("Bronze Cuff", "Pierce Damge", 135, new ConfigDescription("Pierce Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.bronzechop = base.Config.Bind<int>("Bronze Cuff", "Chop Damage", 0, new ConfigDescription("Chop Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.bronzepickaxe = base.Config.Bind<int>("Bronze Cuff", "PickAxe Damage", 0, new ConfigDescription("Pickaxe Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.bronzefire = base.Config.Bind<int>("Bronze Cuff", "Fire Damage", 0, new ConfigDescription("Fire Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.bronzefrost = base.Config.Bind<int>("Bronze Cuff", "Frost Damage", 0, new ConfigDescription("Frost Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.bronzelightning = base.Config.Bind<int>("Bronze Cuff", "Lightning Damage", 0, new ConfigDescription("Lightning Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.bronzepoison = base.Config.Bind<int>("Bronze Cuff", "Poison Damage", 250, new ConfigDescription("Poison Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.bronzespirit = base.Config.Bind<int>("Bronze Cuff", "Spirit Damage", 100, new ConfigDescription("Spirit Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.bronzedamageper = base.Config.Bind<int>("Bronze Cuff", "Overall Damage Per Level", 50, new ConfigDescription("Overall Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.bronzebluntper = base.Config.Bind<int>("Bronze Cuff", "Blunt Damage Per Level", 50, new ConfigDescription("Blunt Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.bronzeslashper = base.Config.Bind<int>("Bronze Cuff", "Slash Damage Per Level", 50, new ConfigDescription("Slash Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.bronzepierceper = base.Config.Bind<int>("Bronze Cuff", "Pierce Damage Per Level", 50, new ConfigDescription("Pierce Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.bronzechopper = base.Config.Bind<int>("Bronze Cuff", "Chop Damage Per Level", 50, new ConfigDescription("Chop Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.bronzepickaxeper = base.Config.Bind<int>("Bronze Cuff", "PickAxe Damage Per Level", 50, new ConfigDescription("PickAxe Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.bronzefireper = base.Config.Bind<int>("Bronze Cuff", "Fire Damage Per Level", 50, new ConfigDescription("Fire Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.bronzefrostper = base.Config.Bind<int>("Bronze Cuff", "Frost Damage Per Level", 50, new ConfigDescription("Frost Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.bronzelightningper = base.Config.Bind<int>("Bronze Cuff", "Lightning Damage Per Level", 50, new ConfigDescription("Lightning Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.bronzepoisonper = base.Config.Bind<int>("Bronze Cuff", "Poison Damage Per Level", 50, new ConfigDescription("Poison Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.bronzespiritper = base.Config.Bind<int>("Bronze Cuff", "Spirit Damage Per Level", 50, new ConfigDescription("Spirit Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.bronzetier = base.Config.Bind<int>("Bronze Cuff", "Tool Tier", 5, new ConfigDescription("Tool Tier", new AcceptableValueRange<int>(0, 10), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.bronzeattackforce = base.Config.Bind<int>("Bronze Cuff", "Attack Force", 90, new ConfigDescription("Attack Force", new AcceptableValueRange<int>(0, 100), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.irondamage = base.Config.Bind<int>("Iron Cuff", "Overall Damage", 0, new ConfigDescription("Overall Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.ironblunt = base.Config.Bind<int>("Iron Cuff", "Blunt Damge", 0, new ConfigDescription("Blunt Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.ironslashval = base.Config.Bind<int>("Iron Cuff", "Slash Damage", 300, new ConfigDescription("Slash Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.ironpierce = base.Config.Bind<int>("Iron Cuff", "Pierce Damge", 135, new ConfigDescription("Pierce Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.ironchop = base.Config.Bind<int>("Iron Cuff", "Chop Damage", 0, new ConfigDescription("Chop Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.ironpickaxe = base.Config.Bind<int>("Iron Cuff", "PickAxe Damage", 0, new ConfigDescription("Pickaxe Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.ironfire = base.Config.Bind<int>("Iron Cuff", "Fire Damage", 0, new ConfigDescription("Fire Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.ironfrost = base.Config.Bind<int>("Iron Cuff", "Frost Damage", 0, new ConfigDescription("Frost Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.ironlightning = base.Config.Bind<int>("Iron Cuff", "Lightning Damage", 0, new ConfigDescription("Lightning Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.ironpoison = base.Config.Bind<int>("Iron Cuff", "Poison Damage", 250, new ConfigDescription("Poison Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.ironspirit = base.Config.Bind<int>("Iron Cuff", "Spirit Damage", 100, new ConfigDescription("Spirit Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.irondamageper = base.Config.Bind<int>("Iron Cuff", "Overall Damage Per Level", 50, new ConfigDescription("Overall Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.ironbluntper = base.Config.Bind<int>("Iron Cuff", "Blunt Damage Per Level", 50, new ConfigDescription("Blunt Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.ironslashper = base.Config.Bind<int>("Iron Cuff", "Slash Damage Per Level", 50, new ConfigDescription("Slash Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.ironpierceper = base.Config.Bind<int>("Iron Cuff", "Pierce Damage Per Level", 50, new ConfigDescription("Pierce Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.ironchopper = base.Config.Bind<int>("Iron Cuff", "Chop Damage Per Level", 50, new ConfigDescription("Chop Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.ironpickaxeper = base.Config.Bind<int>("Iron Cuff", "PickAxe Damage Per Level", 50, new ConfigDescription("PickAxe Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.ironfireper = base.Config.Bind<int>("Iron Cuff", "Fire Damage Per Level", 50, new ConfigDescription("Fire Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.ironfrostper = base.Config.Bind<int>("Iron Cuff", "Frost Damage Per Level", 50, new ConfigDescription("Frost Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.ironlightningper = base.Config.Bind<int>("Iron Cuff", "Lightning Damage Per Level", 50, new ConfigDescription("Lightning Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.ironpoisonper = base.Config.Bind<int>("Iron Cuff", "Poison Damage Per Level", 50, new ConfigDescription("Poison Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.ironspiritper = base.Config.Bind<int>("Iron Cuff", "Spirit Damage Per Level", 50, new ConfigDescription("Spirit Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.irontier = base.Config.Bind<int>("Iron Cuff", "Tool Tier", 5, new ConfigDescription("Tool Tier", new AcceptableValueRange<int>(0, 10), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.ironattackforce = base.Config.Bind<int>("Iron Cuff", "Attack Force", 90, new ConfigDescription("Attack Force", new AcceptableValueRange<int>(0, 100), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.silverdamage = base.Config.Bind<int>("Silver Cuff", "Overall Damage", 0, new ConfigDescription("Overall Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.silverblunt = base.Config.Bind<int>("Silver Cuff", "Blunt Damge", 0, new ConfigDescription("Blunt Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.silverslashval = base.Config.Bind<int>("Silver Cuff", "Slash Damage", 300, new ConfigDescription("Slash Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.silverpierce = base.Config.Bind<int>("Silver Cuff", "Pierce Damge", 135, new ConfigDescription("Pierce Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.silverchop = base.Config.Bind<int>("Silver Cuff", "Chop Damage", 0, new ConfigDescription("Chop Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.silverpickaxe = base.Config.Bind<int>("Silver Cuff", "PickAxe Damage", 0, new ConfigDescription("Pickaxe Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.silverfire = base.Config.Bind<int>("Silver Cuff", "Fire Damage", 0, new ConfigDescription("Fire Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.silverfrost = base.Config.Bind<int>("Silver Cuff", "Frost Damage", 0, new ConfigDescription("Frost Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.silverlightning = base.Config.Bind<int>("Silver Cuff", "Lightning Damage", 0, new ConfigDescription("Lightning Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.silverpoison = base.Config.Bind<int>("Silver Cuff", "Poison Damage", 250, new ConfigDescription("Poison Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.silverspirit = base.Config.Bind<int>("Silver Cuff", "Spirit Damage", 100, new ConfigDescription("Spirit Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.silverdamageper = base.Config.Bind<int>("Silver Cuff", "Overall Damage Per Level", 50, new ConfigDescription("Overall Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.silverbluntper = base.Config.Bind<int>("Silver Cuff", "Blunt Damage Per Level", 50, new ConfigDescription("Blunt Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.silverslashper = base.Config.Bind<int>("Silver Cuff", "Slash Damage Per Level", 50, new ConfigDescription("Slash Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.silverpierceper = base.Config.Bind<int>("Silver Cuff", "Pierce Damage Per Level", 50, new ConfigDescription("Pierce Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.silverchopper = base.Config.Bind<int>("Silver Cuff", "Chop Damage Per Level", 50, new ConfigDescription("Chop Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.silverpickaxeper = base.Config.Bind<int>("Silver Cuff", "PickAxe Damage Per Level", 50, new ConfigDescription("PickAxe Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.silverfireper = base.Config.Bind<int>("Silver Cuff", "Fire Damage Per Level", 50, new ConfigDescription("Fire Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.silverfrostper = base.Config.Bind<int>("Silver Cuff", "Frost Damage Per Level", 50, new ConfigDescription("Frost Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.silverlightningper = base.Config.Bind<int>("Silver Cuff", "Lightning Damage Per Level", 50, new ConfigDescription("Lightning Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.silverpoisonper = base.Config.Bind<int>("Silver Cuff", "Poison Damage Per Level", 50, new ConfigDescription("Poison Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.silverspiritper = base.Config.Bind<int>("Silver Cuff", "Spirit Damage Per Level", 50, new ConfigDescription("Spirit Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.silvertier = base.Config.Bind<int>("Silver Cuff", "Tool Tier", 5, new ConfigDescription("Tool Tier", new AcceptableValueRange<int>(0, 10), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.silverattackforce = base.Config.Bind<int>("Silver Cuff", "Attack Force", 90, new ConfigDescription("Attack Force", new AcceptableValueRange<int>(0, 100), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.bonedamage = base.Config.Bind<int>("Bone Cuff", "Overall Damage", 0, new ConfigDescription("Overall Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.boneblunt = base.Config.Bind<int>("Bone Cuff", "Blunt Damge", 0, new ConfigDescription("Blunt Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.boneslashval = base.Config.Bind<int>("Bone Cuff", "Slash Damage", 300, new ConfigDescription("Slash Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.bonepierce = base.Config.Bind<int>("Bone Cuff", "Pierce Damge", 135, new ConfigDescription("Pierce Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.bonechop = base.Config.Bind<int>("Bone Cuff", "Chop Damage", 0, new ConfigDescription("Chop Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.bonepickaxe = base.Config.Bind<int>("Bone Cuff", "PickAxe Damage", 0, new ConfigDescription("Pickaxe Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.bonefire = base.Config.Bind<int>("Bone Cuff", "Fire Damage", 0, new ConfigDescription("Fire Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.bonefrost = base.Config.Bind<int>("Bone Cuff", "Frost Damage", 0, new ConfigDescription("Frost Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.bonelightning = base.Config.Bind<int>("Bone Cuff", "Lightning Damage", 0, new ConfigDescription("Lightning Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.bonepoison = base.Config.Bind<int>("Bone Cuff", "Poison Damage", 250, new ConfigDescription("Poison Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.bonespirit = base.Config.Bind<int>("Bone Cuff", "Spirit Damage", 100, new ConfigDescription("Spirit Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.bonedamageper = base.Config.Bind<int>("Bone Cuff", "Overall Damage Per Level", 50, new ConfigDescription("Overall Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.bonebluntper = base.Config.Bind<int>("Bone Cuff", "Blunt Damage Per Level", 50, new ConfigDescription("Blunt Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.boneslashper = base.Config.Bind<int>("Bone Cuff", "Slash Damage Per Level", 50, new ConfigDescription("Slash Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.bonepierceper = base.Config.Bind<int>("Bone Cuff", "Pierce Damage Per Level", 50, new ConfigDescription("Pierce Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.bonechopper = base.Config.Bind<int>("Bone Cuff", "Chop Damage Per Level", 50, new ConfigDescription("Chop Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.bonepickaxeper = base.Config.Bind<int>("Bone Cuff", "PickAxe Damage Per Level", 50, new ConfigDescription("PickAxe Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.bonefireper = base.Config.Bind<int>("Bone Cuff", "Fire Damage Per Level", 50, new ConfigDescription("Fire Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.bonefrostper = base.Config.Bind<int>("Bone Cuff", "Frost Damage Per Level", 50, new ConfigDescription("Frost Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.bonelightningper = base.Config.Bind<int>("Bone Cuff", "Lightning Damage Per Level", 50, new ConfigDescription("Lightning Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.bonepoisonper = base.Config.Bind<int>("Bone Cuff", "Poison Damage Per Level", 50, new ConfigDescription("Poison Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.bonespiritper = base.Config.Bind<int>("Bone Cuff", "Spirit Damage Per Level", 50, new ConfigDescription("Spirit Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.bonetier = base.Config.Bind<int>("Bone Cuff", "Tool Tier", 5, new ConfigDescription("Tool Tier", new AcceptableValueRange<int>(0, 10), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.boneattackforce = base.Config.Bind<int>("Bone Cuff", "Attack Force", 90, new ConfigDescription("Attack Force", new AcceptableValueRange<int>(0, 100), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.wooddamage = base.Config.Bind<int>("Wood Cuff", "Overall Damage", 0, new ConfigDescription("Overall Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.woodblunt = base.Config.Bind<int>("Wood Cuff", "Blunt Damge", 0, new ConfigDescription("Blunt Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.woodslashval = base.Config.Bind<int>("Wood Cuff", "Slash Damage", 300, new ConfigDescription("Slash Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.woodpierce = base.Config.Bind<int>("Wood Cuff", "Pierce Damge", 135, new ConfigDescription("Pierce Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.woodchop = base.Config.Bind<int>("Wood Cuff", "Chop Damage", 0, new ConfigDescription("Chop Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.woodpickaxe = base.Config.Bind<int>("Wood Cuff", "PickAxe Damage", 0, new ConfigDescription("Pickaxe Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.woodfire = base.Config.Bind<int>("Wood Cuff", "Fire Damage", 0, new ConfigDescription("Fire Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.woodfrost = base.Config.Bind<int>("Wood Cuff", "Frost Damage", 0, new ConfigDescription("Frost Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.woodlightning = base.Config.Bind<int>("Wood Cuff", "Lightning Damage", 0, new ConfigDescription("Lightning Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.woodpoison = base.Config.Bind<int>("Wood Cuff", "Poison Damage", 250, new ConfigDescription("Poison Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.woodspirit = base.Config.Bind<int>("Wood Cuff", "Spirit Damage", 100, new ConfigDescription("Spirit Damage", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.wooddamageper = base.Config.Bind<int>("Wood Cuff", "Overall Damage Per Level", 50, new ConfigDescription("Overall Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.woodbluntper = base.Config.Bind<int>("Wood Cuff", "Blunt Damage Per Level", 50, new ConfigDescription("Blunt Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.woodslashper = base.Config.Bind<int>("Wood Cuff", "Slash Damage Per Level", 50, new ConfigDescription("Slash Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.woodpierceper = base.Config.Bind<int>("Wood Cuff", "Pierce Damage Per Level", 50, new ConfigDescription("Pierce Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.woodchopper = base.Config.Bind<int>("Wood Cuff", "Chop Damage Per Level", 50, new ConfigDescription("Chop Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.woodpickaxeper = base.Config.Bind<int>("Wood Cuff", "PickAxe Damage Per Level", 50, new ConfigDescription("PickAxe Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.woodfireper = base.Config.Bind<int>("Wood Cuff", "Fire Damage Per Level", 50, new ConfigDescription("Fire Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.woodfrostper = base.Config.Bind<int>("Wood Cuff", "Frost Damage Per Level", 50, new ConfigDescription("Frost Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.woodlightningper = base.Config.Bind<int>("Wood Cuff", "Lightning Damage Per Level", 50, new ConfigDescription("Lightning Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.woodpoisonper = base.Config.Bind<int>("Wood Cuff", "Poison Damage Per Level", 50, new ConfigDescription("Poison Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.woodspiritper = base.Config.Bind<int>("Wood Cuff", "Spirit Damage Per Level", 50, new ConfigDescription("Spirit Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.woodtier = base.Config.Bind<int>("Wood Cuff", "Tool Tier", 5, new ConfigDescription("Tool Tier", new AcceptableValueRange<int>(0, 10), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
				this.woodattackforce = base.Config.Bind<int>("Wood Cuff", "Attack Force", 90, new ConfigDescription("Attack Force", new AcceptableValueRange<int>(0, 100), new object[]
				{
					null,
					new ConfigurationManagerAttributes
					{
						IsAdminOnly = true
					}
				}));
			}
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002050 File Offset: 0x00000250
		private void LoadAssets()
		{
			Jotunn.Logger.LogInfo("Embedded resources: " + string.Join(",", Assembly.GetExecutingAssembly().GetManifestResourceNames()));
			this.fisticuffsassets = AssetUtils.LoadAssetBundleFromResources("valheim-brawler", Assembly.GetExecutingAssembly());
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000063CC File Offset: 0x000045CC
		private void BlackMetal()
		{
			GameObject itemPrefab = this.fisticuffsassets.LoadAsset<GameObject>("BlackMetalCestus");
			this.bmetal = new CustomItem(itemPrefab, true, new ItemConfig
			{
				Amount = 1,
				Name = "$item_blackmetalcestus_name",
				Description = "$item_blackmetalcestus_desc",
				Enabled = this.configBlackmetal.Value,
				CraftingStation = "forge",
				MinStationLevel = 4,
				RepairStation = "forge",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "LeatherScraps",
						Amount = 1,
						AmountPerLevel = 5
					},
					new RequirementConfig
					{
						Item = "BlackMetal",
						Amount = 1,
						AmountPerLevel = 5
					},
					new RequirementConfig
					{
						Item = "Chain",
						Amount = this.Blackmetalcost.Value,
						AmountPerLevel = 10
					}
				}
			});
			if (this.damagealter.Value)
			{
				this.bmetal.ItemDrop.m_itemData.m_shared.m_maxQuality = 10;
				this.bmetal.ItemDrop.m_itemData.m_shared.m_damages.m_damage = (float)this.damage.Value;
				this.bmetal.ItemDrop.m_itemData.m_shared.m_damages.m_blunt = (float)this.blunt.Value;
				this.bmetal.ItemDrop.m_itemData.m_shared.m_toolTier = this.tier.Value;
				this.bmetal.ItemDrop.m_itemData.m_shared.m_damages.m_slash = (float)this.slashval.Value;
				this.bmetal.ItemDrop.m_itemData.m_shared.m_damages.m_pierce = (float)this.pierce.Value;
				this.bmetal.ItemDrop.m_itemData.m_shared.m_damages.m_chop = (float)this.chop.Value;
				this.bmetal.ItemDrop.m_itemData.m_shared.m_damages.m_pickaxe = (float)this.pickaxe.Value;
				this.bmetal.ItemDrop.m_itemData.m_shared.m_damages.m_fire = (float)this.fire.Value;
				this.bmetal.ItemDrop.m_itemData.m_shared.m_damages.m_frost = (float)this.frost.Value;
				this.bmetal.ItemDrop.m_itemData.m_shared.m_damages.m_lightning = (float)this.lightning.Value;
				this.bmetal.ItemDrop.m_itemData.m_shared.m_damages.m_poison = (float)this.poison.Value;
				this.bmetal.ItemDrop.m_itemData.m_shared.m_damages.m_spirit = (float)this.spirit.Value;
				this.bmetal.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_damage = (float)this.damageper.Value;
				this.bmetal.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_blunt = (float)this.bluntper.Value;
				this.bmetal.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_slash = (float)this.slashper.Value;
				this.bmetal.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pierce = (float)this.pierceper.Value;
				this.bmetal.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_chop = (float)this.chopper.Value;
				this.bmetal.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pickaxe = (float)this.pickaxeper.Value;
				this.bmetal.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_fire = (float)this.fireper.Value;
				this.bmetal.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_frost = (float)this.frostper.Value;
				this.bmetal.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_lightning = (float)this.lightningper.Value;
				this.bmetal.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_poison = (float)this.poisonper.Value;
				this.bmetal.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_spirit = (float)this.spiritper.Value;
				this.bmetal.ItemDrop.m_itemData.m_shared.m_attackForce = (float)this.attackforce.Value;
			}
			ItemManager.Instance.AddItem(this.bmetal);
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00006900 File Offset: 0x00004B00
		private void BronzeCestus()
		{
			GameObject itemPrefab = this.fisticuffsassets.LoadAsset<GameObject>("BronzeCestus");
			this.bcestus = new CustomItem(itemPrefab, true, new ItemConfig
			{
				Amount = 1,
				Name = "$item_bronzecestus_name",
				Description = "$item_bronzecestus_desc",
				Enabled = this.configBronze.Value,
				CraftingStation = "forge",
				MinStationLevel = 1,
				RepairStation = "forge",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Bronze",
						Amount = 10,
						AmountPerLevel = 3
					},
					new RequirementConfig
					{
						Item = "LeatherScraps",
						Amount = 5,
						AmountPerLevel = 4
					},
					new RequirementConfig
					{
						Item = "Tin",
						Amount = 5,
						AmountPerLevel = 2
					}
				}
			});
			if (this.damagealter.Value)
			{
				this.bcestus.ItemDrop.m_itemData.m_shared.m_maxQuality = 10;
				this.bcestus.ItemDrop.m_itemData.m_shared.m_damages.m_damage = (float)this.bronzedamage.Value;
				this.bcestus.ItemDrop.m_itemData.m_shared.m_damages.m_blunt = (float)this.bronzeblunt.Value;
				this.bcestus.ItemDrop.m_itemData.m_shared.m_toolTier = this.bronzetier.Value;
				this.bcestus.ItemDrop.m_itemData.m_shared.m_damages.m_slash = (float)this.bronzeslashval.Value;
				this.bcestus.ItemDrop.m_itemData.m_shared.m_damages.m_pierce = (float)this.bronzepierce.Value;
				this.bcestus.ItemDrop.m_itemData.m_shared.m_damages.m_chop = (float)this.bronzechop.Value;
				this.bcestus.ItemDrop.m_itemData.m_shared.m_damages.m_pickaxe = (float)this.bronzepickaxe.Value;
				this.bcestus.ItemDrop.m_itemData.m_shared.m_damages.m_fire = (float)this.bronzefire.Value;
				this.bcestus.ItemDrop.m_itemData.m_shared.m_damages.m_frost = (float)this.bronzefrost.Value;
				this.bcestus.ItemDrop.m_itemData.m_shared.m_damages.m_lightning = (float)this.bronzelightning.Value;
				this.bcestus.ItemDrop.m_itemData.m_shared.m_damages.m_poison = (float)this.bronzepoison.Value;
				this.bcestus.ItemDrop.m_itemData.m_shared.m_damages.m_spirit = (float)this.bronzespirit.Value;
				this.bcestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_damage = (float)this.bronzedamageper.Value;
				this.bcestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_blunt = (float)this.bronzebluntper.Value;
				this.bcestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_slash = (float)this.bronzeslashper.Value;
				this.bcestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pierce = (float)this.bronzepierceper.Value;
				this.bcestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_chop = (float)this.bronzechopper.Value;
				this.bcestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pickaxe = (float)this.bronzepickaxeper.Value;
				this.bcestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_fire = (float)this.bronzefireper.Value;
				this.bcestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_frost = (float)this.bronzefrostper.Value;
				this.bcestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_lightning = (float)this.bronzelightningper.Value;
				this.bcestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_poison = (float)this.bronzepoisonper.Value;
				this.bcestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_spirit = (float)this.bronzespiritper.Value;
				this.bcestus.ItemDrop.m_itemData.m_shared.m_attackForce = (float)this.bronzeattackforce.Value;
			}
			ItemManager.Instance.AddItem(this.bcestus);
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00006E28 File Offset: 0x00005028
		private void SilverCestus()
		{
			GameObject itemPrefab = this.fisticuffsassets.LoadAsset<GameObject>("SilverCestus");
			this.silvercestus = new CustomItem(itemPrefab, true, new ItemConfig
			{
				Amount = 1,
				Name = "$item_silvercestus_name",
				Description = "$item_silvercestus_desc",
				Enabled = this.configSilver.Value,
				CraftingStation = "forge",
				MinStationLevel = 4,
				RepairStation = "forge",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "LeatherScraps",
						Amount = 1,
						AmountPerLevel = 2
					},
					new RequirementConfig
					{
						Item = "Silver",
						Amount = 15,
						AmountPerLevel = 10
					}
				}
			});
			if (this.damagealter.Value)
			{
				this.silvercestus.ItemDrop.m_itemData.m_shared.m_maxQuality = 10;
				this.silvercestus.ItemDrop.m_itemData.m_shared.m_damages.m_damage = (float)this.silverdamage.Value;
				this.silvercestus.ItemDrop.m_itemData.m_shared.m_damages.m_blunt = (float)this.silverblunt.Value;
				this.silvercestus.ItemDrop.m_itemData.m_shared.m_toolTier = this.silvertier.Value;
				this.silvercestus.ItemDrop.m_itemData.m_shared.m_damages.m_slash = (float)this.silverslashval.Value;
				this.silvercestus.ItemDrop.m_itemData.m_shared.m_damages.m_pierce = (float)this.silverpierce.Value;
				this.silvercestus.ItemDrop.m_itemData.m_shared.m_damages.m_chop = (float)this.silverchop.Value;
				this.silvercestus.ItemDrop.m_itemData.m_shared.m_damages.m_pickaxe = (float)this.silverpickaxe.Value;
				this.silvercestus.ItemDrop.m_itemData.m_shared.m_damages.m_fire = (float)this.silverfire.Value;
				this.silvercestus.ItemDrop.m_itemData.m_shared.m_damages.m_frost = (float)this.silverfrost.Value;
				this.silvercestus.ItemDrop.m_itemData.m_shared.m_damages.m_lightning = (float)this.silverlightning.Value;
				this.silvercestus.ItemDrop.m_itemData.m_shared.m_damages.m_poison = (float)this.silverpoison.Value;
				this.silvercestus.ItemDrop.m_itemData.m_shared.m_damages.m_spirit = (float)this.silverspirit.Value;
				this.silvercestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_damage = (float)this.silverdamageper.Value;
				this.silvercestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_blunt = (float)this.silverbluntper.Value;
				this.silvercestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_slash = (float)this.silverslashper.Value;
				this.silvercestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pierce = (float)this.silverpierceper.Value;
				this.silvercestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_chop = (float)this.silverchopper.Value;
				this.silvercestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pickaxe = (float)this.silverpickaxeper.Value;
				this.silvercestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_fire = (float)this.silverfireper.Value;
				this.silvercestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_frost = (float)this.silverfrostper.Value;
				this.silvercestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_lightning = (float)this.silverlightningper.Value;
				this.silvercestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_poison = (float)this.silverpoisonper.Value;
				this.silvercestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_spirit = (float)this.silverspiritper.Value;
				this.silvercestus.ItemDrop.m_itemData.m_shared.m_attackForce = (float)this.silverattackforce.Value;
			}
			ItemManager.Instance.AddItem(this.silvercestus);
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00007330 File Offset: 0x00005530
		private void IronCestus()
		{
			GameObject itemPrefab = this.fisticuffsassets.LoadAsset<GameObject>("IronCestus");
			this.ironcestus = new CustomItem(itemPrefab, true, new ItemConfig
			{
				Amount = 1,
				Name = "$item_ironcestus_name",
				Description = "$item_ironcestus_desc",
				Enabled = this.configIron.Value,
				CraftingStation = "forge",
				MinStationLevel = 4,
				RepairStation = "forge",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Iron",
						Amount = 10,
						AmountPerLevel = 5
					},
					new RequirementConfig
					{
						Item = "LeatherScraps",
						Amount = 5,
						AmountPerLevel = 5
					}
				}
			});
			if (this.damagealter.Value)
			{
				this.ironcestus.ItemDrop.m_itemData.m_shared.m_maxQuality = 10;
				this.ironcestus.ItemDrop.m_itemData.m_shared.m_damages.m_damage = (float)this.irondamage.Value;
				this.ironcestus.ItemDrop.m_itemData.m_shared.m_damages.m_blunt = (float)this.ironblunt.Value;
				this.ironcestus.ItemDrop.m_itemData.m_shared.m_toolTier = this.irontier.Value;
				this.ironcestus.ItemDrop.m_itemData.m_shared.m_damages.m_slash = (float)this.ironslashval.Value;
				this.ironcestus.ItemDrop.m_itemData.m_shared.m_damages.m_pierce = (float)this.ironpierce.Value;
				this.ironcestus.ItemDrop.m_itemData.m_shared.m_damages.m_chop = (float)this.ironchop.Value;
				this.ironcestus.ItemDrop.m_itemData.m_shared.m_damages.m_pickaxe = (float)this.ironpickaxe.Value;
				this.ironcestus.ItemDrop.m_itemData.m_shared.m_damages.m_fire = (float)this.ironfire.Value;
				this.ironcestus.ItemDrop.m_itemData.m_shared.m_damages.m_frost = (float)this.ironfrost.Value;
				this.ironcestus.ItemDrop.m_itemData.m_shared.m_damages.m_lightning = (float)this.ironlightning.Value;
				this.ironcestus.ItemDrop.m_itemData.m_shared.m_damages.m_poison = (float)this.ironpoison.Value;
				this.ironcestus.ItemDrop.m_itemData.m_shared.m_damages.m_spirit = (float)this.ironspirit.Value;
				this.ironcestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_damage = (float)this.irondamageper.Value;
				this.ironcestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_blunt = (float)this.ironbluntper.Value;
				this.ironcestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_slash = (float)this.ironslashper.Value;
				this.ironcestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pierce = (float)this.ironpierceper.Value;
				this.ironcestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_chop = (float)this.ironchopper.Value;
				this.ironcestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pickaxe = (float)this.ironpickaxeper.Value;
				this.ironcestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_fire = (float)this.ironfireper.Value;
				this.ironcestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_frost = (float)this.ironfrostper.Value;
				this.ironcestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_lightning = (float)this.ironlightningper.Value;
				this.ironcestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_poison = (float)this.ironpoisonper.Value;
				this.ironcestus.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_spirit = (float)this.ironspiritper.Value;
				this.ironcestus.ItemDrop.m_itemData.m_shared.m_attackForce = (float)this.ironattackforce.Value;
			}
			ItemManager.Instance.AddItem(this.ironcestus);
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00007838 File Offset: 0x00005A38
		private void BoneKnuckle()
		{
			GameObject itemPrefab = this.fisticuffsassets.LoadAsset<GameObject>("StuddedKnuckles");
			this.boneknuck = new CustomItem(itemPrefab, true, new ItemConfig
			{
				Amount = 1,
				Name = "$item_studdedknuckles_name",
				Description = "$item_studdedknuckles_desc",
				Enabled = this.configBone.Value,
				CraftingStation = "piece_workbench",
				MinStationLevel = 2,
				RepairStation = "piece_workbench",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "LeatherScraps",
						Amount = 5,
						AmountPerLevel = 2
					},
					new RequirementConfig
					{
						Item = "BoneFragments",
						Amount = 5,
						AmountPerLevel = 2
					}
				}
			});
			if (this.damagealter.Value)
			{
				this.boneknuck.ItemDrop.m_itemData.m_shared.m_maxQuality = 10;
				this.boneknuck.ItemDrop.m_itemData.m_shared.m_damages.m_damage = (float)this.bonedamage.Value;
				this.boneknuck.ItemDrop.m_itemData.m_shared.m_damages.m_blunt = (float)this.boneblunt.Value;
				this.boneknuck.ItemDrop.m_itemData.m_shared.m_toolTier = this.bonetier.Value;
				this.boneknuck.ItemDrop.m_itemData.m_shared.m_damages.m_slash = (float)this.boneslashval.Value;
				this.boneknuck.ItemDrop.m_itemData.m_shared.m_damages.m_pierce = (float)this.bonepierce.Value;
				this.boneknuck.ItemDrop.m_itemData.m_shared.m_damages.m_chop = (float)this.bonechop.Value;
				this.boneknuck.ItemDrop.m_itemData.m_shared.m_damages.m_pickaxe = (float)this.bonepickaxe.Value;
				this.boneknuck.ItemDrop.m_itemData.m_shared.m_damages.m_fire = (float)this.bonefire.Value;
				this.boneknuck.ItemDrop.m_itemData.m_shared.m_damages.m_frost = (float)this.bonefrost.Value;
				this.boneknuck.ItemDrop.m_itemData.m_shared.m_damages.m_lightning = (float)this.bonelightning.Value;
				this.boneknuck.ItemDrop.m_itemData.m_shared.m_damages.m_poison = (float)this.bonepoison.Value;
				this.boneknuck.ItemDrop.m_itemData.m_shared.m_damages.m_spirit = (float)this.bonespirit.Value;
				this.boneknuck.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_damage = (float)this.bonedamageper.Value;
				this.boneknuck.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_blunt = (float)this.bonebluntper.Value;
				this.boneknuck.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_slash = (float)this.boneslashper.Value;
				this.boneknuck.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pierce = (float)this.bonepierceper.Value;
				this.boneknuck.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_chop = (float)this.bonechopper.Value;
				this.boneknuck.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pickaxe = (float)this.bonepickaxeper.Value;
				this.boneknuck.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_fire = (float)this.bonefireper.Value;
				this.boneknuck.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_frost = (float)this.bonefrostper.Value;
				this.boneknuck.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_lightning = (float)this.bonelightningper.Value;
				this.boneknuck.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_poison = (float)this.bonepoisonper.Value;
				this.boneknuck.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_spirit = (float)this.bonespiritper.Value;
				this.boneknuck.ItemDrop.m_itemData.m_shared.m_attackForce = (float)this.boneattackforce.Value;
			}
			ItemManager.Instance.AddItem(this.boneknuck);
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00007D40 File Offset: 0x00005F40
		private void WoodKnuckle()
		{
			GameObject itemPrefab = this.fisticuffsassets.LoadAsset<GameObject>("WoodKnuckles");
			this.twig = new CustomItem(itemPrefab, true, new ItemConfig
			{
				Amount = 1,
				Name = "$item_woodknuckles_name",
				Description = "$item_woodknuckles_desc",
				Enabled = this.configwood.Value,
				CraftingStation = null,
				MinStationLevel = 2,
				RepairStation = "piece_workbench",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "LeatherScraps",
						Amount = 1
					},
					new RequirementConfig
					{
						Item = "Wood",
						Amount = 1
					}
				}
			});
			if (this.damagealter.Value)
			{
				this.twig.ItemDrop.m_itemData.m_shared.m_maxQuality = 10;
				this.twig.ItemDrop.m_itemData.m_shared.m_damages.m_damage = (float)this.wooddamage.Value;
				this.twig.ItemDrop.m_itemData.m_shared.m_damages.m_blunt = (float)this.woodblunt.Value;
				this.twig.ItemDrop.m_itemData.m_shared.m_toolTier = this.woodtier.Value;
				this.twig.ItemDrop.m_itemData.m_shared.m_damages.m_slash = (float)this.woodslashval.Value;
				this.twig.ItemDrop.m_itemData.m_shared.m_damages.m_pierce = (float)this.woodpierce.Value;
				this.twig.ItemDrop.m_itemData.m_shared.m_damages.m_chop = (float)this.woodchop.Value;
				this.twig.ItemDrop.m_itemData.m_shared.m_damages.m_pickaxe = (float)this.woodpickaxe.Value;
				this.twig.ItemDrop.m_itemData.m_shared.m_damages.m_fire = (float)this.woodfire.Value;
				this.twig.ItemDrop.m_itemData.m_shared.m_damages.m_frost = (float)this.woodfrost.Value;
				this.twig.ItemDrop.m_itemData.m_shared.m_damages.m_lightning = (float)this.woodlightning.Value;
				this.twig.ItemDrop.m_itemData.m_shared.m_damages.m_poison = (float)this.woodpoison.Value;
				this.twig.ItemDrop.m_itemData.m_shared.m_damages.m_spirit = (float)this.woodspirit.Value;
				this.twig.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_damage = (float)this.wooddamageper.Value;
				this.twig.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_blunt = (float)this.woodbluntper.Value;
				this.twig.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_slash = (float)this.woodslashper.Value;
				this.twig.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pierce = (float)this.woodpierceper.Value;
				this.twig.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_chop = (float)this.woodchopper.Value;
				this.twig.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pickaxe = (float)this.woodpickaxeper.Value;
				this.twig.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_fire = (float)this.woodfireper.Value;
				this.twig.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_frost = (float)this.woodfrostper.Value;
				this.twig.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_lightning = (float)this.woodlightningper.Value;
				this.twig.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_poison = (float)this.woodpoisonper.Value;
				this.twig.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_spirit = (float)this.woodspiritper.Value;
				this.twig.ItemDrop.m_itemData.m_shared.m_attackForce = (float)this.woodattackforce.Value;
			}
			ItemManager.Instance.AddItem(this.twig);
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00008234 File Offset: 0x00006434
		private void IronChain()
		{
			CustomRecipe customRecipe = new CustomRecipe(new RecipeConfig
			{
				Item = "Chain",
				Enabled = this.configChains.Value,
				Name = "Chain",
				CraftingStation = "forge",
				RepairStation = "forge",
				MinStationLevel = 1,
				Amount = 5,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Iron",
						Amount = this.Chainironcost.Value
					},
					new RequirementConfig
					{
						Item = "Coal",
						Amount = 2
					}
				}
			});
			ItemManager.Instance.AddRecipe(customRecipe);
		}

		// Token: 0x0600000C RID: 12 RVA: 0x0000208A File Offset: 0x0000028A
		public Fisticuffs()
		{
		}

		// Token: 0x04000001 RID: 1
		public const string PluginGUID = "com.zarboz.fisticuffs";

		// Token: 0x04000002 RID: 2
		public const string PluginName = "Fisticuffs";

		// Token: 0x04000003 RID: 3
		public const string PluginVersion = "1.1.8";

		// Token: 0x04000004 RID: 4
		public new static Jotunn.Logger Logger;

		// Token: 0x04000005 RID: 5
		private AssetBundle fisticuffsassets;

		// Token: 0x04000006 RID: 6
		private ConfigEntry<bool> configBlackmetal;

		// Token: 0x04000007 RID: 7
		private ConfigEntry<int> Blackmetalcost;

		// Token: 0x04000008 RID: 8
		private ConfigEntry<bool> configBronze;

		// Token: 0x04000009 RID: 9
		private ConfigEntry<bool> configIron;

		// Token: 0x0400000A RID: 10
		private ConfigEntry<bool> configSilver;

		// Token: 0x0400000B RID: 11
		private ConfigEntry<bool> configBone;

		// Token: 0x0400000C RID: 12
		private ConfigEntry<bool> configwood;

		// Token: 0x0400000D RID: 13
		private ConfigEntry<bool> configChains;

		// Token: 0x0400000E RID: 14
		private ConfigEntry<bool> damagealter;

		// Token: 0x0400000F RID: 15
		private ConfigEntry<int> damage;

		// Token: 0x04000010 RID: 16
		private ConfigEntry<int> blunt;

		// Token: 0x04000011 RID: 17
		private ConfigEntry<int> slashval;

		// Token: 0x04000012 RID: 18
		private ConfigEntry<int> pierce;

		// Token: 0x04000013 RID: 19
		private ConfigEntry<int> chop;

		// Token: 0x04000014 RID: 20
		private ConfigEntry<int> pickaxe;

		// Token: 0x04000015 RID: 21
		private ConfigEntry<int> Chainironcost;

		// Token: 0x04000016 RID: 22
		private ConfigEntry<int> NexusID;

		// Token: 0x04000017 RID: 23
		private CustomItem bmetal;

		// Token: 0x04000018 RID: 24
		private ConfigEntry<int> fire;

		// Token: 0x04000019 RID: 25
		private ConfigEntry<int> frost;

		// Token: 0x0400001A RID: 26
		private ConfigEntry<int> lightning;

		// Token: 0x0400001B RID: 27
		private ConfigEntry<int> poison;

		// Token: 0x0400001C RID: 28
		private ConfigEntry<int> spirit;

		// Token: 0x0400001D RID: 29
		private ConfigEntry<int> damageper;

		// Token: 0x0400001E RID: 30
		private ConfigEntry<int> bluntper;

		// Token: 0x0400001F RID: 31
		private ConfigEntry<int> slashper;

		// Token: 0x04000020 RID: 32
		private ConfigEntry<int> pierceper;

		// Token: 0x04000021 RID: 33
		private ConfigEntry<int> chopper;

		// Token: 0x04000022 RID: 34
		private ConfigEntry<int> pickaxeper;

		// Token: 0x04000023 RID: 35
		private ConfigEntry<int> fireper;

		// Token: 0x04000024 RID: 36
		private ConfigEntry<int> frostper;

		// Token: 0x04000025 RID: 37
		private ConfigEntry<int> lightningper;

		// Token: 0x04000026 RID: 38
		private ConfigEntry<int> poisonper;

		// Token: 0x04000027 RID: 39
		private ConfigEntry<int> spiritper;

		// Token: 0x04000028 RID: 40
		private ConfigEntry<int> tier;

		// Token: 0x04000029 RID: 41
		private ConfigEntry<int> attackforce;

		// Token: 0x0400002A RID: 42
		private ConfigEntry<int> bronzedamage;

		// Token: 0x0400002B RID: 43
		private ConfigEntry<int> bronzeblunt;

		// Token: 0x0400002C RID: 44
		private ConfigEntry<int> bronzeslashval;

		// Token: 0x0400002D RID: 45
		private ConfigEntry<int> bronzepierce;

		// Token: 0x0400002E RID: 46
		private ConfigEntry<int> bronzechop;

		// Token: 0x0400002F RID: 47
		private ConfigEntry<int> bronzepickaxe;

		// Token: 0x04000030 RID: 48
		private ConfigEntry<int> bronzefire;

		// Token: 0x04000031 RID: 49
		private ConfigEntry<int> bronzefrost;

		// Token: 0x04000032 RID: 50
		private ConfigEntry<int> bronzelightning;

		// Token: 0x04000033 RID: 51
		private ConfigEntry<int> bronzepoison;

		// Token: 0x04000034 RID: 52
		private ConfigEntry<int> bronzespirit;

		// Token: 0x04000035 RID: 53
		private ConfigEntry<int> bronzedamageper;

		// Token: 0x04000036 RID: 54
		private ConfigEntry<int> bronzebluntper;

		// Token: 0x04000037 RID: 55
		private ConfigEntry<int> bronzeslashper;

		// Token: 0x04000038 RID: 56
		private ConfigEntry<int> bronzepierceper;

		// Token: 0x04000039 RID: 57
		private ConfigEntry<int> bronzechopper;

		// Token: 0x0400003A RID: 58
		private ConfigEntry<int> bronzepickaxeper;

		// Token: 0x0400003B RID: 59
		private ConfigEntry<int> bronzefireper;

		// Token: 0x0400003C RID: 60
		private ConfigEntry<int> bronzefrostper;

		// Token: 0x0400003D RID: 61
		private ConfigEntry<int> bronzelightningper;

		// Token: 0x0400003E RID: 62
		private ConfigEntry<int> bronzepoisonper;

		// Token: 0x0400003F RID: 63
		private ConfigEntry<int> bronzespiritper;

		// Token: 0x04000040 RID: 64
		private ConfigEntry<int> bronzetier;

		// Token: 0x04000041 RID: 65
		private ConfigEntry<int> bronzeattackforce;

		// Token: 0x04000042 RID: 66
		private ConfigEntry<int> irondamage;

		// Token: 0x04000043 RID: 67
		private ConfigEntry<int> ironblunt;

		// Token: 0x04000044 RID: 68
		private ConfigEntry<int> ironslashval;

		// Token: 0x04000045 RID: 69
		private ConfigEntry<int> ironpierce;

		// Token: 0x04000046 RID: 70
		private ConfigEntry<int> ironchop;

		// Token: 0x04000047 RID: 71
		private ConfigEntry<int> ironpickaxe;

		// Token: 0x04000048 RID: 72
		private ConfigEntry<int> ironfire;

		// Token: 0x04000049 RID: 73
		private ConfigEntry<int> ironfrost;

		// Token: 0x0400004A RID: 74
		private ConfigEntry<int> ironlightning;

		// Token: 0x0400004B RID: 75
		private ConfigEntry<int> ironpoison;

		// Token: 0x0400004C RID: 76
		private ConfigEntry<int> ironspirit;

		// Token: 0x0400004D RID: 77
		private ConfigEntry<int> irondamageper;

		// Token: 0x0400004E RID: 78
		private ConfigEntry<int> ironbluntper;

		// Token: 0x0400004F RID: 79
		private ConfigEntry<int> ironslashper;

		// Token: 0x04000050 RID: 80
		private ConfigEntry<int> ironpierceper;

		// Token: 0x04000051 RID: 81
		private ConfigEntry<int> ironchopper;

		// Token: 0x04000052 RID: 82
		private ConfigEntry<int> ironpickaxeper;

		// Token: 0x04000053 RID: 83
		private ConfigEntry<int> ironfireper;

		// Token: 0x04000054 RID: 84
		private ConfigEntry<int> ironfrostper;

		// Token: 0x04000055 RID: 85
		private ConfigEntry<int> ironlightningper;

		// Token: 0x04000056 RID: 86
		private ConfigEntry<int> ironpoisonper;

		// Token: 0x04000057 RID: 87
		private ConfigEntry<int> ironspiritper;

		// Token: 0x04000058 RID: 88
		private ConfigEntry<int> irontier;

		// Token: 0x04000059 RID: 89
		private ConfigEntry<int> ironattackforce;

		// Token: 0x0400005A RID: 90
		private ConfigEntry<int> silverdamage;

		// Token: 0x0400005B RID: 91
		private ConfigEntry<int> silverblunt;

		// Token: 0x0400005C RID: 92
		private ConfigEntry<int> silverslashval;

		// Token: 0x0400005D RID: 93
		private ConfigEntry<int> silverpierce;

		// Token: 0x0400005E RID: 94
		private ConfigEntry<int> silverchop;

		// Token: 0x0400005F RID: 95
		private ConfigEntry<int> silverpickaxe;

		// Token: 0x04000060 RID: 96
		private ConfigEntry<int> silverfire;

		// Token: 0x04000061 RID: 97
		private ConfigEntry<int> silverfrost;

		// Token: 0x04000062 RID: 98
		private ConfigEntry<int> silverlightning;

		// Token: 0x04000063 RID: 99
		private ConfigEntry<int> silverpoison;

		// Token: 0x04000064 RID: 100
		private ConfigEntry<int> silverspirit;

		// Token: 0x04000065 RID: 101
		private ConfigEntry<int> silverdamageper;

		// Token: 0x04000066 RID: 102
		private ConfigEntry<int> silverbluntper;

		// Token: 0x04000067 RID: 103
		private ConfigEntry<int> silverslashper;

		// Token: 0x04000068 RID: 104
		private ConfigEntry<int> silverpierceper;

		// Token: 0x04000069 RID: 105
		private ConfigEntry<int> silverchopper;

		// Token: 0x0400006A RID: 106
		private ConfigEntry<int> silverpickaxeper;

		// Token: 0x0400006B RID: 107
		private ConfigEntry<int> silverfireper;

		// Token: 0x0400006C RID: 108
		private ConfigEntry<int> silverfrostper;

		// Token: 0x0400006D RID: 109
		private ConfigEntry<int> silverlightningper;

		// Token: 0x0400006E RID: 110
		private ConfigEntry<int> silverpoisonper;

		// Token: 0x0400006F RID: 111
		private ConfigEntry<int> silverspiritper;

		// Token: 0x04000070 RID: 112
		private ConfigEntry<int> silvertier;

		// Token: 0x04000071 RID: 113
		private ConfigEntry<int> silverattackforce;

		// Token: 0x04000072 RID: 114
		private ConfigEntry<int> bonedamage;

		// Token: 0x04000073 RID: 115
		private ConfigEntry<int> boneblunt;

		// Token: 0x04000074 RID: 116
		private ConfigEntry<int> boneslashval;

		// Token: 0x04000075 RID: 117
		private ConfigEntry<int> bonepierce;

		// Token: 0x04000076 RID: 118
		private ConfigEntry<int> bonechop;

		// Token: 0x04000077 RID: 119
		private ConfigEntry<int> bonepickaxe;

		// Token: 0x04000078 RID: 120
		private ConfigEntry<int> bonefire;

		// Token: 0x04000079 RID: 121
		private ConfigEntry<int> bonefrost;

		// Token: 0x0400007A RID: 122
		private ConfigEntry<int> bonelightning;

		// Token: 0x0400007B RID: 123
		private ConfigEntry<int> bonepoison;

		// Token: 0x0400007C RID: 124
		private ConfigEntry<int> bonespirit;

		// Token: 0x0400007D RID: 125
		private ConfigEntry<int> bonedamageper;

		// Token: 0x0400007E RID: 126
		private ConfigEntry<int> bonebluntper;

		// Token: 0x0400007F RID: 127
		private ConfigEntry<int> boneslashper;

		// Token: 0x04000080 RID: 128
		private ConfigEntry<int> bonepierceper;

		// Token: 0x04000081 RID: 129
		private ConfigEntry<int> bonechopper;

		// Token: 0x04000082 RID: 130
		private ConfigEntry<int> bonepickaxeper;

		// Token: 0x04000083 RID: 131
		private ConfigEntry<int> bonefireper;

		// Token: 0x04000084 RID: 132
		private ConfigEntry<int> bonefrostper;

		// Token: 0x04000085 RID: 133
		private ConfigEntry<int> bonelightningper;

		// Token: 0x04000086 RID: 134
		private ConfigEntry<int> bonepoisonper;

		// Token: 0x04000087 RID: 135
		private ConfigEntry<int> bonespiritper;

		// Token: 0x04000088 RID: 136
		private ConfigEntry<int> bonetier;

		// Token: 0x04000089 RID: 137
		private ConfigEntry<int> boneattackforce;

		// Token: 0x0400008A RID: 138
		private ConfigEntry<int> wooddamage;

		// Token: 0x0400008B RID: 139
		private ConfigEntry<int> woodblunt;

		// Token: 0x0400008C RID: 140
		private ConfigEntry<int> woodslashval;

		// Token: 0x0400008D RID: 141
		private ConfigEntry<int> woodpierce;

		// Token: 0x0400008E RID: 142
		private ConfigEntry<int> woodchop;

		// Token: 0x0400008F RID: 143
		private ConfigEntry<int> woodpickaxe;

		// Token: 0x04000090 RID: 144
		private ConfigEntry<int> woodfire;

		// Token: 0x04000091 RID: 145
		private ConfigEntry<int> woodfrost;

		// Token: 0x04000092 RID: 146
		private ConfigEntry<int> woodlightning;

		// Token: 0x04000093 RID: 147
		private ConfigEntry<int> woodpoison;

		// Token: 0x04000094 RID: 148
		private ConfigEntry<int> woodspirit;

		// Token: 0x04000095 RID: 149
		private ConfigEntry<int> wooddamageper;

		// Token: 0x04000096 RID: 150
		private ConfigEntry<int> woodbluntper;

		// Token: 0x04000097 RID: 151
		private ConfigEntry<int> woodslashper;

		// Token: 0x04000098 RID: 152
		private ConfigEntry<int> woodpierceper;

		// Token: 0x04000099 RID: 153
		private ConfigEntry<int> woodchopper;

		// Token: 0x0400009A RID: 154
		private ConfigEntry<int> woodpickaxeper;

		// Token: 0x0400009B RID: 155
		private ConfigEntry<int> woodfireper;

		// Token: 0x0400009C RID: 156
		private ConfigEntry<int> woodfrostper;

		// Token: 0x0400009D RID: 157
		private ConfigEntry<int> woodlightningper;

		// Token: 0x0400009E RID: 158
		private ConfigEntry<int> woodpoisonper;

		// Token: 0x0400009F RID: 159
		private ConfigEntry<int> woodspiritper;

		// Token: 0x040000A0 RID: 160
		private ConfigEntry<int> woodtier;

		// Token: 0x040000A1 RID: 161
		private ConfigEntry<int> woodattackforce;

		// Token: 0x040000A2 RID: 162
		private CustomItem bcestus;

		// Token: 0x040000A3 RID: 163
		private CustomItem silvercestus;

		// Token: 0x040000A4 RID: 164
		private CustomItem ironcestus;

		// Token: 0x040000A5 RID: 165
		private CustomItem boneknuck;

		// Token: 0x040000A6 RID: 166
		private CustomItem twig;
	}
}
