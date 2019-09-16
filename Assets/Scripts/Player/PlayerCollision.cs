using System;
using UnityEngine;

namespace Player
{
    public class PlayerCollision : MonoBehaviour
    {
        [SerializeField] private float collisionInterval = 1;
        private float nextCollision = 0;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("enemy"))
            {
                if (nextCollision > Time.time) return;
                gameObject.GetComponent<HealthSystem>().Damage(other.gameObject.GetComponent<EnemyLogic>().CollisionDamage);
                nextCollision = Time.time + collisionInterval;
            }

        }
    }
}
