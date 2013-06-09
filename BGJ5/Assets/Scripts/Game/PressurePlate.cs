using UnityEngine;
using System.Collections;

public class PressurePlate : MonoBehaviour {

    public Flashlight light;
    public bool inversed = false;

    float checkTime = 0f;
    public float amountInTrigger = 0;

    public AudioClip enterSound;
    public AudioClip exitSound;


    void OnTriggerEnter(Collider c)
    {
        if (c.rigidbody && c.gameObject.tag == "TriggerBlock" || c.gameObject.tag == "Player")
        {
            amountInTrigger++;
            Debug.Log("YA");
            light.Toggle(!inversed);
            AudioSource.PlayClipAtPoint(enterSound, transform.position, 0.4f);
        }

    }

    void OnTriggerExit(Collider c)
    {
        if (c.rigidbody && c.gameObject.tag == "TriggerBlock" || c.gameObject.tag == "Player")
        {
            amountInTrigger--;
            if (amountInTrigger==0)
                light.Toggle(inversed);
            AudioSource.PlayClipAtPoint(exitSound, transform.position);
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

        if (Physics.Raycast(transform.position, transform.up, out h, 0.5f))
        {
            Debug.Log("HIT");
            light.Toggle(!inversed);
        }
        else
            light.Toggle(inversed);
    }

}
