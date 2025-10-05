using System.Collections.Generic;
using TerrariaAchievementLib.Achievements;
using TerrariaAchievementLib.Achievements.Conditions;

namespace CompletionistAchievements.Achievements
{
    /// <summary>
    /// Commonly used between achievements
    /// </summary>
    public class Common
    {
        /// <summary>
        /// Achievement condition requirements
        /// </summary>
        public static readonly ConditionReqs reqs = new(PlayerDiff.Classic, WorldDiff.Classic, SpecialSeed.None);

        /// <summary>
        /// Returns conditions to break a tile and grab the item<br/>
        /// Requires the player to actually find rare items from tiles
        /// </summary>
        /// <param name="reqs">Common condition requirements</param>
        /// <param name="itemId">Item ID to grab</param>
        /// <returns>Conditions to break a tile and grab the item</returns>
        public static List<CustomAchievementCondition> BreakAndGrabItem(ConditionReqs reqs, int itemId)
        {
            List<CustomAchievementCondition> conds = [];
            conds.Add(TileDropCondition.Drop(reqs, itemId));
            conds.Add(ItemGrabCondition.Grab(reqs, itemId));
            return conds;
        }
    }
}
