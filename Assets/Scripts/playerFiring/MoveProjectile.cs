using System;
using UnityEngine;

namespace playerFiring
{
    public class MoveProjectile : MonoBehaviour
    {

        [SerializeField] private new Rigidbody rigidbody = null;
        [SerializeField] private float bulletSpeed = 10;
        [SerializeField] private GameObject[] enemies;
        public GameObject target;

        private Vector3 direction;

        // Start is called before the first frame update
        private void Start()
        {
            enemies = GameObject.FindGameObjectsWithTag("enemy");
            var startingPosition = gameObject.transform.position;
        
            Array.Sort(enemies, (x, y) => 
                (int) (Vector3.Distance(x.transform.position, startingPosition) -
                       Vector3.Distance(y.transform.position, startingPosition)));

            // todo check if no enemies in range dont create elbta3 elli ana feh now
            try
            {
                target = enemies[0];
            }
            catch (IndexOutOfRangeException)
            {
                Destroy(gameObject);
                return;
            }

            var targetPosition = target.transform.position;
            direction = targetPosition - startingPosition;
            var distance = Vector3.Distance(targetPosition, startingPosition);
            LayerMask mask = LayerMask.GetMask("enemy");
            for (int i = 1; i < enemies.Length; i++)
            {
                if (Physics.Raycast(startingPosition, direction, distance, ~mask))
                {
                    target = enemies[i];
                    direction = target.transform.position - startingPosition;
                    distance = Vector3.Distance(target.transform.position, startingPosition);   
                }
            }
        }

        // Update is called once per frame
        private void FixedUpdate()
        {
            rigidbody.AddForce((direction) * bulletSpeed);
        }
    }
}
