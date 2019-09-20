using System.Collections.Generic;
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
    private GameObject coinPrefab = null;
    [SerializeField]
    private int numOfCoins = 3;

    private List<GameObject> coins;

    private void Start()
    {
        HealthSystem.onDeath += die;
        gameManager.Enemies.Add(gameObject);

        initializeCoins();
    }

    private void initializeCoins()
    {
        coins = new List<GameObject>();
        for (int i = 0; i < numOfCoins; i++)
        {
            GameObject coin = Instantiate(coinPrefab,
                        transform.position,
                        Quaternion.identity,
                        transform);
            coin.SetActive(false);
            coin.GetComponent<CoinLogic>().GameManager = gameManager;
            coins.Add(coin);
        }
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
        foreach (GameObject coin in coins)
        {
            coin.transform.parent = null;
            coin.SetActive(true);
        }
    }
}
