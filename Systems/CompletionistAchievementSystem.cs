using System.Collections.Generic;
using Terraria.Achievements;
using Terraria.ID;
using TerrariaAchievementLib.Achievements;
using TerrariaAchievementLib.Achievements.Conditions;
using TerrariaAchievementLib.Systems;

namespace CompletionistAchievements.Systems
{
    /// <summary>
    /// Adds achievements for completion to the in-game list
    /// </summary>
    public class CompletionistAchievementSystem : AchievementSystem
    {
        protected override string Identifier { get => "COMPLETIONIST"; }

        protected override List<string> TexturePaths { get => ["CompletionistAchievements/Assets/Achievements-1", "CompletionistAchievements/Assets/Achievements-2", "CompletionistAchievements/Assets/Achievements-3"]; }


        protected override void RegisterAchievements()
        {
            ConditionReqs reqs = new(PlayerDiff.Classic, WorldDiff.Classic, SpecialSeed.None);

            RegisterWeaponAchievements(reqs);
            RegisterAmmoAchievements(reqs);
            RegisterToolAchievements(reqs);
            RegisterArmorAchievements(reqs);
            RegisterAccessoryAchievements(reqs);
            RegisterMountAchievements(reqs);
            RegisterMinecartAchievements(reqs);
            RegisterVanityAchievements(reqs);
            RegisterPetAchievements(reqs);

            RegisterBannerAchievements(reqs);
            RegisterCritterAchievements(reqs);
            RegisterDyeAchievements(reqs);
            RegisterExtractinatorAchievements(reqs);
            RegisterFishAchievements(reqs);
            RegisterFurnitureAchievements(reqs);
            RegisterNoveltyAchievements(reqs);
            RegisterPaintingAchievements(reqs);
            RegisterPylonAchievements(reqs);
            RegisterStatueAchievements(reqs);
            RegisterStorageAchievements(reqs);
            RegisterTrophyAchievements(reqs);

            RegisterBuffAchievements(reqs);
            RegisterConsumableAchievements(reqs);
        }

        /// <summary>
        /// Returns conditions to break a tile and grab the item<br/>
        /// Requires the player to actually find rare items from tiles
        /// </summary>
        /// <param name="reqs">Common condition requirements</param>
        /// <param name="itemId">Item ID to grab</param>
        /// <returns>Conditions to break a tile and grab the item</returns>
        private static List<CustomAchievementCondition> BreakAndGrabItem(ConditionReqs reqs, int itemId)
        {
            List<CustomAchievementCondition> conds = [];
            conds.Add(TileDropCondition.Drop(reqs, itemId));
            conds.Add(ItemGrabCondition.Grab(reqs, itemId));
            return conds;
        }

        /// <summary>
        /// Register weapon achievements
        /// </summary>
        /// <param name="reqs">Common achievement requirements</param>
        private void RegisterWeaponAchievements(ConditionReqs reqs)
        {
            RegisterMeleeWeaponAchievements(reqs);
            RegisterRangedWeaponAchievements(reqs);
            RegisterMagicWeaponAchievements(reqs);
            RegisterSummonWeaponAchievements(reqs);
            RegisterPlaceableWeaponAchievements(reqs);
        }

        /// <summary>
        /// Register melee weapon achievements
        /// </summary>
        /// <param name="reqs">Common achievement requirements</param>
        private void RegisterMeleeWeaponAchievements(ConditionReqs reqs)
        {
            // Verified w/ https://terraria.wiki.gg/wiki/Weapons
            Dictionary<string, int[]> MeleeWeapons = new()
            {
                { "WEAPON_MELEE_SWORD", [ItemID.CopperShortsword, ItemID.TinShortsword, ItemID.WoodenSword, ItemID.BorealWoodSword, ItemID.CopperBroadsword, ItemID.IronShortsword, ItemID.PalmWoodSword, ItemID.RichMahoganySword, ItemID.CactusSword, ItemID.LeadShortsword, ItemID.SilverShortsword, ItemID.TinBroadsword, ItemID.EbonwoodSword, ItemID.IronBroadsword, ItemID.ShadewoodSword, ItemID.TungstenShortsword, ItemID.GoldShortsword, ItemID.LeadBroadsword, ItemID.SilverBroadsword, ItemID.BladedGlove, ItemID.TungstenBroadsword, ItemID.ZombieArm, ItemID.AshWoodSword, ItemID.GoldBroadsword, ItemID.Flymeal, ItemID.PlatinumShortsword, ItemID.AntlionClaw, ItemID.StylistKilLaKillScissorsIWish, ItemID.Ruler, ItemID.PlatinumBroadsword, ItemID.Umbrella, ItemID.BreathingReed, ItemID.Gladius, ItemID.BoneSword, ItemID.BatBat, ItemID.TentacleSpike, ItemID.CandyCaneSword, ItemID.Katana, ItemID.IceBlade, ItemID.LightsBane, ItemID.TragicUmbrella, ItemID.Muramasa, ItemID.DyeTradersScimitar, ItemID.BluePhaseblade, ItemID.GreenPhaseblade, ItemID.OrangePhaseblade, ItemID.PurplePhaseblade, ItemID.RedPhaseblade, ItemID.WhitePhaseblade, ItemID.YellowPhaseblade, ItemID.BloodButcherer, ItemID.Starfury, ItemID.EnchantedSword, ItemID.PurpleClubberfish, ItemID.BeeKeeper, ItemID.FalconBlade, ItemID.BladeofGrass, ItemID.FieryGreatsword, ItemID.NightsEdge, ItemID.PearlwoodSword, ItemID.TaxCollectorsStickOfDoom, ItemID.SlapHand, ItemID.CobaltSword, ItemID.PalladiumSword, ItemID.BluePhasesaber, ItemID.GreenPhasesaber, ItemID.OrangePhasesaber, ItemID.PurplePhasesaber, ItemID.RedPhasesaber, ItemID.WhitePhasesaber, ItemID.YellowPhasesaber, ItemID.IceSickle, ItemID.DD2SquireDemonSword, ItemID.MythrilSword, ItemID.OrichalcumSword, ItemID.BreakerBlade, ItemID.Cutlass, ItemID.Frostbrand, ItemID.AdamantiteSword, ItemID.BeamSword, ItemID.TitaniumSword, ItemID.FetidBaghnakhs, ItemID.Bladetongue, ItemID.HamBat, ItemID.Excalibur, ItemID.TrueExcalibur, ItemID.ChlorophyteSaber, ItemID.DeathSickle, ItemID.PsychoKnife, ItemID.Keybrand, ItemID.ChlorophyteClaymore, ItemID.TheHorsemansBlade, ItemID.ChristmasTreeSword, ItemID.TrueNightsEdge, ItemID.Seedler, ItemID.DD2SquireBetsySword, ItemID.TerraBlade, ItemID.InfluxWaver, ItemID.StarWrath, ItemID.Meowmere] },
                { "WEAPON_MELEE_YOYO", [ItemID.WoodYoyo, ItemID.Rally, ItemID.CorruptYoyo, ItemID.CrimsonYoyo, ItemID.JungleYoyo, ItemID.Code1, ItemID.Valor, ItemID.Cascade, ItemID.HiveFive, ItemID.FormatC, ItemID.Gradient, ItemID.Chik, ItemID.HelFire, ItemID.Amarok, ItemID.Code2, ItemID.Yelets, ItemID.Kraken, ItemID.TheEyeOfCthulhu, ItemID.Terrarian] },
                { "WEAPON_MELEE_SPEAR", [ItemID.Spear, ItemID.Trident, ItemID.ThunderStaff, ItemID.TheRottedFork, ItemID.Swordfish, ItemID.DarkLance, ItemID.CobaltNaginata, ItemID.PalladiumPike, ItemID.MythrilHalberd, ItemID.OrichalcumHalberd, ItemID.AdamantiteGlaive, ItemID.TitaniumTrident, ItemID.Gungnir, ItemID.MonkStaffT2, ItemID.ChlorophytePartisan, ItemID.MushroomSpear, ItemID.ObsidianSwordfish, ItemID.NorthPole] },
                { "WEAPON_MELEE_BOOMERANG", [ItemID.WoodenBoomerang, ItemID.EnchantedBoomerang, ItemID.FruitcakeChakram, ItemID.BloodyMachete, ItemID.Shroomerang, ItemID.IceBoomerang, ItemID.ThornChakram, ItemID.CombatWrench, ItemID.Flamarang, ItemID.Trimarang, ItemID.FlyingKnife, ItemID.BouncingShield, ItemID.LightDisc, ItemID.Bananarang, ItemID.PossessedHatchet, ItemID.PaladinsHammer] },
                { "WEAPON_MELEE_FLAIL", [ItemID.Mace, ItemID.FlamingMace, ItemID.BallOHurt, ItemID.TheMeatball, ItemID.BlueMoon, ItemID.Sunfury, ItemID.ChainKnife, ItemID.DripplerFlail, ItemID.DaoofPow, ItemID.FlowerPow, ItemID.Anchor, ItemID.ChainGuillotines, ItemID.KOCannon, ItemID.GolemFist, ItemID.Flairon] },
                { "WEAPON_MELEE_OTHER", [ItemID.Terragrim, ItemID.JoustingLance, ItemID.ShadowFlameKnife, ItemID.HallowJoustingLance, ItemID.MonkStaffT1, ItemID.ScourgeoftheCorruptor, ItemID.VampireKnives, ItemID.ShadowJoustingLance, ItemID.PiercingStarlight, ItemID.MonkStaffT3, ItemID.DayBreak, ItemID.SolarEruption, ItemID.Zenith] }
            };

            // Verified w/ https://terraria.wiki.gg/wiki/Skeleton_Merchant
            int[] SkeletonMerchantYoyoStuff = [ItemID.BlueCounterweight, ItemID.RedCounterweight, ItemID.PurpleCounterweight, ItemID.GreenCounterweight, ItemID.Gradient, ItemID.FormatC, ItemID.YoYoGlove];

            // Rare Swords
            RegisterAchievement("WEAPON_BAT_BAT", NpcDropCondition.Drop(reqs, NPCID.None, ItemID.BatBat), AchievementCategory.Collector);
            RegisterAchievement("WEAPON_BEAM_SWORD", NpcDropCondition.Drop(reqs, NPCID.ArmoredSkeleton, ItemID.BeamSword), AchievementCategory.Collector);
            RegisterAchievement("WEAPON_BLADED_GLOVE", NpcDropCondition.Drop(reqs, NPCID.None, ItemID.BladedGlove), AchievementCategory.Collector);
            RegisterAchievement("WEAPON_BLADETONGUE", ItemCatchCondition.Catch(reqs, ItemID.Bladetongue), AchievementCategory.Collector);
            RegisterAchievement("WEAPON_BONE_SWORD", NpcDropCondition.Drop(reqs, NPCID.None, ItemID.BoneSword), AchievementCategory.Collector);
            RegisterAchievement("WEAPON_EXOTIC_SCIMITAR", ItemGrabCondition.Grab(reqs, ItemID.DyeTradersScimitar), AchievementCategory.Collector);
            RegisterAchievement("WEAPON_GLADIUS", NpcDropCondition.Drop(reqs, NPCID.GreekSkeleton, ItemID.Gladius), AchievementCategory.Collector);
            RegisterAchievement("WEAPON_MANDIBLE_BLADE", NpcDropCondition.Drop(reqs, NPCID.None, ItemID.AntlionClaw), AchievementCategory.Collector);
            RegisterAchievement("WEAPON_STYLISH_SCISSORS", ItemGrabCondition.Grab(reqs, ItemID.StylistKilLaKillScissorsIWish), AchievementCategory.Collector);
            RegisterAchievement("WEAPON_ZOMBIE_ARM", NpcDropCondition.Drop(reqs, NPCID.None, ItemID.ZombieArm), AchievementCategory.Collector);
            RegisterAchievement("WEAPON_CLASSY_CANE", ItemGrabCondition.Grab(reqs, ItemID.TaxCollectorsStickOfDoom), AchievementCategory.Collector);
            RegisterAchievement("WEAPON_ICE_SICKLE", NpcDropCondition.Drop(reqs, NPCID.None, ItemID.IceSickle), AchievementCategory.Collector);
            RegisterAchievement("WEAPON_KEYBRAND", NpcDropCondition.Drop(reqs, NPCID.None, ItemID.Keybrand), AchievementCategory.Collector);

            // Rare Yoyos
            RegisterAchievement("WEAPON_CASCADE", NpcDropCondition.Drop(reqs, NPCID.None, ItemID.Cascade), AchievementCategory.Collector);
            RegisterAchievement("WEAPON_AMAROK", NpcDropCondition.Drop(reqs, NPCID.None, ItemID.Amarok), AchievementCategory.Collector);
            RegisterAchievement("WEAPON_HELFIRE", NpcDropCondition.Drop(reqs, NPCID.None, ItemID.HelFire), AchievementCategory.Collector);
            RegisterAchievement("WEAPON_KRAKEN", NpcDropCondition.Drop(reqs, NPCID.None, ItemID.Kraken), AchievementCategory.Collector);
            RegisterAchievement("WEAPON_YELETS", NpcDropCondition.Drop(reqs, NPCID.None, ItemID.Yelets), AchievementCategory.Collector);
            RegisterAchievement("WEAPON_SKELETON_MERCHANT", NpcBuyCondition.BuyAll(reqs, NPCID.SkeletonMerchant, SkeletonMerchantYoyoStuff), true, AchievementCategory.Collector);

            // Rare Spears
            RegisterAchievement("WEAPON_OBSIDIAN_SWORDFISH", ItemCatchCondition.Catch(reqs, ItemID.ObsidianSwordfish), AchievementCategory.Collector);

            // Rare Boomerangs
            RegisterAchievement("WEAPON_BLOODY_MACHETE", NpcDropCondition.Drop(reqs, NPCID.None, ItemID.BloodyMachete), AchievementCategory.Collector);
            RegisterAchievement("WEAPON_COMBAT_WRENCH", ItemGrabCondition.Grab(reqs, ItemID.CombatWrench), AchievementCategory.Collector);
            RegisterAchievement("WEAPON_SHROOMERANG", NpcDropCondition.Drop(reqs, NPCID.SporeBat, ItemID.Shroomerang), AchievementCategory.Collector);
            RegisterAchievement("WEAPON_BANANARANG", NpcDropCondition.Drop(reqs, NPCID.Clown, ItemID.Bananarang), AchievementCategory.Collector);
            RegisterAchievement("WEAPON_PALADINS_HAMMER", NpcDropCondition.Drop(reqs, NPCID.Paladin, ItemID.PaladinsHammer), AchievementCategory.Collector);

            // Rare Flails
            RegisterAchievement("WEAPON_CHAIN_KNIFE", NpcDropCondition.Drop(reqs, NPCID.CaveBat, ItemID.ChainKnife), AchievementCategory.Collector);
            RegisterAchievement("WEAPON_DRIPPLER_CRIPPLER", NpcDropCondition.Drop(reqs, NPCID.None, ItemID.DripplerFlail), AchievementCategory.Collector);

            // Rare Other
            RegisterAchievement("WEAPON_TERRAGRIM", BreakAndGrabItem(reqs, ItemID.Terragrim), false, AchievementCategory.Collector);

            foreach (var group in MeleeWeapons)
                RegisterAchievement(group.Key, ItemGrabCondition.GrabAll(reqs, group.Value), group.Value.Length > 1, AchievementCategory.Collector);
        }

        /// <summary>
        /// Register ranged weapon achievements
        /// </summary>
        /// <param name="reqs">Common achievement requirements</param>
        private void RegisterRangedWeaponAchievements(ConditionReqs reqs)
        {
            // Verified w/ https://terraria.wiki.gg/wiki/Weapons
            Dictionary<string, int[]> RangedWeapons = new()
            {
                { "WEAPON_RANGED_BOW", [ItemID.WoodenBow, ItemID.BorealWoodBow, ItemID.CopperBow, ItemID.PalmWoodBow, ItemID.RichMahoganyBow, ItemID.TinBow, ItemID.EbonwoodBow, ItemID.IronBow, ItemID.ShadewoodBow, ItemID.LeadBow, ItemID.SilverBow, ItemID.TungstenBow, ItemID.AshWoodBow, ItemID.GoldBow, ItemID.PlatinumBow, ItemID.DemonBow, ItemID.TendonBow, ItemID.BloodRainBow, ItemID.BeesKnees, ItemID.HellwingBow, ItemID.MoltenFury, ItemID.PearlwoodBow, ItemID.Marrow, ItemID.IceBow, ItemID.DaedalusStormbow, ItemID.ShadowFlameBow, ItemID.DD2PhoenixBow, ItemID.PulseBow, ItemID.DD2BetsyBow, ItemID.Tsunami, ItemID.FairyQueenRangedItem, ItemID.Phantasm] },
                { "WEAPON_RANGED_REPEATER", [ItemID.CobaltRepeater, ItemID.PalladiumRepeater, ItemID.MythrilRepeater, ItemID.OrichalcumRepeater, ItemID.AdamantiteRepeater, ItemID.TitaniumRepeater, ItemID.HallowedRepeater, ItemID.ChlorophyteShotbow, ItemID.StakeLauncher] },
                { "WEAPON_RANGED_GUN", [ItemID.RedRyder, ItemID.FlintlockPistol, ItemID.Musket, ItemID.TheUndertaker, ItemID.Revolver, ItemID.Minishark, ItemID.Boomstick, ItemID.QuadBarrelShotgun, ItemID.Handgun, ItemID.PhoenixBlaster, ItemID.PewMaticHorn, ItemID.ClockworkAssaultRifle, ItemID.Gatligator, ItemID.Shotgun, ItemID.OnyxBlaster, ItemID.Uzi, ItemID.Megashark, ItemID.VenusMagnum, ItemID.TacticalShotgun, ItemID.SniperRifle, ItemID.CandyCornRifle, ItemID.ChainGun, ItemID.Xenopopper, ItemID.VortexBeater, ItemID.SDMG] },
                { "WEAPON_RANGED_LAUNCHER", [ItemID.GrenadeLauncher, ItemID.ProximityMineLauncher, ItemID.RocketLauncher, ItemID.NailGun, ItemID.Stynger, ItemID.JackOLanternLauncher, ItemID.SnowballCannon, ItemID.FireworksLauncher, ItemID.ElectrosphereLauncher, ItemID.Celeb2] },
                { "WEAPON_RANGED_OTHER", [ItemID.Blowpipe, ItemID.Sandgun, ItemID.Blowgun, ItemID.SnowballCannon, ItemID.PainterPaintballGun, ItemID.AleThrowingGlove, ItemID.Harpoon, ItemID.StarCannon, ItemID.Toxikarp, ItemID.DartPistol, ItemID.DartRifle, ItemID.CoinGun, ItemID.Flamethrower, ItemID.PiranhaGun, ItemID.ElfMelter, ItemID.SuperStarCannon] }
            };

            // Rare Bows
            RegisterAchievement("WEAPON_BLOOD_RAIN_BOW", NpcDropCondition.Drop(reqs, NPCID.None, ItemID.BloodRainBow), AchievementCategory.Collector);
            RegisterAchievement("WEAPON_MARROW", NpcDropCondition.Drop(reqs, NPCID.SkeletonArcher, ItemID.Marrow), AchievementCategory.Collector);

            // Rare Guns
            RegisterAchievement("WEAPON_RED_RYDER", ItemOpenCondition.Open(reqs, ItemID.Present, ItemID.RedRyder), AchievementCategory.Collector);
            RegisterAchievement("WEAPON_UZI", NpcDropCondition.Drop(reqs, NPCID.AngryTrapper, ItemID.Uzi), AchievementCategory.Collector);

            // Rare Other
            RegisterAchievement("WEAPON_ALE_TOSSER", ItemGrabCondition.Grab(reqs, ItemID.AleThrowingGlove), AchievementCategory.Collector);
            RegisterAchievement("WEAPON_PAINTBALL_GUN", ItemGrabCondition.Grab(reqs, ItemID.PainterPaintballGun), AchievementCategory.Collector);
            RegisterAchievement("WEAPON_COIN_GUN", NpcDropCondition.Drop(reqs, NPCID.None, ItemID.CoinGun), AchievementCategory.Collector);
            RegisterAchievement("WEAPON_TOXIKARP", ItemCatchCondition.Catch(reqs, ItemID.Toxikarp), AchievementCategory.Collector);

            foreach (var group in RangedWeapons)
                RegisterAchievement(group.Key, ItemGrabCondition.GrabAll(reqs, group.Value), group.Value.Length > 1, AchievementCategory.Collector);
        }

