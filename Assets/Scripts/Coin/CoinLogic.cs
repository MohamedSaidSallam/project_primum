using UnityEngine;
using Random = UnityEngine.Random;

public class CoinLogic : MonoBehaviour
{
    [Header("Refs")]
    [SerializeField] private Rigidbody rigidBody = null;
    [Header("Settings")]
    [SerializeField] private float speed = 0.1f;
    [SerializeField] private Vector3 randomForceStart = Vector3.zero;
    [SerializeField] private Vector3 randomForceEnd = Vector3.zero;

    private Transform player = null;
    private GameManager gameManager = null;

    public GameManager GameManager
    {
        set
        {
            if (gameManager != null)
                gameManager.Coins.Remove(this);
            gameManager = value;
            if (gameManager != null)
            {
                player = gameManager.GetPlayer().transform;
                gameManager.Coins.Add(this);
            }
        }
    }

    void Start()
    {
        rigidBody.AddForce(new Vector3(Random.Range(randomForceStart.x, randomForceEnd.x),
                                       Random.Range(randomForceStart.y, randomForceEnd.y),
                                       Random.Range(randomForceStart.z, randomForceEnd.z)), ForceMode.Impulse);
    }

    public void GoToPlayer()
    {
        transform.position = Vector3.Lerp(transform.position, player.position, speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        //todo add money to player
        if (other.gameObject.CompareTag("Player") && gameManager.Enemies.Count == 0)
        {
            gameManager.Coins.Remove(this);
            Destroy(gameObject);
        }
    }
}
