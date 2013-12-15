using UnityEngine;
using System.Collections;

public class Spectator : MonoBehaviour {

    public float interval;

    public float jumpForce;

    public float jumpForceMin;
    public float jumpForceMax;


    void Start()
    {
        interval = Random.Range(0.5f, 1.5f);
        jumpForce = Random.Range(jumpForceMin, jumpForceMax);
        InvokeRepeating("Jump", interval, interval);

    }

    void Jump()
    {
       // rigidbody2D.AddForce(Vector2.up * 20f);
        if (rigidbody2D.IsSleeping())
            rigidbody2D.velocity = Vector2.up * jumpForce;
    }



}
