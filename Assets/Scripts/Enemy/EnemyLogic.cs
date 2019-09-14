using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    [SerializeField]
    [Tooltip("A reference to the Game Manager.")]
    private GameManager gameManager = null;
    [SerializeField]
    [Tooltip("The Weapons Used for attacking.")]
    private Weapon[] weapons = null;
    [SerializeField]
    [Tooltip("Movement Component of the current enemy")]
    private EnemyMovement enemyMovement = null;
    [SerializeField]
    [Tooltip("HealthSystem component to assign this component to it's onDeath call")]
    private HealthSystem HealthSystem = null;

    private void Start()
    {
        HealthSystem.onDeath += die;
    }

    private void Update()
    {
        foreach (Weapon weapon in weapons)
        {
            if (!weapon.TryAttack(gameManager.GetPlayer(), gameObject))
            {
                enemyMovement.Move();
            }
        }
    }

    private void die()
    {
        Destroy(gameObject);
    }
}
