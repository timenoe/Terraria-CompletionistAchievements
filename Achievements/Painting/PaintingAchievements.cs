using System.Collections.Generic;
using Terraria.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using TerrariaAchievementLib.Achievements;
using TerrariaAchievementLib.Achievements.Conditions;
using CompletionistAchievements.Achievements.Novelty;

namespace CompletionistAchievements.Achievements.Painting
{
    public class Info
    {
        // Verified w/ https://terraria.wiki.gg/wiki/Paintings
        public static readonly Dictionary<string, int[]> PaintingsBuy = new()
        {
            { "CLOTHIER",           [ItemID.PlacePainting] },
            { "GOLFER",             [ItemID.GolfPainting1, ItemID.GolfPainting2, ItemID.GolfPainting3, ItemID.GolfPainting4] },
            { "PAINTER",            [ItemID.ColdWatersintheWhiteLand, ItemID.Daylight, ItemID.DeadlandComesAlive, ItemID.DoNotStepontheGrass, ItemID.EvilPresence, ItemID.FirstEncounter, ItemID.GoodMorning, ItemID.TheLandofDeceivingLooks, ItemID.LightlessChasms, ItemID.PlaceAbovetheClouds, ItemID.SecretoftheSands, ItemID.SkyGuardian, ItemID.ThroughtheWindow, ItemID.UndergroundReward, ItemID.Purity, ItemID.Thunderbolt] },
            { "PAINTER_GRAVEYARD",  [ItemID.Nevermore, ItemID.Reborn, ItemID.Graveyard, ItemID.GhostManifestation, ItemID.WickedUndead, ItemID.HailtotheKing, ItemID.BloodyGoblet, ItemID.StillLife] },
            { "PRINCESS",           [ItemID.Princess64, ItemID.PaintingOfALass, ItemID.DarkSideHallow, ItemID.PrincessStyle, ItemID.SuspiciouslySparkly, ItemID.TerraBladeChronicles, ItemID.RoyalRomance] },
            { "TRAVELING_MERCHANT", [ItemID.PaintingAcorns, ItemID.PaintingCastleMarsberg, ItemID.PaintingColdSnap, ItemID.PaintingCursedSaint, ItemID.PaintingMartiaLisa, ItemID.MoonLordPainting, ItemID.PaintingWendy, ItemID.PaintingWillow, ItemID.PaintingWilson, ItemID.PaintingWolfgang, ItemID.PaintingTheSeason, ItemID.PaintingSnowfellas, ItemID.PaintingTheTruthIsUpThere, ItemID.HoplitePizza, ItemID.YuumaTheBlueTiger, ItemID.MoonmanandCompany, ItemID.SunshineofIsrapony, ItemID.BennyWarhol, ItemID.DoNotEattheVileMushroom, ItemID.Duality, ItemID.KargohsSummon, ItemID.ParsecPals] },
            { "TRUFFLE",            [ItemID.MySon] },
            { "ZOOLOGIST",          [ItemID.TheWerewolf] }
        };

