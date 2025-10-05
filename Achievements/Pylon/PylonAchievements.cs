using System.Collections.Generic;
using Terraria.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using TerrariaAchievementLib.Achievements;
using TerrariaAchievementLib.Achievements.Conditions;
using CompletionistAchievements.Achievements.Painting;

namespace CompletionistAchievements.Achievements.Pylon
{
    public class Info
    {
        // Verified w/ https://terraria.wiki.gg/wiki/Pylons
        public static readonly int[] Pylons = [ItemID.TeleportationPylonPurity, ItemID.TeleportationPylonSnow, ItemID.TeleportationPylonDesert, ItemID.TeleportationPylonUnderground, ItemID.TeleportationPylonOcean, ItemID.TeleportationPylonJungle, ItemID.TeleportationPylonHallow, ItemID.TeleportationPylonMushroom, ItemID.TeleportationPylonVictory];
    }
    
    public class PylonUniversalAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/PylonUniversalAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcBuyCondition.Buy(Common.reqs, NPCID.BestiaryGirl, ItemID.TeleportationPylonVictory));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<PaintingAnimalSkinsAchievement>());
        }
    }

    public class PylonAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/PylonAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, NpcBuyCondition.BuyAll(Common.reqs, NPCID.None, Info.Pylons));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<PylonUniversalAchievement>());
        }
    }
}
