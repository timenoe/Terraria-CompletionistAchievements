using System.Collections.Generic;
using Terraria.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using TerrariaAchievementLib.Achievements;
using TerrariaAchievementLib.Achievements.Conditions;
using CompletionistAchievements.Achievements.Banner;

namespace CompletionistAchievements.Achievements.Critter
{
    public class Info
    {
        // Verified w/ https://terraria.wiki.gg/wiki/Critters
        public static readonly Dictionary<string, int[]> SpecialCritters = new()
        {
            { "GEM",  [NPCID.GemBunnyAmethyst, NPCID.GemBunnyTopaz, NPCID.GemBunnySapphire, NPCID.GemBunnyEmerald, NPCID.GemBunnyRuby, NPCID.GemBunnyDiamond, NPCID.GemBunnyAmber, NPCID.GemSquirrelAmethyst, NPCID.GemSquirrelTopaz, NPCID.GemSquirrelSapphire, NPCID.GemSquirrelEmerald, NPCID.GemSquirrelRuby, NPCID.GemSquirrelDiamond, NPCID.GemSquirrelAmber] },
            { "GOLD", [NPCID.GoldBird, NPCID.GoldBunny, NPCID.GoldButterfly, NPCID.GoldDragonfly, NPCID.GoldFrog, NPCID.GoldGoldfish, NPCID.GoldGoldfishWalker, NPCID.GoldGrasshopper, NPCID.GoldLadyBug, NPCID.GoldMouse, NPCID.GoldSeahorse, NPCID.SquirrelGold, NPCID.GoldWaterStrider, NPCID.GoldWorm] }
        };

        // Verified w/ https://terraria.wiki.gg/wiki/Critters
        public static readonly int[] Critters = [ItemID.Bird, ItemID.BlueJay, ItemID.Buggy, ItemID.Bunny, ItemID.ExplosiveBunny, ItemID.GemBunnyAmethyst, ItemID.GemBunnyTopaz, ItemID.GemBunnySapphire, ItemID.GemBunnyEmerald, ItemID.GemBunnyRuby, ItemID.GemBunnyDiamond, ItemID.GemBunnyAmber, ItemID.Cardinal, ItemID.YellowCockatiel, ItemID.GrayCockatiel, ItemID.Duck, ItemID.MallardDuck, ItemID.EnchantedNightcrawler, ItemID.Shimmerfly, ItemID.FairyCritterBlue, ItemID.FairyCritterGreen, ItemID.FairyCritterPink, ItemID.Firefly, ItemID.Lavafly, ItemID.LightningBug, ItemID.Frog, ItemID.Goldfish, ItemID.Grasshopper, ItemID.Grebe, ItemID.Grubby, ItemID.LadyBug, ItemID.ScarletMacaw, ItemID.BlueMacaw, ItemID.Maggot, ItemID.Mouse, ItemID.Owl, ItemID.Penguin, ItemID.Pupfish, ItemID.Rat, ItemID.Scorpion, ItemID.BlackScorpion, ItemID.Seagull, ItemID.Seahorse, ItemID.Sluggy, ItemID.Snail, ItemID.GlowingSnail, ItemID.MagmaSnail, ItemID.Squirrel, ItemID.SquirrelRed, ItemID.GemSquirrelAmethyst, ItemID.GemSquirrelTopaz, ItemID.GemSquirrelSapphire, ItemID.GemSquirrelEmerald, ItemID.GemSquirrelRuby, ItemID.GemSquirrelDiamond, ItemID.GemSquirrelAmber, ItemID.Stinkbug, ItemID.Toucan, ItemID.Turtle, ItemID.TurtleJungle, ItemID.WaterStrider, ItemID.Worm, ItemID.JuliaButterfly, ItemID.MonarchButterfly, ItemID.PurpleEmperorButterfly, ItemID.RedAdmiralButterfly, ItemID.SulphurButterfly, ItemID.TreeNymphButterfly, ItemID.UlyssesButterfly, ItemID.ZebraSwallowtailButterfly, ItemID.HellButterfly, ItemID.EmpressButterfly, ItemID.BlackDragonfly, ItemID.BlueDragonfly, ItemID.GreenDragonfly, ItemID.OrangeDragonfly, ItemID.RedDragonfly, ItemID.YellowDragonfly, ItemID.GoldBird, ItemID.GoldBunny, ItemID.GoldButterfly, ItemID.GoldDragonfly, ItemID.GoldFrog, ItemID.GoldGoldfish, ItemID.GoldGrasshopper, ItemID.GoldLadyBug, ItemID.GoldMouse, ItemID.GoldSeahorse, ItemID.SquirrelGold, ItemID.GoldWaterStrider, ItemID.GoldWorm, ItemID.TruffleWorm];
    }
    
    public class CritterGemAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/CritterGemAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, NpcCatchCondition.CatchAll(Common.reqs, false, Info.SpecialCritters["GEM"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<BannerWindyDayAchievement>());
        }
    }

    public class CritterGoldAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/CritterGoldAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, NpcCatchCondition.CatchAll(Common.reqs, false, Info.SpecialCritters["GOLD"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<CritterGemAchievement>());
        }
    }

    public class CritterAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/CritterAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.Critters));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<CritterGoldAchievement>());
        }
    }
}
