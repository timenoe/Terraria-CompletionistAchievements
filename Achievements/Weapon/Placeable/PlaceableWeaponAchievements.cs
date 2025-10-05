using System.Collections.Generic;
using Terraria.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using TerrariaAchievementLib.Achievements;
using TerrariaAchievementLib.Achievements.Conditions;
using CompletionistAchievements.Achievements.Weapon.Summon;

namespace CompletionistAchievements.Achievements.Weapon.Placeable
{
    public class Info
    {
        // Verified w/ https://terraria.wiki.gg/wiki/Weapons
        public static readonly int[] PlaceableWeapons = [ItemID.SnowballLauncher, ItemID.RedRocket, ItemID.GreenRocket, ItemID.BlueRocket, ItemID.YellowRocket, ItemID.Cannon, ItemID.BunnyCannon, ItemID.LandMine];
    }

    public class WeaponPlaceableAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponPlaceableAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.PlaceableWeapons));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponSummonWhipAchievement>());
        }
    }
}
