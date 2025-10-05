using System.Collections.Generic;
using Terraria.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using TerrariaAchievementLib.Achievements;
using TerrariaAchievementLib.Achievements.Conditions;
using CompletionistAchievements.Achievements.Vanity;

namespace CompletionistAchievements.Achievements.Pet
{
    public class Info
    {
        // Verified w/ https://terraria.wiki.gg/wiki/Pets
        public static readonly Dictionary<string, int[]> Pets = new()
        {
            { "NORMAL", [ItemID.AmberMosquito, ItemID.EatersBone, ItemID.BoneRattle, ItemID.BabyGrinchMischiefWhistle, ItemID.Nectar, ItemID.HellCake, ItemID.Fish, ItemID.BambooLeaf, ItemID.BoneKey, ItemID.ToySled, ItemID.StrangeGlowingMushroom, ItemID.FullMoonSqueakyToy, ItemID.BerniePetItem, ItemID.UnluckyYarn, ItemID.BlueEgg, ItemID.GlowTulip, ItemID.ChesterPetItem, ItemID.CompanionCube, ItemID.CursedSapling, ItemID.DirtiestBlock, ItemID.BallOfFuseWire, ItemID.CelestialWand, ItemID.EyeSpring, ItemID.ExoticEasternChewToy, ItemID.BedazzledNectar, ItemID.GlommerPetItem, ItemID.DD2PetDragon, ItemID.JunimoPetItem, ItemID.BirdieRattle, ItemID.LizardEgg, ItemID.TartarSauce, ItemID.ParrotCracker, ItemID.PigPetItem, ItemID.MudBud, ItemID.DD2PetGato, ItemID.DogWhistle, ItemID.Seedling, ItemID.SpiderEgg, ItemID.OrnateShadowKey, ItemID.SharkBait, ItemID.SpiffoPlush, ItemID.MagicalPumpkinSeed, ItemID.EucaluptusSap, ItemID.TikiTotem, ItemID.Seaweed, ItemID.LightningCarrot, ItemID.ZephyrFish] },
            { "LIGHT",  [ItemID.ShadowOrb, ItemID.CrimsonHeart, ItemID.MagicLantern, ItemID.FairyBell, ItemID.DD2PetGhost, ItemID.WispinaBottle] }
        };
    }
    
    public class PetBabyDinosaurAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/PetBabyDinosaurAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemExtractCondition.Extract(Common.reqs, ItemID.AmberMosquito));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<VanityOtherAchievement>());
        }
    }

    public class PetBabyEaterAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/PetBabyEaterAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemGrabCondition.Grab(Common.reqs, ItemID.EatersBone));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<PetBabyDinosaurAchievement>());
        }
    }

    public class PetBabyFaceMonsterAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/PetBabyFaceMonsterAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemGrabCondition.Grab(Common.reqs, ItemID.BoneRattle));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<PetBabyEaterAchievement>());
        }
    }

    public class PetBabyGrinchAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/PetBabyGrinchAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.BabyGrinchMischiefWhistle));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<PetBabyFaceMonsterAchievement>());
        }
    }

    public class PetBabyHornetAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/PetBabyHornetAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemGrabCondition.Grab(Common.reqs, ItemID.Nectar));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<PetBabyGrinchAchievement>());
        }
    }

    public class PetBabySkeletronHeadAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/PetBabySkeletronHeadAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.BoneKey));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<PetBabyHornetAchievement>());
        }
    }

    public class PetBabySnowmanAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/PetBabySnowmanAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.ToySled));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<PetBabySkeletronHeadAchievement>());
        }
    }

    public class PetBlackCatAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/PetBlackCatAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemOpenCondition.Open(Common.reqs, ItemID.GoodieBag, ItemID.UnluckyYarn));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<PetBabySnowmanAchievement>());
        }
    }

    public class PetCavelingGardenerAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/PetCavelingGardenerAchievement";

        public override void AutoStaticDefaults() {}

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, Common.BreakAndGrabItem(Common.reqs, ItemID.GlowTulip));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<PetBlackCatAchievement>());
        }
    }

    public class PetTheDirtiestBlockAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/PetTheDirtiestBlockAchievement";

        public override void AutoStaticDefaults() {}

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, Common.BreakAndGrabItem(Common.reqs, ItemID.DirtiestBlock));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<PetCavelingGardenerAchievement>());
        }
    }

    public class PetJunimoAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/PetJunimoAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcGiftCondition.Gift(Common.reqs, NPCID.None, ItemID.JunimoPetItem));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<PetTheDirtiestBlockAchievement>());
        }
    }

    public class PetLizardAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/PetLizardAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.LizardEgg));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<PetJunimoAchievement>());
        }
    }

    public class PetMiniMinotaurAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/PetMiniMinotaurAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemOpenCondition.Open(Common.reqs, ItemID.None, ItemID.TartarSauce));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<PetLizardAchievement>());
        }
    }

    public class PetPuppyAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/PetPuppyAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemOpenCondition.Open(Common.reqs, ItemID.Present, ItemID.DogWhistle));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<PetMiniMinotaurAchievement>());
        }
    }

    public class PetSaplingAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/PetSaplingAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemGrabCondition.Grab(Common.reqs, ItemID.Seedling));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<PetPuppyAchievement>());
        }
    }

    public class PetSpiffoAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/PetSpiffoAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.SpiffoPlush));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<PetSaplingAchievement>());
        }
    }

    public class PetSquashlingAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/PetSquashlingAchievement";

        public override void AutoStaticDefaults() {}

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, Common.BreakAndGrabItem(Common.reqs, ItemID.MagicalPumpkinSeed));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<PetSpiffoAchievement>());
        }
    }

    public class PetSugarGliderAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/PetSugarGliderAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemShakeCondition.Shake(Common.reqs, ItemID.EucaluptusSap));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<PetSquashlingAchievement>());
        }
    }

    public class PetZephyrFishAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/PetZephyrFishAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemCatchCondition.Catch(Common.reqs, ItemID.ZephyrFish));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<PetSugarGliderAchievement>());
        }
    }

    public class PetWispAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/PetWispAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.WispinaBottle));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<PetZephyrFishAchievement>());
        }
    }

    public class PetAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/PetAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.Pets["NORMAL"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<PetWispAchievement>());
        }
    }

    public class PetLightAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/PetLightAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.Pets["LIGHT"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<PetAchievement>());
        }
    }
}
