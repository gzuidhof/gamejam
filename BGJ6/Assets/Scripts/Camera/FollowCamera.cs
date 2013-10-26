using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {

    public Transform target;


    private Vector3 targetPos;
    private Vector3 startOffset;
    private  Quaternion startRot;


	// Use this for initialization
	void Start () {
        if (!target) target = GameObject.FindGameObjectWithTag("Player").transform;
        startOffset = transform.position - target.position;
	}
	
	void LateUpdate () {

        targetPos = target.position + startOffset;
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime);
	}
}
