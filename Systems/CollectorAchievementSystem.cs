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
            { "Rain/Blizzard", [ItemID.FlyingFishBanner, ItemID.RaincoatZombieBanner, ItemID.AngryNimbusBanner, ItemID.IceGolemBanner] },
            { "Windy Day", [ItemID.DandelionBanner] },
            { "Blood Moon", [ItemID.BloodZombieBanner, ItemID.CorruptBunnyBanner, ItemID.CorruptGoldfishBanner, ItemID.CorruptPenguinBanner, ItemID.DripplerBanner, ItemID.TheGroomBanner, ItemID.TheBrideBanner, ItemID.CrimsonBunnyBanner, ItemID.CrimsonGoldfishBanner, ItemID.CrimsonPenguinBanner, ItemID.EyeballFlyingFishBanner, ItemID.ZombieMermanBanner, ItemID.ClownBanner, ItemID.BloodEelBanner, ItemID.BloodSquidBanner, ItemID.GoblinSharkBanner, ItemID.BloodNautilusBanner] },
            { "Goblin Army", [ItemID.GoblinArcherBanner, ItemID.GoblinPeonBanner, ItemID.GoblinSorcererBanner, ItemID.GoblinThiefBanner, ItemID.GoblinWarriorBanner, ItemID.GoblinSummonerBanner] },
            { "Sandstorm", [ItemID.TumbleweedBanner, ItemID.SandElementalBanner, ItemID.SandsharkBanner, ItemID.SandsharkHallowedBanner, ItemID.SandsharkCorruptBanner, ItemID.SandsharkCrimsonBanner] },
            { "Halloween", [ItemID.RavenBanner, ItemID.GhostBanner, ItemID.HoppinJackBanner] },
            { "Pirate Invasion", [ItemID.ParrotBanner, ItemID.PirateCaptainBanner, ItemID.PirateCorsairBanner, ItemID.PirateCrossbowerBanner, ItemID.PirateDeadeyeBanner, ItemID.PirateBanner] },
            { "Solar Eclipse", [ItemID.ButcherBanner, ItemID.CreatureFromTheDeepBanner, ItemID.DeadlySphereBanner, ItemID.DrManFlyBanner, ItemID.EyezorBanner, ItemID.FrankensteinBanner, ItemID.FritzBanner, ItemID.MothronBanner, ItemID.NailheadBanner, ItemID.PsychoBanner, ItemID.ReaperBanner, ItemID.SwampThingBanner, ItemID.ThePossessedBanner, ItemID.VampireBanner] },
            { "Frost Legion", [ItemID.MisterStabbyBanner, ItemID.SnowBallaBanner, ItemID.SnowmanGangstaBanner] },
            { "Pumpkin Moon", [ItemID.HeadlessHorsemanBanner, ItemID.HellhoundBanner, ItemID.PoltergeistBanner, ItemID.ScarecrowBanner, ItemID.SplinterlingBanner] },
            { "Frost Moon", [ItemID.ElfArcherBanner, ItemID.ElfCopterBanner, ItemID.FlockoBanner, ItemID.GingerbreadManBanner, ItemID.KrampusBanner, ItemID.NutcrackerBanner, ItemID.PresentMimicBanner, ItemID.YetiBanner, ItemID.ZombieElfBanner] },
            { "Martian Madness", [ItemID.MartianBrainscramblerBanner, ItemID.MartianDroneBanner, ItemID.MartianEngineerBanner, ItemID.MartianGigazapperBanner, ItemID.MartianGreyGruntBanner, ItemID.MartianOfficerBanner, ItemID.MartianRaygunnerBanner, ItemID.MartianScutlixGunnerBanner, ItemID.MartianTeslaTurretBanner, ItemID.MartianWalkerBanner, ItemID.ScutlixBanner] },
            { "Lunar Events", [ItemID.BlueCultistArcherBanner, ItemID.BlueCultistCasterBanner, ItemID.VortexHornetBanner, ItemID.VortexLarvaBanner, ItemID.VortexHornetQueenBanner, ItemID.VortexRiflemanBanner, ItemID.VortexSoldierBanner, ItemID.NebulaHeadcrabBanner, ItemID.NebulaBeastBanner, ItemID.NebulaBrainBanner, ItemID.NebulaSoldierBanner, ItemID.StardustJellyfishBanner, ItemID.StardustWormBanner, ItemID.StardustSmallCellBanner, ItemID.StardustLargeCellBanner, ItemID.StardustSoldierBanner, ItemID.StardustSpiderBanner, ItemID.SolarCoriteBanner, ItemID.SolarCrawltipedeBanner, ItemID.SolarDrakomireBanner, ItemID.SolarDrakomireRiderBanner, ItemID.SolarSolenianBanner, ItemID.SolarSrollerBanner] },
            { "Old One's Army", [ItemID.DD2JavelinThrowerBanner, ItemID.DD2GoblinBanner, ItemID.DD2GoblinBomberBanner, ItemID.DD2WyvernBanner, ItemID.DD2SkeletonBanner, ItemID.DD2DrakinBanner, ItemID.DD2LightningBugBanner, ItemID.DD2KoboldBanner, ItemID.DD2KoboldFlyerBanner, ItemID.DD2WitherBeastBanner] },
        };

        private static readonly int[] Pets = [ItemID.AmberMosquito, ItemID.EatersBone, ItemID.BoneRattle, ItemID.BabyGrinchMischiefWhistle, ItemID.Nectar, ItemID.HellCake, ItemID.Fish, ItemID.BambooLeaf, ItemID.BoneKey, ItemID.ToySled, ItemID.StrangeGlowingMushroom, ItemID.FullMoonSqueakyToy, ItemID.BerniePetItem, ItemID.UnluckyYarn, ItemID.BlueEgg, ItemID.GlowTulip, ItemID.ChesterPetItem, ItemID.CompanionCube, ItemID.CursedSapling, ItemID.BallOfFuseWire, ItemID.CelestialWand, ItemID.EyeSpring, ItemID.ExoticEasternChewToy, ItemID.BedazzledNectar, ItemID.GlommerPetItem, ItemID.DD2PetDragon, ItemID.JunimoPetItem, ItemID.BirdieRattle, ItemID.LizardEgg, ItemID.TartarSauce, ItemID.ParrotCracker, ItemID.PigPetItem, ItemID.MudBud, ItemID.DD2PetGato, ItemID.DogWhistle, ItemID.Seedling, ItemID.SpiderEgg, ItemID.OrnateShadowKey, ItemID.SharkBait, ItemID.SpiffoPlush, ItemID.MagicalPumpkinSeed, ItemID.EucaluptusSap, ItemID.DirtiestBlock, ItemID.TikiTotem, ItemID.Seaweed, ItemID.LightningCarrot, ItemID.ZephyrFish];

        private static readonly int[] LightPets = [ItemID.ShadowOrb, ItemID.CrimsonHeart, ItemID.MagicLantern, ItemID.FairyBell, ItemID.DD2OgrePetItem, ItemID.WispinaBottle];

        private static readonly Dictionary<string, int[]> Dyes = new()
        {
            { "Strange", [ItemID.AcidDye, ItemID.BlueAcidDye, ItemID.RedAcidDye, ItemID.ChlorophyteDye, ItemID.GelDye, ItemID.MushroomDye, ItemID.GrimDye, ItemID.HadesDye, ItemID.BurningHadesDye, ItemID.ShadowflameHadesDye, ItemID.LivingOceanDye, ItemID.LivingFlameDye, ItemID.LivingRainbowDye, ItemID.MartianArmorDye, ItemID.MidnightRainbowDye, ItemID.MirageDye, ItemID.NegativeDye, ItemID.PixieDye, ItemID.PhaseDye, ItemID.PurpleOozeDye, ItemID.ReflectiveDye, ItemID.ReflectiveCopperDye, ItemID.ReflectiveGoldDye, ItemID.ReflectiveObsidianDye, ItemID.ReflectiveMetalDye, ItemID.ReflectiveSilverDye, ItemID.ShadowDye, ItemID.ShiftingSandsDye, ItemID.DevDye, ItemID.TwilightDye, ItemID.WispDye, ItemID.InfernalWispDye, ItemID.UnicornWispDye] },
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
