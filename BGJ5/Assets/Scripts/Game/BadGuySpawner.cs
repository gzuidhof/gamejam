using UnityEngine;
using System.Collections;

public class BadGuySpawner : MonoBehaviour {

    public GameObject badGuyPrefab;

	// Use this for initialization
	void Start () {
	
	}


	// Update is called once per frame
	void Update () {
        if (BadGuy.badGuys.Count < 10)
        {
            Instantiate(badGuyPrefab);
        }
	}
}
