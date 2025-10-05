using System.Collections.Generic;
using Terraria.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using TerrariaAchievementLib.Achievements;
using TerrariaAchievementLib.Achievements.Conditions;
using CompletionistAchievements.Achievements.Ammo;

namespace CompletionistAchievements.Achievements.Tool
{
    public class Info
    {
        // Verified w/ https://terraria.wiki.gg/wiki/Tools
        public static readonly Dictionary<string, int[]> Tools = new()
        {
            { "MINE",     [ItemID.CactusPickaxe, ItemID.CopperPickaxe, ItemID.TinPickaxe, ItemID.IronPickaxe, ItemID.LeadPickaxe, ItemID.SilverPickaxe, ItemID.TungstenPickaxe, ItemID.GoldPickaxe, ItemID.CnadyCanePickaxe, ItemID.FossilPickaxe, ItemID.BonePickaxe, ItemID.PlatinumPickaxe, ItemID.ReaverShark, ItemID.NightmarePickaxe, ItemID.DeathbringerPickaxe, ItemID.MoltenPickaxe, ItemID.CobaltPickaxe, ItemID.CobaltDrill, ItemID.PalladiumPickaxe, ItemID.PalladiumDrill, ItemID.MythrilPickaxe, ItemID.MythrilDrill, ItemID.OrichalcumPickaxe, ItemID.OrichalcumDrill, ItemID.AdamantitePickaxe, ItemID.AdamantiteDrill, ItemID.TitaniumPickaxe, ItemID.TitaniumDrill, ItemID.SpectrePickaxe, ItemID.ChlorophytePickaxe, ItemID.ChlorophyteDrill, ItemID.PickaxeAxe, ItemID.Drax, ItemID.ShroomiteDiggingClaw, ItemID.Picksaw, ItemID.VortexPickaxe, ItemID.NebulaPickaxe, ItemID.SolarFlarePickaxe, ItemID.StardustPickaxe, ItemID. VortexDrill, ItemID.NebulaDrill, ItemID.SolarFlareDrill, ItemID.StardustDrill, ItemID.LaserDrill] },
            { "CHOP",     [ItemID.CopperAxe, ItemID.TinAxe, ItemID.IronAxe, ItemID.LeadAxe, ItemID.SilverAxe, ItemID.TungstenAxe, ItemID.GoldAxe, ItemID.PlatinumAxe, ItemID.CobaltWaraxe, ItemID.CobaltChainsaw, ItemID.SawtoothShark, ItemID.WarAxeoftheNight, ItemID.BloodLustCluster, ItemID.PalladiumWaraxe, ItemID.PalladiumChainsaw, ItemID.MythrilWaraxe, ItemID.MythrilChainsaw, ItemID.OrichalcumWaraxe, ItemID.OrichalcumChainsaw, ItemID.AdamantiteWaraxe, ItemID.AdamantiteChainsaw, ItemID.MeteorHamaxe, ItemID.TitaniumWaraxe, ItemID.TitaniumChainsaw, ItemID.PickaxeAxe, ItemID.Drax, ItemID.ChlorophyteGreataxe, ItemID.ChlorophyteChainsaw, ItemID.Picksaw, ItemID.ShroomiteDiggingClaw, ItemID.LucyTheAxe, ItemID.AcornAxe, ItemID.ButchersChainsaw, ItemID.MoltenHamaxe, ItemID.BloodHamaxe, ItemID.SpectreHamaxe, ItemID.LunarHamaxeSolar, ItemID.LunarHamaxeVortex, ItemID.LunarHamaxeNebula, ItemID.LunarHamaxeStardust, ItemID.TheAxe] },
            { "HAMMER",   [ItemID.WoodenHammer, ItemID.RichMahoganyHammer, ItemID.PalmWoodHammer, ItemID.BorealWoodHammer, ItemID.CopperHammer, ItemID.TinHammer, ItemID.IronHammer, ItemID.EbonwoodHammer, ItemID.ShadewoodHammer, ItemID.LeadHammer, ItemID.AshWoodHammer, ItemID.SilverHammer, ItemID.TungstenHammer, ItemID.GoldHammer, ItemID.TheBreaker, ItemID.PearlwoodHammer, ItemID.FleshGrinder, ItemID.PlatinumHammer, ItemID.MeteorHamaxe, ItemID.Rockfish, ItemID.MoltenHamaxe, ItemID.Pwnhammer, ItemID.BloodHamaxe, ItemID.Hammush, ItemID.ChlorophyteWarhammer, ItemID.ChlorophyteJackhammer, ItemID.SpectreHamaxe, ItemID.LunarHamaxeSolar, ItemID.LunarHamaxeVortex, ItemID.LunarHamaxeNebula, ItemID.LunarHamaxeStardust, ItemID.TheAxe] },
            { "WIRE",     [ItemID.Wrench, ItemID.WireCutter, ItemID.BlueWrench, ItemID.GreenWrench, ItemID.WireKite, ItemID.YellowWrench, ItemID.ActuationRod, ItemID.MulticolorWrench] },
            { "PAINT",    [ItemID.Paintbrush, ItemID.PaintRoller, ItemID.PaintScraper, ItemID.SpectrePaintbrush, ItemID.SpectrePaintRoller, ItemID.SpectrePaintScraper] },
            { "HOOK",     [ItemID.GrapplingHook, ItemID.IvyWhip, ItemID.DualHook, ItemID.WebSlinger, ItemID.AmethystHook, ItemID.TopazHook, ItemID.SapphireHook, ItemID.EmeraldHook, ItemID.RubyHook, ItemID.DiamondHook, ItemID.SkeletronHand, ItemID.BatHook, ItemID.SpookyHook, ItemID.CandyCaneHook, ItemID.ChristmasHook, ItemID.FishHook, ItemID.SlimeHook, ItemID.AntiGravityHook, ItemID.TendonHook, ItemID.ThornHook, ItemID.IlluminantHook, ItemID.WormHook, ItemID.LunarHook, ItemID.StaticHook, ItemID.AmberHook, ItemID.SquirrelHook, ItemID.QueenSlimeHook] },
            { "FISH",     [ItemID.WoodFishingPole, ItemID.ReinforcedFishingPole, ItemID.FiberglassFishingPole, ItemID.FisherofSouls, ItemID.GoldenFishingRod, ItemID.MechanicsRod, ItemID.SittingDucksFishingRod, ItemID.Fleshcatcher, ItemID.HotlineFishingHook, ItemID.BloodFishingRod, ItemID.ScarabFishingRod] },
            { "MOVEMENT", [ItemID.IceMirror, ItemID.MagicMirror, ItemID.CellPhone, ItemID.Shellphone, ItemID.Trident, ItemID.RodofDiscord, ItemID.RodOfHarmony, ItemID.PortalGun, ItemID.Umbrella, ItemID.TragicUmbrella, ItemID.MagicConch, ItemID.DemonConch, ItemID.MysticCoilSnake] },
            { "WAND",     [ItemID.LeafWand, ItemID.LivingWoodWand, ItemID.LivingMahoganyLeafWand, ItemID.LivingMahoganyWand, ItemID.HiveWand, ItemID.BoneWand] },
            { "OTHER",    [ItemID.EmptyBucket, ItemID.BottomlessBucket, ItemID.BottomlessLavaBucket, ItemID.BottomlessHoneyBucket, ItemID.BottomlessShimmerBucket, ItemID.SuperAbsorbantSponge, ItemID.LavaAbsorbantSponge, ItemID.HoneyAbsorbantSponge, ItemID.UltraAbsorbantSponge, ItemID.BugNet, ItemID.GoldenBugNet, ItemID.FireproofBugNet, ItemID.Sickle, ItemID.StaffofRegrowth, ItemID.Clentaminator, ItemID.Clentaminator2, ItemID.BreathingReed, ItemID.Binoculars, ItemID.GolfClubStoneIron, ItemID.GolfClubIron, ItemID.GolfClubMythrilIron, ItemID.GolfClubTitaniumIron, ItemID.GolfClubWoodDriver, ItemID.GolfClubDriver, ItemID.GolfClubPearlwoodDriver, ItemID.GolfClubChlorophyteDriver, ItemID.GolfClubBronzeWedge, ItemID.GolfClubWedge, ItemID.GolfClubGoldWedge, ItemID.GolfClubDiamondWedge, ItemID.GolfClubRustyPutter, ItemID.GolfClubPutter, ItemID.GolfClubLeadPutter, ItemID.GolfClubShroomitePutter, ItemID.GolfWhistle, ItemID.GoldenKey, ItemID.ShadowKey, ItemID.TempleKey, ItemID.JungleKey, ItemID.FrozenKey, ItemID.HallowedKey, ItemID.CorruptionKey, ItemID.CrimsonKey, ItemID.DungeonDesertKey, ItemID.LightKey, ItemID.NightKey, ItemID.DontHurtCrittersBook, ItemID.DontHurtNatureBook, ItemID.DontHurtComboBook, ItemID.ChumBucket, ItemID.GravediggerShovel, ItemID.EncumberingStone, ItemID.LawnMower, ItemID.RubblemakerSmall, ItemID.RubblemakerMedium, ItemID.RubblemakerLarge, ItemID.SandcastleBucket, ItemID.IceRod, ItemID.DirtRod, ItemID.FlareGun] }
        };
    }
    
