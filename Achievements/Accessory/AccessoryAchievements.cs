using System.Collections.Generic;
using Terraria.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using TerrariaAchievementLib.Achievements;
using TerrariaAchievementLib.Achievements.Conditions;
using CompletionistAchievements.Achievements.Armor;

namespace CompletionistAchievements.Achievements.Accessory
{
    public class Info
    {
        // Verified w/ https://terraria.wiki.gg/wiki/Accessories
        // Added https://terraria.wiki.gg/wiki/FPV_Goggles to Other
        public static readonly Dictionary<string, int[]> Accessories = new()
        {
            { "MOVE",         [ItemID.Aglet, ItemID.BalloonHorseshoeHoney, ItemID.AmphibianBoots, ItemID.AnkletoftheWind, ItemID.ArcticDivingGear, ItemID.BalloonPufferfish, ItemID.BlizzardinaBalloon, ItemID.BlizzardinaBottle, ItemID.BlueHorseshoeBalloon, ItemID.BundleofBalloons, ItemID.HorseshoeBundle, ItemID.CelestialShell, ItemID.ClimbingClaws, ItemID.CloudinaBalloon, ItemID.CloudinaBottle, ItemID.DivingGear, ItemID.SandBoots, ItemID.FairyBoots, ItemID.FartInABalloon, ItemID.FartinaJar, ItemID.Flipper, ItemID.FlurryBoots, ItemID.FlyingCarpet, ItemID.FrogFlipper, ItemID.FrogGear, ItemID.FrogLeg, ItemID.FrogWebbing, ItemID.FrostsparkBoots, ItemID.BalloonHorseshoeFart, ItemID.HellfireTreads, ItemID.HermesBoots, ItemID.HoneyBalloon, ItemID.IceSkates, ItemID.FloatingTube, ItemID.JellyfishDivingGear, ItemID.LavaCharm, ItemID.LavaWaders, ItemID.LightningBoots, ItemID.LuckyHorseshoe, ItemID.Magiluminescence, ItemID.LavaSkull, ItemID.MasterNinjaGear, ItemID.MoltenCharm, ItemID.MoonCharm, ItemID.MoonShell, ItemID.NeptunesShell, ItemID.ObsidianHorseshoe, ItemID.ObsidianWaterWalkingBoots, ItemID.BalloonHorseshoeSharkron, ItemID.RocketBoots, ItemID.SailfishBoots, ItemID.SandstorminaBalloon, ItemID.SandstorminaBottle, ItemID.SharkronBalloon, ItemID.ShinyRedBalloon, ItemID.ShoeSpikes, ItemID.SpectreBoots, ItemID.PortableStool, ItemID.Tabi, ItemID.TerrasparkBoots, ItemID.TigerClimbingGear, ItemID.TsunamiInABottle, ItemID.WaterWalkingBoots, ItemID.WhiteHorseshoeBalloon, ItemID.YellowHorseshoeBalloon] },
            { "WINGS",        [ItemID.CreativeWings, ItemID.AngelWings, ItemID.DemonWings, ItemID.FairyWings, ItemID.FinWings, ItemID.FrozenWings, ItemID.HarpyWings, ItemID.Jetpack, ItemID.LeafWings, ItemID.BatWings, ItemID.BeeWings, ItemID.ButterflyWings, ItemID.FlameWings, ItemID.Hoverboard, ItemID.BoneWings, ItemID.MothronWings, ItemID.GhostWings, ItemID.BeetleWings, ItemID.FestiveWings, ItemID.SpookyWings, ItemID.TatteredFairyWings, ItemID.SteampunkWings, ItemID.BetsyWings, ItemID.RainbowWings, ItemID.FishronWings, ItemID.WingsNebula, ItemID.WingsVortex, ItemID.WingsSolar, ItemID.WingsStardust] },
            { "INFO",         [ItemID.CopperWatch, ItemID.TinWatch, ItemID.SilverWatch, ItemID.TungstenWatch, ItemID.GoldWatch, ItemID.PlatinumWatch, ItemID.DepthMeter, ItemID.Compass, ItemID.Radar, ItemID.LifeformAnalyzer, ItemID.TallyCounter, ItemID.MetalDetector, ItemID.Stopwatch, ItemID.DPSMeter, ItemID.FishermansGuide, ItemID.WeatherRadio, ItemID.Sextant, ItemID.GPS, ItemID.REK, ItemID.GoblinTech, ItemID.FishFinder, ItemID.PDA, ItemID.MechanicalLens, ItemID.Ruler, ItemID.LaserRuler] },
            { "HEALTH_MANA",  [ItemID.ArcaneFlower, ItemID.BandofRegeneration, ItemID.BandofStarpower, ItemID.CelestialCuffs, ItemID.CelestialMagnet, ItemID.CelestialEmblem, ItemID.CharmofMyths, ItemID.MagicCuffs, ItemID.MagnetFlower, ItemID.ManaCloak, ItemID.ManaFlower, ItemID.ManaRegenerationBand, ItemID.NaturesGift, ItemID.PhilosophersStone] },
            { "COMBAT",       [ItemID.AdhesiveBandage, ItemID.AnkhCharm, ItemID.AnkhShield, ItemID.ArmorBracing, ItemID.ArmorPolish, ItemID.AvengerEmblem, ItemID.BeeCloak, ItemID.BerserkerGlove, ItemID.Bezoar, ItemID.BlackBelt, ItemID.Blindfold, ItemID.CelestialEmblem, ItemID.MoonCharm, ItemID.MoonShell, ItemID.CelestialStone, ItemID.CelestialShell, ItemID.CobaltShield, ItemID.CountercurseMantra, ItemID.CrossNecklace, ItemID.DestroyerEmblem, ItemID.EyeoftheGolem, ItemID.FastClock, ItemID.FeralClaws, ItemID.FireGauntlet, ItemID.FleshKnuckles, ItemID.FrozenTurtleShell, ItemID.FrozenShield, ItemID.HandWarmer, ItemID.HeroShield, ItemID.HoneyComb, ItemID.MagicQuiver, ItemID.MagmaStone, ItemID.MechanicalGlove, ItemID.MedicatedBandage, ItemID.Megaphone, ItemID.MoonStone, ItemID.MoltenQuiver, ItemID.MoltenSkullRose, ItemID.Nazar, ItemID.ObsidianRose, ItemID.ObsidianShield, ItemID.ObsidianSkull, ItemID.ObsidianSkullRose, ItemID.PaladinsShield, ItemID.PanicNecklace, ItemID.PocketMirror, ItemID.PowerGlove, ItemID.PutridScent, ItemID.RangerEmblem, ItemID.ReconScope, ItemID.RifleScope, ItemID.Shackle, ItemID.SharkToothNecklace, ItemID.SniperScope, ItemID.SorcererEmblem, ItemID.StalkersQuiver, ItemID.StarCloak, ItemID.StarVeil, ItemID.StingerNecklace, ItemID.SummonerEmblem, ItemID.SunStone, ItemID.SweetheartNecklace, ItemID.ThePlan, ItemID.TitanGlove, ItemID.TrifoldMap, ItemID.Vitamins, ItemID.WarriorEmblem, ItemID.ApprenticeScarf, ItemID.SquireShield, ItemID.HuntressBuckler, ItemID.MonkBelt, ItemID.HerculesBeetle, ItemID.NecromanticScroll, ItemID.PapyrusScarab, ItemID.PygmyNecklace] },
            { "CONSTRUCTION", [ItemID.Toolbelt, ItemID.Toolbox, ItemID.PaintSprayer, ItemID.ExtendoGrip, ItemID.PortableCementMixer, ItemID.BrickLayer, ItemID.ArchitectGizmoPack, ItemID.ActuationAccessory, ItemID.AncientChisel, ItemID.HandOfCreation] },
            { "FISH",         [ItemID.HighTestFishingLine, ItemID.AnglerEarring, ItemID.TackleBox, ItemID.AnglerTackleBag, ItemID.LavaFishingHook, ItemID.LavaproofTackleBag, ItemID.FishingBobber, ItemID.FishingBobberGlowingStar, ItemID.FishingBobberGlowingArgon, ItemID.FishingBobberGlowingKrypton, ItemID.FishingBobberGlowingLava, ItemID.FishingBobberGlowingViolet, ItemID.FishingBobberGlowingXenon, ItemID.FishingBobberGlowingRainbow] },
            { "YOYO",         [ItemID.WhiteString, ItemID.RedString, ItemID.OrangeString, ItemID.YellowString, ItemID.LimeString, ItemID.GreenString, ItemID.TealString, ItemID.CyanString, ItemID.SkyBlueString, ItemID.BlueString, ItemID.PurpleString, ItemID.VioletString, ItemID.PinkString, ItemID.BlackString, ItemID.BrownString, ItemID.RainbowString, ItemID.BlackCounterweight, ItemID.YellowCounterweight, ItemID.BlueCounterweight, ItemID.RedCounterweight, ItemID.PurpleCounterweight, ItemID.GreenCounterweight, ItemID.YoYoGlove, ItemID.YoyoBag] },
            { "VANITY",       [ItemID.JungleRose, ItemID.WinterCape, ItemID.MysteriousCape, ItemID.RedCape, ItemID.PrinceCape, ItemID.CrimsonCloak, ItemID.DiamondRing, ItemID.AngelHalo, ItemID.GingerBeard, ItemID.PartyBalloonAnimal, ItemID.BundleofBalloons, ItemID.FlameWakerBoots, ItemID.CritterShampoo, ItemID.BunnyTail, ItemID.FoxTail, ItemID.DogTail, ItemID.LizardTail, ItemID.UnicornHornHat, ItemID.HunterCloak, ItemID.RoyalScepter, ItemID.GlassSlipper, ItemID.RainbowCursor, ItemID.ShimmerMonolith, ItemID.BloodMoonMonolith, ItemID.VortexMonolith, ItemID.NebulaMonolith, ItemID.StardustMonolith, ItemID.SolarMonolith, ItemID.VoidMonolith] },
            { "MUSIC_BOX",    [ItemID.MusicBoxOverworldDay, ItemID.MusicBoxAltOverworldDay, ItemID.MusicBoxNight, ItemID.MusicBoxRain, ItemID.MusicBoxSnow, ItemID.MusicBoxIce, ItemID.MusicBoxDesert, ItemID.MusicBoxOcean, ItemID.MusicBoxOceanAlt, ItemID.MusicBoxSpace, ItemID.MusicBoxSpaceAlt, ItemID.MusicBoxUnderground, ItemID.MusicBoxAltUnderground, ItemID.MusicBoxMushrooms, ItemID.MusicBoxJungle, ItemID.MusicBoxCorruption, ItemID.MusicBoxUndergroundCorruption, ItemID.MusicBoxCrimson, ItemID.MusicBoxUndergroundCrimson, ItemID.MusicBoxTheHallow, ItemID.MusicBoxUndergroundHallow, ItemID.MusicBoxHell, ItemID.MusicBoxDungeon, ItemID.MusicBoxTemple, ItemID.MusicBoxBoss1, ItemID.MusicBoxBoss2, ItemID.MusicBoxBoss3, ItemID.MusicBoxBoss4, ItemID.MusicBoxBoss5, ItemID.MusicBoxDeerclops, ItemID.MusicBoxQueenSlime, ItemID.MusicBoxPlantera, ItemID.MusicBoxEmpressOfLight, ItemID.MusicBoxDukeFishron, ItemID.MusicBoxEerie, ItemID.MusicBoxEclipse, ItemID.MusicBoxGoblins, ItemID.MusicBoxPirates, ItemID.MusicBoxMartians, ItemID.MusicBoxPumpkinMoon, ItemID.MusicBoxFrostMoon, ItemID.MusicBoxTowers, ItemID.MusicBoxLunarBoss, ItemID.MusicBoxSandstorm, ItemID.MusicBoxDD2, ItemID.MusicBoxSlimeRain, ItemID.MusicBoxTownDay, ItemID.MusicBoxTownNight, ItemID.MusicBoxWindyDay, ItemID.MusicBoxDayRemix, ItemID.MusicBoxTitleAlt, ItemID.MusicBoxStorm, ItemID.MusicBoxGraveyard, ItemID.MusicBoxUndergroundJungle, ItemID.MusicBoxJungleNight, ItemID.MusicBoxMorningRain, ItemID.MusicBoxConsoleTitle, ItemID.MusicBoxUndergroundDesert, ItemID.MusicBoxOWRain, ItemID.MusicBoxOWDay, ItemID.MusicBoxOWNight, ItemID.MusicBoxOWUnderground, ItemID.MusicBoxOWDesert, ItemID.MusicBoxOWOcean, ItemID.MusicBoxOWMushroom, ItemID.MusicBoxOWDungeon, ItemID.MusicBoxOWSpace, ItemID.MusicBoxOWUnderworld, ItemID.MusicBoxOWSnow, ItemID.MusicBoxOWCorruption, ItemID.MusicBoxOWUndergroundCorruption, ItemID.MusicBoxOWCrimson, ItemID.MusicBoxOWUndergroundCrimson, ItemID.MusicBoxOWUndergroundSnow, ItemID.MusicBoxOWUndergroundHallow, ItemID.MusicBoxOWBloodMoon, ItemID.MusicBoxOWBoss2, ItemID.MusicBoxOWBoss1, ItemID.MusicBoxOWInvasion, ItemID.MusicBoxOWTowers, ItemID.MusicBoxOWMoonLord, ItemID.MusicBoxOWPlantera, ItemID.MusicBoxOWJungle, ItemID.MusicBoxOWWallOfFlesh, ItemID.MusicBoxOWHallow, ItemID.MusicBoxCredits, ItemID.MusicBoxShimmer, ItemID.MusicBoxTitle, ItemID.MusicBox] },
            { "GOLF_BALL",    [ItemID.GolfBallDyedBlack, ItemID.GolfBallDyedBlue, ItemID.GolfBallDyedBrown, ItemID.GolfBallDyedCyan, ItemID.GolfBallDyedGreen, ItemID.GolfBallDyedLimeGreen, ItemID.GolfBallDyedOrange, ItemID.GolfBallDyedPink, ItemID.GolfBallDyedPurple, ItemID.GolfBallDyedRed, ItemID.GolfBallDyedSkyBlue, ItemID.GolfBallDyedTeal, ItemID.GolfBallDyedViolet, ItemID.GolfBallDyedYellow] },
            { "OTHER",        [ItemID.ClothierVoodooDoll, ItemID.CoinRing, ItemID.DiscountCard, ItemID.FlowerBoots, ItemID.GoldRing, ItemID.GreedyRing, ItemID.CordageGuide, ItemID.GuideVoodooDoll, ItemID.JellyfishNecklace, ItemID.LuckyCoin, ItemID.DontStarveShaderItem, ItemID.SpectreGoggles, ItemID.TreasureMagnet, ItemID.ShimmerCloak, ItemID.JimsDroneVisor] }
        };
    }

    public class AccessoryBalloonPufferfishAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/AccessoryBalloonPufferfishAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemCatchCondition.Catch(Common.reqs, ItemID.BalloonPufferfish));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<ArmorOtherAchievement>());
        }
    }

    public class AccessoryFrogLegAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/AccessoryFrogLegAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemCatchCondition.Catch(Common.reqs, ItemID.FrogLeg));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<AccessoryBalloonPufferfishAchievement>());
        }
    }

    public class AccessoryMoonCharmAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/AccessoryMoonCharmAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.MoonCharm));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<AccessoryFrogLegAchievement>());
        }
    }

    public class AccessoryFinWingsAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/AccessoryFinWingsAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcGiftCondition.Gift(Common.reqs, NPCID.Angler, ItemID.FinWings));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<AccessoryMoonCharmAchievement>());
        }
    }

    public class AccessoryDepthMeterAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/AccessoryDepthMeterAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.DepthMeter));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<AccessoryFinWingsAchievement>());
        }
    }

    public class AccessoryCompassAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/AccessoryCompassAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.Compass));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<AccessoryDepthMeterAchievement>());
        }
    }

    public class AccessoryTallyCounterAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/AccessoryTallyCounterAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.TallyCounter));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<AccessoryCompassAchievement>());
        }
    }

    public class AccessoryNaturesGiftAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/AccessoryNaturesGiftAchievement";

        public override void AutoStaticDefaults() { }

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, Common.BreakAndGrabItem(Common.reqs, ItemID.NaturesGift));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<AccessoryTallyCounterAchievement>());
        }
    }

    public class AccessoryFrozenTurtleShellAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/AccessoryFrozenTurtleShellAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.FrozenTurtleShell));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<AccessoryNaturesGiftAchievement>());
        }
    }

    public class AccessoryMagicQuiverAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/AccessoryMagicQuiverAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.MagicQuiver));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<AccessoryFrozenTurtleShellAchievement>());
        }
    }

    public class AccessorySharkToothNecklaceAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/AccessorySharkToothNecklaceAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.SharkToothNecklace));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<AccessoryMagicQuiverAchievement>());
        }
    }

    public class AccessoryClothierVoodooDollAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/AccessoryClothierVoodooDollAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.ClothierVoodooDoll));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<AccessorySharkToothNecklaceAchievement>());
        }
    }

    public class AccessoryJellyfishNecklaceAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/AccessoryJellyfishNecklaceAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.JellyfishNecklace));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<AccessoryClothierVoodooDollAchievement>());
        }
    }

    public class AccessoryJungleRoseAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/AccessoryJungleRoseAchievement";

        public override void AutoStaticDefaults() { }

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, Common.BreakAndGrabItem(Common.reqs, ItemID.JungleRose));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<AccessoryJellyfishNecklaceAchievement>());
        }
    }

    public class AccessoryArcticDivingGearAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/AccessoryArcticDivingGearAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemCraftCondition.Craft(Common.reqs, ItemID.ArcticDivingGear));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<AccessoryJungleRoseAchievement>());
        }
    }

    public class AccessoryBundleHorseshoeBalloonsAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/AccessoryBundleHorseshoeBalloonsAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemCraftCondition.Craft(Common.reqs, ItemID.HorseshoeBundle));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<AccessoryArcticDivingGearAchievement>());
        }
    }

    public class AccessoryCelestialCuffsAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/AccessoryCelestialCuffsAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemCraftCondition.Craft(Common.reqs, ItemID.CelestialCuffs));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<AccessoryBundleHorseshoeBalloonsAchievement>());
        }
    }

    public class AccessoryCelestialEmblemAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/AccessoryCelestialEmblemAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemCraftCondition.Craft(Common.reqs, ItemID.CelestialEmblem));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<AccessoryCelestialCuffsAchievement>());
        }
    }

    public class AccessoryCelestialShellAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/AccessoryCelestialShellAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemCraftCondition.Craft(Common.reqs, ItemID.CelestialShell));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<AccessoryCelestialEmblemAchievement>());
        }
    }

    public class AccessoryFairyBootsAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/AccessoryFairyBootsAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemCraftCondition.Craft(Common.reqs, ItemID.FairyBoots));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<AccessoryCelestialShellAchievement>());
        }
    }

    public class AccessoryFireGauntletAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/AccessoryFireGauntletAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemCraftCondition.Craft(Common.reqs, ItemID.FireGauntlet));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<AccessoryFairyBootsAchievement>());
        }
    }

    public class AccessoryFrogGearAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/AccessoryFrogGearAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemCraftCondition.Craft(Common.reqs, ItemID.FrogGear));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<AccessoryFireGauntletAchievement>());
        }
    }

    public class AccessoryGreedyRingAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/AccessoryGreedyRingAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemCraftCondition.Craft(Common.reqs, ItemID.GreedyRing));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<AccessoryFrogGearAchievement>());
        }
    }

    public class AccessoryHandOfCreationAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/AccessoryHandOfCreationAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemCraftCondition.Craft(Common.reqs, ItemID.HandOfCreation));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<AccessoryGreedyRingAchievement>());
        }
    }

    public class AccessoryHellfireTreadsAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/AccessoryHellfireTreadsAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemCraftCondition.Craft(Common.reqs, ItemID.HellfireTreads));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<AccessoryHandOfCreationAchievement>());
        }
    }

    public class AccessoryLavaproofTackleBagAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/AccessoryLavaproofTackleBagAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemCraftCondition.Craft(Common.reqs, ItemID.LavaproofTackleBag));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<AccessoryHellfireTreadsAchievement>());
        }
    }

    public class AccessoryMasterNinjaGearAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/AccessoryMasterNinjaGearAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemCraftCondition.Craft(Common.reqs, ItemID.MasterNinjaGear));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<AccessoryLavaproofTackleBagAchievement>());
        }
    }

    public class AccessoryShellphoneAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/AccessoryShellphoneAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemCraftCondition.Craft(Common.reqs, ItemID.ShellphoneDummy));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<AccessoryMasterNinjaGearAchievement>());
        }
    }

    public class AccessorySniperScopeAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/AccessorySniperScopeAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemCraftCondition.Craft(Common.reqs, ItemID.SniperScope));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<AccessoryShellphoneAchievement>());
        }
    }

    public class AccessoryTheGrandDesignAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/AccessoryTheGrandDesignAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemCraftCondition.Craft(Common.reqs, ItemID.WireKite));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<AccessorySniperScopeAchievement>());
        }
    }

    public class AccessoryUltraAbsorbantSpongeAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/AccessoryUltraAbsorbantSpongeAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemCraftCondition.Craft(Common.reqs, ItemID.UltraAbsorbantSponge));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<AccessoryTheGrandDesignAchievement>());
        }
    }

    public class AccessoryMoveAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/AccessoryMoveAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.Accessories["MOVE"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<AccessoryUltraAbsorbantSpongeAchievement>());
        }
    }

    public class AccessoryWingsAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/AccessoryWingsAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.Accessories["WINGS"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<AccessoryMoveAchievement>());
        }
    }

    public class AccessoryInfoAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/AccessoryInfoAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.Accessories["INFO"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<AccessoryWingsAchievement>());
        }
    }

    public class AccessoryHealthManaAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/AccessoryHealthManaAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.Accessories["HEALTH_MANA"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<AccessoryInfoAchievement>());
        }
    }

    public class AccessoryCombatAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/AccessoryCombatAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.Accessories["COMBAT"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<AccessoryHealthManaAchievement>());
        }
    }

    public class AccessoryConstructionAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/AccessoryConstructionAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.Accessories["CONSTRUCTION"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<AccessoryCombatAchievement>());
        }
    }

    public class AccessoryFishAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/AccessoryFishAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.Accessories["FISH"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<AccessoryConstructionAchievement>());
        }
    }

    public class AccessoryYoyoAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/AccessoryYoyoAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.Accessories["YOYO"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<AccessoryFishAchievement>());
        }
    }

    public class AccessoryVanityAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/AccessoryVanityAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.Accessories["VANITY"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<AccessoryYoyoAchievement>());
        }
    }

    public class AccessoryMusicBoxAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/AccessoryMusicBoxAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.Accessories["MUSIC_BOX"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<AccessoryVanityAchievement>());
        }
    }

    public class AccessoryGolfBallAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/AccessoryGolfBallAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.Accessories["GOLF_BALL"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<AccessoryMusicBoxAchievement>());
        }
    }

    public class AccessoryOtherAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/AccessoryOtherAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.Accessories["OTHER"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<AccessoryGolfBallAchievement>());
        }
    }
}
