using UnityEngine;
using System.Collections;

public class RocketCamera : MonoBehaviour {

    public Transform rocket;
    public float speed;

    private Vector3 startOffset;

    void Start()
    {
        startOffset = camera.transform.position - rocket.position;
    }

	// Update is called once per frame
	void LateUpdate () {
        camera.transform.position = Vector3.Lerp(camera.transform.position, rocket.position + startOffset, Time.deltaTime * speed);
	}
}
