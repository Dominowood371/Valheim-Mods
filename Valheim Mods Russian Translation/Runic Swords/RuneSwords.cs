using System;
using System.Runtime.CompilerServices;
using BepInEx.Bootstrap;
using BepInEx.Configuration;
using BepInEx.Logging;
using UnityEngine;

namespace BepInEx
{
	/// <summary>
	/// The base plugin type that is used by the BepInEx plugin loader.
	/// </summary>
	// Token: 0x02000011 RID: 17
	public abstract class BaseUnityPlugin : MonoBehaviour
	{
		/// <summary>
		/// Information about this plugin as it was loaded.
		/// </summary>
		// Token: 0x1700002D RID: 45
		// (get) Token: 0x060000A5 RID: 165 RVA: 0x00003442 File Offset: 0x00001642
		public PluginInfo Info
		{
			[CompilerGenerated]
			get
			{
				return this.<Info>k__BackingField;
			}
		}

		/// <summary>
		/// Logger instance tied to this plugin.
		/// </summary>
		// Token: 0x1700002E RID: 46
		// (get) Token: 0x060000A6 RID: 166 RVA: 0x0000344A File Offset: 0x0000164A
		protected ManualLogSource Logger
		{
			[CompilerGenerated]
			get
			{
				return this.<Logger>k__BackingField;
			}
		}

		/// <summary>
		/// Default config file tied to this plugin. The config file will not be created until 
		/// any settings are added and changed, or <see cref="M:BepInEx.Configuration.ConfigFile.Save" /> is called.
		/// </summary>
		// Token: 0x1700002F RID: 47
		// (get) Token: 0x060000A7 RID: 167 RVA: 0x00003452 File Offset: 0x00001652
		public ConfigFile Config
		{
			[CompilerGenerated]
			get
			{
				return this.<Config>k__BackingField;
			}
		}

		/// <summary>
		/// Create a new instance of a plugin and all of its tied in objects.
		/// </summary>
		/// <exception cref="T:System.InvalidOperationException">BepInPlugin attribute is missing.</exception>
		// Token: 0x060000A8 RID: 168 RVA: 0x0000345C File Offset: 0x0000165C
		protected BaseUnityPlugin()
		{
			BepInPlugin metadata = MetadataHelper.GetMetadata(this);
			if (metadata == null)
			{
				throw new InvalidOperationException("Can't create an instance of " + base.GetType().FullName + " because it inherits from BaseUnityPlugin and the BepInPlugin attribute is missing.");
			}
			PluginInfo pluginInfo;
			if (!Chainloader.IsEditor && Chainloader.PluginInfos.TryGetValue(metadata.GUID, out pluginInfo))
			{
				this.Info = pluginInfo;
			}
			else
			{
				this.Info = new PluginInfo
				{
					Metadata = metadata,
					Instance = this,
					Dependencies = MetadataHelper.GetDependencies(base.GetType()),
					Processes = MetadataHelper.GetAttributes<BepInProcess>(base.GetType()),
					Location = base.GetType().Assembly.Location
				};
			}
			this.Logger = BepInEx.Logging.Logger.CreateLogSource(metadata.Name);
			string text = Chainloader.IsEditor ? "." : Paths.ConfigPath;
			this.Config = new ConfigFile(Utility.CombinePaths(new string[]
			{
				text,
				metadata.GUID + ".cfg"
			}), false, metadata);
		}

		// Token: 0x04000034 RID: 52
		[CompilerGenerated]
		private readonly PluginInfo <Info>k__BackingField;

		// Token: 0x04000035 RID: 53
		[CompilerGenerated]
		private readonly ManualLogSource <Logger>k__BackingField;

		// Token: 0x04000036 RID: 54
		[CompilerGenerated]
		private readonly ConfigFile <Config>k__BackingField;
	}
}
