using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinLogic : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody = null;
    [SerializeField] private GameObject player = null;
    [SerializeField] private GameManager gameManager = null;
    [SerializeField] private float radius = 8.0F;
    [SerializeField] private float power = 30.0F;
    
    void Start()
    {
        //todo not working
        Vector3 explosionPos = transform.position;
        rigidbody.AddExplosionForce(power, explosionPos, radius, 0.0F);
        gameManager.Coins.Add(gameObject);
    }

    public void GoToPlayer()
    {
        //todo add smooth transform animation
        rigidbody.isKinematic = true;
        transform.position = player.transform.position;
    }
    
    private void OnCollisionEnter(Collision other)
    {
        //todo add money to player
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
