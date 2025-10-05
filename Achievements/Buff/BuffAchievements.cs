using System.Collections.Generic;
using Terraria.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using TerrariaAchievementLib.Achievements;
using TerrariaAchievementLib.Achievements.Conditions;
using CompletionistAchievements.Achievements.Trophy;

namespace CompletionistAchievements.Achievements.Buff
{
    public class Info
    {
        // Verified w/ https://terraria.wiki.gg/wiki/Buffs
        public static readonly Dictionary<string, int[]> Buffs = new()
        {
            { "ENVIRONMENT", [BuffID.Campfire, BuffID.DryadsWard, BuffID.Sunflower, BuffID.HeartLamp, BuffID.Honey, BuffID.PeaceCandle, BuffID.StarInBottle, BuffID.CatBast, BuffID.MonsterBanner] },
            { "EQUIPMENT",   [BuffID.CoolWhipPlayerBuff, BuffID.BeetleEndurance1, BuffID.BeetleEndurance2, BuffID.BeetleEndurance3, BuffID.BeetleMight1, BuffID.BeetleMight2, BuffID.BeetleMight3, BuffID.NebulaUpDmg1, BuffID.NebulaUpDmg2, BuffID.NebulaUpDmg3, BuffID.SwordWhipPlayerBuff, BuffID.ScytheWhipPlayerBuff, BuffID.ShadowDodge, BuffID.IceBarrier, BuffID.ThornWhipPlayerBuff, BuffID.LeafCrystal, BuffID.SoulDrain, BuffID.NebulaUpLife1, BuffID.NebulaUpLife2, BuffID.NebulaUpLife3, BuffID.NebulaUpMana1, BuffID.NebulaUpMana2, BuffID.NebulaUpMana3, BuffID.Merfolk, BuffID.Panic, BuffID.RapidHealing, BuffID.TitaniumStorm, BuffID.SolarShield1, BuffID.SolarShield2, BuffID.SolarShield3, BuffID.StardustGuardianMinion, BuffID.ParryDamageBuff, BuffID.Werewolf] },
            { "FURNITURE",   [BuffID.AmmoBox, BuffID.Bewitched, BuffID.Clairvoyance, BuffID.Sharpened, BuffID.WarTable, BuffID.SugarRush] },
            { "LIGHT_PET",   [BuffID.ShadowOrb, BuffID.CrimsonHeart, BuffID.MagicLantern, BuffID.FairyBlue, BuffID.FairyGreen, BuffID.FairyRed, BuffID.PetDD2Ghost, BuffID.Wisp] },
            { "MINECART",    [BuffID.MinecartLeftWood, BuffID.MinecartRightWood, BuffID.MinecartLeft, BuffID.MinecartRight, BuffID.DesertMinecartLeft, BuffID.DesertMinecartRight, BuffID.FishMinecartLeft, BuffID.FishMinecartRight, BuffID.BeeMinecartLeft, BuffID.BeeMinecartRight, BuffID.LadybugMinecartLeft, BuffID.LadybugMinecartRight, BuffID.PigronMinecartLeft, BuffID.PigronMinecartRight, BuffID.SunflowerMinecartLeft, BuffID.SunflowerMinecartRight, BuffID.HellMinecartLeft, BuffID.HellMinecartRight, BuffID.ShroomMinecartLeft, BuffID.ShroomMinecartRight, BuffID.AmethystMinecartLeft, BuffID.AmethystMinecartRight, BuffID.TopazMinecartLeft, BuffID.TopazMinecartRight, BuffID.SapphireMinecartLeft, BuffID.SapphireMinecartRight, BuffID.EmeraldMinecartLeft, BuffID.EmeraldMinecartRight, BuffID.RubyMinecartLeft, BuffID.RubyMinecartRight, BuffID.DiamondMinecartLeft, BuffID.DiamondMinecartRight, BuffID.AmberMinecartLeft, BuffID.AmberMinecartRight, BuffID.BeetleMinecartLeft, BuffID.BeetleMinecartRight, BuffID.MeowmereMinecartLeft, BuffID.MeowmereMinecartRight, BuffID.PartyMinecartLeft, BuffID.PartyMinecartRight, BuffID.PirateMinecartLeft, BuffID.PirateMinecartRight, BuffID.SteampunkMinecartLeft, BuffID.SteampunkMinecartRight, BuffID.CoffinMinecartLeft, BuffID.CoffinMinecartRight, BuffID.DiggingMoleMinecartLeft, BuffID.DiggingMoleMinecartRight, BuffID.FartMinecartLeft, BuffID.FartMinecartRight, BuffID.TerraFartMinecartLeft, BuffID.TerraFartMinecartRight] },
            { "MOUNT",       [BuffID.SlimeMount, BuffID.BeeMount, BuffID.TurtleMount, BuffID.BunnyMount, BuffID.PogoStickMount, BuffID.GolfCartMount, BuffID.Flamingo, BuffID.PaintedHorseMount, BuffID.MajesticHorseMount, BuffID.DarkHorseMount, BuffID.LavaSharkMount, BuffID.BasiliskMount, BuffID.WolfMount, BuffID.UnicornMount, BuffID.PigronMount, BuffID.QueenSlimeMount, BuffID.Rudolph, BuffID.ScutlixMount, BuffID.UFOMount, BuffID.DrillMount] },
            { "PET",         [BuffID.BabyDinosaur, BuffID.BabyEater, BuffID.BabyFaceMonster, BuffID.BabyGrinch, BuffID.BabyHornet, BuffID.BabyImp, BuffID.BabyPenguin, BuffID.BabyRedPanda, BuffID.BabySkeletronHead, BuffID.BabySnowman, BuffID.BabyTruffle, BuffID.BabyWerewolf, BuffID.BerniePet, BuffID.BlackCat, BuffID.BlueChickenPet, BuffID.CavelingGardener, BuffID.ChesterPet, BuffID.CompanionCube, BuffID.CursedSapling, BuffID.DirtiestBlock, BuffID.DynamiteKitten, BuffID.UpbeatStar, BuffID.EyeballSpring, BuffID.FennecFox, BuffID.GlitteryButterfly, BuffID.GlommerPet, BuffID.PetDD2Dragon, BuffID.JunimoPet, BuffID.LilHarpy, BuffID.PetLizard, BuffID.MiniMinotaur, BuffID.PetParrot, BuffID.PigPet, BuffID.Plantero, BuffID.PetDD2Gato, BuffID.Puppy, BuffID.PetSapling, BuffID.PetSpider, BuffID.ShadowMimic, BuffID.SharkPup, BuffID.Spiffo, BuffID.Squashling, BuffID.SugarGlider, BuffID.TikiSpirit, BuffID.PetTurtle, BuffID.VoltBunny, BuffID.ZephyrFish] },
            { "SUMMON",      [BuffID.AbigailMinion, BuffID.BabyBird, BuffID.BabySlime, BuffID.DeadlySphere, BuffID.StormTiger, BuffID.Smolstar, BuffID.FlinxMinion, BuffID.HornetMinion, BuffID.ImpMinion, BuffID.PirateMinion, BuffID.Pygmies, BuffID.Ravens, BuffID.BatOfLight, BuffID.SharknadoMinion, BuffID.SpiderMinion, BuffID.StardustMinion, BuffID.StardustDragonMinion, BuffID.EmpressBlade, BuffID.TwinEyesMinion, BuffID.UFOMinion, BuffID.VampireFrog] },
        };
    }
    
