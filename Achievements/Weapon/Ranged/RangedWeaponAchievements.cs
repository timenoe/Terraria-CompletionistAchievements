using System.Collections.Generic;
using Terraria.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using TerrariaAchievementLib.Achievements;
using TerrariaAchievementLib.Achievements.Conditions;
using CompletionistAchievements.Achievements.Weapon.Melee;

namespace CompletionistAchievements.Achievements.Weapon.Ranged
{
    public class Info
    {
        // Verified w/ https://terraria.wiki.gg/wiki/Weapons
        public static readonly Dictionary<string, int[]> RangedWeapons = new()
        {
            { "BOW",      [ItemID.WoodenBow, ItemID.BorealWoodBow, ItemID.CopperBow, ItemID.PalmWoodBow, ItemID.RichMahoganyBow, ItemID.TinBow, ItemID.EbonwoodBow, ItemID.IronBow, ItemID.ShadewoodBow, ItemID.LeadBow, ItemID.SilverBow, ItemID.TungstenBow, ItemID.AshWoodBow, ItemID.GoldBow, ItemID.PlatinumBow, ItemID.DemonBow, ItemID.TendonBow, ItemID.BloodRainBow, ItemID.BeesKnees, ItemID.HellwingBow, ItemID.MoltenFury, ItemID.PearlwoodBow, ItemID.Marrow, ItemID.IceBow, ItemID.DaedalusStormbow, ItemID.ShadowFlameBow, ItemID.DD2PhoenixBow, ItemID.PulseBow, ItemID.DD2BetsyBow, ItemID.Tsunami, ItemID.FairyQueenRangedItem, ItemID.Phantasm] },
            { "REPEATER", [ItemID.CobaltRepeater, ItemID.PalladiumRepeater, ItemID.MythrilRepeater, ItemID.OrichalcumRepeater, ItemID.AdamantiteRepeater, ItemID.TitaniumRepeater, ItemID.HallowedRepeater, ItemID.ChlorophyteShotbow, ItemID.StakeLauncher] },
            { "GUN",      [ItemID.RedRyder, ItemID.FlintlockPistol, ItemID.Musket, ItemID.TheUndertaker, ItemID.Revolver, ItemID.Minishark, ItemID.Boomstick, ItemID.QuadBarrelShotgun, ItemID.Handgun, ItemID.PhoenixBlaster, ItemID.PewMaticHorn, ItemID.ClockworkAssaultRifle, ItemID.Gatligator, ItemID.Shotgun, ItemID.OnyxBlaster, ItemID.Uzi, ItemID.Megashark, ItemID.VenusMagnum, ItemID.TacticalShotgun, ItemID.SniperRifle, ItemID.CandyCornRifle, ItemID.ChainGun, ItemID.Xenopopper, ItemID.VortexBeater, ItemID.SDMG] },
            { "LAUNCHER", [ItemID.GrenadeLauncher, ItemID.ProximityMineLauncher, ItemID.RocketLauncher, ItemID.NailGun, ItemID.Stynger, ItemID.JackOLanternLauncher, ItemID.SnowballCannon, ItemID.FireworksLauncher, ItemID.ElectrosphereLauncher, ItemID.Celeb2] },
            { "OTHER",    [ItemID.Blowpipe, ItemID.Sandgun, ItemID.Blowgun, ItemID.SnowballCannon, ItemID.PainterPaintballGun, ItemID.AleThrowingGlove, ItemID.Harpoon, ItemID.StarCannon, ItemID.Toxikarp, ItemID.DartPistol, ItemID.DartRifle, ItemID.CoinGun, ItemID.Flamethrower, ItemID.PiranhaGun, ItemID.ElfMelter, ItemID.SuperStarCannon] }
        };
    }

    public class WeaponBloodRainBowAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponBloodRainBowAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.BloodRainBow));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponMeleeOtherAchievement>());
        }
    }

    public class WeaponMarrowAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponMarrowAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.Marrow));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponBloodRainBowAchievement>());
        }
    }

    public class WeaponRedRyderAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponRedRyderAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemOpenCondition.Open(Common.reqs, ItemID.Present, ItemID.RedRyder));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponMarrowAchievement>());
        }
    }

    public class WeaponUziAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponUziAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.Uzi));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponRedRyderAchievement>());
        }
    }

    public class WeaponAleTosserAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponAleTosserAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemGrabCondition.Grab(Common.reqs, ItemID.AleThrowingGlove));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponUziAchievement>());
        }
    }

    public class WeaponPaintballGunAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponPaintballGunAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemGrabCondition.Grab(Common.reqs, ItemID.PainterPaintballGun));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponAleTosserAchievement>());
        }
    }

    public class WeaponCoinGunAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponCoinGunAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(NpcDropCondition.Drop(Common.reqs, NPCID.None, ItemID.CoinGun));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponPaintballGunAchievement>());
        }
    }

    public class WeaponToxikarpAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponToxikarpAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            AddCondition(ItemCatchCondition.Catch(Common.reqs, ItemID.Toxikarp));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponCoinGunAchievement>());
        }
    }

    public class WeaponRangedBowAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponRangedBowAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.RangedWeapons["BOW"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponToxikarpAchievement>());
        }
    }

    public class WeaponRangedRepeaterAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponRangedRepeaterAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.RangedWeapons["REPEATER"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponRangedBowAchievement>());
        }
    }

    public class WeaponRangedGunAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponRangedGunAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.RangedWeapons["GUN"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponRangedRepeaterAchievement>());
        }
    }

    public class WeaponRangedLauncherAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponRangedLauncherAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.RangedWeapons["LAUNCHER"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponRangedGunAchievement>());
        }
    }

    public class WeaponRangedOtherAchievement : ModAchievement
    {
        public override string TextureName => "CompletionistAchievements/Assets/WeaponRangedOtherAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            ConditionHelper.AddConditions(this, ItemGrabCondition.GrabAll(Common.reqs, Info.RangedWeapons["OTHER"]));
        }

        public override IEnumerable<Position> GetModdedConstraints()
        {
            yield return new After(ModContent.GetInstance<WeaponRangedLauncherAchievement>());
        }
    }
}
