using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour {

    public PlayerStats stats;
    public AudioClip owSound;
    public AudioClip deathSound;

    private TweenScale scaleT;
    public float startScale = 1f;

    private float startHealth;

    public bool alive = true;


    public static List<Enemy> enemies = new List<Enemy>();

	// Use this for initialization
	void Start () {
        enemies.Add(this);
        scaleT = GetComponent<TweenScale>();
        startHealth = stats.health;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void DealDamage(float dmg, bool noSound = false)
    {
        if (!noSound)
            audio.PlayOneShot(owSound);
        
        //transform.localScale = Vector3.one * (stats.health / startHealth);
        if (scaleT)
        {
            scaleT.Reset();
            scaleT.from = Vector3.one * startScale * (stats.health / startHealth);
        }

        stats.health -= dmg;

        if (scaleT)
        {
            scaleT.to = Vector3.one * startScale * (stats.health / startHealth);
            scaleT.Play();
        }

        if (stats.health <= 0f)
            Die();
            

    }

    public void DrainMana(float m)
    {
        stats.mana -= m;
    }

    public void Die()
    {
        AudioSource.PlayClipAtPoint(deathSound, transform.position, 0.9f);
        Destroy(transform.gameObject);
        alive = false;
    }

}
