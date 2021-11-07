using Assets.Scripts.Entities.Perks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Entities.Guns
{
    public class GunStats : MonoBehaviour
    {
        public float BaseDamage = 10;
        public float DamageModifier = 100;
        public float Damage
        {
            get
            {
                if ((BaseDamage * DamageModifier / 100) < 1)
                    return 1;
                else if (Perks.IndexOf(PerkKind.Dicer) != -1)
                    return ((float)(Math.Round(Random.Range(0.5f, 1.5f), 2) * BaseDamage * DamageModifier / 100));
                else
                    return (BaseDamage * DamageModifier / 100);
            }
        }

        public float BaseBulletDelay = 1f;
        public float BulletDelayModifier = 100;
        public float BulletDelay
        {
            get
            {
                if (BulletDelayModifier < 1)
                    return (BaseBulletDelay / (1 / 100));
                else if (Type == GunType.Cylinder)
                    return (0.2f * BaseBulletDelay / (BulletDelayModifier / 100));
                else if (Perks.IndexOf(PerkKind.BulletThrower) != -1)
                    return (0.2f * BaseBulletDelay / (BulletDelayModifier / 100));
                else
                    return (BaseBulletDelay / (BulletDelayModifier / 100));
            }
        }

        public float BaseBPS
        {
            get
            {
                return 1 / BaseBulletDelay;
            }
        }

        public float BPS
        {
            get
            {
                return 1 / BulletDelay;
            }
        }

        public float Accuracy = 95;
        public float Stability = 50;


        public int Bullets = 1;
        public int Ricochet = 0;


        public float BaseForce = 20f;
        public float ForceModifier = 100;
        public float Force { 
            get { 
                if (Perks.IndexOf(PerkKind.SelfShooter) != -1)
                    return (-BaseForce * ForceModifier / 100);
                else if (Perks.IndexOf(PerkKind.Freezer) != -1)
                    return (0 * BaseForce * ForceModifier / 100);
                else if (Perks.IndexOf(PerkKind.BulletThrower) != -1)
                    return (0.1f * BaseForce * ForceModifier / 100);
                else
                    return (BaseForce * ForceModifier / 100);
            } }

        public float BaseBulletSize = 1f;
        public float BulletSizeModifier = 100;
        public float BulletSize
        {
            get
            {
                if ((BaseBulletSize * BulletSizeModifier / 100) < 0.5f)
                    return 0.5f;
                else
                    return (BaseBulletSize * BulletSizeModifier / 100);
            }
        }

        public int BaseClipSize = 10;
        public int ClipSizeModifier = 100;
        public int ClipSize { 
            get {
                if ((Type == GunType.Cylinder) || (Type == GunType.SlidingShutter))
                    return (BaseClipSize / 2 * ClipSizeModifier / 100);
                else
                    return (BaseClipSize * ClipSizeModifier / 100); 
            } }

        public float BaseReloadTime = 2;
        public float ReloadTimeModifier = 100;
        public float ReloadTime { get { return (BaseReloadTime * ReloadTimeModifier / 100); } }

        public GunType Type;
        public List<PerkKind> Perks;

        public float curDelay;
        public float curStab;
        public int curClip;
        public float curReload;
    }
}
