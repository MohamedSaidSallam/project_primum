using UnityEngine;
using UnityEngine.AI;

namespace Enemy.Movement
{
    public class GoofyChargeMovement : EnemyMovement
    {
        [SerializeField]
        [Tooltip("The Navmesh Agent of the current Gameobject.")]
        private NavMeshAgent navMeshAgent = null;
        [SerializeField]
        [Tooltip("A reference to the Game Manager.")]
        private GameManager gameManager = null;
        [SerializeField]
        private float fastInterval = 0.7f;
        [SerializeField]
        private float slowInterval = 3f;
        private float nextChange = 0;
        private bool normalPace = true;
        private Vector3 velocity;
        /// <summary>
        /// Moves the enemy towards the player using the navMeshAgent.
        /// </summary>
        public override void Move()
        {
            if (nextChange < Time.time)
            {
                normalPace = !normalPace;
                nextChange += normalPace ? slowInterval : fastInterval;
                if (!normalPace)
                {
                    navMeshAgent.speed *= 6;
                }
                else
                {
                    navMeshAgent.speed /= 6;
                }
            }

            navMeshAgent.SetDestination(gameManager.GetPlayer().transform.position);
        }
    }
}