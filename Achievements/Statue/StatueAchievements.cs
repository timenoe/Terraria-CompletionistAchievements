using System.Collections.Generic;
using Terraria.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using TerrariaAchievementLib.Achievements;
using TerrariaAchievementLib.Achievements.Conditions;
using CompletionistAchievements.Achievements.Pylon;

namespace CompletionistAchievements.Achievements.Statue
{
    public class Info
    {
        // Verified w/ https://terraria.wiki.gg/wiki/Statues
        public static readonly Dictionary<string, int[]> Statues = new()
        {
            { "ENEMY",   [ItemID.ZombieArmStatue, ItemID.BatStatue, ItemID.BloodZombieStatue, ItemID.BoneSkeletonStatue, ItemID.ChestStatue, ItemID.CorruptStatue, ItemID.CrabStatue, ItemID.DripplerStatue, ItemID.EyeballStatue, ItemID.GoblinStatue, ItemID.GraniteGolemStatue, ItemID.HarpyStatue, ItemID.HopliteStatue, ItemID.HornetStatue, ItemID.ImpStatue, ItemID.JellyfishStatue, ItemID.MedusaStatue, ItemID.PigronStatue, ItemID.PiranhaStatue, ItemID.SharkStatue, ItemID.SkeletonStatue, ItemID.SlimeStatue, ItemID.UndeadVikingStatue, ItemID.UnicornStatue, ItemID.WallCreeperStatue, ItemID.WraithStatue] },
            { "CRITTER", [ItemID.BirdStatue, ItemID.BuggyStatue, ItemID.BunnyStatue, ItemID.ButterflyStatue, ItemID.CockatielStatue, ItemID.DragonflyStatue, ItemID.DuckStatue, ItemID.FireflyStatue, ItemID.FishStatue, ItemID.FrogStatue, ItemID.GrasshopperStatue, ItemID.MacawStatue, ItemID.MouseStatue, ItemID.OwlStatue, ItemID.PenguinStatue, ItemID.ScorpionStatue, ItemID.SeagullStatue, ItemID.SnailStatue, ItemID.SquirrelStatue, ItemID.ToucanStatue, ItemID.TurtleStatue, ItemID.WormStatue] },
            { "DECOR",   [ItemID.AnvilStatue, ItemID.ArmorStatue, ItemID.AxeStatue, ItemID.BoomerangStatue, ItemID.BootStatue, ItemID.BowStatue, ItemID.CrossStatue, ItemID.GargoyleStatue, ItemID.GloomStatue, ItemID.HammerStatue, ItemID.PickaxeStatue, ItemID.PillarStatue, ItemID.PotStatue, ItemID.PotionStatue, ItemID.ReaperStatue, ItemID.ShieldStatue, ItemID.SpearStatue, ItemID.SunflowerStatue, ItemID.SwordStatue, ItemID.TreeStatue, ItemID.WomanStatue, ItemID.LihzahrdStatue, ItemID.LihzahrdGuardianStatue, ItemID.LihzahrdWatcherStatue] },
            { "OTHER",   [ItemID.KingStatue, ItemID.QueenStatue, ItemID.BombStatue, ItemID.HeartStatue, ItemID.StarStatue, ItemID.MushroomStatue, ItemID.BoulderStatue, ItemID.CatBast, ItemID.AngelStatue] }
        };
    }

    public class StatueEnemyAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/StatueEnemyAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.Statues["ENEMY"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<PylonAchievement>());
        }
    }

    public class StatueCritterAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/StatueCritterAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.Statues["CRITTER"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<StatueEnemyAchievement>());
        }
    }

    public class StatueDecorAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/StatueDecorAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.Statues["DECOR"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<StatueCritterAchievement>());
        }
    }

    public class StatueOtherAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/StatueOtherAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.Statues["OTHER"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<StatueDecorAchievement>());
        }
    }
}
