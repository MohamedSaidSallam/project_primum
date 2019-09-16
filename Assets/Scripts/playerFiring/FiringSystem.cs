using System;
using System.Collections;
using Cinemachine.Utility;
using UnityEngine;

namespace playerFiring
{
    public class FiringSystem : MonoBehaviour
    {
        [SerializeField] public GameObject projectile = null;

        [SerializeField] private double fireRate = 1;
        [SerializeField] private double movePenalty = 0.33;
        [SerializeField] private GameManager gameManager;
        [SerializeField] private Rigidbody Rigidbody;
        private Vector3 direction;
        public GameObject target = null;
        private double nextFire;

        //todo ask which is better getComponent on start or adding via editor ?
//        private void Start()
//        {
//            Rigidbody = gameObject.GetComponent<Rigidbody>();
//        }

        public void Update()
        {
            if (nextFire > Time.time) return;
            
            if (!Rigidbody.velocity.AlmostZero())
            {
                nextFire += movePenalty;
                return;
            }

            Debug.Log(gameManager.Enemies.Count);
            if (gameManager.Enemies.Count == 0) return;

            if (target == null)
            {
                var startingPosition = gameObject.transform.position;
                gameManager.Enemies.Sort(comparison: (x, y) => 
                    (int) (Vector3.Distance(x.transform.position, startingPosition) -
                           Vector3.Distance(y.transform.position, startingPosition)));
                target = gameManager.Enemies[0];

                var targetPosition = target.transform.position;
                direction = targetPosition - startingPosition;
                var distance = Vector3.Distance(targetPosition, startingPosition);
                LayerMask mask = LayerMask.GetMask("enemy");
                for (int i = 1; i < gameManager.Enemies.Count; i++)
                {
                    if (Physics.Raycast(startingPosition, direction, distance, ~mask))
                    {
                        target = gameManager.Enemies[i];
                        direction = target.transform.position - startingPosition;
                        distance = Vector3.Distance(target.transform.position, startingPosition);   
                    }
                } 
            }
            else
            {
                direction = target.transform.position - gameObject.transform.position;
            }

            GameObject bullet = Instantiate(projectile, gameObject.transform.position, transform.rotation);
            bullet.transform.forward = direction;
//            bullet.GetComponent<Rigidbody>().AddForce(direction * 500);
            nextFire = Time.time + fireRate;
        }
    }
}
