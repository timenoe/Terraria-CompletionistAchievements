using System.Collections.Generic;
using Terraria.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using TerrariaAchievementLib.Achievements;
using TerrariaAchievementLib.Achievements.Conditions;
using CompletionistAchievements.Achievements.Extractinator;

namespace CompletionistAchievements.Achievements.Fish
{
    public class Info
    {
        // Verified w/ https://terraria.wiki.gg/wiki/Fishing
        public static readonly Dictionary<string, int[]> FishCatch = new()
        {
            { "NORMAL", [ItemID.ArmoredCavefish, ItemID.AtlanticCod, ItemID.Bass, ItemID.BlueJellyfish, ItemID.ChaosFish, ItemID.CrimsonTigerfish, ItemID.Damselfish, ItemID.DoubleCod, ItemID.Ebonkoi, ItemID.FlarefinKoi, ItemID.Flounder, ItemID.FrostMinnow, ItemID.GoldenCarp, ItemID.GreenJellyfish, ItemID.Hemopiranha, ItemID.Honeyfin, ItemID.NeonTetra, ItemID.Obsidifish, ItemID.PinkJellyfish, ItemID.PrincessFish, ItemID.Prismite, ItemID.RedSnapper, ItemID.RockLobster, ItemID.Salmon, ItemID.Shrimp, ItemID.SpecularFish, ItemID.Stinkfish, ItemID.Trout, ItemID.Tuna, ItemID.VariegatedLardfish] },
            { "QUEST",  [ItemID.AmanitaFungifin, ItemID.Angelfish, ItemID.Batfish, ItemID.BloodyManowar, ItemID.Bonefish, ItemID.BumblebeeTuna, ItemID.Bunnyfish, ItemID.CapnTunabeard, ItemID.Catfish, ItemID.Cloudfish, ItemID.Clownfish, ItemID.Cursedfish, ItemID.DemonicHellfish, ItemID.Derpfish, ItemID.Dirtfish, ItemID.DynamiteFish, ItemID.EaterofPlankton, ItemID.FallenStarfish, ItemID.Fishotron, ItemID.Fishron, ItemID.GuideVoodooFish, ItemID.Harpyfish, ItemID.Hungerfish, ItemID.Ichorfish, ItemID.InfectedScabbardfish, ItemID.Jewelfish, ItemID.MirageFish, ItemID.Mudfish, ItemID.MutantFlinxfin, ItemID.Pengfish, ItemID.Pixiefish, ItemID.ScarabFish, ItemID.ScorpioFish, ItemID.Slimefish, ItemID.Spiderfish, ItemID.TheFishofCthulu, ItemID.TropicalBarracuda, ItemID.TundraTrout, ItemID.UnicornFish, ItemID.Wyverntail, ItemID.ZombieFish] },
            { "CRATE",  [ItemID.WoodenCrate, ItemID.WoodenCrateHard, ItemID.IronCrate, ItemID.IronCrateHard, ItemID.GoldenCrate, ItemID.GoldenCrateHard, ItemID.JungleFishingCrate, ItemID.JungleFishingCrateHard, ItemID.FloatingIslandFishingCrate, ItemID.FloatingIslandFishingCrateHard, ItemID.CorruptFishingCrate, ItemID.CorruptFishingCrateHard, ItemID.CrimsonFishingCrate, ItemID.CrimsonFishingCrateHard, ItemID.HallowedFishingCrate, ItemID.HallowedFishingCrateHard, ItemID.DungeonFishingCrate, ItemID.DungeonFishingCrateHard, ItemID.FrozenCrate, ItemID.FrozenCrateHard, ItemID.OasisCrate, ItemID.OasisCrateHard, ItemID.LavaCrate, ItemID.LavaCrateHard, ItemID.OceanCrate, ItemID.OceanCrateHard] },
            { "JUNK",   [ItemID.OldShoe, ItemID.FishingSeaweed, ItemID.TinCan, ItemID.JojaCola] }
        };

        // Verified w/ https://terraria.wiki.gg/wiki/Angler#Reward_lists
        public static readonly int[] OneTimeFishRewards = [ItemID.FuzzyCarrot, ItemID.AnglerHat, ItemID.AnglerVest, ItemID.AnglerPants];
        public static readonly int[] AllOtherFishRewards = [ItemID.HoneyAbsorbantSponge, ItemID.BottomlessHoneyBucket, ItemID.GoldenFishingRod, ItemID.HotlineFishingHook, ItemID.FinWings, ItemID.BottomlessBucket, ItemID.SuperAbsorbantSponge, ItemID.GoldenBugNet, ItemID.FishHook, ItemID.FishMinecart, ItemID.SeashellHairpin, ItemID.MermaidAdornment, ItemID.MermaidTail, ItemID.FishCostumeMask, ItemID.FishCostumeShirt, ItemID.FishCostumeFinskirt, ItemID.HighTestFishingLine, ItemID.AnglerEarring, ItemID.TackleBox, ItemID.FishermansGuide, ItemID.WeatherRadio, ItemID.Sextant, ItemID.FishingBobber, ItemID.FishingPotion, ItemID.SonarPotion, ItemID.CratePotion, ItemID.LifePreserver, ItemID.ShipsWheel, ItemID.CompassRose, ItemID.WallAnchor, ItemID.PillaginMePixels, ItemID.TreasureMap, ItemID.GoldfishTrophy, ItemID.BunnyfishTrophy, ItemID.SwordfishTrophy, ItemID.SharkteethTrophy, ItemID.ShipInABottle, ItemID.SeaweedPlanter, ItemID.NotSoLostInParadise, ItemID.Crustography, ItemID.WhatLurksBelow, ItemID.Fangs, ItemID.CouchGag, ItemID.SilentFish, ItemID.TheDuke, ItemID.MasterBait, ItemID.JourneymanBait, ItemID.ApprenticeBait];
    }
    
    public class FishPinkPearlAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/FishPinkPearlAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemOpenCondition.Open(Common.reqs, ItemID.Oyster, ItemID.PinkPearl));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<ExtractJourneymanBaitAchievement>());
        }
    }

    public class FishNormalAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/FishNormalAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemCatchCondition.CatchAll(Common.reqs, Info.FishCatch["NORMAL"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<FishPinkPearlAchievement>());
        }
    }

    public class FishQuestAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/FishQuestAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemCatchCondition.CatchAll(Common.reqs, Info.FishCatch["QUEST"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<FishNormalAchievement>());
        }
    }

    public class FishCrateAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/FishCrateAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemCatchCondition.CatchAll(Common.reqs, Info.FishCatch["CRATE"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<FishQuestAchievement>());
        }
    }

    public class FishJunkAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/FishJunkAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemCatchCondition.CatchAll(Common.reqs, Info.FishCatch["JUNK"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<FishCrateAchievement>());
        }
    }

    public class FishRewardAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/FishRewardAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.OneTimeFishRewards));
            ConditionHelper.AddConditions(this, NpcGiftCondition.GiftAll(Common.reqs, NPCID.Angler, Info.AllOtherFishRewards));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<FishJunkAchievement>());
        }
    }
}