    public class ToolBonePickaxeAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/ToolBonePickaxeAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.BonePickaxe));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<AmmoSolutionAchievement>());
        }
    }

    public class ToolTheAxeAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/ToolTheAxeAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemGrabCondition.Grab(Common.reqs, ItemID.TheAxe));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<ToolBonePickaxeAchievement>());
        }
    }

    public class ToolBatHookAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/ToolBatHookAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemOpenCondition.Open(Common.reqs, ItemID.GoodieBag, ItemID.BatHook));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<ToolTheAxeAchievement>());
        }
    }

    public class ToolFishHookAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/ToolFishHookAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcGiftCondition.Gift(Common.reqs, NPCID.Angler, ItemID.FishHook));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<ToolBatHookAchievement>());
        }
    }

    public class ToolHotlineFishingHookAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/ToolHotlineFishingHookAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcGiftCondition.Gift(Common.reqs, NPCID.Angler, ItemID.HotlineFishingHook));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<ToolFishHookAchievement>());
        }
    }

    public class ToolDemonConchAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/ToolDemonConchAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemCatchCondition.Catch(Common.reqs, ItemID.DemonConch));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<ToolHotlineFishingHookAchievement>());
        }
    }

    public class ToolRodOfDiscordAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/ToolRodOfDiscordAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.RodofDiscord));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<ToolDemonConchAchievement>());
        }
    }

    public class ToolBoneWandAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/ToolBoneWandAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.BoneWand));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<ToolRodOfDiscordAchievement>());
        }
    }

    public class ToolBottomlessLavaBucketAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/ToolBottomlessLavaBucketAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemCatchCondition.Catch(Common.reqs, ItemID.BottomlessLavaBucket));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<ToolBoneWandAchievement>());
        }
    }

    public class ToolSuperAbsorbantSpongeAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/ToolSuperAbsorbantSpongeAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcGiftCondition.Gift(Common.reqs, NPCID.Angler, ItemID.SuperAbsorbantSponge));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<ToolBottomlessLavaBucketAchievement>());
        }
    }

    public class ToolLavaAbsorbantSpongeAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/ToolLavaAbsorbantSpongeAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemCatchCondition.Catch(Common.reqs, ItemID.LavaAbsorbantSponge));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<ToolSuperAbsorbantSpongeAchievement>());
        }
    }

    public class ToolGoldenBugNetAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/ToolGoldenBugNetAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcGiftCondition.Gift(Common.reqs, NPCID.Angler, ItemID.GoldenBugNet));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<ToolLavaAbsorbantSpongeAchievement>());
        }
    }

    public class ToolBinocularsAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/ToolBinocularsAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemGrabCondition.Grab(Common.reqs, ItemID.Binoculars));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<ToolGoldenBugNetAchievement>());
        }
    }

    public class ToolJungleKeyAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/ToolJungleKeyAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.JungleKey));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<ToolBinocularsAchievement>());
        }
    }

    public class ToolFrozenKeyAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/ToolFrozenKeyAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.FrozenKey));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<ToolJungleKeyAchievement>());
        }
    }

    public class ToolHallowedKeyAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/ToolHallowedKeyAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.HallowedKey));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<ToolFrozenKeyAchievement>());
        }
    }

    public class ToolCorruptionKeyAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/ToolCorruptionKeyAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.CorruptionKey));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<ToolHallowedKeyAchievement>());
        }
    }

    public class ToolCrimsonKeyAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/ToolCrimsonKeyAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.CrimsonKey));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<ToolCorruptionKeyAchievement>());
        }
    }

    public class ToolDesertKeyAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/ToolDesertKeyAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.DungeonDesertKey));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<ToolCrimsonKeyAchievement>());
        }
    }

    public class ToolMineAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/ToolMineAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.Tools["MINE"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<ToolDesertKeyAchievement>());
        }
    }

    public class ToolChopAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/ToolChopAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.Tools["CHOP"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<ToolMineAchievement>());
        }
    }

    public class ToolHammerAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/ToolHammerAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.Tools["HAMMER"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<ToolChopAchievement>());
        }
    }

    public class ToolWireAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/ToolWireAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.Tools["WIRE"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<ToolHammerAchievement>());
        }
    }

    public class ToolPaintAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/ToolPaintAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.Tools["PAINT"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<ToolWireAchievement>());
        }
    }

    public class ToolHookAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/ToolHookAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.Tools["HOOK"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<ToolPaintAchievement>());
        }
    }

    public class ToolFishAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/ToolFishAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.Tools["FISH"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<ToolHookAchievement>());
        }
    }

    public class ToolMovementAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/ToolMovementAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.Tools["MOVEMENT"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<ToolFishAchievement>());
        }
    }

    public class ToolWandAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/ToolWandAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.Tools["WAND"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<ToolMovementAchievement>());
        }
    }

    public class ToolOtherAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/ToolOtherAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.Tools["OTHER"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<ToolWandAchievement>());
        }
    }
}