        /// <summary>
        /// Register magic weapon achievements
        /// </summary>
        /// <param name="reqs">Common achievement requirements</param>
        private void RegisterMagicWeaponAchievements(ConditionReqs reqs)
        {
            // Verified w/ https://terraria.wiki.gg/wiki/Weapons
            Dictionary<string, int[]> MagicWeapons = new()
            {
                { "WEAPON_MAGIC_WAND", [ItemID.WandofSparking, ItemID.WandofFrosting, ItemID.ThunderStaff, ItemID.AmethystStaff, ItemID.TopazStaff, ItemID.SapphireStaff, ItemID.EmeraldStaff, ItemID.RubyStaff, ItemID.DiamondStaff, ItemID.AmberStaff, ItemID.Vilethorn, ItemID.WeatherPain, ItemID.MagicMissile, ItemID.AquaScepter, ItemID.FlowerofFire, ItemID.Flamelash, ItemID.SkyFracture, ItemID.CrystalSerpent, ItemID.FlowerofFrost, ItemID.FrostStaff, ItemID.CrystalVileShard, ItemID.SoulDrain, ItemID.MeteorStaff, ItemID.PoisonStaff, ItemID.RainbowRod, ItemID.UnholyTrident, ItemID.BookStaff, ItemID.VenomStaff, ItemID.NettleBurst, ItemID.BatScepter, ItemID.BlizzardStaff, ItemID.InfernoFork, ItemID.ShadowbeamStaff, ItemID.SpectreStaff, ItemID.PrincessWeapon, ItemID.Razorpine, ItemID.StaffofEarth, ItemID.ApprenticeStaffT3] },
                { "WEAPON_MAGIC_GUN", [ItemID.ZapinatorGray, ItemID.SpaceGun, ItemID.BeeGun, ItemID.LaserRifle, ItemID.ZapinatorOrange, ItemID.WaspGun, ItemID.LeafBlower, ItemID.RainbowGun, ItemID.HeatRay, ItemID.LaserMachinegun, ItemID.ChargedBlasterCannon, ItemID.BubbleGun] },
                { "WEAPON_MAGIC_BOOK", [ItemID.WaterBolt, ItemID.BookofSkulls, ItemID.DemonScythe, ItemID.CursedFlames, ItemID.GoldenShower, ItemID.CrystalStorm, ItemID.MagnetSphere, ItemID.RazorbladeTyphoon, ItemID.LunarFlareBook] },
                { "WEAPON_MAGIC_OTHER", [ItemID.CrimsonRod, ItemID.IceRod, ItemID.ClingerStaff, ItemID.NimbusRod, ItemID.MagicDagger, ItemID.MedusaHead, ItemID.SpiritFlame, ItemID.ShadowFlameHexDoll, ItemID.SharpTears, ItemID.MagicalHarp, ItemID.ToxicFlask, ItemID.FairyQueenMagicItem, ItemID.SparkleGuitar, ItemID.NebulaArcanum, ItemID.NebulaBlaze, ItemID.LastPrism] }
            };

            // Rare Wands
            RegisterAchievement("WEAPON_CRYSTAL_SERPENT", ItemCatchCondition.Catch(reqs, ItemID.CrystalSerpent), AchievementCategory.Collector);
            RegisterAchievement("WEAPON_FROST_STAFF", NpcDropCondition.Drop(reqs, NPCID.None, ItemID.FrostStaff), AchievementCategory.Collector);
            RegisterAchievement("WEAPON_POISON_STAFF", NpcDropCondition.Drop(reqs, NPCID.BlackRecluse, ItemID.PoisonStaff), AchievementCategory.Collector);
            RegisterAchievement("WEAPON_RESONANCE_SCEPTER", ItemGrabCondition.Grab(reqs, ItemID.PrincessWeapon), AchievementCategory.Collector);
            RegisterAchievement("WEAPON_UNHOLY_TRIDENT", NpcDropCondition.Drop(reqs, NPCID.RedDevil, ItemID.UnholyTrident), AchievementCategory.Collector);

            // Rare Books
            RegisterAchievement("WEAPON_DEMON_SCYTHE", NpcDropCondition.Drop(reqs, NPCID.None, ItemID.DemonScythe), AchievementCategory.Collector);
            RegisterAchievement("WEAPON_WATER_BOLT", BreakAndGrabItem(reqs, ItemID.WaterBolt), false, AchievementCategory.Collector);

            // Rare Other
            RegisterAchievement("WEAPON_BLOOD_THORN", NpcDropCondition.Drop(reqs, NPCID.GoblinShark, ItemID.SharpTears), AchievementCategory.Collector);
            RegisterAchievement("WEAPON_MEDUSA_HEAD", NpcDropCondition.Drop(reqs, NPCID.Medusa, ItemID.MedusaHead), AchievementCategory.Collector);
            RegisterAchievement("WEAPON_NIMBUS_ROD", NpcDropCondition.Drop(reqs, NPCID.AngryNimbus, ItemID.NimbusRod), AchievementCategory.Collector);
            RegisterAchievement("WEAPON_STELLAR_TUNE", ItemGrabCondition.Grab(reqs, ItemID.SparkleGuitar), AchievementCategory.Collector);

            foreach (var group in MagicWeapons)
                RegisterAchievement(group.Key, ItemGrabCondition.GrabAll(reqs, group.Value), group.Value.Length > 1, AchievementCategory.Collector);
        }

        /// <summary>
        /// Register summon weapon achievements
        /// </summary>
        /// <param name="reqs">Common achievement requirements</param>
        private void RegisterSummonWeaponAchievements(ConditionReqs reqs)
        {
            // Verified w/ https://terraria.wiki.gg/wiki/Weapons
            Dictionary<string, int[]> SummonWeapons = new()
            {
                { "WEAPON_SUMMON_MINION", [ItemID.BabyBirdStaff, ItemID.SlimeStaff, ItemID.FlinxStaff, ItemID.AbigailsFlower, ItemID.HornetStaff, ItemID.VampireFrogStaff, ItemID.ImpStaff, ItemID.Smolstar, ItemID.SpiderStaff, ItemID.PirateStaff, ItemID.SanguineStaff, ItemID.OpticStaff, ItemID.DeadlySphereStaff, ItemID.PygmyStaff, ItemID.RavenStaff, ItemID.StormTigerStaff, ItemID.TempestStaff, ItemID.EmpressBlade, ItemID.XenoStaff, ItemID.StardustCellStaff, ItemID.StardustDragonStaff] },
                { "WEAPON_SUMMON_SENTRY", [ItemID.HoundiusShootius, ItemID.DD2LightningAuraT1Popper, ItemID.DD2FlameburstTowerT1Popper, ItemID.DD2ExplosiveTrapT1Popper, ItemID.DD2BallistraTowerT1Popper, ItemID.QueenSpiderStaff, ItemID.StaffoftheFrostHydra, ItemID.MoonlordTurretStaff, ItemID.RainbowCrystalStaff, ItemID.DD2LightningAuraT2Popper, ItemID.DD2FlameburstTowerT2Popper, ItemID.DD2ExplosiveTrapT2Popper, ItemID.DD2BallistraTowerT2Popper, ItemID.DD2LightningAuraT3Popper, ItemID.DD2FlameburstTowerT3Popper, ItemID.DD2ExplosiveTrapT3Popper, ItemID.DD2BallistraTowerT3Popper] },
                { "WEAPON_SUMMON_WHIP", [ItemID.BlandWhip, ItemID.ThornWhip, ItemID.BoneWhip, ItemID.FireWhip, ItemID.CoolWhip, ItemID.SwordWhip, ItemID.ScytheWhip, ItemID.MaceWhip, ItemID.RainbowWhip] }
            };

            // Rare Minions
            RegisterAchievement("WEAPON_ABIGAILS_FLOWER", BreakAndGrabItem(reqs, ItemID.AbigailsFlower), false, AchievementCategory.Collector);
            RegisterAchievement("WEAPON_SLIME_STAFF", NpcDropCondition.Drop(reqs, NPCID.None, ItemID.SlimeStaff), AchievementCategory.Collector);
            RegisterAchievement("WEAPON_VAMPIRE_FROG_STAFF", NpcDropCondition.Drop(reqs, NPCID.None, ItemID.VampireFrogStaff), AchievementCategory.Collector);
            RegisterAchievement("WEAPON_PIRATE_STAFF", NpcDropCondition.Drop(reqs, NPCID.None, ItemID.PirateStaff), AchievementCategory.Collector);
            RegisterAchievement("WEAPON_SANGUINE_STAFF", NpcDropCondition.Drop(reqs, NPCID.BloodNautilus, ItemID.SanguineStaff), AchievementCategory.Collector);
            RegisterAchievement("WEAPON_TERRAPRISMA", NpcDropCondition.Drop(reqs, NPCID.HallowBoss, ItemID.EmpressBlade), AchievementCategory.Collector);

            // Rare Whips
            RegisterAchievement("WEAPON_MORNING_STAR", NpcDropCondition.Drop(reqs, NPCID.None, ItemID.MaceWhip), AchievementCategory.Collector);

            foreach (var group in SummonWeapons)
                RegisterAchievement(group.Key, ItemGrabCondition.GrabAll(reqs, group.Value), group.Value.Length > 1, AchievementCategory.Collector);
        }

        /// <summary>
        /// Register other weapon achievements
        /// </summary>
        /// <param name="reqs">Common achievement requirements</param>
        private void RegisterPlaceableWeaponAchievements(ConditionReqs reqs)
        {
            // Verified w/ https://terraria.wiki.gg/wiki/Weapons
            int[] PlaceableWeapons = [ItemID.SnowballLauncher, ItemID.RedRocket, ItemID.GreenRocket, ItemID.BlueRocket, ItemID.YellowRocket, ItemID.Cannon, ItemID.BunnyCannon, ItemID.LandMine];

            RegisterAchievement("WEAPON_PLACEABLE", ItemGrabCondition.GrabAll(reqs, PlaceableWeapons), true, AchievementCategory.Collector);
        }

        /// <summary>
        /// Register ammo achievements
        /// </summary>
        /// <param name="reqs">Common achievement requirements</param>
        private void RegisterAmmoAchievements(ConditionReqs reqs)
        {
            Dictionary<string, int[]> Ammo = new()
            {
                { "AMMO_FLARE", [ItemID.Flare, ItemID.BlueFlare, ItemID.SpelunkerFlare, ItemID.CursedFlare, ItemID.RainbowFlare, ItemID.ShimmerFlare] },
                { "AMMO_BULLET", [ItemID.MusketBall, ItemID.MeteorShot, ItemID.SilverBullet, ItemID.CrystalBullet, ItemID.CursedBullet, ItemID.ChlorophyteBullet, ItemID.HighVelocityBullet, ItemID.IchorBullet, ItemID.VenomBullet, ItemID.PartyBullet, ItemID.NanoBullet, ItemID.ExplodingBullet, ItemID.GoldenBullet, ItemID.EndlessMusketPouch, ItemID.MoonlordBullet, ItemID.TungstenBullet] },
                { "AMMO_ARROW", [ItemID.WoodenArrow, ItemID.FlamingArrow, ItemID.UnholyArrow, ItemID.JestersArrow, ItemID.HellfireArrow, ItemID.HolyArrow, ItemID.CursedArrow, ItemID.FrostburnArrow, ItemID.ChlorophyteArrow, ItemID.IchorArrow, ItemID.VenomArrow, ItemID.BoneArrow, ItemID.EndlessQuiver, ItemID.MoonlordArrow, ItemID.ShimmerArrow] },
                { "AMMO_ROCKET", [ItemID.RocketI, ItemID.RocketII, ItemID.RocketIII, ItemID.RocketIV, ItemID.ClusterRocketI, ItemID.ClusterRocketII, ItemID.DryRocket, ItemID.WetRocket, ItemID.LavaRocket, ItemID.HoneyRocket, ItemID.MiniNukeI, ItemID.MiniNukeII] },
                { "AMMO_DART", [ItemID.PoisonDart, ItemID.CrystalDart, ItemID.CursedDart, ItemID.IchorDart] },
                { "AMMO_SOLUTION", [ItemID.GreenSolution, ItemID.SandSolution, ItemID.SnowSolution, ItemID.DirtSolution, ItemID.BlueSolution, ItemID.PurpleSolution, ItemID.DarkBlueSolution, ItemID.RedSolution] }
            };

            foreach (var group in Ammo)
                RegisterAchievement(group.Key, ItemGrabCondition.GrabAll(reqs, group.Value), group.Value.Length > 1, AchievementCategory.Collector);
        }

        /// <summary>
        /// Register tool achievements
        /// </summary>
        /// <param name="reqs">Common achievement requirements</param>
        private void RegisterToolAchievements(ConditionReqs reqs)
        {
            // Verified w/ https://terraria.wiki.gg/wiki/Tools
            Dictionary<string, int[]> Tools = new()
            {
                { "TOOL_MINE", [ItemID.CactusPickaxe, ItemID.CopperPickaxe, ItemID.TinPickaxe, ItemID.IronPickaxe, ItemID.LeadPickaxe, ItemID.SilverPickaxe, ItemID.TungstenPickaxe, ItemID.GoldPickaxe, ItemID.CnadyCanePickaxe, ItemID.FossilPickaxe, ItemID.BonePickaxe, ItemID.PlatinumPickaxe, ItemID.ReaverShark, ItemID.NightmarePickaxe, ItemID.DeathbringerPickaxe, ItemID.MoltenPickaxe, ItemID.CobaltPickaxe, ItemID.CobaltDrill, ItemID.PalladiumPickaxe, ItemID.PalladiumDrill, ItemID.MythrilPickaxe, ItemID.MythrilDrill, ItemID.OrichalcumPickaxe, ItemID.OrichalcumDrill, ItemID.AdamantitePickaxe, ItemID.AdamantiteDrill, ItemID.TitaniumPickaxe, ItemID.TitaniumDrill, ItemID.SpectrePickaxe, ItemID.ChlorophytePickaxe, ItemID.ChlorophyteDrill, ItemID.PickaxeAxe, ItemID.Drax, ItemID.ShroomiteDiggingClaw, ItemID.Picksaw, ItemID.VortexPickaxe, ItemID.NebulaPickaxe, ItemID.SolarFlarePickaxe, ItemID.StardustPickaxe, ItemID. VortexDrill, ItemID.NebulaDrill, ItemID.SolarFlareDrill, ItemID.StardustDrill, ItemID.LaserDrill] },
                { "TOOL_CHOP", [ItemID.CopperAxe, ItemID.TinAxe, ItemID.IronAxe, ItemID.LeadAxe, ItemID.SilverAxe, ItemID.TungstenAxe, ItemID.GoldAxe, ItemID.PlatinumAxe, ItemID.CobaltWaraxe, ItemID.CobaltChainsaw, ItemID.SawtoothShark, ItemID.WarAxeoftheNight, ItemID.BloodLustCluster, ItemID.PalladiumWaraxe, ItemID.PalladiumChainsaw, ItemID.MythrilWaraxe, ItemID.MythrilChainsaw, ItemID.OrichalcumWaraxe, ItemID.OrichalcumChainsaw, ItemID.AdamantiteWaraxe, ItemID.AdamantiteChainsaw, ItemID.MeteorHamaxe, ItemID.TitaniumWaraxe, ItemID.TitaniumChainsaw, ItemID.PickaxeAxe, ItemID.Drax, ItemID.ChlorophyteGreataxe, ItemID.ChlorophyteChainsaw, ItemID.Picksaw, ItemID.ShroomiteDiggingClaw, ItemID.LucyTheAxe, ItemID.AcornAxe, ItemID.ButchersChainsaw, ItemID.MoltenHamaxe, ItemID.BloodHamaxe, ItemID.SpectreHamaxe, ItemID.LunarHamaxeSolar, ItemID.LunarHamaxeVortex, ItemID.LunarHamaxeNebula, ItemID.LunarHamaxeStardust, ItemID.TheAxe] },
                { "TOOL_HAMMER", [ItemID.WoodenHammer, ItemID.RichMahoganyHammer, ItemID.PalmWoodHammer, ItemID.BorealWoodHammer, ItemID.CopperHammer, ItemID.TinHammer, ItemID.IronHammer, ItemID.EbonwoodHammer, ItemID.ShadewoodHammer, ItemID.LeadHammer, ItemID.AshWoodHammer, ItemID.SilverHammer, ItemID.TungstenHammer, ItemID.GoldHammer, ItemID.TheBreaker, ItemID.PearlwoodHammer, ItemID.FleshGrinder, ItemID.PlatinumHammer, ItemID.MeteorHamaxe, ItemID.Rockfish, ItemID.MoltenHamaxe, ItemID.Pwnhammer, ItemID.BloodHamaxe, ItemID.Hammush, ItemID.ChlorophyteWarhammer, ItemID.ChlorophyteJackhammer, ItemID.SpectreHamaxe, ItemID.LunarHamaxeSolar, ItemID.LunarHamaxeVortex, ItemID.LunarHamaxeNebula, ItemID.LunarHamaxeStardust, ItemID.TheAxe] },
                { "TOOL_WIRE", [ItemID.Wrench, ItemID.WireCutter, ItemID.BlueWrench, ItemID.GreenWrench, ItemID.WireKite, ItemID.YellowWrench, ItemID.ActuationRod, ItemID.MulticolorWrench] },
                { "TOOL_PAINT", [ItemID.Paintbrush, ItemID.PaintRoller, ItemID.PaintScraper, ItemID.SpectrePaintbrush, ItemID.SpectrePaintRoller, ItemID.SpectrePaintScraper] },
                { "TOOL_HOOK", [ItemID.GrapplingHook, ItemID.IvyWhip, ItemID.DualHook, ItemID.WebSlinger, ItemID.AmethystHook, ItemID.TopazHook, ItemID.SapphireHook, ItemID.EmeraldHook, ItemID.RubyHook, ItemID.DiamondHook, ItemID.SkeletronHand, ItemID.BatHook, ItemID.SpookyHook, ItemID.CandyCaneHook, ItemID.ChristmasHook, ItemID.FishHook, ItemID.SlimeHook, ItemID.AntiGravityHook, ItemID.TendonHook, ItemID.ThornHook, ItemID.IlluminantHook, ItemID.WormHook, ItemID.LunarHook, ItemID.StaticHook, ItemID.AmberHook, ItemID.SquirrelHook, ItemID.QueenSlimeHook] },
                { "TOOL_FISH", [ItemID.WoodFishingPole, ItemID.ReinforcedFishingPole, ItemID.FiberglassFishingPole, ItemID.FisherofSouls, ItemID.GoldenFishingRod, ItemID.MechanicsRod, ItemID.SittingDucksFishingRod, ItemID.Fleshcatcher, ItemID.HotlineFishingHook, ItemID.BloodFishingRod, ItemID.ScarabFishingRod] },
                { "TOOL_MOVEMENT", [ItemID.IceMirror, ItemID.MagicMirror, ItemID.CellPhone, ItemID.Shellphone, ItemID.Trident, ItemID.RodofDiscord, ItemID.RodOfHarmony, ItemID.PortalGun, ItemID.Umbrella, ItemID.TragicUmbrella, ItemID.MagicConch, ItemID.DemonConch, ItemID.MysticCoilSnake] },
                { "TOOL_WAND", [ItemID.LeafWand, ItemID.LivingWoodWand, ItemID.LivingMahoganyLeafWand, ItemID.LivingMahoganyWand, ItemID.HiveWand, ItemID.BoneWand] },
                { "TOOL_OTHER", [ItemID.EmptyBucket, ItemID.BottomlessBucket, ItemID.BottomlessLavaBucket, ItemID.BottomlessHoneyBucket, ItemID.BottomlessShimmerBucket, ItemID.SuperAbsorbantSponge, ItemID.LavaAbsorbantSponge, ItemID.HoneyAbsorbantSponge, ItemID.UltraAbsorbantSponge, ItemID.BugNet, ItemID.GoldenBugNet, ItemID.FireproofBugNet, ItemID.Sickle, ItemID.StaffofRegrowth, ItemID.Clentaminator, ItemID.Clentaminator2, ItemID.BreathingReed, ItemID.Binoculars, ItemID.GolfClubStoneIron, ItemID.GolfClubIron, ItemID.GolfClubMythrilIron, ItemID.GolfClubTitaniumIron, ItemID.GolfClubWoodDriver, ItemID.GolfClubDriver, ItemID.GolfClubPearlwoodDriver, ItemID.GolfClubChlorophyteDriver, ItemID.GolfClubBronzeWedge, ItemID.GolfClubWedge, ItemID.GolfClubGoldWedge, ItemID.GolfClubDiamondWedge, ItemID.GolfClubRustyPutter, ItemID.GolfClubPutter, ItemID.GolfClubLeadPutter, ItemID.GolfClubShroomitePutter, ItemID.GolfWhistle, ItemID.GoldenKey, ItemID.ShadowKey, ItemID.TempleKey, ItemID.JungleKey, ItemID.FrozenKey, ItemID.HallowedKey, ItemID.CorruptionKey, ItemID.CrimsonKey, ItemID.DungeonDesertKey, ItemID.LightKey, ItemID.NightKey, ItemID.DontHurtCrittersBook, ItemID.DontHurtNatureBook, ItemID.DontHurtComboBook, ItemID.ChumBucket, ItemID.GravediggerShovel, ItemID.EncumberingStone, ItemID.LawnMower, ItemID.RubblemakerSmall, ItemID.RubblemakerMedium, ItemID.RubblemakerLarge, ItemID.SandcastleBucket, ItemID.IceRod, ItemID.DirtRod, ItemID.FlareGun] }
            };

            // Rare Pickaxes
            RegisterAchievement("TOOL_BONE_PICKAXE", NpcDropCondition.Drop(reqs, NPCID.UndeadMiner, ItemID.BonePickaxe), AchievementCategory.Collector);
            RegisterAchievement("TOOL_THE_AXE", ItemGrabCondition.Grab(reqs, ItemID.TheAxe), AchievementCategory.Collector);

            // Rare Hooks
            RegisterAchievement("TOOL_BAT_HOOK", ItemOpenCondition.Open(reqs, ItemID.GoodieBag, ItemID.BatHook), AchievementCategory.Collector);
            RegisterAchievement("TOOL_FISH_HOOK", NpcGiftCondition.Gift(reqs, NPCID.Angler, ItemID.FishHook), AchievementCategory.Collector);

            // Rare Fishing Rods
            RegisterAchievement("TOOL_HOTLINE_FISHING_HOOK", NpcGiftCondition.Gift(reqs, NPCID.Angler, ItemID.HotlineFishingHook), AchievementCategory.Collector);

            // Rare Movement Tools
            RegisterAchievement("TOOL_DEMON_CONCH", ItemCatchCondition.Catch(reqs, ItemID.DemonConch), AchievementCategory.Collector);
            RegisterAchievement("TOOL_ROD_OF_DISCORD", NpcDropCondition.Drop(reqs, NPCID.ChaosElemental, ItemID.RodofDiscord), AchievementCategory.Collector);

            // Rare Wands
            RegisterAchievement("TOOL_BONE_WAND", NpcDropCondition.Drop(reqs, NPCID.None, ItemID.BoneWand), AchievementCategory.Collector);

            // Rare Other
            RegisterAchievement("TOOL_BOTTOMLESS_LAVA_BUCKET", ItemCatchCondition.Catch(reqs, ItemID.BottomlessLavaBucket), AchievementCategory.Collector);
            RegisterAchievement("TOOL_SUPER_ABSORBANT_SPONGE", NpcGiftCondition.Gift(reqs, NPCID.Angler, ItemID.SuperAbsorbantSponge), AchievementCategory.Collector);
            RegisterAchievement("TOOL_LAVA_ABSORBANT_SPONGE", ItemCatchCondition.Catch(reqs, ItemID.LavaAbsorbantSponge), AchievementCategory.Collector);
            RegisterAchievement("TOOL_GOLDEN_BUG_NET", NpcGiftCondition.Gift(reqs, NPCID.Angler, ItemID.GoldenBugNet), AchievementCategory.Collector);
            RegisterAchievement("TOOL_BINOCULARS", ItemGrabCondition.Grab(reqs, ItemID.Binoculars), AchievementCategory.Collector);
            RegisterAchievement("TOOL_JUNGLE_KEY", NpcDropCondition.Drop(reqs, NPCID.None, ItemID.JungleKey), AchievementCategory.Collector);
            RegisterAchievement("TOOL_FROZEN_KEY", NpcDropCondition.Drop(reqs, NPCID.None, ItemID.FrozenKey), AchievementCategory.Collector);
            RegisterAchievement("TOOL_HALLOWED_KEY", NpcDropCondition.Drop(reqs, NPCID.None, ItemID.HallowedKey), AchievementCategory.Collector);
            RegisterAchievement("TOOL_CORRUPTION_KEY", NpcDropCondition.Drop(reqs, NPCID.None, ItemID.CorruptionKey), AchievementCategory.Collector);
            RegisterAchievement("TOOL_CRIMSON_KEY", NpcDropCondition.Drop(reqs, NPCID.None, ItemID.CrimsonKey), AchievementCategory.Collector);
            RegisterAchievement("TOOL_DESERT_KEY", NpcDropCondition.Drop(reqs, NPCID.None, ItemID.DungeonDesertKey), AchievementCategory.Collector);

            foreach (var group in Tools)
                RegisterAchievement(group.Key, ItemGrabCondition.GrabAll(reqs, group.Value), group.Value.Length > 1, AchievementCategory.Collector);
        }

