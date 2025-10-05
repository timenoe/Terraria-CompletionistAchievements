using System.Collections.Generic;
using Terraria.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using TerrariaAchievementLib.Achievements;
using TerrariaAchievementLib.Achievements.Conditions;
using CompletionistAchievements.Achievements.Pet;

namespace CompletionistAchievements.Achievements.Banner
{
    public class Info
    {
        // Verified w/ https://terraria.wiki.gg/wiki/Banners_(enemy)
        public static readonly Dictionary<string, int[]> Banners = new()
        {
            { "SLIME", [ItemID.SlimeBanner, ItemID.GreenSlimeBanner, ItemID.PurpleSlimeBanner, ItemID.UmbrellaSlimeBanner, ItemID.RedSlimeBanner, ItemID.YellowSlimeBanner, ItemID.BlackSlimeBanner, ItemID.MotherSlimeBanner, ItemID.DungeonSlimeBanner, ItemID.PinkyBanner, ItemID.JungleSlimeBanner, ItemID.SpikedJungleSlimeBanner, ItemID.IceSlimeBanner, ItemID.SpikedIceSlimeBanner, ItemID.SandSlimeBanner, ItemID.LavaSlimeBanner, ItemID.ShimmerSlimeBanner, ItemID.ToxicSludgeBanner, ItemID.CorruptSlimeBanner, ItemID.SlimerBanner, ItemID.CrimslimeBanner, ItemID.GastropodBanner, ItemID.IlluminantSlimeBanner, ItemID.RainbowSlimeBanner] },
            
            // Environments
            { "CAVERN",           [ItemID.BatBanner, ItemID.CochinealBeetleBanner, ItemID.CrawdadBanner, ItemID.GiantShellyBanner, ItemID.WormBanner, ItemID.NypmhBanner, ItemID.SalamanderBanner, ItemID.SkeletonBanner, ItemID.TimBanner, ItemID.UndeadMinerBanner, ItemID.JellyfishBanner, ItemID.ArmoredSkeletonBanner, ItemID.GiantBatBanner, ItemID.MimicBanner, ItemID.RockGolemBanner, ItemID.RuneWizardBanner, ItemID.SkeletonArcherBanner, ItemID.AnglerFishBanner, ItemID.GreenJellyfishBanner] },
            { "CORRUPTION",       [ItemID.DevourerBanner, ItemID.EaterofSoulsBanner, ItemID.ClingerBanner, ItemID.BigMimicCorruptionBanner, ItemID.CorruptorBanner, ItemID.CursedHammerBanner, ItemID.DarkMummyBanner, ItemID.WorldFeederBanner] },
            { "CRIMSON",          [ItemID.BloodCrawlerBanner, ItemID.CrimeraBanner, ItemID.FaceMonsterBanner, ItemID.BloodFeederBanner, ItemID.BloodJellyBanner, ItemID.BloodMummyBanner, ItemID.CrimsonAxeBanner, ItemID.BigMimicCrimsonBanner, ItemID.FloatyGrossBanner, ItemID.HerplingBanner, ItemID.IchorStickerBanner] },
            { "DESERT",           [ItemID.AntlionBanner, ItemID.WalkingAntlionBanner, ItemID.LarvaeAntlionBanner, ItemID.FlyingAntlionBanner, ItemID.TombCrawlerBanner, ItemID.VultureBanner, ItemID.DesertBasiliskBanner, ItemID.DesertDjinnBanner, ItemID.DuneSplicerBanner, ItemID.DesertGhoulBanner, ItemID.DesertLamiaBanner, ItemID.MummyBanner, ItemID.RavagerScorpionBanner] },
            { "DUNGEON",          [ItemID.AngryBonesBanner, ItemID.CursedSkullBanner, ItemID.SkeletonMageBanner, ItemID.BlueArmoredBonesBanner, ItemID.RustyArmoredBonesBanner, ItemID.HellArmoredBonesBanner, ItemID.DiablolistBanner, ItemID.NecromancerBanner, ItemID.RaggedCasterBanner, ItemID.BoneLeeBanner, ItemID.SkeletonCommandoBanner, ItemID.SkeletonSniperBanner, ItemID.TacticalSkeletonBanner, ItemID.DungeonSpiritBanner, ItemID.GiantCursedSkullBanner, ItemID.PaladinBanner] },
            { "GLOWING_MUSHROOM", [ItemID.AnomuraFungusBanner, ItemID.FungiBulbBanner, ItemID.MushiLadybugBanner, ItemID.SporeBatBanner, ItemID.SporeSkeletonBanner, ItemID.SporeZombieBanner, ItemID.FungoFishBanner] },
            { "GRANITE_CAVE",     [ItemID.GraniteFlyerBanner, ItemID.GraniteGolemBanner] },
            { "HALLOW",           [ItemID.ChaosElementalBanner, ItemID.EnchantedSwordBanner, ItemID.BigMimicHallowBanner, ItemID.IlluminantBatBanner, ItemID.LightMummyBanner, ItemID.PixieBanner, ItemID.UnicornBanner] },
            { "JUNGLE",           [ItemID.DoctorBonesBanner, ItemID.HornetBanner, ItemID.JungleBatBanner, ItemID.LacBeetleBanner, ItemID.ManEaterBanner, ItemID.SnatcherBanner, ItemID.PiranhaBanner, ItemID.AngryTrapperBanner, ItemID.DerplingBanner, ItemID.GiantFlyingFoxBanner, ItemID.TortoiseBanner, ItemID.JungleCreeperBanner, ItemID.MossHornetBanner, ItemID.MothBanner, ItemID.ArapaimaBanner, ItemID.FlyingSnakeBanner, ItemID.LihzahrdBanner] },
            { "MARBLE_CAVE",      [ItemID.GreekSkeletonBanner, ItemID.MedusaBanner] },
            { "METEORITE",        [ItemID.MeteorHeadBanner] },
            { "SNOW",             [ItemID.CyanBeetleBanner, ItemID.IceBatBanner, ItemID.PenguinBanner, ItemID.SnowFlinxBanner, ItemID.UndeadVikingBanner, ItemID.ZombieEskimoBanner, ItemID.ArmoredVikingBanner, ItemID.IceElementalBanner, ItemID.IceTortoiseBanner, ItemID.IcyMermanBanner, ItemID.PigronBanner, ItemID.WolfBanner] },
            { "SPIDER_CAVE",      [ItemID.SpiderBanner, ItemID.BlackRecluseBanner] },
            { "SURFACE",          [ItemID.BirdBanner, ItemID.BunnyBanner, ItemID.GoldfishBanner, ItemID.ZombieBanner, ItemID.DemonEyeBanner, ItemID.GoblinScoutBanner, ItemID.GnomeBanner, ItemID.HarpyBanner, ItemID.CrabBanner, ItemID.PinkJellyfishBanner, ItemID.SeaSnailBanner, ItemID.SharkBanner, ItemID.SquidBanner, ItemID.PossessedArmorBanner, ItemID.WanderingEyeBanner, ItemID.WraithBanner, ItemID.WerewolfBanner, ItemID.WyvernBanner] },
            { "UNDERWORLD",       [ItemID.BoneSerpentBanner, ItemID.DemonBanner, ItemID.FireImpBanner, ItemID.HellbatBanner, ItemID.LavaBatBanner, ItemID.RedDevilBanner] },

            // Events
            { "BLOOD_MOON",      [ItemID.BloodZombieBanner, ItemID.CorruptBunnyBanner, ItemID.CorruptGoldfishBanner, ItemID.CorruptPenguinBanner, ItemID.DripplerBanner, ItemID.TheGroomBanner, ItemID.TheBrideBanner, ItemID.CrimsonBunnyBanner, ItemID.CrimsonGoldfishBanner, ItemID.CrimsonPenguinBanner, ItemID.EyeballFlyingFishBanner, ItemID.ZombieMermanBanner, ItemID.ClownBanner, ItemID.BloodEelBanner, ItemID.BloodSquidBanner, ItemID.GoblinSharkBanner, ItemID.BloodNautilusBanner] },
            { "FROST_LEGION",    [ItemID.MisterStabbyBanner, ItemID.SnowBallaBanner, ItemID.SnowmanGangstaBanner] },
            { "FROST_MOON",      [ItemID.ElfArcherBanner, ItemID.ElfCopterBanner, ItemID.FlockoBanner, ItemID.GingerbreadManBanner, ItemID.KrampusBanner, ItemID.NutcrackerBanner, ItemID.PresentMimicBanner, ItemID.YetiBanner, ItemID.ZombieElfBanner] },
            { "GOBLIN_ARMY",     [ItemID.GoblinArcherBanner, ItemID.GoblinPeonBanner, ItemID.GoblinSorcererBanner, ItemID.GoblinThiefBanner, ItemID.GoblinWarriorBanner, ItemID.GoblinSummonerBanner] },
            { "HALLOWEEN",       [ItemID.RavenBanner, ItemID.GhostBanner, ItemID.HoppinJackBanner] },
            { "LUNAR_EVENTS",    [ItemID.BlueCultistArcherBanner, ItemID.BlueCultistCasterBanner, ItemID.VortexHornetBanner, ItemID.VortexLarvaBanner, ItemID.VortexHornetQueenBanner, ItemID.VortexRiflemanBanner, ItemID.VortexSoldierBanner, ItemID.NebulaHeadcrabBanner, ItemID.NebulaBeastBanner, ItemID.NebulaBrainBanner, ItemID.NebulaSoldierBanner, ItemID.StardustJellyfishBanner, ItemID.StardustWormBanner, ItemID.StardustSmallCellBanner, ItemID.StardustLargeCellBanner, ItemID.StardustSoldierBanner, ItemID.StardustSpiderBanner, ItemID.SolarCoriteBanner, ItemID.SolarCrawltipedeBanner, ItemID.SolarDrakomireBanner, ItemID.SolarDrakomireRiderBanner, ItemID.SolarSolenianBanner, ItemID.SolarSrollerBanner] },
            { "MARTIAN_MADNESS", [ItemID.MartianBrainscramblerBanner, ItemID.MartianDroneBanner, ItemID.MartianEngineerBanner, ItemID.MartianGigazapperBanner, ItemID.MartianGreyGruntBanner, ItemID.MartianOfficerBanner, ItemID.MartianRaygunnerBanner, ItemID.MartianScutlixGunnerBanner, ItemID.MartianTeslaTurretBanner, ItemID.MartianWalkerBanner, ItemID.ScutlixBanner] },
            { "OLD_ONES_ARMY",   [ItemID.DD2JavelinThrowerBanner, ItemID.DD2GoblinBanner, ItemID.DD2GoblinBomberBanner, ItemID.DD2WyvernBanner, ItemID.DD2SkeletonBanner, ItemID.DD2DrakinBanner, ItemID.DD2LightningBugBanner, ItemID.DD2KoboldBanner, ItemID.DD2KoboldFlyerBanner, ItemID.DD2WitherBeastBanner] },
            { "PIRATE_INVASION", [ItemID.ParrotBanner, ItemID.PirateCaptainBanner, ItemID.PirateCorsairBanner, ItemID.PirateCrossbowerBanner, ItemID.PirateDeadeyeBanner, ItemID.PirateBanner] },
            { "PUMPKIN_MOON",    [ItemID.HeadlessHorsemanBanner, ItemID.HellhoundBanner, ItemID.PoltergeistBanner, ItemID.ScarecrowBanner, ItemID.SplinterlingBanner] },
            { "RAIN_BLIZZARD",   [ItemID.FlyingFishBanner, ItemID.RaincoatZombieBanner, ItemID.AngryNimbusBanner, ItemID.IceGolemBanner] },
            { "SANDSTORM",       [ItemID.TumbleweedBanner, ItemID.SandElementalBanner, ItemID.SandsharkBanner, ItemID.SandsharkHallowedBanner, ItemID.SandsharkCorruptBanner, ItemID.SandsharkCrimsonBanner] },
            { "SOLAR_ECLIPSE",   [ItemID.ButcherBanner, ItemID.CreatureFromTheDeepBanner, ItemID.DeadlySphereBanner, ItemID.DrManFlyBanner, ItemID.EyezorBanner, ItemID.FrankensteinBanner, ItemID.FritzBanner, ItemID.MothronBanner, ItemID.NailheadBanner, ItemID.PsychoBanner, ItemID.ReaperBanner, ItemID.SwampThingBanner, ItemID.ThePossessedBanner, ItemID.VampireBanner] },
            { "WINDY_DAY",       [ItemID.DandelionBanner] }
        };

