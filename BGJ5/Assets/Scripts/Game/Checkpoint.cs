using UnityEngine;
using System.Collections;

[RequireComponent (typeof(AudioSource))]
public class Checkpoint : MonoBehaviour {

    public static int furthest = 0;
    public static Vector3 currentRespawn = new Vector3(-5f, 0f,25f) ;

    public int num;



    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.transform.root.gameObject.tag == "Player")
        {
            if (num > furthest)
            {
                Debug.Log("Checkpoint set! num: " + num);
                furthest = num;
                audio.Play();
                currentRespawn = transform.position;
            }
        }
    }

}
