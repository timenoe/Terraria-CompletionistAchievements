using System.Collections.Generic;
using TerrariaAchievementLib.Systems;
using TerrariaAchievementLib.Achievements;
using Terraria.ID;
using Terraria.Achievements;
using TerrariaAchievementLib.Achievements.Conditions;

namespace CollectorAchievements.Systems
{
    public class CollectorAchievementSystem : AchievementSystem
    {
        private static readonly Dictionary<string, int[]> Dyes = new()
        {
            { "Basic",     [ItemID.RedDye, ItemID.OrangeDye, ItemID.YellowDye, ItemID.LimeDye, ItemID.GreenDye, ItemID.TealDye, ItemID.CyanDye, ItemID.SkyBlueDye, ItemID.BlueDye, ItemID.PurpleDye, ItemID.VioletDye, ItemID.PinkDye, ItemID.BlackDye, ItemID.BrownDye, ItemID.SilverDye]},
            { "Bright",    [ItemID.BrightRedDye, ItemID.BrightOrangeDye, ItemID.BrightYellowDye, ItemID.BrightLimeDye, ItemID.BrightGreenDye, ItemID.BrightTealDye, ItemID.BrightCyanDye, ItemID.BrightSkyBlueDye, ItemID.BrightBlueDye, ItemID.BrightPurpleDye, ItemID.BrightVioletDye, ItemID.BrightPinkDye, ItemID.BrightBrownDye, ItemID.BrightSilverDye]},
            { "Gradient",  [ItemID.FlameDye, ItemID.GreenFlameDye, ItemID.BlueFlameDye, ItemID.YellowGradientDye, ItemID.CyanGradientDye, ItemID.VioletGradientDye, ItemID.RainbowDye, ItemID.IntenseFlameDye, ItemID.IntenseGreenFlameDye, ItemID.IntenseBlueFlameDye, ItemID.IntenseRainbowDye]},
            { "Compound",  [ItemID.RedandBlackDye, ItemID.OrangeandBlackDye, ItemID.YellowandBlackDye, ItemID.LimeandBlackDye, ItemID.GreenandBlackDye, ItemID.TealandBlackDye, ItemID.CyanandBlackDye, ItemID.SkyBlueandBlackDye, ItemID.BlueandBlackDye, ItemID.PurpleandBlackDye, ItemID.VioletandBlackDye, ItemID.PinkandBlackDye, ItemID.BrownAndBlackDye, ItemID.SilverAndBlackDye, ItemID.FlameAndBlackDye, ItemID.GreenFlameAndBlackDye, ItemID.BlueFlameAndBlackDye, ItemID.RedandSilverDye, ItemID.OrangeandSilverDye, ItemID.YellowandSilverDye, ItemID.LimeandSilverDye, ItemID.GreenandSilverDye, ItemID.TealandSilverDye, ItemID.CyanandSilverDye, ItemID.SkyBlueandSilverDye, ItemID.BlueandSilverDye, ItemID.PurpleandSilverDye, ItemID.VioletandSilverDye, ItemID.PinkandSilverDye, ItemID.BrownAndSilverDye, ItemID.BlackAndWhiteDye, ItemID.FlameAndSilverDye, ItemID.GreenFlameAndSilverDye, ItemID.BlueFlameAndSilverDye]},
            { "Craftable", [ItemID.NebulaDye, ItemID.SolarDye, ItemID.StardustDye, ItemID.VortexDye, ItemID.ShiftingPearlSandsDye, ItemID.PinkGelDye, ItemID.VoidDye]},
            { "Strange",   [ItemID.AcidDye, ItemID.BlueAcidDye, ItemID.RedAcidDye, ItemID.ChlorophyteDye, ItemID.GelDye, ItemID.MushroomDye, ItemID.GrimDye, ItemID.HadesDye, ItemID.BurningHadesDye, ItemID.ShadowflameHadesDye, ItemID.LivingOceanDye, ItemID.LivingFlameDye, ItemID.LivingRainbowDye, ItemID.MartianArmorDye, ItemID.MidnightRainbowDye, ItemID.MirageDye, ItemID.NegativeDye, ItemID.PixieDye, ItemID.PhaseDye, ItemID.PurpleOozeDye, ItemID.ReflectiveDye, ItemID.ReflectiveCopperDye, ItemID.ReflectiveGoldDye, ItemID.ReflectiveObsidianDye, ItemID.ReflectiveMetalDye, ItemID.ReflectiveSilverDye, ItemID.ShadowDye, ItemID.ShiftingSandsDye, ItemID.DevDye, ItemID.TwilightDye, ItemID.WispDye, ItemID.InfernalWispDye, ItemID.UnicornWispDye] },
            { "Other",     [ItemID.BloodbathDye, ItemID.FogboundDye, ItemID.HallowBossDye]}
        };

        private static readonly Dictionary<string, int[]> MeleeWeapons = new()
        {
            { "Boomerangs", [ItemID.WoodenBoomerang, ItemID.EnchantedBoomerang, ItemID.FruitcakeChakram, ItemID.BloodyMachete, ItemID.Shroomerang, ItemID.IceBoomerang, ItemID.Trimarang, ItemID.ThornChakram, ItemID.CombatWrench, ItemID.Flamarang, ItemID.FlyingKnife, ItemID.BouncingShield, ItemID.LightDisc, ItemID.Bananarang, ItemID.PossessedHatchet, ItemID.PaladinsHammer]},
            { "Flails",     [ItemID.ChainKnife, ItemID.Mace, ItemID.FlamingMace, ItemID.BallOHurt, ItemID.TheMeatball, ItemID.BlueMoon, ItemID.Sunfury, ItemID.Anchor, ItemID.KOCannon, ItemID.DripplerFlail, ItemID.ChainGuillotines, ItemID.DaoofPow, ItemID.FlowerPow, ItemID.GolemFist, ItemID.Flairon]},
            { "Spears",     [ItemID.Spear, ItemID.Trident, ItemID.ThunderStaff, ItemID.TheRottedFork, ItemID.Swordfish, ItemID.DarkLance, ItemID.CobaltNaginata, ItemID.PalladiumPike, ItemID.MythrilHalberd, ItemID.OrichalcumHalberd, ItemID.AdamantiteGlaive, ItemID.TitaniumTrident, ItemID.Gungnir, ItemID.MonkStaffT2, ItemID.ChlorophytePartisan, ItemID.MushroomSpear, ItemID.ObsidianSwordfish, ItemID.NorthPole]},
            { "Swords",     [ItemID.CopperShortsword, ItemID.TinShortsword, ItemID.WoodenSword, ItemID.BorealWoodSword, ItemID.CopperBroadsword, ItemID.IronShortsword, ItemID.PalmWoodSword, ItemID.RichMahoganySword, ItemID.CactusSword, ItemID.LeadShortsword, ItemID.SilverShortsword, ItemID.TinBroadsword, ItemID.EbonwoodSword, ItemID.IronBroadsword, ItemID.ShadewoodSword, ItemID.TungstenShortsword, ItemID.GoldShortsword, ItemID.LeadBroadsword, ItemID.SilverBroadsword, ItemID.AshWoodSword, ItemID.Flymeal, ItemID.BladedGlove, ItemID.TungstenBroadsword, ItemID.ZombieArm, ItemID.GoldBroadsword, ItemID.PlatinumShortsword, ItemID.AntlionClaw, ItemID.StylistKilLaKillScissorsIWish, ItemID.Ruler, ItemID.PlatinumBroadsword, ItemID.Umbrella, ItemID.BreathingReed, ItemID.Gladius, ItemID.BoneSword, ItemID.BatBat, ItemID.TentacleSpike, ItemID.CandyCaneSword, ItemID.Katana, ItemID.IceBlade, ItemID.LightsBane, ItemID.TragicUmbrella, ItemID.Muramasa, ItemID.DyeTradersScimitar, ItemID.BluePhaseblade, ItemID.GreenPhaseblade, ItemID.OrangePhaseblade, ItemID.PurplePhaseblade, ItemID.RedPhaseblade, ItemID.WhitePhaseblade, ItemID.YellowPhaseblade, ItemID.BloodButcherer, ItemID.Starfury, ItemID.EnchantedSword, ItemID.PurpleClubberfish, ItemID.BeeKeeper, ItemID.FalconBlade, ItemID.BladeofGrass, ItemID.FieryGreatsword, ItemID.NightsEdge, ItemID.PearlwoodSword, ItemID.TaxCollectorsStickOfDoom, ItemID.SlapHand, ItemID.CobaltSword, ItemID.PalladiumSword, ItemID.BluePhasesaber, ItemID.GreenPhasesaber, ItemID.OrangePhasesaber, ItemID.PurplePhasesaber, ItemID.RedPhasesaber, ItemID.WhitePhasesaber, ItemID.YellowPhasesaber, ItemID.IceSickle, ItemID.DD2SquireDemonSword, ItemID.MythrilSword, ItemID.OrichalcumSword, ItemID.BreakerBlade, ItemID.Cutlass, ItemID.Frostbrand, ItemID.AdamantiteSword, ItemID.BeamSword, ItemID.TitaniumSword, ItemID.FetidBaghnakhs, ItemID.Bladetongue, ItemID.HamBat, ItemID.Excalibur, ItemID.TrueExcalibur, ItemID.ChlorophyteSaber, ItemID.DeathSickle, ItemID.PsychoKnife, ItemID.Keybrand, ItemID.ChlorophyteClaymore, ItemID.TheHorsemansBlade, ItemID.ChristmasTreeSword, ItemID.TrueNightsEdge, ItemID.Seedler, ItemID.DD2SquireBetsySword, ItemID.PiercingStarlight, ItemID.TerraBlade, ItemID.InfluxWaver, ItemID.StarWrath, ItemID.Meowmere]},
            { "Yoyos",      [ItemID.WoodYoyo, ItemID.Rally, ItemID.CorruptYoyo, ItemID.CrimsonYoyo, ItemID.JungleYoyo, ItemID.Code1, ItemID.Valor, ItemID.Cascade, ItemID.HiveFive, ItemID.FormatC, ItemID.Gradient, ItemID.Chik, ItemID.HelFire, ItemID.Amarok, ItemID.Code2, ItemID.Yelets, ItemID.Kraken, ItemID.TheEyeOfCthulhu, ItemID.Terrarian]},
            { "Other",      [ItemID.Terragrim, ItemID.JoustingLance, ItemID.ShadowFlameKnife, ItemID.JoustingLance, ItemID.MonkStaffT1, ItemID.ScourgeoftheCorruptor, ItemID.ShadowJoustingLance, ItemID.VampireKnives, ItemID.MonkStaffT3, ItemID.DayBreak, ItemID.SolarEruption, ItemID.Zenith]},
        };

        private static readonly Dictionary<string, int[]> RangedWeapons = new()
        {
            { "Bows",        [ItemID.WoodenBow, ItemID.BorealWoodBow, ItemID.CopperBow, ItemID.PalmWoodBow, ItemID.RichMahoganyBow, ItemID.TinBow, ItemID.EbonwoodBow, ItemID.IronBow, ItemID.ShadewoodBow, ItemID.LeadBow, ItemID.SilverBow, ItemID.AshWoodBow, ItemID.TungstenBow, ItemID.GoldBow, ItemID.PlatinumBow, ItemID.DemonBow, ItemID.TendonBow, ItemID.BloodRainBow, ItemID.BeesKnees, ItemID.HellwingBow, ItemID.MoltenFury, ItemID.PearlwoodBow, ItemID.Marrow, ItemID.IceBow, ItemID.DaedalusStormbow, ItemID.ShadowFlameBow, ItemID.DD2PhoenixBow, ItemID.PulseBow, ItemID.DD2BetsyBow, ItemID.Tsunami, ItemID.FairyQueenRangedItem, ItemID.Phantasm] },
            { "Consumables", [ItemID.PaperAirplaneA, ItemID.PaperAirplaneB, ItemID.Shuriken, ItemID.ThrowingKnife, ItemID.PoisonedKnife, ItemID.Snowball, ItemID.SpikyBall, ItemID.Bone, ItemID.RottenEgg, ItemID.StarAnise, ItemID.MolotovCocktail, ItemID.FrostDaggerfish, ItemID.Javelin, ItemID.BoneJavelin, ItemID.BoneDagger, ItemID.Grenade, ItemID.StickyGrenade, ItemID.BouncyGrenade, ItemID.Beenade, ItemID.PartyGirlGrenade] },
            { "Guns",        [ItemID.RedRyder, ItemID.FlintlockPistol, ItemID.Musket, ItemID.TheUndertaker, ItemID.Sandgun, ItemID.Revolver, ItemID.Minishark, ItemID.Boomstick, ItemID.QuadBarrelShotgun, ItemID.Handgun, ItemID.PhoenixBlaster, ItemID.PewMaticHorn, ItemID.ClockworkAssaultRifle, ItemID.Gatligator, ItemID.Shotgun, ItemID.OnyxBlaster, ItemID.CoinGun, ItemID.Uzi, ItemID.Megashark, ItemID.VenusMagnum, ItemID.TacticalShotgun, ItemID.SniperRifle, ItemID.CandyCornRifle, ItemID.ChainGun, ItemID.Xenopopper, ItemID.VortexBeater, ItemID.SDMG] },
            { "Launchers",   [ItemID.GrenadeLauncher, ItemID.ProximityMineLauncher, ItemID.RocketLauncher, ItemID.NailGun, ItemID.Stynger, ItemID.JackOLanternLauncher, ItemID.SnowballCannon, ItemID.FireworksLauncher, ItemID.ElectrosphereLauncher, ItemID.Celeb2] },
            { "Repeaters",   [ItemID.CobaltRepeater, ItemID.PalladiumRepeater, ItemID.MythrilRepeater, ItemID.OrichalcumRepeater, ItemID.AdamantiteRepeater, ItemID.TitaniumRepeater, ItemID.HallowedRepeater, ItemID.ChlorophyteShotbow, ItemID.StakeLauncher] },
            { "Other",       [ItemID.FlareGun, ItemID.AleThrowingGlove, ItemID.Blowpipe, ItemID.Blowgun, ItemID.SnowballCannon, ItemID.PainterPaintballGun, ItemID.Harpoon, ItemID.StarCannon, ItemID.Toxikarp, ItemID.DartPistol, ItemID.DartRifle, ItemID.Flamethrower, ItemID.PiranhaGun, ItemID.ElfMelter, ItemID.SuperStarCannon] },
        };

