using System.Collections.Generic;
using Terraria.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using TerrariaAchievementLib.Achievements;
using TerrariaAchievementLib.Achievements.Conditions;
using CompletionistAchievements.Achievements.Statue;

namespace CompletionistAchievements.Achievements.Storage
{
    public class Info
    {
        // Verified w/ https://terraria.wiki.gg/wiki/Storage_items#Portable_Storage
        public static readonly int[] PortableStorage = [ItemID.PiggyBank, ItemID.MoneyTrough, ItemID.VoidVault, ItemID.VoidLens, ItemID.Safe, ItemID.DefendersForge, ItemID.ChesterPetItem];
    }
    
    public class StorageMoneyTroughAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/StorageMoneyTroughAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.MoneyTrough));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<StatueOtherAchievement>());
        }
    }

    public class StorageAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/StorageAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.PortableStorage));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<StorageMoneyTroughAchievement>());
        }
    }
}
