using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileCollision : MonoBehaviour
{
    [SerializeField] private int damageAmount = 15;
    void OnTriggerEnter(Collider col)
    {
        //all projectile colliding game objects should be tagged "Enemy" or whatever in inspector but that tag must be reflected in the below if conditional
        if (col.gameObject.CompareTag("wall"))
        {
            Destroy(gameObject);
        }
        
        if (col.gameObject.CompareTag("enemy"))
        {
            //todo why is the damage integer ?
            col.gameObject.GetComponent<HealthSystem>().Damage(damageAmount);
            //todo apply enemy knockback
//            col.gameObject.transform.position
//            col.gameObject.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * 15);
            Destroy(gameObject);
        }
    }
}
