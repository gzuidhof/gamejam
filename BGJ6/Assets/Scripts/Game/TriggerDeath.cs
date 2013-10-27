using UnityEngine;
using System.Collections;

public class TriggerDeath : MonoBehaviour {

    void OnTriggerEnter(Collider c)
    {
        if (!gameObject) return;
        //if (c.rigidbody)
        //{
        if (c.transform.root.tag == "Player")
        {
            c.transform.root.gameObject.GetComponent<Player>().DealDamage(500f);

        }

        else if (c.transform.root.tag == "Enemy")
        {
            c.GetComponent<Enemy>().DealDamage(500f);
        }

        //}

    }
}