    public class BuffEnvironmentAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/BuffEnvironmentAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, BuffAddCondition.AddAll(Common.reqs, Info.Buffs["ENVIRONMENT"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<TrophyGolfAchievement>());
        }
    }

    public class BuffEquipmentAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/BuffEquipmentAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, BuffAddCondition.AddAll(Common.reqs, Info.Buffs["EQUIPMENT"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<BuffEnvironmentAchievement>());
        }
    }

    public class BuffFurnitureAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/BuffFurnitureAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, BuffAddCondition.AddAll(Common.reqs, Info.Buffs["FURNITURE"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<BuffEquipmentAchievement>());
        }
    }

    public class BuffLightPetAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/BuffLightPetAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, BuffAddCondition.AddAll(Common.reqs, Info.Buffs["LIGHT_PET"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<BuffFurnitureAchievement>());
        }
    }

    public class BuffMinecartAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/BuffMinecartAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            // There is are left-facing and right-facing buffs for minecarts; count either
            var buffs = Info.Buffs["MINECART"];
            for (int i = 0; i < buffs.Length; i += 2)
                AddCondition(BuffAddCondition.AddAny(Common.reqs, [buffs[i], buffs[i + 1]]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<BuffLightPetAchievement>());
        }
    }

    public class BuffMountAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/BuffMountAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, BuffAddCondition.AddAll(Common.reqs, Info.Buffs["MOUNT"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<BuffMinecartAchievement>());
        }
    }

    public class BuffPetAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/BuffPetAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, BuffAddCondition.AddAll(Common.reqs, Info.Buffs["PET"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<BuffMountAchievement>());
        }
    }

    public class BuffSummonAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/BuffSummonAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, BuffAddCondition.AddAll(Common.reqs, Info.Buffs["SUMMON"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<BuffPetAchievement>());
        }
    }
}
