using Assets.Scripts;
using Assets.Scripts.Entities;
using Assets.Scripts.Entities.Perks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    //private Rigidbody2D rb;

    public GameObject Author;
    public Gun Gun;

    public bool IfShootPowered = false;
    public bool IfClipPowered = false;
    public int RicochetAmount = 0;

    public void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
    }

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

    public void Update()
    {
        if (Gun.Perks.IndexOf(PerkKind.IncreasingSize) != -1)
            transform.localScale += new Vector3(1, 1) * Time.deltaTime;
    }
}
