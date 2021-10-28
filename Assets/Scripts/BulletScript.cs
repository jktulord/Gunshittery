using Assets.Scripts;
using Assets.Scripts.Entities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject Author;
    public Gun Gun;

    public int RicochetAmount = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if ((collision.gameObject.tag == "Enemy"))
        {
            //Debug.Log(collision.gameObject.name);
            DamagableBody Enemy = collision.gameObject.GetComponent<DamagableBody>();
            Enemy.ReciveDamage(this, Author);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Player")
        {
            //Debug.Log(collision.gameObject.name);
            DamagableBody PlayerBody = collision.gameObject.GetComponent<DamagableBody>();
            PlayerBody.ReciveDamage(this, Author);
        }
        if ((collision.gameObject.tag != "Projectile") || (collision.gameObject.tag == "Player"))
        {
            if (RicochetAmount <= 0)
            {
                //Debug.Log(collision.gameObject.name);
                Destroy(gameObject);
            }
            else
                RicochetAmount -= 1;
        }
    }
}
