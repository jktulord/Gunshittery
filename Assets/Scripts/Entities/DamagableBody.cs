using Assets.Scripts.Entities;
using Assets.Scripts.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class DamagableBody : MonoBehaviour
    {
        private TextSpawner TextSpawner;

        public LimitedValue Hp;
        public float hp;
        public bool IfImmuneToSelfHurt;
        public GameObject HpBarPrefab;

        public Transform Canvas;
        public Camera cam;

        private Slider HpBar;

        public void Start()
        {
            TextSpawner = GetComponent<TextSpawner>();
            Hp = new LimitedValue(hp, hp);
            if (HpBarPrefab != null)
            {
                cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
                if (cam != null)
                    Debug.Log("No cam found");
                Canvas = GameObject.FindGameObjectWithTag("MainCanvas").transform.Find("ObjectUI");
                //cam = 
                //Canvas = FindObjectOfType<Canvas>().transform.Find("ObjectUi");


                HpBar = Instantiate(HpBarPrefab, Canvas).GetComponent<Slider>();
                HpBar.maxValue = Hp.Max;
                HpBar.value = Hp.Value;
            }
            
        }

        public void ReciveDamage(BulletScript bullet, GameObject Author)
        {
            if ((Author.tag == gameObject.tag) && (IfImmuneToSelfHurt == true))
                return;

            Gun gun = bullet.Gun;

            Hp.Value -= gun.Damage;
            hp = Hp.Value;

            Vector3 Direction = gameObject.transform.position - bullet.transform.position;
            TextSpawner.ThrowAText("-"+gun.Damage, Direction.normalized * 10);
            
        }

        public void Update()
        {
            if (HpBarPrefab != null)
            {
                HpBar.transform.position = cam.WorldToScreenPoint(transform.position + new Vector3(0, 1.5f));
                HpBar.value = Hp.Value;
            }
            DieCheck();
            //Hp.Value += 5 * Time.deltaTime;
        }

        public void DieCheck()
        {
            if (Hp.Value <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