        public static readonly List<int> CraftableBanners = [ItemID.CrawdadBanner, ItemID.GiantShellyBanner, ItemID.SalamanderBanner];
    }
    
    public class BannerSlimeAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/BannerSlimeAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, NpcDropCondition.DropAll(Common.reqs, NPCID.None, Info.Banners["SLIME"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<PetLightAchievement>());
        }
    }

    public class BannerCavernAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/BannerCavernAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            foreach (int banner in Info.Banners["CAVERN"])
            {
                if (Info.CraftableBanners.Contains(banner))
                    AddCondition(ItemGrabCondition.Grab(Common.reqs, banner));
                else
                    AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, banner));
            }
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<BannerSlimeAchievement>());
        }
    }

    public class BannerCorruptionAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/BannerCorruptionAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, NpcDropCondition.DropAll(Common.reqs, NPCID.None, Info.Banners["CORRUPTION"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<BannerCavernAchievement>());
        }
    }

    public class BannerCrimsonAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/BannerCrimsonAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, NpcDropCondition.DropAll(Common.reqs, NPCID.None, Info.Banners["CRIMSON"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<BannerCorruptionAchievement>());
        }
    }

    public class BannerDesertAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/BannerDesertAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, NpcDropCondition.DropAll(Common.reqs, NPCID.None, Info.Banners["DESERT"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<BannerCrimsonAchievement>());
        }
    }

    public class BannerDungeonAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/BannerDungeonAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, NpcDropCondition.DropAll(Common.reqs, NPCID.None, Info.Banners["DUNGEON"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<BannerDesertAchievement>());
        }
    }

    public class BannerGlowingMushroomAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/BannerGlowingMushroomAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, NpcDropCondition.DropAll(Common.reqs, NPCID.None, Info.Banners["GLOWING_MUSHROOM"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<BannerDungeonAchievement>());
        }
    }

    public class BannerGraniteCaveAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/BannerGraniteCaveAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, NpcDropCondition.DropAll(Common.reqs, NPCID.None, Info.Banners["GRANITE_CAVE"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<BannerGlowingMushroomAchievement>());
        }
    }

    public class BannerHallowAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/BannerHallowAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, NpcDropCondition.DropAll(Common.reqs, NPCID.None, Info.Banners["HALLOW"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<BannerGraniteCaveAchievement>());
        }
    }

    public class BannerJungleAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/BannerJungleAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, NpcDropCondition.DropAll(Common.reqs, NPCID.None, Info.Banners["JUNGLE"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<BannerHallowAchievement>());
        }
    }

    public class BannerMarbleCaveAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/BannerMarbleCaveAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, NpcDropCondition.DropAll(Common.reqs, NPCID.None, Info.Banners["MARBLE_CAVE"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<BannerJungleAchievement>());
        }
    }

    public class BannerMeteoriteAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/BannerMeteoriteAchievement";

        public override void AutoStaticDefaults() {}

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, NpcDropCondition.DropAll(Common.reqs, NPCID.None, Info.Banners["METEORITE"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<BannerMarbleCaveAchievement>());
        }
    }

    public class BannerSnowAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/BannerSnowAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, NpcDropCondition.DropAll(Common.reqs, NPCID.None, Info.Banners["SNOW"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<BannerMeteoriteAchievement>());
        }
    }

    public class BannerSpiderCaveAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/BannerSpiderCaveAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, NpcDropCondition.DropAll(Common.reqs, NPCID.None, Info.Banners["SPIDER_CAVE"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<BannerSnowAchievement>());
        }
    }

    public class BannerSurfaceAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/BannerSurfaceAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, NpcDropCondition.DropAll(Common.reqs, NPCID.None, Info.Banners["SURFACE"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<BannerSpiderCaveAchievement>());
        }
    }

    public class BannerUnderworldAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/BannerUnderworldAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, NpcDropCondition.DropAll(Common.reqs, NPCID.None, Info.Banners["UNDERWORLD"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<BannerSurfaceAchievement>());
        }
    }

    public class BannerBloodMoonAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/BannerBloodMoonAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, NpcDropCondition.DropAll(Common.reqs, NPCID.None, Info.Banners["BLOOD_MOON"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<BannerUnderworldAchievement>());
        }
    }

    public class BannerFrostLegionAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/BannerFrostLegionAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, NpcDropCondition.DropAll(Common.reqs, NPCID.None, Info.Banners["FROST_LEGION"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<BannerBloodMoonAchievement>());
        }
    }

    public class BannerFrostMoonAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/BannerFrostMoonAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, NpcDropCondition.DropAll(Common.reqs, NPCID.None, Info.Banners["FROST_MOON"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<BannerFrostLegionAchievement>());
        }
    }

    public class BannerGoblinArmyAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/BannerGoblinArmyAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, NpcDropCondition.DropAll(Common.reqs, NPCID.None, Info.Banners["GOBLIN_ARMY"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<BannerFrostMoonAchievement>());
        }
    }

    public class BannerHalloweenAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/BannerHalloweenAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, NpcDropCondition.DropAll(Common.reqs, NPCID.None, Info.Banners["HALLOWEEN"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<BannerGoblinArmyAchievement>());
        }
    }

    public class BannerLunarEventsAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/BannerLunarEventsAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, NpcDropCondition.DropAll(Common.reqs, NPCID.None, Info.Banners["LUNAR_EVENTS"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<BannerHalloweenAchievement>());
        }
    }

    public class BannerMartianMadnessAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/BannerMartianMadnessAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, NpcDropCondition.DropAll(Common.reqs, NPCID.None, Info.Banners["MARTIAN_MADNESS"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<BannerLunarEventsAchievement>());
        }
    }

    public class BannerOldOnesArmyAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/BannerOldOnesArmyAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, NpcDropCondition.DropAll(Common.reqs, NPCID.None, Info.Banners["OLD_ONES_ARMY"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<BannerMartianMadnessAchievement>());
        }
    }

    public class BannerPirateInvasionAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/BannerPirateInvasionAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, NpcDropCondition.DropAll(Common.reqs, NPCID.None, Info.Banners["PIRATE_INVASION"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<BannerOldOnesArmyAchievement>());
        }
    }

    public class BannerPumpkinMoonAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/BannerPumpkinMoonAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, NpcDropCondition.DropAll(Common.reqs, NPCID.None, Info.Banners["PUMPKIN_MOON"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<BannerPirateInvasionAchievement>());
        }
    }

    public class BannerRainBlizzardAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/BannerRainBlizzardAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, NpcDropCondition.DropAll(Common.reqs, NPCID.None, Info.Banners["RAIN_BLIZZARD"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<BannerPumpkinMoonAchievement>());
        }
    }

    public class BannerSandstormAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/BannerSandstormAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, NpcDropCondition.DropAll(Common.reqs, NPCID.None, Info.Banners["SANDSTORM"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<BannerRainBlizzardAchievement>());
        }
    }

    public class BannerSolarEclipseAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/BannerSolarEclipseAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, NpcDropCondition.DropAll(Common.reqs, NPCID.None, Info.Banners["SOLAR_ECLIPSE"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<BannerSandstormAchievement>());
        }
    }

    public class BannerWindyDayAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/BannerWindyDayAchievement";

        public override void AutoStaticDefaults() {}

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, NpcDropCondition.DropAll(Common.reqs, NPCID.None, Info.Banners["WINDY_DAY"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<BannerSolarEclipseAchievement>());
        }
    }
}
