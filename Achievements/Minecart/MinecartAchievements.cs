using System.Collections.Generic;
using Terraria.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using TerrariaAchievementLib.Achievements;
using TerrariaAchievementLib.Achievements.Conditions;
using CompletionistAchievements.Achievements.Mounts;

namespace CompletionistAchievements.Achievements.Minecart
{
    public class Info
    {
        // Verified w/ https://terraria.wiki.gg/wiki/Minecarts
        public static readonly int[] Minecarts = [ItemID.Minecart, ItemID.DesertMinecart, ItemID.FishMinecart, ItemID.BeeMinecart, ItemID.LadybugMinecart, ItemID.PigronMinecart, ItemID.SunflowerMinecart, ItemID.HellMinecart, ItemID.ShroomMinecart, ItemID.AmethystMinecart, ItemID.TopazMinecart, ItemID.SapphireMinecart, ItemID.EmeraldMinecart, ItemID.RubyMinecart, ItemID.DiamondMinecart, ItemID.AmberMinecart, ItemID.BeetleMinecart, ItemID.MeowmereMinecart, ItemID.PartyMinecart, ItemID.PirateMinecart, ItemID.SteampunkMinecart, ItemID.CoffinMinecart, ItemID.DiggingMoleMinecart, ItemID.FartMinecart, ItemID.TerraFartMinecart];
    }
    
    public class MinecartFishAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/MinecartFishAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcGiftCondition.Gift(Common.reqs, NPCID.Angler, ItemID.FishMinecart));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<MountAchievement>());
        }
    }

    public class MinecartPigronAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/MinecartPigronAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.PigronMinecart));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<MinecartFishAchievement>());
        }
    }

    public class MinecartAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/MinecartAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.Minecarts));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<MinecartPigronAchievement>());
        }
    }
}
