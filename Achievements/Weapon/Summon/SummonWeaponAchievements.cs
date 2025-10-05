using System.Collections.Generic;
using Terraria.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using TerrariaAchievementLib.Achievements;
using TerrariaAchievementLib.Achievements.Conditions;
using CompletionistAchievements.Achievements.Weapon.Magic;

namespace CompletionistAchievements.Achievements.Weapon.Summon
{
    public class Info
    {
        // Verified w/ https://terraria.wiki.gg/wiki/Weapons
        public static readonly Dictionary<string, int[]> SummonWeapons = new()
        {
            { "MINION", [ItemID.BabyBirdStaff, ItemID.SlimeStaff, ItemID.FlinxStaff, ItemID.AbigailsFlower, ItemID.HornetStaff, ItemID.VampireFrogStaff, ItemID.ImpStaff, ItemID.Smolstar, ItemID.SpiderStaff, ItemID.PirateStaff, ItemID.SanguineStaff, ItemID.OpticStaff, ItemID.DeadlySphereStaff, ItemID.PygmyStaff, ItemID.RavenStaff, ItemID.StormTigerStaff, ItemID.TempestStaff, ItemID.EmpressBlade, ItemID.XenoStaff, ItemID.StardustCellStaff, ItemID.StardustDragonStaff] },
            { "SENTRY", [ItemID.HoundiusShootius, ItemID.DD2LightningAuraT1Popper, ItemID.DD2FlameburstTowerT1Popper, ItemID.DD2ExplosiveTrapT1Popper, ItemID.DD2BallistraTowerT1Popper, ItemID.QueenSpiderStaff, ItemID.StaffoftheFrostHydra, ItemID.MoonlordTurretStaff, ItemID.RainbowCrystalStaff, ItemID.DD2LightningAuraT2Popper, ItemID.DD2FlameburstTowerT2Popper, ItemID.DD2ExplosiveTrapT2Popper, ItemID.DD2BallistraTowerT2Popper, ItemID.DD2LightningAuraT3Popper, ItemID.DD2FlameburstTowerT3Popper, ItemID.DD2ExplosiveTrapT3Popper, ItemID.DD2BallistraTowerT3Popper] },
            { "WHIP",   [ItemID.BlandWhip, ItemID.ThornWhip, ItemID.BoneWhip, ItemID.FireWhip, ItemID.CoolWhip, ItemID.SwordWhip, ItemID.ScytheWhip, ItemID.MaceWhip, ItemID.RainbowWhip] }
        };
    }

    public class WeaponAbigailsFlowerAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponAbigailsFlowerAchievement";

        public override void AutoStaticDefaults() { }

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, Common.BreakAndGrabItem(Common.reqs, ItemID.AbigailsFlower));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponMagicOtherAchievement>());
        }
    }

    public class WeaponSlimeStaffAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponSlimeStaffAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.SlimeStaff));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponAbigailsFlowerAchievement>());
        }
    }

    public class WeaponVampireFrogStaffAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponVampireFrogStaffAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.VampireFrogStaff));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponSlimeStaffAchievement>());
        }
    }

    public class WeaponPirateStaffAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponPirateStaffAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.PirateStaff));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponVampireFrogStaffAchievement>());
        }
    }

    public class WeaponSanguineStaffAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponSanguineStaffAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.BloodNautilus, ItemID.SanguineStaff));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponPirateStaffAchievement>());
        }
    }

    public class WeaponTerraprismaAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponTerraprismaAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.HallowBoss, ItemID.EmpressBlade));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponSanguineStaffAchievement>());
        }
    }

    public class WeaponMorningStarAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponMorningStarAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.MaceWhip));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponTerraprismaAchievement>());
        }
    }

    public class WeaponSummonMinionAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponSummonMinionAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.SummonWeapons["MINION"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponMorningStarAchievement>());
        }
    }

    public class WeaponSummonSentryAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponSummonSentryAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.SummonWeapons["SENTRY"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponSummonMinionAchievement>());
        }
    }

    public class WeaponSummonWhipAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponSummonWhipAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.SummonWeapons["WHIP"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponSummonSentryAchievement>());
        }
    }
}