        private static readonly Dictionary<string, int[]> MagicWeapons = new()
        {
            { "Wands", [ItemID.WandofSparking, ItemID.WandofFrosting, ItemID.ThunderStaff, ItemID.AmethystStaff, ItemID.TopazStaff, ItemID.SapphireStaff, ItemID.EmeraldStaff, ItemID.RubyStaff, ItemID.DiamondStaff, ItemID.AmberStaff, ItemID.Vilethorn, ItemID.WeatherPain, ItemID.MagicMissile, ItemID.AquaScepter, ItemID.FlowerofFire, ItemID.Flamelash, ItemID.SkyFracture, ItemID.CrystalSerpent, ItemID.FlowerofFrost, ItemID.FrostStaff, ItemID.CrystalVileShard, ItemID.SoulDrain, ItemID.MeteorStaff, ItemID.PoisonStaff, ItemID.RainbowRod, ItemID.UnholyTrident, ItemID.BookStaff, ItemID.VenomStaff, ItemID.NettleBurst, ItemID.BatScepter, ItemID.BlizzardStaff, ItemID.InfernoFork, ItemID.ShadowbeamStaff, ItemID.SpectreStaff, ItemID.PrincessWeapon, ItemID.Razorpine, ItemID.StaffofEarth, ItemID.ApprenticeStaffT3]},
            { "Guns",  [ItemID.ZapinatorGray, ItemID.SpaceGun, ItemID.BeeGun, ItemID.LaserRifle, ItemID.ZapinatorOrange, ItemID.WaspGun, ItemID.WaspGun, ItemID.LeafBlower, ItemID.RainbowGun, ItemID.HeatRay, ItemID.LaserMachinegun, ItemID.ChargedBlasterCannon, ItemID.BubbleGun]},
            { "Books", [ItemID.WaterBolt, ItemID.BookofSkulls, ItemID.DemonScythe, ItemID.CursedFlames, ItemID.GoldenShower, ItemID.CrystalStorm, ItemID.MagnetSphere, ItemID.RazorbladeTyphoon, ItemID.LunarFlareBook]},
            { "Other", [ItemID.CrimsonRod, ItemID.IceRod, ItemID.ClingerStaff, ItemID.NimbusRod, ItemID.MagicDagger, ItemID.MedusaHead, ItemID.SpiritFlame, ItemID.ShadowFlameHexDoll, ItemID.SharpTears, ItemID.MagicalHarp, ItemID.ToxicFlask, ItemID.FairyQueenMagicItem, ItemID.SparkleGuitar, ItemID.NebulaArcanum, ItemID.NebulaBlaze, ItemID.LastPrism]},
        };

        private static readonly Dictionary<string, int[]> SummonWeapons = new()
        {
            { "Minion", [ItemID.BabyBirdStaff, ItemID.SlimeStaff, ItemID.FlinxStaff, ItemID.AbigailsFlower, ItemID.HornetStaff, ItemID.VampireFrogStaff, ItemID.ImpStaff, ItemID.Smolstar, ItemID.SpiderStaff, ItemID.PirateStaff, ItemID.SanguineStaff, ItemID.OpticStaff, ItemID.DeadlySphereStaff, ItemID.PygmyStaff, ItemID.RavenStaff, ItemID.StormTigerStaff, ItemID.TempestStaff, ItemID.EmpressBlade, ItemID.XenoStaff, ItemID.StardustCellStaff, ItemID.StardustDragonStaff] },
            { "Sentry", [ItemID.DD2LightningAuraT1Popper, ItemID.DD2FlameburstTowerT1Popper, ItemID.DD2ExplosiveTrapT1Popper, ItemID.DD2BallistraTowerT1Popper, ItemID.HoundiusShootius, ItemID.QueenSpiderStaff, ItemID.DD2LightningAuraT2Popper, ItemID.DD2FlameburstTowerT2Popper, ItemID.DD2ExplosiveTrapT2Popper, ItemID.DD2BallistraTowerT2Popper, ItemID.StaffoftheFrostHydra, ItemID.DD2LightningAuraT3Popper, ItemID.DD2FlameburstTowerT3Popper, ItemID.DD2ExplosiveTrapT3Popper, ItemID.DD2BallistraTowerT3Popper, ItemID.MoonlordTurretStaff, ItemID.RainbowCrystalStaff] },
            { "Whip",   [ItemID.BlandWhip, ItemID.ThornWhip, ItemID.BoneWhip, ItemID.FireWhip, ItemID.CoolWhip, ItemID.SwordWhip, ItemID.ScytheWhip, ItemID.MaceWhip, ItemID.RainbowWhip] },
        };

        private static readonly Dictionary<string, int[]> OtherWeapons = new()
        {
            { "Explosives", [ItemID.Bomb, ItemID.StickyBomb, ItemID.BouncyBomb, ItemID.ScarabBomb, ItemID.Dynamite, ItemID.StickyDynamite, ItemID.BouncyDynamite, ItemID.BombFish] },
            { "Placeables", [ItemID.SnowballLauncher, ItemID.Cannon, ItemID.BunnyCannon, ItemID.LandMine] },
            { "Other",      [ItemID.HolyWater, ItemID.UnholyWater, ItemID.BloodWater] },
        };

        private static readonly Dictionary<string, int[]> Tools = new()
        {
            { "Pickaxes/Drills", [ItemID.CactusPickaxe, ItemID.CopperPickaxe, ItemID.TinPickaxe, ItemID.IronPickaxe, ItemID.LeadPickaxe, ItemID.SilverPickaxe, ItemID.TungstenPickaxe, ItemID.GoldPickaxe, ItemID.CnadyCanePickaxe, ItemID.FossilPickaxe, ItemID.BonePickaxe, ItemID.PlatinumPickaxe, ItemID.ReaverShark, ItemID.NightmarePickaxe, ItemID.DeathbringerPickaxe, ItemID.MoltenPickaxe, ItemID.CobaltPickaxe, ItemID.CobaltDrill, ItemID.PalladiumPickaxe, ItemID.PalladiumDrill, ItemID.MythrilPickaxe, ItemID.MythrilDrill, ItemID.OrichalcumPickaxe, ItemID.OrichalcumDrill, ItemID.AdamantitePickaxe, ItemID.AdamantiteDrill, ItemID.TitaniumPickaxe, ItemID.TitaniumDrill, ItemID.SpectrePickaxe, ItemID.ChlorophytePickaxe, ItemID.ChlorophyteDrill, ItemID.PickaxeAxe, ItemID.Drax, ItemID.ShroomiteDiggingClaw, ItemID.Picksaw, ItemID.VortexPickaxe, ItemID.NebulaPickaxe, ItemID.SolarFlarePickaxe, ItemID.StardustPickaxe, ItemID. VortexDrill, ItemID.NebulaDrill, ItemID.SolarFlareDrill, ItemID.StardustDrill, ItemID.LaserDrill] },
            { "Axes/Chainsaws", [ItemID.CopperAxe, ItemID.TinAxe, ItemID.IronAxe, ItemID.LeadAxe, ItemID.SilverAxe, ItemID.TungstenAxe, ItemID.GoldAxe, ItemID.PlatinumAxe, ItemID.CobaltWaraxe, ItemID.CobaltChainsaw, ItemID.SawtoothShark, ItemID.WarAxeoftheNight, ItemID.BloodLustCluster, ItemID.PalladiumWaraxe, ItemID.PalladiumChainsaw, ItemID.MythrilWaraxe, ItemID.MythrilChainsaw, ItemID.OrichalcumWaraxe, ItemID.OrichalcumChainsaw, ItemID.AdamantiteWaraxe, ItemID.AdamantiteChainsaw, ItemID.MeteorHamaxe, ItemID.TitaniumWaraxe, ItemID.TitaniumChainsaw, ItemID.PickaxeAxe, ItemID.Drax, ItemID.ChlorophyteGreataxe, ItemID.ChlorophyteChainsaw, ItemID.Picksaw, ItemID.ShroomiteDiggingClaw, ItemID.LucyTheAxe, ItemID.AcornAxe, ItemID.ButchersChainsaw, ItemID.MoltenHamaxe, ItemID.BloodHamaxe, ItemID.SpectreHamaxe, ItemID.LunarHamaxeSolar, ItemID.LunarHamaxeVortex, ItemID.LunarHamaxeNebula, ItemID.LunarHamaxeStardust, ItemID.TheAxe] },
            { "Hammers", [ItemID.WoodenHammer, ItemID.RichMahoganyHammer, ItemID.PalmWoodHammer, ItemID.BorealWoodHammer, ItemID.CopperHammer, ItemID.TinHammer, ItemID.IronHammer, ItemID.EbonwoodHammer, ItemID.ShadewoodHammer, ItemID.LeadHammer, ItemID.AshWoodHammer, ItemID.SilverHammer, ItemID.TungstenHammer, ItemID.GoldHammer, ItemID.TheBreaker, ItemID.PearlwoodHammer, ItemID.FleshGrinder, ItemID.PlatinumHammer, ItemID.MeteorHamaxe, ItemID.Rockfish, ItemID.MoltenHamaxe, ItemID.Pwnhammer, ItemID.BloodHamaxe, ItemID.Hammush, ItemID.ChlorophyteWarhammer, ItemID.ChlorophyteJackhammer, ItemID.SpectreHamaxe, ItemID.LunarHamaxeSolar, ItemID.LunarHamaxeVortex, ItemID.LunarHamaxeNebula, ItemID.LunarHamaxeStardust, ItemID.TheAxe] },
            { "Wiring", [ItemID.Wrench, ItemID.WireCutter, ItemID.BlueWrench, ItemID.GreenWrench, ItemID.WireKite, ItemID.YellowWrench, ItemID.ActuationRod, ItemID.MulticolorWrench] },
            { "Painting", [ItemID.Paintbrush, ItemID.PaintRoller, ItemID.PaintScraper, ItemID.SpectrePaintbrush, ItemID.SpectrePaintRoller, ItemID.SpectrePaintScraper] },
            { "Hooks", [ItemID.GrapplingHook, ItemID.IvyWhip, ItemID.DualHook, ItemID.WebSlinger, ItemID.AmethystHook, ItemID.TopazHook, ItemID.SapphireHook, ItemID.EmeraldHook, ItemID.RubyHook, ItemID.DiamondHook, ItemID.SkeletronHand, ItemID.BatHook, ItemID.SpookyHook, ItemID.CandyCaneHook, ItemID.ChristmasHook, ItemID.FishHook, ItemID.SlimeHook, ItemID.AntiGravityHook, ItemID.TendonHook, ItemID.ThornHook, ItemID.IlluminantHook, ItemID.WormHook, ItemID.LunarHook, ItemID.StaticHook, ItemID.AmberHook, ItemID.SquirrelHook, ItemID.QueenSlimeHook] },
            { "Fishing Poles", [ItemID.WoodFishingPole, ItemID.ReinforcedFishingPole, ItemID.FiberglassFishingPole, ItemID.FisherofSouls, ItemID.GoldenFishingRod, ItemID.MechanicsRod, ItemID.SittingDucksFishingRod, ItemID.Fleshcatcher, ItemID.HotlineFishingHook, ItemID.BloodFishingRod, ItemID.ScarabFishingRod] },
            { "Movement Items", [ItemID.IceMirror, ItemID.MagicMirror, ItemID.CellPhone, ItemID.RodofDiscord, ItemID.RodOfHarmony, ItemID.PortalGun, ItemID.Umbrella, ItemID.TragicUmbrella, ItemID.MagicConch, ItemID.DemonConch, ItemID.MysticCoilSnake, ItemID.Shellphone] },
            { "Block-Placing Wands", [ItemID.LeafWand, ItemID.LivingWoodWand, ItemID.LivingMahoganyLeafWand, ItemID.LivingMahoganyWand, ItemID.HiveWand, ItemID.BoneWand] },
            { "Others", [ItemID.EmptyBucket, ItemID.BottomlessBucket, ItemID.BottomlessLavaBucket, ItemID.BottomlessHoneyBucket, ItemID.BottomlessShimmerBucket, ItemID.SuperAbsorbantSponge, ItemID.LavaAbsorbantSponge, ItemID.HoneyAbsorbantSponge, ItemID.UltraAbsorbantSponge, ItemID.BugNet, ItemID.GoldenBugNet, ItemID.FireproofBugNet, ItemID.Sickle, ItemID.StaffofRegrowth, ItemID.Clentaminator, ItemID.Clentaminator2, ItemID.BreathingReed, ItemID.Binoculars, ItemID.DontHurtCrittersBook, ItemID.DontHurtNatureBook, ItemID.DontHurtComboBook, ItemID.GravediggerShovel, ItemID.EncumberingStone, ItemID.LawnMower, ItemID.SandcastleBucket, ItemID.IceRod, ItemID.FlareGun] },
        };

        private static readonly Dictionary<string, int[]> Statues = new()
        {
            { "Enemy", [ItemID.ZombieArmStatue, ItemID.BatStatue, ItemID.BloodZombieStatue, ItemID.BoneSkeletonStatue, ItemID.ChestStatue, ItemID.CorruptStatue, ItemID.CrabStatue, ItemID.DripplerStatue, ItemID.EyeballStatue, ItemID.GoblinStatue, ItemID.GraniteGolemStatue, ItemID.HarpyStatue, ItemID.HopliteStatue, ItemID.HornetStatue, ItemID.ImpStatue, ItemID.JellyfishStatue, ItemID.MedusaStatue, ItemID.PigronStatue, ItemID.PiranhaStatue, ItemID.SharkStatue, ItemID.SkeletonStatue, ItemID.SlimeStatue, ItemID.UndeadVikingStatue, ItemID.UnicornStatue, ItemID.WallCreeperStatue, ItemID.WraithStatue] },
            { "Critter", [ItemID.BirdStatue, ItemID.BuggyStatue, ItemID.BunnyStatue, ItemID.ButterflyStatue, ItemID.CockatielStatue, ItemID.DragonflyStatue, ItemID.DuckStatue, ItemID.FireflyStatue, ItemID.FishStatue, ItemID.FrogStatue, ItemID.GrasshopperStatue, ItemID.MacawStatue, ItemID.MouseStatue, ItemID.OwlStatue, ItemID.PenguinStatue, ItemID.ScorpionStatue, ItemID.SeagullStatue, ItemID.SnailStatue, ItemID.SquirrelStatue, ItemID.TurtleStatue, ItemID.WormStatue] },
            { "Other", [ItemID.KingStatue, ItemID.QueenStatue, ItemID.BombStatue, ItemID.HeartStatue, ItemID.StarStatue, ItemID.MushroomStatue, ItemID.BoulderStatue, ItemID.CatBast] },
            { "Decorative", [ItemID.AngelStatue, ItemID.AnvilStatue, ItemID.ArmorStatue, ItemID.AxeStatue, ItemID.BoomerangStatue, ItemID.BootStatue, ItemID.BowStatue, ItemID.CrossStatue, ItemID.GargoyleStatue, ItemID.GloomStatue, ItemID.HammerStatue, ItemID.PickaxeStatue, ItemID.PillarStatue, ItemID.PotStatue, ItemID.PotionStatue, ItemID.ReaperStatue, ItemID.ShieldStatue, ItemID.SpearStatue, ItemID.SunflowerStatue, ItemID.SwordStatue, ItemID.TreeStatue, ItemID.WomanStatue, ItemID.LihzahrdStatue, ItemID.LihzahrdGuardianStatue, ItemID.LihzahrdWatcherStatue] },
            // TODO: Text statues?
        };
        
