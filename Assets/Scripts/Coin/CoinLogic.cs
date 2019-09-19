using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinLogic : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidBody = null;
    [SerializeField] private GameObject player = null;
    [SerializeField] private GameManager gameManager = null;
    [SerializeField] private float radius = 30.0F;
    [SerializeField] private float power = 300.0F;
    [SerializeField] private float speed = 0.1f;
    
    void Start()
    {
            
        Vector3 explosionPos = transform.position;
        //rigidBody.AddExplosionForce(power, explosionPos+Vector3.up, radius,500);
        rigidBody.AddForce(new Vector3(Random.Range(5, 15), Random.Range(30, 35), Random.Range(5, 15)), ForceMode.Impulse);

    }

    public void GoToPlayer()
    {
        transform.position = Vector3.Lerp(transform.position,player.transform.position,speed);
    }
    public void SetGameManager(GameManager gameManager)
    {
        this.gameManager = gameManager;
        player = gameManager.GetPlayer();
        gameManager.Coins.Add(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        //todo add money to player
        if (other.gameObject.CompareTag("Player") && gameManager.Enemies.Count == 0)
        {
            gameManager.Coins.Remove(gameObject);
            Destroy(gameObject);

        }
    }
}
