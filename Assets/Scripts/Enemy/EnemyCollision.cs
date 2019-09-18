using UnityEngine;

[RequireComponent(typeof(Collider))]
public class EnemyCollision : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Time between each damage dealt to player because of collision.")]
    private float collisionInterval = 1;
    [SerializeField]
    [Tooltip("Damage dealt to player incase of collision.")]
    private int collisionDamage = 0;

    private float nextCollision = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (nextCollision > Time.time) return;
            other.gameObject.GetComponent<HealthSystem>().Damage(collisionDamage);
            nextCollision = Time.time + collisionInterval;
        }
    }
}
