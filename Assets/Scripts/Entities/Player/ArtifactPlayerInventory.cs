using Assets.Scripts;
using Assets.Scripts.ArtifactScripts;
using Assets.Scripts.ArtifactScripts.Generation;
using Assets.Scripts.Entities.Guns;
using Assets.Scripts.Entities.Perks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactPlayerInventory : MonoBehaviour
{
    public List<ArtifactStats> Gun1Artifacts;
    public List<ArtifactStats> Gun2Artifacts;
    
    public int artifatAmount;

    public PlayerMovement playerMovement;
   
    public PlayerGun playerGun1;
    public PlayerGun playerGun2;

    public GunStatPanel GunStatPanel1;
    public GunStatPanel GunStatPanel2;

    private PlayerGun BasePlayerGun1;
    private PlayerGun BasePlayerGun2;

    private DamagableBody DamagableBody;

    public bool PickUpState = false;
    public GameObject ChousenPickUp;


    private void Start()
    {
        
        DamagableBody = GetComponent<DamagableBody>();
        Gun1Artifacts = new List<ArtifactStats>();
        Gun2Artifacts = new List<ArtifactStats>();

        BasePlayerGun1 = new PlayerGun();
        BasePlayerGun1.CopyFromAnotherGun(playerGun1);
        BasePlayerGun2 = new PlayerGun();
        BasePlayerGun2.CopyFromAnotherGun(playerGun2);
        GunStatPanel1.Refresh(playerGun1);
        GunStatPanel2.Refresh(playerGun2);
    }
    /*
    private void Update()
    {
        if (PickUpState)
        {
            if (Input.GetButtonDown("PickUp1"))               
                PickUpThePickUp(1);
            if (Input.GetButtonDown("PickUp2"))
                PickUpThePickUp(2);
        }
    }
    */

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Artifact")
        {
            PickUpState = true;
            ChousenPickUp = collision.gameObject;
            if (ChousenPickUp.GetComponent<ObjectArtifact>().State == OAStates.Idle)
                ChousenPickUp.GetComponent<ObjectArtifact>().State = OAStates.PlayerNear;
            //PickUpThePickUp(1);
        }
        else if (collision.gameObject.tag == "PickUp")
        {
            DamagableBody.Hp.Value += 25;
            Destroy(collision.gameObject);
            //PickUpThePickUp(1);
        }
    }
    

    public void PickUpThePickUp(int GunNum)
    {
        if (ChousenPickUp.activeSelf == true)
        {
            ObjectArtifact artifact = ChousenPickUp.GetComponent<ObjectArtifact>();
            
            if (GunNum == 1)
            {
                /*
                if (artifact.artifact.ProEffects.ContainsKey(EffectKind.Bullets))
                {
                    if (playerGun1.BulletsPerShoot <= -artifact.artifact.ProEffects[EffectKind.Bullets])
                        return;
                }
                */
                artifact.PickUp(this, 1);
            }
                

            if (GunNum == 2)
            {
                /*
                if (artifact.artifact.Deffects1.ContainsKey(EffectKind.Bullets))
                {
                    if (playerGun2.BulletsPerShoot <= -artifact.artifact.ProEffects[EffectKind.Bullets])
                        return;
                }
                */
                artifact.PickUp(this, 2);
            }
            
        }
    }

    public void Refresh()
    {
        RefreshGunStats(BasePlayerGun1, playerGun1, Gun1Artifacts);
        RefreshGunStats(BasePlayerGun2, playerGun2, Gun2Artifacts);
        ChousenPickUp.SetActive(false);
        PickUpState = false;
        ChousenPickUp = null;
        GunStatPanel1.Refresh(playerGun1);
        GunStatPanel2.Refresh(playerGun2);
    }

    public void RefreshGunStats(PlayerGun BasePlayerGun, PlayerGun playerGun, List<ArtifactStats> artifactStats)
    {
        //artifatAmount = Gun1Artifacts.Count;
        playerGun.CopyFromAnotherGun(BasePlayerGun);
       

        for (int i = 0; i < artifactStats.Count; i++)
        {
            //playerMovement.moveSpeed = 200 + artifacts[i].
            foreach (EffectKind cur in artifactStats[i].ProEffects.Keys)
            {
                ChangePlayerGunAccordingly(playerGun, artifactStats[i].ProEffects, cur);
            }
            if (artifactStats[i].chosenDeffect == 1)
            {
                foreach (EffectKind cur in artifactStats[i].Deffects1.Keys)  
                {
                    ChangePlayerGunAccordingly(playerGun, artifactStats[i].Deffects1, cur);
                }
            }
            else if (artifactStats[i].chosenDeffect == 2)
            {
                foreach (EffectKind cur in artifactStats[i].Deffects2.Keys)
                {
                    ChangePlayerGunAccordingly(playerGun, artifactStats[i].Deffects2, cur);
                }
            }


            if (playerGun.DamageModifier < 1)
                playerGun.DamageModifier = 1;

            if (playerGun.ForceModifier < 1)
                playerGun.ForceModifier = 1;
            if (playerGun.BulletDelayModifier < 1)
                playerGun.BulletDelayModifier = 1;
            if (playerGun.BulletSizeModifier < 1)
                playerGun.BulletSizeModifier = 1;
        }

    }

    public void ChangePlayerGunAccordingly(PlayerGun playerGun, Dictionary<EffectKind, float> Effects, EffectKind cur)
    {
        switch (cur)
        {
            case EffectKind.Dmg:
                playerGun.BaseDamage += Effects[cur];
                break;
            case EffectKind.DmgMod:
                playerGun.DamageModifier += Effects[cur];
                break;

            case EffectKind.BPSMod:
                playerGun.BulletDelayModifier += Effects[cur];
                break;

            case EffectKind.Accuracy:
                playerGun.Accuracy += Effects[cur];
                break;
            case EffectKind.Stability:
                playerGun.Stability += Effects[cur];
                break;

            case EffectKind.SizeMod:
                playerGun.BulletSizeModifier += Effects[cur];
                break;
            case EffectKind.ForceMod:
                playerGun.ForceModifier += Effects[cur];
                break;


            case EffectKind.Clip:
                playerGun.BaseClipSize += (int)Effects[cur];
                break;
            case EffectKind.ClipMod:
                playerGun.ClipSizeModifier += (int)Effects[cur];
                break;

            case EffectKind.ReloadMod:
                playerGun.ReloadTimeModifier += (int)Effects[cur];
                break;


            case EffectKind.Bullets:
                playerGun.Bullets += (int)Effects[cur];
                break;
            case EffectKind.Ricochet:
                playerGun.Ricochet += (int)Effects[cur];
                break;

            //Types 
            case EffectKind.Auto:
                playerGun.Type = GunType.Auto;
                break;
            case EffectKind.Semi:
                playerGun.Type = GunType.Auto;
                break;
            case EffectKind.Burst:
                playerGun.Type = GunType.Auto;
                break;
            case EffectKind.Cylinder:
                playerGun.Type = GunType.Auto;
                break;
            case EffectKind.SlydingShutter:
                playerGun.Type = GunType.Auto;
                break;

            //Perks
            case EffectKind.Peashot:
                playerGun.Perks.Add(PerkKind.Peashot);
                break;
            case EffectKind.Shotgun:
                playerGun.Perks.Add(PerkKind.Shotgun);
                break;
            case EffectKind.LazerSight:
                playerGun.Perks.Add(PerkKind.LazerSight);
                break;
            case EffectKind.SuperSight:
                playerGun.Perks.Add(PerkKind.SuperSight);
                break;
            case EffectKind.SelfShooter:
                playerGun.Perks.Add(PerkKind.SelfShooter);
                break;
            case EffectKind.Freezer:
                playerGun.Perks.Add(PerkKind.Freezer);
                break;
            case EffectKind.BulletThrower:
                playerGun.Perks.Add(PerkKind.BulletThrower);
                break;
            case EffectKind.Dicer:
                playerGun.Perks.Add(PerkKind.Dicer);
                break;
            case EffectKind.PoweredTrigger:
                playerGun.Perks.Add(PerkKind.PoweredTrigger);
                break;
            case EffectKind.PoweredReload:
                playerGun.Perks.Add(PerkKind.PoweredReload);
                break;
            case EffectKind.Nails:
                playerGun.Perks.Add(PerkKind.Nails);
                break;
            case EffectKind.ClipRegen:
                playerGun.Perks.Add(PerkKind.ClipRegen);
                break;
            case EffectKind.IncreasingSize:
                playerGun.Perks.Add(PerkKind.IncreasingSize);
                break;


            /*
        case EffectKind.ChangeToAuto:
            playerGun.Type = GunType.Auto;
            break;

        case EffectKind.ChangeToSemi:
            playerGun.Type = GunType.Semi;
            break;

        case EffectKind.ChangeToShootgun:
            playerGun.Perks.Add(PerkKind.Shotgun);
            break;

        case EffectKind.ChangeToPeashoot:
            playerGun.Perks.Add(PerkKind.Shotgun);
            break;
            */
            /*
            case EffectKind.ChangeToNormal:
                playerGun.ShootgunEffect = false;
                playerGun.PeashootEffect = false;
                break;
            */
            case EffectKind.ImmuneToSelfHurt:
                DamagableBody.IfImmuneToSelfHurt = true;
                break;
        }
    }
}
