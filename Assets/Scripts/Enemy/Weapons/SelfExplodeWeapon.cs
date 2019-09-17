using System;
using UnityEngine;

public class SelfExplodeWeapon : Weapon
{
    [SerializeField]
    [Tooltip("The range at which the Character Explodes.")]
    protected float range = 1f;
    [SerializeField]
    [Tooltip("Damange to deal")]
    private int damageAmount = 0;

    protected override bool WithinRange(GameObject player, GameObject attacker)
    {
        return Vector3.Distance(player.transform.position, attacker.transform.position) < range; //temp
    }

    protected override void Attack(GameObject player, GameObject attacker)
    {
        player.GetComponent<HealthSystem>().Damage(damageAmount);
        attacker.GetComponent<EnemyLogic>().die();
    }
}
