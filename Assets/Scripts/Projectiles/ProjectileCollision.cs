using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    [SerializeField] private int damageAmount = 15;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }

        if (col.gameObject.CompareTag("enemy"))
        {
            //todo why is the damage integer ?
            col.gameObject.GetComponent<HealthSystem>().Damage(damageAmount);
            //todo apply enemy knockback
            Destroy(gameObject);
        }
    }
}
