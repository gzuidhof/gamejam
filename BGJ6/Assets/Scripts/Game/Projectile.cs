using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public float dmg = 5f;
    public float speed = 10f;
    public AudioClip hitSound;
    public AudioClip fireSound;
    public string firedBy; //String of tag who fired


    public void Fire(Vector3 from, Vector3 forward, string firedBy)
    {
        rigidbody.position = from;
        rigidbody.velocity = forward * speed;
        AudioSource.PlayClipAtPoint(fireSound, from);
        this.firedBy = firedBy;
        Invoke("Remove", 5f);
    }


    void Remove()
    {
        Destroy(transform.root.gameObject);

    }

    void OnTriggerEnter(Collider c)
    {
        if (!gameObject) return;
        if (string.Equals(c.transform.root.tag, firedBy)) return;

        AudioSource.PlayClipAtPoint(hitSound, c.transform.position);
        //if (c.rigidbody)
        //{
        if (c.transform.root.tag == "Player")
        {
            c.GetComponent<Player>().DealDamage(dmg);
        }
        else if (c.transform.root.tag == "Enemy")
        {
            c.GetComponent<Enemy>().DealDamage(dmg);
        }

        Remove();
      
        //}

    }

}
