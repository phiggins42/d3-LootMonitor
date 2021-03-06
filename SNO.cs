﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;

namespace LootAlert
{
    class SNO
    {
        public const int MonsterSNO = 0x0157F838; //15DBE00
        public const int StringListSNO = 0x1588278; //15E8808
        public const int ActorSNO = 0x158FB40; //15EC108
        public const int PowerSNO = 0x158D858; //15E7E20
        public const int GameBalanceSNO = 0x1548FB8; //15A6008
        public const int SceneSNO = 0x1595BC8; //15F2190
        public const int SceneGroupSNO = 0x015E4348; //15E4348
        public const int WorldsSNO = 0x1591510; //15EDAD8

        public const int defptr = 0x3C;
        public const int defcount = 0x10C;
        public const int deflink = 0x148;

        public static List<Point> IndexSNO(int offset)
        {
            List<Point> list = new List<Point>();

            int ptr = d3.ReadInt(d3.ReadInt(offset) + defptr);
            int count = d3.ReadInt(ptr + defcount);
            int curOff = d3.ReadInt(ptr + deflink) + 0xC;

            for (int i = 0; i <= 4096; i++)
            {
                int curSNOoff = d3.ReadInt(curOff);
                int curSNOid = d3.ReadInt(curSNOoff);

                if (curSNOoff == 0 && curSNOid == 0)
                    break;

                list.Add(new Point(curSNOoff, curSNOid));

                curOff += 0x10;
            }
            return list;
        }

        public static void test()
        {
            IndexSNO(GameBalanceSNO, true);
        }

        public static int GetOffsetFromSNOID(int snoid, int snogroup)
        {
            List<Point> list = IndexSNO(snogroup);

            foreach (Point p in list)
            {
                if (p.Y == snoid)
                    return p.X;
            }

            return -1;
        }
    }

