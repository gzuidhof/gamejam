using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

    public float range = 5f;
    public Flashlight[] lights;

    private GameObject player;
    private Player playerScript;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {

        if (playerScript.GetPositiveButtonDown() && 
            Vector3.Distance(player.transform.position,transform.position) < range)
        {
            foreach (Flashlight l in lights) {
                l.ToggleLight();
            }
        } 
	}
}
