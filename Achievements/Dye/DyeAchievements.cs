using System.Collections.Generic;
using Terraria.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using TerrariaAchievementLib.Achievements;
using TerrariaAchievementLib.Achievements.Conditions;
using CompletionistAchievements.Achievements.Critter;

namespace CompletionistAchievements.Achievements.Dye
{
    public class Info
    {
        // Verified w/ https://terraria.wiki.gg/wiki/Dyes
        public static readonly Dictionary<string, int[]> SpecialDyes = new()
        {
            { "STRANGE", [ItemID.AcidDye, ItemID.BlueAcidDye, ItemID.RedAcidDye, ItemID.ChlorophyteDye, ItemID.GelDye, ItemID.MushroomDye, ItemID.GrimDye, ItemID.HadesDye, ItemID.BurningHadesDye, ItemID.ShadowflameHadesDye, ItemID.LivingOceanDye, ItemID.LivingFlameDye, ItemID.LivingRainbowDye, ItemID.MartianArmorDye, ItemID.MidnightRainbowDye, ItemID.MirageDye, ItemID.NegativeDye, ItemID.PixieDye, ItemID.PhaseDye, ItemID.PurpleOozeDye, ItemID.ReflectiveDye, ItemID.ReflectiveCopperDye, ItemID.ReflectiveGoldDye, ItemID.ReflectiveObsidianDye, ItemID.ReflectiveMetalDye, ItemID.ReflectiveSilverDye, ItemID.ShadowDye, ItemID.ShiftingSandsDye, ItemID.DevDye, ItemID.TwilightDye, ItemID.WispDye, ItemID.InfernalWispDye, ItemID.UnicornWispDye] },
            { "CRAFT",   [ItemID.PinkGelDye, ItemID.ShiftingPearlSandsDye, ItemID.NebulaDye, ItemID.SolarDye, ItemID.StardustDye, ItemID.VortexDye, ItemID.VoidDye] },
            { "OTHER",   [ItemID.BloodbathDye, ItemID.FogboundDye, ItemID.HallowBossDye] }
        };

        // Verified w/ https://terraria.wiki.gg/wiki/Hair_Dyes
        public static readonly int[] HairDyes = [ItemID.LifeHairDye, ItemID.ManaHairDye, ItemID.DepthHairDye, ItemID.MoneyHairDye, ItemID.TimeHairDye, ItemID.BiomeHairDye, ItemID.PartyHairDye, ItemID.RainbowHairDye, ItemID.SpeedHairDye, ItemID.MartianHairDye, ItemID.TwilightHairDye];
    }

    public class DyeStrangeAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/DyeStrangeAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, NpcGiftCondition.GiftAll(Common.reqs, NPCID.DyeTrader, Info.SpecialDyes["STRANGE"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<CritterAchievement>());
        }
    }

    public class DyeCraftAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/DyeCraftAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemCraftCondition.CraftAll(Common.reqs, Info.SpecialDyes["CRAFT"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<DyeStrangeAchievement>());
        }
    }

    public class DyeOtherAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/DyeOtherAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.SpecialDyes["OTHER"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<DyeCraftAchievement>());
        }
    }

    public class DyeHairAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/DyeHairAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.HairDyes));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<DyeOtherAchievement>());
        }
    }
}
