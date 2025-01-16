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
            { "Lamia", [ItemID.LamiaHat, ItemID.LamiaShirt, ItemID.LamiaPants] },
            { "Lizard", [ItemID.LizardEars, ItemID.LizardTail] },
            { "Lunar Cultist", [ItemID.BlueLunaticHood, ItemID.BlueLunaticRobe] },
            { "Maid", [ItemID.MaidHead, ItemID.MaidShirt, ItemID.MaidPants] },
            { "Maroon Graduation", [ItemID.GraduationCapMaroon, ItemID.GraduationGownMaroon] },
            { "Martian Costume", [ItemID.MartianCostumeMask, ItemID.MartianCostumeShirt, ItemID.MartianCostumePants] },
            { "Martian Uniform", [ItemID.MartianUniformHelmet, ItemID.MartianUniformTorso, ItemID.MartianUniformPants] },
            { "Master Gamer's", [ItemID.GameMasterShirt, ItemID.GameMasterPants] },
            { "Mermaid", [ItemID.SeashellHairpin, ItemID.MermaidAdornment, ItemID.MermaidTail] },
            { "Mummy", [ItemID.MummyMask, ItemID.MummyShirt, ItemID.MummyPants] },
            { "Mushroom", [ItemID.MushroomHat, ItemID.MushroomVest, ItemID.MushroomPants] },
            { "Pedguin's", [ItemID.PedguinHat, ItemID.PedguinShirt, ItemID.PedguinPants] },
            { "Pharaoh's", [ItemID.PharaohsMask, ItemID.PharaohsRobe] },
            { "Pink Maid", [ItemID.MaidHead2, ItemID.MaidShirt2, ItemID.MaidPants2] },
            { "Pirate", [ItemID.PirateHat, ItemID.PirateShirt, ItemID.PiratePants] },
            { "Plaguebringer's", [ItemID.PlaguebringerHelmet, ItemID.PlaguebringerChestplate, ItemID.PlaguebringerGreaves] },
            { "Plumber's", [ItemID.PlumbersHat, ItemID.PlumbersPants, ItemID.PlumbersPants] },
            { "Pretty Pink", [ItemID.PrettyPinkRibbon, ItemID.PrettyPinkDressSkirt, ItemID.PrettyPinkDressPants] },
            { "Prince", [ItemID.PrinceUniform, ItemID.PrincePants, ItemID.PrinceCape] },
            { "Princess", [ItemID.Tiara, ItemID.PrincessDress] },
            { "Royal", [ItemID.RoyalTiara, ItemID.RoyalDressTop, ItemID.RoyalDressBottom] },
            { "Rune", [ItemID.RuneHat, ItemID.RuneRobe] },
            { "Sailor", [ItemID.SailorHat, ItemID.SailorShirt, ItemID.SailorPants] },
            { "Scarecrow", [ItemID.ScarecrowHat, ItemID.ScarecrowShirt, ItemID.ScarecrowPants] },
            { "Silly Sunflower", [ItemID.FlowerBoyHat, ItemID.FlowerBoyShirt, ItemID.FlowerBoyPants] },
            { "Solar Cultist", [ItemID.WhiteLunaticHood, ItemID.WhiteLunaticRobe] },
            { "Star Princess", [ItemID.StarPrincessCrown, ItemID.StarPrincessDress] },
            { "Steampunk", [ItemID.SteampunkHat, ItemID.SteampunkShirt, ItemID.SteampunkPants] },
            { "Superhero", [ItemID.SuperHeroMask, ItemID.SuperHeroCostume, ItemID.SuperHeroTights] },
            { "Tax Collector's", [ItemID.TaxCollectorHat, ItemID.TaxCollectorSuit, ItemID.TaxCollectorPants] },
            { "The Doctor's", [ItemID.TheDoctorsShirt, ItemID.TheDoctorsPants] },
            { "Timeless Traveler's", [ItemID.TimelessTravelerHood, ItemID.TimelessTravelerRobe, ItemID.TimelessTravelerBottom] },
            { "Tuxedo", [ItemID.TopHat, ItemID.TuxedoShirt, ItemID.TuxedoPants] },
            { "TV Head", [ItemID.TVHeadMask, ItemID.TVHeadSuit, ItemID.TVHeadPants] },
            { "Victorian Goth", [ItemID.VictorianGothHat, ItemID.VictorianGothDress] },
            { "Wandering", [ItemID.RoninHat, ItemID.RoninShirt, ItemID.RoninPants] },
            { "Wedding", [ItemID.TheBrideHat, ItemID.TheBrideDress] },
            { "White Tuxedo", [ItemID.WhiteTuxedoShirt, ItemID.WhiteTuxedoPants] },

            // Halloween
            { "Bride of Frankenstein", [ItemID.BrideofFrankensteinMask, ItemID.BrideofFrankensteinDress] },
            { "Cat", [ItemID.CatMask, ItemID.CatShirt, ItemID.CatPants] },
            { "Clothier's", [ItemID.RedHat, ItemID.ClothierJacket, ItemID.ClothierPants] },
            { "Creeper", [ItemID.CreeperMask, ItemID.CreeperShirt, ItemID.CreeperPants] },
            { "Cyborg", [ItemID.CyborgHelmet, ItemID.CyborgShirt, ItemID.CyborgPants] },
            { "Dryad", [ItemID.DryadCoverings, ItemID.DryadLoincloth] },
            { "Dye Trader's", [ItemID.DyeTraderTurban, ItemID.DyeTraderRobe] },
            { "Fox", [ItemID.FoxMask, ItemID.FoxShirt, ItemID.FoxPants] },
            { "Ghost", [ItemID.GhostMask, ItemID.GhostShirt] },
            { "Karate Tortoise", [ItemID.KarateTortoiseMask, ItemID.KarateTortoiseShirt, ItemID.KarateTortoisePants] },
            { "Leprechaun", [ItemID.LeprechaunHat, ItemID.LeprechaunShirt, ItemID.LeprechaunPants] },
            { "Nurse", [ItemID.NurseHat, ItemID.NurseShirt, ItemID.NursePants] },
            { "Pixie", [ItemID.PixieShirt, ItemID.PixiePants] },
            { "Princess", [ItemID.PrincessHat, ItemID.PrincessDressNew] },
            { "Pumpkin", [ItemID.PumpkinHelmet, ItemID.PumpkinShirt, ItemID.PumpkinPants] },
            { "Reaper", [ItemID.ReaperHood, ItemID.ReaperRobe] },
            { "Robot", [ItemID.RobotMask, ItemID.RobotShirt, ItemID.RobotPants] },
            { "Space Creature", [ItemID.SpaceCreatureMask, ItemID.SpaceCreatureShirt, ItemID.SpaceCreaturePants] },
            { "Treasure Hunter", [ItemID.TreasureHunterShirt, ItemID.TreasureHunterPants] },
            { "Unicorn", [ItemID.UnicornMask, ItemID.UnicornShirt, ItemID.UnicornPants] },
            { "Vampire", [ItemID.VampireMask, ItemID.VampireShirt, ItemID.VampirePants] },
            { "Witch", [ItemID.WitchHat, ItemID.WitchDress, ItemID.WitchBoots] },
            { "Wolf", [ItemID.WolfMask, ItemID.WolfShirt, ItemID.WolfPants] },

            // Christmas
            { "Mrs. Claus", [ItemID.MrsClauseHat, ItemID.MrsClauseShirt, ItemID.MrsClauseHeels] },
            { "Parka", [ItemID.ParkaHood, ItemID.ParkaCoat, ItemID.ParkaPants] },
            { "Santa", [ItemID.SantaHat, ItemID.SantaShirt, ItemID.SantaPants] },
            { "Tree", [ItemID.TreeMask, ItemID.TreeShirt, ItemID.TreeTrunks] },
        };

        private static readonly Dictionary<string, int[]> Paintings = new()
        {
            { "Golfer", [ItemID.GolfPainting1, ItemID.GolfPainting2, ItemID.GolfPainting3, ItemID.GolfPainting4] },
            { "Painter", [ItemID.ColdWatersintheWhiteLand, ItemID.Daylight, ItemID.DeadlandComesAlive, ItemID.DoNotStepontheGrass, ItemID.EvilPresence, ItemID.FirstEncounter, ItemID.GoodMorning, ItemID.TheLandofDeceivingLooks, ItemID.LightlessChasms, ItemID.PlaceAbovetheClouds, ItemID.SecretoftheSands, ItemID.SkyGuardian, ItemID.ThroughtheWindow, ItemID.UndergroundReward, ItemID.Purity, ItemID.Thunderbolt] },
            { "Painter Graveyard", [ItemID.Nevermore, ItemID.Reborn, ItemID.Graveyard, ItemID.GhostManifestation, ItemID.WickedUndead, ItemID.HailtotheKing, ItemID.BloodyGoblet, ItemID.StillLife] },
            { "Princess", [ItemID.Princess64, ItemID.PaintingOfALass, ItemID.DarkSideHallow, ItemID.PrincessStyle, ItemID.SuspiciouslySparkly, ItemID.TerraBladeChronicles, ItemID.RoyalRomance] },
            { "Clothier", [ItemID.PlacePainting] },
            { "Traveling Merchant", [ItemID.PaintingAcorns, ItemID.PaintingCastleMarsberg, ItemID.PaintingColdSnap, ItemID.PaintingCursedSaint, ItemID.PaintingMartiaLisa, ItemID.MoonLordPainting, ItemID.PaintingWendy, ItemID.PaintingWillow, ItemID.PaintingWilson, ItemID.PaintingWolfgang, ItemID.PaintingTheSeason, ItemID.PaintingSnowfellas, ItemID.PaintingTheTruthIsUpThere, ItemID.HoplitePizza, ItemID.YuumaTheBlueTiger, ItemID.MoonmanandCompany, ItemID.SunshineofIsrapony, ItemID.BennyWarhol, ItemID.DoNotEattheVileMushroom, ItemID.Duality, ItemID.KargohsSummon, ItemID.ParsecPals] },
            { "Truffle", [ItemID.MySon] },
            { "Zoologist", [ItemID.TheWerewolf] },
            { "Desert Underground Cabins", [ItemID.AndrewSphinx, ItemID.WatchfulAntlion, ItemID.BurningSpirit, ItemID.JawsOfDeath, ItemID.TheSandsOfSlime, ItemID.SnakesIHateSnakes, ItemID.LifeAboveTheSand, ItemID.Oasis, ItemID.PrehistoryPreserved, ItemID.AncientTablet, ItemID.Uluru, ItemID.VisitingThePyramids, ItemID.BandageBoy, ItemID.DivineEye] },
            { "Underground Cabins", [ItemID.AmericanExplosive, ItemID.AuroraBorealis, ItemID.Bifrost, ItemID.Bioluminescence, ItemID.CatSword, ItemID.CrownoDevoursHisLunch, ItemID.Discover, ItemID.FairyGuides, ItemID.FatherofSomeone, ItemID.FindingGold, ItemID.ForestTroll, ItemID.GloriousNight, ItemID.GuidePicasso, ItemID.HappyLittleTree, ItemID.Heartlands, ItemID.AHorribleNightforAlchemy, ItemID.Land, ItemID.TheMerchant, ItemID.MorningHunt, ItemID.NurseLisa, ItemID.OldMiner, ItemID.Outcast, ItemID.RareEnchantment, ItemID.Secrets, ItemID.StrangeDeadFellows, ItemID.StrangeGrowth, ItemID.SufficientlyAdvanced, ItemID.Sunflowers, ItemID.TerrarianGothic, ItemID.VikingVoyage, ItemID.Waldo, ItemID.Wildflowers] },
            { "Dungeon", [ItemID.BloodMoonRising, ItemID.BoneWarp, ItemID.TheCreationoftheGuide, ItemID.TheCursedMan, ItemID.TheDestroyer, ItemID.Dryadisque, ItemID.TheEyeSeestheEnd, ItemID.FacingtheCerebralMastermind, ItemID.GloryoftheFire, ItemID.GoblinsPlayingPoker, ItemID.GreatWave, ItemID.TheGuardiansGaze, ItemID.TheHangedMan, ItemID.Impact, ItemID.ThePersistencyofEyes, ItemID.PoweredbyBirds, ItemID.TheScreamer, ItemID.SkellingtonJSkellingsworth, ItemID.SparkyPainting, ItemID.SomethingEvilisWatchingYou, ItemID.StarryNight, ItemID.TrioSuperHeroes, ItemID.TheTwinsHaveAwoken, ItemID.UnicornCrossingtheHallows] },
            { "Underworld", [ItemID.DarkSoulReaper, ItemID.Darkness, ItemID.DemonsEye, ItemID.FlowingMagma, ItemID.HandEarth, ItemID.ImpFace, ItemID.LakeofFire, ItemID.LivingGore, ItemID.OminousPresence, ItemID.ShiningMoon, ItemID.Skelehead, ItemID.TrappedGhost] },
            { "Goodie Bags", [ItemID.BitterHarvest, ItemID.BloodMoonCountess, ItemID.HallowsEve, ItemID.JackingSkeletron, ItemID.MorbidCuriosity] },
            { "Angler Quest Rewards", [ItemID.PillaginMePixels, ItemID.CouchGag, ItemID.Crustography, ItemID.Fangs, ItemID.NotSoLostInParadise, ItemID.SilentFish, ItemID.TheDuke, ItemID.WhatLurksBelow] },
            { "Floating Islands", [ItemID.HighPitch, ItemID.Constellation, ItemID.LoveisintheTrashSlot, ItemID.SunOrnament, ItemID.BlessingfromTheHeavens, ItemID.SeeTheWorldForWhatItIs] },
            { "Blood Moon Fishing", [ItemID.DreadoftheRedSea] },
            { "Hallow Fishing", [ItemID.LadyOfTheLake] },
            { "Solar Eclipse Drops", [ItemID.Requiem, ItemID.OcularResonance, ItemID.AMachineforTerrarians, ItemID.WingsofEvil, ItemID.ThisIsGettingOutOfHand, ItemID.Eyezorhead, ItemID.MidnightSun, ItemID.Buddies] },
            { "Dungeon Chests", [ItemID.RemnantsofDevotion] },
            { "Jungle Temple", [ItemID.LizardKing] },
        };

        private static readonly Dictionary<string, int[]> Banners = new()
        {
            { "Slimes", [ItemID.SlimeBanner, ItemID.GreenSlimeBanner, ItemID.PurpleSlimeBanner, ItemID.UmbrellaSlimeBanner, ItemID.RedSlimeBanner, ItemID.YellowSlimeBanner, ItemID.BlackSlimeBanner, ItemID.MotherSlimeBanner, ItemID.DungeonSlimeBanner, ItemID.PinkyBanner, ItemID.JungleSlimeBanner, ItemID.SpikedJungleSlimeBanner, ItemID.IceSlimeBanner, ItemID.SpikedIceSlimeBanner, ItemID.SandSlimeBanner, ItemID.LavaSlimeBanner, ItemID.ShimmerSlimeBanner, ItemID.ToxicSludgeBanner, ItemID.CorruptSlimeBanner, ItemID.SlimerBanner, ItemID.CrimslimeBanner, ItemID.GastropodBanner, ItemID.IlluminantSlimeBanner, ItemID.RainbowSlimeBanner] },
            
            // Environments
            { "Surface", [ItemID.BirdBanner, ItemID.BunnyBanner, ItemID.GoldfishBanner, ItemID.ZombieBanner, ItemID.DemonEyeBanner, ItemID.GoblinScoutBanner, ItemID.HarpyBanner, ItemID.CrabBanner, ItemID.PinkJellyfishBanner, ItemID.SeaSnailBanner, ItemID.SharkBanner, ItemID.SquidBanner, ItemID.PossessedArmorBanner, ItemID.WanderingEyeBanner, ItemID.WraithBanner, ItemID.WerewolfBanner, ItemID.WyvernBanner] },
            { "Cavern", [ItemID.BatBanner, ItemID.CochinealBeetleBanner, ItemID.CrawdadBanner, ItemID.GiantShellyBanner, ItemID.WormBanner, ItemID.GnomeBanner, ItemID.NypmhBanner, ItemID.SalamanderBanner, ItemID.SkeletonBanner, ItemID.TimBanner, ItemID.UndeadMinerBanner, ItemID.JellyfishBanner, ItemID.ArmoredSkeletonBanner, ItemID.GiantBatBanner, ItemID.MimicBanner, ItemID.RockGolemBanner, ItemID.RuneWizardBanner, ItemID.SkeletonArcherBanner, ItemID.AnglerFishBanner, ItemID.GreenJellyfishBanner] },
            { "Granite Cave", [ItemID.GraniteFlyerBanner, ItemID.GraniteGolemBanner] },
            { "Marble Cave", [ItemID.GreekSkeletonBanner, ItemID.MedusaBanner] },
            { "Spider Cave", [ItemID.SpiderBanner, ItemID.BlackRecluseBanner] },
            { "Glowing Mushroom", [ItemID.AnomuraFungusBanner, ItemID.FungiBulbBanner, ItemID.MushiLadybugBanner, ItemID.SporeBatBanner, ItemID.SporeSkeletonBanner, ItemID.SporeZombieBanner, ItemID.FungoFishBanner] },
            { "Snow", [ItemID.CyanBeetleBanner, ItemID.IceBatBanner, ItemID.PenguinBanner, ItemID.SnowFlinxBanner, ItemID.UndeadVikingBanner, ItemID.ZombieEskimoBanner, ItemID.ArmoredVikingBanner, ItemID.IceElementalBanner, ItemID.IceTortoiseBanner, ItemID.IcyMermanBanner, ItemID.PigronBanner, ItemID.WolfBanner] },
            { "Jungle", [ItemID.DoctorBonesBanner, ItemID.HornetBanner, ItemID.JungleBatBanner, ItemID.LacBeetleBanner, ItemID.ManEaterBanner, ItemID.SnatcherBanner, ItemID.PiranhaBanner, ItemID.AngryTrapperBanner, ItemID.DerplingBanner, ItemID.GiantFlyingFoxBanner, ItemID.TortoiseBanner, ItemID.JungleCreeperBanner, ItemID.MossHornetBanner, ItemID.MothBanner, ItemID.ArapaimaBanner, ItemID.FlyingSnakeBanner, ItemID.LihzahrdBanner] },
            { "Desert", [ItemID.AntlionBanner, ItemID.WalkingAntlionBanner, ItemID.LarvaeAntlionBanner, ItemID.FlyingAntlionBanner, ItemID.TombCrawlerBanner, ItemID.VultureBanner, ItemID.DesertBasiliskBanner, ItemID.DesertDjinnBanner, ItemID.DuneSplicerBanner, ItemID.DesertGhoulBanner, ItemID.DesertLamiaBanner, ItemID.MummyBanner, ItemID.RavagerScorpionBanner] },
            { "Underworld", [ItemID.BoneSerpentBanner, ItemID.DemonBanner, ItemID.FireImpBanner, ItemID.HellbatBanner, ItemID.LavaBatBanner, ItemID.RedDevilBanner] },
            { "Dungeon", [ItemID.AngryBonesBanner, ItemID.CursedSkullBanner, ItemID.SkeletonMageBanner, ItemID.BlueArmoredBonesBanner, ItemID.RustyArmoredBonesBanner, ItemID.HellArmoredBonesBanner, ItemID.DiablolistBanner, ItemID.NecromancerBanner, ItemID.RaggedCasterBanner, ItemID.BoneLeeBanner, ItemID.SkeletonCommandoBanner, ItemID.SkeletonSniperBanner, ItemID.TacticalSkeletonBanner, ItemID.DungeonSpiritBanner, ItemID.GiantCursedSkullBanner, ItemID.PaladinBanner] },
            { "Corruption", [ItemID.DevourerBanner, ItemID.EaterofSoulsBanner, ItemID.ClingerBanner, ItemID.BigMimicCorruptionBanner, ItemID.CorruptorBanner, ItemID.CursedHammerBanner, ItemID.DarkMummyBanner, ItemID.WorldFeederBanner] },
            { "Crimson", [ItemID.BloodCrawlerBanner, ItemID.CrimeraBanner, ItemID.FaceMonsterBanner, ItemID.BloodFeederBanner, ItemID.BloodJellyBanner, ItemID.BloodMummyBanner, ItemID.CrimsonAxeBanner, ItemID.BigMimicCrimsonBanner, ItemID.FloatyGrossBanner, ItemID.HerplingBanner, ItemID.IchorStickerBanner] },
            { "Hallow", [ItemID.ChaosElementalBanner, ItemID.EnchantedSwordBanner, ItemID.BigMimicHallowBanner, ItemID.IlluminantBatBanner, ItemID.LightMummyBanner, ItemID.PixieBanner, ItemID.UnicornBanner] },
            { "Meteorite", [ItemID.MeteorHeadBanner] },

            // Events
            { "Rain/Blizzard",   [ItemID.FlyingFishBanner, ItemID.RaincoatZombieBanner, ItemID.AngryNimbusBanner, ItemID.IceGolemBanner] },
            { "Windy Day",       [ItemID.DandelionBanner] },
            { "Blood Moon",      [ItemID.BloodZombieBanner, ItemID.CorruptBunnyBanner, ItemID.CorruptGoldfishBanner, ItemID.CorruptPenguinBanner, ItemID.DripplerBanner, ItemID.TheGroomBanner, ItemID.TheBrideBanner, ItemID.CrimsonBunnyBanner, ItemID.CrimsonGoldfishBanner, ItemID.CrimsonPenguinBanner, ItemID.EyeballFlyingFishBanner, ItemID.ZombieMermanBanner, ItemID.ClownBanner, ItemID.BloodEelBanner, ItemID.BloodSquidBanner, ItemID.GoblinSharkBanner, ItemID.BloodNautilusBanner] },
            { "Goblin Army",     [ItemID.GoblinArcherBanner, ItemID.GoblinPeonBanner, ItemID.GoblinSorcererBanner, ItemID.GoblinThiefBanner, ItemID.GoblinWarriorBanner, ItemID.GoblinSummonerBanner] },
            { "Sandstorm",       [ItemID.TumbleweedBanner, ItemID.SandElementalBanner, ItemID.SandsharkBanner, ItemID.SandsharkHallowedBanner, ItemID.SandsharkCorruptBanner, ItemID.SandsharkCrimsonBanner] },
            { "Halloween",       [ItemID.RavenBanner, ItemID.GhostBanner, ItemID.HoppinJackBanner] },
            { "Pirate Invasion", [ItemID.ParrotBanner, ItemID.PirateCaptainBanner, ItemID.PirateCorsairBanner, ItemID.PirateCrossbowerBanner, ItemID.PirateDeadeyeBanner, ItemID.PirateBanner] },
            { "Solar Eclipse",   [ItemID.ButcherBanner, ItemID.CreatureFromTheDeepBanner, ItemID.DeadlySphereBanner, ItemID.DrManFlyBanner, ItemID.EyezorBanner, ItemID.FrankensteinBanner, ItemID.FritzBanner, ItemID.MothronBanner, ItemID.NailheadBanner, ItemID.PsychoBanner, ItemID.ReaperBanner, ItemID.SwampThingBanner, ItemID.ThePossessedBanner, ItemID.VampireBanner] },
            { "Frost Legion",    [ItemID.MisterStabbyBanner, ItemID.SnowBallaBanner, ItemID.SnowmanGangstaBanner] },
            { "Pumpkin Moon",    [ItemID.HeadlessHorsemanBanner, ItemID.HellhoundBanner, ItemID.PoltergeistBanner, ItemID.ScarecrowBanner, ItemID.SplinterlingBanner] },
            { "Frost Moon",      [ItemID.ElfArcherBanner, ItemID.ElfCopterBanner, ItemID.FlockoBanner, ItemID.GingerbreadManBanner, ItemID.KrampusBanner, ItemID.NutcrackerBanner, ItemID.PresentMimicBanner, ItemID.YetiBanner, ItemID.ZombieElfBanner] },
            { "Martian Madness", [ItemID.MartianBrainscramblerBanner, ItemID.MartianDroneBanner, ItemID.MartianEngineerBanner, ItemID.MartianGigazapperBanner, ItemID.MartianGreyGruntBanner, ItemID.MartianOfficerBanner, ItemID.MartianRaygunnerBanner, ItemID.MartianScutlixGunnerBanner, ItemID.MartianTeslaTurretBanner, ItemID.MartianWalkerBanner, ItemID.ScutlixBanner] },
            { "Lunar Events",    [ItemID.BlueCultistArcherBanner, ItemID.BlueCultistCasterBanner, ItemID.VortexHornetBanner, ItemID.VortexLarvaBanner, ItemID.VortexHornetQueenBanner, ItemID.VortexRiflemanBanner, ItemID.VortexSoldierBanner, ItemID.NebulaHeadcrabBanner, ItemID.NebulaBeastBanner, ItemID.NebulaBrainBanner, ItemID.NebulaSoldierBanner, ItemID.StardustJellyfishBanner, ItemID.StardustWormBanner, ItemID.StardustSmallCellBanner, ItemID.StardustLargeCellBanner, ItemID.StardustSoldierBanner, ItemID.StardustSpiderBanner, ItemID.SolarCoriteBanner, ItemID.SolarCrawltipedeBanner, ItemID.SolarDrakomireBanner, ItemID.SolarDrakomireRiderBanner, ItemID.SolarSolenianBanner, ItemID.SolarSrollerBanner] },
            { "Old One's Army",  [ItemID.DD2JavelinThrowerBanner, ItemID.DD2GoblinBanner, ItemID.DD2GoblinBomberBanner, ItemID.DD2WyvernBanner, ItemID.DD2SkeletonBanner, ItemID.DD2DrakinBanner, ItemID.DD2LightningBugBanner, ItemID.DD2KoboldBanner, ItemID.DD2KoboldFlyerBanner, ItemID.DD2WitherBeastBanner] },
        };

        private static readonly int[] Pets = [ItemID.AmberMosquito, ItemID.EatersBone, ItemID.BoneRattle, ItemID.BabyGrinchMischiefWhistle, ItemID.Nectar, ItemID.HellCake, ItemID.Fish, ItemID.BambooLeaf, ItemID.BoneKey, ItemID.ToySled, ItemID.StrangeGlowingMushroom, ItemID.FullMoonSqueakyToy, ItemID.BerniePetItem, ItemID.UnluckyYarn, ItemID.BlueEgg, ItemID.GlowTulip, ItemID.ChesterPetItem, ItemID.CompanionCube, ItemID.CursedSapling, ItemID.BallOfFuseWire, ItemID.CelestialWand, ItemID.EyeSpring, ItemID.ExoticEasternChewToy, ItemID.BedazzledNectar, ItemID.GlommerPetItem, ItemID.DD2PetDragon, ItemID.JunimoPetItem, ItemID.BirdieRattle, ItemID.LizardEgg, ItemID.TartarSauce, ItemID.ParrotCracker, ItemID.PigPetItem, ItemID.MudBud, ItemID.DD2PetGato, ItemID.DogWhistle, ItemID.Seedling, ItemID.SpiderEgg, ItemID.OrnateShadowKey, ItemID.SharkBait, ItemID.SpiffoPlush, ItemID.MagicalPumpkinSeed, ItemID.EucaluptusSap, ItemID.DirtiestBlock, ItemID.TikiTotem, ItemID.Seaweed, ItemID.LightningCarrot, ItemID.ZephyrFish];

        private static readonly int[] LightPets = [ItemID.ShadowOrb, ItemID.CrimsonHeart, ItemID.MagicLantern, ItemID.FairyBell, ItemID.DD2OgrePetItem, ItemID.WispinaBottle];

        
        private static readonly Dictionary<string, int[]> Dyes = new()
        {
            { "Basic",     [ItemID.RedDye, ItemID.OrangeDye, ItemID.YellowDye, ItemID.LimeDye, ItemID.GreenDye, ItemID.TealDye, ItemID.CyanDye, ItemID.SkyBlueDye, ItemID.BlueDye, ItemID.PurpleDye, ItemID.VioletDye, ItemID.PinkDye, ItemID.BlackDye, ItemID.BrownDye, ItemID.SilverDye]},
            { "Bright",    [ItemID.BrightRedDye, ItemID.BrightOrangeDye, ItemID.BrightYellowDye, ItemID.BrightLimeDye, ItemID.BrightGreenDye, ItemID.BrightTealDye, ItemID.BrightCyanDye, ItemID.BrightSkyBlueDye, ItemID.BrightBlueDye, ItemID.BrightPurpleDye, ItemID.BrightVioletDye, ItemID.BrightPinkDye, ItemID.BrightBrownDye, ItemID.BrightSilverDye]},
            { "Gradient",  [ItemID.FlameDye, ItemID.GreenFlameDye, ItemID.BlueFlameDye, ItemID.YellowGradientDye, ItemID.CyanGradientDye, ItemID.VioletGradientDye, ItemID.RainbowDye, ItemID.IntenseFlameDye, ItemID.IntenseGreenFlameDye, ItemID.IntenseBlueFlameDye, ItemID.IntenseRainbowDye]},
            { "Compound",  [ItemID.RedandBlackDye, ItemID.OrangeandBlackDye, ItemID.YellowandBlackDye, ItemID.LimeandBlackDye, ItemID.GreenandBlackDye, ItemID.TealandBlackDye, ItemID.CyanandBlackDye, ItemID.SkyBlueandBlackDye, ItemID.BlueandBlackDye, ItemID.PurpleandBlackDye, ItemID.VioletandBlackDye, ItemID.PinkandBlackDye, ItemID.BrownAndBlackDye, ItemID.SilverAndBlackDye, ItemID.FlameAndBlackDye, ItemID.GreenFlameAndBlackDye, ItemID.BlueFlameAndBlackDye, ItemID.RedandSilverDye, ItemID.OrangeandSilverDye, ItemID.YellowandSilverDye, ItemID.LimeandSilverDye, ItemID.GreenandSilverDye, ItemID.TealandSilverDye, ItemID.CyanandSilverDye, ItemID.SkyBlueandSilverDye, ItemID.BlueandSilverDye, ItemID.PurpleandSilverDye, ItemID.VioletandSilverDye, ItemID.PinkandSilverDye, ItemID.BrownAndSilverDye, ItemID.BlackAndWhiteDye, ItemID.FlameAndSilverDye, ItemID.GreenFlameAndSilverDye, ItemID.BlueFlameAndSilverDye]},
            { "Strange",   [ItemID.AcidDye, ItemID.BlueAcidDye, ItemID.RedAcidDye, ItemID.ChlorophyteDye, ItemID.GelDye, ItemID.MushroomDye, ItemID.GrimDye, ItemID.HadesDye, ItemID.BurningHadesDye, ItemID.ShadowflameHadesDye, ItemID.LivingOceanDye, ItemID.LivingFlameDye, ItemID.LivingRainbowDye, ItemID.MartianArmorDye, ItemID.MidnightRainbowDye, ItemID.MirageDye, ItemID.NegativeDye, ItemID.PixieDye, ItemID.PhaseDye, ItemID.PurpleOozeDye, ItemID.ReflectiveDye, ItemID.ReflectiveCopperDye, ItemID.ReflectiveGoldDye, ItemID.ReflectiveObsidianDye, ItemID.ReflectiveMetalDye, ItemID.ReflectiveSilverDye, ItemID.ShadowDye, ItemID.ShiftingSandsDye, ItemID.DevDye, ItemID.TwilightDye, ItemID.WispDye, ItemID.InfernalWispDye, ItemID.UnicornWispDye] },
            { "Craftable", [ItemID.NebulaDye, ItemID.SolarDye, ItemID.StardustDye, ItemID.VortexDye, ItemID.ShiftingPearlSandsDye, ItemID.PinkGelDye, ItemID.VoidDye]}
            { "Other",     [ItemID.BloodbathDye, ItemID.FogboundDye, ItemID.HallowBossDye]}
        };

        private static readonly Dictionary<string, int[]> MeleeWeapons = new()
        {
            { "Sword", [ItemID.CopperShortsword, ItemID.TinShortsword, ItemID.WoodenSword, ItemID.BorealWoodSword, ItemID.CopperBroadsword, ItemID.IronShortsword, ItemID.PalmWoodSword, ItemID.RichMahoganySword, ItemID.CactusSword, ItemID.LeadShortsword, ItemID.SilverShortsword, ItemID.TinBroadsword, ItemID.EbonwoodSword, ItemID.IronBroadsword, ItemID.ShadewoodSword, ItemID.TungstenShortsword, ItemID.GoldShortsword, ItemID.LeadBroadsword, ItemID.SilverBroadsword, ItemID.AshWoodSword, ItemID.Flymeal, ItemID.BladedGlove, ItemID.TungstenBroadsword, ItemID.ZombieArm, ItemID.GoldBroadsword, ItemID.PlatinumShortsword, ItemID.AntlionClaw, ItemID.StylistKilLaKillScissorsIWish, ItemID.Ruler, ItemID.PlatinumBroadsword, ItemID.Umbrella, ItemID.BreathingReed, ItemID.Gladius, ItemID.BoneSword, ItemID.BatBat, ItemID.TentacleSpike, ItemID.CandyCaneSword, ItemID.Katana, ItemID.IceBlade, ItemID.LightsBane, ItemID.TragicUmbrella, ItemID.Muramasa, ItemID.DyeTradersScimitar, ItemID.BluePhaseblade, ItemID.GreenPhaseblade, ItemID.OrangePhaseblade, ItemID.PurplePhaseblade, ItemID.RedPhaseblade, ItemID.WhitePhaseblade, ItemID.YellowPhaseblade, ItemID.BloodButcherer, ItemID.Starfury, ItemID.EnchantedSword, ItemID.PurpleClubberfish, ItemID.BeeKeeper, ItemID.FalconBlade, ItemID.BladeofGrass, ItemID.FieryGreatsword, ItemID.NightsEdge, ItemID.PearlwoodSword, ItemID.TaxCollectorsStickOfDoom, ItemID.SlapHand, ItemID.CobaltSword, ItemID.PalladiumSword, ItemID.BluePhasesaber, ItemID.GreenPhasesaber, ItemID.OrangePhasesaber, ItemID.PurplePhasesaber, ItemID.RedPhasesaber, ItemID.WhitePhasesaber, ItemID.YellowPhasesaber, ItemID.IceSickle, ItemID.DD2SquireDemonSword, ItemID.MythrilSword, ItemID.OrichalcumSword, ItemID.BreakerBlade, ItemID.Cutlass, ItemID.Frostbrand, ItemID.AdamantiteSword, ItemID.BeamSword, ItemID.TitaniumSword, ItemID.FetidBaghnakhs, ItemID.Bladetongue, ItemID.HamBat, ItemID.Excalibur, ItemID.TrueExcalibur, ItemID.ChlorophyteSaber, ItemID.DeathSickle, ItemID.PsychoKnife, ItemID.Keybrand, ItemID.ChlorophyteClaymore, ItemID.TheHorsemansBlade, ItemID.ChristmasTreeSword, ItemID.TrueNightsEdge, ItemID.Seedler, ItemID.DD2SquireBetsySword, ItemID.PiercingStarlight, ItemID.TerraBlade, ItemID.InfluxWaver, ItemID.StarWrath, ItemID.Meowmere]},
            { "Yoyo", [ItemID.WoodYoyo, ItemID.Rally, ItemID.CorruptYoyo, ItemID.CrimsonYoyo, ItemID.JungleYoyo, ItemID.Code1, ItemID.Valor, ItemID.Cascade, ItemID.HiveFive, ItemID.FormatC, ItemID.Gradient, ItemID.Chik, ItemID.HelFire, ItemID.Amarok, ItemID.Code2, ItemID.Yelets, ItemID.Kraken, ItemID.TheEyeOfCthulhu, ItemID.Terrarian]},
            { "Spear", [ItemID.Spear, ItemID.Trident, ItemID.ThunderStaff, ItemID.TheRottedFork, ItemID.Swordfish, ItemID.DarkLance, ItemID.CobaltNaginata, ItemID.PalladiumPike, ItemID.MythrilHalberd, ItemID.OrichalcumHalberd, ItemID.AdamantiteGlaive, ItemID.TitaniumTrident, ItemID.Gungnir, ItemID.MonkStaffT2, ItemID.ChlorophytePartisan, ItemID.MushroomSpear, ItemID.ObsidianSwordfish, ItemID.NorthPole]},
            { "Boomerang", [ItemID.WoodenBoomerang, ItemID.EnchantedBoomerang, ItemID.FruitcakeChakram, ItemID.BloodyMachete, ItemID.Shroomerang, ItemID.IceBoomerang, ItemID.Trimarang, ItemID.ThornChakram, ItemID.CombatWrench, ItemID.Flamarang, ItemID.FlyingKnife, ItemID.BouncingShield, ItemID.LightDisc, ItemID.Bananarang, ItemID.PossessedHatchet, ItemID.PaladinsHammer]},
            { "Flail", [ItemID.ChainKnife, ItemID.Mace, ItemID.FlamingMace, ItemID.BallOHurt, ItemID.TheMeatball, ItemID.BlueMoon, ItemID.Sunfury, ItemID.Anchor, ItemID.KOCannon, ItemID.DripplerFlail, ItemID.ChainGuillotines, ItemID.DaoofPow, ItemID.FlowerPow, ItemID.GolemFist, ItemID.Flairon]},
            { "Other", [ItemID.Terragrim, ItemID.JoustingLance, ItemID.ShadowFlameKnife, ItemID.JoustingLance, ItemID.MonkStaffT1, ItemID.ScourgeoftheCorruptor, ItemID.ShadowJoustingLance, ItemID.VampireKnives, ItemID.MonkStaffT3, ItemID.DayBreak, ItemID.SolarEruption, ItemID.Zenith]},
        };

        private static readonly Dictionary<string, int[]> RangedWeapons = new()
        {
            { "Bow", [ItemID.WoodenBow, ItemID.BorealWoodBow, ItemID.CopperBow, ItemID.PalmWoodBow, ItemID.RichMahoganyBow, ItemID.TinBow, ItemID.EbonwoodBow, ItemID.IronBow, ItemID.ShadewoodBow, ItemID.LeadBow, ItemID.SilverBow, ItemID.AshWoodBow, ItemID.TungstenBow, ItemID.GoldBow, ItemID.PlatinumBow, ItemID.DemonBow, ItemID.TendonBow, ItemID.BloodRainBow, ItemID.BeesKnees, ItemID.HellwingBow, ItemID.MoltenFury, ItemID.PearlwoodBow, ItemID.Marrow, ItemID.IceBow, ItemID.DaedalusStormbow, ItemID.ShadowFlameBow, ItemID.DD2PhoenixBow, ItemID.PulseBow, ItemID.DD2BetsyBow, ItemID.Tsunami, ItemID.FairyQueenRangedItem, ItemID.Phantasm] },
            { "Repeater", [ItemID.CobaltRepeater, ItemID.PalladiumRepeater, ItemID.MythrilRepeater, ItemID.OrichalcumRepeater, ItemID.AdamantiteRepeater, ItemID.TitaniumRepeater, ItemID.HallowedRepeater, ItemID.ChlorophyteShotbow, ItemID.StakeLauncher] },
            { "Gun", [ItemID.RedRyder, ItemID.FlintlockPistol, ItemID.Musket, ItemID.TheUndertaker, ItemID.Sandgun, ItemID.Revolver, ItemID.Minishark, ItemID.Boomstick, ItemID.QuadBarrelShotgun, ItemID.Handgun, ItemID.PhoenixBlaster, ItemID.PewMaticHorn, ItemID.ClockworkAssaultRifle, ItemID.Gatligator, ItemID.Shotgun, ItemID.OnyxBlaster, ItemID.CoinGun, ItemID.Uzi, ItemID.Megashark, ItemID.VenusMagnum, ItemID.TacticalShotgun, ItemID.SniperRifle, ItemID.CandyCornRifle, ItemID.ChainGun, ItemID.Xenopopper, ItemID.VortexBeater, ItemID.SDMG] },
            { "Launcher", [ItemID.GrenadeLauncher, ItemID.ProximityMineLauncher, ItemID.RocketLauncher, ItemID.NailGun, ItemID.Stynger, ItemID.JackOLanternLauncher, ItemID.SnowballCannon, ItemID.FireworksLauncher, ItemID.ElectrosphereLauncher, ItemID.Celeb2] },
            { "Consumable", [ItemID.PaperAirplaneA, ItemID.PaperAirplaneB, ItemID.Shuriken, ItemID.ThrowingKnife, ItemID.PoisonedKnife, ItemID.Snowball, ItemID.SpikyBall, ItemID.Bone, ItemID.RottenEgg, ItemID.StarAnise, ItemID.MolotovCocktail, ItemID.FrostDaggerfish, ItemID.Javelin, ItemID.BoneJavelin, ItemID.BoneDagger, ItemID.Grenade, ItemID.StickyGrenade, ItemID.BouncyGrenade, ItemID.Beenade, ItemID.PartyGirlGrenade] },
            { "Other", [ItemID.FlareGun, ItemID.AleThrowingGlove, ItemID.Blowpipe, ItemID.Blowgun, ItemID.SnowballCannon, ItemID.PainterPaintballGun, ItemID.Harpoon, ItemID.StarCannon, ItemID.Toxikarp, ItemID.DartPistol, ItemID.DartRifle, ItemID.Flamethrower, ItemID.PiranhaGun, ItemID.ElfMelter, ItemID.SuperStarCannon] },
        };

        private static readonly Dictionary<string, int[]> MagicWeapons = new()
        {
            { "Wand", [ItemID.WandofSparking, ItemID.WandofFrosting, ItemID.ThunderStaff, ItemID.AmethystStaff, ItemID.TopazStaff, ItemID.SapphireStaff, ItemID.EmeraldStaff, ItemID.RubyStaff, ItemID.DiamondStaff, ItemID.AmberStaff, ItemID.Vilethorn, ItemID.WeatherPain, ItemID.MagicMissile, ItemID.AquaScepter, ItemID.FlowerofFire, ItemID.Flamelash, ItemID.SkyFracture, ItemID.CrystalSerpent, ItemID.FlowerofFrost, ItemID.FrostStaff, ItemID.CrystalVileShard, ItemID.SoulDrain, ItemID.MeteorStaff, ItemID.PoisonStaff, ItemID.RainbowRod, ItemID.UnholyTrident, ItemID.BookStaff, ItemID.VenomStaff, ItemID.NettleBurst, ItemID.BatScepter, ItemID.BlizzardStaff, ItemID.InfernoFork, ItemID.ShadowbeamStaff, ItemID.SpectreStaff, ItemID.PrincessWeapon, ItemID.Razorpine, ItemID.StaffofEarth, ItemID.ApprenticeStaffT3]},
            { "Magic Gun", [ItemID.ZapinatorGray, ItemID.SpaceGun, ItemID.BeeGun, ItemID.LaserRifle, ItemID.ZapinatorOrange, ItemID.WaspGun, ItemID.WaspGun, ItemID.LeafBlower, ItemID.RainbowGun, ItemID.HeatRay, ItemID.LaserMachinegun, ItemID.ChargedBlasterCannon, ItemID.BubbleGun]},
            { "Spell Books", [ItemID.WaterBolt, ItemID.BookofSkulls, ItemID.DemonScythe, ItemID.CursedFlames, ItemID.GoldenShower, ItemID.CrystalStorm, ItemID.MagnetSphere, ItemID.RazorbladeTyphoon, ItemID.LunarFlareBook]},
            { "Other", [ItemID.CrimsonRod, ItemID.IceRod, ItemID.ClingerStaff, ItemID.NimbusRod, ItemID.MagicDagger, ItemID.MedusaHead, ItemID.SpiritFlame, ItemID.ShadowFlameHexDoll, ItemID.SharpTears, ItemID.MagicalHarp, ItemID.ToxicFlask, ItemID.FairyQueenMagicItem, ItemID.SparkleGuitar, ItemID.NebulaArcanum, ItemID.NebulaBlaze, ItemID.LastPrism]},
            { "Minion Summoning", [ItemID.BabyBirdStaff, ItemID.SlimeStaff, ItemID.FlinxStaff, ItemID.AbigailsFlower, ItemID.HornetStaff, ItemID.VampireFrogStaff, ItemID.ImpStaff, ItemID.Smolstar, ItemID.SpiderStaff, ItemID.PirateStaff, ItemID.SanguineStaff, ItemID.OpticStaff, ItemID.DeadlySphereStaff, ItemID.PygmyStaff, ItemID.RavenStaff, ItemID.StormTigerStaff, ItemID.TempestStaff, ItemID.EmpressBlade, ItemID.XenoStaff, ItemID.StardustCellStaff, ItemID.StardustDragonStaff]},
            { "Sentry Summoning", [ItemID.DD2LightningAuraT1Popper, ItemID.DD2FlameburstTowerT1Popper, ItemID.DD2ExplosiveTrapT1Popper, ItemID.DD2BallistraTowerT1Popper, ItemID.HoundiusShootius, ItemID.QueenSpiderStaff, ItemID.DD2LightningAuraT2Popper, ItemID.DD2FlameburstTowerT2Popper, ItemID.DD2ExplosiveTrapT2Popper, ItemID.DD2BallistraTowerT2Popper, ItemID.StaffoftheFrostHydra, ItemID.DD2LightningAuraT3Popper, ItemID.DD2FlameburstTowerT3Popper, ItemID.DD2ExplosiveTrapT3Popper, ItemID.DD2BallistraTowerT3Popper, ItemID.MoonlordTurretStaff, ItemID.RainbowCrystalStaff]},
            { "Whip", [ItemID.BlandWhip, ItemID.ThornWhip, ItemID.BoneWhip, ItemID.FireWhip, ItemID.CoolWhip, ItemID.SwordWhip, ItemID.ScytheWhip, ItemID.MaceWhip, ItemID.RainbowWhip]},
        };
        private static readonly Dictionary<string, int[]> OtherWeapons = new()
        {
            { "Placeable", [ItemID.SnowballLauncher, ItemID.Cannon, ItemID.BunnyCannon, ItemID.LandMine] },
            { "Explosives", [ItemID.Bomb, ItemID.StickyBomb, ItemID.BouncyBomb, ItemID.ScarabBomb, ItemID.Dynamite, ItemID.StickyDynamite, ItemID.BouncyDynamite, ItemID.BombFish] },
            { "Other", [ItemID.HolyWater, ItemID.UnholyWater, ItemID.BloodWater] },
        };
        private static readonly Dictionary<string, int[]> Plants = new()
        {
            { "Moss", [ItemID.GreenMoss, ItemID.BrownMoss, ItemID.RedMoss, ItemID.BlueMoss, ItemID.PurpleMoss, ItemID.LavaMoss, ItemID.KryptonMoss, ItemID.XenonMoss, ItemID.ArgonMoss, ItemID.VioletMoss, ItemID.RainbowMoss] },
            { "Herbs", [ItemID.Blinkroot, ItemID.Daybloom, ItemID.Deathweed, ItemID.Fireblossom, ItemID.Moonglow, ItemID.Shiverthorn, ItemID.Waterleaf] },
            { "Mushrooms", [ItemID.Mushroom, ItemID.GlowingMushroom, ItemID.VileMushroom, ItemID.ViciousMushroom, ItemID.GreenMushroom, ItemID.TealMushroom] },
        };
        private static readonly Dictionary<string, int[]> Tools = new()
        {
            { "Pickaxes/Drills", [ItemID.CactusPickaxe, ItemID.CopperPickaxe, ItemID.TinPickaxe, ItemID.IronPickaxe, ItemID.LeadPickaxe, ItemID.SilverPickaxe, ItemID.TungstenPickaxe, ItemID.GoldPickaxe, ItemID.CnadyCanePickaxe, ItemID.FossilPickaxe, ItemID.BonePickaxe, ItemID.PlatinumPickaxe, ItemID.ReaverShark, ItemID.NightmarePickaxe, ItemID.DeathbringerPickaxe, ItemID.MoltenPickaxe, ItemID.CobaltPickaxe, ItemID.CobaltDrill, ItemID.PalladiumPickaxe, ItemID.PalladiumDrill, ItemID.MythrilPickaxe, ItemID.MythrilDrill, ItemID.OrichalcumPickaxe, ItemID.OrichalcumDrill, ItemID.AdamantitePickaxe, ItemID.AdamantiteDrill, ItemID.TitaniumPickaxe, ItemID.TitaniumDrill, ItemID.SpectrePickaxe, ItemID.ChlorophytePickaxe, ItemID.ChlorophyteDrill, ItemID.PickaxeAxe, ItemID.Drax, ItemID.ShroomiteDiggingClaw, ItemID.Picksaw, ItemID.VortexPickaxe, ItemID.NebulaPickaxe, ItemID.SolarFlarePickaxe, ItemID.StardustPickaxe, ItemID. VortexDrill, ItemID.NebulaDrill, ItemID.SolarFlareDrill, ItemID.StardustDrill, ItemID.LaserDrill },
            { "Axes/Chainsaws", [ItemID.CopperAxe, ItemID.TinAxe, ItemID.IronAxe, ItemID.LeadAxe, ItemID.SilverAxe, ItemID.TungstenAxe, ItemID.GoldAxe, ItemID.PlatinumAxe, ItemID.CobaltWaraxe, ItemID.CobaltChainsaw, ItemID.SawtoothShark, ItemID.WarAxeoftheNight, ItemID.BloodLustCluster, ItemID.PalladiumWaraxe, ItemID.PalladiumChainsaw, ItemID.MythrilWaraxe, ItemID.MythrilChainsaw, ItemID.OrichalcumWaraxe, ItemID.OrichalcumChainsaw, ItemID.AdamantiteWaraxe, ItemID.AdamantiteChainsaw, ItemID.MeteorHamaxe, ItemID.TitaniumWaraxe, ItemID.TitaniumChainsaw, ItemID.PickaxeAxe, ItemID.Drax, ItemID.ChlorophyteGreataxe, ItemID.ChlorophyteChainsaw, ItemID.Picksaw, ItemID.ShroomiteDiggingClaw, ItemID.LucyTheAxe, ItemID.AcornAxe, ItemID.ButchersChainsaw, ItemID.MoltenHamaxe, ItemID.BloodHamaxe, ItemID.SpectreHamaxe, ItemID.LunarHamaxeSolar, ItemID.LunarHamaxeVortex, ItemID.LunarHamaxeNebula, ItemID.LunarHamaxeStardust, ItemID.TheAxe] },
            { "Hammers", [ItemID.WoodenHammer, ItemID.RichMahoganyHammer, ItemID.PalmWoodHammer, ItemID.BorealWoodHammer, ItemID.CopperHammer, ItemID.TinHammer, ItemID.IronHammer, ItemID.EbonwoodHammer, ItemID.ShadewoodHammer, ItemID.LeadHammer, ItemID.AshWoodHammer, ItemID.SilverHammer, ItemID.TungstenHammer, ItemID.GoldHammer, ItemID.TheBreaker, ItemID.PearlwoodHammer, ItemID.FleshGrinder, ItemID.PlatinumHammer, ItemID.MeteorHamaxe, ItemID.Rockfish, ItemID.MoltenHamaxe, ItemID.Pwnhammer, ItemID.BloodHamaxe, ItemID.Hammush, ItemID.ChlorophyteWarhammer, ItemID.ChlorophyteJackhammer, ItemID.SpectreHamaxe, ItemID.LunarHamaxeSolar, ItemID.LunarHamaxeVortex, ItemID.LunarHamaxeNebula, ItemID.LunarHamaxeStardust, ItemID.TheAxe] },
            { "Wiring", [ItemID.Wrench, ItemID.WireCutter, ItemID.BlueWrench, ItemID.GreenWrench, ItemID.WireKite, ItemID.YellowWrench, ItemID.ActuationRod, ItemID.MulticolorWrench] },
            { "Painting", [ItemID.Paintbrush, ItemID.PaintRoller, ItemID.PaintScraper, ItemID.SpectrePaintbrush, ItemID.SpectrePaintRoller, ItemID.SpectrePaintScraper] },
            { "Hooks", [ItemID.GrapplingHook, ItemID.IvyWhip, ItemID.DualHook, ItemID.WebSlinger, ItemID.AmethystHook, ItemID.TopazHook, ItemID.SapphireHook, ItemID.EmeraldHook, ItemID.RubyHook, ItemID.DiamondHook, ItemID.SkeletronHand, ItemID.BatHook, ItemID.SpookyHook, ItemID.CandyCaneHook, ItemID.ChristmasHook, ItemID.FishHook, ItemID.SlimeHook, ItemID.AntiGravityHook, ItemID.TendonHook, ItemID.ThornHook, ItemID.IlluminantHook, ItemID.WormHook, ItemID.LunarHook, ItemID.StaticHook, ItemID.AmberHook, ItemID.SquirrelHook, ItemID.QueenSlimeHook] },
            { "Fishing Poles", [ItemID.WoodFishingPole, ItemID.ReinforcedFishingPole, ItemID.FiberglassFishingPole, ItemID.FisherofSouls, ItemID.GoldenFishingRod, ItemID.MechanicsRod, ItemID.SittingDucksFishingRod, ItemID.Fleshcatcher, ItemID.HotlineFishingHook, ItemID.BloodFishingRod, ItemID.ScarabFishingRod] },
            { "Movement Items", [ItemID.IceMirror, ItemID.MagicMirror, ItemID.CellPhone, ItemID.RodofDiscord, ItemID.RodOfHarmony, ItemID.PortalGun, ItemID.Umbrella, ItemID.TragicUmbrella, ItemID.MagicConch, ItemID.DemonConch, ItemID.MysticCoilSnake, ItemID.Shellphone] },
            { "Block-Placing Wands", [ItemID.LeafWand, ItemID.LivingWoodWand, ItemID.LivingMahoganyLeafWand, ItemID.LivingMahoganyWand, ItemID.HiveWand, ItemID.BoneWand] },
            { "Others", [ItemID.EmptyBucket, ItemID.BottomlessBucket, ItemID.BottomlessLavaBucket, ItemID.BottomlessHoneyBucket, ItemID.BottomlessShimmerBucket, ItemID.SuperAbsorbantSponge, ItemID.LavaAbsorbantSponge, ItemID.HoneyAbsorbantSponge, ItemID.UltraAbsorbantSponge, ItemID.BugNet, ItemID.GoldenBugNet, ItemID.FireproofBugNet, ItemID.Sickle, ItemID.StaffofRegrowth, ItemID.Clentaminator, ItemID.Clentaminator2, ItemID.BreathingReed, ItemID.Binoculars, ItemID.DontHurtCrittersBook, ItemID.DontHurtNatureBook, ItemID.DontHurtComboBook, ItemID.GravediggerShovel, ItemID.EncumberingStone, ItemID.LawnMower, ItemID.SandcastleBucket, ItemID.IceRod, ItemID.FlareGun] },
        };
        private static readonly Dictionary<string, int[]> Statues = new()
        {
            { "Enemy", [ItemID.ZombieArmStatue, ItemID.BatStatue, ItemID.BloodZombieStatue, ItemID.BoneSkeletonStatue, ItemID.ChestStatue, ItemID.CorruptStatue, ItemID.CrabStatue, ItemID.DripplerStatue, ItemID.EyeballStatue, ItemID.GoblinStatue, ItemID.GraniteGolemStatue, ItemID.HarpyStatue, ItemID.HopliteStatue, ItemID.HornetStatue, ItemID.ImpStatue, ItemID.JellyfishStatue, ItemID.MedusaStatue, ItemID.PigronStatue, ItemID.PiranhaStatue, ItemID.SharkStatue, ItemID.SkeletonStatue, ItemID.SlimeStatue, ItemID.UndeadVikingStatue, ItemID.UnicornStatue, ItemID.WallCreeperStatue, ItemID.WraithStatue] },
            { "Critter", [ItemID.BirdStatue, ItemID.BuggyStatue, ItemID.BunnyStatue, ItemID.ButterflyStatue, ItemID.CockatielStatue, ItemID.DragonflyStatue, ItemID.DuckStatue, ItemID.FireflyStatue, ItemID.FishStatue, ItemID.FrogStatue, ItemID.GrasshopperStatue, ItemID.MacawStatue, ItemID.MouseStatue, ItemID.OwlStatue, ItemID.PenguinStatue, ItemID.ScorpionStatue, ItemID.SeagullStatue, ItemID.SnailStatue, ItemID.SquirrelStatue, ItemID.TurtleStatue, ItemID.WormStatue] },
            { "Other", [ItemID.KingStatue, ItemID.QueenStatue, ItemID.BombStatue, ItemID.HeartStatue, ItemID.StarStatue, ItemID.MushroomStatue, ItemID.BoulderStatue, ItemID.CatBast] },
            { "Decorative", [ItemID.AngelStatue, ItemID.AnvilStatue, ItemID.ArmorStatue, ItemID.AxeStatue, ItemID.BoomerangStatue, ItemID.BootStatue, ItemID.BowStatue, ItemID.CrossStatue, ItemID.GargoyleStatue, ItemID.GloomStatue, ItemID.HammerStatue, ItemID.PickaxeStatue, ItemID.PillarStatue, ItemID.PotStatue, ItemID.PotionStatue, ItemID.ReaperStatue, ItemID.ShieldStatue, ItemID.SpearStatue, ItemID.SunflowerStatue, ItemID.SwordStatue, ItemID.TreeStatue, ItemID.WomanStatue, ItemID.LihzahrdStatue, ItemID.LihzahrdGuardianStatue, ItemID.LihzahrdWatcherStatue] },
            // TODO: Text statues?
        };
        private static readonly int[] Wings = [ItemID.CreativeWings, ItemID.AngelWings, ItemID.DemonWings, ItemID.LeafWings, ItemID.FairyWings, ItemID.FinWings, ItemID.FrozenWings, ItemID.HarpyWings, ItemID.Jetpack, ItemID.BatWings, ItemID.BeeWings, ItemID.ButterflyWings, ItemID.FlameWings, ItemID.Hoverboard, ItemID.BoneWings, ItemID.MothronWings, ItemID.GhostWings, ItemID.BeetleWings, ItemID.FestiveWings, ItemID.SpookyWings, ItemID.TatteredFairyWings, ItemID.SteampunkWings, ItemID.BetsyWings, ItemID.RainbowWings, ItemID.FishronWings, ItemID.WingsNebula, ItemID.WingsVortex, ItemID.WingsSolar, ItemID.WingsStardust];

        private static readonly int[] Mounts = [ItemID.SlimySaddle, ItemID.HoneyedGoggles, ItemID.HardySaddle, ItemID.FuzzyCarrot, ItemID.PogoStick, ItemID.GolfCart, ItemID.MolluskWhistle, ItemID.PaintedHorseSaddle, ItemID.MajesticHorseSaddle, ItemID.DarkHorseSaddle, ItemID.SuperheatedBlood, ItemID.AncientHorn, ItemID.BlessedApple, ItemID.ScalyTruffle, ItemID.QueenSlimeMountSaddle, ItemID.ReindeerBells, ItemID.BrainScrambler, ItemID.CosmicCarKey, ItemID.DrillContainmentUnit];

        private static readonly Dictionary<string, int[]> Accessories = new()
        {
            { "Movement", [ItemID.Aglet, ItemID.BalloonHorseshoeHoney, ItemID.AmphibianBoots, ItemID.AnkletoftheWind, ItemID.ArcticDivingGear, ItemID.BalloonPufferfish, ItemID.BlizzardinaBalloon, ItemID.BlizzardinaBottle, ItemID.BlueHorseshoeBalloon, ItemID.BundleofBalloons, ItemID.ClimbingClaws, ItemID.CloudinaBalloon, ItemID.CloudinaBottle, ItemID.DivingGear, ItemID.SandBoots, ItemID.FairyBoots, ItemID.FartInABalloon, ItemID.FartinaJar, ItemID.Flipper, ItemID.FlurryBoots, ItemID.FlyingCarpet, ItemID.FrogFlipper, ItemID.FrogGear, ItemID.FrogLeg, ItemID.FrogWebbing, ItemID.FrostsparkBoots, ItemID.BalloonHorseshoeFart, ItemID.HellfireTreads, ItemID.HermesBoots, ItemID.HoneyBalloon, ItemID.IceSkates, ItemID.FloatingTube, ItemID.JellyfishDivingGear, ItemID.LavaCharm, ItemID.LavaWaders, ItemID.LightningBoots, ItemID.LuckyHorseshoe, ItemID.Magiluminescence, ItemID.MasterNinjaGear, ItemID.MoltenCharm, ItemID.NeptunesShell, ItemID.ObsidianHorseshoe, ItemID.ObsidianWaterWalkingBoots, ItemID.BalloonHorseshoeSharkron, ItemID.RocketBoots, ItemID.SailfishBoots, ItemID.SandstorminaBalloon, ItemID.SandstorminaBottle, ItemID.SharkronBalloon, ItemID.ShinyRedBalloon, ItemID.ShoeSpikes, ItemID.SpectreBoots, ItemID.PortableStool, ItemID.Tabi, ItemID.TerrasparkBoots, ItemID.TigerClimbingGear, ItemID.TsunamiInABottle, ItemID.WaterWalkingBoots, ItemID.WhiteHorseshoeBalloon, ItemID.YellowHorseshoeBalloon] },
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
