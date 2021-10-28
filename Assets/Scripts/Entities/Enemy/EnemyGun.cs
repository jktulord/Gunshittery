using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Entities.Enemy
{
    public class EnemyGun : Gun
    {
        private Rigidbody2D rb;
        //private LineRenderer line;

        public Transform Target;
        public bool HasALazerSight;
        public float TargetDelay;
        private float CurrentTargetDelay;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            if (Target == null)
            {
                Target = GetComponent<EnemyMoveAi>().target;
            }
        }

        void Update()
        {
           // Ray ray = new Ray(transform.position, transform.forward);
            //RaycastHit hit;

            curDelay -= Time.deltaTime;
            CurrentTargetDelay -= Time.deltaTime;

            if (CurrentTargetDelay <= 0)
            {
                CurrentTargetDelay = TargetDelay;
                Debug.Log("Targeting");
                Vector2 lookDir = (Vector2)Target.position - rb.position;
                float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;

                transform.rotation = Quaternion.Euler(0, 0, angle);

            }

            if ((Target != null) && (curDelay <= 0))
            {
                curDelay = BulletDelay;
                
                Shoot(Bullets);
            }

        }
    }
}
