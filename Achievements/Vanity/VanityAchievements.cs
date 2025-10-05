using System.Collections.Generic;
using Terraria.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using TerrariaAchievementLib.Achievements;
using TerrariaAchievementLib.Achievements.Conditions;
using CompletionistAchievements.Achievements.Minecart;

namespace CompletionistAchievements.Achievements.Vanity
{
    public class Info
    {
        // Verified w/ https://terraria.wiki.gg/wiki/Vanity_items
        public static readonly Dictionary<string, int[]> VanitySets = new()
        {
            { "ANCIENT",           [ItemID.AncientArmorHat, ItemID.AncientArmorShirt, ItemID.AncientArmorPants] },
            { "ARCHAEOLOGIST",     [ItemID.ArchaeologistsHat, ItemID.ArchaeologistsJacket, ItemID.ArchaeologistsPants] },
            { "BEE",               [ItemID.BeeHat, ItemID.BeeShirt, ItemID.BeePants] },
            { "BLACK_GRADUATION",  [ItemID.GraduationCapBlack, ItemID.GraduationGownBlack] },
            { "BLUE_GRADUATION",   [ItemID.GraduationCapBlue, ItemID.GraduationGownBlue] },
            { "BUCCANEER",         [ItemID.BuccaneerBandana, ItemID.BuccaneerShirt, ItemID.BuccaneerPants] },
            { "BUNNY",             [ItemID.BunnyEars, ItemID.BunnyTail] },
            { "BUTCHER",           [ItemID.ButcherMask, ItemID.ButcherApron, ItemID.ButcherPants] },
            { "CAPRICORN",         [ItemID.CapricornMask, ItemID.CapricornChestplate, ItemID.CapricornLegs, ItemID.CapricornTail] },
            { "CHEF",              [ItemID.ChefHat, ItemID.ChefShirt, ItemID.ChefPants] },
            { "CLOWN",             [ItemID.ClownHat, ItemID.ClownShirt, ItemID.ClownPants] },
            { "COUNTRY_CLUB",      [ItemID.GolfHat, ItemID.GolfShirt, ItemID.GolfPants] },
            { "COWBOY",            [ItemID.CowboyHat, ItemID.CowboyJacket, ItemID.CowboyPants] },
            { "DOG",               [ItemID.DogEars, ItemID.DogTail] },
            { "DR_MAN_FLY",        [ItemID.DrManFlyMask, ItemID.DrManFlyLabCoat] },
            { "ELF",               [ItemID.ElfHat, ItemID.ElfShirt, ItemID.ElfPants] },
            { "FALLEN_TUXEDO",     [ItemID.FallenTuxedoShirt, ItemID.FallenTuxedoPants] },
            { "FAMILIAR",          [ItemID.FamiliarWig, ItemID.FamiliarShirt, ItemID.FamiliarPants] },
            { "FIRESTARTER",       [ItemID.WillowShirt, ItemID.WillowSkirt] },
            { "FISH_COSTUME",      [ItemID.FishCostumeMask, ItemID.FishCostumeShirt, ItemID.FishCostumeFinskirt] },
            { "FLORET_PROTECTOR",  [ItemID.FloretProtectorHelmet, ItemID.FloretProtectorChestplate, ItemID.FloretProtectorLegs] },
            { "FOX",               [ItemID.FoxEars, ItemID.FoxTail] },
            { "FUNERAL",           [ItemID.FuneralHat, ItemID.FuneralCoat, ItemID.FuneralPants] },
            { "GENTLEMAN",         [ItemID.WilsonBeardShort, ItemID.WilsonBeardLong, ItemID.WilsonBeardMagnificent, ItemID.WilsonShirt, ItemID.WilsonPants] },
            { "GRAVEDIGGER",       [ItemID.UndertakerHat, ItemID.UndertakerCoat] },
            { "HERO",              [ItemID.HerosHat, ItemID.HerosShirt, ItemID.HerosPants] },
            { "LAMIA",             [ItemID.LamiaHat, ItemID.LamiaShirt, ItemID.LamiaPants] },
            { "LIZARD",            [ItemID.LizardEars, ItemID.LizardTail] },
            { "LUNAR_CULTIST",     [ItemID.BlueLunaticHood, ItemID.BlueLunaticRobe] },
            { "MAID",              [ItemID.MaidHead, ItemID.MaidShirt, ItemID.MaidPants] },
            { "MAROON_GRADUATION", [ItemID.GraduationCapMaroon, ItemID.GraduationGownMaroon] },
            { "MARTIAN_COSTUME",   [ItemID.MartianCostumeMask, ItemID.MartianCostumeShirt, ItemID.MartianCostumePants] },
            { "MARTIAN_UNIFORM",   [ItemID.MartianUniformHelmet, ItemID.MartianUniformTorso, ItemID.MartianUniformPants] },
            { "MASTER_GAMER",      [ItemID.GameMasterShirt, ItemID.GameMasterPants] },
            { "MERMAID",           [ItemID.SeashellHairpin, ItemID.MermaidAdornment, ItemID.MermaidTail] },
            { "MUMMY",             [ItemID.MummyMask, ItemID.MummyShirt, ItemID.MummyPants] },
            { "MUSHROOM",          [ItemID.MushroomHat, ItemID.MushroomVest, ItemID.MushroomPants] },
            { "PEDGUIN",           [ItemID.PedguinHat, ItemID.PedguinShirt, ItemID.PedguinPants] },
            { "PHARAOH",           [ItemID.PharaohsMask, ItemID.PharaohsRobe] },
            { "PINK_MAID",         [ItemID.MaidHead2, ItemID.MaidShirt2, ItemID.MaidPants2] },
            { "PIRATE",            [ItemID.PirateHat, ItemID.PirateShirt, ItemID.PiratePants] },
            { "PLAGUEBRINGER",     [ItemID.PlaguebringerHelmet, ItemID.PlaguebringerChestplate, ItemID.PlaguebringerGreaves] },
            { "PLUMBER",           [ItemID.PlumbersHat, ItemID.PlumbersShirt, ItemID.PlumbersPants] },
            { "PRETTY_PINK",       [ItemID.PrettyPinkRibbon, ItemID.PrettyPinkDressSkirt, ItemID.PrettyPinkDressPants] },
            { "PRINCE",            [ItemID.PrinceUniform, ItemID.PrincePants, ItemID.PrinceCape] },
            { "PRINCESS",          [ItemID.Tiara, ItemID.PrincessDress] },
            { "RAYNEBRO",          [ItemID.LincolnsHood, ItemID.LincolnsHoodie, ItemID.LincolnsPants] },
            { "ROYAL",             [ItemID.RoyalTiara, ItemID.RoyalDressTop, ItemID.RoyalDressBottom] },
            { "RUNE",              [ItemID.RuneHat, ItemID.RuneRobe] },
            { "SAILOR",            [ItemID.SailorHat, ItemID.SailorShirt, ItemID.SailorPants] },
            { "SCARECROW",         [ItemID.ScarecrowHat, ItemID.ScarecrowShirt, ItemID.ScarecrowPants] },
            { "SILLY_SUNFLOWER",   [ItemID.FlowerBoyHat, ItemID.FlowerBoyShirt, ItemID.FlowerBoyPants] },
            { "SOLAR_CULTIST",     [ItemID.WhiteLunaticHood, ItemID.WhiteLunaticRobe] },
            { "STAR_PRINCESS",     [ItemID.StarPrincessCrown, ItemID.StarPrincessDress] },
            { "STEAMPUNK",         [ItemID.SteampunkHat, ItemID.SteampunkShirt, ItemID.SteampunkPants] },
            { "SUPERHERO",         [ItemID.SuperHeroMask, ItemID.SuperHeroCostume, ItemID.SuperHeroTights] },
            { "TAX_COLLECTOR",     [ItemID.TaxCollectorHat, ItemID.TaxCollectorSuit, ItemID.TaxCollectorPants] },
            { "THE_DOCTOR",        [ItemID.TheDoctorsShirt, ItemID.TheDoctorsPants] },
            { "TIMELESS_TRAVELER", [ItemID.TimelessTravelerHood, ItemID.TimelessTravelerRobe, ItemID.TimelessTravelerBottom] },
            { "TUXEDO",            [ItemID.TopHat, ItemID.TuxedoShirt, ItemID.TuxedoPants] },
            { "TV_HEAD",           [ItemID.TVHeadMask, ItemID.TVHeadSuit, ItemID.TVHeadPants] },
            { "VICTORIAN_GOTH",    [ItemID.VictorianGothHat, ItemID.VictorianGothDress] },
            { "WANDERING",         [ItemID.RoninHat, ItemID.RoninShirt, ItemID.RoninPants] },
            { "WEDDING",           [ItemID.TheBrideHat, ItemID.TheBrideDress] },
            { "WHITE_TUXEDO",      [ItemID.WhiteTuxedoShirt, ItemID.WhiteTuxedoPants] }
        };

