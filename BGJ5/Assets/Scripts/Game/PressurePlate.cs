using UnityEngine;
using System.Collections;

public class PressurePlate : MonoBehaviour {

    public Flashlight light;
    public bool inversed = false;

    float checkTime = 0f;


    void OnTriggerEnter(Collider c)
    {
        if (c.rigidbody && c.gameObject.tag == "TriggerBlock" /*|| c.gameObject.tag == "Player"*/)
        {
            Debug.Log("YA");
            light.Toggle(!inversed);
        }

    }

    void OnTriggerExit(Collider c)
    {
        if (c.rigidbody && c.gameObject.tag == "TriggerBlock" /*|| c.gameObject.tag == "Player"*/)
        {
            light.Toggle(inversed);
        }

    }


    //deprecated
    void RayCastCheck()
    {
        checkTime += Time.deltaTime;
        if (checkTime > 0.25f)
        {
            checkTime = 0f;
        }
        else
            return;

        RaycastHit h;

        Debug.DrawRay(transform.position, transform.up);

        if (Physics.Raycast(transform.position, transform.up, out h, 1f))
            light.Toggle(!inversed);
        else
            light.Toggle(inversed);
    }

}