        /// <summary>
        /// Register armor achievements
        /// </summary>
        /// <param name="reqs">Common achievement requirements</param>
        private void RegisterArmorAchievements(ConditionReqs reqs)
        {
            // Verified w/ https://terraria.wiki.gg/wiki/Armor
            Dictionary<string, int[]> ArmorPreHardmode = new()
            {
                { "Mining", [ItemID.UltrabrightHelmet, ItemID.MiningHelmet, ItemID.MiningShirt, ItemID.MiningPants] },
                { "Wood", [ItemID.WoodHelmet, ItemID.WoodBreastplate, ItemID.WoodGreaves] },
                { "Rich Mahogany", [ItemID.RichMahoganyHelmet, ItemID.RichMahoganyBreastplate, ItemID.RichMahoganyGreaves] },
                { "Boreal Wood", [ItemID.BorealWoodHelmet, ItemID.BorealWoodBreastplate, ItemID.BorealWoodGreaves] },
                { "Palm Wood", [ItemID.PalmWoodHelmet, ItemID.PalmWoodBreastplate, ItemID.PalmWoodGreaves] },
                { "Ebonwood", [ItemID.EbonwoodHelmet, ItemID.EbonwoodBreastplate, ItemID.EbonwoodGreaves] },
                { "Shadewood", [ItemID.ShadewoodHelmet, ItemID.ShadewoodBreastplate, ItemID.ShadewoodGreaves] },
                { "Ash Wood", [ItemID.AshWoodHelmet, ItemID.AshWoodBreastplate, ItemID.AshWoodGreaves] },
                { "Rain", [ItemID.RainHat, ItemID.RainCoat] },
                { "Snow", [ItemID.EskimoHood, ItemID.EskimoCoat, ItemID.EskimoPants] },
                { "Pink Snow", [ItemID.PinkEskimoHood, ItemID.PinkEskimoCoat, ItemID.PinkEskimoPants] },
                { "Angler", [ItemID.AnglerHat, ItemID.AnglerVest, ItemID.AnglerPants] },
                { "Cactus", [ItemID.CactusHelmet, ItemID.CactusBreastplate, ItemID.CactusLeggings] },
                { "Copper", [ItemID.CopperHelmet, ItemID.CopperChainmail, ItemID.CopperGreaves] },
                { "Tin", [ItemID.TinHelmet, ItemID.TinChainmail, ItemID.TinGreaves] },
                { "Pumpkin", [ItemID.PumpkinHelmet, ItemID.PumpkinBreastplate, ItemID.PumpkinLeggings] },
                { "Ninja", [ItemID.NinjaHood, ItemID.NinjaShirt, ItemID.NinjaPants] },
                { "Iron", [ItemID.IronHelmet, ItemID.AncientIronHelmet, ItemID.IronChainmail, ItemID.IronGreaves] },
                { "Lead", [ItemID.LeadHelmet, ItemID.LeadChainmail, ItemID.LeadGreaves] },
                { "Silver", [ItemID.SilverHelmet, ItemID.SilverChainmail, ItemID.SilverGreaves] },
                { "Tungsten", [ItemID.TungstenHelmet, ItemID.TungstenChainmail, ItemID.TungstenGreaves] },
                { "Gold", [ItemID.GoldHelmet, ItemID.AncientGoldHelmet, ItemID.GoldChainmail, ItemID.GoldGreaves] },
                { "Platinum", [ItemID.PlatinumHelmet, ItemID.PlatinumChainmail, ItemID.PlatinumGreaves] },
                { "Fossil", [ItemID.FossilHelm, ItemID.FossilShirt, ItemID.FossilPants] },
                { "Bee", [ItemID.BeeHeadgear, ItemID.BeeBreastplate, ItemID.BeePants] },
                { "Obsidian", [ItemID.ObsidianHelm, ItemID.ObsidianShirt, ItemID.ObsidianPants] },
                { "Gladiator", [ItemID.GladiatorHelmet, ItemID.GladiatorBreastplate, ItemID.GladiatorLeggings] },
                { "Meteor", [ItemID.MeteorHelmet, ItemID.MeteorSuit, ItemID.MeteorLeggings] },
                { "Jungle", [ItemID.JungleHat, ItemID.JungleShirt, ItemID.JunglePants] },
                { "Ancient Cobalt", [ItemID.AncientCobaltHelmet, ItemID.AncientCobaltBreastplate, ItemID.AncientCobaltLeggings] },
                { "Necro", [ItemID.NecroHelmet, ItemID.AncientNecroHelmet, ItemID.NecroBreastplate, ItemID.NecroGreaves] },
                { "Shadow", [ItemID.ShadowHelmet, ItemID.ShadowScalemail, ItemID.ShadowGreaves] },
                { "Ancient Shadow", [ItemID.AncientShadowHelmet, ItemID.AncientShadowScalemail, ItemID.AncientShadowGreaves] },
                { "Crimson", [ItemID.CrimsonHelmet, ItemID.CrimsonScalemail, ItemID.CrimsonGreaves] },
                { "Molten", [ItemID.MoltenHelmet, ItemID.MoltenBreastplate, ItemID.MoltenGreaves] }
            };

            // Verified w/ https://terraria.wiki.gg/wiki/Armor
            Dictionary<string, int[]> ArmorHardmode = new()
            {
                { "Pearlwood", [ItemID.PearlwoodHelmet, ItemID.PearlwoodBreastplate, ItemID.PearlwoodGreaves] },
                { "Spider", [ItemID.SpiderMask, ItemID.SpiderBreastplate, ItemID.SpiderGreaves] },
                { "Cobalt", [ItemID.CobaltHat, ItemID.CobaltHelmet, ItemID.CobaltMask, ItemID.CobaltBreastplate, ItemID.CobaltLeggings] },
                { "Palladium", [ItemID.PalladiumHeadgear, ItemID.PalladiumMask, ItemID.PalladiumHelmet, ItemID.PalladiumBreastplate, ItemID.PalladiumLeggings] },
                { "Mythril", [ItemID.MythrilHood, ItemID.MythrilHelmet, ItemID.MythrilHat, ItemID.MythrilChainmail, ItemID.MythrilGreaves] },
                { "Orichalcum", [ItemID.OrichalcumHeadgear, ItemID.OrichalcumMask, ItemID.OrichalcumHelmet, ItemID.OrichalcumBreastplate, ItemID.OrichalcumLeggings] },
                { "Adamantite", [ItemID.AdamantiteHeadgear, ItemID.AdamantiteHelmet, ItemID.AdamantiteMask, ItemID.AdamantiteBreastplate, ItemID.AdamantiteLeggings] },
                { "Titanium", [ItemID.TitaniumHeadgear, ItemID.TitaniumMask, ItemID.TitaniumHelmet, ItemID.TitaniumBreastplate, ItemID.TitaniumLeggings] },
                { "Crystal Assassin", [ItemID.CrystalNinjaHelmet, ItemID.CrystalNinjaChestplate, ItemID.CrystalNinjaLeggings] },
                { "Frost", [ItemID.FrostHelmet, ItemID.FrostBreastplate, ItemID.FrostLeggings] },
                { "Forbidden", [ItemID.AncientBattleArmorHat, ItemID.AncientBattleArmorShirt, ItemID.AncientBattleArmorPants] },
                { "Squire", [ItemID.SquireGreatHelm, ItemID.SquirePlating, ItemID.SquireGreaves] },
                { "Monk", [ItemID.MonkBrows, ItemID.MonkShirt, ItemID.MonkPants] },
                { "Huntress", [ItemID.HuntressWig, ItemID.HuntressJerkin, ItemID.HuntressPants] },
                { "Apprentice", [ItemID.ApprenticeHat, ItemID.ApprenticeRobe, ItemID.ApprenticeTrousers] },
                { "Hallowed", [ItemID.HallowedMask, ItemID.HallowedHelmet, ItemID.HallowedHeadgear, ItemID.HallowedHood, ItemID.HallowedPlateMail, ItemID.HallowedGreaves] },
                { "Ancient Hallowed", [ItemID.AncientHallowedMask, ItemID.AncientHallowedHelmet, ItemID.AncientHallowedHeadgear, ItemID.AncientHallowedHood, ItemID.AncientHallowedPlateMail, ItemID.AncientHallowedGreaves] },
                { "Chlorophyte", [ItemID.ChlorophyteMask, ItemID.ChlorophyteHelmet, ItemID.ChlorophyteHeadgear, ItemID.ChlorophytePlateMail, ItemID.ChlorophyteGreaves] },
                { "Turtle", [ItemID.TurtleHelmet, ItemID.TurtleScaleMail, ItemID.TurtleLeggings] },
                { "Tiki", [ItemID.TikiMask, ItemID.TikiShirt, ItemID.TikiPants] },
                { "Beetle", [ItemID.BeetleHelmet, ItemID.BeetleScaleMail, ItemID.BeetleShell, ItemID.BeetleLeggings] },
                { "Shroomite", [ItemID.ShroomiteHeadgear, ItemID.ShroomiteHelmet, ItemID.ShroomiteMask, ItemID.ShroomiteBreastplate, ItemID.ShroomiteLeggings] },
                { "Spectre", [ItemID.SpectreMask, ItemID.SpectreHood, ItemID.SpectreRobe, ItemID.SpectrePants] },
                { "Spooky", [ItemID.SpookyHelmet, ItemID.SpookyBreastplate, ItemID.SpookyLeggings] },
                { "Valhalla Knight", [ItemID.SquireAltHead, ItemID.SquireAltShirt, ItemID.SquireAltPants] },
                { "Shinobi Infiltrator", [ItemID.MonkAltHead, ItemID.MonkAltShirt, ItemID.MonkAltPants] },
                { "Red Riding", [ItemID.HuntressAltHead, ItemID.HuntressAltShirt, ItemID.HuntressAltPants] },
                { "Dark Artist", [ItemID.ApprenticeAltHead, ItemID.ApprenticeAltShirt, ItemID.ApprenticeAltPants] },
                { "Solar Flare", [ItemID.SolarFlareHelmet, ItemID.SolarFlareBreastplate, ItemID.SolarFlareLeggings] },
                { "Vortex", [ItemID.VortexHelmet, ItemID.VortexBreastplate, ItemID.VortexLeggings] },
                { "Nebula", [ItemID.NebulaHelmet, ItemID.NebulaBreastplate, ItemID.NebulaLeggings] },
                { "Stardust", [ItemID.StardustHelmet, ItemID.StardustBreastplate, ItemID.StardustLeggings] }
            };

            // Verified w/ https://terraria.wiki.gg/wiki/Armor
            Dictionary<string, int[]> ArmorPieces = new()
            {
                { "ARMOR_WIZARD", [ItemID.MagicHat, ItemID.WizardHat, ItemID.AmethystRobe, ItemID.TopazRobe, ItemID.SapphireRobe, ItemID.EmeraldRobe, ItemID.RubyRobe, ItemID.AmberRobe, ItemID.DiamondRobe, ItemID.GypsyRobe] },
                { "ARMOR_OTHER", [ItemID.EmptyBucket, ItemID.Goggles, ItemID.GreenCap, ItemID.DivingHelmet, ItemID.NightVisionHelmet, ItemID.VikingHelmet, ItemID.FlinxFurCoat, ItemID.Gi, ItemID.DjinnsCurse] }
            };

            // Rare Sets
            RegisterAchievement("ARMOR_MINING", NpcDropCondition.DropAll(reqs, NPCID.UndeadMiner, [ItemID.MiningShirt, ItemID.MiningPants]), true, AchievementCategory.Collector);
            RegisterAchievement("ARMOR_RAIN", NpcDropCondition.DropAll(reqs, NPCID.ZombieRaincoat, ArmorPreHardmode["Rain"]), true, AchievementCategory.Collector);
            RegisterAchievement("ARMOR_SNOW", NpcDropCondition.DropAll(reqs, NPCID.ZombieEskimo, ArmorPreHardmode["Snow"]), true, AchievementCategory.Collector);
            
            // Rare Pieces
            RegisterAchievement("ARMOR_DIVING_HELMET", NpcDropCondition.Drop(reqs, NPCID.Shark, ItemID.DivingHelmet), AchievementCategory.Collector);
            RegisterAchievement("ARMOR_DJINNS_CURSE", NpcDropCondition.Drop(reqs, NPCID.DesertDjinn, ItemID.DjinnsCurse), AchievementCategory.Collector);
            RegisterAchievement("ARMOR_GREEN_CAP", ItemGrabCondition.Grab(reqs, ItemID.GreenCap), AchievementCategory.Collector);
            RegisterAchievement("ARMOR_VIKING_HELMET", NpcDropCondition.Drop(reqs, NPCID.UndeadViking, ItemID.VikingHelmet), AchievementCategory.Collector);

            List<CustomAchievementCondition> sets = [];
            foreach (var set in ArmorPreHardmode)
                sets.AddRange(ItemGrabCondition.GrabAll(reqs, set.Value));
            RegisterAchievement("ARMOR_PRE-HARDMODE", sets, true, AchievementCategory.Collector);

            sets = [];
            foreach (var set in ArmorHardmode)
                sets.AddRange(ItemGrabCondition.GrabAll(reqs, set.Value));
            RegisterAchievement("ARMOR_HARDMODE", sets, true, AchievementCategory.Collector);

            foreach (var group in ArmorPieces)
                RegisterAchievement(group.Key, ItemGrabCondition.GrabAll(reqs, group.Value), group.Value.Length > 1, AchievementCategory.Collector);
        }