        // Verified w/ https://terraria.wiki.gg/wiki/Vanity_items
        public static readonly Dictionary<string, int[]> VanityHalloween = new()
        {
            { "BRIDE_OF_FRAKENSTEIN", [ItemID.BrideofFrankensteinMask, ItemID.BrideofFrankensteinDress] },
            { "CAT",                  [ItemID.CatMask, ItemID.CatShirt, ItemID.CatPants] },
            { "CLOTHIER",             [ItemID.RedHat, ItemID.ClothierJacket, ItemID.ClothierPants] },
            { "CREEPER",              [ItemID.CreeperMask, ItemID.CreeperShirt, ItemID.CreeperPants] },
            { "CYBORG",               [ItemID.CyborgHelmet, ItemID.CyborgShirt, ItemID.CyborgPants] },
            { "DRYAD",                [ItemID.DryadCoverings, ItemID.DryadLoincloth] },
            { "DYE_TRADER",           [ItemID.DyeTraderTurban, ItemID.DyeTraderRobe] },
            { "FOX",                  [ItemID.FoxMask, ItemID.FoxShirt, ItemID.FoxPants] },
            { "GHOST",                [ItemID.GhostMask, ItemID.GhostShirt] },
            { "KARATE_TORTOISE",      [ItemID.KarateTortoiseMask, ItemID.KarateTortoiseShirt, ItemID.KarateTortoisePants] },
            { "LEPRECHAUN",           [ItemID.LeprechaunHat, ItemID.LeprechaunShirt, ItemID.LeprechaunPants] },
            { "NURSE",                [ItemID.NurseHat, ItemID.NurseShirt, ItemID.NursePants] },
            { "PIXIE",                [ItemID.PixieShirt, ItemID.PixiePants] },
            { "PRINCESS",             [ItemID.PrincessHat, ItemID.PrincessDressNew] },
            { "PUMPKIN",              [ItemID.PumpkinMask, ItemID.PumpkinShirt, ItemID.PumpkinPants] },
            { "REAPER",               [ItemID.ReaperHood, ItemID.ReaperRobe] },
            { "ROBOT",                [ItemID.RobotMask, ItemID.RobotShirt, ItemID.RobotPants] },
            { "SPACE_CREATURE",       [ItemID.SpaceCreatureMask, ItemID.SpaceCreatureShirt, ItemID.SpaceCreaturePants] },
            { "TREAURE_HUNTER",       [ItemID.TreasureHunterShirt, ItemID.TreasureHunterPants] },
            { "UNICORN",              [ItemID.UnicornMask, ItemID.UnicornShirt, ItemID.UnicornPants] },
            { "VAMPIRE",              [ItemID.VampireMask, ItemID.VampireShirt, ItemID.VampirePants] },
            { "WITCH",                [ItemID.WitchHat, ItemID.WitchDress, ItemID.WitchBoots] },
            { "WOLF",                 [ItemID.WolfMask, ItemID.WolfShirt, ItemID.WolfPants] }
        };