    public enum PowerID : int
    {
        None = -1,
        AI_FollowWithWalk = 1728,
        AI_Wander = 1729,
        Barrel_Explode_Instant = 1736,
        CryptChildEat = 1738,
        Templar_Heal = 1747,
        Scavenger_Leap = 1752,
        UseItem = 1759,
        Wizard_Electrocute = 1765,
        Wizard_SlowTime = 1769,
        ZombieKillerGrab = 1771,
        AI_Circle = 29986,
        AI_Circle_Long = 29987,
        AI_Close = 29990,
        AI_Close_Long = 29991,
        AI_Follow = 29993,
        AI_FollowPath = 29994,
        AI_Follow_Close = 29995,
        AI_Idle = 29996,
        AI_Idle_Long = 29997,
        AI_Idle_Short = 29998,
        AI_ReturnToPath = 30000,
        AI_RunAway = 30001,
        AI_RunAway_Long = 30002,
        AI_RunAway_Short = 30003,
        AI_RunInFront = 30004,
        AI_RunNearby = 30005,
        AI_RunNearby_Short = 30008,
        AI_RunTo = 30009,
        AI_WalkTo = 30013,
        AI_WanderRun = 30014,
        AI_Wander_Long = 30015,
        Axe_Bad_Data = 30020,
        Axe_Operate_Gizmo = 30021,
        Axe_Operate_NPC = 30022,
        Trait_Barbarian_Fury = 30078,
        Barbarian_GroundStompEffect = 30080,
        BareHandedPassive = 30145,
        BeastCharge = 30147,
        BurrowOut = 30157,
        BurrowStartBuff = 30158,
        ChampionClone = 30166,
        ChampionTeleport = 30167,
        Cooldown = 30176,
        CorpulentExplode = 30178,
        CritDebuffCold = 30180,
        CryptChildLeapOut = 30185,
        CryptChildLeapOutBuff = 30186,
        DebuffChilled = 30195,
        DestructableObjectChandelier_AOE = 30209,
        DrinkHealthPotion = 30211,
        EatCorpse = 30214,
        GenericArrow_Projectile = 30242,
        Ghost_Melee_Drain = 30243,
        Ghost_SoulSiphon = 30244,
        GizmoOperatePortalWithAnimation = 30249,
        Goatman_Lightning_Shield = 30251,
        Goatman_Moonclan_Ranged_Projectile = 30252,
        GraveDigger_Knockback_Attack = 30255,
        GraveRobber_Dodge_Left = 30256,
        GraveRobber_Dodge_Right = 30257,
        graveRobber_Projectile = 30258,
        HealingWell_Heal = 30264,
        Hearth = 30265,
        Hearth_Finish = 30266,
        ImmuneToFearDuringBuff = 30283,
        ImmuneToRootDuringBuff = 30284,
        ImmuneToSnareDuringBuff = 30285,
        ImmuneToStunDuringBuff = 30286,
        Interact_Crouching = 30287,
        Interact_Normal = 30288,
        InvisibileDuringBuff = 30289,
        InvulnerableDuringBuff = 30290,
        Knockdown = 30296,
        Laugh = 30307,
        MagicPainting_Summon_Skeleton = 30313,
        Monster_Ranged_Projectile = 30334,
        Monster_Spell_Projectile = 30338,
        NPC_LookAt = 30342,
        OnDeathArcane = 30343,
        OnDeathCold = 30344,
        OnDeathFire = 30345,
        OnDeathLightning = 30346,
        OnDeathPoison = 30347,
        Operate_Helper_Attach = 30348,
        Templar_Inspire = 30356,
        Templar_Loyalty = 30357,
        Templar_Guardian = 30359,
        Templar_ShieldCharge = 30360,
        Proxy_Delayed_Power = 30385,
        Punch = 30391,
        RangedEscort_Projectile = 30394,
        Resurrection_Buff = 30424,
        Rockworm_Web = 30431,
        RootTryGrab = 30433,
        SandsharkBurrowIn = 30440,
        ScavengerBurrowIn = 30450,
        ScavengerBurrowOut = 30451,
        Scoundrel_Anatomy = 30454,
        Scoundrel_Bandage = 30455,
        Scoundrel_Multishot = 30458,
        Scoundrel_PoisonArrow = 30460,
        Scoundrel_Vanish = 30464,
        ScrollBuff = 30469,
        SetMode_EscortFollow = 30471,
        ShieldSkeleton_Shield = 30473,
        Shield_Skeleton_Melee_Instant = 30474,
        Shrine_Desecrated_Blessed = 30476,
        Shrine_Desecrated_Enlightened = 30477,
        Shrine_Desecrated_Fortune = 30478,
        Shrine_Desecrated_Frenzied = 30479,
        SkeletonArcher_Projectile = 30495,
        SkeletonKing_Summon_Skeleton = 30496,
        skeletonMage_poison_death = 30501,
        SkeletonSummoner_Projectile = 30503,
        SkeletonKing_Cleave = 30504,
        SnakemanCaster_ElectricBurst = 30509,
        Snakeman_MeleeStealth = 30512,
        Snakeman_MeleeUnstealth = 30513,
        SporeCloud = 30525,
        StealthBuff = 30527,
        StitchExplode = 30529,
        StitchMeleeAlternate = 30530,
        StitchPush = 30531,
        Suicide_Proc = 30538,
        Summoned = 30540,
        Summon_Skeleton = 30543,
        Summon_Skeleton_OnSpawn = 30545,
        Summon_Skeleton_Orb = 30546,
        Summon_Triune_Demon = 30547,
        Summon_Zombie_Crawler = 30550,
        Thorns = 30554,
        TransformToActivatedTriune = 30563,
        TriuneBerserker_Hit = 30567,
        TriuneSummoner_Projectile = 30570,
        TriuneSummoner_Shield = 30571,
        TriuneSummoner_SplitSummonCast = 30572,
        TriuneVesselCharge = 30573,
        TriuneVesselOverpower = 30574,
        Unburied_Knockback = 30580,
        Unburied_Melee_Attack = 30581,
        UntargetableDuringBuff = 30582,
        UseHealthGlyph = 30584,
        UseManaGlyph = 30585,
        Walk = 30588,
        Warp = 30589,
        Weapon_Melee_Instant = 30592,
        Weapon_Melee_Instant_BothHand = 30593,
        Weapon_Melee_Instant_OffHand = 30594,
        Weapon_Melee_Obstruction = 30595,
        Weapon_Melee_Reach_Instant = 30596,
        Weapon_Ranged_Instant = 30598,
        Weapon_Ranged_Projectile = 30599,
        Weapon_Ranged_Wand = 30601,
        Witchdoctor_Gargantuan = 30624,
        Witchdoctor_Hex = 30631,
        Wizard_ArcaneOrb = 30668,
        Wizard_Blizzard = 30680,
        Wizard_EnergyShield = 30708,
        Wizard_FrostNova = 30718,
        Wizard_Hydra = 30725,
        Wizard_MagicMissile = 30744,
        Wizard_ShockPulse = 30783,
        Wizard_WaveOfForce = 30796,
        WoodWraithSummonSpores = 30800,
        Trait_Monk_Spirit = 52753,
        TreasureGoblinPause = 54055,
        TreasureGoblin_ThrowPortal = 54836,
        AI_Orbit = 55433,
        Generic_Taunt = 60777,
        Generic_SetUntargetable = 62666,
        Generic_SetInvulnerable = 62731,
        TarPitSlowOn = 67106,
        Witchdoctor_Firebomb = 67567,
        Witchdoctor_MassConfusion = 67600,
        Witchdoctor_SoulHarvest = 67616,
        Witchdoctor_Horrify = 67668,
        Monk_BreathOfHeaven = 69130,
        Witchdoctor_GraspOfTheDead = 69182,
        Wizard_Meteor = 69190,
        Monk_MantraOfRetribution = 69484,
        Monk_ResistAura = 69489,
        Monk_MantraOfHealing = 69490,
        Witchdoctor_CorpseSpider = 69866,
        Witchdoctor_Locust_Swarm = 69867,
        BurrowInSetup = 69949,
        Barbarian_AncientSpear = 69979,
        Weapon_Melee_NoClose = 70218,
        MonsterAffix_Vampiric = 70309,
        Knockback = 70432,
        Witchdoctor_AcidCloud = 70455,
        Barbarian_Rend = 70472,
        MonsterAffix_ExtraHealth = 70650,
        MonsterAffix_Knockback = 70655,
        MonsterAffix_Fast = 70849,
        MonsterAffix_Shaman = 70959,
        MonsterAffix_Puppetmaster = 71023,
        MonsterAffix_Puppetmaster_Minion = 71024,
        MonsterAffix_Illusionist = 71108,
        MonsterAffix_Healthlink = 71239,
        Wizard_SpectralBlade = 71548,
        Brickhouse_Enrage = 72713,
        Witchdoctor_FetishArmy = 72785,
        Wizard_IceArmor = 73223,
        HelperArcherProjectile = 73289,
        SkeletonKing_Whirlwind = 73824,
        Witchdoctor_ZombieCharger = 74003,
        Wizard_StormArmor = 74499,
        BurrowOut_NoFacing = 75226,
        DemonHunter_SpikeTrap = 75301,
        Wizard_DiamondSkin = 75599,
        DemonHunter_EntanglingShot = 75873,
        Generic_SetInvisible = 76107,
        Wizard_MagicWeapon = 76108,
        Spider_Web_Slow = 76961,
        Wizard_Hydra_RuneLightning_Prototype = 77065,
        Wizard_Hydra_RuneAcid_Prototype = 77066,
        Wizard_Hydra_RuneArcane_Prototype = 77067,
        Wizard_Hydra_DefaultFire_Prototype = 77068,
        Wizard_EnergyTwister = 77113,
        Goatman_Shaman_Lightningbolt = 77342,
        DemonHunter_FanOfKnives = 77546,
        DemonHunter_BolaShot = 77552,
        DemonHunter_Multishot = 77649,
        Barbarian_Frenzy = 78548,
        Barbarian_Sprint = 78551,
        Barbarian_BattleRage = 79076,
        Barbarian_ThreateningShout = 79077,
        Barbarian_Bash = 79242,
        SkeletonKing_Teleport = 79334,
        Barbarian_GroundStomp = 79446,
        UninterruptibleDuringBuff = 79486,
        Barbarian_IgnorePain = 79528,
        Barbarian_WrathOfTheBerserker = 79607,
        Barbarian_HammerOfTheAncients = 80028,
        Barbarian_CallOfTheAncients = 80049,
        Barbarian_Cleave = 80263,
        MonsterAffix_Electrified = 81420,
        SkeletonKing_Teleport_Away = 81504,
        Barbarian_WarCry = 81612,
        Wizard_Hydra_RuneFrost_Prototype = 83040,
        Witchdoctor_Haunt = 83602,
        Wizard_Hydra_RuneBig_Prototype = 84030,
        Enchantress_Cripple = 84469,
        Laugh_SkeletonKing = 84699,
        g_levelUp = 85954,
        DamageAttribute = 86152,
        EscortingBuff = 86241,
        DemonHunter_Grenades = 86610,
        Barbarian_SeismicSlam = 86989,
        Wizard_EnergyArmor = 86991,
        Hireling_Callout_BattleCry = 87093,
        SkeletonKing_KillSummonedSkeletons = 87523,
        Wizard_ExplosiveBlast = 87525,
        MonsterAffix_Frozen = 90144,
        MonsterAffix_Molten = 90314,
        MonsterAffix_Plagued = 90566,
        MonsterAffix_MissileDampening = 91028,
        CopiedVisualEffectsBuff = 91052,
        MonsterAffix_Ballista = 91098,
        CalldownGrenade = 91155,
        MonsterAffix_DieTogether = 91232,
        trout_tristramfields_punji_trap_aoe = 91261,
        Wizard_Disintegrate = 91549,
        Wizard_RayOfFrost = 93395,
        Barbarian_Leap = 93409,
        ActorDisabledBuff = 93716,
        Leah_Vortex = 93831,
        Barbarian_WeaponThrow = 93885,
        Templar_Onslaught = 93888,
        Templar_Intimidate = 93901,
        Templar_Intervene = 93938,
        Templar_Intervene_Proc = 94008,
        Summon_Zombie_Vomit = 94734,
        Ghost_A_Unique_House1000Undead_Slow = 94972,
        trout_tristramfields_punji_trap_mirror_aoe = 95387,
        Monk_MantraOfConviction = 95572,
        Scoundrel_CripplingShot = 95675,
        Scoundrel_PowerShot = 95690,
        DOTDebuff = 95701,
        Monk_FistsofThunder = 95940,
        Monk_DeadlyReach = 96019,
        Monk_WaveOfLight = 96033,
        Monk_SweepingWind = 96090,
        Monk_DashingStrike = 96203,
        Monk_Serenity = 96215,
        Barbarian_Whirlwind = 96296,
        Monk_CripplingWave = 96311,
        Monk_SevenSidedStrike = 96694,
        Monk_WayOfTheHundredFists = 97110,
        Monk_InnerSanctuary = 97222,
        Monk_ExplodingPalm = 97328,
        Barbarian_FuriousCharge = 97435,
        Scoundrel_DirtyFighting = 97436,
        GoatmanDrumsBeating = 97497,
        Wizard_MirrorImage = 98027,
        Barbarian_Earthquake = 98878,
        Goatman_Iceball = 99077,
        GhostWalkThroughWalls = 99094,
        Wizard_Familiar = 99120,
        AIEvadeBuff = 99543,
        Scoundrel_Ranged_Projectile = 99902,
        Scoundrel_RunAway = 99904,
        trOut_LogStack_Trap = 100287,
        DebuffSlowed = 100971,
        DebuffStunned = 101000,
        DebuffFeared = 101002,
        DebuffRooted = 101003,
        Enchantress_FocusedMind = 101425,
        Enchantress_PoweredArmor = 101461,
        Enchantress_ReflectMissiles_Proc = 101867,
        Enchantress_ForcefulPush = 101969,
        Enchantress_Disorient = 101990,
        Enchantress_Charm = 102057,
        Enchantress_ReflectMissiles = 102133,
        Cain_Intro_Swing = 102449,
        Witchdoctor_Sacrifice = 102572,
        Witchdoctor_SummonZombieDog = 102573,
        Witchdoctor_PoisonDart = 103181,
        DebuffBlind = 103216,
        Quest_CanyonBridge_Player_RevealFootsteps = 103337,
        Quest_CanyonBridge_Enchantress_RevealFootsteps = 103338,
        AI_Follow_MeleeLead = 104514,
        TreasureGoblin_Escape = 105371,
        TreasureGoblin_ThrowPortal_Fast = 105665,
        Witchdoctor_Firebats = 105963,
        Witchdoctor_SpiritWalk = 106237,
        AncientSpearKnockback = 106281,
        Witchdoctor_PlagueOfToads = 106465,
        Witchdoctor_PlagueOfToads_BigToadAttack = 106592,
        Witchdoctor_CorpseSpider_Leap = 107103,
        Witchdoctor_Hex_Fetish = 107301,
        QuillDemon_Projectile = 107729,
        Witchdoctor_Hex_Fetish_Heal = 107742,
        Witchdoctor_SpiritBarrage = 108506,
        Beast_Weapon_Melee_Instant = 109289,
        Barbarian_Revenge = 109342,
        Barbarian_Revenge_Buff = 109344,
        Trait_Witchdoctor_ZombieDogSpawner_Passive = 109560,
        MonsterAffix_Electrified_Minion = 109899,
        ZombieFemale_Projectile = 110518,
        DemonHunter_Vault = 111215,
        Monk_LashingTailKick = 111676,
        Weapon_Melee_Reach_Instant_Freeze_Facing = 115624,
        Hireling_Callout_BattleFinished = 117323,
        Witchdoctor_BigBadVoodoo = 117402,
        Summoning_Machine_Summon = 117580,
        HellPortalSummoningMachineActivate = 118226,
        Witchdoctor_FetishArmy_Shaman = 118442,
        Witchdoctor_FetishArmy_Hunter = 119166,
        MonsterAffix_VortexCast = 120305,
        MonsterAffix_VortexBuff = 120306,
        MonsterAffix_Pheonix = 120655,
        Monk_TempestRush = 121442,
        Witchdoctor_Gargantuan_Cleave = 121942,
        Witchdoctor_Gargantuan_Slam = 121943,
        UnholyShield = 122977,
        SetItemBonusBuff = 123014,
        Goatman_Cold_Shield = 123158,
        Monk_MysticAlly = 123208,
        Frenzy_Affix = 123843,
        DemonHunter_Preparation = 129212,
        DemonHunter_Chakram = 129213,
        DemonHunter_ClusterArrow = 129214,
        DemonHunter_HungeringArrow = 129215,
        DemonHunter_Caltrops = 129216,
        DemonHunter_Sentry = 129217,
        Generic_SetCannotBeAddedToAITargetList = 129386,
        Generic_SetObserver = 129393,
        Generic_SetTakesNoDamage = 129394,
        Generic_SetDoesFakeDamage = 129395,
        DemonHunter_Sentry_TurretAttack = 129661,
        DemonHunter_SmokeScreen = 130695,
        DemonHunter_MarkedForDeath = 130738,
        DemonFlyer_Projectile = 130798,
        DemonHunter_ShadowPower = 130830,
        DemonHunter_RainOfVengeance = 130831,
        DemonHunter_RapidFire = 131192,
        BodyGuard_Teleport = 131193,
        DemonHunter_ElementalArrow = 131325,
        DemonHunter_Impale = 131366,
        GoatMutantEnrage = 131588,
        GoatMutantGroundSmash = 131699,
        PickupNearby = 131976,
        Charmed_Weapon_Melee_Instant = 132695,
        Charmed_Monster_Ranged_Projectile = 132698,
        WarpInMagical = 132910,
        DemonHunter_Companion = 133695,
        DH_Companion_ChargeAttack = 133887,
        DemonHunter_Strafe = 134030,
        DemonHunter_EvasiveFire = 134209,
        Callout_Cooldown = 134225,
        DemonHunter_EvasiveFire_Flip = 134280,
        Banter_Cooldown = 134334,
        Wizard_ArcaneTorrent = 134456,
        CoreElite_DropPod = 134816,
        Witchdoctor_WallOfZombies = 134837,
        Wizard_Archon = 134872,
        Wizard_Archon_ArcaneStrike = 135166,
        Wizard_Archon_DisintegrationWave = 135238,
        Wizard_Archon_SlowTime = 135663,
        Monk_BlindingFlash = 136954,
        Monk_ResistAura_RuneC_Fire = 143382,
        Monk_ResistAura_RuneC_Lightning = 144188,
        Monk_ResistAura_RuneC_Cold = 144197,
        Monk_ResistAura_RuneC_Poison = 144202,
        MastaBlasta_Steed_Combine = 144289,
        Monk_ResistAura_RuneC_Arcane = 144312,
        Monk_ResistAura_RuneC_Holy = 144322,
        PlagueOfToadsKnockback = 147876,
        DH_rainofArrows_shadowBeast_bombDrop = 150075,
        Camera_Focus_Buff = 151595,
        Camera_Focus_Pet_Buff = 151604,
        Unique_Monster_Generic_Projectile = 152540,
        DemonHunter_Passive_Vengeance = 155714,
        DemonHunter_Passive_Sharpshooter = 155715,
        DemonHunter_Passive_CullTheWeak = 155721,
        DemonHunter_Passive_Perfectionist = 155722,
        DemonHunter_Passive_Ballistics = 155723,
        DemonHunter_Passive_HotPursuit = 155725,
        MonsterAffix_TeleporterBuff = 155958,
        MonsterAffix_TeleporterCast = 155959,
        MonsterAffix_DesecratorCast = 156105,
        MonsterAffix_DesecratorBuff = 156106,
        Monk_Passive_ChantOfResonance = 156467,
        Monk_Passive_NearDeathExperience = 156484,
        Monk_Passive_GuidingLight = 156492,
        Barbarian_Overpower = 159169,
        AI_WalkTo_Guaranteed = 163333,
        AI_WalkInFront_Guaranteed = 163334,
        AI_SprintTo_Guaranteed = 163335,
        AI_SprintInFront_Guaranteed = 163336,
        AI_RunTo_Guaranteed = 163338,
        AI_RunInFront_Guaranteed = 163339,
        DemonHunter_Passive_SteadyAim = 164363,
        UseArcaneGlyph = 165553,
        Wizard_ArcaneTorrent_RuneC_Mine = 165598,
        Wizard_Archon_Cancel = 166616,
        Wizard_Archon_ArcaneBlast = 167355,
        Wizard_Archon_Teleport = 167648,
        Summon_Skeleton_Jondar = 168212,
        Wizard_Teleport = 168344,
        Barbarian_CallOfTheAncients_Cleave = 168823,
        Barbarian_CallOfTheAncients_FuriousCharge = 168824,
        Barbarian_CallOfTheAncients_Leap = 168825,
        Barbarian_CallOfTheAncients_SeismicSlam = 168827,
        Barbarian_CallOfTheAncients_WeaponThrow = 168828,
        Barbarian_CallOfTheAncients_Whirlwind = 168830,
        Monk_MysticAlly_Pet_Weapon_Melee_Instant = 169081,
        Monk_MysticAlly_Pet_RuneA_Kick = 169155,
        Monk_MysticAlly_Pet_RuneB_WaveAttack = 169325,
        Monk_MysticAlly_Pet_RuneC_GroundPunch = 169715,
        Monk_MysticAlly_Pet_RuneD_AOEAttack = 169728,
        a2dun_Cave_Goatmen_Dropping_Log_Trap_attack = 175069,
        a1dun_Leor_Fire_Gutter_fire = 175159,
        ZombieEatStart = 178483,
        ZombieEatStop = 178485,
        BannerDrop = 185040,
        EmoteFollow = 185042,
        EmoteGive = 185081,
        EmoteThanks = 185082,
        EmoteSorry = 185083,
        EmoteBye = 185085,
        EmoteDie = 185087,
        EmoteHelp = 185093,
        EmoteRun = 185598,
        EmoteWait = 185600,
        EmoteGo = 185629,
        trOut_LogStack_Short_Damage = 186138,
        Enchantress_RunAway = 186200,
        trDun_Cath_WallCollapse_Damage = 186216,
        Witchdoctor_SpiritBarrage_RuneC_AOE = 186471,
        Witchdoctor_Gargantuan_Smash = 186851,
        Barbarian_CallOfTheAncients_Basic_Melee = 187092,
        EmoteYes = 188251,
        EmoteNo = 188252,
        EmoteStay = 188253,
        EmoteAttack = 188254,
        EmoteRetreat = 188255,
        EmoteHold = 188256,
        EmoteTakeObjective = 188257,
        EmoteLaugh = 188258,
        Witchdoctor_Hex_Explode = 188442,
        UseStoneOfRecall = 191590,
        Monk_MantraOfEvasion = 192405,
        AI_ReturnToGuardObject = 193411,
        DualWieldBuff = 193438,
        Hireling_Dismiss_Buff = 196103,
        Hireling_Dismiss = 196142,
        Hireling_Dismiss_Buff_Remove = 196251,
        Witchdoctor_Hex_ChickenWalk = 196974,
        EnterStoneOfRecall = 200036,
        ExitStoneOfRecall = 200039,
        Scoundrel_Hysteria = 200169,
        Enchantress_MassCharm = 201524,
        EnterRecallPortal = 201538,
        ExitRecallPortal = 201570,
        Unburied_Wreckable_Attack = 202344,
        Weapon_Melee_Instant_Wreckables = 202345,
        PvP_DamageBuff = 202701,
        Barbarian_Passive_BoonOfBulKathos = 204603,
        Barbarian_Passive_NoEscape = 204725,
        Barbarian_Passive_Brawler = 205133,
        Barbarian_Passive_Ruthless = 205175,
        Barbarian_Passive_BerserkerRage = 205187,
        Barbarian_Passive_PoundOfFlesh = 205205,
        Barbarian_Passive_Bloodthirst = 205217,
        Barbarian_Passive_Animosity = 205228,
        Barbarian_Passive_Unforgiving = 205300,
        Barbarian_Passive_Relentless = 205398,
        Barbarian_Passive_Superstition = 205491,
        Barbarian_Passive_InspiringPresence = 205546,
        Barbarian_Passive_Juggernaut = 205707,
        Barbarian_Passive_ToughAsNails = 205848,
        Barbarian_Passive_WeaponsMaster = 206147,
        Wizard_Passive_Blur = 208468,
        Wizard_Passive_GlassCannon = 208471,
        Wizard_Passive_AstralPresence = 208472,
        Wizard_Passive_Evocation = 208473,
        Wizard_Passive_UnstableAnomaly = 208474,
        Wizard_Passive_TemporalFlux = 208477,
        Wizard_Passive_PowerHungry = 208478,
        Wizard_Passive_Prodigy = 208493,
        Wizard_Passive_GalvanizingWard = 208541,
        Wizard_Passive_Illusionist = 208547,
        Witchdoctor_Passive_ZombieHandler = 208563,
        Witchdoctor_Passive_RushOfEssence = 208565,
        Witchdoctor_Passive_BloodRitual = 208568,
        Witchdoctor_Passive_SpiritualAttunement = 208569,
        Witchdoctor_Passive_CircleOfLife = 208571,
        Witchdoctor_Passive_GruesomeFeast = 208594,
        Witchdoctor_Passive_TribalRites = 208601,
        DemonHunter_Passive_CustomEngineering = 208610,
        Witchdoctor_Passive_PierceTheVeil = 208628,
        Witchdoctor_Passive_FierceLoyalty = 208639,
        DemonHunter_Passive_Grenadier = 208779,
        Wizard_Passive_ArcaneDynamo = 208823,
        Monk_Passive_ExaltedSoul = 209027,
        Monk_Passive_FleetFooted = 209029,
        Witchdoctor_Passive_VisionQuest = 209041,
        Monk_Passive_BeaconOfYtar = 209104,
        Monk_Passive_Transcendence = 209250,
        Monk_Passive_SixthSense = 209622,
        Monk_Passive_SeizeTheInitiative = 209628,
        Monk_Passive_OneWithEverything = 209656,
        DemonHunter_Passive_Archery = 209734,
        Monk_Passive_TheGuardiansPath = 209812,
        Monk_Passive_Pacifism = 209813,
        MonsterAffix_ChampionBuff = 210333,
        MonsterAffix_EnrageExecute = 210335,
        DemonHunter_Passive_Brooding = 210801,
        DemonHunter_Passive_ThrillOfTheHunt = 211225,
        Monk_Passive_Resolve = 211581,
        ActorLoadingBuff = 212032,
        Taunted_Monster_Ranged_Projectile = 212952,
        Taunted_Weapon_Melee_Instant = 212953,
        MonsterAffix_ArcaneEnchanted = 214594,
        MonsterAffix_ArcaneEnchantedCast = 214791,
        MonsterAffix_Mortar = 215756,
        MonsterAffix_MortarCast = 215757,
        SelectingSkill = 217340,
        AI_TownWalkTo_Guaranteed = 217618,
        Barbarian_Passive_NervesOfSteel = 217819,
        Witchdoctor_Passive_BadMedicine = 217826,
        Witchdoctor_Passive_JungleFortitude = 217968,
        Wizard_Passive_Conflagration = 218044,
        Wizard_Passive_CriticalMass = 218153,
        Witchdoctor_Passive_GraveInjustice = 218191,
        DemonHunter_Passive_NightStalker = 218350,
        DemonHunter_Passive_TacticalAdvantage = 218385,
        DemonHunter_Passive_NumbingTraps = 218398,
        Monk_Passive_CombinationStrike = 218415,
        Witchdoctor_Passive_SpiritVessel = 218501,
        Witchdoctor_Passive_FetishSycophants = 218588,
        MonsterAffix_ArcaneEnchanted_New_PetBasic = 219671,
        ActorInTownBuff = 220304,
        UseDungeonStone = 220318,
        Enchantress_ScorchedEarth = 220872,
        Witchdoctor_PlagueOfToads_BigToad_TongueSlap = 220908,
        MonsterAffix_ArcaneEnchanted_Champion = 221130,
        MonsterAffix_DesecratorBuff_Champion = 221131,
        MonsterAffix_VortexBuff_Champion = 221132,
        MonsterAffix_ArcaneEnchanted_Minion = 221219,
        SkillOverrideStartedOrEnded = 221275,
        MonsterAffix_Jailer = 222743,
        MonsterAffix_JailerCast = 222744,
        MonsterAffix_Jailer_Champion = 222745,
        Monk_CycloneStrike = 223473,
        WorldCreatingBuff = 223604,
        ActorGhostedBuff = 224639,
        CannotDieDuringBuff = 225599,
        MonsterAffix_Avenger_Champion = 226289,
        MonsterAffix_Avenger_Buff = 226292,
        MonsterAffix_Waller = 226293,
        MonsterAffix_WallerCast = 226294,
        Wizard_Passive_ColdBlooded = 226301,
        Wizard_Passive_Paralysis = 226348,
        MonsterAffix_Shielding = 226437,
        MonsterAffix_ShieldingCast = 226438,
        MonsterAffix_Linked = 226497,
        Witchdoctor_FetishArmy_Melee = 226690,
        Witchdoctor_ZombieDog_Melee = 226692,
        IdentifyWithCast = 226757,
        DH_Companion_MeleeAttack = 227240,
        trDun_Cath_WallCollapse_Damage_offset = 227949,
        DebuffBleed = 228423,
        Manual_Walk = 229128,
        Enchantress_Melee_Instant = 230238,
        Templar_Melee_Instant = 230239,
        g_killElitePack = 230745,
        MonsterAffix_ReflectsDamage = 230877,
        AI_Follow_MeleeLead_Pet = 231004,
        MonsterAffix_PlaguedCast = 231115,
        MonsterAffix_WallerRare = 231117,
        MonsterAffix_WallerRareCast = 231118,
        MonsterAffix_FrozenCast = 231149,
        MonsterAffix_FrozenRare = 231157,
    }
}