        /// <summary>
        /// Register accessory achievements
        /// </summary>
        /// <param name="reqs">Common achievement requirements</param>
        private void RegisterAccessoryAchievements(ConditionReqs reqs)
        {
            // Verified w/ https://terraria.wiki.gg/wiki/Accessories
            // Added https://terraria.wiki.gg/wiki/FPV_Goggles to Other
            Dictionary<string, int[]> Accessories = new()
            {
                { "ACCESSORY_MOVE", [ItemID.Aglet, ItemID.BalloonHorseshoeHoney, ItemID.AmphibianBoots, ItemID.AnkletoftheWind, ItemID.ArcticDivingGear, ItemID.BalloonPufferfish, ItemID.BlizzardinaBalloon, ItemID.BlizzardinaBottle, ItemID.BlueHorseshoeBalloon, ItemID.BundleofBalloons, ItemID.HorseshoeBundle, ItemID.CelestialShell, ItemID.ClimbingClaws, ItemID.CloudinaBalloon, ItemID.CloudinaBottle, ItemID.DivingGear, ItemID.SandBoots, ItemID.FairyBoots, ItemID.FartInABalloon, ItemID.FartinaJar, ItemID.Flipper, ItemID.FlurryBoots, ItemID.FlyingCarpet, ItemID.FrogFlipper, ItemID.FrogGear, ItemID.FrogLeg, ItemID.FrogWebbing, ItemID.FrostsparkBoots, ItemID.BalloonHorseshoeFart, ItemID.HellfireTreads, ItemID.HermesBoots, ItemID.HoneyBalloon, ItemID.IceSkates, ItemID.FloatingTube, ItemID.JellyfishDivingGear, ItemID.LavaCharm, ItemID.LavaWaders, ItemID.LightningBoots, ItemID.LuckyHorseshoe, ItemID.Magiluminescence, ItemID.LavaSkull, ItemID.MasterNinjaGear, ItemID.MoltenCharm, ItemID.MoonCharm, ItemID.MoonShell, ItemID.NeptunesShell, ItemID.ObsidianHorseshoe, ItemID.ObsidianWaterWalkingBoots, ItemID.BalloonHorseshoeSharkron, ItemID.RocketBoots, ItemID.SailfishBoots, ItemID.SandstorminaBalloon, ItemID.SandstorminaBottle, ItemID.SharkronBalloon, ItemID.ShinyRedBalloon, ItemID.ShoeSpikes, ItemID.SpectreBoots, ItemID.PortableStool, ItemID.Tabi, ItemID.TerrasparkBoots, ItemID.TigerClimbingGear, ItemID.TsunamiInABottle, ItemID.WaterWalkingBoots, ItemID.WhiteHorseshoeBalloon, ItemID.YellowHorseshoeBalloon] },
                { "ACCESSORY_WINGS", [ItemID.CreativeWings, ItemID.AngelWings, ItemID.DemonWings, ItemID.FairyWings, ItemID.FinWings, ItemID.FrozenWings, ItemID.HarpyWings, ItemID.Jetpack, ItemID.LeafWings, ItemID.BatWings, ItemID.BeeWings, ItemID.ButterflyWings, ItemID.FlameWings, ItemID.Hoverboard, ItemID.BoneWings, ItemID.MothronWings, ItemID.GhostWings, ItemID.BeetleWings, ItemID.FestiveWings, ItemID.SpookyWings, ItemID.TatteredFairyWings, ItemID.SteampunkWings, ItemID.BetsyWings, ItemID.RainbowWings, ItemID.FishronWings, ItemID.WingsNebula, ItemID.WingsVortex, ItemID.WingsSolar, ItemID.WingsStardust] },
                { "ACCESSORY_INFO", [ItemID.CopperWatch, ItemID.TinWatch, ItemID.SilverWatch, ItemID.TungstenWatch, ItemID.GoldWatch, ItemID.PlatinumWatch, ItemID.DepthMeter, ItemID.Compass, ItemID.Radar, ItemID.LifeformAnalyzer, ItemID.TallyCounter, ItemID.MetalDetector, ItemID.Stopwatch, ItemID.DPSMeter, ItemID.FishermansGuide, ItemID.WeatherRadio, ItemID.Sextant, ItemID.GPS, ItemID.REK, ItemID.GoblinTech, ItemID.FishFinder, ItemID.PDA, ItemID.MechanicalLens, ItemID.Ruler, ItemID.LaserRuler] },
                { "ACCESSORY_HEALTH_MANA", [ItemID.ArcaneFlower, ItemID.BandofRegeneration, ItemID.BandofStarpower, ItemID.CelestialCuffs, ItemID.CelestialMagnet, ItemID.CelestialEmblem, ItemID.CharmofMyths, ItemID.MagicCuffs, ItemID.MagnetFlower, ItemID.ManaCloak, ItemID.ManaFlower, ItemID.ManaRegenerationBand, ItemID.NaturesGift, ItemID.PhilosophersStone] },
                { "ACCESSORY_COMBAT", [ItemID.AdhesiveBandage, ItemID.AnkhCharm, ItemID.AnkhShield, ItemID.ArmorBracing, ItemID.ArmorPolish, ItemID.AvengerEmblem, ItemID.BeeCloak, ItemID.BerserkerGlove, ItemID.Bezoar, ItemID.BlackBelt, ItemID.Blindfold, ItemID.CelestialEmblem, ItemID.MoonCharm, ItemID.MoonShell, ItemID.CelestialStone, ItemID.CelestialShell, ItemID.CobaltShield, ItemID.CountercurseMantra, ItemID.CrossNecklace, ItemID.DestroyerEmblem, ItemID.EyeoftheGolem, ItemID.FastClock, ItemID.FeralClaws, ItemID.FireGauntlet, ItemID.FleshKnuckles, ItemID.FrozenTurtleShell, ItemID.FrozenShield, ItemID.HandWarmer, ItemID.HeroShield, ItemID.HoneyComb, ItemID.MagicQuiver, ItemID.MagmaStone, ItemID.MechanicalGlove, ItemID.MedicatedBandage, ItemID.Megaphone, ItemID.MoonStone, ItemID.MoltenQuiver, ItemID.MoltenSkullRose, ItemID.Nazar, ItemID.ObsidianRose, ItemID.ObsidianShield, ItemID.ObsidianSkull, ItemID.ObsidianSkullRose, ItemID.PaladinsShield, ItemID.PanicNecklace, ItemID.PocketMirror, ItemID.PowerGlove, ItemID.PutridScent, ItemID.RangerEmblem, ItemID.ReconScope, ItemID.RifleScope, ItemID.Shackle, ItemID.SharkToothNecklace, ItemID.SniperScope, ItemID.SorcererEmblem, ItemID.StalkersQuiver, ItemID.StarCloak, ItemID.StarVeil, ItemID.StingerNecklace, ItemID.SummonerEmblem, ItemID.SunStone, ItemID.SweetheartNecklace, ItemID.ThePlan, ItemID.TitanGlove, ItemID.TrifoldMap, ItemID.Vitamins, ItemID.WarriorEmblem, ItemID.ApprenticeScarf, ItemID.SquireShield, ItemID.HuntressBuckler, ItemID.MonkBelt, ItemID.HerculesBeetle, ItemID.NecromanticScroll, ItemID.PapyrusScarab, ItemID.PygmyNecklace] },
                { "ACCESSORY_CONSTRUCTION", [ItemID.Toolbelt, ItemID.Toolbox, ItemID.PaintSprayer, ItemID.ExtendoGrip, ItemID.PortableCementMixer, ItemID.BrickLayer, ItemID.ArchitectGizmoPack, ItemID.ActuationAccessory, ItemID.AncientChisel, ItemID.HandOfCreation] },
                { "ACCESSORY_FISH", [ItemID.HighTestFishingLine, ItemID.AnglerEarring, ItemID.TackleBox, ItemID.AnglerTackleBag, ItemID.LavaFishingHook, ItemID.LavaproofTackleBag, ItemID.FishingBobber, ItemID.FishingBobberGlowingStar, ItemID.FishingBobberGlowingArgon, ItemID.FishingBobberGlowingKrypton, ItemID.FishingBobberGlowingLava, ItemID.FishingBobberGlowingViolet, ItemID.FishingBobberGlowingXenon, ItemID.FishingBobberGlowingRainbow] },
                { "ACCESSORY_YOYO", [ItemID.WhiteString, ItemID.RedString, ItemID.OrangeString, ItemID.YellowString, ItemID.LimeString, ItemID.GreenString, ItemID.TealString, ItemID.CyanString, ItemID.SkyBlueString, ItemID.BlueString, ItemID.PurpleString, ItemID.VioletString, ItemID.PinkString, ItemID.BlackString, ItemID.BrownString, ItemID.RainbowString, ItemID.BlackCounterweight, ItemID.YellowCounterweight, ItemID.BlueCounterweight, ItemID.RedCounterweight, ItemID.PurpleCounterweight, ItemID.GreenCounterweight, ItemID.YoYoGlove, ItemID.YoyoBag] },
                { "ACCESSORY_VANITY", [ItemID.JungleRose, ItemID.WinterCape, ItemID.MysteriousCape, ItemID.RedCape, ItemID.PrinceCape, ItemID.CrimsonCloak, ItemID.DiamondRing, ItemID.AngelHalo, ItemID.GingerBeard, ItemID.PartyBalloonAnimal, ItemID.BundleofBalloons, ItemID.FlameWakerBoots, ItemID.CritterShampoo, ItemID.BunnyTail, ItemID.FoxTail, ItemID.DogTail, ItemID.LizardTail, ItemID.UnicornHornHat, ItemID.HunterCloak, ItemID.RoyalScepter, ItemID.GlassSlipper, ItemID.RainbowCursor, ItemID.ShimmerMonolith, ItemID.BloodMoonMonolith, ItemID.VortexMonolith, ItemID.NebulaMonolith, ItemID.StardustMonolith, ItemID.SolarMonolith, ItemID.VoidMonolith] },
                { "ACCESSORY_MUSIC_BOX", [ItemID.MusicBox, ItemID.MusicBoxOverworldDay, ItemID.MusicBoxAltOverworldDay, ItemID.MusicBoxNight, ItemID.MusicBoxRain, ItemID.MusicBoxSnow, ItemID.MusicBoxIce, ItemID.MusicBoxDesert, ItemID.MusicBoxOcean, ItemID.MusicBoxOceanAlt, ItemID.MusicBoxSpace, ItemID.MusicBoxSpaceAlt, ItemID.MusicBoxUnderground, ItemID.MusicBoxAltUnderground, ItemID.MusicBoxMushrooms, ItemID.MusicBoxJungle, ItemID.MusicBoxCorruption, ItemID.MusicBoxUndergroundCorruption, ItemID.MusicBoxCrimson, ItemID.MusicBoxOWUndergroundCrimson, ItemID.MusicBoxTheHallow, ItemID.MusicBoxUndergroundHallow, ItemID.MusicBoxHell, ItemID.MusicBoxDungeon, ItemID.MusicBoxTemple, ItemID.MusicBoxBoss1, ItemID.MusicBoxBoss2, ItemID.MusicBoxBoss3, ItemID.MusicBoxBoss4, ItemID.MusicBoxBoss5, ItemID.MusicBoxDeerclops, ItemID.MusicBoxQueenSlime, ItemID.MusicBoxPlantera, ItemID.MusicBoxEmpressOfLight, ItemID.MusicBoxDukeFishron, ItemID.MusicBoxEerie, ItemID.MusicBoxEclipse, ItemID.MusicBoxGoblins, ItemID.MusicBoxPirates, ItemID.MusicBoxMartians, ItemID.MusicBoxPumpkinMoon, ItemID.MusicBoxFrostMoon, ItemID.MusicBoxTowers, ItemID.MusicBoxLunarBoss, ItemID.MusicBoxSandstorm, ItemID.MusicBoxDD2, ItemID.MusicBoxSlimeRain, ItemID.MusicBoxTownDay, ItemID.MusicBoxTownNight, ItemID.MusicBoxWindyDay, ItemID.MusicBoxStorm, ItemID.MusicBoxGraveyard, ItemID.MusicBoxUndergroundJungle, ItemID.MusicBoxJungleNight, ItemID.MusicBoxMorningRain, ItemID.MusicBoxUndergroundDesert, ItemID.MusicBoxShimmer, ItemID.MusicBoxOWRain, ItemID.MusicBoxOWDay, ItemID.MusicBoxOWNight, ItemID.MusicBoxOWUnderground, ItemID.MusicBoxOWDesert, ItemID.MusicBoxOWOcean, ItemID.MusicBoxOWMushroom, ItemID.MusicBoxOWDungeon, ItemID.MusicBoxOWSpace, ItemID.MusicBoxOWUnderworld, ItemID.MusicBoxOWSnow, ItemID.MusicBoxOWCorruption, ItemID.MusicBoxOWUndergroundCorruption, ItemID.MusicBoxOWCrimson, ItemID.MusicBoxOWUndergroundCrimson, ItemID.MusicBoxOWUndergroundSnow, ItemID.MusicBoxOWUndergroundHallow, ItemID.MusicBoxOWBloodMoon, ItemID.MusicBoxOWBoss2, ItemID.MusicBoxOWBoss1, ItemID.MusicBoxOWInvasion, ItemID.MusicBoxOWTowers, ItemID.MusicBoxOWMoonLord, ItemID.MusicBoxOWPlantera, ItemID.MusicBoxOWJungle, ItemID.MusicBoxOWWallOfFlesh, ItemID.MusicBoxOWHallow, ItemID.MusicBoxDayRemix, ItemID.MusicBoxCredits, ItemID.MusicBoxTitle, ItemID.MusicBoxTitleAlt] },
                { "ACCESSORY_GOLF_BALL", [ItemID.GolfBallDyedBlack, ItemID.GolfBallDyedBlue, ItemID.GolfBallDyedBrown, ItemID.GolfBallDyedCyan, ItemID.GolfBallDyedGreen, ItemID.GolfBallDyedLimeGreen, ItemID.GolfBallDyedOrange, ItemID.GolfBallDyedPink, ItemID.GolfBallDyedPurple, ItemID.GolfBallDyedRed, ItemID.GolfBallDyedSkyBlue, ItemID.GolfBallDyedTeal, ItemID.GolfBallDyedViolet, ItemID.GolfBallDyedYellow] },
                { "ACCESSORY_OTHER", [ItemID.ClothierVoodooDoll, ItemID.CoinRing, ItemID.DiscountCard, ItemID.FlowerBoots, ItemID.GoldRing, ItemID.GreedyRing, ItemID.CordageGuide, ItemID.GuideVoodooDoll, ItemID.JellyfishNecklace, ItemID.LuckyCoin, ItemID.DontStarveShaderItem, ItemID.SpectreGoggles, ItemID.TreasureMagnet, ItemID.ShimmerCloak, ItemID.JimsDroneVisor] }
            };

            // Rare Movement
            RegisterAchievement("ACCESSORY_BALLOON_PUFFERFISH", ItemCatchCondition.Catch(reqs, ItemID.BalloonPufferfish), AchievementCategory.Collector);
            RegisterAchievement("ACCESSORY_FROG_LEG", ItemCatchCondition.Catch(reqs, ItemID.FrogLeg), AchievementCategory.Collector);
            RegisterAchievement("ACCESSORY_MOON_CHARM", NpcDropCondition.Drop(reqs, NPCID.Werewolf, ItemID.MoonCharm), AchievementCategory.Collector);
            
            // Rare Wings
            RegisterAchievement("ACCESSORY_FIN_WINGS", NpcGiftCondition.Gift(reqs, NPCID.Angler, ItemID.FinWings), AchievementCategory.Collector);
            
            // Rare Informational
            RegisterAchievement("ACCESSORY_DEPTH_METER", NpcDropCondition.Drop(reqs, NPCID.None, ItemID.DepthMeter), AchievementCategory.Collector);
            RegisterAchievement("ACCESSORY_COMPASS", NpcDropCondition.Drop(reqs, NPCID.None, ItemID.Compass), AchievementCategory.Collector);
            RegisterAchievement("ACCESSORY_TALLY_COUNTER", NpcDropCondition.Drop(reqs, NPCID.None, ItemID.TallyCounter), AchievementCategory.Collector);
            
            // Rare Health/Mana
            RegisterAchievement("ACCESSORY_NATURES_GIFT", BreakAndGrabItem(reqs, ItemID.NaturesGift), false, AchievementCategory.Collector);
            
            // Rare Combat
            RegisterAchievement("ACCESSORY_FROZEN_TURTLE_SHELL", NpcDropCondition.Drop(reqs, NPCID.IceTortoise, ItemID.FrozenTurtleShell), AchievementCategory.Collector);
            RegisterAchievement("ACCESSORY_MAGIC_QUIVER", NpcDropCondition.Drop(reqs, NPCID.SkeletonArcher, ItemID.MagicQuiver), AchievementCategory.Collector);
            RegisterAchievement("ACCESSORY_SHARK_TOOTH_NECKLACE", NpcDropCondition.Drop(reqs, NPCID.None, ItemID.SharkToothNecklace), AchievementCategory.Collector);
            
            // Rare Other
            RegisterAchievement("ACCESSORY_CLOTHIER_VOODOO_DOLL", NpcDropCondition.Drop(reqs, NPCID.None, ItemID.ClothierVoodooDoll), AchievementCategory.Collector);
            RegisterAchievement("ACCESSORY_JELLYFISH_NECKLACE", NpcDropCondition.Drop(reqs, NPCID.None, ItemID.JellyfishNecklace), AchievementCategory.Collector);
            
            // Rare Vanity
            RegisterAchievement("ACCESSORY_JUNGLE_ROSE", BreakAndGrabItem(reqs, ItemID.JungleRose), false, AchievementCategory.Collector);

            // Rare Craft
            RegisterAchievement("ACCESSORY_ARCTIC_DIVING_GEAR", ItemCraftCondition.Craft(reqs, ItemID.ArcticDivingGear), AchievementCategory.Collector);
            RegisterAchievement("ACCESSORY_BUNDLE_HORSESHOE_BALLOONS", ItemCraftCondition.Craft(reqs, ItemID.HorseshoeBundle), AchievementCategory.Collector);
            RegisterAchievement("ACCESSORY_CELESTIAL_CUFFS", ItemCraftCondition.Craft(reqs, ItemID.CelestialCuffs), AchievementCategory.Collector);
            RegisterAchievement("ACCESSORY_CELESTIAL_EMBLEM", ItemCraftCondition.Craft(reqs, ItemID.CelestialEmblem), AchievementCategory.Collector);
            RegisterAchievement("ACCESSORY_CELESTIAL_SHELL", ItemCraftCondition.Craft(reqs, ItemID.CelestialShell), AchievementCategory.Collector);
            RegisterAchievement("ACCESSORY_FAIRY_BOOTS", ItemCraftCondition.Craft(reqs, ItemID.FairyBoots), AchievementCategory.Collector);
            RegisterAchievement("ACCESSORY_FIRE_GAUNTLET", ItemCraftCondition.Craft(reqs, ItemID.FireGauntlet), AchievementCategory.Collector);
            RegisterAchievement("ACCESSORY_FROG_GEAR", ItemCraftCondition.Craft(reqs, ItemID.FrogGear), AchievementCategory.Collector);
            RegisterAchievement("ACCESSORY_GREEDY_RING", ItemCraftCondition.Craft(reqs, ItemID.GreedyRing), AchievementCategory.Collector);
            RegisterAchievement("ACCESSORY_HAND_OF_CREATION", ItemCraftCondition.Craft(reqs, ItemID.HandOfCreation), AchievementCategory.Collector);
            RegisterAchievement("ACCESSORY_HELLFIRE_TREADS", ItemCraftCondition.Craft(reqs, ItemID.HellfireTreads), AchievementCategory.Collector);
            RegisterAchievement("ACCESSORY_LAVAPROOF_TACKLE_BAG", ItemCraftCondition.Craft(reqs, ItemID.LavaproofTackleBag), AchievementCategory.Collector);
            RegisterAchievement("ACCESSORY_MASTER_NINJA_GEAR", ItemCraftCondition.Craft(reqs, ItemID.MasterNinjaGear), AchievementCategory.Collector);
            RegisterAchievement("ACCESSORY_SHELLPHONE", ItemCraftCondition.Craft(reqs, ItemID.ShellphoneDummy), AchievementCategory.Collector);
            RegisterAchievement("ACCESSORY_SNIPER_SCOPE", ItemCraftCondition.Craft(reqs, ItemID.SniperScope), AchievementCategory.Collector);
            RegisterAchievement("ACCESSORY_THE_GRAND_DESIGN", ItemCraftCondition.Craft(reqs, ItemID.WireKite), AchievementCategory.Collector);
            RegisterAchievement("ACCESSORY_ULTRA_ABSORBANT_SPONGE", ItemCraftCondition.Craft(reqs, ItemID.UltraAbsorbantSponge), AchievementCategory.Collector);

            foreach (var group in Accessories)
                RegisterAchievement(group.Key, ItemGrabCondition.GrabAll(reqs, group.Value), group.Value.Length > 1, AchievementCategory.Collector);
        }

        /// <summary>
        /// Register mount achievements
        /// </summary>
        /// <param name="reqs">Common achievement requirements</param>
        private void RegisterMountAchievements(ConditionReqs reqs)
        {
            // Verified w/ https://terraria.wiki.gg/wiki/Mounts
            int[] Mounts = [ItemID.SlimySaddle, ItemID.HoneyedGoggles, ItemID.HardySaddle, ItemID.FuzzyCarrot, ItemID.PogoStick, ItemID.GolfCart, ItemID.MolluskWhistle, ItemID.PaintedHorseSaddle, ItemID.MajesticHorseSaddle, ItemID.DarkHorseSaddle, ItemID.SuperheatedBlood, ItemID.AncientHorn, ItemID.WolfMountItem, ItemID.BlessedApple, ItemID.ScalyTruffle, ItemID.QueenSlimeMountSaddle, ItemID.ReindeerBells, ItemID.BrainScrambler, ItemID.CosmicCarKey, ItemID.DrillContainmentUnit];

            RegisterAchievement("MOUNT_BEE", ItemGrabCondition.Grab(reqs, ItemID.HoneyedGoggles), AchievementCategory.Collector);
            RegisterAchievement("MOUNT_TURTLE", ItemOpenCondition.Open(reqs, ItemID.None, ItemID.HardySaddle), AchievementCategory.Collector);
            RegisterAchievement("MOUNT_GOLF_CART", NpcBuyCondition.Buy(reqs, NPCID.Golfer, ItemID.GolfCart), AchievementCategory.Collector);
            RegisterAchievement("MOUNT_BASILISK", NpcDropCondition.Drop(reqs, NPCID.DesertBeast, ItemID.AncientHorn), AchievementCategory.Collector);
            RegisterAchievement("MOUNT_WOLF", NpcDropCondition.Drop(reqs, NPCID.Wolf, ItemID.WolfMountItem), AchievementCategory.Collector);
            RegisterAchievement("MOUNT_UNICORN", NpcDropCondition.Drop(reqs, NPCID.None, ItemID.BlessedApple), AchievementCategory.Collector);
            RegisterAchievement("MOUNT_PIGRON", ItemCatchCondition.Catch(reqs, ItemID.ScalyTruffle), AchievementCategory.Collector);
            RegisterAchievement("MOUNT_RUDOLPH", NpcDropCondition.Drop(reqs, NPCID.IceQueen, ItemID.ReindeerBells), AchievementCategory.Collector);
            RegisterAchievement("MOUNT_DCU", ItemCraftCondition.Craft(reqs, ItemID.DrillContainmentUnit), AchievementCategory.Collector);
            RegisterAchievement("MOUNT", ItemGrabCondition.GrabAll(reqs, Mounts), true, AchievementCategory.Collector);
        }

