using System;
using BepInEx;
using Jotunn;
using Jotunn.Managers;
using Jotunn.Utils;
using UnityEngine;

namespace ValExFauna
{
	// Token: 0x02000002 RID: 2
	[BepInPlugin("MrRageous.ValExFauna", "ValheimExpanded: Fauna Module", "0.4.1")]
	[BepInDependency("com.jotunn.jotunn", BepInDependency.DependencyFlags.HardDependency)]
	[NetworkCompatibility(CompatibilityLevel.OnlySyncWhenInstalled, VersionStrictness.Minor)]
	public class Setup : BaseUnityPlugin
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		private void Awake()
		{
			this.LoadAssets();
			this.LoadLox();
			this.LoadSpiderlings();
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002068 File Offset: 0x00000268
		private void LoadAssets()
		{
			Logger.LogInfo("Embedded resources: " + string.Join(",", typeof(Setup).Assembly.GetManifestResourceNames()));
			this.assetBundle = AssetUtils.LoadAssetBundleFromResources("zfauna", typeof(Setup).Assembly);
			Logger.LogInfo(this.assetBundle);
		}

		// Token: 0x06000003 RID: 3 RVA: 0x000020D0 File Offset: 0x000002D0
		public void LoadMob(string prefabName, string mobName)
		{
			this.Prefab = this.assetBundle.LoadAsset<GameObject>(prefabName);
			Humanoid component = this.Prefab.GetComponent<Humanoid>();
			component.m_name = mobName;
			PrefabManager.Instance.AddPrefab(this.Prefab);
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002114 File Offset: 0x00000314
		private void LoadLox()
		{
			this.LoadMob("PolarLox", "Polar Lox");
			this.LoadMob("PygmyLox", "Pygmy Lox");
			this.LoadMob("NightLox", "Night Lox");
			this.LoadMob("MossyLox", "Mossy Lox");
			this.LoadMob("MistyLox", "Misty Lox");
			this.LoadMob("FlamingLox", "Flaming Lox");
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002188 File Offset: 0x00000388
		private void LoadSpiderlings()
		{
			this.LoadMob("FrozenSpiderling", "Frozen Spiderling");
			this.LoadMob("PygmySpiderling", "Pygmy Spiderling");
			this.LoadMob("WidowSpiderling", "Widow Spiderling");
			this.LoadMob("AncientSpiderling", "Ancient Spiderling");
			this.LoadMob("MistySpiderling", "Misty Spiderling");
			this.LoadMob("FlamingSpiderling", "Flaming Spiderling");
			this.LoadMob("RadioSpiderling 4", "Radioactive Spiderling");
		}

		// Token: 0x04000001 RID: 1
		public const string PluginGUID = "MrRageous.ValExFauna";

		// Token: 0x04000002 RID: 2
		public const string PluginName = "ValheimExpanded: Fauna Module";

		// Token: 0x04000003 RID: 3
		public const string PluginVersion = "0.4.1";

		// Token: 0x04000004 RID: 4
		private AssetBundle assetBundle;

		// Token: 0x04000005 RID: 5
		private GameObject Prefab;
	}
}
