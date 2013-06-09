using UnityEngine;
using System.Collections;

[RequireComponent (typeof(AudioSource))]
public class Checkpoint : MonoBehaviour {

    public static float furthest = 0;
    public static Checkpoint currentRespawn = null;

    public ResetTriggerBlock[] resetTriggerBlocks;


    public float num;



    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.transform.root.gameObject.tag == "Player")
        {
            if (num > furthest)
            {
                Debug.Log("Checkpoint set! num: " + num);
                furthest = num;
                audio.Play();
                currentRespawn = this;
            }
        }
    }

    public void Respawn(Player p)
    {
        p.transform.position = transform.position;
        p.rigidbody.velocity = Vector3.zero;
        foreach (ResetTriggerBlock b in resetTriggerBlocks)
        {
            b.Reset();
        }
    }


}
