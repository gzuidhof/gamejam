using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Checkpoint : MonoBehaviour {

    private static List<Checkpoint> seen = new List<Checkpoint>();

    public static Checkpoint lastCheckpoint;
    public AudioClip checkpointSound;
    private Player p;

    void OnTriggerEnter(Collider c)
    {
        if (!gameObject) return;

        
        //if (c.rigidbody)
        //{
        if (c.transform.root.tag == "Player")
        {
            if (seen.Contains(this)) return;
            if (checkpointSound)
                AudioSource.PlayClipAtPoint(checkpointSound, c.transform.position);
            seen.Add(this);
            p = c.transform.root.gameObject.GetComponent<Player>();
            lastCheckpoint = this;
        }


        //}

    }

    public void Respawn()
    {
        p.transform.position = transform.position;
        p.stats.health = p.attributes.maxHealth;
       // Application.LoadLevel(0);
        
        p.UpdateHUD();
    }

}
