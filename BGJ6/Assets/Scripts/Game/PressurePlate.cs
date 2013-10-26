using UnityEngine;
using System.Collections;


[RequireComponent(typeof(BoxCollider))]
public class PressurePlate : MonoBehaviour {

    public float amountInTrigger = 0;

    public AudioClip enterSound;
    public AudioClip exitSound;

    public Triggerable triggerable;


    void OnTriggerEnter(Collider c)
    {
        //if (c.rigidbody)
        //{
            amountInTrigger++;
            if (amountInTrigger == 1)
            {
                if (triggerable)
                    triggerable.OnTrigger(true);
            }

            AudioSource.PlayClipAtPoint(enterSound, transform.position, 0.4f);
        //}

    }

    void OnTriggerExit(Collider c)
    {
        
        //if (c.rigidbody)
        //{
            amountInTrigger--;
            if (amountInTrigger == 0)
            {
                if (triggerable)
                    triggerable.OnTrigger(false);
            }
            AudioSource.PlayClipAtPoint(exitSound, transform.position);
       // }

    }
}
