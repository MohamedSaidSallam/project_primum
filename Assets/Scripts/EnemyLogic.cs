using UnityEngine;
using UnityEngine.AI;

public class EnemyLogic : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The Navmesh Agent of the current Gameobject.")]
    private NavMeshAgent navMeshAgent = null;
    [SerializeField]
    [Tooltip("A reference to the Game Manager.")]
    private GameManager gameManager = null;
    [SerializeField]
    [Tooltip("The Weapons Used for attacking.")]
    private Weapon[] weapons = null;

    private void Start()
    {

    }

    private void Update()
    {
        foreach (Weapon weapon in weapons)
        {
            if (!weapon.TryAttack(gameManager.GetPlayer(), gameObject))
            {
                navMeshAgent.SetDestination(gameManager.GetPlayer().transform.position);
            }
        }
    }
}
