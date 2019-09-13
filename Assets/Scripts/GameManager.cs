using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    [Tooltip("The Main Character of the game.")]
    private GameObject player = null;

    /// <summary>
    /// gets the Player.
    /// </summary>
    /// <returns>the Gameobject of the player.</returns>
    public GameObject GetPlayer()
    {
        return player;
    }
}