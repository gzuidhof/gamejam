using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

    public float range = 5f;
    public Flashlight[] lights;
    public bool spinButton = false;

    private GameObject player;
    private Player playerScript;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!spinButton)
        {
            if (playerScript.GetPositiveButtonDown() &&
                Vector3.Distance(player.transform.position, transform.position) < range)
            {
                if (audio) audio.Play();
                foreach (Flashlight l in lights)
                {
                    l.ToggleLight();
                }
            }
        }
        else
        {
            if (playerScript.GetPositiveButtonDown() &&
                Vector3.Distance(player.transform.position, transform.position) < range)
            {
                if (audio) audio.Play();
                foreach (Flashlight l in lights)
                {
                    l.spin = !l.spin;
                }
            }
        }

	}
}
