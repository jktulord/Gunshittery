using Assets.Scripts.Entities.Guns;
using Assets.Scripts.Entities.Perks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Entities
{
    public class Gun : GunStats
    {
        public Transform firePoint;
        public GameObject bulletPrefab;
        public GameObject nailBulletPrefab;

        public Lazer LazerSight;

        public int PoweredBullets = 0;
        public float curPowerReload = 1;
        public float curPowerFire = 1;


        public void Start()
        {
            curClip = ClipSize;
        }

        public void Shoot(int n = 1, bool IfShootPowered = false)
        {
            for (int i = 0; i < n; i++)
            {
                int ClipCost = 1;
                /*
                if ((Type == GunType.SlidingShutter) || (Type == GunType.Cylinder))
                    ClipCost = 2;
                else
                    ClipCost = 1;
                */
                if (curClip < ClipCost)
                    return;
                else
                    curClip -= ClipCost;

                if (Type == GunType.SlidingShutter)
                {
                    curReload = 1;
                }
                GameObject BulletPrefab = bulletPrefab;
                if (Perks.IndexOf(PerkKind.Nails) != -1)
                    BulletPrefab = nailBulletPrefab;
                GameObject Bullet;  
                Quaternion SpreadModifier = Quaternion.Euler(0, 0, UnityEngine.Random.Range(-15f * (1 + curStab) * ((100 - Accuracy) / 100), 15f * (1 + curStab) * ((100 - Accuracy) / 100)));


                if (Perks.IndexOf(PerkKind.Peashot) != -1)
                {
                    Vector3 StartPositionModifier = new Vector3(0.1f * (n - 1) - 0.2f * i, 0);
                    Bullet = Instantiate(BulletPrefab, firePoint.position + transform.rotation * StartPositionModifier, firePoint.rotation);
                }
                else if (Perks.IndexOf(PerkKind.Shotgun) != -1)
                {
                    Vector3 StartPositionModifier = new Vector3(UnityEngine.Random.Range(0.1f, -0.1f), 0);
                    Bullet = Instantiate(BulletPrefab, firePoint.position + transform.rotation * StartPositionModifier, firePoint.rotation);
                }
                else
                {
                    Bullet = Instantiate(BulletPrefab, firePoint.position, firePoint.rotation);
                }



                if (Perks.IndexOf(PerkKind.Shotgun) != -1)
                {
                    //Vector2 DirectionModifier =  new Vector2(Random.Range(0.5f, -0.5f), 0);// transform.rotation*

                    Rigidbody2D rb = Bullet.GetComponent<Rigidbody2D>();
                    //Debug.Log(firePoint.up.x);
                    Vector2 DirectionModifier = (SpreadModifier) * firePoint.up; /** Quaternion.Euler(0, 0, Random.Range(-5f, 5f))*/
                    rb.AddForce(DirectionModifier * Force * Random.Range(1.1f, 0.9f), ForceMode2D.Impulse);
                    //rb.rotation += Random.Range(0.1f, -0.1f);
                }
                else
                {
                    Rigidbody2D rb = Bullet.GetComponent<Rigidbody2D>();
                    Vector2 DirectionModifier = SpreadModifier * firePoint.up;
                    rb.AddForce(DirectionModifier * Force, ForceMode2D.Impulse);

                }

                Transform tf = Bullet.transform;
                BulletScript bulletScript = Bullet.GetComponent<BulletScript>();
                bulletScript.Gun = this;

                tf.localScale *= BulletSize;
                bulletScript.RicochetAmount = Ricochet;
                bulletScript.Author = gameObject;
                bulletScript.IfShootPowered = IfShootPowered;
                if (PoweredBullets > 0)
                {
                    bulletScript.IfClipPowered = true;
                    PoweredBullets -= 1;
                }
                curStab += 5 * ((100 - Stability) / 100);
                if (curStab > 3)
                {
                    curStab = 3;
                }
                

                if (Perks.IndexOf(PerkKind.LazerSight) != -1)
                {
                    LazerSight.IsActive = true;
                }
                else
                {
                    LazerSight.IsActive = false;
                }
            }
        }

    }
}
