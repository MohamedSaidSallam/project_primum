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
    [SerializeField] 
    private GameObject coin = null;
    private void Start()
    {
        HealthSystem.onDeath += die;
        gameManager.Enemies.Add(gameObject);
    }

    private void Update()
    {
        bool canMove = true;
        foreach (Weapon weapon in weapons)
        {
            canMove = (!weapon.TryAttack(gameManager.GetPlayer(), gameObject)) && canMove;
        }
        if (canMove)
        {
            enemyMovement.Move();
        }
    }

    public void die()
    {
        Destroy(gameObject);
        gameManager.Enemies.Remove(gameObject);
        Instantiate(coin, transform.position, Quaternion.identity);
        if (gameManager.Enemies.Count == 0)
        {
            foreach (var coin in gameManager.Coins)
            {
                coin.GetComponent<CoinLogic>().GoToPlayer();
            }
        }
    }
}
