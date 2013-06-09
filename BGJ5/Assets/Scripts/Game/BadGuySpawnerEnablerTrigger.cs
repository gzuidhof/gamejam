using UnityEngine;
using System.Collections;

public class BadGuySpawnerEnablerTrigger : MonoBehaviour {

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.transform.root.gameObject.tag == "Player")
        {
            GameManager.instance.GetComponent<BadGuySpawner>().enabled = true;
        }
    }

}
