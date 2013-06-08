using UnityEngine;
using System.Collections;

public class SmoothLookAtCS : MonoBehaviour {

    public Transform target;
    public float damping = 6.0F;
    public bool smooth  = true;

    private Vector3 wantedOffset;

    public Vector3 goalPosition;
    public float positionDamping = 1F;

	// Use this for initialization
	void Start () {
        if (rigidbody)
            rigidbody.freezeRotation = true;
        wantedOffset = transform.position - target.position;
	}


    void Update()
    {
        

    }
    void LateUpdate()
    {
        if (target)
        {
            if (smooth)
            {
                Quaternion rotation = Quaternion.LookRotation(target.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
            }
            else
            {
                transform.LookAt(target);
            }
        }
        goalPosition = target.position + wantedOffset;
        if (goalPosition != Vector3.zero)
        {
            transform.position = (goalPosition);//, goalPosition, Time.deltaTime * positionDamping);
        }

    }
}