        private static readonly Dictionary<string, int[]> Accessories = new()
        {
            { "Movement", [ItemID.Aglet, ItemID.BalloonHorseshoeHoney, ItemID.AmphibianBoots, ItemID.AnkletoftheWind, ItemID.ArcticDivingGear, ItemID.BalloonPufferfish, ItemID.BlizzardinaBalloon, ItemID.BlizzardinaBottle, ItemID.BlueHorseshoeBalloon, ItemID.BundleofBalloons, ItemID.ClimbingClaws, ItemID.CloudinaBalloon, ItemID.CloudinaBottle, ItemID.DivingGear, ItemID.SandBoots, ItemID.FairyBoots, ItemID.FartInABalloon, ItemID.FartinaJar, ItemID.Flipper, ItemID.FlurryBoots, ItemID.FlyingCarpet, ItemID.FrogFlipper, ItemID.FrogGear, ItemID.FrogLeg, ItemID.FrogWebbing, ItemID.FrostsparkBoots, ItemID.BalloonHorseshoeFart, ItemID.HellfireTreads, ItemID.HermesBoots, ItemID.HoneyBalloon, ItemID.IceSkates, ItemID.FloatingTube, ItemID.JellyfishDivingGear, ItemID.LavaCharm, ItemID.LavaWaders, ItemID.LightningBoots, ItemID.LuckyHorseshoe, ItemID.Magiluminescence, ItemID.MasterNinjaGear, ItemID.MoltenCharm, ItemID.NeptunesShell, ItemID.ObsidianHorseshoe, ItemID.ObsidianWaterWalkingBoots, ItemID.BalloonHorseshoeSharkron, ItemID.RocketBoots, ItemID.SailfishBoots, ItemID.SandstorminaBalloon, ItemID.SandstorminaBottle, ItemID.SharkronBalloon, ItemID.ShinyRedBalloon, ItemID.ShoeSpikes, ItemID.SpectreBoots, ItemID.PortableStool, ItemID.Tabi, ItemID.TerrasparkBoots, ItemID.TigerClimbingGear, ItemID.TsunamiInABottle, ItemID.WaterWalkingBoots, ItemID.WhiteHorseshoeBalloon, ItemID.YellowHorseshoeBalloon] },
            { "Information", [ItemID.CopperWatch, ItemID.TinWatch, ItemID.SilverWatch, ItemID.TungstenWatch, ItemID.GoldWatch, ItemID.PlatinumWatch, ItemID.DepthMeter, ItemID.CellPhone, ItemID.Compass, ItemID.Radar, ItemID.LifeformAnalyzer, ItemID.TallyCounter, ItemID.MetalDetector, ItemID.Stopwatch, ItemID.DPSMeter, ItemID.FishermansGuide, ItemID.WeatherRadio, ItemID.Sextant, ItemID.Shellphone, ItemID.GPS, ItemID.REK, ItemID.GoblinTech, ItemID.FishFinder, ItemID.PDA, ItemID.MechanicalLens, ItemID.Ruler, ItemID.LaserRuler] },
            { "Health/Mana", [ItemID.ArcaneFlower, ItemID.BandofRegeneration, ItemID.BandofStarpower, ItemID.CelestialCuffs, ItemID.CelestialMagnet, ItemID.CelestialEmblem, ItemID.CharmofMyths, ItemID.MagicCuffs, ItemID.MagnetFlower, ItemID.ManaCloak, ItemID.ManaFlower, ItemID.ManaRegenerationBand, ItemID.NaturesGift, ItemID.PhilosophersStone] },
            { "Combat", [ItemID.AdhesiveBandage, ItemID.AnkhCharm, ItemID.AnkhShield, ItemID.ArmorBracing, ItemID.ArmorPolish, ItemID.AvengerEmblem, ItemID.BeeCloak, ItemID.BerserkerGlove, ItemID.Bezoar, ItemID.BlackBelt, ItemID.Blindfold, ItemID.CelestialEmblem, ItemID.MoonCharm, ItemID.MoonShell, ItemID.CelestialStone, ItemID.CelestialShell, ItemID.CobaltShield, ItemID.CountercurseMantra, ItemID.CrossNecklace, ItemID.DestroyerEmblem, ItemID.EyeoftheGolem, ItemID.FastClock, ItemID.FeralClaws, ItemID.FireGauntlet, ItemID.FleshKnuckles, ItemID.FrozenTurtleShell, ItemID.FrozenShield, ItemID.HandWarmer, ItemID.HeroShield, ItemID.HoneyComb, ItemID.MagicQuiver, ItemID.LavaSkull, ItemID.MagmaStone, ItemID.MechanicalGlove, ItemID.MedicatedBandage, ItemID.Megaphone, ItemID.MoonStone, ItemID.MoltenQuiver, ItemID.MoltenSkullRose, ItemID.Nazar, ItemID.ObsidianRose, ItemID.ObsidianShield, ItemID.ObsidianSkull, ItemID.ObsidianSkullRose, ItemID.PaladinsShield, ItemID.PanicNecklace, ItemID.PocketMirror, ItemID.PowerGlove, ItemID.PutridScent, ItemID.RangerEmblem, ItemID.ReconScope, ItemID.RifleScope, ItemID.Shackle, ItemID.SharkToothNecklace, ItemID.SniperScope, ItemID.SorcererEmblem, ItemID.StalkersQuiver, ItemID.StarCloak, ItemID.StarVeil, ItemID.StingerNecklace, ItemID.SummonerEmblem, ItemID.SunStone, ItemID.SweetheartNecklace, ItemID.ThePlan, ItemID.TitanGlove, ItemID.TrifoldMap, ItemID.Vitamins, ItemID.WarriorEmblem, ItemID.ApprenticeScarf, ItemID.SquireShield, ItemID.HuntressBuckler, ItemID.MonkBelt, ItemID.HerculesBeetle, ItemID.NecromanticScroll, ItemID.PapyrusScarab, ItemID.PygmyNecklace] },
            { "Construction", [ItemID.Toolbelt, ItemID.Toolbox, ItemID.PaintSprayer, ItemID.ExtendoGrip, ItemID.PortableCementMixer, ItemID.BrickLayer, ItemID.ArchitectGizmoPack, ItemID.ActuationAccessory, ItemID.AncientChisel, ItemID.HandOfCreation] },
            { "Fishing", [ItemID.HighTestFishingLine, ItemID.AnglerEarring, ItemID.TackleBox, ItemID.FishingBobber, ItemID.FishingBobberGlowingArgon, ItemID.FishingBobberGlowingKrypton, ItemID.FishingBobberGlowingLava, ItemID.FishingBobberGlowingRainbow, ItemID.FishingBobberGlowingStar, ItemID.FishingBobberGlowingViolet, ItemID.FishingBobberGlowingXenon, ItemID.AnglerTackleBag, ItemID.LavaFishingHook, ItemID.LavaproofTackleBag] },
            { "Yoyo", [ItemID.WhiteString, ItemID.RedString, ItemID.OrangeString, ItemID.YellowString, ItemID.LimeString, ItemID.GreenString, ItemID.TealString, ItemID.CyanString, ItemID.SkyBlueString, ItemID.BlueString, ItemID.PurpleString, ItemID.VioletString, ItemID.PinkString, ItemID.BlackString, ItemID.BrownString, ItemID.RainbowString, ItemID.BlackCounterweight, ItemID.YellowCounterweight, ItemID.BlueCounterweight, ItemID.RedCounterweight, ItemID.PurpleCounterweight, ItemID.GreenCounterweight, ItemID.YoYoGlove, ItemID.YoyoBag] },
            { "Misc.", [ItemID.ClothierVoodooDoll, ItemID.CoinRing, ItemID.DiscountCard, ItemID.FlowerBoots, ItemID.GoldRing, ItemID.GreedyRing, ItemID.CordageGuide, ItemID.GuideVoodooDoll, ItemID.JellyfishNecklace, ItemID.LuckyCoin, ItemID.DontStarveShaderItem, ItemID.SpectreGoggles, ItemID.TreasureMagnet] },
            { "Music Boxes", [ItemID.MusicBox, ItemID.MusicBoxOverworldDay, ItemID.MusicBoxAltOverworldDay, ItemID.MusicBoxNight, ItemID.MusicBoxRain, ItemID.MusicBoxSnow, ItemID.MusicBoxIce, ItemID.MusicBoxDesert, ItemID.MusicBoxOcean, ItemID.MusicBoxOceanAlt, ItemID.MusicBoxSpace, ItemID.MusicBoxSpaceAlt, ItemID.MusicBoxUnderground, ItemID.MusicBoxAltUnderground, ItemID.MusicBoxMushrooms, ItemID.MusicBoxJungle, ItemID.MusicBoxCorruption, ItemID.MusicBoxUndergroundCorruption, ItemID.MusicBoxCrimson, ItemID.MusicBoxOWUndergroundCrimson, ItemID.MusicBoxTheHallow, ItemID.MusicBoxUndergroundHallow, ItemID.MusicBoxHell, ItemID.MusicBoxDungeon, ItemID.MusicBoxTemple, ItemID.MusicBoxBoss1, ItemID.MusicBoxBoss2, ItemID.MusicBoxBoss3, ItemID.MusicBoxBoss4, ItemID.MusicBoxBoss5, ItemID.MusicBoxDeerclops, ItemID.MusicBoxQueenSlime, ItemID.MusicBoxPlantera, ItemID.MusicBoxEmpressOfLight, ItemID.MusicBoxDukeFishron, ItemID.MusicBoxEerie, ItemID.MusicBoxEclipse, ItemID.MusicBoxGoblins, ItemID.MusicBoxPirates, ItemID.MusicBoxMartians, ItemID.MusicBoxPumpkinMoon, ItemID.MusicBoxFrostMoon, ItemID.MusicBoxTowers, ItemID.MusicBoxLunarBoss, ItemID.MusicBoxSandstorm, ItemID.MusicBoxDD2, ItemID.MusicBoxSlimeRain, ItemID.MusicBoxTownDay, ItemID.MusicBoxTownNight, ItemID.MusicBoxWindyDay, ItemID.MusicBoxDayRemix, ItemID.MusicBoxTitleAlt, ItemID.MusicBoxStorm, ItemID.MusicBoxGraveyard, ItemID.MusicBoxUndergroundJungle, ItemID.MusicBoxJungleNight, ItemID.MusicBoxMorningRain, ItemID.MusicBoxConsoleTitle, ItemID.MusicBoxUndergroundDesert, ItemID.MusicBoxOWRain, ItemID.MusicBoxOWDay, ItemID.MusicBoxOWNight, ItemID.MusicBoxOWUnderground, ItemID.MusicBoxOWDesert, ItemID.MusicBoxOWOcean, ItemID.MusicBoxOWMushroom, ItemID.MusicBoxOWDungeon, ItemID.MusicBoxOWSpace, ItemID.MusicBoxOWUnderworld, ItemID.MusicBoxOWSnow, ItemID.MusicBoxOWCorruption, ItemID.MusicBoxOWUndergroundCorruption, ItemID.MusicBoxOWCrimson, ItemID.MusicBoxOWUndergroundCrimson, ItemID.MusicBoxOWUndergroundSnow, ItemID.MusicBoxOWUndergroundHallow, ItemID.MusicBoxOWBloodMoon, ItemID.MusicBoxOWBoss2, ItemID.MusicBoxOWBoss1, ItemID.MusicBoxOWInvasion, ItemID.MusicBoxOWTowers, ItemID.MusicBoxOWMoonLord, ItemID.MusicBoxOWPlantera, ItemID.MusicBoxOWJungle, ItemID.MusicBoxOWWallOfFlesh, ItemID.MusicBoxOWHallow, ItemID.MusicBoxCredits, ItemID.MusicBoxShimmer, ItemID.MusicBoxTitle] },
            { "Golf Balls", [ItemID.GolfBallDyedBlack, ItemID.GolfBallDyedBlue, ItemID.GolfBallDyedBrown, ItemID.GolfBallDyedCyan, ItemID.GolfBallDyedGreen, ItemID.GolfBallDyedLimeGreen, ItemID.GolfBallDyedOrange, ItemID.GolfBallDyedPink, ItemID.GolfBallDyedPurple, ItemID.GolfBallDyedRed, ItemID.GolfBallDyedSkyBlue, ItemID.GolfBallDyedTeal, ItemID.GolfBallDyedViolet, ItemID.GolfBallDyedYellow] },
        };

        private static readonly Dictionary<string, int[]> Critters = new()
        {
            { "All",         [ItemID.Bird, ItemID.BlueJay, ItemID.BlueMacaw, ItemID.Buggy, ItemID.Bunny, ItemID.ExplosiveBunny, ItemID.GemBunnyAmethyst, ItemID.GemBunnyTopaz, ItemID.GemBunnySapphire, ItemID.GemBunnyEmerald, ItemID.GemBunnyRuby, ItemID.GemBunnyDiamond, ItemID.GemBunnyAmber, ItemID.Cardinal, ItemID.Duck, ItemID.MallardDuck, ItemID.EnchantedNightcrawler, ItemID.Shimmerfly, ItemID.FairyCritterBlue, ItemID.FairyCritterGreen, ItemID.FairyCritterPink, ItemID.Firefly, ItemID.Frog, ItemID.GlowingSnail, ItemID.Goldfish, ItemID.Grasshopper, ItemID.GrayCockatiel, ItemID.Grebe, ItemID.Grubby, ItemID.LadyBug, ItemID.Lavafly, ItemID.LightningBug, ItemID.Maggot, ItemID.MagmaSnail, ItemID.Mouse, ItemID.Owl, ItemID.Penguin, ItemID.Pupfish, ItemID.Rat, ItemID.ScarletMacaw, ItemID.Scorpion, ItemID.BlackScorpion, ItemID.Seagull, ItemID.Seahorse, ItemID.Sluggy, ItemID.Snail, ItemID.Squirrel, ItemID.GemSquirrelAmethyst, ItemID.GemSquirrelTopaz, ItemID.GemSquirrelSapphire, ItemID.GemSquirrelEmerald, ItemID.GemSquirrelRuby, ItemID.GemSquirrelDiamond, ItemID.GemSquirrelAmber, ItemID.Stinkbug, ItemID.TruffleWorm, ItemID.Toucan, ItemID.Turtle, ItemID.TurtleJungle, ItemID.WaterStrider, ItemID.Worm, ItemID.YellowCockatiel] },
            { "Butterflies", [ItemID.JuliaButterfly, ItemID.MonarchButterfly, ItemID.PurpleEmperorButterfly, ItemID.RedAdmiralButterfly, ItemID.SulphurButterfly, ItemID.TreeNymphButterfly, ItemID.UlyssesButterfly, ItemID.ZebraSwallowtailButterfly, ItemID.HellButterfly, ItemID.EmpressButterfly] },
            { "Dragonflies", [ItemID.YellowDragonfly, ItemID.RedDragonfly, ItemID.BlackDragonfly, ItemID.BlueDragonfly, ItemID.OrangeDragonfly, ItemID.GreenDragonfly] },
            { "Gold",        [ItemID.GoldBird, ItemID.GoldBunny, ItemID.GoldButterfly, ItemID.GoldDragonfly, ItemID.GoldFrog, ItemID.GoldGoldfish, ItemID.GoldGrasshopper, ItemID.GoldLadyBug, ItemID.GoldMouse, ItemID.GoldSeahorse, ItemID.SquirrelGold, ItemID.GoldWaterStrider, ItemID.GoldWorm] },
        };

