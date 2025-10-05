using System.Collections.Generic;
using Terraria.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using TerrariaAchievementLib.Achievements;
using TerrariaAchievementLib.Achievements.Conditions;

namespace CompletionistAchievements.Achievements.Weapon.Melee
{
    public class Info
    {
        // Verified w/ https://terraria.wiki.gg/wiki/Weapons
        public static readonly Dictionary<string, int[]> MeleeWeapons = new()
        {
            { "SWORD",     [ItemID.CopperShortsword, ItemID.TinShortsword, ItemID.WoodenSword, ItemID.BorealWoodSword, ItemID.CopperBroadsword, ItemID.IronShortsword, ItemID.PalmWoodSword, ItemID.RichMahoganySword, ItemID.CactusSword, ItemID.LeadShortsword, ItemID.SilverShortsword, ItemID.TinBroadsword, ItemID.EbonwoodSword, ItemID.IronBroadsword, ItemID.ShadewoodSword, ItemID.TungstenShortsword, ItemID.GoldShortsword, ItemID.LeadBroadsword, ItemID.SilverBroadsword, ItemID.BladedGlove, ItemID.TungstenBroadsword, ItemID.ZombieArm, ItemID.AshWoodSword, ItemID.GoldBroadsword, ItemID.Flymeal, ItemID.PlatinumShortsword, ItemID.AntlionClaw, ItemID.StylistKilLaKillScissorsIWish, ItemID.Ruler, ItemID.PlatinumBroadsword, ItemID.Umbrella, ItemID.BreathingReed, ItemID.Gladius, ItemID.BoneSword, ItemID.BatBat, ItemID.TentacleSpike, ItemID.CandyCaneSword, ItemID.Katana, ItemID.IceBlade, ItemID.LightsBane, ItemID.TragicUmbrella, ItemID.Muramasa, ItemID.DyeTradersScimitar, ItemID.BluePhaseblade, ItemID.GreenPhaseblade, ItemID.OrangePhaseblade, ItemID.PurplePhaseblade, ItemID.RedPhaseblade, ItemID.WhitePhaseblade, ItemID.YellowPhaseblade, ItemID.BloodButcherer, ItemID.Starfury, ItemID.EnchantedSword, ItemID.PurpleClubberfish, ItemID.BeeKeeper, ItemID.FalconBlade, ItemID.BladeofGrass, ItemID.FieryGreatsword, ItemID.NightsEdge, ItemID.PearlwoodSword, ItemID.TaxCollectorsStickOfDoom, ItemID.SlapHand, ItemID.CobaltSword, ItemID.PalladiumSword, ItemID.BluePhasesaber, ItemID.GreenPhasesaber, ItemID.OrangePhasesaber, ItemID.PurplePhasesaber, ItemID.RedPhasesaber, ItemID.WhitePhasesaber, ItemID.YellowPhasesaber, ItemID.IceSickle, ItemID.DD2SquireDemonSword, ItemID.MythrilSword, ItemID.OrichalcumSword, ItemID.BreakerBlade, ItemID.Cutlass, ItemID.Frostbrand, ItemID.AdamantiteSword, ItemID.BeamSword, ItemID.TitaniumSword, ItemID.FetidBaghnakhs, ItemID.Bladetongue, ItemID.HamBat, ItemID.Excalibur, ItemID.TrueExcalibur, ItemID.ChlorophyteSaber, ItemID.DeathSickle, ItemID.PsychoKnife, ItemID.Keybrand, ItemID.ChlorophyteClaymore, ItemID.TheHorsemansBlade, ItemID.ChristmasTreeSword, ItemID.TrueNightsEdge, ItemID.Seedler, ItemID.DD2SquireBetsySword, ItemID.TerraBlade, ItemID.InfluxWaver, ItemID.StarWrath, ItemID.Meowmere] },
            { "YOYO",      [ItemID.WoodYoyo, ItemID.Rally, ItemID.CorruptYoyo, ItemID.CrimsonYoyo, ItemID.JungleYoyo, ItemID.Code1, ItemID.Valor, ItemID.Cascade, ItemID.HiveFive, ItemID.FormatC, ItemID.Gradient, ItemID.Chik, ItemID.HelFire, ItemID.Amarok, ItemID.Code2, ItemID.Yelets, ItemID.Kraken, ItemID.TheEyeOfCthulhu, ItemID.Terrarian] },
            { "SPEAR",     [ItemID.Spear, ItemID.Trident, ItemID.ThunderStaff, ItemID.TheRottedFork, ItemID.Swordfish, ItemID.DarkLance, ItemID.CobaltNaginata, ItemID.PalladiumPike, ItemID.MythrilHalberd, ItemID.OrichalcumHalberd, ItemID.AdamantiteGlaive, ItemID.TitaniumTrident, ItemID.Gungnir, ItemID.MonkStaffT2, ItemID.ChlorophytePartisan, ItemID.MushroomSpear, ItemID.ObsidianSwordfish, ItemID.NorthPole] },
            { "BOOMERANG", [ItemID.WoodenBoomerang, ItemID.EnchantedBoomerang, ItemID.FruitcakeChakram, ItemID.BloodyMachete, ItemID.Shroomerang, ItemID.IceBoomerang, ItemID.ThornChakram, ItemID.CombatWrench, ItemID.Flamarang, ItemID.Trimarang, ItemID.FlyingKnife, ItemID.BouncingShield, ItemID.LightDisc, ItemID.Bananarang, ItemID.PossessedHatchet, ItemID.PaladinsHammer] },
            { "FLAIL",     [ItemID.Mace, ItemID.FlamingMace, ItemID.BallOHurt, ItemID.TheMeatball, ItemID.BlueMoon, ItemID.Sunfury, ItemID.ChainKnife, ItemID.DripplerFlail, ItemID.DaoofPow, ItemID.FlowerPow, ItemID.Anchor, ItemID.ChainGuillotines, ItemID.KOCannon, ItemID.GolemFist, ItemID.Flairon] },
            { "OTHER",     [ItemID.Terragrim, ItemID.JoustingLance, ItemID.ShadowFlameKnife, ItemID.HallowJoustingLance, ItemID.MonkStaffT1, ItemID.ScourgeoftheCorruptor, ItemID.VampireKnives, ItemID.ShadowJoustingLance, ItemID.PiercingStarlight, ItemID.MonkStaffT3, ItemID.DayBreak, ItemID.SolarEruption, ItemID.Zenith] }
        };

