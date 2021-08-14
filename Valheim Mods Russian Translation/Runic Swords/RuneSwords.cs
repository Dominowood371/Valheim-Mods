using System;
using System.Collections.Generic;
using BepInEx;
using BepInEx.Configuration;
using Jotunn;
using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;
using Jotunn.Utils;
using UnityEngine;

namespace RuneSwords
{
	// Token: 0x02000002 RID: 2
	[BepInPlugin("com.zarboz.runicswords", "RuneSwords", "0.0.9")]
	[BepInDependency("com.jotunn.jotunn", BepInDependency.DependencyFlags.HardDependency)]
	[NetworkCompatibility(CompatibilityLevel.OnlySyncWhenInstalled, VersionStrictness.Minor)]
	internal class RuneSwords : BaseUnityPlugin
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		private void Awake()
		{
			this.AddTranslations();
			this.LoadAssets();
			this.ConfigDeploy();
			SynchronizationManager.OnConfigurationSynchronized += delegate(object obj, ConfigurationSynchronizationEventArgs attr)
			{
				if (attr.InitialSynchronization)
				{
					Jotunn.Logger.LogMessage("Initial Config sync event received");
					this.LoadSwords();
					return;
				}
				Jotunn.Logger.LogMessage("Config sync event received");
				this.LoadSwords();
			};
			ItemManager.OnVanillaItemsAvailable += this.LoadgameFabs;
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002086 File Offset: 0x00000286
		public void LoadAssets()
		{
			this.runeassets = AssetUtils.LoadAssetBundleFromResources("runeswords", typeof(RuneSwords).Assembly);
		}

		// Token: 0x06000003 RID: 3 RVA: 0x000020DC File Offset: 0x000002DC
		private void LoadSwords()
		{
			List<GameObject> items = ObjectDB.instance.m_items;
			items.Remove(this.FrostSword);
			this.Frost_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_damage = (float)this.damagefrost.Value;
			this.Frost_Sword.ItemDrop.m_itemData.m_shared.m_toolTier = this.bluntfrost.Value;
			this.Frost_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_slash = (float)this.slashvalfrost.Value;
			this.Frost_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_pierce = (float)this.piercefrost.Value;
			this.Frost_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_chop = (float)this.chopfrost.Value;
			this.Frost_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_pickaxe = (float)this.pickaxefrost.Value;
			this.Frost_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_fire = (float)this.firefrost.Value;
			this.Frost_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_frost = (float)this.frostfrost.Value;
			this.Frost_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_lightning = (float)this.lightningfrost.Value;
			this.Frost_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_poison = (float)this.poisonfrost.Value;
			this.Frost_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_spirit = (float)this.spiritfrost.Value;
			this.Frost_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_damage = (float)this.damageperfrost.Value;
			this.Frost_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_blunt = (float)this.bluntperfrost.Value;
			this.Frost_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_slash = (float)this.slashperfrost.Value;
			this.Frost_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pierce = (float)this.pierceperfrost.Value;
			this.Frost_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_chop = (float)this.chopperfrost.Value;
			this.Frost_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pickaxe = (float)this.pickaxeperfrost.Value;
			this.Frost_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_fire = (float)this.fireperfrost.Value;
			this.Frost_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_frost = (float)this.frostperfrost.Value;
			this.Frost_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_lightning = (float)this.lightningperfrost.Value;
			this.Frost_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_poison = (float)this.poisonperfrost.Value;
			this.Frost_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_spirit = (float)this.spiritperfrost.Value;
			this.Frost_Sword.ItemDrop.m_itemData.m_shared.m_attackForce = (float)this.attackforcefrost.Value;
			items.Add(this.FrostSword);
			items.Remove(this.firefab);
			this.firerune.ItemDrop.m_itemData.m_shared.m_damages.m_damage = (float)this.damagefire.Value;
			this.firerune.ItemDrop.m_itemData.m_shared.m_damages.m_blunt = (float)this.bluntfire.Value;
			this.firerune.ItemDrop.m_itemData.m_shared.m_toolTier = this.tierfire.Value;
			this.firerune.ItemDrop.m_itemData.m_shared.m_damages.m_slash = (float)this.slashvalfire.Value;
			this.firerune.ItemDrop.m_itemData.m_shared.m_damages.m_pierce = (float)this.piercefire.Value;
			this.firerune.ItemDrop.m_itemData.m_shared.m_damages.m_chop = (float)this.chopfire.Value;
			this.firerune.ItemDrop.m_itemData.m_shared.m_damages.m_pickaxe = (float)this.pickaxefire.Value;
			this.firerune.ItemDrop.m_itemData.m_shared.m_damages.m_fire = (float)this.firefire.Value;
			this.firerune.ItemDrop.m_itemData.m_shared.m_damages.m_frost = (float)this.frostfire.Value;
			this.firerune.ItemDrop.m_itemData.m_shared.m_damages.m_lightning = (float)this.lightningfire.Value;
			this.firerune.ItemDrop.m_itemData.m_shared.m_damages.m_poison = (float)this.poisonfire.Value;
			this.firerune.ItemDrop.m_itemData.m_shared.m_damages.m_spirit = (float)this.spiritfire.Value;
			this.firerune.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_damage = (float)this.damageperfire.Value;
			this.firerune.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_blunt = (float)this.bluntperfire.Value;
			this.firerune.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_slash = (float)this.slashperfire.Value;
			this.firerune.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pierce = (float)this.pierceperfire.Value;
			this.firerune.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_chop = (float)this.chopperfire.Value;
			this.firerune.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pickaxe = (float)this.pickaxeperfire.Value;
			this.firerune.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_fire = (float)this.fireperfire.Value;
			this.firerune.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_frost = (float)this.frostperfire.Value;
			this.firerune.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_lightning = (float)this.lightningperfire.Value;
			this.firerune.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_poison = (float)this.poisonperfire.Value;
			this.firerune.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_spirit = (float)this.spiritperfire.Value;
			this.firerune.ItemDrop.m_itemData.m_shared.m_attackForce = (float)this.attackforcefire.Value;
			items.Add(this.firefab);
			items.Remove(this.poisonfab);
			this.poison.ItemDrop.m_itemData.m_shared.m_damages.m_damage = (float)this.damageposion.Value;
			this.poison.ItemDrop.m_itemData.m_shared.m_damages.m_blunt = (float)this.bluntposion.Value;
			this.poison.ItemDrop.m_itemData.m_shared.m_toolTier = this.tierposion.Value;
			this.poison.ItemDrop.m_itemData.m_shared.m_damages.m_slash = (float)this.slashvalposion.Value;
			this.poison.ItemDrop.m_itemData.m_shared.m_damages.m_pierce = (float)this.pierceposion.Value;
			this.poison.ItemDrop.m_itemData.m_shared.m_damages.m_chop = (float)this.chopposion.Value;
			this.poison.ItemDrop.m_itemData.m_shared.m_damages.m_pickaxe = (float)this.pickaxeposion.Value;
			this.poison.ItemDrop.m_itemData.m_shared.m_damages.m_fire = (float)this.fireposion.Value;
			this.poison.ItemDrop.m_itemData.m_shared.m_damages.m_frost = (float)this.frostposion.Value;
			this.poison.ItemDrop.m_itemData.m_shared.m_damages.m_lightning = (float)this.lightningposion.Value;
			this.poison.ItemDrop.m_itemData.m_shared.m_damages.m_poison = (float)this.poisonposion.Value;
			this.poison.ItemDrop.m_itemData.m_shared.m_damages.m_spirit = (float)this.spiritposion.Value;
			this.poison.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_damage = (float)this.damageperposion.Value;
			this.poison.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_blunt = (float)this.bluntperposion.Value;
			this.poison.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_slash = (float)this.slashperposion.Value;
			this.poison.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pierce = (float)this.pierceperposion.Value;
			this.poison.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_chop = (float)this.chopperposion.Value;
			this.poison.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pickaxe = (float)this.pickaxeperposion.Value;
			this.poison.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_fire = (float)this.fireperposion.Value;
			this.poison.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_frost = (float)this.frostperposion.Value;
			this.poison.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_lightning = (float)this.lightningperposion.Value;
			this.poison.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_poison = (float)this.poisonperposion.Value;
			this.poison.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_spirit = (float)this.spiritperposion.Value;
			items.Add(this.poisonfab);
			items.Remove(this.lightningfab);
			this.llightrune.ItemDrop.m_itemData.m_shared.m_damages.m_damage = (float)this.damagelight.Value;
			this.llightrune.ItemDrop.m_itemData.m_shared.m_damages.m_blunt = (float)this.bluntlight.Value;
			this.llightrune.ItemDrop.m_itemData.m_shared.m_toolTier = this.tierlight.Value;
			this.llightrune.ItemDrop.m_itemData.m_shared.m_damages.m_slash = (float)this.slashvallight.Value;
			this.llightrune.ItemDrop.m_itemData.m_shared.m_damages.m_pierce = (float)this.piercelight.Value;
			this.llightrune.ItemDrop.m_itemData.m_shared.m_damages.m_chop = (float)this.choplight.Value;
			this.llightrune.ItemDrop.m_itemData.m_shared.m_damages.m_pickaxe = (float)this.pickaxelight.Value;
			this.llightrune.ItemDrop.m_itemData.m_shared.m_damages.m_fire = (float)this.firelight.Value;
			this.llightrune.ItemDrop.m_itemData.m_shared.m_damages.m_frost = (float)this.frostlight.Value;
			this.llightrune.ItemDrop.m_itemData.m_shared.m_damages.m_lightning = (float)this.lightninglight.Value;
			this.llightrune.ItemDrop.m_itemData.m_shared.m_damages.m_poison = (float)this.poisonlight.Value;
			this.llightrune.ItemDrop.m_itemData.m_shared.m_damages.m_spirit = (float)this.spiritlight.Value;
			this.llightrune.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_damage = (float)this.damageperlight.Value;
			this.llightrune.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_blunt = (float)this.bluntperlight.Value;
			this.llightrune.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_slash = (float)this.slashperlight.Value;
			this.llightrune.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pierce = (float)this.pierceperlight.Value;
			this.llightrune.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_chop = (float)this.chopperlight.Value;
			this.llightrune.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pickaxe = (float)this.pickaxeperlight.Value;
			this.llightrune.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_fire = (float)this.fireperlight.Value;
			this.llightrune.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_frost = (float)this.frostperlight.Value;
			this.llightrune.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_lightning = (float)this.lightningperlight.Value;
			this.llightrune.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_poison = (float)this.poisonperlight.Value;
			this.llightrune.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_spirit = (float)this.spiritperlight.Value;
			this.llightrune.ItemDrop.m_itemData.m_shared.m_attackForce = (float)this.attackforcelight.Value;
			items.Add(this.lightningfab);
			items.Remove(this.Ice_GreatSword);
			this.IceGreat_Sword.ItemDrop.m_itemData.m_shared.m_maxQuality = 10;
			this.IceGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_damage = (float)this.greatdamagefrost.Value;
			this.IceGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_blunt = (float)this.greatbluntfrost.Value;
			this.IceGreat_Sword.ItemDrop.m_itemData.m_shared.m_toolTier = this.greattierfrost.Value;
			this.IceGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_slash = (float)this.greatslashvalfrost.Value;
			this.IceGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_pierce = (float)this.greatpiercefrost.Value;
			this.IceGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_chop = (float)this.greatchopfrost.Value;
			this.IceGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_pickaxe = (float)this.greatpickaxefrost.Value;
			this.IceGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_fire = (float)this.greatfirefrost.Value;
			this.IceGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_frost = (float)this.greatfrostfrost.Value;
			this.IceGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_lightning = (float)this.greatlightningfrost.Value;
			this.IceGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_poison = (float)this.greatpoisonfrost.Value;
			this.IceGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_spirit = (float)this.greatspiritfrost.Value;
			this.IceGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_damage = (float)this.greatdamageperfrost.Value;
			this.IceGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_blunt = (float)this.greatbluntperfrost.Value;
			this.IceGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_slash = (float)this.greatslashperfrost.Value;
			this.IceGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pierce = (float)this.greatpierceperfrost.Value;
			this.IceGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_chop = (float)this.greatchopperfrost.Value;
			this.IceGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pickaxe = (float)this.greatpickaxeperfrost.Value;
			this.IceGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_fire = (float)this.greatfireperfrost.Value;
			this.IceGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_frost = (float)this.greatfrostperfrost.Value;
			this.IceGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_lightning = (float)this.greatlightningperfrost.Value;
			this.IceGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_poison = (float)this.greatpoisonperfrost.Value;
			this.IceGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_spirit = (float)this.greatspiritperfrost.Value;
			this.IceGreat_Sword.ItemDrop.m_itemData.m_shared.m_attackForce = (float)this.greatattackforcefrost.Value;
			items.Add(this.Ice_GreatSword);
			items.Remove(this.Fire_GreatSword);
			this.FireGreat_Sword.ItemDrop.m_itemData.m_shared.m_maxQuality = 10;
			this.FireGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_damage = (float)this.greatdamagefire.Value;
			this.FireGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_blunt = (float)this.greatbluntfire.Value;
			this.FireGreat_Sword.ItemDrop.m_itemData.m_shared.m_toolTier = this.greattierfire.Value;
			this.FireGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_slash = (float)this.greatslashvalfire.Value;
			this.FireGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_pierce = (float)this.greatpiercefire.Value;
			this.FireGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_chop = (float)this.greatchopfire.Value;
			this.FireGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_pickaxe = (float)this.greatpickaxefire.Value;
			this.FireGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_fire = (float)this.greatfirefire.Value;
			this.FireGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_frost = (float)this.greatfrostfire.Value;
			this.FireGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_lightning = (float)this.greatlightningfire.Value;
			this.FireGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_poison = (float)this.greatpoisonfire.Value;
			this.FireGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_spirit = (float)this.greatspiritfire.Value;
			this.FireGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_damage = (float)this.greatdamageperfire.Value;
			this.FireGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_blunt = (float)this.greatbluntperfire.Value;
			this.FireGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_slash = (float)this.greatslashperfire.Value;
			this.FireGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pierce = (float)this.greatpierceperfire.Value;
			this.FireGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_chop = (float)this.greatchopperfire.Value;
			this.FireGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pickaxe = (float)this.greatpickaxeperfire.Value;
			this.FireGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_fire = (float)this.greatfireperfire.Value;
			this.FireGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_frost = (float)this.greatfrostperfire.Value;
			this.FireGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_lightning = (float)this.greatlightningperfire.Value;
			this.FireGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_poison = (float)this.greatpoisonperfire.Value;
			this.FireGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_spirit = (float)this.greatspiritperfire.Value;
			items.Add(this.Fire_GreatSword);
			items.Add(this.Poison_GreatSword);
			this.PoisonGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_damage = (float)this.greatdamageposion.Value;
			this.PoisonGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_blunt = (float)this.greatbluntposion.Value;
			this.PoisonGreat_Sword.ItemDrop.m_itemData.m_shared.m_toolTier = this.greattierposion.Value;
			this.PoisonGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_slash = (float)this.greatslashvalposion.Value;
			this.PoisonGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_pierce = (float)this.greatpierceposion.Value;
			this.PoisonGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_chop = (float)this.greatchopposion.Value;
			this.PoisonGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_pickaxe = (float)this.greatpickaxeposion.Value;
			this.PoisonGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_fire = (float)this.greatfireposion.Value;
			this.PoisonGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_frost = (float)this.greatfrostposion.Value;
			this.PoisonGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_lightning = (float)this.greatlightningposion.Value;
			this.PoisonGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_poison = (float)this.greatpoisonposion.Value;
			this.PoisonGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_spirit = (float)this.greatspiritposion.Value;
			this.PoisonGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_damage = (float)this.greatdamageperposion.Value;
			this.PoisonGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_blunt = (float)this.greatbluntperposion.Value;
			this.PoisonGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_slash = (float)this.greatslashperposion.Value;
			this.PoisonGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pierce = (float)this.greatpierceperposion.Value;
			this.PoisonGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_chop = (float)this.greatchopperposion.Value;
			this.PoisonGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pickaxe = (float)this.greatpickaxeperposion.Value;
			this.PoisonGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_fire = (float)this.greatfireperposion.Value;
			this.PoisonGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_frost = (float)this.greatfrostperposion.Value;
			this.PoisonGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_lightning = (float)this.greatlightningperposion.Value;
			this.PoisonGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_poison = (float)this.greatpoisonperposion.Value;
			this.PoisonGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_spirit = (float)this.greatspiritperposion.Value;
			this.PoisonGreat_Sword.ItemDrop.m_itemData.m_shared.m_attackForce = (float)this.greatattackforceposion.Value;
			items.Remove(this.Poison_GreatSword);
			items.Remove(this.Lgntng_GreatSword);
			this.YlwGreatSwrd.ItemDrop.m_itemData.m_shared.m_damages.m_damage = (float)this.greatdamagelight.Value;
			this.YlwGreatSwrd.ItemDrop.m_itemData.m_shared.m_damages.m_blunt = (float)this.greatbluntlight.Value;
			this.YlwGreatSwrd.ItemDrop.m_itemData.m_shared.m_toolTier = this.greattierlight.Value;
			this.YlwGreatSwrd.ItemDrop.m_itemData.m_shared.m_damages.m_slash = (float)this.greatslashvallight.Value;
			this.YlwGreatSwrd.ItemDrop.m_itemData.m_shared.m_damages.m_pierce = (float)this.greatpiercelight.Value;
			this.YlwGreatSwrd.ItemDrop.m_itemData.m_shared.m_damages.m_chop = (float)this.greatchoplight.Value;
			this.YlwGreatSwrd.ItemDrop.m_itemData.m_shared.m_damages.m_pickaxe = (float)this.greatpickaxelight.Value;
			this.YlwGreatSwrd.ItemDrop.m_itemData.m_shared.m_damages.m_fire = (float)this.greatfirelight.Value;
			this.YlwGreatSwrd.ItemDrop.m_itemData.m_shared.m_damages.m_frost = (float)this.greatfrostlight.Value;
			this.YlwGreatSwrd.ItemDrop.m_itemData.m_shared.m_damages.m_lightning = (float)this.greatlightninglight.Value;
			this.YlwGreatSwrd.ItemDrop.m_itemData.m_shared.m_damages.m_poison = (float)this.greatpoisonlight.Value;
			this.YlwGreatSwrd.ItemDrop.m_itemData.m_shared.m_damages.m_spirit = (float)this.greatspiritlight.Value;
			this.YlwGreatSwrd.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_damage = (float)this.greatdamageperlight.Value;
			this.YlwGreatSwrd.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_blunt = (float)this.greatbluntperlight.Value;
			this.YlwGreatSwrd.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_slash = (float)this.greatslashperlight.Value;
			this.YlwGreatSwrd.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pierce = (float)this.greatpierceperlight.Value;
			this.YlwGreatSwrd.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_chop = (float)this.greatchopperlight.Value;
			this.YlwGreatSwrd.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pickaxe = (float)this.greatpickaxeperlight.Value;
			this.YlwGreatSwrd.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_fire = (float)this.greatfireperlight.Value;
			this.YlwGreatSwrd.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_frost = (float)this.greatfrostperlight.Value;
			this.YlwGreatSwrd.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_lightning = (float)this.greatlightningperlight.Value;
			this.YlwGreatSwrd.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_poison = (float)this.greatpoisonperlight.Value;
			this.YlwGreatSwrd.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_spirit = (float)this.greatspiritperlight.Value;
			this.YlwGreatSwrd.ItemDrop.m_itemData.m_shared.m_attackForce = (float)this.greatattackforcelight.Value;
			items.Add(this.Lgntng_GreatSword);
			items.Remove(this.FrostDagger);
			this.Frost_Dagger.ItemDrop.m_itemData.m_shared.m_damages.m_damage = (float)this.daggerdamagefrost.Value;
			this.Frost_Dagger.ItemDrop.m_itemData.m_shared.m_toolTier = this.daggerbluntfrost.Value;
			this.Frost_Dagger.ItemDrop.m_itemData.m_shared.m_damages.m_slash = (float)this.daggerslashvalfrost.Value;
			this.Frost_Dagger.ItemDrop.m_itemData.m_shared.m_damages.m_pierce = (float)this.daggerpiercefrost.Value;
			this.Frost_Dagger.ItemDrop.m_itemData.m_shared.m_damages.m_chop = (float)this.daggerchopfrost.Value;
			this.Frost_Dagger.ItemDrop.m_itemData.m_shared.m_damages.m_pickaxe = (float)this.daggerpickaxefrost.Value;
			this.Frost_Dagger.ItemDrop.m_itemData.m_shared.m_damages.m_fire = (float)this.daggerfirefrost.Value;
			this.Frost_Dagger.ItemDrop.m_itemData.m_shared.m_damages.m_frost = (float)this.daggerfrostfrost.Value;
			this.Frost_Dagger.ItemDrop.m_itemData.m_shared.m_damages.m_lightning = (float)this.daggerlightningfrost.Value;
			this.Frost_Dagger.ItemDrop.m_itemData.m_shared.m_damages.m_poison = (float)this.daggerpoisonfrost.Value;
			this.Frost_Dagger.ItemDrop.m_itemData.m_shared.m_damages.m_spirit = (float)this.daggerspiritfrost.Value;
			this.Frost_Dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_damage = (float)this.daggerdamageperfrost.Value;
			this.Frost_Dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_blunt = (float)this.daggerbluntperfrost.Value;
			this.Frost_Dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_slash = (float)this.daggerslashperfrost.Value;
			this.Frost_Dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pierce = (float)this.daggerpierceperfrost.Value;
			this.Frost_Dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_chop = (float)this.daggerchopperfrost.Value;
			this.Frost_Dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pickaxe = (float)this.daggerpickaxeperfrost.Value;
			this.Frost_Dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_fire = (float)this.daggerfireperfrost.Value;
			this.Frost_Dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_frost = (float)this.daggerfrostperfrost.Value;
			this.Frost_Dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_lightning = (float)this.daggerlightningperfrost.Value;
			this.Frost_Dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_poison = (float)this.daggerpoisonperfrost.Value;
			this.Frost_Dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_spirit = (float)this.daggerspiritperfrost.Value;
			this.Frost_Dagger.ItemDrop.m_itemData.m_shared.m_attackForce = (float)this.daggerattackforcefrost.Value;
			items.Add(this.FrostDagger);
			items.Remove(this.firedagger);
			this.fire_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_damage = (float)this.daggerdamagefire.Value;
			this.fire_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_blunt = (float)this.daggerbluntfire.Value;
			this.fire_dagger.ItemDrop.m_itemData.m_shared.m_toolTier = this.daggertierfire.Value;
			this.fire_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_slash = (float)this.daggerslashvalfire.Value;
			this.fire_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_pierce = (float)this.daggerpiercefire.Value;
			this.fire_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_chop = (float)this.daggerchopfire.Value;
			this.fire_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_pickaxe = (float)this.daggerpickaxefire.Value;
			this.fire_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_fire = (float)this.daggerfirefire.Value;
			this.fire_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_frost = (float)this.daggerfrostfire.Value;
			this.fire_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_lightning = (float)this.daggerlightningfire.Value;
			this.fire_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_poison = (float)this.daggerpoisonfire.Value;
			this.fire_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_spirit = (float)this.daggerspiritfire.Value;
			this.fire_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_damage = (float)this.daggerdamageperfire.Value;
			this.fire_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_blunt = (float)this.daggerbluntperfire.Value;
			this.fire_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_slash = (float)this.daggerslashperfire.Value;
			this.fire_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pierce = (float)this.daggerpierceperfire.Value;
			this.fire_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_chop = (float)this.daggerchopperfire.Value;
			this.fire_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pickaxe = (float)this.daggerpickaxeperfire.Value;
			this.fire_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_fire = (float)this.daggerfireperfire.Value;
			this.fire_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_frost = (float)this.daggerfrostperfire.Value;
			this.fire_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_lightning = (float)this.daggerlightningperfire.Value;
			this.fire_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_poison = (float)this.daggerpoisonperfire.Value;
			this.fire_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_spirit = (float)this.daggerspiritperfire.Value;
			this.fire_dagger.ItemDrop.m_itemData.m_shared.m_attackForce = (float)this.daggerattackforcefire.Value;
			items.Add(this.firedagger);
			items.Remove(this.poisondagger);
			this.poison_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_damage = (float)this.daggerdamageposion.Value;
			this.poison_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_blunt = (float)this.daggerbluntposion.Value;
			this.poison_dagger.ItemDrop.m_itemData.m_shared.m_toolTier = this.daggertierposion.Value;
			this.poison_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_slash = (float)this.daggerslashvalposion.Value;
			this.poison_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_pierce = (float)this.daggerpierceposion.Value;
			this.poison_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_chop = (float)this.daggerchopposion.Value;
			this.poison_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_pickaxe = (float)this.daggerpickaxeposion.Value;
			this.poison_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_fire = (float)this.daggerfireposion.Value;
			this.poison_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_frost = (float)this.daggerfrostposion.Value;
			this.poison_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_lightning = (float)this.daggerlightningposion.Value;
			this.poison_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_poison = (float)this.daggerpoisonposion.Value;
			this.poison_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_spirit = (float)this.daggerspiritposion.Value;
			this.poison_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_damage = (float)this.daggerdamageperposion.Value;
			this.poison_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_blunt = (float)this.daggerbluntperposion.Value;
			this.poison_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_slash = (float)this.daggerslashperposion.Value;
			this.poison_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pierce = (float)this.daggerpierceperposion.Value;
			this.poison_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_chop = (float)this.daggerchopperposion.Value;
			this.poison_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pickaxe = (float)this.daggerpickaxeperposion.Value;
			this.poison_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_fire = (float)this.daggerfireperposion.Value;
			this.poison_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_frost = (float)this.daggerfrostperposion.Value;
			this.poison_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_lightning = (float)this.daggerlightningperposion.Value;
			this.poison_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_poison = (float)this.daggerpoisonperposion.Value;
			this.poison_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_spirit = (float)this.daggerspiritperposion.Value;
			this.poison_dagger.ItemDrop.m_itemData.m_shared.m_attackForce = (float)this.daggerattackforceposion.Value;
			items.Add(this.poisondagger);
			items.Remove(this.lightningdagger);
			this.lightning_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_damage = (float)this.daggerdamagelight.Value;
			this.lightning_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_blunt = (float)this.daggerbluntlight.Value;
			this.lightning_dagger.ItemDrop.m_itemData.m_shared.m_toolTier = this.daggertierlight.Value;
			this.lightning_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_slash = (float)this.daggerslashvallight.Value;
			this.lightning_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_pierce = (float)this.daggerpiercelight.Value;
			this.lightning_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_chop = (float)this.daggerchoplight.Value;
			this.lightning_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_pickaxe = (float)this.daggerpickaxelight.Value;
			this.lightning_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_fire = (float)this.daggerfirelight.Value;
			this.lightning_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_frost = (float)this.daggerfrostlight.Value;
			this.lightning_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_lightning = (float)this.daggerlightninglight.Value;
			this.lightning_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_poison = (float)this.daggerpoisonlight.Value;
			this.lightning_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_spirit = (float)this.daggerspiritlight.Value;
			this.lightning_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_damage = (float)this.daggerdamageperlight.Value;
			this.lightning_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_blunt = (float)this.daggerbluntperlight.Value;
			this.lightning_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_slash = (float)this.daggerslashperlight.Value;
			this.lightning_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pierce = (float)this.daggerpierceperlight.Value;
			this.lightning_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_chop = (float)this.daggerchopperlight.Value;
			this.lightning_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pickaxe = (float)this.daggerpickaxeperlight.Value;
			this.lightning_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_fire = (float)this.daggerfireperlight.Value;
			this.lightning_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_frost = (float)this.daggerfrostperlight.Value;
			this.lightning_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_lightning = (float)this.daggerlightningperlight.Value;
			this.lightning_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_poison = (float)this.daggerpoisonperlight.Value;
			this.lightning_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_spirit = (float)this.daggerspiritperlight.Value;
			this.lightning_dagger.ItemDrop.m_itemData.m_shared.m_attackForce = (float)this.daggerattackforcelight.Value;
			items.Add(this.lightningdagger);
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00005190 File Offset: 0x00003390
		public void LoadgameFabs()
		{
			try
			{
				GameObject prefab = PrefabManager.Cache.GetPrefab<GameObject>("vfx_HitSparks");
				GameObject prefab2 = PrefabManager.Cache.GetPrefab<GameObject>("sfx_sword_hit");
				GameObject prefab3 = PrefabManager.Cache.GetPrefab<GameObject>("fx_hit_camshake");
				GameObject prefab4 = PrefabManager.Cache.GetPrefab<GameObject>("sfx_metal_blocked");
				GameObject prefab5 = PrefabManager.Cache.GetPrefab<GameObject>("vfx_blocked");
				GameObject prefab6 = PrefabManager.Cache.GetPrefab<GameObject>("sfx_sword_swing");
				GameObject prefab7 = PrefabManager.Cache.GetPrefab<GameObject>("fx_block_camshake");
				GameObject prefab8 = PrefabManager.Cache.GetPrefab<GameObject>("sfx_build_hammer_wood");
				GameObject prefab9 = PrefabManager.Cache.GetPrefab<GameObject>("vfx_Place_wood_pole");
				this.buildsounds = new EffectList
				{
					m_effectPrefabs = new EffectList.EffectData[]
					{
						new EffectList.EffectData
						{
							m_prefab = prefab8
						},
						new EffectList.EffectData
						{
							m_prefab = prefab9
						}
					}
				};
				this.effecthit = new EffectList
				{
					m_effectPrefabs = new EffectList.EffectData[]
					{
						new EffectList.EffectData
						{
							m_prefab = prefab,
							m_enabled = true
						},
						new EffectList.EffectData
						{
							m_prefab = prefab2,
							m_enabled = true
						},
						new EffectList.EffectData
						{
							m_prefab = prefab3,
							m_enabled = true
						}
					}
				};
				this.effectblocked = new EffectList
				{
					m_effectPrefabs = new EffectList.EffectData[]
					{
						new EffectList.EffectData
						{
							m_prefab = prefab4
						},
						new EffectList.EffectData
						{
							m_prefab = prefab5,
							m_enabled = true
						},
						new EffectList.EffectData
						{
							m_prefab = prefab7,
							m_enabled = true
						}
					}
				};
				this.trigger = new EffectList
				{
					m_effectPrefabs = new EffectList.EffectData[]
					{
						new EffectList.EffectData
						{
							m_prefab = prefab3,
							m_enabled = true
						}
					}
				};
				this.trailfx = new EffectList
				{
					m_effectPrefabs = new EffectList.EffectData[]
					{
						new EffectList.EffectData
						{
							m_prefab = prefab6,
							m_enabled = true
						}
					}
				};
				Jotunn.Logger.LogMessage("Loaded Game VFX and SFX");
				Jotunn.Logger.LogMessage("Loading Runestones");
				this.piece_exentension();
				this.piece_exentension1();
				this.piece_exentension2();
				this.piece_exentension3();
				this.piece_exentension4();
				this.piece_exentension5();
				Jotunn.Logger.LogMessage("Loading Swords");
				this.IceSword();
				this.FireSword();
				this.PoisonSword();
				this.LightningSword();
				Jotunn.Logger.LogMessage("Loading Great Swords");
				this.IceGreatSword();
				this.FireGreatSword();
				this.PoisonGreatSword();
				this.LightningGreatSword();
				Jotunn.Logger.LogMessage("Loading Knives");
				this.IceDagger();
				this.FireDagger();
				this.PoisonDagger();
				this.LightningDagger();
			}
			catch (Exception ex)
			{
				Jotunn.Logger.LogError("Error while adding cloned item: " + ex.Message);
			}
			finally
			{
				ItemManager.OnVanillaItemsAvailable -= this.LoadgameFabs;
			}
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00005460 File Offset: 0x00003660
		public void IceSword()
		{
			this.FrostSword = this.runeassets.LoadAsset<GameObject>("IceRuneSword");
			this.Frost_Sword = new CustomItem(this.FrostSword, true, new ItemConfig
			{
				Amount = 1,
				Name = "$icerunesword",
				Enabled = this.FrostEnable.Value,
				CraftingStation = "piece_artisanstation",
				RepairStation = "piece_artisanstation",
				MinStationLevel = 2,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Obsidian",
						Amount = this.ObsidianFrost.Value,
						AmountPerLevel = 5
					},
					new RequirementConfig
					{
						Item = "Iron",
						Amount = this.IronFrost.Value,
						AmountPerLevel = 25
					},
					new RequirementConfig
					{
						Item = "FreezeGland",
						Amount = this.IceFreezeGland.Value,
						AmountPerLevel = 10
					},
					new RequirementConfig
					{
						Item = "DragonTear",
						Amount = this.DragonTear.Value,
						AmountPerLevel = 5
					}
				}
			});
			this.Frost_Sword.ItemDrop.m_itemData.m_shared.m_maxQuality = 10;
			this.Frost_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_damage = (float)this.damagefrost.Value;
			this.Frost_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_blunt = (float)this.bluntfrost.Value;
			this.Frost_Sword.ItemDrop.m_itemData.m_shared.m_toolTier = this.tierfrost.Value;
			this.Frost_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_slash = (float)this.slashvalfrost.Value;
			this.Frost_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_pierce = (float)this.piercefrost.Value;
			this.Frost_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_chop = (float)this.chopfrost.Value;
			this.Frost_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_pickaxe = (float)this.pickaxefrost.Value;
			this.Frost_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_fire = (float)this.firefrost.Value;
			this.Frost_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_frost = (float)this.frostfrost.Value;
			this.Frost_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_lightning = (float)this.lightningfrost.Value;
			this.Frost_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_poison = (float)this.poisonfrost.Value;
			this.Frost_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_spirit = (float)this.spiritfrost.Value;
			this.Frost_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_damage = (float)this.damageperfrost.Value;
			this.Frost_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_blunt = (float)this.bluntperfrost.Value;
			this.Frost_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_slash = (float)this.slashperfrost.Value;
			this.Frost_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pierce = (float)this.pierceperfrost.Value;
			this.Frost_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_chop = (float)this.chopperfrost.Value;
			this.Frost_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pickaxe = (float)this.pickaxeperfrost.Value;
			this.Frost_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_fire = (float)this.fireperfrost.Value;
			this.Frost_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_frost = (float)this.frostperfrost.Value;
			this.Frost_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_lightning = (float)this.lightningperfrost.Value;
			this.Frost_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_poison = (float)this.poisonperfrost.Value;
			this.Frost_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_spirit = (float)this.spiritperfrost.Value;
			this.Frost_Sword.ItemDrop.m_itemData.m_shared.m_attackForce = (float)this.attackforcefrost.Value;
			this.Frost_Sword.ItemDrop.m_itemData.m_shared.m_hitEffect = this.effecthit;
			this.Frost_Sword.ItemDrop.m_itemData.m_shared.m_blockEffect = this.effectblocked;
			this.Frost_Sword.ItemDrop.m_itemData.m_shared.m_triggerEffect = this.trigger;
			this.Frost_Sword.ItemDrop.m_itemData.m_shared.m_trailStartEffect = this.trailfx;
			ItemManager.Instance.AddItem(this.Frost_Sword);
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00005A40 File Offset: 0x00003C40
		public void FireSword()
		{
			this.firefab = this.runeassets.LoadAsset<GameObject>("FireRuneSword");
			this.firerune = new CustomItem(this.firefab, true, new ItemConfig
			{
				Amount = 1,
				Name = "$firerunesword",
				Enabled = this.FireEnable.Value,
				CraftingStation = "piece_artisanstation",
				RepairStation = "piece_artisanstation",
				MinStationLevel = 2,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Flametal",
						Amount = this.FireFlametal.Value,
						AmountPerLevel = 50
					},
					new RequirementConfig
					{
						Item = "SurtlingCore",
						Amount = this.FireSurtling.Value,
						AmountPerLevel = 35
					},
					new RequirementConfig
					{
						Item = "Iron",
						Amount = this.IronFire.Value,
						AmountPerLevel = 25
					},
					new RequirementConfig
					{
						Item = "Obsidian",
						Amount = this.ObsidianFire.Value,
						AmountPerLevel = 5
					}
				}
			});
			this.firerune.ItemDrop.m_itemData.m_shared.m_maxQuality = 10;
			this.firerune.ItemDrop.m_itemData.m_shared.m_damages.m_damage = (float)this.damagefire.Value;
			this.firerune.ItemDrop.m_itemData.m_shared.m_damages.m_blunt = (float)this.bluntfire.Value;
			this.firerune.ItemDrop.m_itemData.m_shared.m_toolTier = this.tierfire.Value;
			this.firerune.ItemDrop.m_itemData.m_shared.m_damages.m_slash = (float)this.slashvalfire.Value;
			this.firerune.ItemDrop.m_itemData.m_shared.m_damages.m_pierce = (float)this.piercefire.Value;
			this.firerune.ItemDrop.m_itemData.m_shared.m_damages.m_chop = (float)this.chopfire.Value;
			this.firerune.ItemDrop.m_itemData.m_shared.m_damages.m_pickaxe = (float)this.pickaxefire.Value;
			this.firerune.ItemDrop.m_itemData.m_shared.m_damages.m_fire = (float)this.firefire.Value;
			this.firerune.ItemDrop.m_itemData.m_shared.m_damages.m_frost = (float)this.frostfire.Value;
			this.firerune.ItemDrop.m_itemData.m_shared.m_damages.m_lightning = (float)this.lightningfire.Value;
			this.firerune.ItemDrop.m_itemData.m_shared.m_damages.m_poison = (float)this.poisonfire.Value;
			this.firerune.ItemDrop.m_itemData.m_shared.m_damages.m_spirit = (float)this.spiritfire.Value;
			this.firerune.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_damage = (float)this.damageperfire.Value;
			this.firerune.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_blunt = (float)this.bluntperfire.Value;
			this.firerune.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_slash = (float)this.slashperfire.Value;
			this.firerune.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pierce = (float)this.pierceperfire.Value;
			this.firerune.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_chop = (float)this.chopperfire.Value;
			this.firerune.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pickaxe = (float)this.pickaxeperfire.Value;
			this.firerune.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_fire = (float)this.fireperfire.Value;
			this.firerune.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_frost = (float)this.frostperfire.Value;
			this.firerune.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_lightning = (float)this.lightningperfire.Value;
			this.firerune.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_poison = (float)this.poisonperfire.Value;
			this.firerune.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_spirit = (float)this.spiritperfire.Value;
			this.firerune.ItemDrop.m_itemData.m_shared.m_attackForce = (float)this.attackforcefire.Value;
			this.firerune.ItemDrop.m_itemData.m_shared.m_hitEffect = this.effecthit;
			this.firerune.ItemDrop.m_itemData.m_shared.m_blockEffect = this.effectblocked;
			this.firerune.ItemDrop.m_itemData.m_shared.m_triggerEffect = this.trigger;
			this.firerune.ItemDrop.m_itemData.m_shared.m_trailStartEffect = this.trailfx;
			ItemManager.Instance.AddItem(this.firerune);
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00006024 File Offset: 0x00004224
		public void PoisonSword()
		{
			this.poisonfab = this.runeassets.LoadAsset<GameObject>("PoisonRuneSword");
			this.poison = new CustomItem(this.poisonfab, true, new ItemConfig
			{
				Amount = 1,
				Name = "$poisonrunesword",
				Enabled = this.PoisonEnable.Value,
				CraftingStation = "piece_artisanstation",
				RepairStation = "piece_artisanstation",
				MinStationLevel = 2,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Obsidian",
						Amount = this.ObsidianPoison.Value,
						AmountPerLevel = 10
					},
					new RequirementConfig
					{
						Item = "Ooze",
						Amount = this.PoisonOoze.Value,
						AmountPerLevel = 25
					},
					new RequirementConfig
					{
						Item = "Iron",
						Amount = this.IronPoison.Value,
						AmountPerLevel = 25
					},
					new RequirementConfig
					{
						Item = "Guck",
						Amount = this.PoisonGuck.Value,
						AmountPerLevel = 10
					}
				}
			});
			this.poison.ItemDrop.m_itemData.m_shared.m_maxQuality = 10;
			this.poison.ItemDrop.m_itemData.m_shared.m_damages.m_damage = (float)this.damageposion.Value;
			this.poison.ItemDrop.m_itemData.m_shared.m_damages.m_blunt = (float)this.bluntposion.Value;
			this.poison.ItemDrop.m_itemData.m_shared.m_toolTier = this.tierposion.Value;
			this.poison.ItemDrop.m_itemData.m_shared.m_damages.m_slash = (float)this.slashvalposion.Value;
			this.poison.ItemDrop.m_itemData.m_shared.m_damages.m_pierce = (float)this.pierceposion.Value;
			this.poison.ItemDrop.m_itemData.m_shared.m_damages.m_chop = (float)this.chopposion.Value;
			this.poison.ItemDrop.m_itemData.m_shared.m_damages.m_pickaxe = (float)this.pickaxeposion.Value;
			this.poison.ItemDrop.m_itemData.m_shared.m_damages.m_fire = (float)this.fireposion.Value;
			this.poison.ItemDrop.m_itemData.m_shared.m_damages.m_frost = (float)this.frostposion.Value;
			this.poison.ItemDrop.m_itemData.m_shared.m_damages.m_lightning = (float)this.lightningposion.Value;
			this.poison.ItemDrop.m_itemData.m_shared.m_damages.m_poison = (float)this.poisonposion.Value;
			this.poison.ItemDrop.m_itemData.m_shared.m_damages.m_spirit = (float)this.spiritposion.Value;
			this.poison.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_damage = (float)this.damageperposion.Value;
			this.poison.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_blunt = (float)this.bluntperposion.Value;
			this.poison.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_slash = (float)this.slashperposion.Value;
			this.poison.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pierce = (float)this.pierceperposion.Value;
			this.poison.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_chop = (float)this.chopperposion.Value;
			this.poison.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pickaxe = (float)this.pickaxeperposion.Value;
			this.poison.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_fire = (float)this.fireperposion.Value;
			this.poison.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_frost = (float)this.frostperposion.Value;
			this.poison.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_lightning = (float)this.lightningperposion.Value;
			this.poison.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_poison = (float)this.poisonperposion.Value;
			this.poison.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_spirit = (float)this.spiritperposion.Value;
			this.poison.ItemDrop.m_itemData.m_shared.m_attackForce = (float)this.attackforceposion.Value;
			this.poison.ItemDrop.m_itemData.m_shared.m_hitEffect = this.effecthit;
			this.poison.ItemDrop.m_itemData.m_shared.m_blockEffect = this.effectblocked;
			this.poison.ItemDrop.m_itemData.m_shared.m_triggerEffect = this.trigger;
			this.poison.ItemDrop.m_itemData.m_shared.m_trailStartEffect = this.trailfx;
			ItemManager.Instance.AddItem(this.poison);
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00006608 File Offset: 0x00004808
		public void LightningSword()
		{
			this.lightningfab = this.runeassets.LoadAsset<GameObject>("LightningRuneSword");
			this.llightrune = new CustomItem(this.lightningfab, true, new ItemConfig
			{
				Amount = 1,
				Name = "$lightningrunesword",
				Enabled = this.LightEnable.Value,
				CraftingStation = "piece_artisanstation",
				RepairStation = "piece_artisanstation",
				MinStationLevel = 2,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Obsidian",
						Amount = this.ObsidianLight.Value,
						AmountPerLevel = 5
					},
					new RequirementConfig
					{
						Item = "Iron",
						Amount = this.IronLight.Value,
						AmountPerLevel = 25
					},
					new RequirementConfig
					{
						Item = "TrophyEikthyr",
						Amount = this.Trophy.Value,
						AmountPerLevel = 1
					},
					new RequirementConfig
					{
						Item = "HardAntler",
						Amount = this.Antler.Value,
						AmountPerLevel = 10
					}
				}
			});
			this.llightrune.ItemDrop.m_itemData.m_shared.m_maxQuality = 10;
			this.llightrune.ItemDrop.m_itemData.m_shared.m_damages.m_damage = (float)this.damagelight.Value;
			this.llightrune.ItemDrop.m_itemData.m_shared.m_damages.m_blunt = (float)this.bluntlight.Value;
			this.llightrune.ItemDrop.m_itemData.m_shared.m_toolTier = this.tierlight.Value;
			this.llightrune.ItemDrop.m_itemData.m_shared.m_damages.m_slash = (float)this.slashvallight.Value;
			this.llightrune.ItemDrop.m_itemData.m_shared.m_damages.m_pierce = (float)this.piercelight.Value;
			this.llightrune.ItemDrop.m_itemData.m_shared.m_damages.m_chop = (float)this.choplight.Value;
			this.llightrune.ItemDrop.m_itemData.m_shared.m_damages.m_pickaxe = (float)this.pickaxelight.Value;
			this.llightrune.ItemDrop.m_itemData.m_shared.m_damages.m_fire = (float)this.firelight.Value;
			this.llightrune.ItemDrop.m_itemData.m_shared.m_damages.m_frost = (float)this.frostlight.Value;
			this.llightrune.ItemDrop.m_itemData.m_shared.m_damages.m_lightning = (float)this.lightninglight.Value;
			this.llightrune.ItemDrop.m_itemData.m_shared.m_damages.m_poison = (float)this.poisonlight.Value;
			this.llightrune.ItemDrop.m_itemData.m_shared.m_damages.m_spirit = (float)this.spiritlight.Value;
			this.llightrune.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_damage = (float)this.damageperlight.Value;
			this.llightrune.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_blunt = (float)this.bluntperlight.Value;
			this.llightrune.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_slash = (float)this.slashperlight.Value;
			this.llightrune.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pierce = (float)this.pierceperlight.Value;
			this.llightrune.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_chop = (float)this.chopperlight.Value;
			this.llightrune.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pickaxe = (float)this.pickaxeperlight.Value;
			this.llightrune.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_fire = (float)this.fireperlight.Value;
			this.llightrune.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_frost = (float)this.frostperlight.Value;
			this.llightrune.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_lightning = (float)this.lightningperlight.Value;
			this.llightrune.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_poison = (float)this.poisonperlight.Value;
			this.llightrune.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_spirit = (float)this.spiritperlight.Value;
			this.llightrune.ItemDrop.m_itemData.m_shared.m_attackForce = (float)this.attackforcelight.Value;
			this.llightrune.ItemDrop.m_itemData.m_shared.m_hitEffect = this.effecthit;
			this.llightrune.ItemDrop.m_itemData.m_shared.m_blockEffect = this.effectblocked;
			this.llightrune.ItemDrop.m_itemData.m_shared.m_triggerEffect = this.trigger;
			this.llightrune.ItemDrop.m_itemData.m_shared.m_trailStartEffect = this.trailfx;
			ItemManager.Instance.AddItem(this.llightrune);
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00006BE8 File Offset: 0x00004DE8
		public void IceGreatSword()
		{
			this.Ice_GreatSword = this.runeassets.LoadAsset<GameObject>("GreatIceRuneSword");
			this.IceGreat_Sword = new CustomItem(this.Ice_GreatSword, true, new ItemConfig
			{
				Amount = 1,
				Name = "$greaticerunesword",
				Enabled = this.FrostEnable.Value,
				CraftingStation = "piece_artisanstation",
				RepairStation = "piece_artisanstation",
				MinStationLevel = 2,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Obsidian",
						Amount = this.ObsidianFrost.Value,
						AmountPerLevel = 5
					},
					new RequirementConfig
					{
						Item = "Iron",
						Amount = this.IronFrost.Value,
						AmountPerLevel = 25
					},
					new RequirementConfig
					{
						Item = "FreezeGland",
						Amount = this.IceFreezeGland.Value,
						AmountPerLevel = 10
					},
					new RequirementConfig
					{
						Item = "DragonTear",
						Amount = this.DragonTear.Value,
						AmountPerLevel = 5
					}
				}
			});
			this.IceGreat_Sword.ItemDrop.m_itemData.m_shared.m_maxQuality = 10;
			this.IceGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_damage = (float)this.greatdamagefrost.Value;
			this.IceGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_blunt = (float)this.greatbluntfrost.Value;
			this.IceGreat_Sword.ItemDrop.m_itemData.m_shared.m_toolTier = this.greattierfrost.Value;
			this.IceGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_slash = (float)this.greatslashvalfrost.Value;
			this.IceGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_pierce = (float)this.greatpiercefrost.Value;
			this.IceGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_chop = (float)this.greatchopfrost.Value;
			this.IceGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_pickaxe = (float)this.greatpickaxefrost.Value;
			this.IceGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_fire = (float)this.greatfirefrost.Value;
			this.IceGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_frost = (float)this.greatfrostfrost.Value;
			this.IceGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_lightning = (float)this.greatlightningfrost.Value;
			this.IceGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_poison = (float)this.greatpoisonfrost.Value;
			this.IceGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_spirit = (float)this.greatspiritfrost.Value;
			this.IceGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_damage = (float)this.greatdamageperfrost.Value;
			this.IceGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_blunt = (float)this.greatbluntperfrost.Value;
			this.IceGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_slash = (float)this.greatslashperfrost.Value;
			this.IceGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pierce = (float)this.greatpierceperfrost.Value;
			this.IceGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_chop = (float)this.greatchopperfrost.Value;
			this.IceGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pickaxe = (float)this.greatpickaxeperfrost.Value;
			this.IceGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_fire = (float)this.greatfireperfrost.Value;
			this.IceGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_frost = (float)this.greatfrostperfrost.Value;
			this.IceGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_lightning = (float)this.greatlightningperfrost.Value;
			this.IceGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_poison = (float)this.greatpoisonperfrost.Value;
			this.IceGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_spirit = (float)this.greatspiritperfrost.Value;
			this.IceGreat_Sword.ItemDrop.m_itemData.m_shared.m_attackForce = (float)this.greatattackforcefrost.Value;
			this.IceGreat_Sword.ItemDrop.m_itemData.m_shared.m_hitEffect = this.effecthit;
			this.IceGreat_Sword.ItemDrop.m_itemData.m_shared.m_blockEffect = this.effectblocked;
			this.IceGreat_Sword.ItemDrop.m_itemData.m_shared.m_triggerEffect = this.trigger;
			this.IceGreat_Sword.ItemDrop.m_itemData.m_shared.m_trailStartEffect = this.trailfx;
			ItemManager.Instance.AddItem(this.IceGreat_Sword);
		}

		// Token: 0x0600000A RID: 10 RVA: 0x000071C8 File Offset: 0x000053C8
		public void FireGreatSword()
		{
			this.Fire_GreatSword = this.runeassets.LoadAsset<GameObject>("GreatFireRuneSword");
			this.FireGreat_Sword = new CustomItem(this.Fire_GreatSword, true, new ItemConfig
			{
				Amount = 1,
				Name = "$greatfirerunesword",
				Enabled = this.FireEnable.Value,
				CraftingStation = "piece_artisanstation",
				RepairStation = "piece_artisanstation",
				MinStationLevel = 2,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Flametal",
						Amount = this.FireFlametal.Value,
						AmountPerLevel = 50
					},
					new RequirementConfig
					{
						Item = "SurtlingCore",
						Amount = this.FireSurtling.Value,
						AmountPerLevel = 35
					},
					new RequirementConfig
					{
						Item = "Iron",
						Amount = this.IronFire.Value,
						AmountPerLevel = 25
					},
					new RequirementConfig
					{
						Item = "Obsidian",
						Amount = this.ObsidianFire.Value,
						AmountPerLevel = 5
					}
				}
			});
			this.FireGreat_Sword.ItemDrop.m_itemData.m_shared.m_maxQuality = 10;
			this.FireGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_damage = (float)this.greatdamagefire.Value;
			this.FireGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_blunt = (float)this.greatbluntfire.Value;
			this.FireGreat_Sword.ItemDrop.m_itemData.m_shared.m_toolTier = this.greattierfire.Value;
			this.FireGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_slash = (float)this.greatslashvalfire.Value;
			this.FireGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_pierce = (float)this.greatpiercefire.Value;
			this.FireGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_chop = (float)this.greatchopfire.Value;
			this.FireGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_pickaxe = (float)this.greatpickaxefire.Value;
			this.FireGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_fire = (float)this.greatfirefire.Value;
			this.FireGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_frost = (float)this.greatfrostfire.Value;
			this.FireGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_lightning = (float)this.greatlightningfire.Value;
			this.FireGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_poison = (float)this.greatpoisonfire.Value;
			this.FireGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_spirit = (float)this.greatspiritfire.Value;
			this.FireGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_damage = (float)this.greatdamageperfire.Value;
			this.FireGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_blunt = (float)this.greatbluntperfire.Value;
			this.FireGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_slash = (float)this.greatslashperfire.Value;
			this.FireGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pierce = (float)this.greatpierceperfire.Value;
			this.FireGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_chop = (float)this.greatchopperfire.Value;
			this.FireGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pickaxe = (float)this.greatpickaxeperfire.Value;
			this.FireGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_fire = (float)this.greatfireperfire.Value;
			this.FireGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_frost = (float)this.greatfrostperfire.Value;
			this.FireGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_lightning = (float)this.greatlightningperfire.Value;
			this.FireGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_poison = (float)this.greatpoisonperfire.Value;
			this.FireGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_spirit = (float)this.greatspiritperfire.Value;
			this.FireGreat_Sword.ItemDrop.m_itemData.m_shared.m_attackForce = (float)this.greatattackforcefire.Value;
			this.FireGreat_Sword.ItemDrop.m_itemData.m_shared.m_hitEffect = this.effecthit;
			this.FireGreat_Sword.ItemDrop.m_itemData.m_shared.m_blockEffect = this.effectblocked;
			this.FireGreat_Sword.ItemDrop.m_itemData.m_shared.m_triggerEffect = this.trigger;
			this.FireGreat_Sword.ItemDrop.m_itemData.m_shared.m_trailStartEffect = this.trailfx;
			ItemManager.Instance.AddItem(this.FireGreat_Sword);
		}

		// Token: 0x0600000B RID: 11 RVA: 0x000077AC File Offset: 0x000059AC
		public void PoisonGreatSword()
		{
			this.Poison_GreatSword = this.runeassets.LoadAsset<GameObject>("GreatPoisonRuneSword");
			this.PoisonGreat_Sword = new CustomItem(this.Poison_GreatSword, true, new ItemConfig
			{
				Amount = 1,
				Name = "$greatpoisonrunesword",
				Enabled = this.PoisonEnable.Value,
				CraftingStation = "piece_artisanstation",
				RepairStation = "piece_artisanstation",
				MinStationLevel = 2,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Obsidian",
						Amount = this.ObsidianPoison.Value,
						AmountPerLevel = 10
					},
					new RequirementConfig
					{
						Item = "Ooze",
						Amount = this.PoisonOoze.Value,
						AmountPerLevel = 25
					},
					new RequirementConfig
					{
						Item = "Iron",
						Amount = this.IronPoison.Value,
						AmountPerLevel = 25
					},
					new RequirementConfig
					{
						Item = "Guck",
						Amount = this.PoisonGuck.Value,
						AmountPerLevel = 10
					}
				}
			});
			this.PoisonGreat_Sword.ItemDrop.m_itemData.m_shared.m_maxQuality = 10;
			this.PoisonGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_damage = (float)this.damageposion.Value;
			this.PoisonGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_blunt = (float)this.bluntposion.Value;
			this.PoisonGreat_Sword.ItemDrop.m_itemData.m_shared.m_toolTier = this.tierposion.Value;
			this.PoisonGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_slash = (float)this.slashvalposion.Value;
			this.PoisonGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_pierce = (float)this.pierceposion.Value;
			this.PoisonGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_chop = (float)this.chopposion.Value;
			this.PoisonGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_pickaxe = (float)this.pickaxeposion.Value;
			this.PoisonGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_fire = (float)this.fireposion.Value;
			this.PoisonGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_frost = (float)this.frostposion.Value;
			this.PoisonGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_lightning = (float)this.lightningposion.Value;
			this.PoisonGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_poison = (float)this.poisonposion.Value;
			this.PoisonGreat_Sword.ItemDrop.m_itemData.m_shared.m_damages.m_spirit = (float)this.spiritposion.Value;
			this.PoisonGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_damage = (float)this.damageperposion.Value;
			this.PoisonGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_blunt = (float)this.bluntperposion.Value;
			this.PoisonGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_slash = (float)this.slashperposion.Value;
			this.PoisonGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pierce = (float)this.pierceperposion.Value;
			this.PoisonGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_chop = (float)this.chopperposion.Value;
			this.PoisonGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pickaxe = (float)this.pickaxeperposion.Value;
			this.PoisonGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_fire = (float)this.fireperposion.Value;
			this.PoisonGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_frost = (float)this.frostperposion.Value;
			this.PoisonGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_lightning = (float)this.lightningperposion.Value;
			this.PoisonGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_poison = (float)this.poisonperposion.Value;
			this.PoisonGreat_Sword.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_spirit = (float)this.spiritperposion.Value;
			this.PoisonGreat_Sword.ItemDrop.m_itemData.m_shared.m_attackForce = (float)this.attackforceposion.Value;
			this.PoisonGreat_Sword.ItemDrop.m_itemData.m_shared.m_hitEffect = this.effecthit;
			this.PoisonGreat_Sword.ItemDrop.m_itemData.m_shared.m_blockEffect = this.effectblocked;
			this.PoisonGreat_Sword.ItemDrop.m_itemData.m_shared.m_triggerEffect = this.trigger;
			this.PoisonGreat_Sword.ItemDrop.m_itemData.m_shared.m_trailStartEffect = this.trailfx;
			ItemManager.Instance.AddItem(this.PoisonGreat_Sword);
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00007D90 File Offset: 0x00005F90
		public void LightningGreatSword()
		{
			this.Lgntng_GreatSword = this.runeassets.LoadAsset<GameObject>("GreatLightningRuneSword");
			this.YlwGreatSwrd = new CustomItem(this.Lgntng_GreatSword, true, new ItemConfig
			{
				Amount = 1,
				Name = "$greatlightningrunesword",
				Enabled = this.LightEnable.Value,
				CraftingStation = "piece_artisanstation",
				RepairStation = "piece_artisanstation",
				MinStationLevel = 2,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Obsidian",
						Amount = this.ObsidianLight.Value,
						AmountPerLevel = 5
					},
					new RequirementConfig
					{
						Item = "Iron",
						Amount = this.IronLight.Value,
						AmountPerLevel = 25
					},
					new RequirementConfig
					{
						Item = "TrophyEikthyr",
						Amount = this.Trophy.Value,
						AmountPerLevel = 1
					},
					new RequirementConfig
					{
						Item = "HardAntler",
						Amount = this.Antler.Value,
						AmountPerLevel = 10
					}
				}
			});
			this.YlwGreatSwrd.ItemDrop.m_itemData.m_shared.m_maxQuality = 10;
			this.YlwGreatSwrd.ItemDrop.m_itemData.m_shared.m_damages.m_damage = (float)this.greatdamagelight.Value;
			this.YlwGreatSwrd.ItemDrop.m_itemData.m_shared.m_damages.m_blunt = (float)this.greatbluntlight.Value;
			this.YlwGreatSwrd.ItemDrop.m_itemData.m_shared.m_toolTier = this.greattierlight.Value;
			this.YlwGreatSwrd.ItemDrop.m_itemData.m_shared.m_damages.m_slash = (float)this.greatslashvallight.Value;
			this.YlwGreatSwrd.ItemDrop.m_itemData.m_shared.m_damages.m_pierce = (float)this.greatpiercelight.Value;
			this.YlwGreatSwrd.ItemDrop.m_itemData.m_shared.m_damages.m_chop = (float)this.greatchoplight.Value;
			this.YlwGreatSwrd.ItemDrop.m_itemData.m_shared.m_damages.m_pickaxe = (float)this.greatpickaxelight.Value;
			this.YlwGreatSwrd.ItemDrop.m_itemData.m_shared.m_damages.m_fire = (float)this.greatfirelight.Value;
			this.YlwGreatSwrd.ItemDrop.m_itemData.m_shared.m_damages.m_frost = (float)this.greatfrostlight.Value;
			this.YlwGreatSwrd.ItemDrop.m_itemData.m_shared.m_damages.m_lightning = (float)this.greatlightninglight.Value;
			this.YlwGreatSwrd.ItemDrop.m_itemData.m_shared.m_damages.m_poison = (float)this.greatpoisonlight.Value;
			this.YlwGreatSwrd.ItemDrop.m_itemData.m_shared.m_damages.m_spirit = (float)this.greatspiritlight.Value;
			this.YlwGreatSwrd.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_damage = (float)this.greatdamageperlight.Value;
			this.YlwGreatSwrd.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_blunt = (float)this.greatbluntperlight.Value;
			this.YlwGreatSwrd.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_slash = (float)this.greatslashperlight.Value;
			this.YlwGreatSwrd.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pierce = (float)this.greatpierceperlight.Value;
			this.YlwGreatSwrd.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_chop = (float)this.greatchopperlight.Value;
			this.YlwGreatSwrd.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pickaxe = (float)this.greatpickaxeperlight.Value;
			this.YlwGreatSwrd.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_fire = (float)this.greatfireperlight.Value;
			this.YlwGreatSwrd.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_frost = (float)this.greatfrostperlight.Value;
			this.YlwGreatSwrd.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_lightning = (float)this.greatlightningperlight.Value;
			this.YlwGreatSwrd.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_poison = (float)this.greatpoisonperlight.Value;
			this.YlwGreatSwrd.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_spirit = (float)this.greatspiritperlight.Value;
			this.YlwGreatSwrd.ItemDrop.m_itemData.m_shared.m_attackForce = (float)this.greatattackforcelight.Value;
			this.YlwGreatSwrd.ItemDrop.m_itemData.m_shared.m_hitEffect = this.effecthit;
			this.YlwGreatSwrd.ItemDrop.m_itemData.m_shared.m_blockEffect = this.effectblocked;
			this.YlwGreatSwrd.ItemDrop.m_itemData.m_shared.m_triggerEffect = this.trigger;
			this.YlwGreatSwrd.ItemDrop.m_itemData.m_shared.m_trailStartEffect = this.trailfx;
			ItemManager.Instance.AddItem(this.YlwGreatSwrd);
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00008370 File Offset: 0x00006570
		public void IceDagger()
		{
			this.FrostDagger = this.runeassets.LoadAsset<GameObject>("IceRuneDagger");
			this.Frost_Dagger = new CustomItem(this.FrostDagger, true, new ItemConfig
			{
				Amount = 1,
				Name = "$icerunedagger",
				Enabled = this.FrostEnable.Value,
				CraftingStation = "piece_artisanstation",
				RepairStation = "piece_artisanstation",
				MinStationLevel = 2,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Obsidian",
						Amount = this.ObsidianFrost.Value,
						AmountPerLevel = 5
					},
					new RequirementConfig
					{
						Item = "Iron",
						Amount = this.IronFrost.Value,
						AmountPerLevel = 25
					},
					new RequirementConfig
					{
						Item = "FreezeGland",
						Amount = this.IceFreezeGland.Value,
						AmountPerLevel = 10
					},
					new RequirementConfig
					{
						Item = "DragonTear",
						Amount = this.DragonTear.Value,
						AmountPerLevel = 5
					}
				}
			});
			this.Frost_Dagger.ItemDrop.m_itemData.m_shared.m_maxQuality = 10;
			this.Frost_Dagger.ItemDrop.m_itemData.m_shared.m_damages.m_damage = (float)this.daggerdamagefrost.Value;
			this.Frost_Dagger.ItemDrop.m_itemData.m_shared.m_damages.m_blunt = (float)this.daggerbluntfrost.Value;
			this.Frost_Dagger.ItemDrop.m_itemData.m_shared.m_toolTier = this.daggertierfrost.Value;
			this.Frost_Dagger.ItemDrop.m_itemData.m_shared.m_damages.m_slash = (float)this.daggerslashvalfrost.Value;
			this.Frost_Dagger.ItemDrop.m_itemData.m_shared.m_damages.m_pierce = (float)this.daggerpiercefrost.Value;
			this.Frost_Dagger.ItemDrop.m_itemData.m_shared.m_damages.m_chop = (float)this.daggerchopfrost.Value;
			this.Frost_Dagger.ItemDrop.m_itemData.m_shared.m_damages.m_pickaxe = (float)this.daggerpickaxefrost.Value;
			this.Frost_Dagger.ItemDrop.m_itemData.m_shared.m_damages.m_fire = (float)this.daggerfirefrost.Value;
			this.Frost_Dagger.ItemDrop.m_itemData.m_shared.m_damages.m_frost = (float)this.daggerfrostfrost.Value;
			this.Frost_Dagger.ItemDrop.m_itemData.m_shared.m_damages.m_lightning = (float)this.daggerlightningfrost.Value;
			this.Frost_Dagger.ItemDrop.m_itemData.m_shared.m_damages.m_poison = (float)this.daggerpoisonfrost.Value;
			this.Frost_Dagger.ItemDrop.m_itemData.m_shared.m_damages.m_spirit = (float)this.daggerspiritfrost.Value;
			this.Frost_Dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_damage = (float)this.daggerdamageperfrost.Value;
			this.Frost_Dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_blunt = (float)this.daggerbluntperfrost.Value;
			this.Frost_Dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_slash = (float)this.daggerslashperfrost.Value;
			this.Frost_Dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pierce = (float)this.daggerpierceperfrost.Value;
			this.Frost_Dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_chop = (float)this.daggerchopperfrost.Value;
			this.Frost_Dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pickaxe = (float)this.daggerpickaxeperfrost.Value;
			this.Frost_Dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_fire = (float)this.daggerfireperfrost.Value;
			this.Frost_Dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_frost = (float)this.daggerfrostperfrost.Value;
			this.Frost_Dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_lightning = (float)this.daggerlightningperfrost.Value;
			this.Frost_Dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_poison = (float)this.daggerpoisonperfrost.Value;
			this.Frost_Dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_spirit = (float)this.daggerspiritperfrost.Value;
			this.Frost_Dagger.ItemDrop.m_itemData.m_shared.m_attackForce = (float)this.daggerattackforcefrost.Value;
			this.Frost_Dagger.ItemDrop.m_itemData.m_shared.m_hitEffect = this.effecthit;
			this.Frost_Dagger.ItemDrop.m_itemData.m_shared.m_blockEffect = this.effectblocked;
			this.Frost_Dagger.ItemDrop.m_itemData.m_shared.m_triggerEffect = this.trigger;
			this.Frost_Dagger.ItemDrop.m_itemData.m_shared.m_trailStartEffect = this.trailfx;
			ItemManager.Instance.AddItem(this.Frost_Dagger);
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00008950 File Offset: 0x00006B50
		public void FireDagger()
		{
			this.firedagger = this.runeassets.LoadAsset<GameObject>("FireRuneDagger");
			this.fire_dagger = new CustomItem(this.firedagger, true, new ItemConfig
			{
				Amount = 1,
				Name = "$firerunedagger",
				Enabled = this.FireEnable.Value,
				CraftingStation = "piece_artisanstation",
				RepairStation = "piece_artisanstation",
				MinStationLevel = 2,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Flametal",
						Amount = this.FireFlametal.Value,
						AmountPerLevel = 50
					},
					new RequirementConfig
					{
						Item = "SurtlingCore",
						Amount = this.FireSurtling.Value,
						AmountPerLevel = 35
					},
					new RequirementConfig
					{
						Item = "Iron",
						Amount = this.IronFire.Value,
						AmountPerLevel = 25
					},
					new RequirementConfig
					{
						Item = "Obsidian",
						Amount = this.ObsidianFire.Value,
						AmountPerLevel = 5
					}
				}
			});
			this.fire_dagger.ItemDrop.m_itemData.m_shared.m_maxQuality = 10;
			this.fire_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_damage = (float)this.daggerdamagefire.Value;
			this.fire_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_blunt = (float)this.daggerbluntfire.Value;
			this.fire_dagger.ItemDrop.m_itemData.m_shared.m_toolTier = this.daggertierfire.Value;
			this.fire_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_slash = (float)this.daggerslashvalfire.Value;
			this.fire_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_pierce = (float)this.daggerpiercefire.Value;
			this.fire_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_chop = (float)this.daggerchopfire.Value;
			this.fire_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_pickaxe = (float)this.daggerpickaxefire.Value;
			this.fire_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_fire = (float)this.daggerfirefire.Value;
			this.fire_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_frost = (float)this.daggerfrostfire.Value;
			this.fire_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_lightning = (float)this.daggerlightningfire.Value;
			this.fire_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_poison = (float)this.daggerpoisonfire.Value;
			this.fire_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_spirit = (float)this.daggerspiritfire.Value;
			this.fire_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_damage = (float)this.daggerdamageperfire.Value;
			this.fire_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_blunt = (float)this.daggerbluntperfire.Value;
			this.fire_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_slash = (float)this.daggerslashperfire.Value;
			this.fire_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pierce = (float)this.daggerpierceperfire.Value;
			this.fire_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_chop = (float)this.daggerchopperfire.Value;
			this.fire_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pickaxe = (float)this.daggerpickaxeperfire.Value;
			this.fire_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_fire = (float)this.daggerfireperfire.Value;
			this.fire_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_frost = (float)this.daggerfrostperfire.Value;
			this.fire_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_lightning = (float)this.daggerlightningperfire.Value;
			this.fire_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_poison = (float)this.daggerpoisonperfire.Value;
			this.fire_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_spirit = (float)this.daggerspiritperfire.Value;
			this.fire_dagger.ItemDrop.m_itemData.m_shared.m_attackForce = (float)this.daggerattackforcefire.Value;
			this.fire_dagger.ItemDrop.m_itemData.m_shared.m_hitEffect = this.effecthit;
			this.fire_dagger.ItemDrop.m_itemData.m_shared.m_blockEffect = this.effectblocked;
			this.fire_dagger.ItemDrop.m_itemData.m_shared.m_triggerEffect = this.trigger;
			this.fire_dagger.ItemDrop.m_itemData.m_shared.m_trailStartEffect = this.trailfx;
			ItemManager.Instance.AddItem(this.fire_dagger);
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00008F34 File Offset: 0x00007134
		public void PoisonDagger()
		{
			this.poisondagger = this.runeassets.LoadAsset<GameObject>("PoisonRuneDagger");
			this.poison_dagger = new CustomItem(this.poisondagger, true, new ItemConfig
			{
				Amount = 1,
				Name = "$poisonrunedagger",
				Enabled = this.PoisonEnable.Value,
				CraftingStation = "piece_artisanstation",
				RepairStation = "piece_artisanstation",
				MinStationLevel = 2,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Obsidian",
						Amount = this.ObsidianPoison.Value,
						AmountPerLevel = 10
					},
					new RequirementConfig
					{
						Item = "Ooze",
						Amount = this.PoisonOoze.Value,
						AmountPerLevel = 25
					},
					new RequirementConfig
					{
						Item = "Iron",
						Amount = this.IronPoison.Value,
						AmountPerLevel = 25
					},
					new RequirementConfig
					{
						Item = "Guck",
						Amount = this.PoisonGuck.Value,
						AmountPerLevel = 10
					}
				}
			});
			this.poison_dagger.ItemDrop.m_itemData.m_shared.m_maxQuality = 10;
			this.poison_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_damage = (float)this.daggerdamageposion.Value;
			this.poison_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_blunt = (float)this.daggerbluntposion.Value;
			this.poison_dagger.ItemDrop.m_itemData.m_shared.m_toolTier = this.daggertierposion.Value;
			this.poison_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_slash = (float)this.daggerslashvalposion.Value;
			this.poison_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_pierce = (float)this.daggerpierceposion.Value;
			this.poison_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_chop = (float)this.daggerchopposion.Value;
			this.poison_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_pickaxe = (float)this.daggerpickaxeposion.Value;
			this.poison_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_fire = (float)this.daggerfireposion.Value;
			this.poison_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_frost = (float)this.daggerfrostposion.Value;
			this.poison_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_lightning = (float)this.daggerlightningposion.Value;
			this.poison_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_poison = (float)this.daggerpoisonposion.Value;
			this.poison_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_spirit = (float)this.daggerspiritposion.Value;
			this.poison_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_damage = (float)this.daggerdamageperposion.Value;
			this.poison_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_blunt = (float)this.daggerbluntperposion.Value;
			this.poison_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_slash = (float)this.daggerslashperposion.Value;
			this.poison_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pierce = (float)this.daggerpierceperposion.Value;
			this.poison_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_chop = (float)this.daggerchopperposion.Value;
			this.poison_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pickaxe = (float)this.daggerpickaxeperposion.Value;
			this.poison_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_fire = (float)this.daggerfireperposion.Value;
			this.poison_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_frost = (float)this.daggerfrostperposion.Value;
			this.poison_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_lightning = (float)this.daggerlightningperposion.Value;
			this.poison_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_poison = (float)this.daggerpoisonperposion.Value;
			this.poison_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_spirit = (float)this.daggerspiritperposion.Value;
			this.poison_dagger.ItemDrop.m_itemData.m_shared.m_attackForce = (float)this.daggerattackforceposion.Value;
			this.poison_dagger.ItemDrop.m_itemData.m_shared.m_hitEffect = this.effecthit;
			this.poison_dagger.ItemDrop.m_itemData.m_shared.m_blockEffect = this.effectblocked;
			this.poison_dagger.ItemDrop.m_itemData.m_shared.m_triggerEffect = this.trigger;
			this.poison_dagger.ItemDrop.m_itemData.m_shared.m_trailStartEffect = this.trailfx;
			ItemManager.Instance.AddItem(this.poison_dagger);
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00009518 File Offset: 0x00007718
		public void LightningDagger()
		{
			this.lightningdagger = this.runeassets.LoadAsset<GameObject>("LightningRuneDagger");
			this.lightning_dagger = new CustomItem(this.lightningdagger, true, new ItemConfig
			{
				Amount = 1,
				Name = "$lightningrunedagger",
				Enabled = this.LightEnable.Value,
				CraftingStation = "piece_artisanstation",
				RepairStation = "piece_artisanstation",
				MinStationLevel = 2,
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Obsidian",
						Amount = this.ObsidianLight.Value,
						AmountPerLevel = 5
					},
					new RequirementConfig
					{
						Item = "Iron",
						Amount = this.IronLight.Value,
						AmountPerLevel = 25
					},
					new RequirementConfig
					{
						Item = "TrophyEikthyr",
						Amount = this.Trophy.Value,
						AmountPerLevel = 1
					},
					new RequirementConfig
					{
						Item = "HardAntler",
						Amount = this.Antler.Value,
						AmountPerLevel = 10
					}
				}
			});
			this.lightning_dagger.ItemDrop.m_itemData.m_shared.m_maxQuality = 10;
			this.lightning_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_damage = (float)this.daggerdamagelight.Value;
			this.lightning_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_blunt = (float)this.daggerbluntlight.Value;
			this.lightning_dagger.ItemDrop.m_itemData.m_shared.m_toolTier = this.daggertierlight.Value;
			this.lightning_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_slash = (float)this.daggerslashvallight.Value;
			this.lightning_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_pierce = (float)this.daggerpiercelight.Value;
			this.lightning_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_chop = (float)this.daggerchoplight.Value;
			this.lightning_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_pickaxe = (float)this.daggerpickaxelight.Value;
			this.lightning_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_fire = (float)this.daggerfirelight.Value;
			this.lightning_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_frost = (float)this.daggerfrostlight.Value;
			this.lightning_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_lightning = (float)this.daggerlightninglight.Value;
			this.lightning_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_poison = (float)this.daggerpoisonlight.Value;
			this.lightning_dagger.ItemDrop.m_itemData.m_shared.m_damages.m_spirit = (float)this.daggerspiritlight.Value;
			this.lightning_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_damage = (float)this.daggerdamageperlight.Value;
			this.lightning_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_blunt = (float)this.daggerbluntperlight.Value;
			this.lightning_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_slash = (float)this.daggerslashperlight.Value;
			this.lightning_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pierce = (float)this.daggerpierceperlight.Value;
			this.lightning_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_chop = (float)this.daggerchopperlight.Value;
			this.lightning_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_pickaxe = (float)this.daggerpickaxeperlight.Value;
			this.lightning_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_fire = (float)this.daggerfireperlight.Value;
			this.lightning_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_frost = (float)this.daggerfrostperlight.Value;
			this.lightning_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_lightning = (float)this.daggerlightningperlight.Value;
			this.lightning_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_poison = (float)this.daggerpoisonperlight.Value;
			this.lightning_dagger.ItemDrop.m_itemData.m_shared.m_damagesPerLevel.m_spirit = (float)this.daggerspiritperlight.Value;
			this.lightning_dagger.ItemDrop.m_itemData.m_shared.m_attackForce = (float)this.daggerattackforcelight.Value;
			this.lightning_dagger.ItemDrop.m_itemData.m_shared.m_hitEffect = this.effecthit;
			this.lightning_dagger.ItemDrop.m_itemData.m_shared.m_blockEffect = this.effectblocked;
			this.lightning_dagger.ItemDrop.m_itemData.m_shared.m_triggerEffect = this.trigger;
			this.lightning_dagger.ItemDrop.m_itemData.m_shared.m_trailStartEffect = this.trailfx;
			ItemManager.Instance.AddItem(this.lightning_dagger);
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00009AF8 File Offset: 0x00007CF8
		public void piece_exentension()
		{
			CustomPiece customPiece = new CustomPiece(this.runeassets.LoadAsset<GameObject>("piece_artisanice"), new PieceConfig
			{
				CraftingStation = "piece_artisanstation",
				Description = "$piece_artisan_ext1desrip",
				PieceTable = "Hammer",
				Enabled = true,
				ExtendStation = "piece_artisanstation",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Obsidian",
						Amount = 5,
						AmountPerLevel = 1,
						Recover = true
					}
				}
			});
			customPiece.Piece.m_placeEffect = this.buildsounds;
			PieceManager.Instance.AddPiece(customPiece);
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00009BA8 File Offset: 0x00007DA8
		public void piece_exentension1()
		{
			CustomPiece customPiece = new CustomPiece(this.runeassets.LoadAsset<GameObject>("piece_artisanpurp"), new PieceConfig
			{
				CraftingStation = "piece_artisanstation",
				Description = "$piece_artisan_ext3desrip",
				PieceTable = "Hammer",
				Enabled = true,
				ExtendStation = "piece_artisanstation",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Obsidian",
						Amount = 5,
						AmountPerLevel = 1,
						Recover = true
					}
				}
			});
			customPiece.Piece.m_placeEffect = this.buildsounds;
			PieceManager.Instance.AddPiece(customPiece);
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00009C58 File Offset: 0x00007E58
		public void piece_exentension2()
		{
			CustomPiece customPiece = new CustomPiece(this.runeassets.LoadAsset<GameObject>("piece_artisanpoison"), new PieceConfig
			{
				CraftingStation = "piece_artisanstation",
				Description = "$piece_artisan_ext2desrip",
				PieceTable = "Hammer",
				Enabled = true,
				ExtendStation = "piece_artisanstation",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Obsidian",
						Amount = 5,
						AmountPerLevel = 1,
						Recover = true
					}
				}
			});
			customPiece.Piece.m_placeEffect = this.buildsounds;
			PieceManager.Instance.AddPiece(customPiece);
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00009D08 File Offset: 0x00007F08
		private void piece_exentension3()
		{
			CustomPiece customPiece = new CustomPiece(this.runeassets.LoadAsset<GameObject>("piece_artisanlight"), new PieceConfig
			{
				CraftingStation = "piece_artisanstation",
				Description = "$piece_artisan_ext4desrip",
				PieceTable = "Hammer",
				Enabled = true,
				ExtendStation = "piece_artisanstation",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Obsidian",
						Amount = 5,
						AmountPerLevel = 1,
						Recover = true
					}
				}
			});
			customPiece.Piece.m_placeEffect = this.buildsounds;
			PieceManager.Instance.AddPiece(customPiece);
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00009DB8 File Offset: 0x00007FB8
		private void piece_exentension4()
		{
			CustomPiece customPiece = new CustomPiece(this.runeassets.LoadAsset<GameObject>("piece_artisanround1"), new PieceConfig
			{
				CraftingStation = "piece_artisanstation",
				Description = "$piece_artisan_ext5desrip",
				PieceTable = "Hammer",
				Enabled = true,
				ExtendStation = "piece_artisanstation",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Obsidian",
						Amount = 5,
						AmountPerLevel = 1,
						Recover = true
					}
				}
			});
			customPiece.Piece.m_placeEffect = this.buildsounds;
			PieceManager.Instance.AddPiece(customPiece);
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00009E68 File Offset: 0x00008068
		private void piece_exentension5()
		{
			CustomPiece customPiece = new CustomPiece(this.runeassets.LoadAsset<GameObject>("piece_artisanround2"), new PieceConfig
			{
				CraftingStation = "piece_artisanstation",
				Description = "$piece_artisan_ext6desrip",
				PieceTable = "Hammer",
				Enabled = true,
				ExtendStation = "piece_artisanstation",
				Requirements = new RequirementConfig[]
				{
					new RequirementConfig
					{
						Item = "Obsidian",
						Amount = 5,
						AmountPerLevel = 1,
						Recover = true
					}
				}
			});
			customPiece.Piece.m_placeEffect = this.buildsounds;
			PieceManager.Instance.AddPiece(customPiece);
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00009F18 File Offset: 0x00008118
		private void ConfigDeploy()
		{
			base.Config.SaveOnConfigSet = true;
			this.LightEnable = base.Config.Bind<bool>("Lightning Sword", "Enable", true, new ConfigDescription("Lightning Sword Enable", null, new object[]
			{
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.FireEnable = base.Config.Bind<bool>("Fire Sword", "Enable", true, new ConfigDescription("Fire Sword Enable", null, new object[]
			{
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.FrostEnable = base.Config.Bind<bool>("Frost Sword", "Enable", true, new ConfigDescription("Frost Sword Enable", null, new object[]
			{
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.PoisonEnable = base.Config.Bind<bool>("Poison Sword", "Enable", true, new ConfigDescription("Poison Sword Enable", null, new object[]
			{
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.ObsidianFrost = base.Config.Bind<int>("Frost Sword", "Obsidian Frost", 20, new ConfigDescription("Cost Of Obsidan for Frost", new AcceptableValueRange<int>(5, 250), new object[]
			{
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.ObsidianFire = base.Config.Bind<int>("Fire Sword", "Obsidian Fire", 20, new ConfigDescription("Cost Of Obsidan for Fire", new AcceptableValueRange<int>(5, 250), new object[]
			{
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.ObsidianLight = base.Config.Bind<int>("Lightning Sword", "Obsidian Lightning", 20, new ConfigDescription("Cost Of Obsidan for Lightning", new AcceptableValueRange<int>(5, 250), new object[]
			{
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.ObsidianPoison = base.Config.Bind<int>("Poison Sword", "Obsidian Poison", 50, new ConfigDescription("Server side integer", new AcceptableValueRange<int>(5, 250), new object[]
			{
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.IronFrost = base.Config.Bind<int>("Frost Sword", "Iron Frost", 50, new ConfigDescription("Cost Of Iron For Frost", new AcceptableValueRange<int>(5, 250), new object[]
			{
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.IronFire = base.Config.Bind<int>("Fire Sword", "Iron Fire", 50, new ConfigDescription("Cost Of Iron For Fire", new AcceptableValueRange<int>(5, 250), new object[]
			{
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.IronLight = base.Config.Bind<int>("Lightning Sword", "Iron Lightning", 50, new ConfigDescription("Cost Of Iron For Lightning", new AcceptableValueRange<int>(5, 250), new object[]
			{
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.IronPoison = base.Config.Bind<int>("Poison Sword", "Iron Poison", 50, new ConfigDescription("Cost Of Iron For Poison", new AcceptableValueRange<int>(5, 250), new object[]
			{
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.IceFreezeGland = base.Config.Bind<int>("Frost Sword", "Ice Glands", 25, new ConfigDescription("FreezeGland Cost", new AcceptableValueRange<int>(5, 250), new object[]
			{
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.DragonTear = base.Config.Bind<int>("Frost Sword", "Dragon Tears", 10, new ConfigDescription("DragonTear Cost", new AcceptableValueRange<int>(5, 250), new object[]
			{
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.FireFlametal = base.Config.Bind<int>("Fire Sword", "Flametal", 100, new ConfigDescription("Flametal Cost", new AcceptableValueRange<int>(5, 250), new object[]
			{
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.FireSurtling = base.Config.Bind<int>("Fire Sword", "SurtlingCore", 75, new ConfigDescription("SurtlingCore Cost", new AcceptableValueRange<int>(5, 250), new object[]
			{
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.PoisonOoze = base.Config.Bind<int>("Poison Sword", "Ooze", 50, new ConfigDescription("Ooze Cost", new AcceptableValueRange<int>(5, 250), new object[]
			{
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.PoisonGuck = base.Config.Bind<int>("Poison Sword", "Guck", 50, new ConfigDescription("Guck Cost", new AcceptableValueRange<int>(5, 250), new object[]
			{
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.Trophy = base.Config.Bind<int>("Lightning Sword", "Trophy", 5, new ConfigDescription("Trophy Cost", new AcceptableValueRange<int>(5, 250), new object[]
			{
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.Antler = base.Config.Bind<int>("Lightning Sword", "Antler", 25, new ConfigDescription("Antler Cost", new AcceptableValueRange<int>(5, 250), new object[]
			{
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.damagefrost = base.Config.Bind<int>("Frost Sword", "Overall Damage", 0, new ConfigDescription("Overall Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.bluntfrost = base.Config.Bind<int>("Frost Sword", "Blunt Damge", 0, new ConfigDescription("Blunt Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.slashvalfrost = base.Config.Bind<int>("Frost Sword", "Slash Damage", 300, new ConfigDescription("Slash Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.piercefrost = base.Config.Bind<int>("Frost Sword", "Pierce Damge", 135, new ConfigDescription("Pierce Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.chopfrost = base.Config.Bind<int>("Frost Sword", "Chop Damage", 0, new ConfigDescription("Chop Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.pickaxefrost = base.Config.Bind<int>("Frost Sword", "PickAxe Damage", 0, new ConfigDescription("Pickaxe Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.firefrost = base.Config.Bind<int>("Frost Sword", "Fire Damage", 0, new ConfigDescription("Fire Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.frostfrost = base.Config.Bind<int>("Frost Sword", "Frost Damage", 250, new ConfigDescription("Frost Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.lightningfrost = base.Config.Bind<int>("Frost Sword", "Lightning Damage", 0, new ConfigDescription("Lightning Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.poisonfrost = base.Config.Bind<int>("Frost Sword", "Poison Damage", 0, new ConfigDescription("Poison Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.spiritfrost = base.Config.Bind<int>("Frost Sword", "Spirit Damage", 100, new ConfigDescription("Spirit Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.damageperfrost = base.Config.Bind<int>("Frost Sword", "Overall Damage Per Level", 50, new ConfigDescription("Overall Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.bluntperfrost = base.Config.Bind<int>("Frost Sword", "Blunt Damage Per Level", 50, new ConfigDescription("Blunt Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.slashperfrost = base.Config.Bind<int>("Frost Sword", "Slash Damage Per Level", 50, new ConfigDescription("Slash Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.pierceperfrost = base.Config.Bind<int>("Frost Sword", "Pierce Damage Per Level", 50, new ConfigDescription("Pierce Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.chopperfrost = base.Config.Bind<int>("Frost Sword", "Chop Damage Per Level", 50, new ConfigDescription("Chop Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.pickaxeperfrost = base.Config.Bind<int>("Frost Sword", "PickAxe Damage Per Level", 50, new ConfigDescription("PickAxe Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.fireperfrost = base.Config.Bind<int>("Frost Sword", "Fire Damage Per Level", 50, new ConfigDescription("Fire Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.frostperfrost = base.Config.Bind<int>("Frost Sword", "Frost Damage Per Level", 50, new ConfigDescription("Frost Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.lightningperfrost = base.Config.Bind<int>("Frost Sword", "Lightning Damage Per Level", 50, new ConfigDescription("Lightning Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.poisonperfrost = base.Config.Bind<int>("Frost Sword", "Poison Damage Per Level", 50, new ConfigDescription("Poison Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.spiritperfrost = base.Config.Bind<int>("Frost Sword", "Spirit Damage Per Level", 50, new ConfigDescription("Spirit Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.tierfrost = base.Config.Bind<int>("Frost Sword", "Tool Tier", 5, new ConfigDescription("Tool Tier", new AcceptableValueRange<int>(0, 10), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.attackforcefrost = base.Config.Bind<int>("Frost Sword", "Attack Force", 30, new ConfigDescription("Attack Force", new AcceptableValueRange<int>(0, 100), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatdamagefrost = base.Config.Bind<int>("Great Frost Sword", "Overall Damage", 0, new ConfigDescription("Overall Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatbluntfrost = base.Config.Bind<int>("Great Frost Sword", "Blunt Damge", 0, new ConfigDescription("Blunt Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatslashvalfrost = base.Config.Bind<int>("Great Frost Sword", "Slash Damage", 300, new ConfigDescription("Slash Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatpiercefrost = base.Config.Bind<int>("Great Frost Sword", "Pierce Damge", 135, new ConfigDescription("Pierce Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatchopfrost = base.Config.Bind<int>("Great Frost Sword", "Chop Damage", 0, new ConfigDescription("Chop Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatpickaxefrost = base.Config.Bind<int>("Great Frost Sword", "PickAxe Damage", 0, new ConfigDescription("Pickaxe Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatfirefrost = base.Config.Bind<int>("Great Frost Sword", "Fire Damage", 0, new ConfigDescription("Fire Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatfrostfrost = base.Config.Bind<int>("Great Frost Sword", "Frost Damage", 250, new ConfigDescription("Frost Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatlightningfrost = base.Config.Bind<int>("Great Frost Sword", "Lightning Damage", 0, new ConfigDescription("Lightning Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatpoisonfrost = base.Config.Bind<int>("Great Frost Sword", "Poison Damage", 0, new ConfigDescription("Poison Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatspiritfrost = base.Config.Bind<int>("Great Frost Sword", "Spirit Damage", 100, new ConfigDescription("Spirit Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatdamageperfrost = base.Config.Bind<int>("Great Frost Sword", "Overall Damage Per Level", 50, new ConfigDescription("Overall Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatbluntperfrost = base.Config.Bind<int>("Great Frost Sword", "Blunt Damage Per Level", 50, new ConfigDescription("Blunt Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatslashperfrost = base.Config.Bind<int>("Great Frost Sword", "Slash Damage Per Level", 50, new ConfigDescription("Slash Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatpierceperfrost = base.Config.Bind<int>("Great Frost Sword", "Pierce Damage Per Level", 50, new ConfigDescription("Pierce Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatchopperfrost = base.Config.Bind<int>("Great Frost Sword", "Chop Damage Per Level", 50, new ConfigDescription("Chop Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatpickaxeperfrost = base.Config.Bind<int>("Great Frost Sword", "PickAxe Damage Per Level", 50, new ConfigDescription("PickAxe Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatfireperfrost = base.Config.Bind<int>("Great Frost Sword", "Fire Damage Per Level", 50, new ConfigDescription("Fire Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatfrostperfrost = base.Config.Bind<int>("Great Frost Sword", "Frost Damage Per Level", 50, new ConfigDescription("Frost Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatlightningperfrost = base.Config.Bind<int>("Great Frost Sword", "Lightning Damage Per Level", 50, new ConfigDescription("Lightning Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatpoisonperfrost = base.Config.Bind<int>("Great Frost Sword", "Poison Damage Per Level", 50, new ConfigDescription("Poison Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatspiritperfrost = base.Config.Bind<int>("Great Frost Sword", "Spirit Damage Per Level", 50, new ConfigDescription("Spirit Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greattierfrost = base.Config.Bind<int>("Great Frost Sword", "Tool Tier", 5, new ConfigDescription("Tool Tier", new AcceptableValueRange<int>(0, 10), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatattackforcefrost = base.Config.Bind<int>("Great Frost Sword", "Attack Force", 30, new ConfigDescription("Attack Force", new AcceptableValueRange<int>(0, 100), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerdamagefrost = base.Config.Bind<int>("Runic Frost Dagger", "Overall Damage", 0, new ConfigDescription("Overall Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerbluntfrost = base.Config.Bind<int>("Runic Frost Dagger", "Blunt Damge", 0, new ConfigDescription("Blunt Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerslashvalfrost = base.Config.Bind<int>("Runic Frost Dagger", "Slash Damage", 300, new ConfigDescription("Slash Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerpiercefrost = base.Config.Bind<int>("Runic Frost Dagger", "Pierce Damge", 135, new ConfigDescription("Pierce Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerchopfrost = base.Config.Bind<int>("Runic Frost Dagger", "Chop Damage", 0, new ConfigDescription("Chop Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerpickaxefrost = base.Config.Bind<int>("Runic Frost Dagger", "PickAxe Damage", 0, new ConfigDescription("Pickaxe Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerfirefrost = base.Config.Bind<int>("Runic Frost Dagger", "Fire Damage", 0, new ConfigDescription("Fire Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerfrostfrost = base.Config.Bind<int>("Runic Frost Dagger", "Frost Damage", 250, new ConfigDescription("Frost Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerlightningfrost = base.Config.Bind<int>("Runic Frost Dagger", "Lightning Damage", 0, new ConfigDescription("Lightning Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerpoisonfrost = base.Config.Bind<int>("Runic Frost Dagger", "Poison Damage", 0, new ConfigDescription("Poison Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerspiritfrost = base.Config.Bind<int>("Runic Frost Dagger", "Spirit Damage", 100, new ConfigDescription("Spirit Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerdamageperfrost = base.Config.Bind<int>("Runic Frost Dagger", "Overall Damage Per Level", 50, new ConfigDescription("Overall Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerbluntperfrost = base.Config.Bind<int>("Runic Frost Dagger", "Blunt Damage Per Level", 50, new ConfigDescription("Blunt Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerslashperfrost = base.Config.Bind<int>("Runic Frost Dagger", "Slash Damage Per Level", 50, new ConfigDescription("Slash Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerpierceperfrost = base.Config.Bind<int>("Runic Frost Dagger", "Pierce Damage Per Level", 50, new ConfigDescription("Pierce Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerchopperfrost = base.Config.Bind<int>("Runic Frost Dagger", "Chop Damage Per Level", 50, new ConfigDescription("Chop Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerpickaxeperfrost = base.Config.Bind<int>("Runic Frost Dagger", "PickAxe Damage Per Level", 50, new ConfigDescription("PickAxe Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerfireperfrost = base.Config.Bind<int>("Runic Frost Dagger", "Fire Damage Per Level", 50, new ConfigDescription("Fire Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerfrostperfrost = base.Config.Bind<int>("Runic Frost Dagger", "Frost Damage Per Level", 50, new ConfigDescription("Frost Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerlightningperfrost = base.Config.Bind<int>("Runic Frost Dagger", "Lightning Damage Per Level", 50, new ConfigDescription("Lightning Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerpoisonperfrost = base.Config.Bind<int>("Runic Frost Dagger", "Poison Damage Per Level", 50, new ConfigDescription("Poison Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerspiritperfrost = base.Config.Bind<int>("Runic Frost Dagger", "Spirit Damage Per Level", 50, new ConfigDescription("Spirit Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggertierfrost = base.Config.Bind<int>("Runic Frost Dagger", "Tool Tier", 5, new ConfigDescription("Tool Tier", new AcceptableValueRange<int>(0, 10), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerattackforcefrost = base.Config.Bind<int>("Runic Frost Dagger", "Attack Force", 30, new ConfigDescription("Attack Force", new AcceptableValueRange<int>(0, 100), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.damagefire = base.Config.Bind<int>("Fire Sword", "Overall Damage", 0, new ConfigDescription("Overall Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.bluntfire = base.Config.Bind<int>("Fire Sword", "Blunt Damge", 0, new ConfigDescription("Blunt Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.slashvalfire = base.Config.Bind<int>("Fire Sword", "Slash Damage", 300, new ConfigDescription("Slash Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.piercefire = base.Config.Bind<int>("Fire Sword", "Pierce Damge", 235, new ConfigDescription("Pierce Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.chopfire = base.Config.Bind<int>("Fire Sword", "Chop Damage", 0, new ConfigDescription("Chop Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.pickaxefire = base.Config.Bind<int>("Fire Sword", "PickAxe Damage", 0, new ConfigDescription("Pickaxe Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.firefire = base.Config.Bind<int>("Fire Sword", "Fire Damage", 200, new ConfigDescription("Fire Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.frostfire = base.Config.Bind<int>("Fire Sword", "Frost Damage", 0, new ConfigDescription("Frost Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.lightningfire = base.Config.Bind<int>("Fire Sword", "Lightning Damage", 0, new ConfigDescription("Lightning Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.poisonfire = base.Config.Bind<int>("Fire Sword", "Poison Damage", 0, new ConfigDescription("Poison Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.spiritfire = base.Config.Bind<int>("Fire Sword", "Spirit Damage", 100, new ConfigDescription("Spirit Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.damageperfire = base.Config.Bind<int>("Fire Sword", "Overall Damage Per Level", 50, new ConfigDescription("Overall Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.bluntperfire = base.Config.Bind<int>("Fire Sword", "Blunt Damage Per Level", 50, new ConfigDescription("Blunt Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.slashperfire = base.Config.Bind<int>("Fire Sword", "Slash Damage Per Level", 50, new ConfigDescription("Slash Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.pierceperfire = base.Config.Bind<int>("Fire Sword", "Pierce Damage Per Level", 50, new ConfigDescription("Pierce Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.chopperfire = base.Config.Bind<int>("Fire Sword", "Chop Damage Per Level", 50, new ConfigDescription("Chop Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.pickaxeperfire = base.Config.Bind<int>("Fire Sword", "PickAxe Damage Per Level", 50, new ConfigDescription("PickAxe Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.fireperfire = base.Config.Bind<int>("Fire Sword", "Fire Damage Per Level", 50, new ConfigDescription("Fire Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.frostperfire = base.Config.Bind<int>("Fire Sword", "Frost Damage Per Level", 50, new ConfigDescription("Frost Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.lightningperfire = base.Config.Bind<int>("Fire Sword", "Lightning Damage Per Level", 50, new ConfigDescription("Lightning Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.poisonperfire = base.Config.Bind<int>("Fire Sword", "Poison Damage Per Level", 50, new ConfigDescription("Poison Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.spiritperfire = base.Config.Bind<int>("Fire Sword", "Spirit Damage Per Level", 50, new ConfigDescription("Spirit Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.tierfire = base.Config.Bind<int>("Fire Sword", "Tool Tier", 5, new ConfigDescription("Tool Tier", new AcceptableValueRange<int>(0, 10), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.attackforcefire = base.Config.Bind<int>("Fire Sword", "Attack Force", 90, new ConfigDescription("Attack Force", new AcceptableValueRange<int>(0, 100), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatdamagefire = base.Config.Bind<int>("Great Fire Sword", "Overall Damage", 0, new ConfigDescription("Overall Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatbluntfire = base.Config.Bind<int>("Great Fire Sword", "Blunt Damge", 0, new ConfigDescription("Blunt Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatslashvalfire = base.Config.Bind<int>("Great Fire Sword", "Slash Damage", 300, new ConfigDescription("Slash Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatpiercefire = base.Config.Bind<int>("Great Fire Sword", "Pierce Damge", 235, new ConfigDescription("Pierce Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatchopfire = base.Config.Bind<int>("Great Fire Sword", "Chop Damage", 0, new ConfigDescription("Chop Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatpickaxefire = base.Config.Bind<int>("Great Fire Sword", "PickAxe Damage", 0, new ConfigDescription("Pickaxe Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatfirefire = base.Config.Bind<int>("Great Fire Sword", "Fire Damage", 200, new ConfigDescription("Fire Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatfrostfire = base.Config.Bind<int>("Great Fire Sword", "Frost Damage", 0, new ConfigDescription("Frost Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatlightningfire = base.Config.Bind<int>("Great Fire Sword", "Lightning Damage", 0, new ConfigDescription("Lightning Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatpoisonfire = base.Config.Bind<int>("Great Fire Sword", "Poison Damage", 0, new ConfigDescription("Poison Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatspiritfire = base.Config.Bind<int>("Great Fire Sword", "Spirit Damage", 100, new ConfigDescription("Spirit Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatdamageperfire = base.Config.Bind<int>("Great Fire Sword", "Overall Damage Per Level", 50, new ConfigDescription("Overall Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatbluntperfire = base.Config.Bind<int>("Great Fire Sword", "Blunt Damage Per Level", 50, new ConfigDescription("Blunt Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatslashperfire = base.Config.Bind<int>("Great Fire Sword", "Slash Damage Per Level", 50, new ConfigDescription("Slash Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatpierceperfire = base.Config.Bind<int>("Great Fire Sword", "Pierce Damage Per Level", 50, new ConfigDescription("Pierce Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatchopperfire = base.Config.Bind<int>("Great Fire Sword", "Chop Damage Per Level", 50, new ConfigDescription("Chop Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatpickaxeperfire = base.Config.Bind<int>("Great Fire Sword", "PickAxe Damage Per Level", 50, new ConfigDescription("PickAxe Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatfireperfire = base.Config.Bind<int>("Great Fire Sword", "Fire Damage Per Level", 50, new ConfigDescription("Fire Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatfrostperfire = base.Config.Bind<int>("Great Fire Sword", "Frost Damage Per Level", 50, new ConfigDescription("Frost Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatlightningperfire = base.Config.Bind<int>("Great Fire Sword", "Lightning Damage Per Level", 50, new ConfigDescription("Lightning Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatpoisonperfire = base.Config.Bind<int>("Great Fire Sword", "Poison Damage Per Level", 50, new ConfigDescription("Poison Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatspiritperfire = base.Config.Bind<int>("Great Fire Sword", "Spirit Damage Per Level", 50, new ConfigDescription("Spirit Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greattierfire = base.Config.Bind<int>("Great Fire Sword", "Tool Tier", 5, new ConfigDescription("Tool Tier", new AcceptableValueRange<int>(0, 10), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatattackforcefire = base.Config.Bind<int>("Great Fire Sword", "Attack Force", 90, new ConfigDescription("Attack Force", new AcceptableValueRange<int>(0, 100), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerdamagefire = base.Config.Bind<int>("Fire Dagger", "Overall Damage", 0, new ConfigDescription("Overall Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerbluntfire = base.Config.Bind<int>("Fire Dagger", "Blunt Damge", 0, new ConfigDescription("Blunt Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerslashvalfire = base.Config.Bind<int>("Fire Dagger", "Slash Damage", 300, new ConfigDescription("Slash Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerpiercefire = base.Config.Bind<int>("Fire Dagger", "Pierce Damge", 235, new ConfigDescription("Pierce Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerchopfire = base.Config.Bind<int>("Fire Dagger", "Chop Damage", 0, new ConfigDescription("Chop Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerpickaxefire = base.Config.Bind<int>("Fire Dagger", "PickAxe Damage", 0, new ConfigDescription("Pickaxe Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerfirefire = base.Config.Bind<int>("Fire Dagger", "Fire Damage", 200, new ConfigDescription("Fire Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerfrostfire = base.Config.Bind<int>("Fire Dagger", "Frost Damage", 0, new ConfigDescription("Frost Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerlightningfire = base.Config.Bind<int>("Fire Dagger", "Lightning Damage", 0, new ConfigDescription("Lightning Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerpoisonfire = base.Config.Bind<int>("Fire Dagger", "Poison Damage", 0, new ConfigDescription("Poison Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerspiritfire = base.Config.Bind<int>("Fire Dagger", "Spirit Damage", 100, new ConfigDescription("Spirit Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerdamageperfire = base.Config.Bind<int>("Fire Dagger", "Overall Damage Per Level", 50, new ConfigDescription("Overall Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerbluntperfire = base.Config.Bind<int>("Fire Dagger", "Blunt Damage Per Level", 50, new ConfigDescription("Blunt Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerslashperfire = base.Config.Bind<int>("Fire Dagger", "Slash Damage Per Level", 50, new ConfigDescription("Slash Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerpierceperfire = base.Config.Bind<int>("Fire Dagger", "Pierce Damage Per Level", 50, new ConfigDescription("Pierce Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerchopperfire = base.Config.Bind<int>("Fire Dagger", "Chop Damage Per Level", 50, new ConfigDescription("Chop Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerpickaxeperfire = base.Config.Bind<int>("Fire Dagger", "PickAxe Damage Per Level", 50, new ConfigDescription("PickAxe Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerfireperfire = base.Config.Bind<int>("Fire Dagger", "Fire Damage Per Level", 50, new ConfigDescription("Fire Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerfrostperfire = base.Config.Bind<int>("Fire Dagger", "Frost Damage Per Level", 50, new ConfigDescription("Frost Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerlightningperfire = base.Config.Bind<int>("Fire Dagger", "Lightning Damage Per Level", 50, new ConfigDescription("Lightning Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerpoisonperfire = base.Config.Bind<int>("Fire Dagger", "Poison Damage Per Level", 50, new ConfigDescription("Poison Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerspiritperfire = base.Config.Bind<int>("Fire Dagger", "Spirit Damage Per Level", 50, new ConfigDescription("Spirit Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggertierfire = base.Config.Bind<int>("Fire Dagger", "Tool Tier", 5, new ConfigDescription("Tool Tier", new AcceptableValueRange<int>(0, 10), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerattackforcefire = base.Config.Bind<int>("Fire Dagger", "Attack Force", 90, new ConfigDescription("Attack Force", new AcceptableValueRange<int>(0, 100), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.damagelight = base.Config.Bind<int>("Lightning Sword", "Overall Damage", 0, new ConfigDescription("Overall Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.bluntlight = base.Config.Bind<int>("Lightning Sword", "Blunt Damge", 0, new ConfigDescription("Blunt Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.slashvallight = base.Config.Bind<int>("Lightning Sword", "Slash Damage", 300, new ConfigDescription("Slash Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.piercelight = base.Config.Bind<int>("Lightning Sword", "Pierce Damge", 135, new ConfigDescription("Pierce Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.choplight = base.Config.Bind<int>("Lightning Sword", "Chop Damage", 0, new ConfigDescription("Chop Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.pickaxelight = base.Config.Bind<int>("Lightning Sword", "PickAxe Damage", 0, new ConfigDescription("Pickaxe Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.firelight = base.Config.Bind<int>("Lightning Sword", "Fire Damage", 0, new ConfigDescription("Fire Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.frostlight = base.Config.Bind<int>("Lightning Sword", "Frost Damage", 0, new ConfigDescription("Frost Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.lightninglight = base.Config.Bind<int>("Lightning Sword", "Lightning Damage", 250, new ConfigDescription("Lightning Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.poisonlight = base.Config.Bind<int>("Lightning Sword", "Poison Damage", 0, new ConfigDescription("Poison Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.spiritlight = base.Config.Bind<int>("Lightning Sword", "Spirit Damage", 100, new ConfigDescription("Spirit Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.damageperlight = base.Config.Bind<int>("Lightning Sword", "Overall Damage Per Level", 50, new ConfigDescription("Overall Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.bluntperlight = base.Config.Bind<int>("Lightning Sword", "Blunt Damage Per Level", 50, new ConfigDescription("Blunt Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.slashperlight = base.Config.Bind<int>("Lightning Sword", "Slash Damage Per Level", 50, new ConfigDescription("Slash Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.pierceperlight = base.Config.Bind<int>("Lightning Sword", "Pierce Damage Per Level", 50, new ConfigDescription("Pierce Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.chopperlight = base.Config.Bind<int>("Lightning Sword", "Chop Damage Per Level", 50, new ConfigDescription("Chop Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.pickaxeperlight = base.Config.Bind<int>("Lightning Sword", "PickAxe Damage Per Level", 50, new ConfigDescription("PickAxe Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.fireperlight = base.Config.Bind<int>("Lightning Sword", "Fire Damage Per Level", 50, new ConfigDescription("Fire Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.frostperlight = base.Config.Bind<int>("Lightning Sword", "Frost Damage Per Level", 50, new ConfigDescription("Frost Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.lightningperlight = base.Config.Bind<int>("Lightning Sword", "Lightning Damage Per Level", 50, new ConfigDescription("Lightning Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.poisonperlight = base.Config.Bind<int>("Lightning Sword", "Poison Damage Per Level", 50, new ConfigDescription("Poison Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.spiritperlight = base.Config.Bind<int>("Lightning Sword", "Spirit Damage Per Level", 50, new ConfigDescription("Spirit Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.tierlight = base.Config.Bind<int>("Lightning Sword", "Tool Tier", 5, new ConfigDescription("Tool Tier", new AcceptableValueRange<int>(0, 10), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.attackforcelight = base.Config.Bind<int>("Lightning Sword", "Attack Force", 90, new ConfigDescription("Attack Force", new AcceptableValueRange<int>(0, 100), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatdamagelight = base.Config.Bind<int>("Great Lightning Sword", "Overall Damage", 0, new ConfigDescription("Overall Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatbluntlight = base.Config.Bind<int>("Great Lightning Sword", "Blunt Damge", 0, new ConfigDescription("Blunt Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatslashvallight = base.Config.Bind<int>("Great Lightning Sword", "Slash Damage", 300, new ConfigDescription("Slash Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatpiercelight = base.Config.Bind<int>("Great Lightning Sword", "Pierce Damge", 135, new ConfigDescription("Pierce Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatchoplight = base.Config.Bind<int>("Great Lightning Sword", "Chop Damage", 0, new ConfigDescription("Chop Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatpickaxelight = base.Config.Bind<int>("Great Lightning Sword", "PickAxe Damage", 0, new ConfigDescription("Pickaxe Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatfirelight = base.Config.Bind<int>("Great Lightning Sword", "Fire Damage", 0, new ConfigDescription("Fire Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatfrostlight = base.Config.Bind<int>("Great Lightning Sword", "Frost Damage", 0, new ConfigDescription("Frost Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatlightninglight = base.Config.Bind<int>("Great Lightning Sword", "Lightning Damage", 250, new ConfigDescription("Lightning Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatpoisonlight = base.Config.Bind<int>("Great Lightning Sword", "Poison Damage", 0, new ConfigDescription("Poison Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatspiritlight = base.Config.Bind<int>("Great Lightning Sword", "Spirit Damage", 100, new ConfigDescription("Spirit Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatdamageperlight = base.Config.Bind<int>("Great Lightning Sword", "Overall Damage Per Level", 50, new ConfigDescription("Overall Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatbluntperlight = base.Config.Bind<int>("Great Lightning Sword", "Blunt Damage Per Level", 50, new ConfigDescription("Blunt Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatslashperlight = base.Config.Bind<int>("Great Lightning Sword", "Slash Damage Per Level", 50, new ConfigDescription("Slash Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatpierceperlight = base.Config.Bind<int>("Great Lightning Sword", "Pierce Damage Per Level", 50, new ConfigDescription("Pierce Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatchopperlight = base.Config.Bind<int>("Great Lightning Sword", "Chop Damage Per Level", 50, new ConfigDescription("Chop Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatpickaxeperlight = base.Config.Bind<int>("Great Lightning Sword", "PickAxe Damage Per Level", 50, new ConfigDescription("PickAxe Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatfireperlight = base.Config.Bind<int>("Great Lightning Sword", "Fire Damage Per Level", 50, new ConfigDescription("Fire Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatfrostperlight = base.Config.Bind<int>("Great Lightning Sword", "Frost Damage Per Level", 50, new ConfigDescription("Frost Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatlightningperlight = base.Config.Bind<int>("Great Lightning Sword", "Lightning Damage Per Level", 50, new ConfigDescription("Lightning Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatpoisonperlight = base.Config.Bind<int>("Great Lightning Sword", "Poison Damage Per Level", 50, new ConfigDescription("Poison Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatspiritperlight = base.Config.Bind<int>("Great Lightning Sword", "Spirit Damage Per Level", 50, new ConfigDescription("Spirit Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greattierlight = base.Config.Bind<int>("Great Lightning Sword", "Tool Tier", 5, new ConfigDescription("Tool Tier", new AcceptableValueRange<int>(0, 10), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatattackforcelight = base.Config.Bind<int>("Great Lightning Sword", "Attack Force", 90, new ConfigDescription("Attack Force", new AcceptableValueRange<int>(0, 100), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerdamagelight = base.Config.Bind<int>("Lightning Dagger", "Overall Damage", 0, new ConfigDescription("Overall Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerbluntlight = base.Config.Bind<int>("Lightning Dagger", "Blunt Damge", 0, new ConfigDescription("Blunt Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerslashvallight = base.Config.Bind<int>("Lightning Dagger", "Slash Damage", 300, new ConfigDescription("Slash Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerpiercelight = base.Config.Bind<int>("Lightning Dagger", "Pierce Damge", 135, new ConfigDescription("Pierce Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerchoplight = base.Config.Bind<int>("Lightning Dagger", "Chop Damage", 0, new ConfigDescription("Chop Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerpickaxelight = base.Config.Bind<int>("Lightning Dagger", "PickAxe Damage", 0, new ConfigDescription("Pickaxe Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerfirelight = base.Config.Bind<int>("Lightning Dagger", "Fire Damage", 0, new ConfigDescription("Fire Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerfrostlight = base.Config.Bind<int>("Lightning Dagger", "Frost Damage", 0, new ConfigDescription("Frost Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerlightninglight = base.Config.Bind<int>("Lightning Dagger", "Lightning Damage", 250, new ConfigDescription("Lightning Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerpoisonlight = base.Config.Bind<int>("Lightning Dagger", "Poison Damage", 0, new ConfigDescription("Poison Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerspiritlight = base.Config.Bind<int>("Lightning Dagger", "Spirit Damage", 100, new ConfigDescription("Spirit Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerdamageperlight = base.Config.Bind<int>("Lightning Dagger", "Overall Damage Per Level", 50, new ConfigDescription("Overall Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerbluntperlight = base.Config.Bind<int>("Lightning Dagger", "Blunt Damage Per Level", 50, new ConfigDescription("Blunt Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerslashperlight = base.Config.Bind<int>("Lightning Dagger", "Slash Damage Per Level", 50, new ConfigDescription("Slash Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerpierceperlight = base.Config.Bind<int>("Lightning Dagger", "Pierce Damage Per Level", 50, new ConfigDescription("Pierce Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerchopperlight = base.Config.Bind<int>("Lightning Dagger", "Chop Damage Per Level", 50, new ConfigDescription("Chop Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerpickaxeperlight = base.Config.Bind<int>("Lightning Dagger", "PickAxe Damage Per Level", 50, new ConfigDescription("PickAxe Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerfireperlight = base.Config.Bind<int>("Lightning Dagger", "Fire Damage Per Level", 50, new ConfigDescription("Fire Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerfrostperlight = base.Config.Bind<int>("Lightning Dagger", "Frost Damage Per Level", 50, new ConfigDescription("Frost Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerlightningperlight = base.Config.Bind<int>("Lightning Dagger", "Lightning Damage Per Level", 50, new ConfigDescription("Lightning Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerpoisonperlight = base.Config.Bind<int>("Lightning Dagger", "Poison Damage Per Level", 50, new ConfigDescription("Poison Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerspiritperlight = base.Config.Bind<int>("Lightning Dagger", "Spirit Damage Per Level", 50, new ConfigDescription("Spirit Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggertierlight = base.Config.Bind<int>("Lightning Dagger", "Tool Tier", 5, new ConfigDescription("Tool Tier", new AcceptableValueRange<int>(0, 10), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerattackforcelight = base.Config.Bind<int>("Lightning Dagger", "Attack Force", 90, new ConfigDescription("Attack Force", new AcceptableValueRange<int>(0, 100), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.damageposion = base.Config.Bind<int>("Poison Sword", "Overall Damage", 0, new ConfigDescription("Overall Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.bluntposion = base.Config.Bind<int>("Poison Sword", "Blunt Damge", 0, new ConfigDescription("Blunt Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.slashvalposion = base.Config.Bind<int>("Poison Sword", "Slash Damage", 300, new ConfigDescription("Slash Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.pierceposion = base.Config.Bind<int>("Poison Sword", "Pierce Damge", 135, new ConfigDescription("Pierce Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.chopposion = base.Config.Bind<int>("Poison Sword", "Chop Damage", 0, new ConfigDescription("Chop Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.pickaxeposion = base.Config.Bind<int>("Poison Sword", "PickAxe Damage", 0, new ConfigDescription("Pickaxe Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.fireposion = base.Config.Bind<int>("Poison Sword", "Fire Damage", 0, new ConfigDescription("Fire Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.frostposion = base.Config.Bind<int>("Poison Sword", "Frost Damage", 0, new ConfigDescription("Frost Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.lightningposion = base.Config.Bind<int>("Poison Sword", "Lightning Damage", 0, new ConfigDescription("Lightning Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.poisonposion = base.Config.Bind<int>("Poison Sword", "Poison Damage", 250, new ConfigDescription("Poison Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.spiritposion = base.Config.Bind<int>("Poison Sword", "Spirit Damage", 100, new ConfigDescription("Spirit Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.damageperposion = base.Config.Bind<int>("Poison Sword", "Overall Damage Per Level", 50, new ConfigDescription("Overall Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.bluntperposion = base.Config.Bind<int>("Poison Sword", "Blunt Damage Per Level", 50, new ConfigDescription("Blunt Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.slashperposion = base.Config.Bind<int>("Poison Sword", "Slash Damage Per Level", 50, new ConfigDescription("Slash Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.pierceperposion = base.Config.Bind<int>("Poison Sword", "Pierce Damage Per Level", 50, new ConfigDescription("Pierce Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.chopperposion = base.Config.Bind<int>("Poison Sword", "Chop Damage Per Level", 50, new ConfigDescription("Chop Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.pickaxeperposion = base.Config.Bind<int>("Poison Sword", "PickAxe Damage Per Level", 50, new ConfigDescription("PickAxe Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.fireperposion = base.Config.Bind<int>("Poison Sword", "Fire Damage Per Level", 50, new ConfigDescription("Fire Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.frostperposion = base.Config.Bind<int>("Poison Sword", "Frost Damage Per Level", 50, new ConfigDescription("Frost Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.lightningperposion = base.Config.Bind<int>("Poison Sword", "Lightning Damage Per Level", 50, new ConfigDescription("Lightning Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.poisonperposion = base.Config.Bind<int>("Poison Sword", "Poison Damage Per Level", 50, new ConfigDescription("Poison Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.spiritperposion = base.Config.Bind<int>("Poison Sword", "Spirit Damage Per Level", 50, new ConfigDescription("Spirit Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.tierposion = base.Config.Bind<int>("Poison Sword", "Tool Tier", 5, new ConfigDescription("Tool Tier", new AcceptableValueRange<int>(0, 10), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.attackforceposion = base.Config.Bind<int>("Poison Sword", "Attack Force", 90, new ConfigDescription("Attack Force", new AcceptableValueRange<int>(0, 100), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatdamageposion = base.Config.Bind<int>("Great Poison Sword", "Overall Damage", 0, new ConfigDescription("Overall Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatbluntposion = base.Config.Bind<int>("Great Poison Sword", "Blunt Damge", 0, new ConfigDescription("Blunt Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatslashvalposion = base.Config.Bind<int>("Great Poison Sword", "Slash Damage", 300, new ConfigDescription("Slash Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatpierceposion = base.Config.Bind<int>("Great Poison Sword", "Pierce Damge", 135, new ConfigDescription("Pierce Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatchopposion = base.Config.Bind<int>("Great Poison Sword", "Chop Damage", 0, new ConfigDescription("Chop Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatpickaxeposion = base.Config.Bind<int>("Great Poison Sword", "PickAxe Damage", 0, new ConfigDescription("Pickaxe Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatfireposion = base.Config.Bind<int>("Great Poison Sword", "Fire Damage", 0, new ConfigDescription("Fire Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatfrostposion = base.Config.Bind<int>("Great Poison Sword", "Frost Damage", 0, new ConfigDescription("Frost Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatlightningposion = base.Config.Bind<int>("Great Poison Sword", "Lightning Damage", 0, new ConfigDescription("Lightning Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatpoisonposion = base.Config.Bind<int>("Great Poison Sword", "Poison Damage", 250, new ConfigDescription("Poison Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatspiritposion = base.Config.Bind<int>("Great Poison Sword", "Spirit Damage", 100, new ConfigDescription("Spirit Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatdamageperposion = base.Config.Bind<int>("Great Poison Sword", "Overall Damage Per Level", 50, new ConfigDescription("Overall Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatbluntperposion = base.Config.Bind<int>("Great Poison Sword", "Blunt Damage Per Level", 50, new ConfigDescription("Blunt Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatslashperposion = base.Config.Bind<int>("Great Poison Sword", "Slash Damage Per Level", 50, new ConfigDescription("Slash Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatpierceperposion = base.Config.Bind<int>("Great Poison Sword", "Pierce Damage Per Level", 50, new ConfigDescription("Pierce Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatchopperposion = base.Config.Bind<int>("Great Poison Sword", "Chop Damage Per Level", 50, new ConfigDescription("Chop Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatpickaxeperposion = base.Config.Bind<int>("Great Poison Sword", "PickAxe Damage Per Level", 50, new ConfigDescription("PickAxe Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatfireperposion = base.Config.Bind<int>("Great Poison Sword", "Fire Damage Per Level", 50, new ConfigDescription("Fire Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatfrostperposion = base.Config.Bind<int>("Great Poison Sword", "Frost Damage Per Level", 50, new ConfigDescription("Frost Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatlightningperposion = base.Config.Bind<int>("Great Poison Sword", "Lightning Damage Per Level", 50, new ConfigDescription("Lightning Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatpoisonperposion = base.Config.Bind<int>("Great Poison Sword", "Poison Damage Per Level", 50, new ConfigDescription("Poison Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatspiritperposion = base.Config.Bind<int>("Great Poison Sword", "Spirit Damage Per Level", 50, new ConfigDescription("Spirit Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greattierposion = base.Config.Bind<int>("Great Poison Sword", "Tool Tier", 5, new ConfigDescription("Tool Tier", new AcceptableValueRange<int>(0, 10), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.greatattackforceposion = base.Config.Bind<int>("Great Poison Sword", "Attack Force", 90, new ConfigDescription("Attack Force", new AcceptableValueRange<int>(0, 100), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerdamageposion = base.Config.Bind<int>("Poison Dagger", "Overall Damage", 0, new ConfigDescription("Overall Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerbluntposion = base.Config.Bind<int>("Poison Dagger", "Blunt Damge", 0, new ConfigDescription("Blunt Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerslashvalposion = base.Config.Bind<int>("Poison Dagger", "Slash Damage", 300, new ConfigDescription("Slash Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerpierceposion = base.Config.Bind<int>("Poison Dagger", "Pierce Damge", 135, new ConfigDescription("Pierce Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerchopposion = base.Config.Bind<int>("Poison Dagger", "Chop Damage", 0, new ConfigDescription("Chop Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerpickaxeposion = base.Config.Bind<int>("Poison Dagger", "PickAxe Damage", 0, new ConfigDescription("Pickaxe Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerfireposion = base.Config.Bind<int>("Poison Dagger", "Fire Damage", 0, new ConfigDescription("Fire Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerfrostposion = base.Config.Bind<int>("Poison Dagger", "Frost Damage", 0, new ConfigDescription("Frost Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerlightningposion = base.Config.Bind<int>("Poison Dagger", "Lightning Damage", 0, new ConfigDescription("Lightning Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerpoisonposion = base.Config.Bind<int>("Poison Dagger", "Poison Damage", 250, new ConfigDescription("Poison Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerspiritposion = base.Config.Bind<int>("Poison Dagger", "Spirit Damage", 100, new ConfigDescription("Spirit Damage", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerdamageperposion = base.Config.Bind<int>("Poison Dagger", "Overall Damage Per Level", 50, new ConfigDescription("Overall Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerbluntperposion = base.Config.Bind<int>("Poison Dagger", "Blunt Damage Per Level", 50, new ConfigDescription("Blunt Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerslashperposion = base.Config.Bind<int>("Poison Dagger", "Slash Damage Per Level", 50, new ConfigDescription("Slash Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerpierceperposion = base.Config.Bind<int>("Poison Dagger", "Pierce Damage Per Level", 50, new ConfigDescription("Pierce Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerchopperposion = base.Config.Bind<int>("Poison Dagger", "Chop Damage Per Level", 50, new ConfigDescription("Chop Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerpickaxeperposion = base.Config.Bind<int>("Poison Dagger", "PickAxe Damage Per Level", 50, new ConfigDescription("PickAxe Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerfireperposion = base.Config.Bind<int>("Poison Dagger", "Fire Damage Per Level", 50, new ConfigDescription("Fire Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerfrostperposion = base.Config.Bind<int>("Poison Dagger", "Frost Damage Per Level", 50, new ConfigDescription("Frost Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerlightningperposion = base.Config.Bind<int>("Poison Dagger", "Lightning Damage Per Level", 50, new ConfigDescription("Lightning Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerpoisonperposion = base.Config.Bind<int>("Poison Dagger", "Poison Damage Per Level", 50, new ConfigDescription("Poison Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerspiritperposion = base.Config.Bind<int>("Poison Dagger", "Spirit Damage Per Level", 50, new ConfigDescription("Spirit Damage per level", new AcceptableValueRange<int>(0, 2500), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggertierposion = base.Config.Bind<int>("Poison Dagger", "Tool Tier", 5, new ConfigDescription("Tool Tier", new AcceptableValueRange<int>(0, 10), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
			this.daggerattackforceposion = base.Config.Bind<int>("Poison Dagger", "Attack Force", 90, new ConfigDescription("Attack Force", new AcceptableValueRange<int>(0, 100), new object[]
			{
				null,
				new ConfigurationManagerAttributes
				{
					IsAdminOnly = true
				}
			}));
		}

		// Token: 0x06000018 RID: 24 RVA: 0x000020A7 File Offset: 0x000002A7
		public RuneSwords()
		{
		}

		// Token: 0x06000019 RID: 25 RVA: 0x0000F434 File Offset: 0x0000D634
		private void AddTranslations()
		{
			LocalizationManager.Instance.AddToken("$icerunesword", "Runic Ice Sword", true);
			LocalizationManager.Instance.AddToken("$firerunesword", "Runic Fire Sword", true);
			LocalizationManager.Instance.AddToken("$lightningrunesword", "Runic Lightning Sword", true);
			LocalizationManager.Instance.AddToken("$poisonrunesword", "Runic Poison Sword", true);
			LocalizationManager.Instance.AddToken("$greatlightningrunesword", "Great Runic Lightning Sword", true);
			LocalizationManager.Instance.AddToken("$greatfirerunesword", "Great Runic Fire Sword", true);
			LocalizationManager.Instance.AddToken("$greaticerunesword", "Great Runic Ice Sword", true);
			LocalizationManager.Instance.AddToken("$greatpoisonrunesword", "Great Runic Poison Sword", true);
			LocalizationManager.Instance.AddToken("$firerunedagger", "Runic Fire Dagger", true);
			LocalizationManager.Instance.AddToken("$icerunedagger", "Runic Ice Dagger", true);
			LocalizationManager.Instance.AddToken("$lightningrunedagger", "Runic Lightning Dagger", true);
			LocalizationManager.Instance.AddToken("$poisonrunedagger", "Runic Poison Dagger", true);
			LocalizationManager.Instance.AddToken("$icerunesworddescrip", "This sword is cold to the touch it has been blessed by Skaoi with ancient runes that give it a mystical frost aura", true);
			LocalizationManager.Instance.AddToken("$greaticerunesworddescrip", "This sword is cold to the touch it has been blessed by Skaoi with ancient runes that give it a mystical frost aura", true);
			LocalizationManager.Instance.AddToken("$icerunedaggerdescrip", "This dagger is cold to the touch it has been blessed by Skaoi with ancient runes that give it a mystical frost aura", true);
			LocalizationManager.Instance.AddToken("$firerunesworddescrip", "This sword almost burn your hand as you touch it burning with Lokis wrath this blade burns those enemies its edge kisses", true);
			LocalizationManager.Instance.AddToken("$greatfirerunesworddescrip", "This sword almost burn your hand as you touch it burning with Lokis wrath this blade burns those enemies its edge kisses", true);
			LocalizationManager.Instance.AddToken("$firerunedaggerdescrip", "This dagger almost burn your hand as you touch it burning with Lokis wrath this blade burns those enemies its edge kisses", true);
			LocalizationManager.Instance.AddToken("$lightningrunesworddescrip", "This sword is truly a gift from Odin himself, it has a quivering yellow aura with sparks flying off the blade. It inflicts lightning damage", true);
			LocalizationManager.Instance.AddToken("$greatlightningrunesworddescrip", "This sword is truly a gift from Odin himself, it has a quivering yellow aura with sparks flying off the blade. It inflicts lightning damage", true);
			LocalizationManager.Instance.AddToken("$lightningrunedaggerdescrip", "This dagger is truly a gift from Odin himself, it has a quivering yellow aura with sparks flying off the blade. It inflicts lightning damage", true);
			LocalizationManager.Instance.AddToken("$poisonrunesworddescrip", "The Goddess Hel has breathed a portion of the underworld into this blade. It holds a powerful poison force", true);
			LocalizationManager.Instance.AddToken("$greatpoisonrunesworddescrip", "The Goddess Hel has breathed a portion of the underworld into this blade. It holds a powerful poison force", true);
			LocalizationManager.Instance.AddToken("$poisonrunedaggerdescrip", "The Goddess Hel has breathed a portion of the underworld into this blade. It holds a powerful poison force", true);
			LocalizationManager.Instance.AddToken("$piece_artisan_ext1", "Artisan Rune", true);
			LocalizationManager.Instance.AddToken("$piece_artisan_ext1desrip", "Extension for artisan table", true);
			LocalizationManager.Instance.AddToken("$piece_artisan_ext2", "Artisan Rune", true);
			LocalizationManager.Instance.AddToken("$piece_artisan_ext2desrip", "Extension for artisan table", true);
			LocalizationManager.Instance.AddToken("$piece_artisan_ext3", "Artisan Rune", true);
			LocalizationManager.Instance.AddToken("$piece_artisan_ext3desrip", "Extension for artisan table", true);
			LocalizationManager.Instance.AddToken("$piece_artisan_ext4", "Artisan Rune", true);
			LocalizationManager.Instance.AddToken("$piece_artisan_ext4desrip", "Extension for artisan table", true);
			LocalizationManager.Instance.AddToken("$piece_artisan_ext5", "Artisan Rune", true);
			LocalizationManager.Instance.AddToken("$piece_artisan_ext5desrip", "Extension for artisan table", true);
			LocalizationManager.Instance.AddToken("$piece_artisan_ext6", "Artisan Rune", true);
			LocalizationManager.Instance.AddToken("$piece_artisan_ext6desrip", "Extension for artisan table", true);
		}

		// Token: 0x04000001 RID: 1
		public const string PluginGUID = "com.zarboz.runicswords";

		// Token: 0x04000002 RID: 2
		public const string PluginName = "RuneSwords";

		// Token: 0x04000003 RID: 3
		public const string PluginVersion = "0.0.9";

		// Token: 0x04000004 RID: 4
		private AssetBundle runeassets;

		// Token: 0x04000005 RID: 5
		public ConfigEntry<bool> LightEnable;

		// Token: 0x04000006 RID: 6
		public ConfigEntry<bool> FireEnable;

		// Token: 0x04000007 RID: 7
		public ConfigEntry<bool> FrostEnable;

		// Token: 0x04000008 RID: 8
		public ConfigEntry<bool> PoisonEnable;

		// Token: 0x04000009 RID: 9
		public ConfigEntry<int> ObsidianFrost;

		// Token: 0x0400000A RID: 10
		public ConfigEntry<int> ObsidianFire;

		// Token: 0x0400000B RID: 11
		public ConfigEntry<int> ObsidianLight;

		// Token: 0x0400000C RID: 12
		public ConfigEntry<int> ObsidianPoison;

		// Token: 0x0400000D RID: 13
		public ConfigEntry<int> IronFrost;

		// Token: 0x0400000E RID: 14
		public ConfigEntry<int> IronFire;

		// Token: 0x0400000F RID: 15
		public ConfigEntry<int> IronLight;

		// Token: 0x04000010 RID: 16
		public ConfigEntry<int> IronPoison;

		// Token: 0x04000011 RID: 17
		public ConfigEntry<int> IceFreezeGland;

		// Token: 0x04000012 RID: 18
		public ConfigEntry<int> DragonTear;

		// Token: 0x04000013 RID: 19
		public ConfigEntry<int> FireFlametal;

		// Token: 0x04000014 RID: 20
		public ConfigEntry<int> FireSurtling;

		// Token: 0x04000015 RID: 21
		public ConfigEntry<int> PoisonOoze;

		// Token: 0x04000016 RID: 22
		public ConfigEntry<int> PoisonGuck;

		// Token: 0x04000017 RID: 23
		public ConfigEntry<int> Trophy;

		// Token: 0x04000018 RID: 24
		public ConfigEntry<int> Antler;

		// Token: 0x04000019 RID: 25
		private ConfigEntry<int> damagefrost;

		// Token: 0x0400001A RID: 26
		private ConfigEntry<int> bluntfrost;

		// Token: 0x0400001B RID: 27
		private ConfigEntry<int> slashvalfrost;

		// Token: 0x0400001C RID: 28
		private ConfigEntry<int> piercefrost;

		// Token: 0x0400001D RID: 29
		private ConfigEntry<int> chopfrost;

		// Token: 0x0400001E RID: 30
		private ConfigEntry<int> pickaxefrost;

		// Token: 0x0400001F RID: 31
		private ConfigEntry<int> firefrost;

		// Token: 0x04000020 RID: 32
		private ConfigEntry<int> frostfrost;

		// Token: 0x04000021 RID: 33
		private ConfigEntry<int> lightningfrost;

		// Token: 0x04000022 RID: 34
		private ConfigEntry<int> poisonfrost;

		// Token: 0x04000023 RID: 35
		private ConfigEntry<int> spiritfrost;

		// Token: 0x04000024 RID: 36
		private ConfigEntry<int> damageperfrost;

		// Token: 0x04000025 RID: 37
		private ConfigEntry<int> bluntperfrost;

		// Token: 0x04000026 RID: 38
		private ConfigEntry<int> slashperfrost;

		// Token: 0x04000027 RID: 39
		private ConfigEntry<int> pierceperfrost;

		// Token: 0x04000028 RID: 40
		private ConfigEntry<int> chopperfrost;

		// Token: 0x04000029 RID: 41
		private ConfigEntry<int> pickaxeperfrost;

		// Token: 0x0400002A RID: 42
		private ConfigEntry<int> fireperfrost;

		// Token: 0x0400002B RID: 43
		private ConfigEntry<int> frostperfrost;

		// Token: 0x0400002C RID: 44
		private ConfigEntry<int> lightningperfrost;

		// Token: 0x0400002D RID: 45
		private ConfigEntry<int> poisonperfrost;

		// Token: 0x0400002E RID: 46
		private ConfigEntry<int> spiritperfrost;

		// Token: 0x0400002F RID: 47
		private ConfigEntry<int> tierfrost;

		// Token: 0x04000030 RID: 48
		private ConfigEntry<int> attackforcefrost;

		// Token: 0x04000031 RID: 49
		private ConfigEntry<int> greatdamagefrost;

		// Token: 0x04000032 RID: 50
		private ConfigEntry<int> greatbluntfrost;

		// Token: 0x04000033 RID: 51
		private ConfigEntry<int> greatslashvalfrost;

		// Token: 0x04000034 RID: 52
		private ConfigEntry<int> greatpiercefrost;

		// Token: 0x04000035 RID: 53
		private ConfigEntry<int> greatchopfrost;

		// Token: 0x04000036 RID: 54
		private ConfigEntry<int> greatpickaxefrost;

		// Token: 0x04000037 RID: 55
		private ConfigEntry<int> greatfirefrost;

		// Token: 0x04000038 RID: 56
		private ConfigEntry<int> greatfrostfrost;

		// Token: 0x04000039 RID: 57
		private ConfigEntry<int> greatlightningfrost;

		// Token: 0x0400003A RID: 58
		private ConfigEntry<int> greatpoisonfrost;

		// Token: 0x0400003B RID: 59
		private ConfigEntry<int> greatspiritfrost;

		// Token: 0x0400003C RID: 60
		private ConfigEntry<int> greatdamageperfrost;

		// Token: 0x0400003D RID: 61
		private ConfigEntry<int> greatbluntperfrost;

		// Token: 0x0400003E RID: 62
		private ConfigEntry<int> greatslashperfrost;

		// Token: 0x0400003F RID: 63
		private ConfigEntry<int> greatpierceperfrost;

		// Token: 0x04000040 RID: 64
		private ConfigEntry<int> greatchopperfrost;

		// Token: 0x04000041 RID: 65
		private ConfigEntry<int> greatpickaxeperfrost;

		// Token: 0x04000042 RID: 66
		private ConfigEntry<int> greatfireperfrost;

		// Token: 0x04000043 RID: 67
		private ConfigEntry<int> greatfrostperfrost;

		// Token: 0x04000044 RID: 68
		private ConfigEntry<int> greatlightningperfrost;

		// Token: 0x04000045 RID: 69
		private ConfigEntry<int> greatpoisonperfrost;

		// Token: 0x04000046 RID: 70
		private ConfigEntry<int> greatspiritperfrost;

		// Token: 0x04000047 RID: 71
		private ConfigEntry<int> greattierfrost;

		// Token: 0x04000048 RID: 72
		private ConfigEntry<int> greatattackforcefrost;

		// Token: 0x04000049 RID: 73
		private ConfigEntry<int> daggerdamagefrost;

		// Token: 0x0400004A RID: 74
		private ConfigEntry<int> daggerbluntfrost;

		// Token: 0x0400004B RID: 75
		private ConfigEntry<int> daggerslashvalfrost;

		// Token: 0x0400004C RID: 76
		private ConfigEntry<int> daggerpiercefrost;

		// Token: 0x0400004D RID: 77
		private ConfigEntry<int> daggerchopfrost;

		// Token: 0x0400004E RID: 78
		private ConfigEntry<int> daggerpickaxefrost;

		// Token: 0x0400004F RID: 79
		private ConfigEntry<int> daggerfirefrost;

		// Token: 0x04000050 RID: 80
		private ConfigEntry<int> daggerfrostfrost;

		// Token: 0x04000051 RID: 81
		private ConfigEntry<int> daggerlightningfrost;

		// Token: 0x04000052 RID: 82
		private ConfigEntry<int> daggerpoisonfrost;

		// Token: 0x04000053 RID: 83
		private ConfigEntry<int> daggerspiritfrost;

		// Token: 0x04000054 RID: 84
		private ConfigEntry<int> daggerdamageperfrost;

		// Token: 0x04000055 RID: 85
		private ConfigEntry<int> daggerbluntperfrost;

		// Token: 0x04000056 RID: 86
		private ConfigEntry<int> daggerslashperfrost;

		// Token: 0x04000057 RID: 87
		private ConfigEntry<int> daggerpierceperfrost;

		// Token: 0x04000058 RID: 88
		private ConfigEntry<int> daggerchopperfrost;

		// Token: 0x04000059 RID: 89
		private ConfigEntry<int> daggerpickaxeperfrost;

		// Token: 0x0400005A RID: 90
		private ConfigEntry<int> daggerfireperfrost;

		// Token: 0x0400005B RID: 91
		private ConfigEntry<int> daggerfrostperfrost;

		// Token: 0x0400005C RID: 92
		private ConfigEntry<int> daggerlightningperfrost;

		// Token: 0x0400005D RID: 93
		private ConfigEntry<int> daggerpoisonperfrost;

		// Token: 0x0400005E RID: 94
		private ConfigEntry<int> daggerspiritperfrost;

		// Token: 0x0400005F RID: 95
		private ConfigEntry<int> daggertierfrost;

		// Token: 0x04000060 RID: 96
		private ConfigEntry<int> daggerattackforcefrost;

		// Token: 0x04000061 RID: 97
		private ConfigEntry<int> damagefire;

		// Token: 0x04000062 RID: 98
		private ConfigEntry<int> bluntfire;

		// Token: 0x04000063 RID: 99
		private ConfigEntry<int> slashvalfire;

		// Token: 0x04000064 RID: 100
		private ConfigEntry<int> piercefire;

		// Token: 0x04000065 RID: 101
		private ConfigEntry<int> chopfire;

		// Token: 0x04000066 RID: 102
		private ConfigEntry<int> pickaxefire;

		// Token: 0x04000067 RID: 103
		private ConfigEntry<int> firefire;

		// Token: 0x04000068 RID: 104
		private ConfigEntry<int> frostfire;

		// Token: 0x04000069 RID: 105
		private ConfigEntry<int> lightningfire;

		// Token: 0x0400006A RID: 106
		private ConfigEntry<int> poisonfire;

		// Token: 0x0400006B RID: 107
		private ConfigEntry<int> spiritfire;

		// Token: 0x0400006C RID: 108
		private ConfigEntry<int> damageperfire;

		// Token: 0x0400006D RID: 109
		private ConfigEntry<int> bluntperfire;

		// Token: 0x0400006E RID: 110
		private ConfigEntry<int> slashperfire;

		// Token: 0x0400006F RID: 111
		private ConfigEntry<int> pierceperfire;

		// Token: 0x04000070 RID: 112
		private ConfigEntry<int> chopperfire;

		// Token: 0x04000071 RID: 113
		private ConfigEntry<int> pickaxeperfire;

		// Token: 0x04000072 RID: 114
		private ConfigEntry<int> fireperfire;

		// Token: 0x04000073 RID: 115
		private ConfigEntry<int> frostperfire;

		// Token: 0x04000074 RID: 116
		private ConfigEntry<int> lightningperfire;

		// Token: 0x04000075 RID: 117
		private ConfigEntry<int> poisonperfire;

		// Token: 0x04000076 RID: 118
		private ConfigEntry<int> spiritperfire;

		// Token: 0x04000077 RID: 119
		private ConfigEntry<int> tierfire;

		// Token: 0x04000078 RID: 120
		private ConfigEntry<int> attackforcefire;

		// Token: 0x04000079 RID: 121
		private ConfigEntry<int> greatdamagefire;

		// Token: 0x0400007A RID: 122
		private ConfigEntry<int> greatbluntfire;

		// Token: 0x0400007B RID: 123
		private ConfigEntry<int> greatslashvalfire;

		// Token: 0x0400007C RID: 124
		private ConfigEntry<int> greatpiercefire;

		// Token: 0x0400007D RID: 125
		private ConfigEntry<int> greatchopfire;

		// Token: 0x0400007E RID: 126
		private ConfigEntry<int> greatpickaxefire;

		// Token: 0x0400007F RID: 127
		public ConfigEntry<int> greatfirefire;

		// Token: 0x04000080 RID: 128
		private ConfigEntry<int> greatfrostfire;

		// Token: 0x04000081 RID: 129
		private ConfigEntry<int> greatlightningfire;

		// Token: 0x04000082 RID: 130
		private ConfigEntry<int> greatpoisonfire;

		// Token: 0x04000083 RID: 131
		private ConfigEntry<int> greatspiritfire;

		// Token: 0x04000084 RID: 132
		private ConfigEntry<int> greatdamageperfire;

		// Token: 0x04000085 RID: 133
		private ConfigEntry<int> greatbluntperfire;

		// Token: 0x04000086 RID: 134
		private ConfigEntry<int> greatslashperfire;

		// Token: 0x04000087 RID: 135
		private ConfigEntry<int> greatpierceperfire;

		// Token: 0x04000088 RID: 136
		private ConfigEntry<int> greatchopperfire;

		// Token: 0x04000089 RID: 137
		private ConfigEntry<int> greatpickaxeperfire;

		// Token: 0x0400008A RID: 138
		private ConfigEntry<int> greatfireperfire;

		// Token: 0x0400008B RID: 139
		private ConfigEntry<int> greatfrostperfire;

		// Token: 0x0400008C RID: 140
		private ConfigEntry<int> greatlightningperfire;

		// Token: 0x0400008D RID: 141
		private ConfigEntry<int> greatpoisonperfire;

		// Token: 0x0400008E RID: 142
		private ConfigEntry<int> greatspiritperfire;

		// Token: 0x0400008F RID: 143
		private ConfigEntry<int> greattierfire;

		// Token: 0x04000090 RID: 144
		private ConfigEntry<int> greatattackforcefire;

		// Token: 0x04000091 RID: 145
		private ConfigEntry<int> daggerdamagefire;

		// Token: 0x04000092 RID: 146
		private ConfigEntry<int> daggerbluntfire;

		// Token: 0x04000093 RID: 147
		private ConfigEntry<int> daggerslashvalfire;

		// Token: 0x04000094 RID: 148
		private ConfigEntry<int> daggerpiercefire;

		// Token: 0x04000095 RID: 149
		private ConfigEntry<int> daggerchopfire;

		// Token: 0x04000096 RID: 150
		private ConfigEntry<int> daggerpickaxefire;

		// Token: 0x04000097 RID: 151
		private ConfigEntry<int> daggerfirefire;

		// Token: 0x04000098 RID: 152
		private ConfigEntry<int> daggerfrostfire;

		// Token: 0x04000099 RID: 153
		private ConfigEntry<int> daggerlightningfire;

		// Token: 0x0400009A RID: 154
		private ConfigEntry<int> daggerpoisonfire;

		// Token: 0x0400009B RID: 155
		private ConfigEntry<int> daggerspiritfire;

		// Token: 0x0400009C RID: 156
		private ConfigEntry<int> daggerdamageperfire;

		// Token: 0x0400009D RID: 157
		private ConfigEntry<int> daggerbluntperfire;

		// Token: 0x0400009E RID: 158
		private ConfigEntry<int> daggerslashperfire;

		// Token: 0x0400009F RID: 159
		private ConfigEntry<int> daggerpierceperfire;

		// Token: 0x040000A0 RID: 160
		private ConfigEntry<int> daggerchopperfire;

		// Token: 0x040000A1 RID: 161
		private ConfigEntry<int> daggerpickaxeperfire;

		// Token: 0x040000A2 RID: 162
		private ConfigEntry<int> daggerfireperfire;

		// Token: 0x040000A3 RID: 163
		private ConfigEntry<int> daggerfrostperfire;

		// Token: 0x040000A4 RID: 164
		private ConfigEntry<int> daggerlightningperfire;

		// Token: 0x040000A5 RID: 165
		private ConfigEntry<int> daggerpoisonperfire;

		// Token: 0x040000A6 RID: 166
		private ConfigEntry<int> daggerspiritperfire;

		// Token: 0x040000A7 RID: 167
		private ConfigEntry<int> daggertierfire;

		// Token: 0x040000A8 RID: 168
		private ConfigEntry<int> daggerattackforcefire;

		// Token: 0x040000A9 RID: 169
		private ConfigEntry<int> damagelight;

		// Token: 0x040000AA RID: 170
		private ConfigEntry<int> bluntlight;

		// Token: 0x040000AB RID: 171
		private ConfigEntry<int> slashvallight;

		// Token: 0x040000AC RID: 172
		private ConfigEntry<int> piercelight;

		// Token: 0x040000AD RID: 173
		private ConfigEntry<int> slashvalposion;

		// Token: 0x040000AE RID: 174
		private ConfigEntry<int> pierceposion;

		// Token: 0x040000AF RID: 175
		private ConfigEntry<int> chopposion;

		// Token: 0x040000B0 RID: 176
		private ConfigEntry<int> pickaxeposion;

		// Token: 0x040000B1 RID: 177
		private ConfigEntry<int> fireposion;

		// Token: 0x040000B2 RID: 178
		private ConfigEntry<int> frostposion;

		// Token: 0x040000B3 RID: 179
		private ConfigEntry<int> lightningposion;

		// Token: 0x040000B4 RID: 180
		private ConfigEntry<int> poisonposion;

		// Token: 0x040000B5 RID: 181
		private ConfigEntry<int> spiritposion;

		// Token: 0x040000B6 RID: 182
		private ConfigEntry<int> damageperposion;

		// Token: 0x040000B7 RID: 183
		private ConfigEntry<int> bluntperposion;

		// Token: 0x040000B8 RID: 184
		private ConfigEntry<int> slashperposion;

		// Token: 0x040000B9 RID: 185
		private ConfigEntry<int> pierceperposion;

		// Token: 0x040000BA RID: 186
		private ConfigEntry<int> chopperposion;

		// Token: 0x040000BB RID: 187
		private ConfigEntry<int> pickaxeperposion;

		// Token: 0x040000BC RID: 188
		private ConfigEntry<int> fireperposion;

		// Token: 0x040000BD RID: 189
		private ConfigEntry<int> frostperposion;

		// Token: 0x040000BE RID: 190
		private ConfigEntry<int> lightningperposion;

		// Token: 0x040000BF RID: 191
		private ConfigEntry<int> poisonperposion;

		// Token: 0x040000C0 RID: 192
		private ConfigEntry<int> spiritperposion;

		// Token: 0x040000C1 RID: 193
		private ConfigEntry<int> tierposion;

		// Token: 0x040000C2 RID: 194
		private ConfigEntry<int> attackforceposion;

		// Token: 0x040000C3 RID: 195
		private ConfigEntry<int> greatdamageposion;

		// Token: 0x040000C4 RID: 196
		private ConfigEntry<int> greatbluntposion;

		// Token: 0x040000C5 RID: 197
		private ConfigEntry<int> greatslashvalposion;

		// Token: 0x040000C6 RID: 198
		private ConfigEntry<int> greatpierceposion;

		// Token: 0x040000C7 RID: 199
		private ConfigEntry<int> greatchopposion;

		// Token: 0x040000C8 RID: 200
		private ConfigEntry<int> greatpickaxeposion;

		// Token: 0x040000C9 RID: 201
		private ConfigEntry<int> greatfireposion;

		// Token: 0x040000CA RID: 202
		private ConfigEntry<int> greatfrostposion;

		// Token: 0x040000CB RID: 203
		private ConfigEntry<int> greatlightningposion;

		// Token: 0x040000CC RID: 204
		private ConfigEntry<int> greatpoisonposion;

		// Token: 0x040000CD RID: 205
		private ConfigEntry<int> greatspiritposion;

		// Token: 0x040000CE RID: 206
		private ConfigEntry<int> greatdamageperposion;

		// Token: 0x040000CF RID: 207
		private ConfigEntry<int> greatbluntperposion;

		// Token: 0x040000D0 RID: 208
		private ConfigEntry<int> greatslashperposion;

		// Token: 0x040000D1 RID: 209
		private ConfigEntry<int> greatpierceperposion;

		// Token: 0x040000D2 RID: 210
		private ConfigEntry<int> greatchopperposion;

		// Token: 0x040000D3 RID: 211
		private ConfigEntry<int> greatpickaxeperposion;

		// Token: 0x040000D4 RID: 212
		private ConfigEntry<int> greatfireperposion;

		// Token: 0x040000D5 RID: 213
		private ConfigEntry<int> greatfrostperposion;

		// Token: 0x040000D6 RID: 214
		private ConfigEntry<int> greatlightningperposion;

		// Token: 0x040000D7 RID: 215
		private ConfigEntry<int> greatpoisonperposion;

		// Token: 0x040000D8 RID: 216
		private ConfigEntry<int> greatspiritperposion;

		// Token: 0x040000D9 RID: 217
		private ConfigEntry<int> greattierposion;

		// Token: 0x040000DA RID: 218
		private ConfigEntry<int> greatattackforceposion;

		// Token: 0x040000DB RID: 219
		private ConfigEntry<int> daggerdamageposion;

		// Token: 0x040000DC RID: 220
		private ConfigEntry<int> daggerbluntposion;

		// Token: 0x040000DD RID: 221
		private ConfigEntry<int> daggerslashvalposion;

		// Token: 0x040000DE RID: 222
		private ConfigEntry<int> daggerpierceposion;

		// Token: 0x040000DF RID: 223
		private ConfigEntry<int> daggerchopposion;

		// Token: 0x040000E0 RID: 224
		private ConfigEntry<int> daggerpickaxeposion;

		// Token: 0x040000E1 RID: 225
		private ConfigEntry<int> daggerfireposion;

		// Token: 0x040000E2 RID: 226
		private ConfigEntry<int> daggerfrostposion;

		// Token: 0x040000E3 RID: 227
		private ConfigEntry<int> daggerlightningposion;

		// Token: 0x040000E4 RID: 228
		private ConfigEntry<int> daggerpoisonposion;

		// Token: 0x040000E5 RID: 229
		private ConfigEntry<int> daggerspiritposion;

		// Token: 0x040000E6 RID: 230
		private ConfigEntry<int> daggerdamageperposion;

		// Token: 0x040000E7 RID: 231
		private ConfigEntry<int> daggerbluntperposion;

		// Token: 0x040000E8 RID: 232
		private ConfigEntry<int> daggerslashperposion;

		// Token: 0x040000E9 RID: 233
		private ConfigEntry<int> daggerpierceperposion;

		// Token: 0x040000EA RID: 234
		private ConfigEntry<int> daggerchopperposion;

		// Token: 0x040000EB RID: 235
		private ConfigEntry<int> daggerpickaxeperposion;

		// Token: 0x040000EC RID: 236
		private ConfigEntry<int> daggerfireperposion;

		// Token: 0x040000ED RID: 237
		private ConfigEntry<int> daggerfrostperposion;

		// Token: 0x040000EE RID: 238
		private ConfigEntry<int> daggerlightningperposion;

		// Token: 0x040000EF RID: 239
		private ConfigEntry<int> daggerpoisonperposion;

		// Token: 0x040000F0 RID: 240
		private ConfigEntry<int> daggerspiritperposion;

		// Token: 0x040000F1 RID: 241
		private ConfigEntry<int> daggertierposion;

		// Token: 0x040000F2 RID: 242
		private ConfigEntry<int> daggerattackforceposion;

		// Token: 0x040000F3 RID: 243
		private ConfigEntry<int> slashperlight;

		// Token: 0x040000F4 RID: 244
		private ConfigEntry<int> pierceperlight;

		// Token: 0x040000F5 RID: 245
		private ConfigEntry<int> chopperlight;

		// Token: 0x040000F6 RID: 246
		private ConfigEntry<int> pickaxeperlight;

		// Token: 0x040000F7 RID: 247
		private ConfigEntry<int> fireperlight;

		// Token: 0x040000F8 RID: 248
		private ConfigEntry<int> frostperlight;

		// Token: 0x040000F9 RID: 249
		private ConfigEntry<int> lightningperlight;

		// Token: 0x040000FA RID: 250
		private ConfigEntry<int> poisonperlight;

		// Token: 0x040000FB RID: 251
		private ConfigEntry<int> spiritperlight;

		// Token: 0x040000FC RID: 252
		private ConfigEntry<int> tierlight;

		// Token: 0x040000FD RID: 253
		private ConfigEntry<int> attackforcelight;

		// Token: 0x040000FE RID: 254
		private ConfigEntry<int> greatdamagelight;

		// Token: 0x040000FF RID: 255
		private ConfigEntry<int> greatbluntlight;

		// Token: 0x04000100 RID: 256
		private ConfigEntry<int> greatslashvallight;

		// Token: 0x04000101 RID: 257
		private ConfigEntry<int> greatpiercelight;

		// Token: 0x04000102 RID: 258
		private ConfigEntry<int> greatchoplight;

		// Token: 0x04000103 RID: 259
		private ConfigEntry<int> greatpickaxelight;

		// Token: 0x04000104 RID: 260
		private ConfigEntry<int> greatfirelight;

		// Token: 0x04000105 RID: 261
		private ConfigEntry<int> greatfrostlight;

		// Token: 0x04000106 RID: 262
		private ConfigEntry<int> greatlightninglight;

		// Token: 0x04000107 RID: 263
		private ConfigEntry<int> greatpoisonlight;

		// Token: 0x04000108 RID: 264
		private ConfigEntry<int> greatspiritlight;

		// Token: 0x04000109 RID: 265
		private ConfigEntry<int> greatdamageperlight;

		// Token: 0x0400010A RID: 266
		private ConfigEntry<int> greatbluntperlight;

		// Token: 0x0400010B RID: 267
		private ConfigEntry<int> greatslashperlight;

		// Token: 0x0400010C RID: 268
		private ConfigEntry<int> greatpierceperlight;

		// Token: 0x0400010D RID: 269
		private ConfigEntry<int> greatchopperlight;

		// Token: 0x0400010E RID: 270
		private ConfigEntry<int> greatpickaxeperlight;

		// Token: 0x0400010F RID: 271
		private ConfigEntry<int> greatfireperlight;

		// Token: 0x04000110 RID: 272
		private ConfigEntry<int> greatfrostperlight;

		// Token: 0x04000111 RID: 273
		private ConfigEntry<int> greatlightningperlight;

		// Token: 0x04000112 RID: 274
		private ConfigEntry<int> greatpoisonperlight;

		// Token: 0x04000113 RID: 275
		private ConfigEntry<int> greatspiritperlight;

		// Token: 0x04000114 RID: 276
		private ConfigEntry<int> greattierlight;

		// Token: 0x04000115 RID: 277
		private ConfigEntry<int> greatattackforcelight;

		// Token: 0x04000116 RID: 278
		private ConfigEntry<int> daggerdamagelight;

		// Token: 0x04000117 RID: 279
		private ConfigEntry<int> daggerbluntlight;

		// Token: 0x04000118 RID: 280
		private ConfigEntry<int> daggerslashvallight;

		// Token: 0x04000119 RID: 281
		private ConfigEntry<int> daggerpiercelight;

		// Token: 0x0400011A RID: 282
		private ConfigEntry<int> daggerchoplight;

		// Token: 0x0400011B RID: 283
		private ConfigEntry<int> daggerpickaxelight;

		// Token: 0x0400011C RID: 284
		private ConfigEntry<int> daggerfirelight;

		// Token: 0x0400011D RID: 285
		private ConfigEntry<int> daggerfrostlight;

		// Token: 0x0400011E RID: 286
		private ConfigEntry<int> daggerlightninglight;

		// Token: 0x0400011F RID: 287
		private ConfigEntry<int> daggerpoisonlight;

		// Token: 0x04000120 RID: 288
		private ConfigEntry<int> daggerspiritlight;

		// Token: 0x04000121 RID: 289
		private ConfigEntry<int> daggerdamageperlight;

		// Token: 0x04000122 RID: 290
		private ConfigEntry<int> daggerbluntperlight;

		// Token: 0x04000123 RID: 291
		private ConfigEntry<int> daggerslashperlight;

		// Token: 0x04000124 RID: 292
		private ConfigEntry<int> daggerpierceperlight;

		// Token: 0x04000125 RID: 293
		private ConfigEntry<int> daggerchopperlight;

		// Token: 0x04000126 RID: 294
		private ConfigEntry<int> daggerpickaxeperlight;

		// Token: 0x04000127 RID: 295
		private ConfigEntry<int> daggerfireperlight;

		// Token: 0x04000128 RID: 296
		private ConfigEntry<int> daggerfrostperlight;

		// Token: 0x04000129 RID: 297
		private ConfigEntry<int> daggerlightningperlight;

		// Token: 0x0400012A RID: 298
		private ConfigEntry<int> daggerpoisonperlight;

		// Token: 0x0400012B RID: 299
		private ConfigEntry<int> daggerspiritperlight;

		// Token: 0x0400012C RID: 300
		private ConfigEntry<int> daggertierlight;

		// Token: 0x0400012D RID: 301
		private ConfigEntry<int> daggerattackforcelight;

		// Token: 0x0400012E RID: 302
		private ConfigEntry<int> damageposion;

		// Token: 0x0400012F RID: 303
		private ConfigEntry<int> bluntposion;

		// Token: 0x04000130 RID: 304
		private ConfigEntry<int> poisonlight;

		// Token: 0x04000131 RID: 305
		private ConfigEntry<int> spiritlight;

		// Token: 0x04000132 RID: 306
		private ConfigEntry<int> damageperlight;

		// Token: 0x04000133 RID: 307
		private ConfigEntry<int> bluntperlight;

		// Token: 0x04000134 RID: 308
		private ConfigEntry<int> choplight;

		// Token: 0x04000135 RID: 309
		private ConfigEntry<int> pickaxelight;

		// Token: 0x04000136 RID: 310
		private ConfigEntry<int> firelight;

		// Token: 0x04000137 RID: 311
		private ConfigEntry<int> frostlight;

		// Token: 0x04000138 RID: 312
		private ConfigEntry<int> lightninglight;

		// Token: 0x04000139 RID: 313
		private EffectList effecthit;

		// Token: 0x0400013A RID: 314
		private EffectList effectblocked;

		// Token: 0x0400013B RID: 315
		private EffectList trigger;

		// Token: 0x0400013C RID: 316
		private EffectList trailfx;

		// Token: 0x0400013D RID: 317
		private EffectList buildsounds;

		// Token: 0x0400013E RID: 318
		private GameObject FrostSword;

		// Token: 0x0400013F RID: 319
		private CustomItem Frost_Sword;

		// Token: 0x04000140 RID: 320
		private GameObject Ice_GreatSword;

		// Token: 0x04000141 RID: 321
		private CustomItem IceGreat_Sword;

		// Token: 0x04000142 RID: 322
		private GameObject Fire_GreatSword;

		// Token: 0x04000143 RID: 323
		private CustomItem FireGreat_Sword;

		// Token: 0x04000144 RID: 324
		private GameObject Poison_GreatSword;

		// Token: 0x04000145 RID: 325
		private CustomItem PoisonGreat_Sword;

		// Token: 0x04000146 RID: 326
		private GameObject Lgntng_GreatSword;

		// Token: 0x04000147 RID: 327
		private CustomItem YlwGreatSwrd;

		// Token: 0x04000148 RID: 328
		private GameObject firefab;

		// Token: 0x04000149 RID: 329
		private CustomItem firerune;

		// Token: 0x0400014A RID: 330
		private GameObject poisonfab;

		// Token: 0x0400014B RID: 331
		private CustomItem poison;

		// Token: 0x0400014C RID: 332
		private GameObject lightningfab;

		// Token: 0x0400014D RID: 333
		private CustomItem llightrune;

		// Token: 0x0400014E RID: 334
		private GameObject FrostDagger;

		// Token: 0x0400014F RID: 335
		private CustomItem Frost_Dagger;

		// Token: 0x04000150 RID: 336
		private GameObject firedagger;

		// Token: 0x04000151 RID: 337
		private CustomItem fire_dagger;

		// Token: 0x04000152 RID: 338
		private GameObject poisondagger;

		// Token: 0x04000153 RID: 339
		private CustomItem poison_dagger;

		// Token: 0x04000154 RID: 340
		private GameObject lightningdagger;

		// Token: 0x04000155 RID: 341
		private CustomItem lightning_dagger;
	}
}