        private static readonly Dictionary<string, int[]> Ammo = new()
        {
            { "Arrows",  [ItemID.WoodenArrow, ItemID.FlamingArrow, ItemID.UnholyArrow, ItemID.JestersArrow, ItemID.HellfireArrow, ItemID.HolyArrow, ItemID.CursedArrow, ItemID.FrostburnArrow, ItemID.ChlorophyteArrow, ItemID.IchorArrow, ItemID.VenomArrow, ItemID.BoneArrow, ItemID.EndlessQuiver, ItemID.MoonlordArrow, ItemID.ShimmerArrow] },
            { "Bullets", [ItemID.MusketBall, ItemID.MeteorShot, ItemID.SilverBullet, ItemID.CrystalBullet, ItemID.CursedBullet, ItemID.ChlorophyteBullet, ItemID.HighVelocityBullet, ItemID.IchorBullet, ItemID.VenomBullet, ItemID.PartyBullet, ItemID.NanoBullet, ItemID.ExplodingBullet, ItemID.GoldenBullet, ItemID.EndlessMusketPouch, ItemID.MoonlordBullet, ItemID.TungstenBullet] },
            { "Darts",   [ItemID.PoisonDart, ItemID.CrystalDart, ItemID.CursedDart, ItemID.IchorDart] },
            { "Rockets", [ItemID.RocketI, ItemID.RocketII, ItemID.RocketIII, ItemID.RocketIV, ItemID.ClusterRocketI, ItemID.ClusterRocketII, ItemID.DryRocket, ItemID.WetRocket, ItemID.LavaRocket, ItemID.HoneyRocket, ItemID.MiniNukeI, ItemID.MiniNukeII] },
        };

        private static readonly Dictionary<string, int[]> Trophies = new()
        {
            { "Pre-Hardmode", [ItemID.KingSlimeTrophy, ItemID.EyeofCthulhuTrophy, ItemID.EaterofWorldsTrophy, ItemID.BrainofCthulhuTrophy, ItemID.QueenBeeTrophy, ItemID.SkeletronTrophy, ItemID.DeerclopsTrophy, ItemID.WallofFleshTrophy] },
            { "Hardmode",     [ItemID.QueenSlimeTrophy, ItemID.DestroyerTrophy, ItemID.SpazmatismTrophy, ItemID.RetinazerTrophy, ItemID.SkeletronPrimeTrophy, ItemID.PlanteraTrophy, ItemID.FairyQueenTrophy, ItemID.GolemTrophy, ItemID.DukeFishronTrophy, ItemID.AncientCultistTrophy, ItemID.MoonLordTrophy] },
            { "Event",        [ItemID.BossTrophyDarkmage, ItemID.BossTrophyOgre, ItemID.BossTrophyBetsy, ItemID.MourningWoodTrophy, ItemID.PumpkingTrophy, ItemID.EverscreamTrophy, ItemID.IceQueenTrophy, ItemID.SantaNK1Trophy, ItemID.FlyingDutchmanTrophy, ItemID.MartianSaucerTrophy] },
            { "Fishing",             [ItemID.GoldfishTrophy, ItemID.BunnyfishTrophy, ItemID.SwordfishTrophy, ItemID.SharkteethTrophy] },
            { "Golfing",             [ItemID.GolfTrophyBronze, ItemID.GolfTrophySilver, ItemID.GolfTrophyGold] },
        };


        protected override string Identifier { get => "COLLECTOR"; }

        protected override List<string> TexturePaths { get => ["CollectorAchievements/Assets/Achievements"]; }


        protected override void RegisterAchievements()
        {
            ConditionReqs reqs = new(PlayerDiff.Classic, WorldDiff.Classic, SpecialSeed.None);

            RegisterArmorAchievements(reqs);
            RegisterVanityAchievements(reqs);
            RegisterWingsAchievements(reqs);
            RegisterMountAchievements(reqs);
            RegisterPetAchievements(reqs);

            RegisterPaintingAchievements(reqs);
            RegisterBannerAchievements(reqs);
            
            RegisterExtractAchievements(reqs);
            RegisterFishAchievements(reqs);  
        }

        private void RegisterArmorAchievements(ConditionReqs reqs)
        {
            Dictionary<string, int[]> ArmorSets = new()
            {
                { "Mining", [ItemID.MiningHelmet, ItemID.MiningShirt, ItemID.MiningPants]},
                { "Wood", [ItemID.WoodHelmet, ItemID.WoodBreastplate, ItemID.WoodGreaves]},
                { "Rich Mahogany", [ItemID.RichMahoganyHelmet, ItemID.RichMahoganyBreastplate, ItemID.RichMahoganyGreaves]},
                { "Boreal Wood", [ItemID.BorealWoodHelmet, ItemID.BorealWoodBreastplate, ItemID.BorealWoodGreaves]},
                { "Palm Wood", [ItemID.PalmWoodHelmet, ItemID.PalmWoodBreastplate, ItemID.PalmWoodGreaves]},
                { "Ebonwood", [ItemID.EbonwoodHelmet, ItemID.EbonwoodBreastplate, ItemID.EbonwoodGreaves]},
                { "Shadewood", [ItemID.ShadewoodHelmet, ItemID.ShadewoodBreastplate, ItemID.ShadewoodGreaves]},
                { "Ash Wood", [ItemID.AshWoodHelmet, ItemID.AshWoodBreastplate, ItemID.AshWoodGreaves]},
                { "Rain", [ItemID.RainHat, ItemID.RainCoat]},
                { "Snow", [ItemID.EskimoHood, ItemID.EskimoCoat, ItemID.EskimoPants]},
                { "Pink Snow", [ItemID.PinkEskimoHood, ItemID.PinkEskimoCoat, ItemID.PinkEskimoPants]},
                { "Angler", [ItemID.AnglerHat, ItemID.AnglerVest, ItemID.AnglerPants]},
                { "Cactus", [ItemID.CactusHelmet, ItemID.CactusBreastplate, ItemID.CactusLeggings]},
                { "Copper", [ItemID.CopperHelmet, ItemID.CopperChainmail, ItemID.CopperGreaves]},
                { "Tin", [ItemID.TinHelmet, ItemID.TinChainmail, ItemID.TinGreaves]},
                { "Pumpkin", [ItemID.PumpkinHelmet, ItemID.PumpkinBreastplate, ItemID.PumpkinLeggings]},
                { "Ninja", [ItemID.NinjaHood, ItemID.NinjaShirt, ItemID.NinjaPants]},
                { "Iron", [ItemID.IronHelmet, ItemID.IronChainmail, ItemID.IronGreaves]},
                { "Lead", [ItemID.LeadHelmet, ItemID.LeadChainmail, ItemID.LeadGreaves]},
                { "Silver", [ItemID.SilverHelmet, ItemID.SilverChainmail, ItemID.SilverGreaves]},
                { "Tungsten", [ItemID.TungstenHelmet, ItemID.TungstenChainmail, ItemID.TungstenGreaves]},
                { "Gold", [ItemID.GoldHelmet, ItemID.GoldChainmail, ItemID.GoldGreaves]},
                { "Platinum", [ItemID.PlatinumHelmet, ItemID.PlatinumChainmail, ItemID.PlatinumGreaves]},
                { "Fossil", [ItemID.FossilHelm, ItemID.FossilShirt, ItemID.FossilPants]},
                { "Bee", [ItemID.BeeHeadgear, ItemID.BeeBreastplate, ItemID.BeePants]},
                { "Obsidian", [ItemID.ObsidianHelm, ItemID.ObsidianShirt, ItemID.ObsidianPants]},
                { "Gladiator", [ItemID.GladiatorHelmet, ItemID.GladiatorBreastplate, ItemID.GladiatorLeggings]},
                { "Meteor", [ItemID.MeteorHelmet, ItemID.MeteorSuit, ItemID.MeteorLeggings]},
                { "Jungle", [ItemID.JungleHat, ItemID.JungleShirt, ItemID.JunglePants]},
                { "Ancient Cobalt", [ItemID.AncientCobaltHelmet, ItemID.AncientCobaltBreastplate, ItemID.AncientCobaltLeggings]},
                { "Necro", [ItemID.NecroHelmet, ItemID.NecroBreastplate, ItemID.NecroGreaves]},
                { "Shadow", [ItemID.ShadowHelmet, ItemID.ShadowScalemail, ItemID.ShadowGreaves]},
                { "Ancient Shadow", [ItemID.AncientShadowHelmet, ItemID.AncientShadowScalemail, ItemID.AncientShadowGreaves]},
                { "Crimson", [ItemID.CrimsonHelmet, ItemID.CrimsonScalemail, ItemID.CrimsonGreaves]},
                { "Molten", [ItemID.MoltenHelmet, ItemID.MoltenBreastplate, ItemID.MoltenGreaves]}
            };

            Dictionary<string, int[]> ArmorHardmode = new()
            {
                { "Pearlwood", [ItemID.PearlwoodHelmet, ItemID.PearlwoodBreastplate, ItemID.PearlwoodGreaves]},
                { "Spider", [ItemID.SpiderMask, ItemID.SpiderBreastplate, ItemID.SpiderGreaves]},
                { "Cobalt", [ItemID.CobaltHat, ItemID.CobaltHelmet, ItemID.CobaltMask, ItemID.CobaltBreastplate, ItemID.CobaltLeggings]},
                { "Palladium", [ItemID.PalladiumHeadgear, ItemID.PalladiumMask, ItemID.PalladiumHelmet, ItemID.PalladiumBreastplate, ItemID.PalladiumLeggings]},
                { "Mythril", [ItemID.MythrilHood, ItemID.MythrilHelmet, ItemID.MythrilHat, ItemID.MythrilChainmail, ItemID.MythrilGreaves]},
                { "Orichalcum", [ItemID.OrichalcumHeadgear, ItemID.OrichalcumMask, ItemID.OrichalcumHelmet, ItemID.OrichalcumBreastplate, ItemID.OrichalcumLeggings]},
                { "Adamantite", [ItemID.AdamantiteHeadgear, ItemID.AdamantiteHelmet, ItemID.AdamantiteMask, ItemID.AdamantiteBreastplate, ItemID.AdamantiteLeggings]},
                { "Titanium", [ItemID.TitaniumHeadgear, ItemID.TitaniumMask, ItemID.TitaniumHelmet, ItemID.TitaniumBreastplate, ItemID.TitaniumLeggings]},
                { "Crystal Assassin", [ItemID.CrystalNinjaHelmet, ItemID.CrystalNinjaChestplate, ItemID.CrystalNinjaLeggings]},
                { "Frost", [ItemID.FrostHelmet, ItemID.FrostBreastplate, ItemID.FrostLeggings]},
                { "Forbidden", [ItemID.AncientBattleArmorHat, ItemID.AncientBattleArmorShirt, ItemID.AncientBattleArmorPants]},
                { "Squire", [ItemID.SquireGreatHelm, ItemID.SquirePlating, ItemID.SquireGreaves]},
                { "Monk", [ItemID.MonkBrows, ItemID.MonkShirt, ItemID.MonkPants]},
                { "Huntress", [ItemID.HuntressWig, ItemID.HuntressJerkin, ItemID.HuntressPants]},
                { "Apprentice", [ItemID.ApprenticeHat, ItemID.ApprenticeRobe, ItemID.ApprenticeTrousers]},
                { "Hallowed", [ItemID.HallowedMask, ItemID.HallowedHelmet, ItemID.HallowedHood, ItemID.HallowedHood, ItemID.HallowedPlateMail, ItemID.HallowedGreaves]},
                { "Ancient Hallowed", [ItemID.AncientHallowedMask, ItemID.AncientHallowedHelmet, ItemID.AncientHallowedHood, ItemID.AncientHallowedHood, ItemID.AncientHallowedPlateMail, ItemID.AncientHallowedGreaves]},
                { "Chlorophyte", [ItemID.ChlorophyteMask, ItemID.ChlorophyteHelmet, ItemID.ChlorophyteHeadgear, ItemID.ChlorophytePlateMail, ItemID.ChlorophyteGreaves]},
                { "Turtle", [ItemID.TurtleHelmet, ItemID.TurtleScaleMail, ItemID.TurtleLeggings]},
                { "Tiki", [ItemID.TikiMask, ItemID.TikiShirt, ItemID.TikiPants]},
                { "Beetle", [ItemID.BeetleHelmet, ItemID.BeetleScaleMail, ItemID.BeetleShell, ItemID.BeetleLeggings]},
                { "Shroomite", [ItemID.ShroomiteHeadgear, ItemID.ShroomiteHelmet, ItemID.ShroomiteMask, ItemID.ShroomiteBreastplate, ItemID.ShroomiteLeggings]},
                { "Spectre", [ItemID.SpectreMask, ItemID.SpectreHood, ItemID.SpectreRobe, ItemID.SpectrePants]},
                { "Spooky", [ItemID.SpookyHelmet, ItemID.SpookyBreastplate, ItemID.SpookyLeggings]},
                { "Valhalla Knight", [ItemID.SquireAltHead, ItemID.SquireAltShirt, ItemID.SquireAltPants]},
                { "Shinobi Infiltrator", [ItemID.MonkAltHead, ItemID.MonkAltShirt, ItemID.MonkAltPants]},
                { "Red Riding", [ItemID.HuntressAltHead, ItemID.HuntressAltShirt, ItemID.HuntressAltPants]},
                { "Dark Artist", [ItemID.ApprenticeAltHead, ItemID.ApprenticeAltShirt, ItemID.ApprenticeAltPants]},
                { "Solar Flare", [ItemID.SolarFlareHelmet, ItemID.SolarFlareBreastplate, ItemID.SolarFlareLeggings]},
                { "Vortex", [ItemID.VortexHelmet, ItemID.VortexBreastplate, ItemID.VortexLeggings]},
                { "Nebula", [ItemID.NebulaHelmet, ItemID.NebulaBreastplate, ItemID.NebulaLeggings]},
                { "Stardust", [ItemID.StardustHelmet, ItemID.StardustBreastplate, ItemID.StardustLeggings]}
            };

            Dictionary<string, int[]> ArmorPieces = new()
            {
                { "ARMOR_WIZARD", [ItemID.MagicHat, ItemID.WizardHat, ItemID.AmethystRobe, ItemID.TopazRobe, ItemID.SapphireRobe, ItemID.EmeraldRobe, ItemID.RubyRobe, ItemID.AmberRobe, ItemID.DiamondRobe, ItemID.GypsyRobe] },
                { "ARMOR_OTHER", [ItemID.EmptyBucket, ItemID.Goggles, ItemID.DivingHelmet, ItemID.NightVisionHelmet, ItemID.VikingHelmet, ItemID.UltrabrightHelmet, ItemID.FlinxFurCoat, ItemID.Gi, ItemID.MoonLordLegs, ItemID.GreenCap]}
            };

            RegisterAchievement("ARMOR_MINING", NpcDropCondition.DropAll(reqs, NPCID.UndeadMiner, [ItemID.MiningShirt, ItemID.MiningPants]), true, AchievementCategory.Collector);
            RegisterAchievement("ARMOR_RAIN", NpcDropCondition.DropAll(reqs, NPCID.ZombieRaincoat, ArmorSets["Rain"]), true, AchievementCategory.Collector);
            RegisterAchievement("ARMOR_SNOW", NpcDropCondition.DropAll(reqs, NPCID.ZombieEskimo, ArmorSets["Snow"]), true, AchievementCategory.Collector);
            RegisterAchievement("ARMOR_GREEN_CAP", NpcDropCondition.Drop(reqs, NPCID.Guide, ItemID.GreenCap), AchievementCategory.Collector);
            RegisterAchievement("ARMOR_DIVING_HELMET", NpcDropCondition.Drop(reqs, NPCID.Shark, ItemID.DivingHelmet), AchievementCategory.Collector);
            RegisterAchievement("ARMOR_VIKING_HELMET", NpcDropCondition.Drop(reqs, NPCID.UndeadViking, ItemID.VikingHelmet), AchievementCategory.Collector);
            RegisterAchievement("ARMOR_DJINNS_CURSE", NpcDropCondition.Drop(reqs, NPCID.DesertDjinn, ItemID.DjinnsCurse), AchievementCategory.Collector);

            List<AchCondition> sets = [];
            foreach (var set in ArmorSets)
                sets.AddRange(ItemGrabCondition.GrabAll(reqs, set.Value));
            RegisterAchievement("ARMOR_SETS", sets, true, AchievementCategory.Collector);

            sets = [];
            foreach (var set in ArmorHardmode)
                sets.AddRange(ItemGrabCondition.GrabAll(reqs, set.Value));
            RegisterAchievement("ARMOR_HARDMODE", sets, true, AchievementCategory.Collector);

            foreach (var group in ArmorPieces)
                RegisterAchievement(group.Key, ItemGrabCondition.GrabAll(reqs, group.Value), group.Value.Length > 1, AchievementCategory.Collector);
        }

