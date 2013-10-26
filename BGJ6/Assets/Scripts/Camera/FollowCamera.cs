using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {

    public Transform target;
    public bool rotate;
    public float rotateSpeed = 1f;

    private Vector3 targetPos;
    private Vector3 startOffset;
    private  Quaternion targetRot;


	// Use this for initialization
	void Start () {
        if (!target) target = GameObject.FindGameObjectWithTag("Player").transform;
        startOffset = transform.position - target.position;
	}
	
	void LateUpdate () {

        targetPos = target.position + startOffset;
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * 1.5f);

        if (rotate)
        {
            targetRot = Quaternion.LookRotation(target.position - transform.position);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, Time.deltaTime * rotateSpeed);
        }
        

	}
}
