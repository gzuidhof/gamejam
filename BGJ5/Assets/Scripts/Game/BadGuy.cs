using UnityEngine;
using System.Collections;
using System.Collections.Generic;



[RequireComponent (typeof(AudioSource))]
public class BadGuy : MonoBehaviour {

    public float hitpoints;
    public AudioClip hurtSound;
    public AudioClip deathSound;
    public static List<BadGuy> badGuys = new List<BadGuy>();
    public MovementMotor motor;
    private GameObject target;

	// Use this for initialization
	void Start () {
        badGuys.Add(this);
        hitpoints = Random.Range(15f, 40f);
        target = GameObject.FindGameObjectWithTag("Player");
	}
	


	// Update is called once per frame
	void Update () {
        //damage();
        AI();
	}

    public bool damage(float dmg)
    {
        hitpoints -= dmg;
        if (hurtSound && dmg > 0.01f) audio.PlayOneShot(hurtSound);
        if (hitpoints < 0f)
        {
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
            Destroy(gameObject);
            return true;
        }
        return false;
    }

    public void AI()
    {
        motor.movementDirection = target.transform.position - transform.position;
        foreach (Flashlight b in Flashlight.lights)
            motor.movementDirection += ((transform.position - b.transform.position) * b.GetAngleDamage(this) * 4f);
    }

}