        // Verified w/ https://terraria.wiki.gg/wiki/Vanity_items
        public static readonly Dictionary<string, int[]> VanityChristmas = new()
        {
            { "MRS_CLAUS", [ItemID.MrsClauseHat, ItemID.MrsClauseShirt, ItemID.MrsClauseHeels] },
            { "PARKA",     [ItemID.ParkaHood, ItemID.ParkaCoat, ItemID.ParkaPants] },
            { "SANTA",     [ItemID.SantaHat, ItemID.SantaShirt, ItemID.SantaPants] },
            { "TREE",      [ItemID.TreeMask, ItemID.TreeShirt, ItemID.TreeTrunks] }
        };

        // Verified w/ https://terraria.wiki.gg/wiki/Vanity_items
        public static readonly Dictionary<string, int[]> VanityPieces = new()
        {
            { "MASK",  [ItemID.KingSlimeMask, ItemID.EyeMask, ItemID.EaterMask, ItemID.BrainMask, ItemID.BeeMask, ItemID.DeerclopsMask, ItemID.SkeletronMask, ItemID.FleshMask, ItemID.QueenSlimeMask, ItemID.TwinMask, ItemID.DestroyerMask, ItemID.SkeletronPrimeMask, ItemID.PlanteraMask, ItemID.GolemMask, ItemID.FairyQueenMask, ItemID.DukeFishronMask, ItemID.BossMaskCultist, ItemID.BossMaskMoonlord, ItemID.BossMaskDarkMage, ItemID.BossMaskOgre, ItemID.BossMaskBetsy] },
            { "OTHER", [ItemID.BadgersHat, ItemID.BallaHat, ItemID.Beanie, ItemID.BunnyHood, ItemID.CatEars, ItemID.DeadMansSweater, ItemID.DemonHorns, ItemID.DevilHorns, ItemID.DizzyHat, ItemID.EngineeringHelmet, ItemID.EyePatch, ItemID.Eyebrella, ItemID.Fedora, ItemID.Fez, ItemID.FishBowl, ItemID.GangstaHat, ItemID.GarlandHat, ItemID.GiantBow, ItemID.GoblorcEar, ItemID.GoldCrown, ItemID.GoldGoldfishBowl, ItemID.GuyFawkesMask, ItemID.HeartHairpin, ItemID.HiTekSunglasses, ItemID.JackOLanternMask, ItemID.JimsCap, ItemID.Kimono, ItemID.MimeMask, ItemID.MoonMask, ItemID.MushroomCap, ItemID.PandaEars, ItemID.PartyHat, ItemID.PeddlersHat, ItemID.PlatinumCrown, ItemID.RabbitOrder, ItemID.ReindeerAntlers, ItemID.Robe, ItemID.RobotHat, ItemID.RockGolemHead, ItemID.SWATHelmet, ItemID.Skull, ItemID.SnowHat, ItemID.StarHairpin, ItemID.SteampunkGoggles, ItemID.SummerHat, ItemID.SunMask, ItemID.Sunglasses, ItemID.TamOShanter, ItemID.UglySweater, ItemID.UmbrellaHat, ItemID.VulkelfEar, ItemID.WizardsHat] }
        };
    }
    