        private void RegisterVanityAchievements(ConditionReqs reqs)
        {
            Dictionary<string, int[]> VanitySets = new()
            {
                { "Ancient", [ItemID.AncientArmorHat, ItemID.AncientArmorShirt, ItemID.AncientArmorPants] },
                { "Archaeologist's", [ItemID.ArchaeologistsHat, ItemID.ArchaeologistsJacket, ItemID.ArchaeologistsPants] },
                { "Bee", [ItemID.BeeHat, ItemID.BeeShirt, ItemID.BeePants] },
                { "Black Graduation", [ItemID.GraduationCapBlack, ItemID.GraduationGownBlack] },
                { "Blue Graduation", [ItemID.GraduationCapBlue, ItemID.GraduationGownBlue] },
                { "Buccaneer", [ItemID.BuccaneerBandana, ItemID.BuccaneerShirt, ItemID.BuccaneerPants] },
                { "Bunny", [ItemID.BunnyEars, ItemID.BunnyTail] },
                { "Butcher's", [ItemID.ButcherMask, ItemID.ButcherApron, ItemID.ButcherPants] },
                { "Capricorn", [ItemID.CapricornMask, ItemID.CapricornChestplate, ItemID.CapricornLegs, ItemID.CapricornTail] },
                { "Chef", [ItemID.ChefHat, ItemID.ChefShirt, ItemID.ChefPants] },
                { "Clown", [ItemID.ClownHat, ItemID.ClownShirt, ItemID.ClownPants] },
                { "Country Club", [ItemID.GolfHat, ItemID.GolfShirt, ItemID.GolfPants] },
                { "Cowboy", [ItemID.CowboyHat, ItemID.CowboyJacket, ItemID.CowboyPants] },
                { "Dog", [ItemID.DogEars, ItemID.DogTail] },
                { "Dr. Man Fly", [ItemID.DrManFlyMask, ItemID.DrManFlyLabCoat] },
                { "Elf", [ItemID.ElfHat, ItemID.ElfShirt, ItemID.ElfPants] },
                { "Fallen Tuxedo", [ItemID.FallenTuxedoShirt, ItemID.FallenTuxedoPants] },
                { "Familiar", [ItemID.FamiliarWig, ItemID.FamiliarShirt, ItemID.FamiliarPants] },
                { "Firestarter's", [ItemID.WillowShirt, ItemID.WillowSkirt] },
                { "Fish", [ItemID.FishCostumeMask, ItemID.FishCostumeShirt, ItemID.FishCostumeFinskirt] },
                { "Floret Protector", [ItemID.FloretProtectorHelmet, ItemID.FloretProtectorChestplate, ItemID.FloretProtectorLegs] },
                { "Fox", [ItemID.FoxEars, ItemID.FoxTail] },
                { "Funeral", [ItemID.FuneralHat, ItemID.FuneralCoat, ItemID.FuneralPants] },
                { "Gentleman", [ItemID.WilsonBeardShort, ItemID.WilsonBeardLong, ItemID.WilsonBeardMagnificent, ItemID.WilsonShirt, ItemID.WilsonPants] },
                { "Gravedigger", [ItemID.UndertakerHat, ItemID.UndertakerCoat] },
                { "Hero's", [ItemID.HerosHat, ItemID.HerosShirt, ItemID.HerosPants] },
                { "Lamia", [ItemID.LamiaHat, ItemID.LamiaShirt, ItemID.LamiaPants] },
                { "Lizard", [ItemID.LizardEars, ItemID.LizardTail] },
                { "Lunar Cultist", [ItemID.BlueLunaticHood, ItemID.BlueLunaticRobe] },
                { "Maid", [ItemID.MaidHead, ItemID.MaidShirt, ItemID.MaidPants] },
                { "Maroon Graduation", [ItemID.GraduationCapMaroon, ItemID.GraduationGownMaroon] },
                { "Martian Costume", [ItemID.MartianCostumeMask, ItemID.MartianCostumeShirt, ItemID.MartianCostumePants] },
                { "Martian Uniform", [ItemID.MartianUniformHelmet, ItemID.MartianUniformTorso, ItemID.MartianUniformPants] },
                { "Master Gamer's", [ItemID.GameMasterShirt, ItemID.GameMasterPants] },
                { "Mermaid", [ItemID.SeashellHairpin, ItemID.MermaidAdornment, ItemID.MermaidTail] },
                { "Mummy", [ItemID.MummyMask, ItemID.MummyShirt, ItemID.MummyPants] },
                { "Mushroom", [ItemID.MushroomHat, ItemID.MushroomVest, ItemID.MushroomPants] },
                { "Pedguin's", [ItemID.PedguinHat, ItemID.PedguinShirt, ItemID.PedguinPants] },
                { "Pharaoh's", [ItemID.PharaohsMask, ItemID.PharaohsRobe] },
                { "Pink Maid", [ItemID.MaidHead2, ItemID.MaidShirt2, ItemID.MaidPants2] },
                { "Pirate", [ItemID.PirateHat, ItemID.PirateShirt, ItemID.PiratePants] },
                { "Plaguebringer's", [ItemID.PlaguebringerHelmet, ItemID.PlaguebringerChestplate, ItemID.PlaguebringerGreaves] },
                { "Plumber's", [ItemID.PlumbersHat, ItemID.PlumbersPants, ItemID.PlumbersPants] },
                { "Pretty Pink", [ItemID.PrettyPinkRibbon, ItemID.PrettyPinkDressSkirt, ItemID.PrettyPinkDressPants] },
                { "Prince", [ItemID.PrinceUniform, ItemID.PrincePants, ItemID.PrinceCape] },
                { "Princess", [ItemID.Tiara, ItemID.PrincessDress] },
                { "Royal", [ItemID.RoyalTiara, ItemID.RoyalDressTop, ItemID.RoyalDressBottom] },
                { "Rune", [ItemID.RuneHat, ItemID.RuneRobe] },
                { "Sailor", [ItemID.SailorHat, ItemID.SailorShirt, ItemID.SailorPants] },
                { "Scarecrow", [ItemID.ScarecrowHat, ItemID.ScarecrowShirt, ItemID.ScarecrowPants] },
                { "Silly Sunflower", [ItemID.FlowerBoyHat, ItemID.FlowerBoyShirt, ItemID.FlowerBoyPants] },
                { "Solar Cultist", [ItemID.WhiteLunaticHood, ItemID.WhiteLunaticRobe] },
                { "Star Princess", [ItemID.StarPrincessCrown, ItemID.StarPrincessDress] },
                { "Steampunk", [ItemID.SteampunkHat, ItemID.SteampunkShirt, ItemID.SteampunkPants] },
                { "Superhero", [ItemID.SuperHeroMask, ItemID.SuperHeroCostume, ItemID.SuperHeroTights] },
                { "Tax Collector's", [ItemID.TaxCollectorHat, ItemID.TaxCollectorSuit, ItemID.TaxCollectorPants] },
                { "The Doctor's", [ItemID.TheDoctorsShirt, ItemID.TheDoctorsPants] },
                { "Timeless Traveler's", [ItemID.TimelessTravelerHood, ItemID.TimelessTravelerRobe, ItemID.TimelessTravelerBottom] },
                { "Tuxedo", [ItemID.TopHat, ItemID.TuxedoShirt, ItemID.TuxedoPants] },
                { "TV Head", [ItemID.TVHeadMask, ItemID.TVHeadSuit, ItemID.TVHeadPants] },
                { "Victorian Goth", [ItemID.VictorianGothHat, ItemID.VictorianGothDress] },
                { "Wandering", [ItemID.RoninHat, ItemID.RoninShirt, ItemID.RoninPants] },
                { "Wedding", [ItemID.TheBrideHat, ItemID.TheBrideDress] },
                { "White Tuxedo", [ItemID.WhiteTuxedoShirt, ItemID.WhiteTuxedoPants] }
            };

            Dictionary<string, int[]> VanityHalloween = new()
            {
                { "Bride of Frankenstein", [ItemID.BrideofFrankensteinMask, ItemID.BrideofFrankensteinDress] },
                { "Cat", [ItemID.CatMask, ItemID.CatShirt, ItemID.CatPants] },
                { "Clothier's", [ItemID.RedHat, ItemID.ClothierJacket, ItemID.ClothierPants] },
                { "Creeper", [ItemID.CreeperMask, ItemID.CreeperShirt, ItemID.CreeperPants] },
                { "Cyborg", [ItemID.CyborgHelmet, ItemID.CyborgShirt, ItemID.CyborgPants] },
                { "Dryad", [ItemID.DryadCoverings, ItemID.DryadLoincloth] },
                { "Dye Trader's", [ItemID.DyeTraderTurban, ItemID.DyeTraderRobe] },
                { "Fox", [ItemID.FoxMask, ItemID.FoxShirt, ItemID.FoxPants] },
                { "Ghost", [ItemID.GhostMask, ItemID.GhostShirt] },
                { "Karate Tortoise", [ItemID.KarateTortoiseMask, ItemID.KarateTortoiseShirt, ItemID.KarateTortoisePants] },
                { "Leprechaun", [ItemID.LeprechaunHat, ItemID.LeprechaunShirt, ItemID.LeprechaunPants] },
                { "Nurse", [ItemID.NurseHat, ItemID.NurseShirt, ItemID.NursePants] },
                { "Pixie", [ItemID.PixieShirt, ItemID.PixiePants] },
                { "Princess", [ItemID.PrincessHat, ItemID.PrincessDressNew] },
                { "Pumpkin", [ItemID.PumpkinHelmet, ItemID.PumpkinShirt, ItemID.PumpkinPants] },
                { "Reaper", [ItemID.ReaperHood, ItemID.ReaperRobe] },
                { "Robot", [ItemID.RobotMask, ItemID.RobotShirt, ItemID.RobotPants] },
                { "Space Creature", [ItemID.SpaceCreatureMask, ItemID.SpaceCreatureShirt, ItemID.SpaceCreaturePants] },
                { "Treasure Hunter", [ItemID.TreasureHunterShirt, ItemID.TreasureHunterPants] },
                { "Unicorn", [ItemID.UnicornMask, ItemID.UnicornShirt, ItemID.UnicornPants] },
                { "Vampire", [ItemID.VampireMask, ItemID.VampireShirt, ItemID.VampirePants] },
                { "Witch", [ItemID.WitchHat, ItemID.WitchDress, ItemID.WitchBoots] },
                { "Wolf", [ItemID.WolfMask, ItemID.WolfShirt, ItemID.WolfPants] }
            };

            Dictionary<string, int[]> VanityChristmas = new()
            {
                { "Mrs. Claus", [ItemID.MrsClauseHat, ItemID.MrsClauseShirt, ItemID.MrsClauseHeels] },
                { "Parka", [ItemID.ParkaHood, ItemID.ParkaCoat, ItemID.ParkaPants] },
                { "Santa", [ItemID.SantaHat, ItemID.SantaShirt, ItemID.SantaPants] },
                { "Tree", [ItemID.TreeMask, ItemID.TreeShirt, ItemID.TreeTrunks] }
            };

            int[] VanityMasks = [ItemID.BossMaskBetsy, ItemID.BrainMask, ItemID.BossMaskDarkMage, ItemID.DeerclopsMask, ItemID.DestroyerMask, ItemID.DukeFishronMask, ItemID.EaterMask, ItemID.FairyQueenMask, ItemID.EyeMask, ItemID.GolemMask, ItemID.KingSlimeMask, ItemID.BossMaskCultist, ItemID.MoonMask, ItemID.OgreMask, ItemID.PlanteraMask, ItemID.BeeMask, ItemID.QueenSlimeMask, ItemID.SkeletronMask, ItemID.SkeletronPrimeMask, ItemID.TwinMask, ItemID.FleshMask];

            Dictionary<string, int[]> VanityPieces = new()
            {
                { "VANITY_ACCESSORY", [ItemID.AngelHalo, ItemID.PartyBalloonAnimal, ItemID.BundleofBalloons, ItemID.BunnyTail, ItemID.CrimsonCloak, ItemID.DiamondRing, ItemID.DogTail, ItemID.UnicornHornHat, ItemID.FlameWakerBoots, ItemID.FoxTail, ItemID.WilsonBeardShort, ItemID.WilsonBeardLong, ItemID.WilsonBeardMagnificent, ItemID.GingerBeard, ItemID.GlassSlipper, ItemID.HunterCloak, ItemID.JungleRose, ItemID.LizardTail, ItemID.MysteriousCape, ItemID.RedCape, ItemID.RoyalScepter, ItemID.WinterCape, ItemID.PrinceCape, ItemID.CritterShampoo, ItemID.RainbowCursor, ItemID.ShimmerMonolith, ItemID.BloodMoonMonolith, ItemID.VortexMonolith, ItemID.NebulaMonolith, ItemID.StardustMonolith, ItemID.SolarMonolith, ItemID.VoidMonolith] },
                { "VANITY_OTHER", [ItemID.BadgersHat, ItemID.BallaHat, ItemID.Beanie, ItemID.BunnyHood, ItemID.CatEars, ItemID.DeadMansSweater, ItemID.DemonHorns, ItemID.DevilHorns, ItemID.DizzyHat, ItemID.DjinnsCurse, ItemID.EngineeringHelmet, ItemID.EyePatch, ItemID.Eyebrella, ItemID.Fedora, ItemID.Fez, ItemID.FishBowl, ItemID.GangstaHat, ItemID.GarlandHat, ItemID.GiantBow, ItemID.GoblorcEar, ItemID.GoldCrown, ItemID.GoldGoldfishBowl, ItemID.GreenCap, ItemID.GuyFawkesMask, ItemID.HeartHairpin, ItemID.HiTekSunglasses, ItemID.JackOLanternMask, ItemID.JimsCap, ItemID.Kimono, ItemID.MimeMask, ItemID.MoonMask, ItemID.MushroomCap, ItemID.PandaEars, ItemID.PartyHat, ItemID.PeddlersHat, ItemID.PlatinumCrown, ItemID.RabbitOrder, ItemID.ReindeerAntlers, ItemID.Robe, ItemID.RobotHat, ItemID.RockGolemHead, ItemID.SWATHelmet, ItemID.Skull, ItemID.SnowHat, ItemID.StarHairpin, ItemID.SteampunkGoggles, ItemID.SummerHat, ItemID.SunMask, ItemID.Sunglasses, ItemID.TamOShanter, ItemID.UglySweater, ItemID.UmbrellaHat, ItemID.VulkelfEar, ItemID.WizardsHat] }
            };

            RegisterAchievement("VANITY_HERO", ItemCraftCondition.CraftAll(reqs, VanitySets["Hero's"]), true, AchievementCategory.Collector);
            RegisterAchievement("VANITY_LAMIA", NpcDropCondition.DropAll(reqs, NPCID.None, VanitySets["Lamia"]), true, AchievementCategory.Collector);
            RegisterAchievement("VANITY_MUMMY", NpcDropCondition.DropAll(reqs, NPCID.None, VanitySets["Mummy"]), true, AchievementCategory.Collector);
            RegisterAchievement("VANITY_PLUMBER", NpcDropCondition.Drop(reqs, NPCID.FireImp, ItemID.PlumbersHat), AchievementCategory.Collector);
            RegisterAchievement("VANITY_CREPPER", ItemOpenCondition.OpenAll(reqs, ItemID.GoodieBag, VanityHalloween["Creeper"]), true, AchievementCategory.Collector);
            RegisterAchievement("VANITY_ROSE", TileDropCondition.Drop(reqs, ItemID.JungleRose), AchievementCategory.Collector);
            RegisterAchievement("VANITY_BADGER", NpcDropCondition.Drop(reqs, NPCID.None, ItemID.BadgersHat), AchievementCategory.Collector);
            RegisterAchievement("VANITY_JIM", NpcDropCondition.Drop(reqs, NPCID.Painter, ItemID.JimsCap), AchievementCategory.Collector);
            RegisterAchievement("VANITY_ROBOT", NpcDropCondition.Drop(reqs, NPCID.None, ItemID.RobotHat), AchievementCategory.Collector);
            RegisterAchievement("VANITY_SKULL", NpcDropCondition.Drop(reqs, NPCID.None, ItemID.Skull), AchievementCategory.Collector);
            RegisterAchievement("VANITY_UMBRELLA", NpcDropCondition.Drop(reqs, NPCID.UmbrellaSlime, ItemID.UmbrellaHat), AchievementCategory.Collector);

            List<AchCondition> sets = [];
            foreach (var set in VanitySets)
                sets.AddRange(ItemGrabCondition.GrabAll(reqs, set.Value));
            RegisterAchievement("VANITY_SETS", sets, true, AchievementCategory.Collector);

            sets = [];
            foreach (var set in VanityHalloween)
                sets.AddRange(ItemGrabCondition.GrabAll(reqs, set.Value));
            RegisterAchievement("VANITY_HALLOWEEN", sets, true, AchievementCategory.Collector);

            sets = [];
            foreach (var set in VanityChristmas)
                sets.AddRange(ItemGrabCondition.GrabAll(reqs, set.Value));
            RegisterAchievement("VANITY_CHRISTMAS", sets, true, AchievementCategory.Collector);

            RegisterAchievement("VANITY_MASKS", NpcDropCondition.DropAll(reqs, NPCID.None, VanityMasks), true, AchievementCategory.Collector);

            foreach (var group in VanityPieces)
                RegisterAchievement(group.Key, ItemGrabCondition.GrabAll(reqs, group.Value), group.Value.Length > 1, AchievementCategory.Collector);
        }

