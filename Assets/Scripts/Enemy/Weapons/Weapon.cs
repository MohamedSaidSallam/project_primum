using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    /// <summary>
    /// Tries to attack the player by checking if it's within range or not.
    /// </summary>
    /// <param name="player">the target player gameobject</param>
    /// <param name="attacker">the attacking gameobject</param>
    /// <returns>true in case it successfully attacked, false otherwise</returns>
    public virtual bool TryAttack(GameObject player, GameObject attacker)
    {
        if (WithinRange(player, attacker))
        {
            Attack(player, attacker);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Checks if the player is within range of the weapon.
    /// </summary>
    /// <param name="player">the target player gameobject</param>
    /// <param name="attacker">the attacking gameobject</param>
    /// <returns>true if the player is within range, false otherwise.</returns>
    protected abstract bool WithinRange(GameObject player, GameObject attacker);

    /// <summary>
    /// Attacks the player.
    /// </summary>
    /// <param name="player">the target player gameobject</param>
    /// <param name="attacker">the attacking gameobject</param>
    protected abstract void Attack(GameObject player, GameObject attacker);
}
