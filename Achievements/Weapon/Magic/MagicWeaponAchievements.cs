using System.Collections.Generic;
using Terraria.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using TerrariaAchievementLib.Achievements;
using TerrariaAchievementLib.Achievements.Conditions;
using CompletionistAchievements.Achievements.Weapon.Ranged;

namespace CompletionistAchievements.Achievements.Weapon.Magic
{
    public class Info
    {
        // Verified w/ https://terraria.wiki.gg/wiki/Weapons
        public static readonly Dictionary<string, int[]> MagicWeapons = new()
        {
            { "WAND",  [ItemID.WandofSparking, ItemID.WandofFrosting, ItemID.ThunderStaff, ItemID.AmethystStaff, ItemID.TopazStaff, ItemID.SapphireStaff, ItemID.EmeraldStaff, ItemID.RubyStaff, ItemID.DiamondStaff, ItemID.AmberStaff, ItemID.Vilethorn, ItemID.WeatherPain, ItemID.MagicMissile, ItemID.AquaScepter, ItemID.FlowerofFire, ItemID.Flamelash, ItemID.SkyFracture, ItemID.CrystalSerpent, ItemID.FlowerofFrost, ItemID.FrostStaff, ItemID.CrystalVileShard, ItemID.SoulDrain, ItemID.MeteorStaff, ItemID.PoisonStaff, ItemID.RainbowRod, ItemID.UnholyTrident, ItemID.BookStaff, ItemID.VenomStaff, ItemID.NettleBurst, ItemID.BatScepter, ItemID.BlizzardStaff, ItemID.InfernoFork, ItemID.ShadowbeamStaff, ItemID.SpectreStaff, ItemID.PrincessWeapon, ItemID.Razorpine, ItemID.StaffofEarth, ItemID.ApprenticeStaffT3] },
            { "GUN",   [ItemID.ZapinatorGray, ItemID.SpaceGun, ItemID.BeeGun, ItemID.LaserRifle, ItemID.ZapinatorOrange, ItemID.WaspGun, ItemID.LeafBlower, ItemID.RainbowGun, ItemID.HeatRay, ItemID.LaserMachinegun, ItemID.ChargedBlasterCannon, ItemID.BubbleGun] },
            { "BOOK",  [ItemID.WaterBolt, ItemID.BookofSkulls, ItemID.DemonScythe, ItemID.CursedFlames, ItemID.GoldenShower, ItemID.CrystalStorm, ItemID.MagnetSphere, ItemID.RazorbladeTyphoon, ItemID.LunarFlareBook] },
            { "OTHER", [ItemID.CrimsonRod, ItemID.IceRod, ItemID.ClingerStaff, ItemID.NimbusRod, ItemID.MagicDagger, ItemID.MedusaHead, ItemID.SpiritFlame, ItemID.ShadowFlameHexDoll, ItemID.SharpTears, ItemID.MagicalHarp, ItemID.ToxicFlask, ItemID.FairyQueenMagicItem, ItemID.SparkleGuitar, ItemID.NebulaArcanum, ItemID.NebulaBlaze, ItemID.LastPrism] }
        };
    }

    public class WeaponCrystalSerpentAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponCrystalSerpentAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemCatchCondition.Catch(Common.reqs, ItemID.CrystalSerpent));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponRangedOtherAchievement>());
        }
    }

    public class WeaponFrostStaffAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponFrostStaffAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.FrostStaff));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponCrystalSerpentAchievement>());
        }
    }

    public class WeaponPoisonStaffAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponPoisonStaffAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.PoisonStaff));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponFrostStaffAchievement>());
        }
    }

    public class WeaponResonanceScepterAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponResonanceScepterAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemGrabCondition.Grab(Common.reqs, ItemID.PrincessWeapon));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponPoisonStaffAchievement>());
        }
    }

    public class WeaponUnholyTridentAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponUnholyTridentAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.RedDevil, ItemID.UnholyTrident));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponResonanceScepterAchievement>());
        }
    }

    public class WeaponDemonScytheAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponDemonScytheAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.DemonScythe));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponUnholyTridentAchievement>());
        }
    }

    public class WeaponWaterBoltAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponWaterBoltAchievement";

        public override void AutoStaticDefaults() { }

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, Common.BreakAndGrabItem(Common.reqs, ItemID.WaterBolt));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponDemonScytheAchievement>());
        }
    }

    public class WeaponBloodThornAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponBloodThornAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.SharpTears));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponWaterBoltAchievement>());
        }
    }

    public class WeaponMedusaHeadAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponMedusaHeadAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.MedusaHead));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponBloodThornAchievement>());
        }
    }

    public class WeaponNimbusRodAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponNimbusRodAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.NimbusRod));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponMedusaHeadAchievement>());
        }
    }

    public class WeaponStellarTuneAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponStellarTuneAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemGrabCondition.Grab(Common.reqs, ItemID.SparkleGuitar));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponNimbusRodAchievement>());
        }
    }

    public class WeaponMagicWandAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponMagicWandAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.MagicWeapons["WAND"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponStellarTuneAchievement>());
        }
    }

    public class WeaponMagicGunAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponMagicGunAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.MagicWeapons["GUN"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponMagicWandAchievement>());
        }
    }

    public class WeaponMagicBookAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponMagicBookAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.MagicWeapons["BOOK"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponMagicGunAchievement>());
        }
    }

    public class WeaponMagicOtherAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponMagicOtherAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.MagicWeapons["OTHER"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponMagicBookAchievement>());
        }
    }
}