    public class VanityHeroAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/VanityHeroAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemCraftCondition.CraftAll(Common.reqs, Info.VanitySets["HERO"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<MinecartAchievement>());
        }
    }

    public class VanityLamiaAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/VanityLamiaAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, NpcDropCondition.DropAll(Common.reqs, NPCID.None, Info.VanitySets["LAMIA"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<VanityHeroAchievement>());
        }
    }

    public class VanityMummyAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/VanityMummyAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, NpcDropCondition.DropAll(Common.reqs, NPCID.None, Info.VanitySets["MUMMY"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<VanityLamiaAchievement>());
        }
    }

    public class VanityPedguinAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/VanityPedguinAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, NpcDropCondition.DropAll(Common.reqs, NPCID.None, Info.VanitySets["PEDGUIN"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<VanityMummyAchievement>());
        }
    }

    public class VanityPlumberAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/VanityPlumberAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.PlumbersHat));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<VanityPedguinAchievement>());
        }
    }

    public class VanityCreeperAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/VanityCreeperAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemOpenCondition.OpenAll(Common.reqs, ItemID.GoodieBag, Info.VanityHalloween["CREEPER"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<VanityPlumberAchievement>());
        }
    }

    public class VanityAngelHaloAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/VanityAngelHaloAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcBuyCondition.Buy(Common.reqs, NPCID.TravellingMerchant, ItemID.AngelHalo));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<VanityCreeperAchievement>());
        }
    }

    public class VanityBadgersHatAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/VanityBadgersHatAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.BadgersHat));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<VanityAngelHaloAchievement>());
        }
    }

    public class VanityDeadMansSweaterAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/VanityDeadMansSweaterAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemGrabCondition.Grab(Common.reqs, ItemID.DeadMansSweater));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<VanityBadgersHatAchievement>());
        }
    }

    public class VanityGingerBeardAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/VanityGingerBeardAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemOpenCondition.Open(Common.reqs, ItemID.None, ItemID.GingerBeard));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<VanityDeadMansSweaterAchievement>());
        }
    }

    public class VanityJimsHatAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/VanityJimsHatAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemGrabCondition.Grab(Common.reqs, ItemID.JimsCap));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<VanityGingerBeardAchievement>());
        }
    }

    public class VanityRobotHatAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/VanityRobotHatAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.RobotHat));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<VanityJimsHatAchievement>());
        }
    }

    public class VanitySkullAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/VanitySkullAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.Skull));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<VanityRobotHatAchievement>());
        }
    }

    public class VanityUmbrellaHatAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/VanityUmbrellaHatAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.UmbrellaSlime, ItemID.UmbrellaHat));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<VanitySkullAchievement>());
        }
    }

    public class VanitySetsAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/VanitySetsAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            foreach (var set in Info.VanitySets)
                ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, set.Value));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<VanityUmbrellaHatAchievement>());
        }
    }

    public class VanityHalloweenAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/VanityHalloweenAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            foreach (var set in Info.VanityHalloween)
                ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, set.Value));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<VanitySetsAchievement>());
        }
    }

    public class VanityChristmasAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/VanityChristmasAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            foreach (var set in Info.VanityChristmas)
                ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, set.Value));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<VanityHalloweenAchievement>());
        }
    }

    public class VanityMaskAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/VanityMaskAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.VanityPieces["MASK"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<VanityChristmasAchievement>());
        }
    }

    public class VanityOtherAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/VanityOtherAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.VanityPieces["OTHER"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<VanityMaskAchievement>());
        }
    }
}
