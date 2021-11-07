using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Entities.Guns
{
    public static class CopyGunExt
    {
        public static void CopyFromAnotherGun(this PlayerGun gun, PlayerGun playerGun)
        {
            gun.BaseDamage = playerGun.BaseDamage;
            gun.DamageModifier = playerGun.DamageModifier;

            gun.BaseBulletDelay = playerGun.BaseBulletDelay;
            gun.BulletDelayModifier = playerGun.BulletDelayModifier;

            gun.Accuracy = playerGun.Accuracy;
            gun.Stability = playerGun.Stability;

            gun.Ricochet = playerGun.Ricochet;
            gun.Bullets = playerGun.Bullets;

            gun.BaseBulletSize = playerGun.BaseBulletSize;
            gun.BulletSizeModifier = playerGun.BulletSizeModifier;
            gun.BaseForce = playerGun.BaseForce;
            gun.ForceModifier = playerGun.ForceModifier;

            gun.Perks = playerGun.Perks;

            gun.BaseClipSize = playerGun.BaseClipSize;
            gun.ClipSizeModifier = playerGun.ClipSizeModifier;
            gun.BaseReloadTime = playerGun.BaseReloadTime;
            gun.ReloadTimeModifier = playerGun.ReloadTimeModifier;
        }

    }
}
