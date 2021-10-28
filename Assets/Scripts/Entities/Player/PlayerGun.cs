using Assets.Scripts.Entities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : Gun
{

    public string Key = "Fire1";

   
    // Update is called once per frame
    void Update()
    {
        curDelay -= Time.deltaTime;

        if (Auto == true)
        {
            if ((Input.GetButton(Key)) && (curDelay <= 0))
            {
                curDelay = BulletDelay;
                Shoot(Bullets);
            }
        }
        else
        {
            if ((Input.GetButtonDown(Key)) && (curDelay <= 0))
            {
                curDelay = BulletDelay;
                Shoot(Bullets);
            }
        }

    }

    
}
