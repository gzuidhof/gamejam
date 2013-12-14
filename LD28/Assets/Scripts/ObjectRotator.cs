using UnityEngine;
using System.Collections;

public class ObjectRotator : MonoBehaviour {

    public Vector3 axisAround;
    public float speed;

	// Update is called once per frame
	void Update () {
        transform.Rotate(axisAround, speed * Time.deltaTime);
	}
}
