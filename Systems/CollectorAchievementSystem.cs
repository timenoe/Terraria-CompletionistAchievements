using System.Collections.Generic;
using TerrariaAchievementLib.Systems;
using TerrariaAchievementLib.Achievements;
using Terraria.ID;

namespace CollectorAchievements.Systems
{
    public class CollectorAchievementSystem : AchievementSystem
    {
        private static readonly Dictionary<string, int[]> ArmorSets = new()
        {
            // Pre-Hardmode
            { "Mining", [ItemID.MiningHelmet, ItemID.MiningShirt, ItemID.MiningPants]},
            { "Wood", [ItemID.WoodHelmet, ItemID.WoodBreastplate, ItemID.WoodGreaves]},
            { "Rich Mahogany", [ItemID.RichMahoganyHelmet, ItemID.RichMahoganyBreastplate, ItemID.RichMahoganyGreaves]},
            { "Boreal Wood", [ItemID.BorealWoodHelmet, ItemID.BorealWoodBreastplate, ItemID.BorealWoodGreaves]},
            { "Palm Wood", [ItemID.PalmWoodHelmet, ItemID.PalmWoodBreastplate, ItemID.PalmWoodGreaves]},
            { "Ebonwood", [ItemID.EbonwoodHelmet, ItemID.EbonwoodBreastplate, ItemID.EbonwoodGreaves]},
            { "Shadewood", [ItemID.ShadewoodHelmet, ItemID.ShadewoodBreastplate, ItemID.ShadewoodGreaves]},
            { "Ash Wood", [ItemID.AshWoodHelmet, ItemID.AshWoodBreastplate, ItemID.AshWoodGreaves]},
            { "Rain", [ItemID.RainHat, ItemID.RainCoat]},
            { "Snow", [ItemID.EskimoHood, ItemID.EskimoCoat, ItemID.EskimoPants]},
            { "Pink Snow", [ItemID.PinkEskimoHood, ItemID.PinkEskimoCoat, ItemID.PinkEskimoPants]},
            { "Angler", [ItemID.AnglerHat, ItemID.AnglerVest, ItemID.AnglerPants]},
            { "Cactus", [ItemID.CactusHelmet, ItemID.CactusBreastplate, ItemID.CactusLeggings]},
            { "Copper", [ItemID.CopperHelmet, ItemID.CopperChainmail, ItemID.CopperGreaves]},
            { "Tin", [ItemID.TinHelmet, ItemID.TinChainmail, ItemID.TinGreaves]},
            { "Pumpkin", [ItemID.PumpkinHelmet, ItemID.PumpkinBreastplate, ItemID.PumpkinLeggings]},
            { "Ninja", [ItemID.NinjaHood, ItemID.NinjaShirt, ItemID.NinjaPants]},
            { "Iron", [ItemID.IronHelmet, ItemID.IronChainmail, ItemID.IronGreaves]},
            { "Lead", [ItemID.LeadHelmet, ItemID.LeadChainmail, ItemID.LeadGreaves]},
            { "Silver", [ItemID.SilverHelmet, ItemID.SilverChainmail, ItemID.SilverGreaves]},
            { "Tungsten", [ItemID.TungstenHelmet, ItemID.TungstenChainmail, ItemID.TungstenGreaves]},
            { "Gold", [ItemID.GoldHelmet, ItemID.GoldChainmail, ItemID.GoldGreaves]},
            { "Platinum", [ItemID.PlatinumHelmet, ItemID.PlatinumChainmail, ItemID.PlatinumGreaves]},
            { "Fossil", [ItemID.FossilHelm, ItemID.FossilShirt, ItemID.FossilPants]},
            { "Bee", [ItemID.BeeHeadgear, ItemID.BeeBreastplate, ItemID.BeePants]},
            { "Obsidian", [ItemID.ObsidianHelm, ItemID.ObsidianShirt, ItemID.ObsidianPants]},
            { "Gladiator", [ItemID.GladiatorHelmet, ItemID.GladiatorBreastplate, ItemID.GladiatorLeggings]},
            { "Meteor", [ItemID.MeteorHelmet, ItemID.MeteorSuit, ItemID.MeteorLeggings]},
            { "Jungle", [ItemID.JungleHat, ItemID.JungleShirt, ItemID.JunglePants]},
            { "Ancient Cobalt", [ItemID.AncientCobaltHelmet, ItemID.AncientCobaltBreastplate, ItemID.AncientCobaltLeggings]},
            { "Necro", [ItemID.NecroHelmet, ItemID.NecroBreastplate, ItemID.NecroGreaves]},
            { "Shadow", [ItemID.ShadowHelmet, ItemID.ShadowScalemail, ItemID.ShadowGreaves]},
            { "Ancient Shadow", [ItemID.AncientShadowHelmet, ItemID.AncientShadowScalemail, ItemID.AncientShadowGreaves]},
            { "Crimson", [ItemID.CrimsonHelmet, ItemID.CrimsonScalemail, ItemID.CrimsonGreaves]},
            { "Molten", [ItemID.MoltenHelmet, ItemID.MoltenBreastplate, ItemID.MoltenGreaves]},

            // Hardmode
            { "Pearlwood", [ItemID.PearlwoodHelmet, ItemID.PearlwoodBreastplate, ItemID.PearlwoodGreaves]},
            { "Spider", [ItemID.SpiderMask, ItemID.SpiderBreastplate, ItemID.SpiderGreaves]},
            { "Cobalt", [ItemID.CobaltHelmet, ItemID.CobaltBreastplate, ItemID.CobaltLeggings]},
            { "Cobalt", [ItemID.CobaltHat, ItemID.CobaltHelmet, ItemID.CobaltMask, ItemID.CobaltBreastplate, ItemID.CobaltLeggings]},
            { "Palladium", [ItemID.PalladiumHeadgear, ItemID.PalladiumMask, ItemID.PalladiumHelmet, ItemID.PalladiumBreastplate, ItemID.PalladiumLeggings]},
            { "Mythril", [ItemID.MythrilHood, ItemID.MythrilHelmet, ItemID.MythrilHat, ItemID.MythrilChainmail, ItemID.MythrilGreaves]},
            { "Orichalcum", [ItemID.OrichalcumHeadgear, ItemID.OrichalcumMask, ItemID.OrichalcumHelmet, ItemID.OrichalcumBreastplate, ItemID.OrichalcumLeggings]},
            { "Adamantite", [ItemID.AdamantiteHeadgear, ItemID.AdamantiteHelmet, ItemID.AdamantiteMask, ItemID.AdamantiteBreastplate, ItemID.AdamantiteLeggings]},
            { "Titanium", [ItemID.TitaniumHeadgear, ItemID.TitaniumMask, ItemID.TitaniumHelmet, ItemID.TitaniumBreastplate, ItemID.TitaniumLeggings]},
            { "Crystal Assassin", [ItemID.CrystalNinjaHelmet, ItemID.CrystalNinjaChestplate, ItemID.CrystalNinjaLeggings]},
            { "Frost", [ItemID.FrostHelmet, ItemID.FrostBreastplate, ItemID.FrostLeggings]},
            { "Forbidden", [ItemID.AncientBattleArmorHat, ItemID.AncientBattleArmorShirt, ItemID.AncientBattleArmorPants]},
            { "Squire", [ItemID.SquireGreatHelm, ItemID.SquirePlating, ItemID.SquireGreaves]},
            { "Monk", [ItemID.MonkBrows, ItemID.MonkShirt, ItemID.MonkPants]},
            { "Huntress", [ItemID.HuntressWig, ItemID.HuntressJerkin, ItemID.HuntressPants]},
            { "Apprentice", [ItemID.ApprenticeHat, ItemID.ApprenticeRobe, ItemID.ApprenticeTrousers]},
            { "Hallowed", [ItemID.HallowedMask, ItemID.HallowedHelmet, ItemID.HallowedHood, ItemID.HallowedHood, ItemID.HallowedPlateMail, ItemID.HallowedGreaves]},
            { "Ancient Hallowed", [ItemID.AncientHallowedMask, ItemID.AncientHallowedHelmet, ItemID.AncientHallowedHood, ItemID.AncientHallowedHood, ItemID.AncientHallowedPlateMail, ItemID.AncientHallowedGreaves]},
            { "Chlorophyte", [ItemID.ChlorophyteMask, ItemID.ChlorophyteHelmet, ItemID.ChlorophyteHeadgear, ItemID.ChlorophytePlateMail, ItemID.ChlorophyteGreaves]},
            { "Turtle", [ItemID.TurtleHelmet, ItemID.TurtleScaleMail, ItemID.TurtleLeggings]},
            { "Tiki", [ItemID.TikiMask, ItemID.TikiShirt, ItemID.TikiPants]},
            { "Beetle", [ItemID.BeetleHelmet, ItemID.BeetleScaleMail, ItemID.BeetleShell, ItemID.BeetleLeggings]},
            { "Shroomite", [ItemID.ShroomiteHeadgear, ItemID.ShroomiteHelmet, ItemID.ShroomiteMask, ItemID.ShroomiteBreastplate, ItemID.ShroomiteLeggings]},
            { "Spectre", [ItemID.SpectreMask, ItemID.SpectreHood, ItemID.SpectreRobe, ItemID.SpectrePants]},
            { "Spooky", [ItemID.SpookyHelmet, ItemID.SpookyBreastplate, ItemID.SpookyLeggings]},
            { "Valhalla Knight", [ItemID.SquireAltHead, ItemID.SquireAltShirt, ItemID.SquireAltPants]},
            { "Shinobi Infiltrator", [ItemID.MonkAltHead, ItemID.MonkAltShirt, ItemID.MonkAltPants]},
            { "Red Riding", [ItemID.HuntressAltHead, ItemID.HuntressAltShirt, ItemID.HuntressAltPants]},
            { "Dark Artist", [ItemID.ApprenticeAltHead, ItemID.ApprenticeAltShirt, ItemID.ApprenticeAltPants]},
            { "Solar Flare", [ItemID.SolarFlareHelmet, ItemID.SolarFlareBreastplate, ItemID.SolarFlareLeggings]},
            { "Vortex", [ItemID.VortexHelmet, ItemID.VortexBreastplate, ItemID.VortexLeggings]},
            { "Nebula", [ItemID.NebulaHelmet, ItemID.NebulaBreastplate, ItemID.NebulaLeggings]},
            { "Stardust", [ItemID.StardustHelmet, ItemID.StardustBreastplate, ItemID.StardustLeggings]},

            // Wizard
            { "Wizard", [ItemID.MagicHat, ItemID.WizardHat, ItemID.AmethystRobe, ItemID.TopazRobe, ItemID.SapphireRobe, ItemID.EmeraldRobe, ItemID.RubyRobe, ItemID.AmberRobe, ItemID.DiamondRobe, ItemID.GypsyRobe] },

            // Misc.
            { "Misc.", [ItemID.EmptyBucket, ItemID.Goggles, ItemID.DivingHelmet, ItemID.NightVisionHelmet, ItemID.VikingHelmet, ItemID.UltrabrightHelmet, ItemID.FlinxFurCoat, ItemID.Gi, ItemID.MoonLordLegs, ItemID.GreenCap]}
        };
        private static readonly Dictionary<string, int[]> VanitySets = new()
        {
            { "Ancient", [ItemID.AncientArmorHat, ItemID.AncientArmorShirt, ItemID.AncientArmorPants] },
            { "Archaeologist's", [ItemID.ArchaeologistsHat, ItemID.ArchaeologistsJacket, ItemID.ArchaeologistsPants] },
            { "Bee", [ItemID.BeeHat, ItemID.BeeShirt, ItemID.BeePants] },
            { "Black Graduation", [ItemID.GraduationCapBlack, ItemID.GraduationGownBlack] },
            { "Blue Graduation", [ItemID.GraduationCapBlue, ItemID.GraduationGownBlue] },
            { "Buccaneer", [ItemID.BuccaneerBandana, ItemID.BuccaneerShirt, ItemID.BuccaneerPants] },
            { "Bunny", [ItemID.BunnyEars, ItemID.BunnyTail] },
            { "Butcher's", [ItemID.ButcherMask, ItemID.ButcherApron, ItemID.ButcherPants] },
            { "Capricorn", [ItemID.CapricornMask, ItemID.CapricornChestplate, ItemID.CapricornLegs, ItemID.CapricornTail] },
            { "Chef", [ItemID.ChefHat, ItemID.ChefShirt, ItemID.ChefPants] },
            { "Clown", [ItemID.ClownHat, ItemID.ClownShirt, ItemID.ClownPants] },
            { "Country Club", [ItemID.GolfHat, ItemID.GolfShirt, ItemID.GolfPants] },
            { "Cowboy", [ItemID.CowboyHat, ItemID.CowboyJacket, ItemID.CowboyPants] },
            { "Dog", [ItemID.DogEars, ItemID.DogTail] },
            { "Dr. Man Fly", [ItemID.DrManFlyMask, ItemID.DrManFlyLabCoat] },
            { "Elf", [ItemID.ElfHat, ItemID.ElfShirt, ItemID.ElfPants] },
            { "Fallen Tuxedo", [ItemID.FallenTuxedoShirt, ItemID.FallenTuxedoPants] },
            { "Familiar", [ItemID.FamiliarWig, ItemID.FamiliarShirt, ItemID.FamiliarPants] },
            { "Firestarter's", [ItemID.WillowShirt, ItemID.WillowSkirt] },
            { "Fish", [ItemID.FishCostumeMask, ItemID.FishCostumeShirt, ItemID.FishCostumeFinskirt] },
            { "Floret Protector", [ItemID.FloretProtectorHelmet, ItemID.FloretProtectorChestplate, ItemID.FloretProtectorLegs] },
            { "Fox", [ItemID.FoxEars, ItemID.FoxTail] },
            { "Funeral", [ItemID.FuneralHat, ItemID.FuneralCoat, ItemID.FuneralPants] },
            { "Gentleman", [ItemID.WilsonBeardShort, ItemID.WilsonBeardLong, ItemID.WilsonBeardMagnificent, ItemID.WilsonShirt, ItemID.WilsonPants] },
            { "Gravedigger", [ItemID.UndertakerHat, ItemID.UndertakerCoat] },
            { "Hero's", [ItemID.HerosHat, ItemID.HerosShirt, ItemID.HerosPants] },
        };


        protected override string Identifier { get => "COLLECTOR"; }

        protected override string TexturePath { get => "CollectorAchievements/Assets/Achievements"; }

        protected override void RegisterAchievements()
        {
            string name;
            AchCondition cond;
            List<AchCondition> conds;
            ConditionReqs reqs = new(PlayerDiff.Classic, WorldDiff.Classic, SpecialSeed.None);
        }
    }
}
