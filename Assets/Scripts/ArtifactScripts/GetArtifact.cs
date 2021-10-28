﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.ArtifactScripts
{
    public static class GetArtifact
    {
        
        // Damage Items 10
        public static ArtifactStats HeavierBullets()
        {
            return new ArtifactStats("HeavierBullets", "+15% Damage, -25% Force.", 
                new Dictionary<EffectKind, float> {
                    { EffectKind.DamageModifier, 15 },
                    { EffectKind.ForceModifier, -25 },
                });
        }
        public static ArtifactStats SlowFury()
        {
            return new ArtifactStats("SlowFury", "+3Dmg, -25% Force.",
                new Dictionary<EffectKind, float> {
                    { EffectKind.BaseDamage, 3 },
                    { EffectKind.ForceModifier, -25 },
                });
        }
        public static ArtifactStats QIBTQ()
        {
            return new ArtifactStats("QIBTQ", "+20% Damage, -15% BPS.", 
                new Dictionary<EffectKind, float> {
                    { EffectKind.DamageModifier, 20 },
                    { EffectKind.BulletDelayModifier, -15 },
                });
        }
        public static ArtifactStats OneShotOneKill()
        {
            return new ArtifactStats("OneShotOneKill", "+10 Damage, -75% BPS.",
                new Dictionary<EffectKind, float> {
                    { EffectKind.BaseDamage, 10 },
                    { EffectKind.BulletDelayModifier, -75 },
                });
        }
        public static ArtifactStats BlindPower()
        {
            return new ArtifactStats("BlindPower", "+10 Damage, -35% accuracy.",
                new Dictionary<EffectKind, float> {
                    { EffectKind.BaseDamage, 10 },
                    { EffectKind.Accuracy, -35 },
                });
        }
        public static ArtifactStats UnfocusedFury()
        {
            return new ArtifactStats("UnfocusedFury", "+10% Damage, -5% accuracy.",
                new Dictionary<EffectKind, float> {
                    { EffectKind.DamageModifier, 10 },
                    { EffectKind.Accuracy, -5 },
                });
        }
        public static ArtifactStats RevolverBoy()
        {
            return new ArtifactStats("RevolverBoy", "+50% BPS, Makes Gun SemiAuto.",
                new Dictionary<EffectKind, float> {
                    { EffectKind.BulletDelayModifier, 50 },
                    { EffectKind.ChangeToSemi, 1 },
                });
        }
        public static ArtifactStats BulletGap()
        {
            return new ArtifactStats("BulletGap", "+2 Damage, -1 Bullet.",
                new Dictionary<EffectKind, float> {
                    { EffectKind.BaseDamage, 50 },
                    { EffectKind.Bullets, -1 },
                });
        }
        public static ArtifactStats RicochetGap()
        {
            return new ArtifactStats("RicochetGap", "+1 Damage, -1 Ricochet.",
                new Dictionary<EffectKind, float> {
                    { EffectKind.BaseDamage, 1 },
                    { EffectKind.Ricochet, -1 },
                });
        }
        public static ArtifactStats BFGATOR()
        {
            return new ArtifactStats("BFGATOR", "+10 Damage, +100% damage, +300% Bullet Size, -70% BPS, -30% Force",
                new Dictionary<EffectKind, float> {
                    { EffectKind.BaseDamage, 10 },
                    { EffectKind.DamageModifier, 100 },
                    { EffectKind.BulletSizeModifier, 300 },
                    { EffectKind.BulletDelayModifier, -70 },
                    { EffectKind.ForceModifier, -30 },
                });
        }

        // BulletForce Items 5
        public static ArtifactStats SmallerBullets()
        {
            return new ArtifactStats("SmallerBullets", "+10% Force, -10% Size.",
                new Dictionary<EffectKind, float> {
                    { EffectKind.ForceModifier, 10 },
                    { EffectKind.BulletSizeModifier, -10 },
                });
        }
        public static ArtifactStats ForceOfPeace()
        {
            return new ArtifactStats("ForceOfPeace", "+100% Force, -2 dmg.",
                new Dictionary<EffectKind, float> {
                    { EffectKind.ForceModifier, 100 },
                    { EffectKind.BaseDamage, -2 },
                });
        }
        public static ArtifactStats SniperTime()
        {
            return new ArtifactStats("SniperTime", "+10 dmg, +30% Force, -50% BulletSize, -50% BPS.", 
                new Dictionary<EffectKind, float> {
                    { EffectKind.BaseDamage, 10 },
                    { EffectKind.ForceModifier, 30 },
                    { EffectKind.BulletSizeModifier, -50 },
                    { EffectKind.BulletDelayModifier, -50 },
                });
        }
        public static ArtifactStats SelfShooter()
        {
            return new ArtifactStats("SelfShooter", "Makes you immune to selfHarm, But your gun will never be the same",
                new Dictionary<EffectKind, float> {
                    { EffectKind.BaseForce, -30 },
                    { EffectKind.ImmuneToSelfHurt, 1 },
                });
        }
        public static ArtifactStats Buster()
        {
            return new ArtifactStats("Buster", "-30 Force, selfHarmImmunity, +1 Ricochet, +50% BPS, -5 dmg",
                new Dictionary<EffectKind, float> {
                    { EffectKind.BaseForce, -30 },
                    { EffectKind.ImmuneToSelfHurt, 1 },
                    { EffectKind.Ricochet, 1 },
                    { EffectKind.BulletDelayModifier, 50 },
                    { EffectKind.BaseDamage, 5 },
                });
        }

        // BulletDelay Items 8
        public static ArtifactStats Speedster()
        {
            return new ArtifactStats("Speedster", "+50% BPS, -50% damage",
                new Dictionary<EffectKind, float> {
                    { EffectKind.BulletDelayModifier, 50 },
                    { EffectKind.DamageModifier, -50 },
                });
        }
        public static ArtifactStats MoreIsMuchMore()
        {
            return new ArtifactStats("MoreIsMuchMore", "+10% BPS, -20% force.", new Dictionary<EffectKind, float> {
                    { EffectKind.BulletDelayModifier, 10 },
                    { EffectKind.ForceModifier, -20 },
                });
        }
        public static ArtifactStats BulletThrower()
        {
            return new ArtifactStats("BulletThrower", "+50% BPS, -50% force, +2 bullets, -70% damage ", new Dictionary<EffectKind, float> {
                    { EffectKind.BulletDelayModifier, 50 },
                    { EffectKind.ForceModifier, -50 },
                    { EffectKind.Bullets, 2 },
                    { EffectKind.DamageModifier, -70 },
                });
        }
        public static ArtifactStats BulletExchange()
        {
            return new ArtifactStats("BulletExchange", "+50% BPS, -1 bullet", new Dictionary<EffectKind, float> {
                    { EffectKind.BulletDelayModifier, 50 },
                    { EffectKind.Bullets, -1 },
                });
        }
        public static ArtifactStats RicochetExchanger()
        {
            return new ArtifactStats("RicochetExchanger", "-1 Ricochet, +20% BPS", new Dictionary<EffectKind, float> {
                    { EffectKind.Ricochet, -1 },
                    { EffectKind.BulletDelayModifier, +20 },
                });
        }
        public static ArtifactStats Fatboy()
        {
            return new ArtifactStats("Fatboy", "+5% BPS, +100% Size", new Dictionary<EffectKind, float> {
                    { EffectKind.BulletDelayModifier, 5 },
                    { EffectKind.BulletSizeModifier, +100 },
                });
        }
        public static ArtifactStats SmollBoy()
        {
            return new ArtifactStats("SmollBoy", "+5% BPS, -50% Size", new Dictionary<EffectKind, float> {
                    { EffectKind.BulletDelayModifier, 5 },
                    { EffectKind.BulletSizeModifier, -50 },
                });
        }
        public static ArtifactStats Spreadster()
        {
            return new ArtifactStats("Spreadster", "-10% Accuracy, +10% BPS, makes gun Auto", new Dictionary<EffectKind, float> {
                    { EffectKind.Accuracy, 10 },
                    { EffectKind.BulletDelayModifier, 10 },
                    { EffectKind.ChangeToAuto, 1 },
                });
        }

        // Accuracy Items 4
        public static ArtifactStats PerciceShot()
        {
            return new ArtifactStats("PerciceShot", "+3% Accuracy, -2 dmg", new Dictionary<EffectKind, float> {
                    { EffectKind.Accuracy, 3 },
                    { EffectKind.BaseDamage, -2 },
                });
        }
        public static ArtifactStats ForceFocus()
        {
            return new ArtifactStats("ForceFocus", " +5% Accuracy, -30% force.", new Dictionary<EffectKind, float> {
                    { EffectKind.Accuracy, 5 },
                    { EffectKind.ForceModifier, -30 },
                });
        }
        public static ArtifactStats Delayer()
        {
            return new ArtifactStats("Delayer", "+5% Accuracy, -10% BPS", new Dictionary<EffectKind, float> {
                    { EffectKind.Accuracy, 5 },
                    { EffectKind.BulletDelayModifier, -10 },
                });
        }
        public static ArtifactStats SlowMachineGun()
        {
            return new ArtifactStats("SlowMachineGun", "+10% Accuracy -30% BPS, makes gun Auto", new Dictionary<EffectKind, float> {
                    { EffectKind.Accuracy, 10 },
                    { EffectKind.BulletDelayModifier, -30 },
                    { EffectKind.ChangeToAuto, 1 },
                });
        }

        // Tagger Items 3
        public static ArtifactStats Peashoter()
        {
            return new ArtifactStats("Peashoter", "+2 bullets, +Peashoter, -3 dmg, -20% delay", new Dictionary<EffectKind, float> {
                    { EffectKind.Bullets, 2 },
                    { EffectKind.ChangeToPeashoot, 1 },
                    { EffectKind.BaseDamage, -3 },
                    { EffectKind.BulletDelayModifier, -20 },
                });
        }
        public static ArtifactStats SuperPeashoter()
        {
            return new ArtifactStats("SuperPeashoter", "+5 bullets, +Peashoter, -5 dmg, -50% delay", new Dictionary<EffectKind, float> {
                    { EffectKind.Bullets, 5 },
                    { EffectKind.ChangeToPeashoot, 1 },
                    { EffectKind.BaseDamage, -5 },
                    { EffectKind.BulletDelayModifier, -50 },
                });
        }
        public static ArtifactStats Normalizer()
        {
            return new ArtifactStats("Normalizer", "+1 Normalize point, -1 dmg ", new Dictionary<EffectKind, float> {
                    { EffectKind.ChangeToNormal, 1 },
                    { EffectKind.BaseDamage, -1 },
                });
        }
            // Bullets Items 2
            public static ArtifactStats TwoShotsSomeKills()
        {
            return new ArtifactStats("TwoShotsSomeKills", "+2 bullets, -5 dmg, -20% Accuracy", new Dictionary<EffectKind, float> {
                    { EffectKind.Bullets, 2 },
                    { EffectKind.BaseDamage, -5 },
                    { EffectKind.Accuracy, -20 },
                });
            }
        public static ArtifactStats FiveShotsNoKills()
        {
            return new ArtifactStats("FiveShotsNoKills", "+5 bullets, -60% dmg, -50% sizes, -30% Accuracy.", new Dictionary<EffectKind, float> {
                    { EffectKind.Bullets, 5 },
                    { EffectKind.DamageModifier, -60 },
                    { EffectKind.BulletSizeModifier, -50 },
                    { EffectKind.Accuracy, -30 },
                });
        }

        // Ricochet Items 4
        public static ArtifactStats BasicBouncer()
        {
            return new ArtifactStats("BasicBouncer", "+1 Ricochet, -10% Force, -1 dmg, -5% delay", new Dictionary<EffectKind, float> {
                    { EffectKind.Ricochet, 1 },
                    { EffectKind.ForceModifier, -10 },
                    { EffectKind.BaseDamage, -1 },
                    { EffectKind.BulletDelayModifier, -5 },
                });
        }
        public static ArtifactStats DanceBabyDance()
        {
            return new ArtifactStats("DanceBabyDance", "+4 Ricochet, -50% Accuracy, +10% bps", new Dictionary<EffectKind, float> {
                    { EffectKind.Ricochet, 4 },
                    { EffectKind.Accuracy, -50 },
                    { EffectKind.BulletDelayModifier, 10 },
                });
        }
        public static ArtifactStats TappedBullets()
        {
            return new ArtifactStats("TappedBullets", "+1 Ricochet, -1 Bullet, +2 dmg", new Dictionary<EffectKind, float> {
                    { EffectKind.Ricochet, 1 },
                    { EffectKind.Bullets, -1 },
                    { EffectKind.BaseDamage, 2 },
                });
        }
        public static ArtifactStats REagle()
        {
            return new ArtifactStats("REagle", "+3 Ricochet, +10% dmg, +5dmg, -65% BPS, makes gun semi, +100% bullet size", new Dictionary<EffectKind, float> {
                    { EffectKind.Ricochet, 3 },
                    { EffectKind.DamageModifier, 10 },
                    { EffectKind.BaseDamage, 5 },
                    { EffectKind.BulletDelayModifier, -65 },
                    { EffectKind.ChangeToSemi, 1 },
                    { EffectKind.BulletSizeModifier, 100 },
                });
        }


        public static ArtifactStats ByNum(int n)
        {
            List<ArtifactStats> ArtifactList = new List<ArtifactStats>() 
            {
                
                //Damage Items 10 
                HeavierBullets(),
                SlowFury(),
                QIBTQ(),
                OneShotOneKill(),
                BlindPower(),
                UnfocusedFury(),
                RevolverBoy(),
                BulletGap(),
                RicochetGap(),
                BFGATOR(),

                // BulletForce Items 5
                SmallerBullets(),
                ForceOfPeace(),
                SniperTime(),
                SelfShooter(),
                Buster(),

                // BulletDelay Items 8
                Speedster(),
                MoreIsMuchMore(),
                BulletThrower(),
                BulletExchange(),
                RicochetExchanger(),
                Fatboy(),
                SmollBoy(),
                Spreadster(),

                // Accuracy Items 4
                PerciceShot(),
                ForceFocus(),
                Delayer(),
                SlowMachineGun(),

                // Tagger Items 3
                Peashoter(),
                SuperPeashoter(),
                Normalizer(),

                // Bullets Items 2
                TwoShotsSomeKills(),
                FiveShotsNoKills(),

                // Ricochet Items 4
                BasicBouncer(),
                DanceBabyDance(),
                TappedBullets(),
                REagle()
            };

            return ArtifactList[n];
        }
    }
}