        // Verified w/ https://terraria.wiki.gg/wiki/Paintings
        public static readonly Dictionary<string, int[]> PaintingsArea = new()
        {
            { "DUNGEON",                  [ItemID.BloodMoonRising, ItemID.BoneWarp, ItemID.TheCreationoftheGuide, ItemID.TheCursedMan, ItemID.TheDestroyer, ItemID.Dryadisque, ItemID.TheEyeSeestheEnd, ItemID.FacingtheCerebralMastermind, ItemID.GloryoftheFire, ItemID.GoblinsPlayingPoker, ItemID.GreatWave, ItemID.TheGuardiansGaze, ItemID.TheHangedMan, ItemID.Impact, ItemID.ThePersistencyofEyes, ItemID.PoweredbyBirds, ItemID.TheScreamer, ItemID.SkellingtonJSkellingsworth, ItemID.SparkyPainting, ItemID.SomethingEvilisWatchingYou, ItemID.StarryNight, ItemID.TrioSuperHeroes, ItemID.TheTwinsHaveAwoken, ItemID.UnicornCrossingtheHallows, ItemID.RemnantsofDevotion] },
            { "FLOATING_ISLAND",          [ItemID.HighPitch, ItemID.Constellation, ItemID.LoveisintheTrashSlot, ItemID.SunOrnament, ItemID.BlessingfromTheHeavens, ItemID.SeeTheWorldForWhatItIs] },
            { "JUNGLE_TEMPLE",            [ItemID.LizardKing] },
            { "UNDERGROUND_CABIN",        [ItemID.AmericanExplosive, ItemID.AuroraBorealis, ItemID.Bifrost, ItemID.Bioluminescence, ItemID.CatSword, ItemID.CrownoDevoursHisLunch, ItemID.Discover, ItemID.FairyGuides, ItemID.FatherofSomeone, ItemID.FindingGold, ItemID.ForestTroll, ItemID.GloriousNight, ItemID.GuidePicasso, ItemID.HappyLittleTree, ItemID.Heartlands, ItemID.AHorribleNightforAlchemy, ItemID.Land, ItemID.TheMerchant, ItemID.MorningHunt, ItemID.NurseLisa, ItemID.OldMiner, ItemID.Outcast, ItemID.RareEnchantment, ItemID.Secrets, ItemID.StrangeDeadFellows, ItemID.StrangeGrowth, ItemID.SufficientlyAdvanced, ItemID.Sunflowers, ItemID.TerrarianGothic, ItemID.VikingVoyage, ItemID.Waldo, ItemID.Wildflowers] },
            { "UNDERGROUND_CABIN_DESERT", [ItemID.AndrewSphinx, ItemID.WatchfulAntlion, ItemID.BurningSpirit, ItemID.JawsOfDeath, ItemID.TheSandsOfSlime, ItemID.SnakesIHateSnakes, ItemID.LifeAboveTheSand, ItemID.Oasis, ItemID.PrehistoryPreserved, ItemID.AncientTablet, ItemID.Uluru, ItemID.VisitingThePyramids, ItemID.BandageBoy, ItemID.DivineEye] },
            { "UNDERWORLD",               [ItemID.DarkSoulReaper, ItemID.Darkness, ItemID.DemonsEye, ItemID.FlowingMagma, ItemID.HandEarth, ItemID.ImpFace, ItemID.LakeofFire, ItemID.LivingGore, ItemID.OminousPresence, ItemID.ShiningMoon, ItemID.Skelehead, ItemID.TrappedGhost] }
        };

        // Verified w/ https://terraria.wiki.gg/wiki/Paintings
        public static readonly Dictionary<string, int[]> PaintingsOther = new()
        {
            { "FISH",   [ItemID.DreadoftheRedSea, ItemID.LadyOfTheLake] },
            { "ANGLER", [ItemID.PillaginMePixels, ItemID.CouchGag, ItemID.Crustography, ItemID.Fangs, ItemID.NotSoLostInParadise, ItemID.SilentFish, ItemID.TheDuke, ItemID.WhatLurksBelow] },
            { "SOLAR",  [ItemID.Requiem, ItemID.OcularResonance, ItemID.AMachineforTerrarians, ItemID.WingsofEvil, ItemID.ThisIsGettingOutOfHand, ItemID.Eyezorhead, ItemID.MidnightSun, ItemID.Buddies] },
            { "GOODIE", [ItemID.BitterHarvest, ItemID.BloodMoonCountess, ItemID.HallowsEve, ItemID.JackingSkeletron, ItemID.MorbidCuriosity] }
        };

        public static readonly int[] AnimalSkins = [ItemID.TigerSkin, ItemID.LeopardSkin, ItemID.ZebraSkin];
    }
    
    public class PaintingWaldoAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/PaintingWaldoAchievement";

