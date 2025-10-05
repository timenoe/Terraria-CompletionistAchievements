using System.Collections.Generic;
using Terraria.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using TerrariaAchievementLib.Achievements;
using TerrariaAchievementLib.Achievements.Conditions;
using CompletionistAchievements.Achievements.Accessory;

namespace CompletionistAchievements.Achievements.Mounts
{
    public class Info
    {
        // Verified w/ https://terraria.wiki.gg/wiki/Mounts
        public static readonly int[] Mounts = [ItemID.SlimySaddle, ItemID.HoneyedGoggles, ItemID.HardySaddle, ItemID.FuzzyCarrot, ItemID.PogoStick, ItemID.GolfCart, ItemID.MolluskWhistle, ItemID.PaintedHorseSaddle, ItemID.MajesticHorseSaddle, ItemID.DarkHorseSaddle, ItemID.SuperheatedBlood, ItemID.AncientHorn, ItemID.WolfMountItem, ItemID.BlessedApple, ItemID.ScalyTruffle, ItemID.QueenSlimeMountSaddle, ItemID.ReindeerBells, ItemID.BrainScrambler, ItemID.CosmicCarKey, ItemID.DrillContainmentUnit];
    }

    public class MountBeeAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/MountBeeAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemGrabCondition.Grab(Common.reqs, ItemID.HoneyedGoggles));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<AccessoryOtherAchievement>());
        }
    }

    public class MountTurtleAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/MountTurtleAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemOpenCondition.Open(Common.reqs, ItemID.None, ItemID.HardySaddle));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<MountBeeAchievement>());
        }
    }

    public class MountGolfCartAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/MountGolfCartAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcBuyCondition.Buy(Common.reqs, NPCID.Golfer, ItemID.GolfCart));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<MountTurtleAchievement>());
        }
    }

    public class MountBasiliskAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/MountBasiliskAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.AncientHorn));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<MountGolfCartAchievement>());
        }
    }

    public class MountWolfAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/MountWolfAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.WolfMountItem));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<MountBasiliskAchievement>());
        }
    }

    public class MountUnicornAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/MountUnicornAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.BlessedApple));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<MountWolfAchievement>());
        }
    }

    public class MountPigronAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/MountPigronAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemCatchCondition.Catch(Common.reqs, ItemID.ScalyTruffle));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<MountUnicornAchievement>());
        }
    }

    public class MountRudolphAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/MountRudolphAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.ReindeerBells));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<MountPigronAchievement>());
        }
    }

    public class MountDcuAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/MountDcuAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemCraftCondition.Craft(Common.reqs, ItemID.DrillContainmentUnit));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<MountRudolphAchievement>());
        }
    }

    public class MountAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/MountAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.Mounts));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<MountDcuAchievement>());
        }
    }
}