        private void RegisterBannerAchievements(ConditionReqs reqs)
        {
            Dictionary<string, int[]> Banners = new()
            {
                { "BANNERS_SLIME", [ItemID.SlimeBanner, ItemID.GreenSlimeBanner, ItemID.PurpleSlimeBanner, ItemID.UmbrellaSlimeBanner, ItemID.RedSlimeBanner, ItemID.YellowSlimeBanner, ItemID.BlackSlimeBanner, ItemID.MotherSlimeBanner, ItemID.DungeonSlimeBanner, ItemID.PinkyBanner, ItemID.JungleSlimeBanner, ItemID.SpikedJungleSlimeBanner, ItemID.IceSlimeBanner, ItemID.SpikedIceSlimeBanner, ItemID.SandSlimeBanner, ItemID.LavaSlimeBanner, ItemID.ShimmerSlimeBanner, ItemID.ToxicSludgeBanner, ItemID.CorruptSlimeBanner, ItemID.SlimerBanner, ItemID.CrimslimeBanner, ItemID.GastropodBanner, ItemID.IlluminantSlimeBanner, ItemID.RainbowSlimeBanner] },
            
                // Environments
                { "BANNERS_CAVERN", [ItemID.BatBanner, ItemID.CochinealBeetleBanner, ItemID.CrawdadBanner, ItemID.GiantShellyBanner, ItemID.WormBanner, ItemID.GnomeBanner, ItemID.NypmhBanner, ItemID.SalamanderBanner, ItemID.SkeletonBanner, ItemID.TimBanner, ItemID.UndeadMinerBanner, ItemID.JellyfishBanner, ItemID.ArmoredSkeletonBanner, ItemID.GiantBatBanner, ItemID.MimicBanner, ItemID.RockGolemBanner, ItemID.RuneWizardBanner, ItemID.SkeletonArcherBanner, ItemID.AnglerFishBanner, ItemID.GreenJellyfishBanner] },
                { "BANNERS_CORRUPTION", [ItemID.DevourerBanner, ItemID.EaterofSoulsBanner, ItemID.ClingerBanner, ItemID.BigMimicCorruptionBanner, ItemID.CorruptorBanner, ItemID.CursedHammerBanner, ItemID.DarkMummyBanner, ItemID.WorldFeederBanner] },
                { "BANNERS_CRIMSON", [ItemID.BloodCrawlerBanner, ItemID.CrimeraBanner, ItemID.FaceMonsterBanner, ItemID.BloodFeederBanner, ItemID.BloodJellyBanner, ItemID.BloodMummyBanner, ItemID.CrimsonAxeBanner, ItemID.BigMimicCrimsonBanner, ItemID.FloatyGrossBanner, ItemID.HerplingBanner, ItemID.IchorStickerBanner] },
                { "BANNERS_DESERT", [ItemID.AntlionBanner, ItemID.WalkingAntlionBanner, ItemID.LarvaeAntlionBanner, ItemID.FlyingAntlionBanner, ItemID.TombCrawlerBanner, ItemID.VultureBanner, ItemID.DesertBasiliskBanner, ItemID.DesertDjinnBanner, ItemID.DuneSplicerBanner, ItemID.DesertGhoulBanner, ItemID.DesertLamiaBanner, ItemID.MummyBanner, ItemID.RavagerScorpionBanner] },
                { "BANNERS_DUNGEON", [ItemID.AngryBonesBanner, ItemID.CursedSkullBanner, ItemID.SkeletonMageBanner, ItemID.BlueArmoredBonesBanner, ItemID.RustyArmoredBonesBanner, ItemID.HellArmoredBonesBanner, ItemID.DiablolistBanner, ItemID.NecromancerBanner, ItemID.RaggedCasterBanner, ItemID.BoneLeeBanner, ItemID.SkeletonCommandoBanner, ItemID.SkeletonSniperBanner, ItemID.TacticalSkeletonBanner, ItemID.DungeonSpiritBanner, ItemID.GiantCursedSkullBanner, ItemID.PaladinBanner] },
                { "BANNERS_GLOWING_MUSHROOM", [ItemID.AnomuraFungusBanner, ItemID.FungiBulbBanner, ItemID.MushiLadybugBanner, ItemID.SporeBatBanner, ItemID.SporeSkeletonBanner, ItemID.SporeZombieBanner, ItemID.FungoFishBanner] },
                { "BANNERS_GRANITE_CAVE", [ItemID.GraniteFlyerBanner, ItemID.GraniteGolemBanner] },
                { "BANNERS_HALLOW", [ItemID.ChaosElementalBanner, ItemID.EnchantedSwordBanner, ItemID.BigMimicHallowBanner, ItemID.IlluminantBatBanner, ItemID.LightMummyBanner, ItemID.PixieBanner, ItemID.UnicornBanner] },
                { "BANNERS_JUNGLE", [ItemID.DoctorBonesBanner, ItemID.HornetBanner, ItemID.JungleBatBanner, ItemID.LacBeetleBanner, ItemID.ManEaterBanner, ItemID.SnatcherBanner, ItemID.PiranhaBanner, ItemID.AngryTrapperBanner, ItemID.DerplingBanner, ItemID.GiantFlyingFoxBanner, ItemID.TortoiseBanner, ItemID.JungleCreeperBanner, ItemID.MossHornetBanner, ItemID.MothBanner, ItemID.ArapaimaBanner, ItemID.FlyingSnakeBanner, ItemID.LihzahrdBanner] },
                { "BANNERS_MARBLE_CAVE", [ItemID.GreekSkeletonBanner, ItemID.MedusaBanner] },
                { "BANNERS_METEORITE", [ItemID.MeteorHeadBanner] },
                { "BANNERS_SNOW", [ItemID.CyanBeetleBanner, ItemID.IceBatBanner, ItemID.PenguinBanner, ItemID.SnowFlinxBanner, ItemID.UndeadVikingBanner, ItemID.ZombieEskimoBanner, ItemID.ArmoredVikingBanner, ItemID.IceElementalBanner, ItemID.IceTortoiseBanner, ItemID.IcyMermanBanner, ItemID.PigronBanner, ItemID.WolfBanner] },
                { "BANNERS_SPIDER_CAVE", [ItemID.SpiderBanner, ItemID.BlackRecluseBanner] },
                { "BANNERS_SURFACE", [ItemID.BirdBanner, ItemID.BunnyBanner, ItemID.GoldfishBanner, ItemID.ZombieBanner, ItemID.DemonEyeBanner, ItemID.GoblinScoutBanner, ItemID.HarpyBanner, ItemID.CrabBanner, ItemID.PinkJellyfishBanner, ItemID.SeaSnailBanner, ItemID.SharkBanner, ItemID.SquidBanner, ItemID.PossessedArmorBanner, ItemID.WanderingEyeBanner, ItemID.WraithBanner, ItemID.WerewolfBanner, ItemID.WyvernBanner] },
                { "BANNERS_UNDERWORLD", [ItemID.BoneSerpentBanner, ItemID.DemonBanner, ItemID.FireImpBanner, ItemID.HellbatBanner, ItemID.LavaBatBanner, ItemID.RedDevilBanner] },

                // Events
                { "BANNERS_BLOOD_MOON", [ItemID.BloodZombieBanner, ItemID.CorruptBunnyBanner, ItemID.CorruptGoldfishBanner, ItemID.CorruptPenguinBanner, ItemID.DripplerBanner, ItemID.TheGroomBanner, ItemID.TheBrideBanner, ItemID.CrimsonBunnyBanner, ItemID.CrimsonGoldfishBanner, ItemID.CrimsonPenguinBanner, ItemID.EyeballFlyingFishBanner, ItemID.ZombieMermanBanner, ItemID.ClownBanner, ItemID.BloodEelBanner, ItemID.BloodSquidBanner, ItemID.GoblinSharkBanner, ItemID.BloodNautilusBanner] },
                { "BANNERS_FROST_LEGION", [ItemID.MisterStabbyBanner, ItemID.SnowBallaBanner, ItemID.SnowmanGangstaBanner] },
                { "BANNERS_FROST_MOON", [ItemID.ElfArcherBanner, ItemID.ElfCopterBanner, ItemID.FlockoBanner, ItemID.GingerbreadManBanner, ItemID.KrampusBanner, ItemID.NutcrackerBanner, ItemID.PresentMimicBanner, ItemID.YetiBanner, ItemID.ZombieElfBanner] },
                { "BANNERS_GOBLIN_ARMY", [ItemID.GoblinArcherBanner, ItemID.GoblinPeonBanner, ItemID.GoblinSorcererBanner, ItemID.GoblinThiefBanner, ItemID.GoblinWarriorBanner, ItemID.GoblinSummonerBanner] },
                { "BANNERS_HALLOWEEN", [ItemID.RavenBanner, ItemID.GhostBanner, ItemID.HoppinJackBanner] },
                { "BANNERS_LUNAR_EVENTS", [ItemID.BlueCultistArcherBanner, ItemID.BlueCultistCasterBanner, ItemID.VortexHornetBanner, ItemID.VortexLarvaBanner, ItemID.VortexHornetQueenBanner, ItemID.VortexRiflemanBanner, ItemID.VortexSoldierBanner, ItemID.NebulaHeadcrabBanner, ItemID.NebulaBeastBanner, ItemID.NebulaBrainBanner, ItemID.NebulaSoldierBanner, ItemID.StardustJellyfishBanner, ItemID.StardustWormBanner, ItemID.StardustSmallCellBanner, ItemID.StardustLargeCellBanner, ItemID.StardustSoldierBanner, ItemID.StardustSpiderBanner, ItemID.SolarCoriteBanner, ItemID.SolarCrawltipedeBanner, ItemID.SolarDrakomireBanner, ItemID.SolarDrakomireRiderBanner, ItemID.SolarSolenianBanner, ItemID.SolarSrollerBanner] },
                { "BANNERS_MARTIAN_MADNESS", [ItemID.MartianBrainscramblerBanner, ItemID.MartianDroneBanner, ItemID.MartianEngineerBanner, ItemID.MartianGigazapperBanner, ItemID.MartianGreyGruntBanner, ItemID.MartianOfficerBanner, ItemID.MartianRaygunnerBanner, ItemID.MartianScutlixGunnerBanner, ItemID.MartianTeslaTurretBanner, ItemID.MartianWalkerBanner, ItemID.ScutlixBanner] },
                { "BANNERS_OLD_ONES_ARMY", [ItemID.DD2JavelinThrowerBanner, ItemID.DD2GoblinBanner, ItemID.DD2GoblinBomberBanner, ItemID.DD2WyvernBanner, ItemID.DD2SkeletonBanner, ItemID.DD2DrakinBanner, ItemID.DD2LightningBugBanner, ItemID.DD2KoboldBanner, ItemID.DD2KoboldFlyerBanner, ItemID.DD2WitherBeastBanner] },
                { "BANNERS_PIRATE_INVASION", [ItemID.ParrotBanner, ItemID.PirateCaptainBanner, ItemID.PirateCorsairBanner, ItemID.PirateCrossbowerBanner, ItemID.PirateDeadeyeBanner, ItemID.PirateBanner] },
                { "BANNERS_PUMPKIN_MOON", [ItemID.HeadlessHorsemanBanner, ItemID.HellhoundBanner, ItemID.PoltergeistBanner, ItemID.ScarecrowBanner, ItemID.SplinterlingBanner] },
                { "BANNERS_RAIN_BLIZZARD", [ItemID.FlyingFishBanner, ItemID.RaincoatZombieBanner, ItemID.AngryNimbusBanner, ItemID.IceGolemBanner] },
                { "BANNERS_SANDSTORM", [ItemID.TumbleweedBanner, ItemID.SandElementalBanner, ItemID.SandsharkBanner, ItemID.SandsharkHallowedBanner, ItemID.SandsharkCorruptBanner, ItemID.SandsharkCrimsonBanner] },
                { "BANNERS_SOLAR_ECLIPSE", [ItemID.ButcherBanner, ItemID.CreatureFromTheDeepBanner, ItemID.DeadlySphereBanner, ItemID.DrManFlyBanner, ItemID.EyezorBanner, ItemID.FrankensteinBanner, ItemID.FritzBanner, ItemID.MothronBanner, ItemID.NailheadBanner, ItemID.PsychoBanner, ItemID.ReaperBanner, ItemID.SwampThingBanner, ItemID.ThePossessedBanner, ItemID.VampireBanner] },
                { "BANNERS_WINDY_DAY", [ItemID.DandelionBanner] }
            };

            foreach (var group in Banners)
                RegisterAchievement(group.Key, NpcDropCondition.DropAll(reqs, NPCID.None, group.Value), group.Value.Length > 1, AchievementCategory.Collector);
        }

