using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

    public float range = 2f;
    public Flashlight[] lights;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("e") && Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position) < range) 
        {
            foreach (Flashlight l in lights) {
                l.ToggleLight();
            }
        } 
	}
}
