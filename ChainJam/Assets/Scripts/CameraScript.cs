using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    public static CameraScript instance;

    //Active players
    public Transform[] players;

    //maximum transform, biggest zoom level
    public Transform maxTrans;

    private Vector3 targetPos;
    public Vector3 startPos;
    public Quaternion startRot;


	// Use this for initialization
	void Start () {
        instance = this;
        startPos = transform.position;
        startRot = transform.rotation;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        float highestY = 0f;

        foreach (Transform p in players) {
            if (p.position.y > highestY) highestY = p.position.y;
        }
        //Debug.Log("highestY: " + highestY);

        targetPos = Vector3.Lerp(startPos, maxTrans.position, highestY / 31f);

        //Smooth movement to new target position (1 unit per second).
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime);
	}
}