        private void RegisterMountAchievements(ConditionReqs reqs)
        {
            int[] Mounts = [ItemID.SlimySaddle, ItemID.HoneyedGoggles, ItemID.HardySaddle, ItemID.FuzzyCarrot, ItemID.PogoStick, ItemID.GolfCart, ItemID.MolluskWhistle, ItemID.PaintedHorseSaddle, ItemID.MajesticHorseSaddle, ItemID.DarkHorseSaddle, ItemID.SuperheatedBlood, ItemID.AncientHorn, ItemID.BlessedApple, ItemID.ScalyTruffle, ItemID.QueenSlimeMountSaddle, ItemID.ReindeerBells, ItemID.BrainScrambler, ItemID.CosmicCarKey, ItemID.DrillContainmentUnit];

            RegisterAchievement("MOUNT_TURTLE", ItemOpenCondition.Open(reqs, ItemID.None, ItemID.HardySaddle), AchievementCategory.Collector);
            RegisterAchievement("MOUNT_GOLF", NpcBuyCondition.Buy(reqs, NPCID.Golfer, ItemID.GolfCart), AchievementCategory.Collector);
            RegisterAchievement("MOUNT_SHARK", ItemOpenCondition.Open(reqs, ItemID.None, ItemID.SuperheatedBlood), AchievementCategory.Collector);
            RegisterAchievement("MOUNT_BASILISK", NpcDropCondition.Drop(reqs, NPCID.DesertBeast, ItemID.AncientHorn), AchievementCategory.Collector);
            RegisterAchievement("MOUNT_UNICORN", NpcDropCondition.Drop(reqs, NPCID.None, ItemID.BlessedApple), AchievementCategory.Collector);
            RegisterAchievement("MOUNT_PIGRON", FishCatchCondition.Catch(reqs, ItemID.ScalyTruffle), AchievementCategory.Collector);
            RegisterAchievement("MOUNT_SCUTLIX", NpcDropCondition.Drop(reqs, NPCID.ScutlixRider, ItemID.BrainScrambler), AchievementCategory.Collector);
            RegisterAchievement("MOUNT_DCU", ItemCraftCondition.Craft(reqs, ItemID.DrillContainmentUnit), AchievementCategory.Collector);

            RegisterAchievement("MOUNTS", ItemGrabCondition.GrabAll(reqs, Mounts), true, AchievementCategory.Collector);
        }

        private void RegisterPaintingAchievements(ConditionReqs reqs)
        {
            Dictionary<string, int[]> PaintingsBuy = new()
            {
                { "PAINTINGS_CLOTHIER", [ItemID.PlacePainting] },
                { "PAINTINGS_GOLFER", [ItemID.GolfPainting1, ItemID.GolfPainting2, ItemID.GolfPainting3, ItemID.GolfPainting4] },
                { "PAINTINGS_PAINTER", [ItemID.ColdWatersintheWhiteLand, ItemID.Daylight, ItemID.DeadlandComesAlive, ItemID.DoNotStepontheGrass, ItemID.EvilPresence, ItemID.FirstEncounter, ItemID.GoodMorning, ItemID.TheLandofDeceivingLooks, ItemID.LightlessChasms, ItemID.PlaceAbovetheClouds, ItemID.SecretoftheSands, ItemID.SkyGuardian, ItemID.ThroughtheWindow, ItemID.UndergroundReward, ItemID.Purity, ItemID.Thunderbolt] },
                { "PAINTINGS_PAINTER_GRAVEYARD", [ItemID.Nevermore, ItemID.Reborn, ItemID.Graveyard, ItemID.GhostManifestation, ItemID.WickedUndead, ItemID.HailtotheKing, ItemID.BloodyGoblet, ItemID.StillLife] },
                { "PAINTINGS_PRINCESS", [ItemID.Princess64, ItemID.PaintingOfALass, ItemID.DarkSideHallow, ItemID.PrincessStyle, ItemID.SuspiciouslySparkly, ItemID.TerraBladeChronicles, ItemID.RoyalRomance] },
                { "PAINTINGS_TRAVELING_MERCHANT", [ItemID.PaintingAcorns, ItemID.PaintingCastleMarsberg, ItemID.PaintingColdSnap, ItemID.PaintingCursedSaint, ItemID.PaintingMartiaLisa, ItemID.MoonLordPainting, ItemID.PaintingWendy, ItemID.PaintingWillow, ItemID.PaintingWilson, ItemID.PaintingWolfgang, ItemID.PaintingTheSeason, ItemID.PaintingSnowfellas, ItemID.PaintingTheTruthIsUpThere, ItemID.HoplitePizza, ItemID.YuumaTheBlueTiger, ItemID.MoonmanandCompany, ItemID.SunshineofIsrapony, ItemID.BennyWarhol, ItemID.DoNotEattheVileMushroom, ItemID.Duality, ItemID.KargohsSummon, ItemID.ParsecPals] },
                { "PAINTINGS_TRUFFLE", [ItemID.MySon] },
                { "PAINTINGS_ZOOLOGIST", [ItemID.TheWerewolf] }
            };
            Dictionary<string, int[]> PaintingsArea = new()
            {
                { "PAINTINGS_DUNGEON", [ItemID.BloodMoonRising, ItemID.BoneWarp, ItemID.TheCreationoftheGuide, ItemID.TheCursedMan, ItemID.TheDestroyer, ItemID.Dryadisque, ItemID.TheEyeSeestheEnd, ItemID.FacingtheCerebralMastermind, ItemID.GloryoftheFire, ItemID.GoblinsPlayingPoker, ItemID.GreatWave, ItemID.TheGuardiansGaze, ItemID.TheHangedMan, ItemID.Impact, ItemID.ThePersistencyofEyes, ItemID.PoweredbyBirds, ItemID.TheScreamer, ItemID.SkellingtonJSkellingsworth, ItemID.SparkyPainting, ItemID.SomethingEvilisWatchingYou, ItemID.StarryNight, ItemID.TrioSuperHeroes, ItemID.TheTwinsHaveAwoken, ItemID.UnicornCrossingtheHallows, ItemID.RemnantsofDevotion] },
                { "PAINTINGS_FLOATING_ISLAND", [ItemID.HighPitch, ItemID.Constellation, ItemID.LoveisintheTrashSlot, ItemID.SunOrnament, ItemID.BlessingfromTheHeavens, ItemID.SeeTheWorldForWhatItIs] },
                { "PAINTINGS_JUNGLE_TEMPLE", [ItemID.LizardKing] },
                { "PAINTINGS_UNDERGROUND_CABINS", [ItemID.AmericanExplosive, ItemID.AuroraBorealis, ItemID.Bifrost, ItemID.Bioluminescence, ItemID.CatSword, ItemID.CrownoDevoursHisLunch, ItemID.Discover, ItemID.FairyGuides, ItemID.FatherofSomeone, ItemID.FindingGold, ItemID.ForestTroll, ItemID.GloriousNight, ItemID.GuidePicasso, ItemID.HappyLittleTree, ItemID.Heartlands, ItemID.AHorribleNightforAlchemy, ItemID.Land, ItemID.TheMerchant, ItemID.MorningHunt, ItemID.NurseLisa, ItemID.OldMiner, ItemID.Outcast, ItemID.RareEnchantment, ItemID.Secrets, ItemID.StrangeDeadFellows, ItemID.StrangeGrowth, ItemID.SufficientlyAdvanced, ItemID.Sunflowers, ItemID.TerrarianGothic, ItemID.VikingVoyage, ItemID.Waldo, ItemID.Wildflowers] },
                { "PAINTINGS_UNDERGROUND_CABINS_DESERT", [ItemID.AndrewSphinx, ItemID.WatchfulAntlion, ItemID.BurningSpirit, ItemID.JawsOfDeath, ItemID.TheSandsOfSlime, ItemID.SnakesIHateSnakes, ItemID.LifeAboveTheSand, ItemID.Oasis, ItemID.PrehistoryPreserved, ItemID.AncientTablet, ItemID.Uluru, ItemID.VisitingThePyramids, ItemID.BandageBoy, ItemID.DivineEye] },
                { "PAINTINGS_UNDERWORLD", [ItemID.DarkSoulReaper, ItemID.Darkness, ItemID.DemonsEye, ItemID.FlowingMagma, ItemID.HandEarth, ItemID.ImpFace, ItemID.LakeofFire, ItemID.LivingGore, ItemID.OminousPresence, ItemID.ShiningMoon, ItemID.Skelehead, ItemID.TrappedGhost] }
            };
            int[] PaintingsFishing = [ItemID.DreadoftheRedSea, ItemID.LadyOfTheLake];
            int[] PaintingsAnglerRewards = [ItemID.PillaginMePixels, ItemID.CouchGag, ItemID.Crustography, ItemID.Fangs, ItemID.NotSoLostInParadise, ItemID.SilentFish, ItemID.TheDuke, ItemID.WhatLurksBelow];
            int[] PaintingsGoodieBags = [ItemID.BitterHarvest, ItemID.BloodMoonCountess, ItemID.HallowsEve, ItemID.JackingSkeletron, ItemID.MorbidCuriosity];
            int[] PaintingsSolarEclipse = [ItemID.Requiem, ItemID.OcularResonance, ItemID.AMachineforTerrarians, ItemID.WingsofEvil, ItemID.ThisIsGettingOutOfHand, ItemID.Eyezorhead, ItemID.MidnightSun, ItemID.Buddies];

            RegisterAchievement("PAINTING_WALDO", TileDropCondition.Drop(reqs, ItemID.Waldo), AchievementCategory.Collector);

            foreach (var group in PaintingsBuy)
                RegisterAchievement(group.Key, NpcBuyCondition.BuyAll(reqs, NPCID.None, group.Value), group.Value.Length > 1, AchievementCategory.Collector);

            foreach (var group in PaintingsArea)
                RegisterAchievement(group.Key, ItemGrabCondition.GrabAll(reqs, group.Value), group.Value.Length > 1, AchievementCategory.Collector);

            RegisterAchievement("PAINTINGS_FISHING", FishCatchCondition.CatchAll(reqs, PaintingsFishing), true, AchievementCategory.Collector);
            RegisterAchievement("PAINTINGS_ANGLER_REWARD", ItemGiftCondition.GiftAll(reqs, NPCID.Angler, PaintingsAnglerRewards), true, AchievementCategory.Collector);
            RegisterAchievement("PAINTINGS_GOODIE_BAG", ItemOpenCondition.OpenAll(reqs, ItemID.GoodieBag, PaintingsGoodieBags), true, AchievementCategory.Collector);
            RegisterAchievement("PAINTINGS_SOLAR_ECLIPSE", NpcDropCondition.DropAll(reqs, NPCID.None, PaintingsSolarEclipse), true, AchievementCategory.Collector);
        }