        /// <summary>
        /// Register minecart achievements
        /// </summary>
        /// <param name="reqs">Common achievement requirements</param>
        private void RegisterMinecartAchievements(ConditionReqs reqs)
        {
            // Verified w/ https://terraria.wiki.gg/wiki/Minecarts
            int[] Minecarts = [ItemID.Minecart, ItemID.DesertMinecart, ItemID.FishMinecart, ItemID.BeeMinecart, ItemID.LadybugMinecart, ItemID.PigronMinecart, ItemID.SunflowerMinecart, ItemID.HellMinecart, ItemID.ShroomMinecart, ItemID.AmethystMinecart, ItemID.TopazMinecart, ItemID.SapphireMinecart, ItemID.EmeraldMinecart, ItemID.RubyMinecart, ItemID.DiamondMinecart, ItemID.AmberMinecart, ItemID.BeetleMinecart, ItemID.MeowmereMinecart, ItemID.PartyMinecart, ItemID.PirateMinecart, ItemID.SteampunkMinecart, ItemID.CoffinMinecart, ItemID.DiggingMoleMinecart, ItemID.FartMinecart, ItemID.TerraFartMinecart];

            RegisterAchievement("MINECART_FISH", NpcGiftCondition.Gift(reqs, NPCID.Angler, ItemID.FishMinecart), AchievementCategory.Collector);
            RegisterAchievement("MINECART_PIGRON", NpcDropCondition.Drop(reqs, NPCID.None, ItemID.PigronMinecart), AchievementCategory.Collector);
            RegisterAchievement("MINECART", ItemGrabCondition.GrabAll(reqs, Minecarts), true, AchievementCategory.Collector);
        }

        /// <summary>
        /// Register vanity achievements
        /// </summary>
        /// <param name="reqs">Common achievement requirements</param>
        private void RegisterVanityAchievements(ConditionReqs reqs)
        {
            // Verified w/ https://terraria.wiki.gg/wiki/Vanity_items
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
                { "Fish Costume", [ItemID.FishCostumeMask, ItemID.FishCostumeShirt, ItemID.FishCostumeFinskirt] },
                { "Floret Protector", [ItemID.FloretProtectorHelmet, ItemID.FloretProtectorChestplate, ItemID.FloretProtectorLegs] },
                { "Fox", [ItemID.FoxEars, ItemID.FoxTail] },
                { "Funeral", [ItemID.FuneralHat, ItemID.FuneralCoat, ItemID.FuneralPants] },
                { "Gentleman's", [ItemID.WilsonBeardShort, ItemID.WilsonBeardLong, ItemID.WilsonBeardMagnificent, ItemID.WilsonShirt, ItemID.WilsonPants] },
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

            // Verified w/ https://terraria.wiki.gg/wiki/Vanity_items
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
                { "Pumpkin", [ItemID.PumpkinMask, ItemID.PumpkinShirt, ItemID.PumpkinPants] },
                { "Reaper", [ItemID.ReaperHood, ItemID.ReaperRobe] },
                { "Robot", [ItemID.RobotMask, ItemID.RobotShirt, ItemID.RobotPants] },
                { "Space Creature", [ItemID.SpaceCreatureMask, ItemID.SpaceCreatureShirt, ItemID.SpaceCreaturePants] },
                { "Treasure Hunter", [ItemID.TreasureHunterShirt, ItemID.TreasureHunterPants] },
                { "Unicorn", [ItemID.UnicornMask, ItemID.UnicornShirt, ItemID.UnicornPants] },
                { "Vampire", [ItemID.VampireMask, ItemID.VampireShirt, ItemID.VampirePants] },
                { "Witch", [ItemID.WitchHat, ItemID.WitchDress, ItemID.WitchBoots] },
                { "Wolf", [ItemID.WolfMask, ItemID.WolfShirt, ItemID.WolfPants] }
            };

            // Verified w/ https://terraria.wiki.gg/wiki/Vanity_items
            Dictionary<string, int[]> VanityChristmas = new()
            {
                { "Mrs. Claus", [ItemID.MrsClauseHat, ItemID.MrsClauseShirt, ItemID.MrsClauseHeels] },
                { "Parka", [ItemID.ParkaHood, ItemID.ParkaCoat, ItemID.ParkaPants] },
                { "Santa", [ItemID.SantaHat, ItemID.SantaShirt, ItemID.SantaPants] },
                { "Tree", [ItemID.TreeMask, ItemID.TreeShirt, ItemID.TreeTrunks] }
            };

            // Verified w/ https://terraria.wiki.gg/wiki/Vanity_items
            Dictionary<string, int[]> VanityPieces = new()
            {
                { "VANITY_MASK", [ItemID.KingSlimeMask, ItemID.EyeMask, ItemID.EaterMask, ItemID.BrainMask, ItemID.BeeMask, ItemID.DeerclopsMask, ItemID.SkeletronMask, ItemID.FleshMask, ItemID.QueenSlimeMask, ItemID.TwinMask, ItemID.DestroyerMask, ItemID.SkeletronPrimeMask, ItemID.PlanteraMask, ItemID.GolemMask, ItemID.FairyQueenMask, ItemID.DukeFishronMask, ItemID.BossMaskCultist, ItemID.BossMaskMoonlord, ItemID.BossMaskDarkMage, ItemID.BossMaskOgre, ItemID.BossMaskBetsy] },
                { "VANITY_OTHER", [ItemID.BadgersHat, ItemID.BallaHat, ItemID.Beanie, ItemID.BunnyHood, ItemID.CatEars, ItemID.DeadMansSweater, ItemID.DemonHorns, ItemID.DevilHorns, ItemID.DizzyHat, ItemID.EngineeringHelmet, ItemID.EyePatch, ItemID.Eyebrella, ItemID.Fedora, ItemID.Fez, ItemID.FishBowl, ItemID.GangstaHat, ItemID.GarlandHat, ItemID.GiantBow, ItemID.GoblorcEar, ItemID.GoldCrown, ItemID.GoldGoldfishBowl, ItemID.GuyFawkesMask, ItemID.HeartHairpin, ItemID.HiTekSunglasses, ItemID.JackOLanternMask, ItemID.JimsCap, ItemID.Kimono, ItemID.MimeMask, ItemID.MoonMask, ItemID.MushroomCap, ItemID.PandaEars, ItemID.PartyHat, ItemID.PeddlersHat, ItemID.PlatinumCrown, ItemID.RabbitOrder, ItemID.ReindeerAntlers, ItemID.Robe, ItemID.RobotHat, ItemID.RockGolemHead, ItemID.SWATHelmet, ItemID.Skull, ItemID.SnowHat, ItemID.StarHairpin, ItemID.SteampunkGoggles, ItemID.SummerHat, ItemID.SunMask, ItemID.Sunglasses, ItemID.TamOShanter, ItemID.UglySweater, ItemID.UmbrellaHat, ItemID.VulkelfEar, ItemID.WizardsHat] }
            };

            // Rare Sets
            RegisterAchievement("VANITY_HERO", ItemCraftCondition.CraftAll(reqs, VanitySets["Hero's"]), true, AchievementCategory.Collector);
            RegisterAchievement("VANITY_LAMIA", NpcDropCondition.DropAll(reqs, NPCID.None, VanitySets["Lamia"]), true, AchievementCategory.Collector);
            RegisterAchievement("VANITY_MUMMY", NpcDropCondition.DropAll(reqs, NPCID.None, VanitySets["Mummy"]), true, AchievementCategory.Collector);
            RegisterAchievement("VANITY_PEDGUIN", NpcDropCondition.DropAll(reqs, NPCID.None, VanitySets["Pedguin's"]), true, AchievementCategory.Collector);
            RegisterAchievement("VANITY_PLUMBER", NpcDropCondition.Drop(reqs, NPCID.FireImp, ItemID.PlumbersHat), AchievementCategory.Collector);

            // Unique Halloween Sets
            RegisterAchievement("VANITY_CREEPER", ItemOpenCondition.OpenAll(reqs, ItemID.GoodieBag, VanityHalloween["Creeper"]), true, AchievementCategory.Collector);

            // Rare Pieces
            RegisterAchievement("VANITY_ANGEL_HALO", NpcBuyCondition.Buy(reqs, NPCID.TravellingMerchant, ItemID.AngelHalo), AchievementCategory.Collector);
            RegisterAchievement("VANITY_BADGERS_HAT", NpcDropCondition.Drop(reqs, NPCID.None, ItemID.BadgersHat), AchievementCategory.Collector);
            RegisterAchievement("VANITY_DEAD_MANS_SWEATER", ItemGrabCondition.Grab(reqs, ItemID.DeadMansSweater), AchievementCategory.Collector);
            RegisterAchievement("VANITY_GINGER_BEARD", ItemOpenCondition.Open(reqs, ItemID.None, ItemID.GingerBeard), AchievementCategory.Collector);
            RegisterAchievement("VANITY_JIMS_HAT", ItemGrabCondition.Grab(reqs, ItemID.JimsCap), AchievementCategory.Collector);
            RegisterAchievement("VANITY_ROBOT_HAT", NpcDropCondition.Drop(reqs, NPCID.None, ItemID.RobotHat), AchievementCategory.Collector);
            RegisterAchievement("VANITY_SKULL", NpcDropCondition.Drop(reqs, NPCID.None, ItemID.Skull), AchievementCategory.Collector);
            RegisterAchievement("VANITY_UMBRELLA_HAT", NpcDropCondition.Drop(reqs, NPCID.UmbrellaSlime, ItemID.UmbrellaHat), AchievementCategory.Collector);

            List<CustomAchievementCondition> sets = [];
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

            RegisterAchievement("VANITY_MASK", NpcDropCondition.DropAll(reqs, NPCID.None, VanityPieces["VANITY_MASK"]), true, AchievementCategory.Collector);
            RegisterAchievement("VANITY_OTHER", ItemGrabCondition.GrabAll(reqs, VanityPieces["VANITY_OTHER"]), true, AchievementCategory.Collector);
        }

        /// <summary>
        /// Register pet achievements
        /// </summary>
        /// <param name="reqs">Common achievement requirements</param>
        private void RegisterPetAchievements(ConditionReqs reqs)
        {
            // Verified w/ https://terraria.wiki.gg/wiki/Pets
            Dictionary<string, int[]> Pets = new()
            {
                { "PET", [ItemID.AmberMosquito, ItemID.EatersBone, ItemID.BoneRattle, ItemID.BabyGrinchMischiefWhistle, ItemID.Nectar, ItemID.HellCake, ItemID.Fish, ItemID.BambooLeaf, ItemID.BoneKey, ItemID.ToySled, ItemID.StrangeGlowingMushroom, ItemID.FullMoonSqueakyToy, ItemID.BerniePetItem, ItemID.UnluckyYarn, ItemID.BlueEgg, ItemID.GlowTulip, ItemID.ChesterPetItem, ItemID.CompanionCube, ItemID.CursedSapling, ItemID.DirtiestBlock, ItemID.BallOfFuseWire, ItemID.CelestialWand, ItemID.EyeSpring, ItemID.ExoticEasternChewToy, ItemID.BedazzledNectar, ItemID.GlommerPetItem, ItemID.DD2PetDragon, ItemID.JunimoPetItem, ItemID.BirdieRattle, ItemID.LizardEgg, ItemID.TartarSauce, ItemID.ParrotCracker, ItemID.PigPetItem, ItemID.MudBud, ItemID.DD2PetGato, ItemID.DogWhistle, ItemID.Seedling, ItemID.SpiderEgg, ItemID.OrnateShadowKey, ItemID.SharkBait, ItemID.SpiffoPlush, ItemID.MagicalPumpkinSeed, ItemID.EucaluptusSap, ItemID.TikiTotem, ItemID.Seaweed, ItemID.LightningCarrot, ItemID.ZephyrFish] },
                { "PET_LIGHT", [ItemID.ShadowOrb, ItemID.CrimsonHeart, ItemID.MagicLantern, ItemID.FairyBell, ItemID.DD2OgrePetItem, ItemID.WispinaBottle] }
            };

            RegisterAchievement("PET_BABY_DINOSAUR", ItemExtractCondition.Extract(reqs, ItemID.AmberMosquito), AchievementCategory.Collector);
            RegisterAchievement("PET_BABY_EATER", ItemGrabCondition.Grab(reqs, ItemID.EatersBone), AchievementCategory.Collector);
            RegisterAchievement("PET_BABY_FACE_MONSTER", ItemGrabCondition.Grab(reqs, ItemID.BoneRattle), AchievementCategory.Collector);
            RegisterAchievement("PET_BABY_GRINCH", NpcDropCondition.Drop(reqs, NPCID.IceQueen, ItemID.BabyGrinchMischiefWhistle), AchievementCategory.Collector);
            RegisterAchievement("PET_BABY_HORNET", ItemGrabCondition.Grab(reqs, ItemID.Nectar), AchievementCategory.Collector);
            RegisterAchievement("PET_BABY_SKELETRON_HEAD", NpcDropCondition.Drop(reqs, NPCID.DungeonGuardian, ItemID.BoneKey), AchievementCategory.Collector);
            RegisterAchievement("PET_BABY_SNOWMAN", NpcDropCondition.Drop(reqs, NPCID.IceMimic, ItemID.ToySled), AchievementCategory.Collector);
            RegisterAchievement("PET_BLACK_CAT", ItemOpenCondition.Open(reqs, ItemID.GoodieBag, ItemID.UnluckyYarn), AchievementCategory.Collector);
            RegisterAchievement("PET_CAVELING_GARDENER", BreakAndGrabItem(reqs, ItemID.GlowTulip), false, AchievementCategory.Collector);
            RegisterAchievement("PET_THE_DIRTIEST_BLOCK", BreakAndGrabItem(reqs, ItemID.DirtiestBlock), false, AchievementCategory.Collector);
            RegisterAchievement("PET_JUNIMO", NpcGiftCondition.Gift(reqs, NPCID.None, ItemID.JunimoPetItem), AchievementCategory.Collector);
            RegisterAchievement("PET_LIZARD", NpcDropCondition.Drop(reqs, NPCID.None, ItemID.LizardEgg), AchievementCategory.Collector);
            RegisterAchievement("PET_MINI_MINOTAUR", ItemOpenCondition.Open(reqs, ItemID.None, ItemID.TartarSauce), AchievementCategory.Collector);
            RegisterAchievement("PET_PUPPY", ItemOpenCondition.Open(reqs, ItemID.Present, ItemID.DogWhistle), AchievementCategory.Collector);
            RegisterAchievement("PET_SAPLING", ItemGrabCondition.Grab(reqs, ItemID.Seedling), AchievementCategory.Collector);
            RegisterAchievement("PET_SPIFFO", NpcDropCondition.Drop(reqs, NPCID.None, ItemID.SpiffoPlush), AchievementCategory.Collector);
            RegisterAchievement("PET_SQUASHLING", BreakAndGrabItem(reqs, ItemID.MagicalPumpkinSeed), false, AchievementCategory.Collector);
            RegisterAchievement("PET_SUGAR_GLIDER", ItemShakeCondition.Shake(reqs, ItemID.EucaluptusSap), AchievementCategory.Collector);
            RegisterAchievement("PET_ZEPHYR_FISH", ItemCatchCondition.Catch(reqs, ItemID.ZephyrFish), AchievementCategory.Collector);
            RegisterAchievement("PET_WISP", NpcDropCondition.Drop(reqs, NPCID.None, ItemID.WispinaBottle), AchievementCategory.Collector);

            foreach (var group in Pets)
                RegisterAchievement(group.Key, ItemGrabCondition.GrabAll(reqs, group.Value), group.Value.Length > 1, AchievementCategory.Collector);
        }

