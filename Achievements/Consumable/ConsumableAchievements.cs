using System.Collections.Generic;
using Terraria.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using TerrariaAchievementLib.Achievements;
using TerrariaAchievementLib.Achievements.Conditions;
using CompletionistAchievements.Achievements.Buff;

namespace CompletionistAchievements.Achievements.Consumable
{
    public class Info
    {
        // Verified w/:
        // https://terraria.wiki.gg/wiki/Consumables
        // https://terraria.wiki.gg/wiki/Food
        // https://terraria.wiki.gg/wiki/Potions (added Ale/Sake to buff potions)
        public static readonly Dictionary<string, int[]> Consumables = new()
        {
            { "EXPLOSIVE",       [ItemID.Bomb, ItemID.BombFish, ItemID.BouncyBomb, ItemID.BouncyDynamite, ItemID.DirtBomb, ItemID.DryBomb, ItemID.Dynamite, ItemID.HoneyBomb, ItemID.LavaBomb, ItemID.ScarabBomb, ItemID.StickyBomb, ItemID.DirtStickyBomb, ItemID.StickyDynamite, ItemID.WetBomb] },
            { "FOOD",            [ItemID.Marshmallow, ItemID.JojaCola, ItemID.Apple, ItemID.Apricot, ItemID.Banana, ItemID.BlackCurrant, ItemID.BloodOrange, ItemID.Cherry, ItemID.Coconut, ItemID.Elderberry, ItemID.Grapefruit, ItemID.Lemon, ItemID.Mango, ItemID.Peach, ItemID.Pineapple, ItemID.Plum, ItemID.Pomegranate, ItemID.Rambutan, ItemID.SpicyPepper, ItemID.Teacup, ItemID.Dragonfruit, ItemID.Starfruit, ItemID.ChristmasPudding, ItemID.CookedFish, ItemID.GingerbreadCookie, ItemID.SugarCookie, ItemID.FroggleBunwich, ItemID.AppleJuice, ItemID.BunnyStew, ItemID.CookedMarshmallow, ItemID.GrilledSquirrel, ItemID.Lemonade, ItemID.PeachSangria, ItemID.RoastedBird, ItemID.SauteedFrogLegs, ItemID.ShuckedOyster, ItemID.BowlofSoup, ItemID.MonsterLasagna, ItemID.PadThai, ItemID.PumpkinPie, ItemID.Sashimi, ItemID.BananaSplit, ItemID.CoffeeCup, ItemID.CookedShrimp, ItemID.Escargot, ItemID.Fries, ItemID.BananaDaiquiri, ItemID.FruitJuice, ItemID.LobsterTail, ItemID.Pho, ItemID.RoastedDuck, ItemID.Burger, ItemID.Pizza, ItemID.Spaghetti, ItemID.BloodyMoscato, ItemID.MilkCarton, ItemID.PinaColada, ItemID.SmoothieofDarkness, ItemID.TropicalSmoothie, ItemID.ChickenNugget, ItemID.FriedEgg, ItemID.GrubSoup, ItemID.IceCream, ItemID.SeafoodDinner, ItemID.CreamSoda, ItemID.Grapes, ItemID.Hotdog, ItemID.Nachos, ItemID.FruitSalad, ItemID.PotatoChips, ItemID.ShrimpPoBoy, ItemID.ChocolateChipCookie, ItemID.PrismaticPunch, ItemID.ApplePie, ItemID.GrapeJuice, ItemID.Milkshake, ItemID.Steak, ItemID.BBQRibs, ItemID.Bacon, ItemID.GoldenDelight] },
            { "LICENSE",         [ItemID.LicenseCat, ItemID.LicenseDog, ItemID.LicenseBunny] },
            { "POTION_BUFF",     [ItemID.AmmoReservationPotion, ItemID.ArcheryPotion, ItemID.BattlePotion, ItemID.BiomeSightPotion, ItemID.BuilderPotion, ItemID.CalmingPotion, ItemID.CratePotion, ItemID.TrapsightPotion, ItemID.EndurancePotion, ItemID.FeatherfallPotion, ItemID.FishingPotion, ItemID.FlipperPotion, ItemID.GillsPotion, ItemID.GravitationPotion, ItemID.LuckPotionGreater, ItemID.HeartreachPotion, ItemID.HunterPotion, ItemID.InfernoPotion, ItemID.InvisibilityPotion, ItemID.IronskinPotion, ItemID.LuckPotionLesser, ItemID.LifeforcePotion, ItemID.LovePotion, ItemID.LuckPotion, ItemID.MagicPowerPotion, ItemID.ManaRegenerationPotion, ItemID.MiningPotion, ItemID.NightOwlPotion, ItemID.ObsidianSkinPotion, ItemID.RagePotion, ItemID.RegenerationPotion, ItemID.ShinePotion, ItemID.SonarPotion, ItemID.SpelunkerPotion, ItemID.StinkPotion, ItemID.SummoningPotion, ItemID.SwiftnessPotion, ItemID.ThornsPotion, ItemID.TitanPotion, ItemID.WarmthPotion, ItemID.WaterWalkingPotion, ItemID.WrathPotion, ItemID.Ale, ItemID.Sake] },
            { "POTION_FLASK",    [ItemID.FlaskofCursedFlames, ItemID.FlaskofFire, ItemID.FlaskofGold, ItemID.FlaskofIchor, ItemID.FlaskofNanites, ItemID.FlaskofParty, ItemID.FlaskofPoison, ItemID.FlaskofVenom] },
            { "POTION_RECOVERY", [ItemID.Mushroom, ItemID.BottledHoney, ItemID.GreaterHealingPotion, ItemID.HealingPotion, ItemID.LesserHealingPotion, ItemID.ManaPotion, ItemID.RestorationPotion, ItemID.SuperHealingPotion, ItemID.SuperManaPotion, ItemID.BottledWater, ItemID.GreaterManaPotion, ItemID.LesserManaPotion, ItemID.Eggnog, ItemID.Honeyfin, ItemID.StrangeBrew] },
            { "POTION_OTHER",    [ItemID.GenderChangePotion, ItemID.PotionOfReturn, ItemID.RecallPotion, ItemID.TeleportationPotion] },
            { "PERMANENT",       [ItemID.LifeCrystal, ItemID.LifeFruit, ItemID.ManaCrystal, ItemID.CombatBook, ItemID.ArtisanLoaf, ItemID.TorchGodsFavor, ItemID.AegisCrystal, ItemID.AegisFruit, ItemID.ArcaneCrystal, ItemID.Ambrosia, ItemID.GummyWorm, ItemID.GalaxyPearl, ItemID.CombatBookVolumeTwo, ItemID.PeddlersSatchel] },
            { "TOOL",            [ItemID.PurificationPowder, ItemID.VilePowder, ItemID.ViciousPowder, ItemID.HolyWater, ItemID.UnholyWater, ItemID.BloodWater, ItemID.Glowstick, ItemID.StickyGlowstick, ItemID.BouncyGlowstick, ItemID.SpelunkerGlowstick, ItemID.FairyGlowstick, ItemID.ChumBucket, ItemID.Fertilizer] },
            { "WEAPON",          [ItemID.PaperAirplaneA, ItemID.PaperAirplaneB, ItemID.Snowball, ItemID.Shuriken, ItemID.RottenEgg, ItemID.ThrowingKnife, ItemID.PoisonedKnife, ItemID.Beenade, ItemID.BoneDagger, ItemID.StarAnise, ItemID.SpikyBall, ItemID.Javelin, ItemID.FrostDaggerfish, ItemID.Bone, ItemID.MolotovCocktail, ItemID.BoneJavelin, ItemID.PartyGirlGrenade, ItemID.Grenade, ItemID.StickyGrenade, ItemID.BouncyGrenade] },
            { "OTHER",           [ItemID.StinkPotion, ItemID.LovePotion, ItemID.SmokeBomb, ItemID.ConfettiGun, ItemID.BeachBall, ItemID.Football, ItemID.Geode, ItemID.TreeGlobe, ItemID.MoonGlobe, ItemID.WorldGlobe, ItemID.ReleaseLantern, ItemID.ReleaseDoves, ItemID.GelBalloon] },
        };
    }
    