        private void RegisterPetAchievements(ConditionReqs reqs)
        {
            Dictionary<string, int[]> Pets = new()
            {
                { "PETS_NORMAL", [ItemID.AmberMosquito, ItemID.EatersBone, ItemID.BoneRattle, ItemID.BabyGrinchMischiefWhistle, ItemID.Nectar, ItemID.HellCake, ItemID.Fish, ItemID.BambooLeaf, ItemID.BoneKey, ItemID.ToySled, ItemID.StrangeGlowingMushroom, ItemID.FullMoonSqueakyToy, ItemID.BerniePetItem, ItemID.UnluckyYarn, ItemID.BlueEgg, ItemID.GlowTulip, ItemID.ChesterPetItem, ItemID.CompanionCube, ItemID.CursedSapling, ItemID.BallOfFuseWire, ItemID.CelestialWand, ItemID.EyeSpring, ItemID.ExoticEasternChewToy, ItemID.BedazzledNectar, ItemID.GlommerPetItem, ItemID.DD2PetDragon, ItemID.JunimoPetItem, ItemID.BirdieRattle, ItemID.LizardEgg, ItemID.TartarSauce, ItemID.ParrotCracker, ItemID.PigPetItem, ItemID.MudBud, ItemID.DD2PetGato, ItemID.DogWhistle, ItemID.Seedling, ItemID.SpiderEgg, ItemID.OrnateShadowKey, ItemID.SharkBait, ItemID.SpiffoPlush, ItemID.MagicalPumpkinSeed, ItemID.EucaluptusSap, ItemID.DirtiestBlock, ItemID.TikiTotem, ItemID.Seaweed, ItemID.LightningCarrot, ItemID.ZephyrFish] },
                { "PETS_LIGHT",  [ItemID.ShadowOrb, ItemID.CrimsonHeart, ItemID.MagicLantern, ItemID.FairyBell, ItemID.DD2OgrePetItem, ItemID.WispinaBottle] },
            };

            RegisterAchievement("PET_DINO", ItemExtractCondition.Extract(reqs, ItemID.AmberMosquito), AchievementCategory.Collector);
            RegisterAchievement("PET_SKELETRON", NpcDropCondition.Drop(reqs, NPCID.DungeonGuardian, ItemID.BoneKey), AchievementCategory.Collector);
            RegisterAchievement("PET_SNOWMAN", NpcDropCondition.Drop(reqs, NPCID.IceMimic, ItemID.ToySled), AchievementCategory.Collector);
            RegisterAchievement("PET_CAT", ItemOpenCondition.Open(reqs, ItemID.GoodieBag, ItemID.UnluckyYarn), AchievementCategory.Collector);
            RegisterAchievement("PET_CAVELING", TileDropCondition.Drop(reqs, ItemID.GlowTulip), AchievementCategory.Collector);
            RegisterAchievement("PET_GLOMMER", NpcDropCondition.Drop(reqs, NPCID.Derpling, ItemID.GlommerPetItem), AchievementCategory.Collector);
            RegisterAchievement("PET_JUNIMO", ItemGiftCondition.Gift(reqs, NPCID.None, ItemID.JunimoPetItem), AchievementCategory.Collector);
            RegisterAchievement("PET_LIZARD", NpcDropCondition.Drop(reqs, NPCID.None, ItemID.LizardEgg), AchievementCategory.Collector);
            RegisterAchievement("PET_PIG", NpcDropCondition.Drop(reqs, NPCID.None, ItemID.PigPetItem), AchievementCategory.Collector);
            RegisterAchievement("PET_PUPPY", ItemOpenCondition.Open(reqs, ItemID.Present, ItemID.DogWhistle), AchievementCategory.Collector);
            RegisterAchievement("PET_SPIFFO", NpcDropCondition.Drop(reqs, NPCID.None, ItemID.SpiffoPlush), AchievementCategory.Collector);
            RegisterAchievement("PET_SQUASHLING", TileDropCondition.Drop(reqs, ItemID.MagicalPumpkinSeed), AchievementCategory.Collector);
            RegisterAchievement("PET_GLIDER", ItemShakeCondition.Shake(reqs, ItemID.EucaluptusSap), AchievementCategory.Collector);
            RegisterAchievement("PET_DIRT", TileDropCondition.Drop(reqs, ItemID.DirtiestBlock), AchievementCategory.Collector);
            RegisterAchievement("PET_ZEPHYR", FishCatchCondition.Catch(reqs, ItemID.ZephyrFish), AchievementCategory.Collector);
            RegisterAchievement("PET_WISP", NpcDropCondition.Drop(reqs, NPCID.None, ItemID.WispinaBottle), AchievementCategory.Collector);

            foreach (var group in Pets)
                RegisterAchievement(group.Key, ItemGrabCondition.GrabAll(reqs, group.Value), group.Value.Length > 1, AchievementCategory.Collector);
        }

        private void RegisterWingsAchievements(ConditionReqs reqs)
        {
            int[] Wings = [ItemID.CreativeWings, ItemID.AngelWings, ItemID.DemonWings, ItemID.LeafWings, ItemID.FairyWings, ItemID.FinWings, ItemID.FrozenWings, ItemID.HarpyWings, ItemID.Jetpack, ItemID.BatWings, ItemID.BeeWings, ItemID.ButterflyWings, ItemID.FlameWings, ItemID.Hoverboard, ItemID.BoneWings, ItemID.MothronWings, ItemID.GhostWings, ItemID.BeetleWings, ItemID.FestiveWings, ItemID.SpookyWings, ItemID.TatteredFairyWings, ItemID.SteampunkWings, ItemID.BetsyWings, ItemID.RainbowWings, ItemID.FishronWings, ItemID.WingsNebula, ItemID.WingsVortex, ItemID.WingsSolar, ItemID.WingsStardust];

            RegisterAchievement("WINGS", ItemGrabCondition.GrabAll(reqs, Wings), true, AchievementCategory.Collector);
        }

        private void RegisterExtractAchievements(ConditionReqs reqs)
        {
            Dictionary<string, int[]> Extract = new()
            {
                { "EXTRACT_SILT_SLUSH", [ItemID.PlatinumCoin, ItemID.GoldCoin, ItemID.SilverCoin, ItemID.CopperCoin, ItemID.AmberMosquito, ItemID.Amethyst, ItemID.Topaz, ItemID.Sapphire, ItemID.Emerald, ItemID.Ruby, ItemID.Diamond, ItemID.Amber, ItemID.CopperOre, ItemID.TinOre, ItemID.IronOre, ItemID.LeadOre, ItemID.SilverOre, ItemID.TungstenOre, ItemID.GoldOre, ItemID.PlatinumOre, ItemID.CobaltOre, ItemID.PalladiumOre, ItemID.MythrilOre, ItemID.OrichalcumOre, ItemID.AdamantiteOre, ItemID.TitaniumOre] },
                { "EXTRACT_FOSSIL", [ItemID.FossilOre, ItemID.PlatinumCoin, ItemID.GoldCoin, ItemID.SilverCoin, ItemID.CopperCoin, ItemID.AmberMosquito, ItemID.Amethyst, ItemID.Topaz, ItemID.Sapphire, ItemID.Emerald, ItemID.Ruby, ItemID.Diamond, ItemID.Amber, ItemID.CopperOre, ItemID.TinOre, ItemID.IronOre, ItemID.LeadOre, ItemID.SilverOre, ItemID.TungstenOre, ItemID.GoldOre, ItemID.PlatinumOre, ItemID.CobaltOre, ItemID.PalladiumOre, ItemID.MythrilOre, ItemID.OrichalcumOre, ItemID.AdamantiteOre, ItemID.TitaniumOre] },
                { "EXTRACT_MOSS", [ItemID.GreenMoss, ItemID.BrownMoss, ItemID.RedMoss, ItemID.BlueMoss, ItemID.PurpleMoss, ItemID.LavaMoss, ItemID.KryptonMoss, ItemID.XenonMoss, ItemID.ArgonMoss, ItemID.VioletMoss] },
                { "EXTRACT_JUNK", [ItemID.Snail, ItemID.ApprenticeBait, ItemID.Worm, ItemID.JourneymanBait] }
            };

            foreach (var group in Extract)
                RegisterAchievement(group.Key, ItemExtractCondition.ExtractAll(reqs, group.Value), group.Value.Length > 1, AchievementCategory.Collector);
        }

        private void RegisterFishAchievements(ConditionReqs reqs)
        {
            Dictionary<string, int[]> FishCatch = new()
            {
                { "FISH_CATCH_FISH", [ItemID.ArmoredCavefish, ItemID.AtlanticCod, ItemID.Bass, ItemID.BlueJellyfish, ItemID.ChaosFish, ItemID.CrimsonTigerfish, ItemID.Damselfish, ItemID.DoubleCod, ItemID.Ebonkoi, ItemID.FlarefinKoi, ItemID.Flounder, ItemID.FrostMinnow, ItemID.GoldenCarp, ItemID.GreenJellyfish, ItemID.Hemopiranha, ItemID.Honeyfin, ItemID.NeonTetra, ItemID.Obsidifish, ItemID.PinkJellyfish, ItemID.PrincessFish, ItemID.Prismite, ItemID.RedSnapper, ItemID.RockLobster, ItemID.Salmon, ItemID.Shrimp, ItemID.SpecularFish, ItemID.Stinkfish, ItemID.Trout, ItemID.Tuna, ItemID.VariegatedLardfish] },
                { "FISH_CATCH_FISH_QUEST", [ItemID.AmanitaFungifin, ItemID.Angelfish, ItemID.Batfish, ItemID.BloodyManowar, ItemID.Bonefish, ItemID.BumblebeeTuna, ItemID.Bunnyfish, ItemID.CapnTunabeard, ItemID.Catfish, ItemID.Cloudfish, ItemID.Clownfish, ItemID.Cursedfish, ItemID.DemonicHellfish, ItemID.Derpfish, ItemID.Dirtfish, ItemID.DynamiteFish, ItemID.EaterofPlankton, ItemID.FallenStarfish, ItemID.TheFishofCthulu, ItemID.Fishotron, ItemID.Fishron, ItemID.GuideVoodooFish, ItemID.Harpyfish, ItemID.Hungerfish, ItemID.Ichorfish, ItemID.InfectedScabbardfish, ItemID.Jewelfish, ItemID.MirageFish, ItemID.Mudfish, ItemID.MutantFlinxfin, ItemID.Pengfish, ItemID.Pixiefish, ItemID.ScarabFish, ItemID.ScorpioFish, ItemID.Slimefish, ItemID.Spiderfish, ItemID.TropicalBarracuda, ItemID.TundraTrout, ItemID.UnicornFish, ItemID.Wyverntail, ItemID.ZombieFish] },
                { "FISH_CATCH_CRATE", [ItemID.WoodenCrate, ItemID.WoodenCrateHard, ItemID.IronCrate, ItemID.IronCrateHard, ItemID.GoldenCrate, ItemID.GoldenCrateHard, ItemID.JungleFishingCrate, ItemID.JungleFishingCrateHard, ItemID.FloatingIslandFishingCrate, ItemID.FloatingIslandFishingCrateHard, ItemID.CorruptFishingCrate, ItemID.CorruptFishingCrateHard, ItemID.CrimsonFishingCrate, ItemID.CrimsonFishingCrateHard, ItemID.HallowedFishingCrate, ItemID.HallowedFishingCrateHard, ItemID.DungeonFishingCrate, ItemID.DungeonFishingCrateHard, ItemID.FrozenCrate, ItemID.FrozenCrateHard, ItemID.OasisCrate, ItemID.OasisCrateHard, ItemID.LavaCrate, ItemID.LavaCrateHard, ItemID.OceanCrate, ItemID.OceanCrateHard] },
                { "FISH_CATCH_ITEM", [ItemID.FrogLeg, ItemID.BalloonPufferfish, ItemID.BombFish, ItemID.PurpleClubberfish, ItemID.ReaverShark, ItemID.Rockfish, ItemID.SawtoothShark, ItemID.FrostDaggerfish, ItemID.Swordfish, ItemID.ZephyrFish, ItemID.Honeyfin, ItemID.Toxikarp, ItemID.Bladetongue, ItemID.CrystalSerpent, ItemID.ScalyTruffle, ItemID.ObsidianSwordfish, ItemID.AlchemyTable, ItemID.Oyster, ItemID.CombatBook, ItemID.BottomlessLavaBucket, ItemID.LavaAbsorbantSponge, ItemID.DemonConch] },
                { "FISH_CATCH_JUNK", [ItemID.OldShoe, ItemID.FishingSeaweed, ItemID.TinCan, ItemID.JojaCola] }
            };
            int[] FishRewards = [ItemID.FuzzyCarrot, ItemID.AnglerHat, ItemID.AnglerVest, ItemID.AnglerPants, ItemID.GoldenFishingRod, ItemID.LavaFishingHook, ItemID.FinWings, ItemID.BottomlessBucket, ItemID.SuperAbsorbantSponge, ItemID.GoldenBugNet, ItemID.FishHook, ItemID.FishMinecart, ItemID.HighTestFishingLine, ItemID.AnglerEarring, ItemID.TackleBox, ItemID.FishingBobber, ItemID.FishermansGuide, ItemID.WeatherRadio, ItemID.Sextant, ItemID.SeashellHairpin, ItemID.MermaidAdornment, ItemID.MermaidTail, ItemID.FishCostumeMask, ItemID.FishCostumeShirt, ItemID.FishCostumeFinskirt, ItemID.BottomlessHoneyBucket, ItemID.HoneyAbsorbantSponge, ItemID.LifePreserver, ItemID.ShipsWheel, ItemID.CompassRose, ItemID.WallAnchor, ItemID.PillaginMePixels, ItemID.TreasureMap, ItemID.GoldfishTrophy, ItemID.BunnyfishTrophy, ItemID.SwordfishTrophy, ItemID.SharkteethTrophy, ItemID.ShipInABottle, ItemID.SeaweedPlanter, ItemID.CoralstoneBlock, ItemID.FishingPotion, ItemID.SonarPotion, ItemID.CratePotion, ItemID.MasterBait, ItemID.JourneymanBait, ItemID.ApprenticeBait];

            foreach (var group in FishCatch)
                RegisterAchievement(group.Key, FishCatchCondition.CatchAll(reqs, group.Value), group.Value.Length > 1, AchievementCategory.Collector);

            RegisterAchievement("FISH_REWARDS", ItemGiftCondition.GiftAll(reqs, NPCID.Angler, FishRewards), true, AchievementCategory.Collector);
        }
    }
}
