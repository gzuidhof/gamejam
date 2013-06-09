using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour {


    public Vector3 spinAxis = new Vector3(0, 1, 0);
    public float spinSpeed = 5f;
    private bool spinDir = true;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        DoSpin();
	}

    void DoSpin()
    {
        if (spinDir)
        {
            transform.Rotate(spinAxis * Time.deltaTime * spinSpeed);
        }
        else
        {
            transform.Rotate(-spinAxis * Time.deltaTime * spinSpeed);
        }
    }

}
