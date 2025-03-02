using System.ComponentModel;
using Terraria.ModLoader.Config;
using TerrariaAchievementLib.Systems;

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
        public bool ProgressNotifications;

        /// <summary>
        /// True if progress rare enemy notifications are enabled
        /// </summary>
        [BackgroundColor(255, 255, 0)]
        [DefaultValue(true)]
        public bool RareEnemyNotifications;

        /// <summary>
        /// True if progress rare enemy notifications are enabled
        /// </summary>
        [BackgroundColor(255, 255, 0)]
        [DefaultValue(true)]
        public bool RareCritterNotifications;

        /// <summary>
        /// True if progress rare enemy notifications are enabled
        /// </summary>
        [BackgroundColor(255, 255, 0)]
        [DefaultValue(true)]
        public bool RareNpcNotifications;

        public override void OnChanged()
        {
            ProgressSystem.SetEnabled(ProgressNotifications);
            RareCreatureSystem.SetEnabled(RareEnemyNotifications, RareCritterNotifications, RareNpcNotifications);
        }
    }
}
