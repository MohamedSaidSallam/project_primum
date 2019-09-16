using UnityEngine;

namespace playerFiring
{
    public class FiringSystem : MonoBehaviour
    {
        [SerializeField] private GameObject projectile = null;

        [SerializeField] private double fireRate = 1;
        [SerializeField] private double movePenalty = 0.33;
        private double nextFire;

        private void Update()
        {
            if (nextFire > Time.time) return;

            //todo confirm these r the correct btns
            if (Input.GetButton("Fire1") || Input.GetButton("Fire2"))
            {
                nextFire += movePenalty;
                return;
            }
        
            Instantiate(projectile, gameObject.transform.position, transform.rotation);
            nextFire = Time.time + fireRate;
        }
    }
}
