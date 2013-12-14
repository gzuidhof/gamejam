using UnityEngine;
using System.Collections;

public class EnableAfterDelay : MonoBehaviour {

    public float delay;
    public GameObject gameObjectToEnable;
    public bool disableSelf;

	// Use this for initialization
	void OnEnable () {
        Invoke("Enable", delay);
	}
	
	// Update is called once per frame
	void Enable () {
        if (disableSelf) gameObject.SetActive(false);
        gameObjectToEnable.SetActive(!gameObjectToEnable.activeSelf);
	}
}
