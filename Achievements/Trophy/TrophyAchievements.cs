using System.Collections.Generic;
using Terraria.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using TerrariaAchievementLib.Achievements;
using TerrariaAchievementLib.Achievements.Conditions;
using CompletionistAchievements.Achievements.Storage;

namespace CompletionistAchievements.Achievements.Trophy
{
    public class Info
    {
        // Verified w/ https://terraria.wiki.gg/wiki/Trophies
        public static readonly Dictionary<string, int[]> Trophies = new()
        {
            { "PRE_HARDMODE", [ItemID.KingSlimeTrophy, ItemID.EyeofCthulhuTrophy, ItemID.EaterofWorldsTrophy, ItemID.BrainofCthulhuTrophy, ItemID.QueenBeeTrophy, ItemID.SkeletronTrophy, ItemID.DeerclopsTrophy, ItemID.WallofFleshTrophy] },
            { "HARDMODE",     [ItemID.QueenSlimeTrophy, ItemID.DestroyerTrophy, ItemID.RetinazerTrophy, ItemID.SpazmatismTrophy, ItemID.SkeletronPrimeTrophy, ItemID.PlanteraTrophy, ItemID.GolemTrophy, ItemID.FairyQueenTrophy, ItemID.DukeFishronTrophy, ItemID.AncientCultistTrophy, ItemID.MoonLordTrophy] },
            { "EVENT",        [ItemID.BossTrophyDarkmage, ItemID.BossTrophyOgre, ItemID.BossTrophyBetsy, ItemID.MourningWoodTrophy, ItemID.PumpkingTrophy, ItemID.EverscreamTrophy, ItemID.SantaNK1Trophy, ItemID.IceQueenTrophy, ItemID.FlyingDutchmanTrophy, ItemID.MartianSaucerTrophy] },
            { "FISH",         [ItemID.GoldfishTrophy, ItemID.BunnyfishTrophy, ItemID.SwordfishTrophy, ItemID.SharkteethTrophy] },
            { "GOLF",         [ItemID.GolfTrophyBronze, ItemID.GolfTrophySilver, ItemID.GolfTrophyGold] }
        };
    }
    
    public class TrophyPreHardmodeAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/TrophyPreHardmodeAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.Trophies["PRE_HARDMODE"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<StorageAchievement>());
        }
    }

    public class TrophyHardmodeAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/TrophyHardmodeAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.Trophies["HARDMODE"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<TrophyPreHardmodeAchievement>());
        }
    }

    public class TrophyEventAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/TrophyEventAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.Trophies["EVENT"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<TrophyHardmodeAchievement>());
        }
    }

    public class TrophyFishAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/TrophyFishAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.Trophies["FISH"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<TrophyEventAchievement>());
        }
    }

    public class TrophyGolfAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/TrophyGolfAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.Trophies["GOLF"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<TrophyFishAchievement>());
        }
    }
}