        /// <summary>
        /// Register banner achievements
        /// </summary>
        /// <param name="reqs">Common achievement requirements</param>
        private void RegisterBannerAchievements(ConditionReqs reqs)
        {
            // Verified w/ https://terraria.wiki.gg/wiki/Banners_(enemy)
            Dictionary<string, int[]> Banners = new()
            {
                { "BANNER_SLIME", [ItemID.SlimeBanner, ItemID.GreenSlimeBanner, ItemID.PurpleSlimeBanner, ItemID.UmbrellaSlimeBanner, ItemID.RedSlimeBanner, ItemID.YellowSlimeBanner, ItemID.BlackSlimeBanner, ItemID.MotherSlimeBanner, ItemID.DungeonSlimeBanner, ItemID.PinkyBanner, ItemID.JungleSlimeBanner, ItemID.SpikedJungleSlimeBanner, ItemID.IceSlimeBanner, ItemID.SpikedIceSlimeBanner, ItemID.SandSlimeBanner, ItemID.LavaSlimeBanner, ItemID.ShimmerSlimeBanner, ItemID.ToxicSludgeBanner, ItemID.CorruptSlimeBanner, ItemID.SlimerBanner, ItemID.CrimslimeBanner, ItemID.GastropodBanner, ItemID.IlluminantSlimeBanner, ItemID.RainbowSlimeBanner] },
            
                // Environments
                { "BANNER_CAVERN", [ItemID.BatBanner, ItemID.CochinealBeetleBanner, ItemID.CrawdadBanner, ItemID.GiantShellyBanner, ItemID.WormBanner, ItemID.NypmhBanner, ItemID.SalamanderBanner, ItemID.SkeletonBanner, ItemID.TimBanner, ItemID.UndeadMinerBanner, ItemID.JellyfishBanner, ItemID.ArmoredSkeletonBanner, ItemID.GiantBatBanner, ItemID.MimicBanner, ItemID.RockGolemBanner, ItemID.RuneWizardBanner, ItemID.SkeletonArcherBanner, ItemID.AnglerFishBanner, ItemID.GreenJellyfishBanner] },
                { "BANNER_CORRUPTION", [ItemID.DevourerBanner, ItemID.EaterofSoulsBanner, ItemID.ClingerBanner, ItemID.BigMimicCorruptionBanner, ItemID.CorruptorBanner, ItemID.CursedHammerBanner, ItemID.DarkMummyBanner, ItemID.WorldFeederBanner] },
                { "BANNER_CRIMSON", [ItemID.BloodCrawlerBanner, ItemID.CrimeraBanner, ItemID.FaceMonsterBanner, ItemID.BloodFeederBanner, ItemID.BloodJellyBanner, ItemID.BloodMummyBanner, ItemID.CrimsonAxeBanner, ItemID.BigMimicCrimsonBanner, ItemID.FloatyGrossBanner, ItemID.HerplingBanner, ItemID.IchorStickerBanner] },
                { "BANNER_DESERT", [ItemID.AntlionBanner, ItemID.WalkingAntlionBanner, ItemID.LarvaeAntlionBanner, ItemID.FlyingAntlionBanner, ItemID.TombCrawlerBanner, ItemID.VultureBanner, ItemID.DesertBasiliskBanner, ItemID.DesertDjinnBanner, ItemID.DuneSplicerBanner, ItemID.DesertGhoulBanner, ItemID.DesertLamiaBanner, ItemID.MummyBanner, ItemID.RavagerScorpionBanner] },
                { "BANNER_DUNGEON", [ItemID.AngryBonesBanner, ItemID.CursedSkullBanner, ItemID.SkeletonMageBanner, ItemID.BlueArmoredBonesBanner, ItemID.RustyArmoredBonesBanner, ItemID.HellArmoredBonesBanner, ItemID.DiablolistBanner, ItemID.NecromancerBanner, ItemID.RaggedCasterBanner, ItemID.BoneLeeBanner, ItemID.SkeletonCommandoBanner, ItemID.SkeletonSniperBanner, ItemID.TacticalSkeletonBanner, ItemID.DungeonSpiritBanner, ItemID.GiantCursedSkullBanner, ItemID.PaladinBanner] },
                { "BANNER_GLOWING_MUSHROOM", [ItemID.AnomuraFungusBanner, ItemID.FungiBulbBanner, ItemID.MushiLadybugBanner, ItemID.SporeBatBanner, ItemID.SporeSkeletonBanner, ItemID.SporeZombieBanner, ItemID.FungoFishBanner] },
                { "BANNER_GRANITE_CAVE", [ItemID.GraniteFlyerBanner, ItemID.GraniteGolemBanner] },
                { "BANNER_HALLOW", [ItemID.ChaosElementalBanner, ItemID.EnchantedSwordBanner, ItemID.BigMimicHallowBanner, ItemID.IlluminantBatBanner, ItemID.LightMummyBanner, ItemID.PixieBanner, ItemID.UnicornBanner] },
                { "BANNER_JUNGLE", [ItemID.DoctorBonesBanner, ItemID.HornetBanner, ItemID.JungleBatBanner, ItemID.LacBeetleBanner, ItemID.ManEaterBanner, ItemID.SnatcherBanner, ItemID.PiranhaBanner, ItemID.AngryTrapperBanner, ItemID.DerplingBanner, ItemID.GiantFlyingFoxBanner, ItemID.TortoiseBanner, ItemID.JungleCreeperBanner, ItemID.MossHornetBanner, ItemID.MothBanner, ItemID.ArapaimaBanner, ItemID.FlyingSnakeBanner, ItemID.LihzahrdBanner] },
                { "BANNER_MARBLE_CAVE", [ItemID.GreekSkeletonBanner, ItemID.MedusaBanner] },
                { "BANNER_METEORITE", [ItemID.MeteorHeadBanner] },
                { "BANNER_SNOW", [ItemID.CyanBeetleBanner, ItemID.IceBatBanner, ItemID.PenguinBanner, ItemID.SnowFlinxBanner, ItemID.UndeadVikingBanner, ItemID.ZombieEskimoBanner, ItemID.ArmoredVikingBanner, ItemID.IceElementalBanner, ItemID.IceTortoiseBanner, ItemID.IcyMermanBanner, ItemID.PigronBanner, ItemID.WolfBanner] },
                { "BANNER_SPIDER_CAVE", [ItemID.SpiderBanner, ItemID.BlackRecluseBanner] },
                { "BANNER_SURFACE", [ItemID.BirdBanner, ItemID.BunnyBanner, ItemID.GoldfishBanner, ItemID.ZombieBanner, ItemID.DemonEyeBanner, ItemID.GoblinScoutBanner, ItemID.GnomeBanner, ItemID.HarpyBanner, ItemID.CrabBanner, ItemID.PinkJellyfishBanner, ItemID.SeaSnailBanner, ItemID.SharkBanner, ItemID.SquidBanner, ItemID.PossessedArmorBanner, ItemID.WanderingEyeBanner, ItemID.WraithBanner, ItemID.WerewolfBanner, ItemID.WyvernBanner] },
                { "BANNER_UNDERWORLD", [ItemID.BoneSerpentBanner, ItemID.DemonBanner, ItemID.FireImpBanner, ItemID.HellbatBanner, ItemID.LavaBatBanner, ItemID.RedDevilBanner] },

                // Events
                { "BANNER_BLOOD_MOON", [ItemID.BloodZombieBanner, ItemID.CorruptBunnyBanner, ItemID.CorruptGoldfishBanner, ItemID.CorruptPenguinBanner, ItemID.DripplerBanner, ItemID.TheGroomBanner, ItemID.TheBrideBanner, ItemID.CrimsonBunnyBanner, ItemID.CrimsonGoldfishBanner, ItemID.CrimsonPenguinBanner, ItemID.EyeballFlyingFishBanner, ItemID.ZombieMermanBanner, ItemID.ClownBanner, ItemID.BloodEelBanner, ItemID.BloodSquidBanner, ItemID.GoblinSharkBanner, ItemID.BloodNautilusBanner] },
                { "BANNER_FROST_LEGION", [ItemID.MisterStabbyBanner, ItemID.SnowBallaBanner, ItemID.SnowmanGangstaBanner] },
                { "BANNER_FROST_MOON", [ItemID.ElfArcherBanner, ItemID.ElfCopterBanner, ItemID.FlockoBanner, ItemID.GingerbreadManBanner, ItemID.KrampusBanner, ItemID.NutcrackerBanner, ItemID.PresentMimicBanner, ItemID.YetiBanner, ItemID.ZombieElfBanner] },
                { "BANNER_GOBLIN_ARMY", [ItemID.GoblinArcherBanner, ItemID.GoblinPeonBanner, ItemID.GoblinSorcererBanner, ItemID.GoblinThiefBanner, ItemID.GoblinWarriorBanner, ItemID.GoblinSummonerBanner] },
                { "BANNER_HALLOWEEN", [ItemID.RavenBanner, ItemID.GhostBanner, ItemID.HoppinJackBanner] },
                { "BANNER_LUNAR_EVENTS", [ItemID.BlueCultistArcherBanner, ItemID.BlueCultistCasterBanner, ItemID.VortexHornetBanner, ItemID.VortexLarvaBanner, ItemID.VortexHornetQueenBanner, ItemID.VortexRiflemanBanner, ItemID.VortexSoldierBanner, ItemID.NebulaHeadcrabBanner, ItemID.NebulaBeastBanner, ItemID.NebulaBrainBanner, ItemID.NebulaSoldierBanner, ItemID.StardustJellyfishBanner, ItemID.StardustWormBanner, ItemID.StardustSmallCellBanner, ItemID.StardustLargeCellBanner, ItemID.StardustSoldierBanner, ItemID.StardustSpiderBanner, ItemID.SolarCoriteBanner, ItemID.SolarCrawltipedeBanner, ItemID.SolarDrakomireBanner, ItemID.SolarDrakomireRiderBanner, ItemID.SolarSolenianBanner, ItemID.SolarSrollerBanner] },
                { "BANNER_MARTIAN_MADNESS", [ItemID.MartianBrainscramblerBanner, ItemID.MartianDroneBanner, ItemID.MartianEngineerBanner, ItemID.MartianGigazapperBanner, ItemID.MartianGreyGruntBanner, ItemID.MartianOfficerBanner, ItemID.MartianRaygunnerBanner, ItemID.MartianScutlixGunnerBanner, ItemID.MartianTeslaTurretBanner, ItemID.MartianWalkerBanner, ItemID.ScutlixBanner] },
                { "BANNER_OLD_ONES_ARMY", [ItemID.DD2JavelinThrowerBanner, ItemID.DD2GoblinBanner, ItemID.DD2GoblinBomberBanner, ItemID.DD2WyvernBanner, ItemID.DD2SkeletonBanner, ItemID.DD2DrakinBanner, ItemID.DD2LightningBugBanner, ItemID.DD2KoboldBanner, ItemID.DD2KoboldFlyerBanner, ItemID.DD2WitherBeastBanner] },
                { "BANNER_PIRATE_INVASION", [ItemID.ParrotBanner, ItemID.PirateCaptainBanner, ItemID.PirateCorsairBanner, ItemID.PirateCrossbowerBanner, ItemID.PirateDeadeyeBanner, ItemID.PirateBanner] },
                { "BANNER_PUMPKIN_MOON", [ItemID.HeadlessHorsemanBanner, ItemID.HellhoundBanner, ItemID.PoltergeistBanner, ItemID.ScarecrowBanner, ItemID.SplinterlingBanner] },
                { "BANNER_RAIN_BLIZZARD", [ItemID.FlyingFishBanner, ItemID.RaincoatZombieBanner, ItemID.AngryNimbusBanner, ItemID.IceGolemBanner] },
                { "BANNER_SANDSTORM", [ItemID.TumbleweedBanner, ItemID.SandElementalBanner, ItemID.SandsharkBanner, ItemID.SandsharkHallowedBanner, ItemID.SandsharkCorruptBanner, ItemID.SandsharkCrimsonBanner] },
                { "BANNER_SOLAR_ECLIPSE", [ItemID.ButcherBanner, ItemID.CreatureFromTheDeepBanner, ItemID.DeadlySphereBanner, ItemID.DrManFlyBanner, ItemID.EyezorBanner, ItemID.FrankensteinBanner, ItemID.FritzBanner, ItemID.MothronBanner, ItemID.NailheadBanner, ItemID.PsychoBanner, ItemID.ReaperBanner, ItemID.SwampThingBanner, ItemID.ThePossessedBanner, ItemID.VampireBanner] },
                { "BANNER_WINDY_DAY", [ItemID.DandelionBanner] }
            };

            foreach (var group in Banners)
                RegisterAchievement(group.Key, NpcDropCondition.DropAll(reqs, NPCID.None, group.Value), group.Value.Length > 1, AchievementCategory.Collector);
        }

        /// <summary>
        /// Register critter achievements
        /// </summary>
        /// <param name="reqs">Common achievement requirements</param>
        private void RegisterCritterAchievements(ConditionReqs reqs)
        {
            // Verified w/ https://terraria.wiki.gg/wiki/Critters
            Dictionary<string, int[]> SpecialCritters = new()
            {
                { "CRITTER_GEM", [NPCID.GemBunnyAmethyst, NPCID.GemBunnyTopaz, NPCID.GemBunnySapphire, NPCID.GemBunnyEmerald, NPCID.GemBunnyRuby, NPCID.GemBunnyDiamond, NPCID.GemBunnyAmber, NPCID.GemSquirrelAmethyst, NPCID.GemSquirrelTopaz, NPCID.GemSquirrelSapphire, NPCID.GemSquirrelEmerald, NPCID.GemSquirrelRuby, NPCID.GemSquirrelDiamond, NPCID.GemSquirrelAmber] },
                { "CRITTER_GOLD", [NPCID.GoldBird, NPCID.GoldBunny, NPCID.GoldButterfly, NPCID.GoldDragonfly, NPCID.GoldFrog, NPCID.GoldGoldfish, NPCID.GoldGoldfishWalker, NPCID.GoldGrasshopper, NPCID.GoldLadyBug, NPCID.GoldMouse, NPCID.GoldSeahorse, NPCID.SquirrelGold, NPCID.GoldWaterStrider, NPCID.GoldWorm] }
            };

            // Verified w/ https://terraria.wiki.gg/wiki/Critters
            int[] Critters = [ItemID.Bird, ItemID.BlueJay, ItemID.Buggy, ItemID.Bunny, ItemID.ExplosiveBunny, ItemID.GemBunnyAmethyst, ItemID.GemBunnyTopaz, ItemID.GemBunnySapphire, ItemID.GemBunnyEmerald, ItemID.GemBunnyRuby, ItemID.GemBunnyDiamond, ItemID.GemBunnyAmber, ItemID.Cardinal, ItemID.YellowCockatiel, ItemID.GrayCockatiel, ItemID.Duck, ItemID.MallardDuck, ItemID.EnchantedNightcrawler, ItemID.Shimmerfly, ItemID.FairyCritterBlue, ItemID.FairyCritterGreen, ItemID.FairyCritterPink, ItemID.Firefly, ItemID.Lavafly, ItemID.LightningBug, ItemID.Frog, ItemID.Goldfish, ItemID.Grasshopper, ItemID.Grebe, ItemID.Grubby, ItemID.LadyBug, ItemID.ScarletMacaw, ItemID.BlueMacaw, ItemID.Maggot, ItemID.Mouse, ItemID.Owl, ItemID.Penguin, ItemID.Pupfish, ItemID.Rat, ItemID.Scorpion, ItemID.BlackScorpion, ItemID.Seagull, ItemID.Seahorse, ItemID.Sluggy, ItemID.Snail, ItemID.GlowingSnail, ItemID.MagmaSnail, ItemID.Squirrel, ItemID.SquirrelRed, ItemID.GemSquirrelAmethyst, ItemID.GemSquirrelTopaz, ItemID.GemSquirrelSapphire, ItemID.GemSquirrelEmerald, ItemID.GemSquirrelRuby, ItemID.GemSquirrelDiamond, ItemID.GemSquirrelAmber, ItemID.Stinkbug, ItemID.Toucan, ItemID.Turtle, ItemID.TurtleJungle, ItemID.WaterStrider, ItemID.Worm, ItemID.JuliaButterfly, ItemID.MonarchButterfly, ItemID.PurpleEmperorButterfly, ItemID.RedAdmiralButterfly, ItemID.SulphurButterfly, ItemID.TreeNymphButterfly, ItemID.UlyssesButterfly, ItemID.ZebraSwallowtailButterfly, ItemID.HellButterfly, ItemID.EmpressButterfly, ItemID.BlackDragonfly, ItemID.BlueDragonfly, ItemID.GreenDragonfly, ItemID.OrangeDragonfly, ItemID.RedDragonfly, ItemID.YellowDragonfly, ItemID.GoldBird, ItemID.GoldBunny, ItemID.GoldButterfly, ItemID.GoldFrog, ItemID.GoldGoldfish, ItemID.GoldGrasshopper, ItemID.GoldLadyBug, ItemID.GoldMouse, ItemID.GoldSeahorse, ItemID.SquirrelGold, ItemID.GoldWaterStrider, ItemID.GoldWorm, ItemID.TruffleWorm];

            foreach (var group in SpecialCritters)
                RegisterAchievement(group.Key, NpcCatchCondition.CatchAll(reqs, group.Value), group.Value.Length > 1, AchievementCategory.Collector);

            RegisterAchievement("CRITTER", ItemGrabCondition.GrabAll(reqs, Critters), true, AchievementCategory.Collector);
        }

        /// <summary>
        /// Register dye achievements
        /// </summary>
        /// <param name="reqs">Common achievement requirements</param>
        private void RegisterDyeAchievements(ConditionReqs reqs)
        {
            // Verified w/ https://terraria.wiki.gg/wiki/Dyes
            Dictionary<string, int[]> SpecialDyes = new()
            {
                { "DYE_STRANGE", [ItemID.AcidDye, ItemID.BlueAcidDye, ItemID.RedAcidDye, ItemID.ChlorophyteDye, ItemID.GelDye, ItemID.MushroomDye, ItemID.GrimDye, ItemID.HadesDye, ItemID.BurningHadesDye, ItemID.ShadowflameHadesDye, ItemID.LivingOceanDye, ItemID.LivingFlameDye, ItemID.LivingRainbowDye, ItemID.MartianArmorDye, ItemID.MidnightRainbowDye, ItemID.MirageDye, ItemID.NegativeDye, ItemID.PixieDye, ItemID.PhaseDye, ItemID.PurpleOozeDye, ItemID.ReflectiveDye, ItemID.ReflectiveCopperDye, ItemID.ReflectiveGoldDye, ItemID.ReflectiveObsidianDye, ItemID.ReflectiveMetalDye, ItemID.ReflectiveSilverDye, ItemID.ShadowDye, ItemID.ShiftingSandsDye, ItemID.DevDye, ItemID.TwilightDye, ItemID.WispDye, ItemID.InfernalWispDye, ItemID.UnicornWispDye] },
                { "DYE_CRAFT", [ItemID.PinkGelDye, ItemID.ShiftingPearlSandsDye, ItemID.NebulaDye, ItemID.SolarDye, ItemID.StardustDye, ItemID.VortexDye, ItemID.VoidDye] },
                { "DYE_OTHER", [ItemID.BloodbathDye, ItemID.FogboundDye, ItemID.HallowBossDye] }
            };

            // Verified w/ https://terraria.wiki.gg/wiki/Hair_Dyes
            int[] HairDyes = [ItemID.LifeHairDye, ItemID.ManaHairDye, ItemID.DepthHairDye, ItemID.MoneyHairDye, ItemID.TimeHairDye, ItemID.BiomeHairDye, ItemID.PartyHairDye, ItemID.RainbowHairDye, ItemID.SpeedHairDye, ItemID.MartianHairDye, ItemID.TwilightHairDye];

            RegisterAchievement("DYE_STRANGE", NpcGiftCondition.GiftAll(reqs, NPCID.DyeTrader, SpecialDyes["DYE_STRANGE"]), true, AchievementCategory.Collector);
            RegisterAchievement("DYE_CRAFT", ItemCraftCondition.CraftAll(reqs, SpecialDyes["DYE_CRAFT"]), true, AchievementCategory.Collector);
            RegisterAchievement("DYE_OTHER", ItemGrabCondition.GrabAll(reqs, SpecialDyes["DYE_OTHER"]), true, AchievementCategory.Collector);
            
            RegisterAchievement("DYE_HAIR", ItemGrabCondition.GrabAll(reqs, HairDyes), true, AchievementCategory.Collector);
        }

        /// <summary>
        /// Register extractinator achievements
        /// </summary>
        /// <param name="reqs">Common achievement requirements</param>
        private void RegisterExtractinatorAchievements(ConditionReqs reqs)
        {
            RegisterAchievement("EXTRACT_PLATINUM_COIN", ItemExtractCondition.Extract(reqs, ItemID.PlatinumCoin), AchievementCategory.Collector);
            RegisterAchievement("EXTRACT_JOURNEYMAN_BAIT", ItemExtractCondition.Extract(reqs, ItemID.JourneymanBait), AchievementCategory.Collector);
        }

        /// <summary>
        /// Register fish achievements
        /// </summary>
        /// <param name="reqs">Common achievement requirements</param>
        private void RegisterFishAchievements(ConditionReqs reqs)
        {
            // Verified w/ https://terraria.wiki.gg/wiki/Fishing
            Dictionary<string, int[]> FishCatch = new()
            {
                { "FISH_NORMAL", [ItemID.ArmoredCavefish, ItemID.AtlanticCod, ItemID.Bass, ItemID.BlueJellyfish, ItemID.ChaosFish, ItemID.CrimsonTigerfish, ItemID.Damselfish, ItemID.DoubleCod, ItemID.Ebonkoi, ItemID.FlarefinKoi, ItemID.Flounder, ItemID.FrostMinnow, ItemID.GoldenCarp, ItemID.GreenJellyfish, ItemID.Hemopiranha, ItemID.Honeyfin, ItemID.NeonTetra, ItemID.Obsidifish, ItemID.PinkJellyfish, ItemID.PrincessFish, ItemID.Prismite, ItemID.RedSnapper, ItemID.RockLobster, ItemID.Salmon, ItemID.Shrimp, ItemID.SpecularFish, ItemID.Stinkfish, ItemID.Trout, ItemID.Tuna, ItemID.VariegatedLardfish] },
                { "FISH_QUEST", [ItemID.AmanitaFungifin, ItemID.Angelfish, ItemID.Batfish, ItemID.BloodyManowar, ItemID.Bonefish, ItemID.BumblebeeTuna, ItemID.Bunnyfish, ItemID.CapnTunabeard, ItemID.Catfish, ItemID.Cloudfish, ItemID.Clownfish, ItemID.Cursedfish, ItemID.DemonicHellfish, ItemID.Derpfish, ItemID.Dirtfish, ItemID.DynamiteFish, ItemID.EaterofPlankton, ItemID.FallenStarfish, ItemID.Fishotron, ItemID.Fishron, ItemID.GuideVoodooFish, ItemID.Harpyfish, ItemID.Hungerfish, ItemID.Ichorfish, ItemID.InfectedScabbardfish, ItemID.Jewelfish, ItemID.MirageFish, ItemID.Mudfish, ItemID.MutantFlinxfin, ItemID.Pengfish, ItemID.Pixiefish, ItemID.ScarabFish, ItemID.ScorpioFish, ItemID.Slimefish, ItemID.Spiderfish, ItemID.TheFishofCthulu, ItemID.TropicalBarracuda, ItemID.TundraTrout, ItemID.UnicornFish, ItemID.Wyverntail, ItemID.ZombieFish] },
                { "FISH_CRATE", [ItemID.WoodenCrate, ItemID.WoodenCrateHard, ItemID.IronCrate, ItemID.IronCrateHard, ItemID.GoldenCrate, ItemID.GoldenCrateHard, ItemID.JungleFishingCrate, ItemID.JungleFishingCrateHard, ItemID.FloatingIslandFishingCrate, ItemID.FloatingIslandFishingCrateHard, ItemID.CorruptFishingCrate, ItemID.CorruptFishingCrateHard, ItemID.CrimsonFishingCrate, ItemID.CrimsonFishingCrateHard, ItemID.HallowedFishingCrate, ItemID.HallowedFishingCrateHard, ItemID.DungeonFishingCrate, ItemID.DungeonFishingCrateHard, ItemID.FrozenCrate, ItemID.FrozenCrateHard, ItemID.OasisCrate, ItemID.OasisCrateHard, ItemID.LavaCrate, ItemID.LavaCrateHard, ItemID.OceanCrate, ItemID.OceanCrateHard] },
                { "FISH_JUNK", [ItemID.OldShoe, ItemID.FishingSeaweed, ItemID.TinCan, ItemID.JojaCola] }
            };

            // Verified w/ https://terraria.wiki.gg/wiki/Angler#Reward_lists
            int[] OneTimeFishRewards = [ItemID.FuzzyCarrot, ItemID.AnglerHat, ItemID.AnglerVest, ItemID.AnglerPants];
            int[] AllOtherFishRewards = [ItemID.HoneyAbsorbantSponge, ItemID.BottomlessHoneyBucket, ItemID.GoldenFishingRod, ItemID.LavaFishingHook, ItemID.FinWings, ItemID.BottomlessBucket, ItemID.SuperAbsorbantSponge, ItemID.GoldenBugNet, ItemID.FishHook, ItemID.FishMinecart, ItemID.SeashellHairpin, ItemID.MermaidAdornment, ItemID.MermaidTail, ItemID.FishCostumeMask, ItemID.FishCostumeShirt, ItemID.FishCostumeFinskirt, ItemID.HighTestFishingLine, ItemID.AnglerEarring, ItemID.TackleBox, ItemID.FishingBobber, ItemID.FishermansGuide, ItemID.WeatherRadio, ItemID.Sextant, ItemID.FishingBobber, ItemID.FishingPotion, ItemID.SonarPotion, ItemID.CratePotion, ItemID.LifePreserver, ItemID.ShipsWheel, ItemID.CompassRose, ItemID.WallAnchor, ItemID.PillaginMePixels, ItemID.TreasureMap, ItemID.GoldfishTrophy, ItemID.BunnyfishTrophy, ItemID.SwordfishTrophy, ItemID.SharkteethTrophy, ItemID.ShipInABottle, ItemID.SeaweedPlanter, ItemID.NotSoLostInParadise, ItemID.Crustography, ItemID.WhatLurksBelow, ItemID.Fangs, ItemID.CouchGag, ItemID.SilentFish, ItemID.TheDuke, ItemID.MasterBait, ItemID.JourneymanBait, ItemID.ApprenticeBait];

            RegisterAchievement("FISH_PINK_PEARL", ItemOpenCondition.Open(reqs, ItemID.Oyster, ItemID.PinkPearl), AchievementCategory.Collector);

            foreach (var group in FishCatch)
                RegisterAchievement(group.Key, ItemCatchCondition.CatchAll(reqs, group.Value), group.Value.Length > 1, AchievementCategory.Collector);

            // Patch since it was borked on release
            // First 4 items never appear again
            List<CustomAchievementCondition> conds = [];
            conds.AddRange(ItemGrabCondition.GrabAll(reqs, OneTimeFishRewards));
            conds.AddRange(NpcGiftCondition.GiftAll(reqs, NPCID.Angler, AllOtherFishRewards));
            RegisterAchievement("FISH_REWARD", conds, true, AchievementCategory.Collector);
        }

