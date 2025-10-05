using System.Collections.Generic;
using Terraria.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using TerrariaAchievementLib.Achievements.Conditions;
using CompletionistAchievements.Achievements.Dye;

namespace CompletionistAchievements.Achievements.Extractinator
{
    public class ExtractPlatinumCoinAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/ExtractPlatinumCoinAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemExtractCondition.Extract(Common.reqs, ItemID.PlatinumCoin));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<DyeHairAchievement>());
        }
    }

    public class ExtractJourneymanBaitAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/ExtractJourneymanBaitAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemExtractCondition.Extract(Common.reqs, ItemID.JourneymanBait));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<ExtractPlatinumCoinAchievement>());
        }
    }
}
