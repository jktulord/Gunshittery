using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Entities.Player
{
    public class PlayerInput : MonoBehaviour
    {
        public ArtifactPlayerInventory ArtifactPlayerInventory;

        public PlayerGun gun1;
        public PlayerGun gun2;

        public GunStatPanel GunStatPanel1;
        public GunStatPanel GunStatPanel2;

        public int ShootKey1 = 0;
        public int ShootKey2 = 1;
        public KeyCode ReloadKey = KeyCode.R;
        public KeyCode ShowGunStatKey = KeyCode.B;
        public KeyCode PickUp1 = KeyCode.Q;
        public KeyCode PickUp2 = KeyCode.E;

        public void Update()
        {
            

            if (gun1.Type == Perks.GunType.Auto)
                if (Input.GetMouseButton(ShootKey1))
                    gun1.PlayerShoot();
                else { }
            else 
                if (Input.GetMouseButtonDown(ShootKey1))
                {
                    Debug.Log("YES");
                    gun1.PlayerShoot();
                }
                    
            

            if (gun2.Type == Perks.GunType.Auto)
                if (Input.GetMouseButton(ShootKey2))
                    gun2.PlayerShoot();
                else
                if (Input.GetMouseButtonDown(ShootKey2))
                    gun2.PlayerShoot();


            if (Input.GetKeyDown(ReloadKey))
            {
                gun1.PlayerReload();
                gun2.PlayerReload();
            }

            if (Input.GetKeyDown(ShowGunStatKey))
            {
                if (GunStatPanel1.gameObject.activeSelf)
                {
                    GunStatPanel1.gameObject.SetActive(false);
                    GunStatPanel2.gameObject.SetActive(false);
                }
                else
                {
                    GunStatPanel1.gameObject.SetActive(true);
                    GunStatPanel2.gameObject.SetActive(true);
                }
            }

            if (Input.GetKeyDown(PickUp1))
            {
                ArtifactPlayerInventory.PickUpThePickUp(1);
            }

            if (Input.GetKeyDown(PickUp2))
            {
                ArtifactPlayerInventory.PickUpThePickUp(2);
            }

        }

    }
}