        /// <summary>
        /// Register furniture achievements
        /// </summary>
        /// <param name="reqs">Common achievement requirements</param>
        private void RegisterFurnitureAchievements(ConditionReqs reqs)
        {
            // Verified w/
            // https://terraria.wiki.gg/wiki/Furniture
            // https://terraria.wiki.gg/wiki/Buffs#Activated_furniture
            // https://terraria.wiki.gg/wiki/Crafting_stations#Themed_furniture
            Dictionary<string, int[]> Furniture = new()
            {
                { "FURNITURE_BUFF", [ItemID.Sunflower, ItemID.Campfire, ItemID.Fireplace, ItemID.CrystalBall, ItemID.AmmoBox, ItemID.SharpeningStation, ItemID.BewitchingTable, ItemID.WarTable, ItemID.HeartLantern, ItemID.CatBast, ItemID.SliceOfCake, ItemID.StarinaBottle, ItemID.GardenGnome, ItemID.PeaceCandle] },
                { "FURNITURE_DISPLAY", [ItemID.Mannequin, ItemID.Womannquin, ItemID.WeaponRack, ItemID.ItemFrame, ItemID.HatRack] },
                { "FURNITURE_THEMED", [ItemID.BoneWelder, ItemID.GlassKiln, ItemID.HoneyDispenser, ItemID.IceMachine, ItemID.LivingLoom, ItemID.SkyMill, ItemID.Solidifier, ItemID.LesionStation, ItemID.FleshCloningVaat, ItemID.SteampunkBoiler, ItemID.LihzahrdFurnace] },
                { "FURNITURE_TOMBSTONE", [ItemID.Tombstone, ItemID.GraveMarker, ItemID.CrossGraveMarker, ItemID.Headstone, ItemID.Gravestone, ItemID.Obelisk, ItemID.RichGravestone1, ItemID.RichGravestone2, ItemID.RichGravestone3, ItemID.RichGravestone4, ItemID.RichGravestone5] },
            };

            RegisterAchievement("FURNITURE_CHIPPYS_COUCH", NpcDropCondition.Drop(reqs, NPCID.SkeletronHead, ItemID.ChippysCouch), AchievementCategory.Collector);
            RegisterAchievement("FURNITURE_DESERT_SPIRIT_LAMP", NpcDropCondition.Drop(reqs, NPCID.DesertDjinn, ItemID.DjinnLamp), AchievementCategory.Collector);
            RegisterAchievement("FURNITURE_ENCHANTED_SUNDIAL", ItemOpenCondition.Open(reqs, ItemID.None, ItemID.Sundial), AchievementCategory.Collector);
            RegisterAchievement("FURNITURE_ENCHANTED_MOONDIAL", ItemGrabCondition.Grab(reqs, ItemID.Moondial), AchievementCategory.Collector);
            RegisterAchievement("FURNITURE_HAT_RACK", ItemCraftCondition.Craft(reqs, ItemID.HatRack), AchievementCategory.Collector);
            RegisterAchievement("FURNITURE_PIGRONATA", NpcBuyCondition.Buy(reqs, NPCID.PartyGirl, ItemID.Pigronata), AchievementCategory.Collector);
            RegisterAchievement("FURNITURE_PORTAL_GUN_STATION", NpcBuyCondition.Buy(reqs, NPCID.Cyborg, ItemID.PortalGunStation), AchievementCategory.Collector);
            RegisterAchievement("FURNITURE_TARGET_DUMMY", ItemCraftCondition.Craft(reqs, ItemID.TargetDummy), AchievementCategory.Collector);

            foreach (var group in Furniture)
                RegisterAchievement(group.Key, ItemGrabCondition.GrabAll(reqs, group.Value), group.Value.Length > 1, AchievementCategory.Collector);
        }

        /// <summary>
        /// Register novelty achievements
        /// </summary>
        /// <param name="reqs">Common achievement requirements</param>
        private void RegisterNoveltyAchievements(ConditionReqs reqs)
        {
            // Verified w/ https://terraria.wiki.gg/wiki/Template:Novelty_items
            int[] Novelties = [ItemID.BeachBall, ItemID.BubbleMachine, ItemID.BubbleWand, ItemID.ConfettiCannon, ItemID.ConfettiGun, ItemID.FireworkFountain, ItemID.FireworksBox, ItemID.FogMachine, ItemID.Football, ItemID.PartyMonolith, ItemID.ReleaseDoves, ItemID.ReleaseLantern, ItemID.SillyBalloonMachine, ItemID.SmokeBomb, ItemID.DrumSet, ItemID.DrumStick, ItemID.IvyGuitar, ItemID.KiteBlue, ItemID.KiteBlueAndYellow, ItemID.KiteRed, ItemID.KiteRedAndYellow, ItemID.KiteYellow, ItemID.KiteGoldfish, ItemID.KiteBunny, ItemID.KiteBunnyCorrupt, ItemID.KiteBunnyCrimson, ItemID.KiteManEater, ItemID.KiteJellyfishBlue, ItemID.KiteJellyfishPink, ItemID.KiteShark, ItemID.KiteBoneSerpent, ItemID.KiteWanderingEye, ItemID.KiteUnicorn, ItemID.KiteWorldFeeder, ItemID.KiteSandShark, ItemID.KiteWyvern, ItemID.KitePigron, ItemID.KiteAngryTrapper, ItemID.KiteKoi, ItemID.KiteCrawltipede, ItemID.KiteSpectrum, ItemID.JimsDrone, ItemID.LovePotion, ItemID.PinWheel, ItemID.CarbonGuitar, ItemID.SandcastleBucket, ItemID.SlimeGun, ItemID.GelBalloon, ItemID.StinkPotion, ItemID.UnicornonaStick, ItemID.WaterGun, ItemID.WhoopieCushion];

            RegisterAchievement("NOVELTY_IVY", ItemGrabCondition.Grab(reqs, ItemID.IvyGuitar), AchievementCategory.Collector);
            RegisterAchievement("NOVELTY_WYVERN_KITE", NpcDropCondition.Drop(reqs, NPCID.None, ItemID.KiteWyvern), AchievementCategory.Collector);
            RegisterAchievement("NOVELTY_RAIN_SONG", NpcDropCondition.Drop(reqs, NPCID.FlyingFish, ItemID.CarbonGuitar), AchievementCategory.Collector);
            RegisterAchievement("NOVELTY_UNICORN_ON_A_STICK", NpcDropCondition.Drop(reqs, NPCID.Unicorn, ItemID.UnicornonaStick), AchievementCategory.Collector);

            RegisterAchievement("NOVELTY", ItemGrabCondition.GrabAll(reqs, Novelties), true, AchievementCategory.Collector);
        }

        /// <summary>
        /// Register painting achievements
        /// </summary>
        /// <param name="reqs">Common achievement requirements</param>
        private void RegisterPaintingAchievements(ConditionReqs reqs)
        {
            // Verified w/ https://terraria.wiki.gg/wiki/Paintings
            Dictionary<string, int[]> PaintingsBuy = new()
            {
                { "PAINTING_CLOTHIER", [ItemID.PlacePainting] },
                { "PAINTING_GOLFER", [ItemID.GolfPainting1, ItemID.GolfPainting2, ItemID.GolfPainting3, ItemID.GolfPainting4] },
                { "PAINTING_PAINTER", [ItemID.ColdWatersintheWhiteLand, ItemID.Daylight, ItemID.DeadlandComesAlive, ItemID.DoNotStepontheGrass, ItemID.EvilPresence, ItemID.FirstEncounter, ItemID.GoodMorning, ItemID.TheLandofDeceivingLooks, ItemID.LightlessChasms, ItemID.PlaceAbovetheClouds, ItemID.SecretoftheSands, ItemID.SkyGuardian, ItemID.ThroughtheWindow, ItemID.UndergroundReward, ItemID.Purity, ItemID.Thunderbolt] },
                { "PAINTING_PAINTER_GRAVEYARD", [ItemID.Nevermore, ItemID.Reborn, ItemID.Graveyard, ItemID.GhostManifestation, ItemID.WickedUndead, ItemID.HailtotheKing, ItemID.BloodyGoblet, ItemID.StillLife] },
                { "PAINTING_PRINCESS", [ItemID.Princess64, ItemID.PaintingOfALass, ItemID.DarkSideHallow, ItemID.PrincessStyle, ItemID.SuspiciouslySparkly, ItemID.TerraBladeChronicles, ItemID.RoyalRomance] },
                { "PAINTING_TRAVELING_MERCHANT", [ItemID.PaintingAcorns, ItemID.PaintingCastleMarsberg, ItemID.PaintingColdSnap, ItemID.PaintingCursedSaint, ItemID.PaintingMartiaLisa, ItemID.MoonLordPainting, ItemID.PaintingWendy, ItemID.PaintingWillow, ItemID.PaintingWilson, ItemID.PaintingWolfgang, ItemID.PaintingTheSeason, ItemID.PaintingSnowfellas, ItemID.PaintingTheTruthIsUpThere, ItemID.HoplitePizza, ItemID.YuumaTheBlueTiger, ItemID.MoonmanandCompany, ItemID.SunshineofIsrapony, ItemID.BennyWarhol, ItemID.DoNotEattheVileMushroom, ItemID.Duality, ItemID.KargohsSummon, ItemID.ParsecPals] },
                { "PAINTING_TRUFFLE", [ItemID.MySon] },
                { "PAINTING_ZOOLOGIST", [ItemID.TheWerewolf] }
            };

            // Verified w/ https://terraria.wiki.gg/wiki/Paintings
            Dictionary<string, int[]> PaintingsArea = new()
            {
                { "PAINTING_DUNGEON", [ItemID.BloodMoonRising, ItemID.BoneWarp, ItemID.TheCreationoftheGuide, ItemID.TheCursedMan, ItemID.TheDestroyer, ItemID.Dryadisque, ItemID.TheEyeSeestheEnd, ItemID.FacingtheCerebralMastermind, ItemID.GloryoftheFire, ItemID.GoblinsPlayingPoker, ItemID.GreatWave, ItemID.TheGuardiansGaze, ItemID.TheHangedMan, ItemID.Impact, ItemID.ThePersistencyofEyes, ItemID.PoweredbyBirds, ItemID.TheScreamer, ItemID.SkellingtonJSkellingsworth, ItemID.SparkyPainting, ItemID.SomethingEvilisWatchingYou, ItemID.StarryNight, ItemID.TrioSuperHeroes, ItemID.TheTwinsHaveAwoken, ItemID.UnicornCrossingtheHallows, ItemID.RemnantsofDevotion] },
                { "PAINTING_FLOATING_ISLAND", [ItemID.HighPitch, ItemID.Constellation, ItemID.LoveisintheTrashSlot, ItemID.SunOrnament, ItemID.BlessingfromTheHeavens, ItemID.SeeTheWorldForWhatItIs] },
                { "PAINTING_JUNGLE_TEMPLE", [ItemID.LizardKing] },
                { "PAINTING_UNDERGROUND_CABIN", [ItemID.AmericanExplosive, ItemID.AuroraBorealis, ItemID.Bifrost, ItemID.Bioluminescence, ItemID.CatSword, ItemID.CrownoDevoursHisLunch, ItemID.Discover, ItemID.FairyGuides, ItemID.FatherofSomeone, ItemID.FindingGold, ItemID.ForestTroll, ItemID.GloriousNight, ItemID.GuidePicasso, ItemID.HappyLittleTree, ItemID.Heartlands, ItemID.AHorribleNightforAlchemy, ItemID.Land, ItemID.TheMerchant, ItemID.MorningHunt, ItemID.NurseLisa, ItemID.OldMiner, ItemID.Outcast, ItemID.RareEnchantment, ItemID.Secrets, ItemID.StrangeDeadFellows, ItemID.StrangeGrowth, ItemID.SufficientlyAdvanced, ItemID.Sunflowers, ItemID.TerrarianGothic, ItemID.VikingVoyage, ItemID.Waldo, ItemID.Wildflowers] },
                { "PAINTING_UNDERGROUND_CABIN_DESERT", [ItemID.AndrewSphinx, ItemID.WatchfulAntlion, ItemID.BurningSpirit, ItemID.JawsOfDeath, ItemID.TheSandsOfSlime, ItemID.SnakesIHateSnakes, ItemID.LifeAboveTheSand, ItemID.Oasis, ItemID.PrehistoryPreserved, ItemID.AncientTablet, ItemID.Uluru, ItemID.VisitingThePyramids, ItemID.BandageBoy, ItemID.DivineEye] },
                { "PAINTING_UNDERWORLD", [ItemID.DarkSoulReaper, ItemID.Darkness, ItemID.DemonsEye, ItemID.FlowingMagma, ItemID.HandEarth, ItemID.ImpFace, ItemID.LakeofFire, ItemID.LivingGore, ItemID.OminousPresence, ItemID.ShiningMoon, ItemID.Skelehead, ItemID.TrappedGhost] }
            };

            // Verified w/ https://terraria.wiki.gg/wiki/Paintings
            Dictionary<string, int[]> PaintingsOther = new()
            {
                { "PAINTING_FISH", [ItemID.DreadoftheRedSea, ItemID.LadyOfTheLake] },
                { "PAINTING_ANGLER", [ItemID.PillaginMePixels, ItemID.CouchGag, ItemID.Crustography, ItemID.Fangs, ItemID.NotSoLostInParadise, ItemID.SilentFish, ItemID.TheDuke, ItemID.WhatLurksBelow] },
                { "PAINTING_SOLAR", [ItemID.Requiem, ItemID.OcularResonance, ItemID.AMachineforTerrarians, ItemID.WingsofEvil, ItemID.ThisIsGettingOutOfHand, ItemID.Eyezorhead, ItemID.MidnightSun, ItemID.Buddies] },
                { "PAINTING_GOODIE", [ItemID.BitterHarvest, ItemID.BloodMoonCountess, ItemID.HallowsEve, ItemID.JackingSkeletron, ItemID.MorbidCuriosity] }
            };

            int[] AnimalSkins = [ItemID.TigerSkin, ItemID.LeopardSkin, ItemID.ZebraSkin];

            RegisterAchievement("PAINTING_WALDO", BreakAndGrabItem(reqs, ItemID.Waldo), false, AchievementCategory.Collector);

            foreach (var group in PaintingsBuy)
                RegisterAchievement(group.Key, NpcBuyCondition.BuyAll(reqs, NPCID.None, group.Value), group.Value.Length > 1, AchievementCategory.Collector);

            foreach (var group in PaintingsArea)
                RegisterAchievement(group.Key, ItemGrabCondition.GrabAll(reqs, group.Value), group.Value.Length > 1, AchievementCategory.Collector);

            RegisterAchievement("PAINTING_FISH", ItemCatchCondition.CatchAll(reqs, PaintingsOther["PAINTING_FISH"]), true, AchievementCategory.Collector);
            RegisterAchievement("PAINTING_ANGLER", NpcGiftCondition.GiftAll(reqs, NPCID.Angler, PaintingsOther["PAINTING_ANGLER"]), true, AchievementCategory.Collector);
            RegisterAchievement("PAINTING_SOLAR", NpcDropCondition.DropAll(reqs, NPCID.None, PaintingsOther["PAINTING_SOLAR"]), true, AchievementCategory.Collector);
            RegisterAchievement("PAINTING_GOODIE", ItemOpenCondition.OpenAll(reqs, ItemID.GoodieBag, PaintingsOther["PAINTING_GOODIE"]), true, AchievementCategory.Collector);
            
            RegisterAchievement("PAINTING_ANIMAL_SKINS", NpcBuyCondition.BuyAll(reqs, NPCID.TravellingMerchant, AnimalSkins), true, AchievementCategory.Collector);
        }

        /// <summary>
        /// Register weapon achievements
        /// </summary>
        /// <param name="reqs">Common achievement requirements</param>
        private void RegisterPylonAchievements(ConditionReqs reqs)
        {
            // Verified w/ https://terraria.wiki.gg/wiki/Pylons
            int[] Pylons = [ItemID.TeleportationPylonPurity, ItemID.TeleportationPylonSnow, ItemID.TeleportationPylonDesert, ItemID.TeleportationPylonUnderground, ItemID.TeleportationPylonOcean, ItemID.TeleportationPylonJungle, ItemID.TeleportationPylonHallow, ItemID.TeleportationPylonMushroom, ItemID.TeleportationPylonVictory];

            RegisterAchievement("PYLON_UNIVERSAL", NpcBuyCondition.Buy(reqs, NPCID.BestiaryGirl, ItemID.TeleportationPylonVictory), AchievementCategory.Collector);
            RegisterAchievement("PYLON", NpcBuyCondition.BuyAll(reqs, NPCID.None, Pylons), true, AchievementCategory.Collector);
        }

        /// <summary>
        /// Register statue achievements
        /// </summary>
        /// <param name="reqs">Common achievement requirements</param>
        private void RegisterStatueAchievements(ConditionReqs reqs)
        {
            // Verified w/ https://terraria.wiki.gg/wiki/Statues
            Dictionary<string, int[]> Statues = new()
            {
                { "STATUE_ENEMY", [ItemID.ZombieArmStatue, ItemID.BatStatue, ItemID.BloodZombieStatue, ItemID.BoneSkeletonStatue, ItemID.ChestStatue, ItemID.CorruptStatue, ItemID.CrabStatue, ItemID.DripplerStatue, ItemID.EyeballStatue, ItemID.GoblinStatue, ItemID.GraniteGolemStatue, ItemID.HarpyStatue, ItemID.HopliteStatue, ItemID.HornetStatue, ItemID.ImpStatue, ItemID.JellyfishStatue, ItemID.MedusaStatue, ItemID.PigronStatue, ItemID.PiranhaStatue, ItemID.SharkStatue, ItemID.SkeletonStatue, ItemID.SlimeStatue, ItemID.UndeadVikingStatue, ItemID.UnicornStatue, ItemID.WallCreeperStatue, ItemID.WraithStatue] },
                { "STATUE_CRITTER", [ItemID.BirdStatue, ItemID.BuggyStatue, ItemID.BunnyStatue, ItemID.ButterflyStatue, ItemID.CockatielStatue, ItemID.DragonflyStatue, ItemID.DuckStatue, ItemID.FireflyStatue, ItemID.FishStatue, ItemID.FrogStatue, ItemID.GrasshopperStatue, ItemID.MacawStatue, ItemID.MouseStatue, ItemID.OwlStatue, ItemID.PenguinStatue, ItemID.ScorpionStatue, ItemID.SeagullStatue, ItemID.SnailStatue, ItemID.SquirrelStatue, ItemID.ToucanStatue, ItemID.TurtleStatue, ItemID.WormStatue] },
                { "STATUE_DECOR", [ItemID.AnvilStatue, ItemID.ArmorStatue, ItemID.AxeStatue, ItemID.BoomerangStatue, ItemID.BootStatue, ItemID.BowStatue, ItemID.CrossStatue, ItemID.GargoyleStatue, ItemID.GloomStatue, ItemID.HammerStatue, ItemID.PickaxeStatue, ItemID.PillarStatue, ItemID.PotStatue, ItemID.PotionStatue, ItemID.ReaperStatue, ItemID.ShieldStatue, ItemID.SpearStatue, ItemID.SunflowerStatue, ItemID.SwordStatue, ItemID.TreeStatue, ItemID.WomanStatue, ItemID.LihzahrdStatue, ItemID.LihzahrdGuardianStatue, ItemID.LihzahrdWatcherStatue] },
                { "STATUE_OTHER", [ItemID.KingStatue, ItemID.QueenStatue, ItemID.BombStatue, ItemID.HeartStatue, ItemID.StarStatue, ItemID.MushroomStatue, ItemID.BoulderStatue, ItemID.CatBast, ItemID.AngelStatue] }
            };

            foreach (var group in Statues)
                RegisterAchievement(group.Key, ItemGrabCondition.GrabAll(reqs, group.Value), group.Value.Length > 1, AchievementCategory.Collector);
        }

