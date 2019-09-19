using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    [Tooltip("The Main Character of the game.")]
    private GameObject player = null;
    [SerializeField]
    [Tooltip("The nav mesh surface of the map.")]
    private NavMeshSurface surface = null;
    public List<GameObject> Coins { get; private set; }
    public List<GameObject> Enemies { get; private set; }

    public GameManager()
    {
        Coins = new List<GameObject>();
        Enemies = new List<GameObject>();
    }

    private void Start()
    {
    }

    private void Update()
    {
        if (Enemies.Count == 0)
        {
            foreach (var coin in Coins)
            {
                coin.GetComponent<CoinLogic>().GoToPlayer();
            }
        }
    }
    private void OnEnable()
    {
        surface.BuildNavMesh();

    }

    /// <summary>
    /// gets the Player.
    /// </summary>
    /// <returns>the Gameobject of the player.</returns>
    public GameObject GetPlayer()
    {
        return player;
    }
}