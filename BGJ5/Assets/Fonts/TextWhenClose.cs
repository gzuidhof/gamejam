using UnityEngine;
using System.Collections;

public class TextWhenClose : MonoBehaviour {

    GameObject player;
    public float dist = 6f;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(player.transform.position, transform.position) < dist)
        {
            renderer.enabled = true;
        }
        else
        {
            renderer.enabled = false;
        }
	}
}
