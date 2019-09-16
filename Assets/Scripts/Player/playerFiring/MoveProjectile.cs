using System;
using Cinemachine.Utility;
using UnityEngine;

namespace playerFiring
{
    public class MoveProjectile : MonoBehaviour
    {

        private new Rigidbody rigidbody = null;
        [SerializeField] private float bulletSpeed = 15;

        // Start is called before the first frame update
        private void Start()
        {
            rigidbody = gameObject.GetComponent<Rigidbody>();
        }

        
        // Update is called once per frame
        private void FixedUpdate()
        {
            rigidbody.AddForce((transform.forward) * bulletSpeed);
        }
    }
}
