using Assets.Scripts.Entities;
using Assets.Scripts.Entities.Perks;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGun : Gun
{
    public Lazer LeftSightLazer;
    public Lazer RightSightLazer;


    public TMP_Text ClipLine;
    public Slider ReloadSlider;
    public Slider FireSlider;

    public Slider PowerFireSlider;
    public Slider PowerReloadSlider;

    

    //public string Key = "Fire1";

    // Update is called once per frame

    public void PlayerShoot()
    {
        if (curReload > 0)
            return;
        bool IfPressTimed = false;
        if (Perks.IndexOf(PerkKind.PoweredTrigger) != -1)
            if (((curPowerFire / 1) < 0.6f) && ((curPowerFire / 1) > 0.4f))
                IfPressTimed = true;

        if (Type == GunType.Auto)
        {
            if ((curDelay <= 0))
            {
                curDelay = BulletDelay;
                Shoot(Bullets, IfPressTimed);
            }
        }
        if (Type == GunType.Burst)
        {
            if ((curDelay <= 0))
            {
                curDelay = BulletDelay;
                StartCoroutine(BurstShot(IfPressTimed));
            }
        }
        else
        {
            if ((curDelay <= 0))
            {
                curDelay = BulletDelay;
                Shoot(Bullets, IfPressTimed);
            }
        }
    }

    IEnumerator BurstShot(bool IfShootPowered = false)
    {
        Shoot(Bullets, IfShootPowered);
        yield return new WaitForSeconds(0.1f);
        Shoot(Bullets, IfShootPowered);
        yield return new WaitForSeconds(0.1f);
        Shoot(Bullets, IfShootPowered);
    }

    public void PlayerReload()
    {
        bool IfPressTimed = false;
        if (Perks.IndexOf(PerkKind.PoweredReload) != -1)
            if (((curPowerReload / 1) < 1.2f) && ((curPowerReload / 1) > 0.8f))
                IfPressTimed = true;

        if (Type == GunType.Cylinder)
        {
            if (IfPressTimed)
                PoweredBullets += 1;
            curClip += 1;
            if (curClip > ClipSize)
            {
                curClip = ClipSize;
            }
        }
        else if (Type == GunType.SlidingShutter)
        {
            if (curReload > 0)
            {
                curReload -= 1;
            }
            else
            {
                if (IfPressTimed)
                    PoweredBullets += ClipSize;
                curClip = ClipSize;
                curReload = ReloadTime;
            }
        }
        else
        {
            if (IfPressTimed)
                PoweredBullets += ClipSize;
            curClip = ClipSize;
            curReload = ReloadTime;
        }
    }

    new void Update()
    {
        curDelay -= Time.deltaTime;
        curStab -= 4 * Time.deltaTime;
        curReload -= Time.deltaTime;

        curPowerFire -= Time.deltaTime;
        if (curPowerFire < 0)
        {
            curPowerFire = 1;
            Tick();
        }
        curPowerReload -= Time.deltaTime;
        if (curPowerReload < 0)
            curPowerReload = 2;

        if (curStab < 0)
            curStab = 0;
        if (curDelay < 0)
            curDelay = 0;

        if (ClipLine != null)
            ClipLine.text = curClip + "/" + ClipSize;
        if (ReloadSlider != null)
            ReloadSlider.value = curReload / ReloadTime;
        if (FireSlider != null)
            FireSlider.value = curDelay / BulletDelay;
        if (PowerFireSlider != null)
            if (Perks.IndexOf(PerkKind.PoweredTrigger) != -1)
            {
                PowerFireSlider.gameObject.SetActive(true);
                PowerFireSlider.value = curPowerFire / 1;
            }
            else
                PowerFireSlider.gameObject.SetActive(false);
        if (PowerReloadSlider != null)
            if (Perks.IndexOf(PerkKind.PoweredReload) != -1)
            {
                PowerReloadSlider.gameObject.SetActive(true);
                PowerReloadSlider.value = curPowerReload / 1;
            }
            else
                PowerReloadSlider.gameObject.SetActive(false);
        

        if ((LeftSightLazer != null))
        {
            if (Perks.IndexOf(PerkKind.SuperSight) != -1)
            {
                if (curReload <= 0)
                {
                    LeftSightLazer.IsActive = true;
                    RightSightLazer.IsActive = true;
                }
                else
                {
                    LeftSightLazer.IsActive = false;
                    RightSightLazer.IsActive = false;
                }
                LeftSightLazer.DirectionModifier = Quaternion.Euler(0, 0, -15f * (1 + curStab) * ((100 - Accuracy) / 100));
                RightSightLazer.DirectionModifier = Quaternion.Euler(0, 0, 15f * (1 + curStab) * ((100 - Accuracy) / 100));
            }
            else
            {
                LeftSightLazer.IsActive = false;
                RightSightLazer.IsActive = false;
            }
        }
    }

    public void Tick()
    {
        if (Perks.IndexOf(PerkKind.ClipRegen) != -1)
            curClip += 1;
    }

    
}