        // Verified w/ https://terraria.wiki.gg/wiki/Skeleton_Merchant
        public static readonly int[] SkeletonMerchantYoyoStuff = [ItemID.BlueCounterweight, ItemID.RedCounterweight, ItemID.PurpleCounterweight, ItemID.GreenCounterweight, ItemID.Gradient, ItemID.FormatC, ItemID.YoYoGlove];
    }

    public class WeaponBatBatAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponBatBatAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.BatBat));
        }
    }

    public class WeaponBeamSwordAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponBeamSwordAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.BeamSword));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponBatBatAchievement>());
        }
    }

    public class WeaponBladedGloveAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponBladedGloveAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.BladedGlove));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponBeamSwordAchievement>());
        }
    }

    public class WeaponBladetongueAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponBladetongueAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemCatchCondition.Catch(Common.reqs, ItemID.Bladetongue));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponBladedGloveAchievement>());
        }
    }

    public class WeaponBoneSwordAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponBoneSwordAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.BoneSword));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponBladetongueAchievement>());
        }
    }

    public class WeaponExoticScimitarAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponExoticScimitarAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemGrabCondition.Grab(Common.reqs, ItemID.DyeTradersScimitar));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponBoneSwordAchievement>());
        }
    }

    public class WeaponGladiusAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponGladiusAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.Gladius));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponExoticScimitarAchievement>());
        }
    }

    public class WeaponMandibleBladeAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponMandibleBladeAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.AntlionClaw));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponGladiusAchievement>());
        }
    }

    public class WeaponStylishScissorsAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponStylishScissorsAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemGrabCondition.Grab(Common.reqs, ItemID.StylistKilLaKillScissorsIWish));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponMandibleBladeAchievement>());
        }
    }

    public class WeaponZombieArmAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponZombieArmAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.ZombieArm));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponStylishScissorsAchievement>());
        }
    }

    public class WeaponClassyCaneAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponClassyCaneAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemGrabCondition.Grab(Common.reqs, ItemID.TaxCollectorsStickOfDoom));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponZombieArmAchievement>());
        }
    }

    public class WeaponIceSickleAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponIceSickleAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.IceSickle));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponClassyCaneAchievement>());
        }
    }

    public class WeaponKeybrandAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponKeybrandAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.Keybrand));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponIceSickleAchievement>());
        }
    }

    public class WeaponCascadeAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponCascadeAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.Cascade));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponKeybrandAchievement>());
        }
    }

    public class WeaponAmarokAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponAmarokAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.Amarok));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponCascadeAchievement>());
        }
    }

    public class WeaponHelfireAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponHelfireAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.HelFire));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponAmarokAchievement>());
        }
    }

    public class WeaponKrakenAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponKrakenAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.Kraken));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponHelfireAchievement>());
        }
    }

    public class WeaponYeletsAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponYeletsAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.Yelets));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponKrakenAchievement>());
        }
    }

    public class WeaponSkeletonMerchantAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponSkeletonMerchantAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            foreach (var condition in NpcBuyCondition.BuyAll(Common.reqs, NPCID.SkeletonMerchant, Info.SkeletonMerchantYoyoStuff))
                AddCondition(condition);
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponYeletsAchievement>());
        }
    }

    public class WeaponObsidianSwordfishAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponObsidianSwordfishAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemCatchCondition.Catch(Common.reqs, ItemID.ObsidianSwordfish));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponSkeletonMerchantAchievement>());
        }
    }

    public class WeaponBloodyMacheteAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponBloodyMacheteAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.BloodyMachete));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponObsidianSwordfishAchievement>());
        }
    }

    public class WeaponCombatWrenchAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponCombatWrenchAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemGrabCondition.Grab(Common.reqs, ItemID.CombatWrench));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponBloodyMacheteAchievement>());
        }
    }

    public class WeaponShroomerangAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponShroomerangAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.Shroomerang));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponCombatWrenchAchievement>());
        }
    }

    public class WeaponBananarangAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponBananarangAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.Bananarang));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponShroomerangAchievement>());
        }
    }

    public class WeaponPaladinsHammerAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponPaladinsHammerAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.PaladinsHammer));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponBananarangAchievement>());
        }
    }

    public class WeaponChainKnifeAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponChainKnifeAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.CaveBat, ItemID.ChainKnife));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponPaladinsHammerAchievement>());
        }
    }

    public class WeaponDripplerCripplerAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponDripplerCripplerAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.DripplerFlail));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponChainKnifeAchievement>());
        }
    }

    public class WeaponTerragrimAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponTerragrimAchievement";

        public override void AutoStaticDefaults() { }

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, Common.BreakAndGrabItem(Common.reqs, ItemID.Terragrim));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponDripplerCripplerAchievement>());
        }
    }

    public class WeaponMeleeSwordAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponMeleeSwordAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.MeleeWeapons["SWORD"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponTerragrimAchievement>());
        }
    }

    public class WeaponMeleeYoyoAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponMeleeYoyoAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.MeleeWeapons["YOYO"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponMeleeSwordAchievement>());
        }
    }

    public class WeaponMeleeSpearAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponMeleeSpearAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.MeleeWeapons["SPEAR"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponMeleeYoyoAchievement>());
        }
    }

    public class WeaponMeleeBoomerangAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponMeleeBoomerangAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.MeleeWeapons["BOOMERANG"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponMeleeSpearAchievement>());
        }
    }

    public class WeaponMeleeFlailAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponMeleeFlailAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.MeleeWeapons["FLAIL"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponMeleeBoomerangAchievement>());
        }
    }

    public class WeaponMeleeOtherAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponMeleeOtherAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.MeleeWeapons["OTHER"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponMeleeFlailAchievement>());
        }
    }
}
