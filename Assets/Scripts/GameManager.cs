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

    private void Start()
    {
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