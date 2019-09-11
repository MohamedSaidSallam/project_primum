using UnityEngine;

public class CycleMovement : MonoBehaviour
{
    [SerializeField]
    private Transform player = null;

    [Header("Random Region")]
    [SerializeField]
    private Vector3 randomRangeStart = Vector3.zero;
    [SerializeField]
    private Vector3 randomRangeEnd = Vector3.zero;

    [Header("Movement")]
    [SerializeField]
    private float speed = 0;

    private Vector3 currentStart;
    private Vector3 currentTarget;
    private float journeyLength;
    private float startTime;
    private bool targetReached = true;

    void Update()
    {
        if (targetReached)
        {
            currentStart = player.position;
            currentTarget.x = Random.Range(randomRangeStart.x, randomRangeEnd.x);
            currentTarget.y = Random.Range(randomRangeStart.y, randomRangeEnd.y);
            currentTarget.z = Random.Range(randomRangeStart.z, randomRangeEnd.z);
            journeyLength = Vector3.Distance(currentStart, currentTarget);
            startTime = Time.time;
        }

        player.position = Vector3.Lerp(
            currentStart,
            currentTarget,
            (Time.time - startTime) * speed / journeyLength);
        targetReached = player.position == currentTarget;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(currentTarget, Vector3.one);
    }
}
