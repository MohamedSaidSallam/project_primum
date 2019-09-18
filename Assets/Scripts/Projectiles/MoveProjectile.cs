using UnityEngine;

namespace playerFiring
{
    public class MoveProjectile : MonoBehaviour
    {
        [SerializeField] private new Rigidbody rigidbody = null;
        [SerializeField] private float bulletSpeed = 15f;

        private void FixedUpdate()
        {
            rigidbody.AddForce((transform.forward) * bulletSpeed);
        }
    }
}
