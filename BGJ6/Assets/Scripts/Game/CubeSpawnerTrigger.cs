using UnityEngine;
using System.Collections;

public class CubeSpawnerTrigger : MonoBehaviour {

    public GameObject obj;

	// Use this for initialization
	void OnEnable () {
        obj.transform.position = transform.position;
        obj.rigidbody.velocity = Vector3.zero;

	}

}
