using UnityEngine;
using System.Collections;

public class HeartBeatCamera : MonoBehaviour {


    public Transform target;
    public float speed;

    private Vector3 startOffset;

    void Start()
    {
        startOffset = camera.transform.position - target.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        camera.transform.position = new Vector3( Vector3.Lerp(camera.transform.position, target.position + startOffset, Time.deltaTime * speed).x, 0f);
    }
}