    public class ConsumableExplosiveAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/ConsumableExplosiveAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemUseCondition.UseAll(Common.reqs, Info.Consumables["EXPLOSIVE"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<BuffSummonAchievement>());
        }
    }

    public class ConsumableFoodAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/ConsumableFoodAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemUseCondition.UseAll(Common.reqs, Info.Consumables["FOOD"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<ConsumableExplosiveAchievement>());
        }
    }

    public class ConsumableLicenseAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/ConsumableLicenseAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemUseCondition.UseAll(Common.reqs, Info.Consumables["LICENSE"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<ConsumableFoodAchievement>());
        }
    }

    public class ConsumablePotionBuffAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/ConsumablePotionBuffAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemUseCondition.UseAll(Common.reqs, Info.Consumables["POTION_BUFF"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<ConsumableLicenseAchievement>());
        }
    }

    public class ConsumablePotionFlaskAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/ConsumablePotionFlaskAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemUseCondition.UseAll(Common.reqs, Info.Consumables["POTION_FLASK"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<ConsumablePotionBuffAchievement>());
        }
    }

    public class ConsumablePotionRecoveryAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/ConsumablePotionRecoveryAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemUseCondition.UseAll(Common.reqs, Info.Consumables["POTION_RECOVERY"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<ConsumablePotionFlaskAchievement>());
        }
    }

    public class ConsumablePotionOtherAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/ConsumablePotionOtherAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemUseCondition.UseAll(Common.reqs, Info.Consumables["POTION_OTHER"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<ConsumablePotionRecoveryAchievement>());
        }
    }

    public class ConsumablePermanentAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/ConsumablePermanentAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemUseCondition.UseAll(Common.reqs, Info.Consumables["PERMANENT"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<ConsumablePotionOtherAchievement>());
        }
    }

    public class ConsumableToolAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/ConsumableToolAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemUseCondition.UseAll(Common.reqs, Info.Consumables["TOOL"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<ConsumablePermanentAchievement>());
        }
    }

    public class ConsumableWeaponAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/ConsumableWeaponAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemUseCondition.UseAll(Common.reqs, Info.Consumables["WEAPON"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<ConsumableToolAchievement>());
        }
    }

    public class ConsumableOtherAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/ConsumableOtherAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemUseCondition.UseAll(Common.reqs, Info.Consumables["OTHER"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<ConsumableWeaponAchievement>());
        }
    }
}
