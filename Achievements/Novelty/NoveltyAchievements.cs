using System.Collections.Generic;
using Terraria.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using TerrariaAchievementLib.Achievements;
using TerrariaAchievementLib.Achievements.Conditions;
using CompletionistAchievements.Achievements.Furniture;

namespace CompletionistAchievements.Achievements.Novelty
{
    public class Info
    {
        // Verified w/ https://terraria.wiki.gg/wiki/Template:Novelty_items
        public static readonly int[] Novelties = [ItemID.BeachBall, ItemID.BubbleMachine, ItemID.BubbleWand, ItemID.ConfettiCannon, ItemID.ConfettiGun, ItemID.FireworkFountain, ItemID.FireworksBox, ItemID.FogMachine, ItemID.Football, ItemID.PartyMonolith, ItemID.ReleaseDoves, ItemID.ReleaseLantern, ItemID.SillyBalloonMachine, ItemID.SmokeBomb, ItemID.DrumSet, ItemID.DrumStick, ItemID.IvyGuitar, ItemID.KiteBlue, ItemID.KiteBlueAndYellow, ItemID.KiteRed, ItemID.KiteRedAndYellow, ItemID.KiteYellow, ItemID.KiteGoldfish, ItemID.KiteBunny, ItemID.KiteBunnyCorrupt, ItemID.KiteBunnyCrimson, ItemID.KiteManEater, ItemID.KiteJellyfishBlue, ItemID.KiteJellyfishPink, ItemID.KiteShark, ItemID.KiteBoneSerpent, ItemID.KiteWanderingEye, ItemID.KiteUnicorn, ItemID.KiteWorldFeeder, ItemID.KiteSandShark, ItemID.KiteWyvern, ItemID.KitePigron, ItemID.KiteAngryTrapper, ItemID.KiteKoi, ItemID.KiteCrawltipede, ItemID.KiteSpectrum, ItemID.JimsDrone, ItemID.LovePotion, ItemID.PinWheel, ItemID.CarbonGuitar, ItemID.SandcastleBucket, ItemID.SlimeGun, ItemID.GelBalloon, ItemID.StinkPotion, ItemID.UnicornonaStick, ItemID.WaterGun, ItemID.WhoopieCushion];
    }

    public class NoveltyIvyAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/NoveltyIvyAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemGrabCondition.Grab(Common.reqs, ItemID.IvyGuitar));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<FurnitureTombstoneAchievement>());
        }
    }

    public class NoveltyWyvernKiteAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/NoveltyWyvernKiteAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.KiteWyvern));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<NoveltyIvyAchievement>());
        }
    }

    public class NoveltyRainSongAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/NoveltyRainSongAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.CarbonGuitar));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<NoveltyWyvernKiteAchievement>());
        }
    }

    public class NoveltyUnicornOnAStickAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/NoveltyUnicornOnAStickAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.UnicornonaStick));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<NoveltyRainSongAchievement>());
        }
    }

    public class NoveltyAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/NoveltyAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.Novelties));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<NoveltyUnicornOnAStickAchievement>());
        }
    }
}
