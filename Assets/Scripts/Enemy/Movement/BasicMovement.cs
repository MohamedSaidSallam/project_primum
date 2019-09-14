using UnityEngine;
using UnityEngine.AI;

public class BasicMovement : EnemyMovement
{
    [SerializeField]
    [Tooltip("The Navmesh Agent of the current Gameobject.")]
    private NavMeshAgent navMeshAgent = null;
    [SerializeField]
    [Tooltip("A reference to the Game Manager.")]
    private GameManager gameManager = null;

    /// <summary>
    /// Moves the enemy towards the player using the navMeshAgent.
    /// </summary>
    public override void Move()
    {
        navMeshAgent.SetDestination(gameManager.GetPlayer().transform.position);
    }
}
