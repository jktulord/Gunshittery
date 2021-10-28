using Assets.Scripts;
using Assets.Scripts.ArtifactScripts;
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
    }

    private void Update()
    {
        if (PickUpState)
        {
            if (Input.GetButton("PickUp1"))
                PickUpThePickUp(1);
            if (Input.GetButton("PickUp2"))
                PickUpThePickUp(2);
        }
            

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Artifact"))
        {
            PickUpState = true;
            ChousenPickUp = collision.gameObject;
            //PickUpThePickUp(1);
        }
        else if ((collision.gameObject.tag == "PickUp"))
        {
            DamagableBody.Hp.Value += 25;
            Destroy(collision.gameObject);
            //PickUpThePickUp(1);
        }
    }
    

    private void PickUpThePickUp(int GunNum)
    {
        if (ChousenPickUp.activeSelf == true)
        {
            ObjectArtifact artifact = ChousenPickUp.GetComponent<ObjectArtifact>();
            
            if (GunNum == 1)
            {
                if (artifact.artifact.Effects.ContainsKey(EffectKind.Bullets))
                {
                    if (playerGun1.Bullets <= -artifact.artifact.Effects[EffectKind.Bullets])
                        return;
                }
                Gun1Artifacts.Add(artifact.artifact);
            }
                

            if (GunNum == 2)
            {
                if (artifact.artifact.Effects.ContainsKey(EffectKind.Bullets))
                {
                    if (playerGun2.Bullets <= -artifact.artifact.Effects[EffectKind.Bullets])
                        return;
                }
                Gun2Artifacts.Add(artifact.artifact);
            }

            artifact.Disapear();
            RefreshGunStats(BasePlayerGun1, playerGun1, Gun1Artifacts);
            RefreshGunStats(BasePlayerGun2, playerGun2, Gun2Artifacts);
            ChousenPickUp.SetActive(false);
            PickUpState = false;
            ChousenPickUp = null;
        }
    }

    public void RefreshGunStats(PlayerGun BasePlayerGun, PlayerGun playerGun, List<ArtifactStats> artifactStats)
    {
        //artifatAmount = Gun1Artifacts.Count;
        playerGun.CopyFromAnotherGun(BasePlayerGun);
       

        for (int i = 0; i < artifactStats.Count; i++)
        {
            //playerMovement.moveSpeed = 200 + artifacts[i].
            Dictionary<EffectKind, float> Effects = artifactStats[i].Effects;
            foreach (EffectKind cur in Effects.Keys)
            {
                switch (cur)
                {
                    case EffectKind.BaseDamage:
                        playerGun.BaseDamage += Effects[cur];
                        break;
                    case EffectKind.DamageModifier:
                        playerGun.DamageModifier += Effects[cur];
                        break;

                    case EffectKind.BaseForce:
                        playerGun.BaseForce += Effects[cur];
                        break;
                    case EffectKind.ForceModifier:
                        playerGun.ForceModifier += Effects[cur];
                        break;

                    case EffectKind.BulletDelayModifier:
                        playerGun.BulletDelayModifier += Effects[cur];
                        break;

                    case EffectKind.Accuracy:
                        playerGun.Accuracy += Effects[cur];
                        break;

                    case EffectKind.Bullets:
                        playerGun.Bullets += (int)Effects[cur];
                        break;

                    case EffectKind.BulletSizeModifier:
                        playerGun.BulletSizeModifier += Effects[cur];
                        break;

                    case EffectKind.Ricochet:
                        playerGun.Ricochet += (int)Effects[cur];
                        break;

                    case EffectKind.ChangeToAuto:
                        playerGun.Auto = true;
                        break;

                    case EffectKind.ChangeToSemi:
                        playerGun.Auto = false;
                        break;

                    case EffectKind.ChangeToShootgun:
                        playerGun.IfShootGun = true;
                        break;

                    case EffectKind.ChangeToPeashoot:
                        playerGun.IfPeashootGun = true;
                        break;

                    case EffectKind.ChangeToNormal:
                        playerGun.IfShootGun = false;
                        playerGun.IfPeashootGun = false;
                        break;

                    case EffectKind.ImmuneToSelfHurt:
                        DamagableBody.IfImmuneToSelfHurt = true;
                        break;
                }
            }
            
        }

    }
}
