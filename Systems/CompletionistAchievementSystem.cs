using Terraria;
using Terraria.ModLoader;
using TerrariaAchievementLib.Systems;
using CompletionistAchievements.Configs;

namespace CompletionistAchievements.Systems
{
    /// <summary>
    /// Creates a helper AchievementSystem instance
    /// </summary>
    public class CompletionistAchievementSystem : AchievementSystem
    {
        public override void OnModLoad()
        {
            if (Main.dedServ)
                return;

            base.OnModLoad();
            SettingsConfig config = ModContent.GetInstance<SettingsConfig>();
            ProgressSystem.SetEnabled(config.ProgressNotifications);
            RareCreatureSystem.SetEnabled(config.RareEnemyNotifications, config.RareCritterNotifications, config.RareNpcNotifications);
        }
    }
}