using Cinemachine.Utility;
using UnityEngine;

namespace Player.playerFiring
{
    //todo suggestion move targeting to a seperate script
    public class FiringSystem : MonoBehaviour
    {
        [Header("Projectile Settings")]
        [SerializeField] private GameObject projectile = null;
        [SerializeField] private float fireRate = 1f;
        [Tooltip("fire time delay added for moving.")]
        [SerializeField] private float movePenalty = 0.33f;
        [SerializeField] private Transform emptyGameObject = null;
        [Header("Scripts Ref")]
        [SerializeField] private GameManager gameManager = null;
        [SerializeField] private new Rigidbody rigidbody = null;

        private GameObject target = null;
        private Vector3 direction;
        private float nextFire;

        public void Update()
        {
            if (nextFire > Time.time) return;

            if (!rigidbody.velocity.AlmostZero())
            {
                nextFire += movePenalty;
                target = null;
                return;
            }

            if (gameManager.Enemies.Count == 0) return;

            if (target == null)
            {
                setTarget();
            }
            else
            {
                direction = target.transform.position - gameObject.transform.position;
            }

            fireProjectile();
        }

        private void fireProjectile()
        {
            GameObject bullet = Instantiate(projectile, transform.position, transform.rotation, emptyGameObject);
            bullet.transform.forward = direction;
            nextFire = Time.time + fireRate;
        }

        private void setTarget()
        {
            Vector3 startingPosition = gameObject.transform.position;
            gameManager.Enemies.Sort(comparison: (x, y) =>
                (int)(Vector3.Distance(x.transform.position, startingPosition) -
                       Vector3.Distance(y.transform.position, startingPosition)));
            target = gameManager.Enemies[0];

            Vector3 targetPosition = target.transform.position;
            direction = targetPosition - startingPosition;
            float distance = Vector3.Distance(targetPosition, startingPosition);
            LayerMask mask = LayerMask.GetMask("enemy");
            for (int i = 1; i < gameManager.Enemies.Count; i++)
            {
                if (Physics.Raycast(startingPosition, direction, distance, ~mask))
                {
                    target = gameManager.Enemies[i];
                    direction = target.transform.position - startingPosition;
                    distance = Vector3.Distance(target.transform.position, startingPosition);
                }
                else
                {
                    break;
                }
            }
        }
    }
}