        public override void AutoStaticDefaults() {}

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, Common.BreakAndGrabItem(Common.reqs, ItemID.Waldo));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<NoveltyAchievement>());
        }
    }

    public class PaintingClothierAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/PaintingClothierAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, NpcBuyCondition.BuyAll(Common.reqs, NPCID.None, Info.PaintingsBuy["CLOTHIER"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<PaintingWaldoAchievement>());
        }
    }

    public class PaintingGolferAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/PaintingGolferAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, NpcBuyCondition.BuyAll(Common.reqs, NPCID.None, Info.PaintingsBuy["GOLFER"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<PaintingClothierAchievement>());
        }
    }

    public class PaintingPainterAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/PaintingPainterAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, NpcBuyCondition.BuyAll(Common.reqs, NPCID.None, Info.PaintingsBuy["PAINTER"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<PaintingGolferAchievement>());
        }
    }

    public class PaintingPainterGraveyardAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/PaintingPainterGraveyardAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, NpcBuyCondition.BuyAll(Common.reqs, NPCID.None, Info.PaintingsBuy["PAINTER_GRAVEYARD"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<PaintingPainterAchievement>());
        }
    }

    public class PaintingPrincessAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/PaintingPrincessAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, NpcBuyCondition.BuyAll(Common.reqs, NPCID.None, Info.PaintingsBuy["PRINCESS"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<PaintingPainterGraveyardAchievement>());
        }
    }

    public class PaintingTravelingMerchantAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/PaintingTravelingMerchantAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, NpcBuyCondition.BuyAll(Common.reqs, NPCID.None, Info.PaintingsBuy["TRAVELING_MERCHANT"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<PaintingPrincessAchievement>());
        }
    }

    public class PaintingTruffleAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/PaintingTruffleAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, NpcBuyCondition.BuyAll(Common.reqs, NPCID.None, Info.PaintingsBuy["TRUFFLE"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<PaintingTravelingMerchantAchievement>());
        }
    }

    public class PaintingZoologistAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/PaintingZoologistAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, NpcBuyCondition.BuyAll(Common.reqs, NPCID.None, Info.PaintingsBuy["ZOOLOGIST"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<PaintingTruffleAchievement>());
        }
    }

    public class PaintingDungeonAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/PaintingDungeonAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.PaintingsArea["DUNGEON"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<PaintingZoologistAchievement>());
        }
    }

    public class PaintingFloatingIslandAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/PaintingFloatingIslandAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.PaintingsArea["FLOATING_ISLAND"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<PaintingDungeonAchievement>());
        }
    }

    public class PaintingJungleTempleAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/PaintingJungleTempleAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.PaintingsArea["JUNGLE_TEMPLE"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<PaintingFloatingIslandAchievement>());
        }
    }

    public class PaintingUndergroundCabinAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/PaintingUndergroundCabinAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.PaintingsArea["UNDERGROUND_CABIN"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<PaintingJungleTempleAchievement>());
        }
    }

    public class PaintingUndergroundCabinDesertAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/PaintingUndergroundCabinDesertAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.PaintingsArea["UNDERGROUND_CABIN_DESERT"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<PaintingUndergroundCabinAchievement>());
        }
    }

    public class PaintingUnderworldAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/PaintingUnderworldAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.PaintingsArea["UNDERWORLD"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<PaintingUndergroundCabinDesertAchievement>());
        }
    }

    public class PaintingFishAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/PaintingFishAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemCatchCondition.CatchAll(Common.reqs, Info.PaintingsOther["FISH"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<PaintingUnderworldAchievement>());
        }
    }

    public class PaintingAnglerAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/PaintingAnglerAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, NpcGiftCondition.GiftAll(Common.reqs, NPCID.Angler, Info.PaintingsOther["ANGLER"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<PaintingFishAchievement>());
        }
    }

    public class PaintingSolarAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/PaintingSolarAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, NpcDropCondition.DropAll(Common.reqs, NPCID.None, Info.PaintingsOther["SOLAR"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<PaintingAnglerAchievement>());
        }
    }

    public class PaintingGoodieAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/PaintingGoodieAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemOpenCondition.OpenAll(Common.reqs, ItemID.GoodieBag, Info.PaintingsOther["GOODIE"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<PaintingSolarAchievement>());
        }
    }

    public class PaintingAnimalSkinsAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/PaintingAnimalSkinsAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, NpcBuyCondition.BuyAll(Common.reqs, NPCID.TravellingMerchant, Info.AnimalSkins));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<PaintingGoodieAchievement>());
        }
    }
}
