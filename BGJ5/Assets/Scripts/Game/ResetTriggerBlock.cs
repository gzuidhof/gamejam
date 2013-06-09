using UnityEngine;
using System.Collections;

public class ResetTriggerBlock : MonoBehaviour {

    private Vector3 originalPos;

	// Use this for initialization
	void Start () {
        originalPos = transform.position;
	}

    public void Reset()
    {
        transform.position = originalPos;
    }
}