        /// <summary>
        /// Register storage achievements
        /// </summary>
        /// <param name="reqs">Common achievement requirements</param>
        private void RegisterStorageAchievements(ConditionReqs reqs)
        {
            // Verified w/ https://terraria.wiki.gg/wiki/Storage_items#Portable_Storage
            int[] PortableStorage = [ItemID.PiggyBank, ItemID.MoneyTrough, ItemID.VoidVault, ItemID.VoidLens, ItemID.Safe, ItemID.DefendersForge, ItemID.ChesterPetItem];

            RegisterAchievement("STORAGE_MONEY_TROUGH", NpcDropCondition.Drop(reqs, NPCID.None, ItemID.MoneyTrough), AchievementCategory.Collector);
            RegisterAchievement("STORAGE", ItemGrabCondition.GrabAll(reqs, PortableStorage), true, AchievementCategory.Collector);
        }

        /// <summary>
        /// Register trophy achievements
        /// </summary>
        /// <param name="reqs">Common achievement requirements</param>
        private void RegisterTrophyAchievements(ConditionReqs reqs)
        {
            // Verified w/ https://terraria.wiki.gg/wiki/Trophies
            Dictionary<string, int[]> Trophies = new()
            {
                { "TROPHY_PRE-HARDMODE", [ItemID.KingSlimeTrophy, ItemID.EyeofCthulhuTrophy, ItemID.EaterofWorldsTrophy, ItemID.BrainofCthulhuTrophy, ItemID.QueenBeeTrophy, ItemID.SkeletronTrophy, ItemID.DeerclopsTrophy, ItemID.WallofFleshTrophy] },
                { "TROPHY_HARDMODE", [ItemID.QueenSlimeTrophy, ItemID.DestroyerTrophy, ItemID.RetinazerTrophy, ItemID.SpazmatismTrophy, ItemID.SkeletronPrimeTrophy, ItemID.PlanteraTrophy, ItemID.GolemTrophy, ItemID.FairyQueenTrophy, ItemID.DukeFishronTrophy, ItemID.AncientCultistTrophy, ItemID.MoonLordTrophy] },
                { "TROPHY_EVENT", [ItemID.BossTrophyDarkmage, ItemID.BossTrophyOgre, ItemID.BossTrophyBetsy, ItemID.MourningWoodTrophy, ItemID.PumpkingTrophy, ItemID.EverscreamTrophy, ItemID.SantaNK1Trophy, ItemID.IceQueenTrophy, ItemID.FlyingDutchmanTrophy, ItemID.MartianSaucerTrophy] },
                { "TROPHY_FISH", [ItemID.GoldfishTrophy, ItemID.BunnyfishTrophy, ItemID.SwordfishTrophy, ItemID.SharkteethTrophy] },
                { "TROPHY_GOLF", [ItemID.GolfTrophyBronze, ItemID.GolfTrophySilver, ItemID.GolfTrophyGold] }
            };

            foreach (var group in Trophies)
                RegisterAchievement(group.Key, ItemGrabCondition.GrabAll(reqs, group.Value), group.Value.Length > 1, AchievementCategory.Collector);
        }

        /// <summary>
        /// Register buff achievements
        /// </summary>
        /// <param name="reqs">Common achievement requirements</param>
        private void RegisterBuffAchievements(ConditionReqs reqs)
        {
            // Verified w/ https://terraria.wiki.gg/wiki/Buffs
            Dictionary<string, int[]> Buffs = new()
            {
                { "BUFF_ENVIRONMENT", [BuffID.Campfire, BuffID.DryadsWard, BuffID.Sunflower, BuffID.HeartLamp, BuffID.Honey, BuffID.PeaceCandle, BuffID.StarInBottle, BuffID.CatBast, BuffID.MonsterBanner] },
                { "BUFF_EQUIPMENT", [BuffID.CoolWhipPlayerBuff, BuffID.BeetleEndurance1, BuffID.BeetleEndurance2, BuffID.BeetleEndurance3, BuffID.BeetleMight1, BuffID.BeetleMight2, BuffID.BeetleMight3, BuffID.NebulaUpDmg1, BuffID.NebulaUpDmg2, BuffID.NebulaUpDmg3, BuffID.SwordWhipPlayerBuff, BuffID.ScytheWhipPlayerBuff, BuffID.ShadowDodge, BuffID.IceBarrier, BuffID.ThornWhipPlayerBuff, BuffID.LeafCrystal, BuffID.SoulDrain, BuffID.NebulaUpLife1, BuffID.NebulaUpLife2, BuffID.NebulaUpLife3, BuffID.NebulaUpMana1, BuffID.NebulaUpMana2, BuffID.NebulaUpMana3, BuffID.Merfolk, BuffID.Panic, BuffID.RapidHealing, BuffID.TitaniumStorm, BuffID.SolarShield1, BuffID.SolarShield2, BuffID.SolarShield3, BuffID.StardustGuardianMinion, BuffID.ParryDamageBuff, BuffID.Werewolf] },
                { "BUFF_FURNITURE", [BuffID.AmmoBox, BuffID.Bewitched, BuffID.Clairvoyance, BuffID.Sharpened, BuffID.WarTable, BuffID.SugarRush] },
                { "BUFF_LIGHT_PET", [BuffID.ShadowOrb, BuffID.CrimsonHeart, BuffID.MagicLantern, BuffID.FairyBlue, BuffID.FairyGreen, BuffID.FairyRed, BuffID.DD2OgrePet, BuffID.Wisp] },
                { "BUFF_MINECART", [BuffID.MinecartLeftWood, BuffID.MinecartRightWood, BuffID.MinecartLeft, BuffID.MinecartRight, BuffID.DesertMinecartLeft, BuffID.DesertMinecartRight, BuffID.FishMinecartLeft, BuffID.FishMinecartRight, BuffID.BeeMinecartLeft, BuffID.BeeMinecartRight, BuffID.LadybugMinecartLeft, BuffID.LadybugMinecartRight, BuffID.PigronMinecartLeft, BuffID.PigronMinecartRight, BuffID.SunflowerMinecartLeft, BuffID.SunflowerMinecartRight, BuffID.HellMinecartLeft, BuffID.HellMinecartRight, BuffID.ShroomMinecartLeft, BuffID.ShroomMinecartRight, BuffID.AmethystMinecartLeft, BuffID.AmethystMinecartRight, BuffID.TopazMinecartLeft, BuffID.TopazMinecartRight, BuffID.SapphireMinecartLeft, BuffID.SapphireMinecartRight, BuffID.EmeraldMinecartLeft, BuffID.EmeraldMinecartRight, BuffID.RubyMinecartLeft, BuffID.RubyMinecartRight, BuffID.DiamondMinecartLeft, BuffID.DiamondMinecartRight, BuffID.AmberMinecartLeft, BuffID.AmberMinecartRight, BuffID.BeetleMinecartLeft, BuffID.BeetleMinecartRight, BuffID.MeowmereMinecartLeft, BuffID.MeowmereMinecartRight, BuffID.PartyMinecartLeft, BuffID.PartyMinecartRight, BuffID.PirateMinecartLeft, BuffID.PirateMinecartRight, BuffID.SteampunkMinecartLeft, BuffID.SteampunkMinecartRight, BuffID.CoffinMinecartLeft, BuffID.CoffinMinecartRight, BuffID.DiggingMoleMinecartLeft, BuffID.DiggingMoleMinecartRight, BuffID.FartMinecartLeft, BuffID.FartMinecartRight, BuffID.TerraFartMinecartLeft, BuffID.TerraFartMinecartRight] },
                { "BUFF_MOUNT", [BuffID.SlimeMount, BuffID.BeeMount, BuffID.TurtleMount, BuffID.BunnyMount, BuffID.PogoStickMount, BuffID.GolfCartMount, BuffID.Flamingo, BuffID.PaintedHorseMount, BuffID.MajesticHorseMount, BuffID.DarkHorseMount, BuffID.LavaSharkMount, BuffID.BasiliskMount, BuffID.WolfMount, BuffID.UnicornMount, BuffID.PigronMount, BuffID.QueenSlimeMount, BuffID.Rudolph, BuffID.ScutlixMount, BuffID.UFOMount, BuffID.DrillMount] },
                { "BUFF_PET", [BuffID.BabyDinosaur, BuffID.BabyEater, BuffID.BabyFaceMonster, BuffID.BabyGrinch, BuffID.BabyHornet, BuffID.BabyImp, BuffID.BabyPenguin, BuffID.BabyRedPanda, BuffID.BabySkeletronHead, BuffID.BabySnowman, BuffID.BabyTruffle, BuffID.BabyWerewolf, BuffID.BerniePet, BuffID.BlackCat, BuffID.BlueChickenPet, BuffID.CavelingGardener, BuffID.ChesterPet, BuffID.CompanionCube, BuffID.CursedSapling, BuffID.DirtiestBlock, BuffID.DynamiteKitten, BuffID.UpbeatStar, BuffID.EyeballSpring, BuffID.FennecFox, BuffID.GlitteryButterfly, BuffID.GlommerPet, BuffID.PetDD2Dragon, BuffID.JunimoPet, BuffID.LilHarpy, BuffID.PetLizard, BuffID.MiniMinotaur, BuffID.PetParrot, BuffID.PigPet, BuffID.Plantero, BuffID.PetDD2Gato, BuffID.Puppy, BuffID.PlanteraPet, BuffID.PetSpider, BuffID.ShadowMimic, BuffID.SharkPup, BuffID.Spiffo, BuffID.Squashling, BuffID.SugarGlider, BuffID.TikiSpirit, BuffID.PetTurtle, BuffID.VoltBunny, BuffID.ZephyrFish] },
                { "BUFF_SUMMON", [BuffID.AbigailMinion, BuffID.BabyBird, BuffID.BabySlime, BuffID.DeadlySphere, BuffID.StormTiger, BuffID.Smolstar, BuffID.FlinxMinion, BuffID.HornetMinion, BuffID.ImpMinion, BuffID.PirateMinion, BuffID.Pygmies, BuffID.Ravens, BuffID.BatOfLight, BuffID.SharknadoMinion, BuffID.SpiderMinion, BuffID.StardustMinion, BuffID.StardustDragonMinion, BuffID.EmpressBlade, BuffID.TwinEyesMinion, BuffID.UFOMinion, BuffID.VampireFrog] },
            };

            foreach (var group in Buffs)
            {
                if (group.Key == "BUFF_MINECART")
                {
                    // There is are left-facing and right-facing buffs for minecarts; count either
                    List<CustomAchievementCondition> conds = [];
                    for (int i = 0; i < group.Value.Length; i += 2)
                        conds.Add(BuffAddCondition.AddAny(reqs, [group.Value[i], group.Value[i + 1]]));

                    RegisterAchievement("BUFF_MINECART", conds, true, AchievementCategory.Collector);
                }
                else
                    RegisterAchievement(group.Key, BuffAddCondition.AddAll(reqs, group.Value), group.Value.Length > 1, AchievementCategory.Collector);
            }
        }

        /// <summary>
        /// Register consumable achievements
        /// </summary>
        /// <param name="reqs">Common achievement requirements</param>
        private void RegisterConsumableAchievements(ConditionReqs reqs)
        {
            // Verified w/:
            // https://terraria.wiki.gg/wiki/Consumables
            // https://terraria.wiki.gg/wiki/Food
            // https://terraria.wiki.gg/wiki/Potions (added Ale/Sake to buff potions)
            Dictionary<string, int[]> Consumables = new()
            {
                { "CONSUMABLE_EXPLOSIVE", [ItemID.Bomb, ItemID.BombFish, ItemID.BouncyBomb, ItemID.BouncyDynamite, ItemID.DirtBomb, ItemID.DryBomb, ItemID.Dynamite, ItemID.HoneyBomb, ItemID.LavaBomb, ItemID.ScarabBomb, ItemID.StickyBomb, ItemID.DirtStickyBomb, ItemID.StickyDynamite, ItemID.WetBomb] },
                { "CONSUMABLE_FOOD", [ItemID.Marshmallow, ItemID.JojaCola, ItemID.Apple, ItemID.Apricot, ItemID.Banana, ItemID.BlackCurrant, ItemID.BloodOrange, ItemID.Cherry, ItemID.Coconut, ItemID.Elderberry, ItemID.Grapefruit, ItemID.Lemon, ItemID.Mango, ItemID.Peach, ItemID.Pineapple, ItemID.Plum, ItemID.Pomegranate, ItemID.Rambutan, ItemID.SpicyPepper, ItemID.Teacup, ItemID.Dragonfruit, ItemID.Starfruit, ItemID.ChristmasPudding, ItemID.CookedFish, ItemID.GingerbreadCookie, ItemID.SugarCookie, ItemID.FroggleBunwich, ItemID.AppleJuice, ItemID.BunnyStew, ItemID.CookedMarshmallow, ItemID.GrilledSquirrel, ItemID.Lemonade, ItemID.PeachSangria, ItemID.RoastedBird, ItemID.SauteedFrogLegs, ItemID.ShuckedOyster, ItemID.BowlofSoup, ItemID.MonsterLasagna, ItemID.PadThai, ItemID.PumpkinPie, ItemID.Sashimi, ItemID.BananaSplit, ItemID.CoffeeCup, ItemID.CookedShrimp, ItemID.Escargot, ItemID.Fries, ItemID.BananaDaiquiri, ItemID.FruitJuice, ItemID.LobsterTail, ItemID.Pho, ItemID.RoastedDuck, ItemID.Burger, ItemID.Pizza, ItemID.Spaghetti, ItemID.BloodyMoscato, ItemID.MilkCarton, ItemID.PinaColada, ItemID.SmoothieofDarkness, ItemID.TropicalSmoothie, ItemID.ChickenNugget, ItemID.FriedEgg, ItemID.GrubSoup, ItemID.IceCream, ItemID.SeafoodDinner, ItemID.CreamSoda, ItemID.Grapes, ItemID.Hotdog, ItemID.Nachos, ItemID.FruitSalad, ItemID.PotatoChips, ItemID.ShrimpPoBoy, ItemID.ChocolateChipCookie, ItemID.PrismaticPunch, ItemID.ApplePie, ItemID.GrapeJuice, ItemID.Milkshake, ItemID.Steak, ItemID.BBQRibs, ItemID.Bacon, ItemID.GoldenDelight] },
                { "CONSUMABLE_LICENSE", [ItemID.LicenseCat, ItemID.LicenseDog, ItemID.LicenseBunny] },
                { "CONSUMABLE_POTION_BUFF", [ItemID.AmmoReservationPotion, ItemID.ArcheryPotion, ItemID.BattlePotion, ItemID.BiomeSightPotion, ItemID.BuilderPotion, ItemID.CalmingPotion, ItemID.CratePotion, ItemID.TrapsightPotion, ItemID.EndurancePotion, ItemID.FeatherfallPotion, ItemID.FishingPotion, ItemID.FlipperPotion, ItemID.GillsPotion, ItemID.GravitationPotion, ItemID.LuckPotionGreater, ItemID.HeartreachPotion, ItemID.HunterPotion, ItemID.InfernoPotion, ItemID.InvisibilityPotion, ItemID.IronskinPotion, ItemID.LuckPotionLesser, ItemID.LifeforcePotion, ItemID.LovePotion, ItemID.LuckPotion, ItemID.MagicPowerPotion, ItemID.ManaRegenerationPotion, ItemID.MiningPotion, ItemID.NightOwlPotion, ItemID.ObsidianSkinPotion, ItemID.RagePotion, ItemID.RegenerationPotion, ItemID.ShinePotion, ItemID.SonarPotion, ItemID.SpelunkerPotion, ItemID.StinkPotion, ItemID.SummoningPotion, ItemID.SwiftnessPotion, ItemID.ThornsPotion, ItemID.TitanPotion, ItemID.WarmthPotion, ItemID.WaterWalkingPotion, ItemID.WrathPotion, ItemID.Ale, ItemID.Sake] },
                { "CONSUMABLE_POTION_FLASK", [ItemID.FlaskofCursedFlames, ItemID.FlaskofFire, ItemID.FlaskofGold, ItemID.FlaskofIchor, ItemID.FlaskofNanites, ItemID.FlaskofParty, ItemID.FlaskofPoison, ItemID.FlaskofVenom] },
                { "CONSUMABLE_POTION_RECOVERY", [ItemID.Mushroom, ItemID.BottledHoney, ItemID.GreaterHealingPotion, ItemID.HealingPotion, ItemID.LesserHealingPotion, ItemID.ManaPotion, ItemID.RestorationPotion, ItemID.SuperHealingPotion, ItemID.SuperManaPotion, ItemID.BottledWater, ItemID.GreaterManaPotion, ItemID.LesserManaPotion, ItemID.Eggnog, ItemID.Honeyfin, ItemID.StrangeBrew] },
                { "CONSUMABLE_POTION_OTHER", [ItemID.GenderChangePotion, ItemID.PotionOfReturn, ItemID.RecallPotion, ItemID.TeleportationPotion] },
                { "CONSUMABLE_PERMANENT", [ItemID.LifeCrystal, ItemID.LifeFruit, ItemID.ManaCrystal, ItemID.CombatBook, ItemID.ArtisanLoaf, ItemID.TorchGodsFavor, ItemID.AegisCrystal, ItemID.AegisFruit, ItemID.ArcaneCrystal, ItemID.Ambrosia, ItemID.GummyWorm, ItemID.GalaxyPearl, ItemID.CombatBookVolumeTwo, ItemID.PeddlersSatchel] },
                { "CONSUMABLE_TOOL", [ItemID.PurificationPowder, ItemID.VilePowder, ItemID.ViciousPowder, ItemID.HolyWater, ItemID.UnholyWater, ItemID.BloodWater, ItemID.Glowstick, ItemID.StickyGlowstick, ItemID.BouncyGlowstick, ItemID.SpelunkerGlowstick, ItemID.FairyGlowstick, ItemID.ChumBucket, ItemID.Fertilizer] },
                { "CONSUMABLE_WEAPON", [ItemID.PaperAirplaneA, ItemID.PaperAirplaneB, ItemID.Snowball, ItemID.Shuriken, ItemID.RottenEgg, ItemID.ThrowingKnife, ItemID.PoisonedKnife, ItemID.Beenade, ItemID.BoneDagger, ItemID.StarAnise, ItemID.SpikyBall, ItemID.Javelin, ItemID.FrostDaggerfish, ItemID.Bone, ItemID.MolotovCocktail, ItemID.BoneJavelin, ItemID.PartyGirlGrenade, ItemID.Grenade, ItemID.StickyGrenade, ItemID.BouncyGrenade] },
                { "CONSUMABLE_OTHER", [ItemID.StinkPotion, ItemID.LovePotion, ItemID.SmokeBomb, ItemID.ConfettiGun, ItemID.BeachBall, ItemID.Football, ItemID.Geode, ItemID.TreeGlobe, ItemID.MoonGlobe, ItemID.WorldGlobe, ItemID.ReleaseLantern, ItemID.ReleaseDoves, ItemID.GelBalloon] },
            };

            foreach (var group in Consumables)
                RegisterAchievement(group.Key, ItemUseCondition.UseAll(reqs, group.Value), group.Value.Length > 1, AchievementCategory.Collector);
        }
    }
}