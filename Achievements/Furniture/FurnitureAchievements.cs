using System.Collections.Generic;
using Terraria.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using TerrariaAchievementLib.Achievements;
using TerrariaAchievementLib.Achievements.Conditions;
using CompletionistAchievements.Achievements.Fish;

namespace CompletionistAchievements.Achievements.Furniture
{
    public class Info
    {
        // Verified w/
        // https://terraria.wiki.gg/wiki/Furniture
        // https://terraria.wiki.gg/wiki/Buffs#Activated_furniture
        // https://terraria.wiki.gg/wiki/Crafting_stations#Themed_furniture
        public static readonly Dictionary<string, int[]> Furniture = new()
        {
            { "BUFF",      [ItemID.Sunflower, ItemID.Campfire, ItemID.Fireplace, ItemID.CrystalBall, ItemID.AmmoBox, ItemID.SharpeningStation, ItemID.BewitchingTable, ItemID.WarTable, ItemID.HeartLantern, ItemID.CatBast, ItemID.SliceOfCake, ItemID.StarinaBottle, ItemID.GardenGnome, ItemID.PeaceCandle] },
            { "DISPLAY",   [ItemID.Mannequin, ItemID.Womannquin, ItemID.WeaponRack, ItemID.ItemFrame, ItemID.HatRack] },
            { "THEMED",    [ItemID.BoneWelder, ItemID.GlassKiln, ItemID.HoneyDispenser, ItemID.IceMachine, ItemID.LivingLoom, ItemID.SkyMill, ItemID.Solidifier, ItemID.LesionStation, ItemID.FleshCloningVaat, ItemID.SteampunkBoiler, ItemID.LihzahrdFurnace] },
            { "TOMBSTONE", [ItemID.Tombstone, ItemID.GraveMarker, ItemID.CrossGraveMarker, ItemID.Headstone, ItemID.Gravestone, ItemID.Obelisk, ItemID.RichGravestone1, ItemID.RichGravestone2, ItemID.RichGravestone3, ItemID.RichGravestone4, ItemID.RichGravestone5] },
        };
    }
    
    public class FurnitureChippysCouchAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/FurnitureChippysCouchAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.ChippysCouch));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<FishRewardAchievement>());
        }
    }

    public class FurnitureDesertSpiritLampAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/FurnitureDesertSpiritLampAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.DjinnLamp));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<FurnitureChippysCouchAchievement>());
        }
    }

    public class FurnitureEnchantedSundialAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/FurnitureEnchantedSundialAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemOpenCondition.Open(Common.reqs, ItemID.None, ItemID.Sundial));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<FurnitureDesertSpiritLampAchievement>());
        }
    }

    public class FurnitureEnchantedMoondialAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/FurnitureEnchantedMoondialAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemGrabCondition.Grab(Common.reqs, ItemID.Moondial));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<FurnitureEnchantedSundialAchievement>());
        }
    }

    public class FurnitureHatRackAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/FurnitureHatRackAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemCraftCondition.Craft(Common.reqs, ItemID.HatRack));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<FurnitureEnchantedMoondialAchievement>());
        }
    }

    public class FurniturePigronataAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/FurniturePigronataAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcBuyCondition.Buy(Common.reqs, NPCID.PartyGirl, ItemID.Pigronata));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<FurnitureHatRackAchievement>());
        }
    }

    public class FurniturePortalGunStationAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/FurniturePortalGunStationAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcBuyCondition.Buy(Common.reqs, NPCID.Cyborg, ItemID.PortalGunStation));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<FurniturePigronataAchievement>());
        }
    }

    public class FurnitureTargetDummyAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/FurnitureTargetDummyAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemCraftCondition.Craft(Common.reqs, ItemID.TargetDummy));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<FurniturePortalGunStationAchievement>());
        }
    }

    public class FurnitureBuffAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/FurnitureBuffAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.Furniture["BUFF"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<FurnitureTargetDummyAchievement>());
        }
    }

    public class FurnitureDisplayAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/FurnitureDisplayAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.Furniture["DISPLAY"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<FurnitureBuffAchievement>());
        }
    }

    public class FurnitureThemedAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/FurnitureThemedAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.Furniture["THEMED"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<FurnitureDisplayAchievement>());
        }
    }

    public class FurnitureTombstoneAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/FurnitureTombstoneAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.Furniture["TOMBSTONE"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<FurnitureThemedAchievement>());
        }
    }
}
