using UnityEngine;
using System.Collections;

public class TogglingLight : MonoBehaviour {

    public float toggleInterval = 4f;
    public float currentInterval = 0f;

    private Flashlight l;
	// Use this for initialization
	void Start () {
        l = GetComponent<Flashlight>();
	}
	
	// Update is called once per frame
	void Update () {
        currentInterval += Time.deltaTime;
        if (currentInterval > toggleInterval)
        {
            currentInterval = 0f;
            l.ToggleLight();
        }
	}
}
