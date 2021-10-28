using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Entities
{
    public class Gun : MonoBehaviour
    {
        public Transform firePoint;
        public GameObject bulletPrefab;

        public float BaseDamage = 10;
        public float DamageModifier = 100;
        public float Damage { get 
            { if ((BaseDamage * DamageModifier / 100) < 1)
                    return 1;
              else
                    return (BaseDamage * DamageModifier / 100); 
            } 
        }

        public float BaseForce = 20f;
        public float ForceModifier = 100;
        public float Force { get { return (BaseForce * ForceModifier / 100); } }

        public float BaseBulletDelay = 1f;
        public float BulletDelayModifier = 100;
        public float BulletDelay { get { return (BaseBulletDelay / (BulletDelayModifier / 100)); } }

        public float Accuracy = 95;
        
        public bool Auto = true;
        public bool IfShootGun = false;
        public bool IfPeashootGun = false;

        public int Bullets = 1;
        public int Ricochet = 0;

        public float BaseBulletSize = 1f;
        public float BulletSizeModifier = 100;
        public float BulletSize { get {
                if ((BaseDamage * DamageModifier / 100) < 1)
                    return 0.5f;
                else
                    return(BaseBulletSize * BulletSizeModifier / 100); } 
        }

        public float curDelay;


        public void CopyFromAnotherGun(PlayerGun playerGun)
        {
            BaseDamage = playerGun.BaseDamage;
            BaseDamage = playerGun.BaseDamage;

            BaseForce = playerGun.BaseForce;
            ForceModifier = playerGun.ForceModifier;
            
            BaseBulletDelay = playerGun.BaseBulletDelay;
            BulletDelayModifier = playerGun.BulletDelayModifier;

            Accuracy = playerGun.Accuracy;
            Auto = playerGun.Auto;

            IfShootGun = playerGun.IfShootGun;
            IfPeashootGun = playerGun.IfPeashootGun;
            Bullets = playerGun.Bullets;

            BaseBulletSize = playerGun.BaseBulletSize;
            BulletSizeModifier = playerGun.BulletSizeModifier;
            Ricochet = playerGun.Ricochet;

        }
        public void Shoot(int n = 1)
        {
            for (int i = 0; i < n; i++)
            {
                GameObject Bullet;
                Quaternion SpreadModifier = Quaternion.Euler(0, 0, UnityEngine.Random.Range(-60f * ((100 - Accuracy) / 100), 60f * ((100 - Accuracy) / 100)));

                if (IfPeashootGun)
                {
                    Vector3 StartPositionModifier = new Vector3(0.1f * (n - 1) - 0.2f * i, 0);
                    Bullet = Instantiate(bulletPrefab, firePoint.position + transform.rotation * StartPositionModifier, firePoint.rotation);
                }
                else if (IfShootGun)
                {
                    Vector3 StartPositionModifier = new Vector3(UnityEngine.Random.Range(0.1f, -0.1f), 0);
                    Bullet = Instantiate(bulletPrefab, firePoint.position + transform.rotation * StartPositionModifier, firePoint.rotation);
                }
                else
                {
                    Bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                }



                if (IfShootGun)
                {
                    //Vector2 DirectionModifier =  new Vector2(Random.Range(0.5f, -0.5f), 0);// transform.rotation*

                    Rigidbody2D rb = Bullet.GetComponent<Rigidbody2D>();
                    //Debug.Log(firePoint.up.x);
                    Vector2 DirectionModifier = (SpreadModifier * Quaternion.Euler(0, 0, Random.Range(-5f, 5f))) * firePoint.up;
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

            }
        }

        
    }
}
