using System.Collections.Generic;
using Terraria.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using TerrariaAchievementLib.Achievements;
using TerrariaAchievementLib.Achievements.Conditions;
using CompletionistAchievements.Achievements.Tool;

namespace CompletionistAchievements.Achievements.Armor
{
    public class Info
    {
        // Verified w/ https://terraria.wiki.gg/wiki/Armor
        public static readonly Dictionary<string, int[]> ArmorPreHardmode = new()
        {
            { "MINING",         [ItemID.UltrabrightHelmet, ItemID.MiningHelmet, ItemID.MiningShirt, ItemID.MiningPants] },
            { "WOOD",           [ItemID.WoodHelmet, ItemID.WoodBreastplate, ItemID.WoodGreaves] },
            { "RICH_MAHOGANY",  [ItemID.RichMahoganyHelmet, ItemID.RichMahoganyBreastplate, ItemID.RichMahoganyGreaves] },
            { "BOREAL_WOOD",    [ItemID.BorealWoodHelmet, ItemID.BorealWoodBreastplate, ItemID.BorealWoodGreaves] },
            { "PALM_WOOD",      [ItemID.PalmWoodHelmet, ItemID.PalmWoodBreastplate, ItemID.PalmWoodGreaves] },
            { "EBONWOOD",       [ItemID.EbonwoodHelmet, ItemID.EbonwoodBreastplate, ItemID.EbonwoodGreaves] },
            { "SHADEWOOD",      [ItemID.ShadewoodHelmet, ItemID.ShadewoodBreastplate, ItemID.ShadewoodGreaves] },
            { "ASH_WOOD",       [ItemID.AshWoodHelmet, ItemID.AshWoodBreastplate, ItemID.AshWoodGreaves] },
            { "RAIN",           [ItemID.RainHat, ItemID.RainCoat] },
            { "SNOW",           [ItemID.EskimoHood, ItemID.EskimoCoat, ItemID.EskimoPants] },
            { "PINK_SNOW",      [ItemID.PinkEskimoHood, ItemID.PinkEskimoCoat, ItemID.PinkEskimoPants] },
            { "ANGLER",         [ItemID.AnglerHat, ItemID.AnglerVest, ItemID.AnglerPants] },
            { "CACTUS",         [ItemID.CactusHelmet, ItemID.CactusBreastplate, ItemID.CactusLeggings] },
            { "COPPER",         [ItemID.CopperHelmet, ItemID.CopperChainmail, ItemID.CopperGreaves] },
            { "TIN",            [ItemID.TinHelmet, ItemID.TinChainmail, ItemID.TinGreaves] },
            { "PUMPKIN",        [ItemID.PumpkinHelmet, ItemID.PumpkinBreastplate, ItemID.PumpkinLeggings] },
            { "NINJA",          [ItemID.NinjaHood, ItemID.NinjaShirt, ItemID.NinjaPants] },
            { "IRON",           [ItemID.IronHelmet, ItemID.AncientIronHelmet, ItemID.IronChainmail, ItemID.IronGreaves] },
            { "LEAD",           [ItemID.LeadHelmet, ItemID.LeadChainmail, ItemID.LeadGreaves] },
            { "SILVER",         [ItemID.SilverHelmet, ItemID.SilverChainmail, ItemID.SilverGreaves] },
            { "TUNGSTEN",       [ItemID.TungstenHelmet, ItemID.TungstenChainmail, ItemID.TungstenGreaves] },
            { "GOLD",           [ItemID.GoldHelmet, ItemID.AncientGoldHelmet, ItemID.GoldChainmail, ItemID.GoldGreaves] },
            { "PLATINUM",       [ItemID.PlatinumHelmet, ItemID.PlatinumChainmail, ItemID.PlatinumGreaves] },
            { "FOSSIL",         [ItemID.FossilHelm, ItemID.FossilShirt, ItemID.FossilPants] },
            { "BEE",            [ItemID.BeeHeadgear, ItemID.BeeBreastplate, ItemID.BeeGreaves] },
            { "OBSIDIAN",       [ItemID.ObsidianHelm, ItemID.ObsidianShirt, ItemID.ObsidianPants] },
            { "GLADIATOR",      [ItemID.GladiatorHelmet, ItemID.GladiatorBreastplate, ItemID.GladiatorLeggings] },
            { "METEOR",         [ItemID.MeteorHelmet, ItemID.MeteorSuit, ItemID.MeteorLeggings] },
            { "JUNGLE",         [ItemID.JungleHat, ItemID.JungleShirt, ItemID.JunglePants] },
            { "ANCIENT_COBALT", [ItemID.AncientCobaltHelmet, ItemID.AncientCobaltBreastplate, ItemID.AncientCobaltLeggings] },
            { "NECRO",          [ItemID.NecroHelmet, ItemID.AncientNecroHelmet, ItemID.NecroBreastplate, ItemID.NecroGreaves] },
            { "SHADOW",         [ItemID.ShadowHelmet, ItemID.ShadowScalemail, ItemID.ShadowGreaves] },
            { "ANCIENT_SHADOW", [ItemID.AncientShadowHelmet, ItemID.AncientShadowScalemail, ItemID.AncientShadowGreaves] },
            { "CRIMSON",        [ItemID.CrimsonHelmet, ItemID.CrimsonScalemail, ItemID.CrimsonGreaves] },
            { "MOLTEN",         [ItemID.MoltenHelmet, ItemID.MoltenBreastplate, ItemID.MoltenGreaves] }
        };

