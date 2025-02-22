using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace CompletionistAchievements.Configs
{
    /// <summary>
    /// Config file for achievement settings
    /// </summary>
    public class SettingsConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        /// <summary>
        /// True if progress notifications are enabled
        /// </summary>
        [BackgroundColor(255, 255, 0)]
        [DefaultValue(true)]
        [ReloadRequired]
        public bool ProgressNotifications;
    }
}
