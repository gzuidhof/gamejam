using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[RequireComponent(typeof(BoxCollider))]
public class PressurePlate : MonoBehaviour {


    public AudioClip enterSound;
    public AudioClip exitSound;

    public Triggerable triggerable;

    public List<Collider> inTrigger;

    void OnTriggerEnter(Collider c)
    {
        if ((c.rigidbody || c.transform.root.GetComponent<CharacterController>()) && !inTrigger.Contains(c))
        {
            inTrigger.Add(c);
            if (inTrigger.Count == 1)
            {
                if (triggerable)
                    triggerable.OnTrigger(true);
            }

            AudioSource.PlayClipAtPoint(enterSound, transform.position, 0.4f);
        }

    }

    void OnTriggerExit(Collider c)
    {
        
        //if (c.rigidbody)
        //{
        inTrigger.Remove(c);
            if (inTrigger.Count == 0)
            {
                if (triggerable)
                    triggerable.OnTrigger(false);
            }
            AudioSource.PlayClipAtPoint(exitSound, transform.position);
       // }

    }

    void Update()
    {
        foreach (Collider c in inTrigger)
            if (!c) OnTriggerExit(c);

    }

}