        // Verified w/ https://terraria.wiki.gg/wiki/Armor
        public static readonly Dictionary<string, int[]> ArmorHardmode = new()
        {
            { "PEARLWOOD",           [ItemID.PearlwoodHelmet, ItemID.PearlwoodBreastplate, ItemID.PearlwoodGreaves] },
            { "SPIDER",              [ItemID.SpiderMask, ItemID.SpiderBreastplate, ItemID.SpiderGreaves] },
            { "COBALT",              [ItemID.CobaltHat, ItemID.CobaltHelmet, ItemID.CobaltMask, ItemID.CobaltBreastplate, ItemID.CobaltLeggings] },
            { "PALLADIUM",           [ItemID.PalladiumHeadgear, ItemID.PalladiumMask, ItemID.PalladiumHelmet, ItemID.PalladiumBreastplate, ItemID.PalladiumLeggings] },
            { "MYTHRIL",             [ItemID.MythrilHood, ItemID.MythrilHelmet, ItemID.MythrilHat, ItemID.MythrilChainmail, ItemID.MythrilGreaves] },
            { "ORICHALCUM",          [ItemID.OrichalcumHeadgear, ItemID.OrichalcumMask, ItemID.OrichalcumHelmet, ItemID.OrichalcumBreastplate, ItemID.OrichalcumLeggings] },
            { "ADAMANTITE",          [ItemID.AdamantiteHeadgear, ItemID.AdamantiteHelmet, ItemID.AdamantiteMask, ItemID.AdamantiteBreastplate, ItemID.AdamantiteLeggings] },
            { "TITANIUM",            [ItemID.TitaniumHeadgear, ItemID.TitaniumMask, ItemID.TitaniumHelmet, ItemID.TitaniumBreastplate, ItemID.TitaniumLeggings] },
            { "CRYSTAL_ASSASSIN",    [ItemID.CrystalNinjaHelmet, ItemID.CrystalNinjaChestplate, ItemID.CrystalNinjaLeggings] },
            { "FROST",               [ItemID.FrostHelmet, ItemID.FrostBreastplate, ItemID.FrostLeggings] },
            { "FORBIDDEN",           [ItemID.AncientBattleArmorHat, ItemID.AncientBattleArmorShirt, ItemID.AncientBattleArmorPants] },
            { "SQUIRE",              [ItemID.SquireGreatHelm, ItemID.SquirePlating, ItemID.SquireGreaves] },
            { "MONK",                [ItemID.MonkBrows, ItemID.MonkShirt, ItemID.MonkPants] },
            { "HUNTRESS",            [ItemID.HuntressWig, ItemID.HuntressJerkin, ItemID.HuntressPants] },
            { "APPRENTICE",          [ItemID.ApprenticeHat, ItemID.ApprenticeRobe, ItemID.ApprenticeTrousers] },
            { "HALLOWED",            [ItemID.HallowedMask, ItemID.HallowedHelmet, ItemID.HallowedHeadgear, ItemID.HallowedHood, ItemID.HallowedPlateMail, ItemID.HallowedGreaves] },
            { "ANCIENT_HALLOWED",    [ItemID.AncientHallowedMask, ItemID.AncientHallowedHelmet, ItemID.AncientHallowedHeadgear, ItemID.AncientHallowedHood, ItemID.AncientHallowedPlateMail, ItemID.AncientHallowedGreaves] },
            { "CHLOROPHYTE",         [ItemID.ChlorophyteMask, ItemID.ChlorophyteHelmet, ItemID.ChlorophyteHeadgear, ItemID.ChlorophytePlateMail, ItemID.ChlorophyteGreaves] },
            { "TURTLE",              [ItemID.TurtleHelmet, ItemID.TurtleScaleMail, ItemID.TurtleLeggings] },
            { "TIKI",                [ItemID.TikiMask, ItemID.TikiShirt, ItemID.TikiPants] },
            { "BEETLE",              [ItemID.BeetleHelmet, ItemID.BeetleScaleMail, ItemID.BeetleShell, ItemID.BeetleLeggings] },
            { "SHROOMITE",           [ItemID.ShroomiteHeadgear, ItemID.ShroomiteHelmet, ItemID.ShroomiteMask, ItemID.ShroomiteBreastplate, ItemID.ShroomiteLeggings] },
            { "SPECTRE",             [ItemID.SpectreMask, ItemID.SpectreHood, ItemID.SpectreRobe, ItemID.SpectrePants] },
            { "SPOOKY",              [ItemID.SpookyHelmet, ItemID.SpookyBreastplate, ItemID.SpookyLeggings] },
            { "VALHALLA_KNIGHT",     [ItemID.SquireAltHead, ItemID.SquireAltShirt, ItemID.SquireAltPants] },
            { "SHINOBI_INFILTRATOR", [ItemID.MonkAltHead, ItemID.MonkAltShirt, ItemID.MonkAltPants] },
            { "RED_RIDING",          [ItemID.HuntressAltHead, ItemID.HuntressAltShirt, ItemID.HuntressAltPants] },
            { "DARK_ARTIST",         [ItemID.ApprenticeAltHead, ItemID.ApprenticeAltShirt, ItemID.ApprenticeAltPants] },
            { "SOLAR_FLARE",         [ItemID.SolarFlareHelmet, ItemID.SolarFlareBreastplate, ItemID.SolarFlareLeggings] },
            { "VORTEX",              [ItemID.VortexHelmet, ItemID.VortexBreastplate, ItemID.VortexLeggings] },
            { "NEBULA",              [ItemID.NebulaHelmet, ItemID.NebulaBreastplate, ItemID.NebulaLeggings] },
            { "STARDUST",            [ItemID.StardustHelmet, ItemID.StardustBreastplate, ItemID.StardustLeggings] }
        };

