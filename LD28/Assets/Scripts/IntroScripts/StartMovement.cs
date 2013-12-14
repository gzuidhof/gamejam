using UnityEngine;
using System.Collections;

public class StartMovement : MonoBehaviour {

    public Vector2 movement;

	// Use this for initialization
	void Start () {
        rigidbody2D.velocity = movement;
	}
	
}
