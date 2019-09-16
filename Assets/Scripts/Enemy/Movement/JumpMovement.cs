using UnityEngine;
using UnityEngine.AI;

public class JumpMovement : EnemyMovement
{
    [SerializeField] private Rigidbody rigidbody = null;

    /// <summary>
    /// Moves the enemy towards the player using the navMeshAgent.
    /// </summary>
    public override void Move()
    {
        rigidbody.AddForce(0, 200, 0);
    }
}