        // Verified w/ https://terraria.wiki.gg/wiki/Armor
        public static readonly Dictionary<string, int[]> ArmorPieces = new()
        {
            { "WIZARD", [ItemID.MagicHat, ItemID.WizardHat, ItemID.AmethystRobe, ItemID.TopazRobe, ItemID.SapphireRobe, ItemID.EmeraldRobe, ItemID.RubyRobe, ItemID.AmberRobe, ItemID.DiamondRobe, ItemID.GypsyRobe] },
            { "OTHER",  [ItemID.EmptyBucket, ItemID.Goggles, ItemID.GreenCap, ItemID.DivingHelmet, ItemID.NightVisionHelmet, ItemID.VikingHelmet, ItemID.FlinxFurCoat, ItemID.Gi, ItemID.DjinnsCurse] }
        };
    }

    public class ArmorMiningAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/ArmorMiningAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, NpcDropCondition.DropAll(Common.reqs, NPCID.None, [ItemID.MiningShirt, ItemID.MiningPants]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<ToolOtherAchievement>());
        }
    }

    public class ArmorRainAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/ArmorRainAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, NpcDropCondition.DropAll(Common.reqs, NPCID.None, Info.ArmorPreHardmode["RAIN"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<ArmorMiningAchievement>());
        }
    }

    public class ArmorSnowAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/ArmorSnowAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, NpcDropCondition.DropAll(Common.reqs, NPCID.None, Info.ArmorPreHardmode["SNOW"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<ArmorRainAchievement>());
        }
    }

    public class ArmorDivingHelmetAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/ArmorDivingHelmetAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.DivingHelmet));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<ArmorSnowAchievement>());
        }
    }

    public class ArmorDjinnsCurseAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/ArmorDjinnsCurseAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.DjinnsCurse));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<ArmorDivingHelmetAchievement>());
        }
    }

    public class ArmorGreenCapAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/ArmorGreenCapAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemGrabCondition.Grab(Common.reqs, ItemID.GreenCap));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<ArmorDjinnsCurseAchievement>());
        }
    }

    public class ArmorVikingHelmetAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/ArmorVikingHelmetAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.VikingHelmet));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<ArmorGreenCapAchievement>());
        }
    }

    public class ArmorPreHardmodeAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/ArmorPreHardmodeAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            foreach (var set in Info.ArmorPreHardmode)
                ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, set.Value));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<ArmorVikingHelmetAchievement>());
        }
    }

    public class ArmorHardmodeAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/ArmorHardmodeAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            foreach (var set in Info.ArmorHardmode)
                ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, set.Value));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<ArmorPreHardmodeAchievement>());
        }
    }

    public class ArmorWizardAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/ArmorWizardAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.ArmorPieces["WIZARD"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<ArmorHardmodeAchievement>());
        }
    }

    public class ArmorOtherAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/ArmorOtherAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.ArmorPieces["OTHER"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<ArmorWizardAchievement>());
        }
    }
}
