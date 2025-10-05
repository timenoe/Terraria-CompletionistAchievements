using System.Collections.Generic;
using Terraria.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using TerrariaAchievementLib.Achievements;
using TerrariaAchievementLib.Achievements.Conditions;
using CompletionistAchievements.Achievements.Weapon.Placeable;

namespace CompletionistAchievements.Achievements.Ammo
{
    public class Info
    {
        public static readonly Dictionary<string, int[]> Ammo = new()
        {
            { "FLARE",    [ItemID.Flare, ItemID.BlueFlare, ItemID.SpelunkerFlare, ItemID.CursedFlare, ItemID.RainbowFlare, ItemID.ShimmerFlare] },
            { "BULLET",   [ItemID.MusketBall, ItemID.MeteorShot, ItemID.SilverBullet, ItemID.CrystalBullet, ItemID.CursedBullet, ItemID.ChlorophyteBullet, ItemID.HighVelocityBullet, ItemID.IchorBullet, ItemID.VenomBullet, ItemID.PartyBullet, ItemID.NanoBullet, ItemID.ExplodingBullet, ItemID.GoldenBullet, ItemID.EndlessMusketPouch, ItemID.MoonlordBullet, ItemID.TungstenBullet] },
            { "ARROW",    [ItemID.WoodenArrow, ItemID.FlamingArrow, ItemID.UnholyArrow, ItemID.JestersArrow, ItemID.HellfireArrow, ItemID.HolyArrow, ItemID.CursedArrow, ItemID.FrostburnArrow, ItemID.ChlorophyteArrow, ItemID.IchorArrow, ItemID.VenomArrow, ItemID.BoneArrow, ItemID.EndlessQuiver, ItemID.MoonlordArrow, ItemID.ShimmerArrow] },
            { "ROCKET",   [ItemID.RocketI, ItemID.RocketII, ItemID.RocketIII, ItemID.RocketIV, ItemID.ClusterRocketI, ItemID.ClusterRocketII, ItemID.DryRocket, ItemID.WetRocket, ItemID.LavaRocket, ItemID.HoneyRocket, ItemID.MiniNukeI, ItemID.MiniNukeII] },
            { "DART",     [ItemID.PoisonDart, ItemID.CrystalDart, ItemID.CursedDart, ItemID.IchorDart] },
            { "SOLUTION", [ItemID.GreenSolution, ItemID.SandSolution, ItemID.SnowSolution, ItemID.DirtSolution, ItemID.BlueSolution, ItemID.PurpleSolution, ItemID.DarkBlueSolution, ItemID.RedSolution] }
        };
    }
    
    public class AmmoFlareAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/AmmoFlareAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.Ammo["FLARE"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponPlaceableAchievement>());
        }
    }

    public class AmmoBulletAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/AmmoBulletAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.Ammo["BULLET"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<AmmoFlareAchievement>());
        }
    }

    public class AmmoArrowAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/AmmoArrowAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.Ammo["ARROW"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<AmmoBulletAchievement>());
        }
    }

    public class AmmoRocketAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/AmmoRocketAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.Ammo["ROCKET"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<AmmoArrowAchievement>());
        }
    }

    public class AmmoDartAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/AmmoDartAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.Ammo["DART"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<AmmoRocketAchievement>());
        }
    }

    public class AmmoSolutionAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/AmmoSolutionAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.Ammo["SOLUTION"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<AmmoDartAchievement>());
        }
    }
}
