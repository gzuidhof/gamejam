using UnityEngine;
using System.Collections;

public class SmoothLookAtCS : MonoBehaviour {

    public Transform target;
    public float damping = 6.0F;
    public bool smooth  = true;

    private Vector3 wantedOffset;
    public float overviewOffset = 2.5f;

    public Vector3 goalPosition;
    public bool overview = false;
    

    public float positionDamping = 1F;

	// Use this for initialization
	void Start () {
        if (rigidbody)
            rigidbody.freezeRotation = true;
        wantedOffset = transform.position - target.position;
	}


    void LateUpdate()
    {
        overview = false;
        if (Input.GetKey(KeyCode.C) || GamePad.GetButton(GamePad.Button.X, 1)) overview = true;

        if (target )
        {
            if (smooth)
            {
                Quaternion rotation;
                //if (overview) rotation = Quaternion.LookRotation(new Vector3(0,-1,0.01f));
                rotation = Quaternion.LookRotation(target.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
            }
            else
            {
                transform.LookAt(target);
            }
        }

        if (overview) 
            goalPosition = target.position + wantedOffset*overviewOffset;
        else goalPosition = target.position + wantedOffset;

        if (goalPosition != Vector3.zero)
        {
            transform.position = (goalPosition);//, goalPosition, Time.deltaTime * positionDamping);
        }

    }
}
