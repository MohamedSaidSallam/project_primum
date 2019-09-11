using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private FloatingJoystick joystick = null;
    [SerializeField] private float speed = 0.12f;
    [SerializeField] private Rigidbody Rigidbody = null;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        Rigidbody.velocity = new Vector3(-joystick.Horizontal * 100f * speed,
            Rigidbody.velocity.y,
            -joystick.Vertical * 100f * speed);
    }
}
