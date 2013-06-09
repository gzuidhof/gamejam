using UnityEngine;
using System.Collections;

public class BadGuySpawner : MonoBehaviour {

    public GameObject badGuyPrefab;

	// Update is called once per frame


    private float t;
    private float max = 20;

	void Update () {
        t += Time.deltaTime;
        if (t > 1f)
        {
            t = 0;
            max++;
        }
        if (BadGuy.badGuys.Count < max)
        {
            Instantiate(badGuyPrefab);
        }
            
	}
}
