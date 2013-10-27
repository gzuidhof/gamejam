using UnityEngine;
using System.Collections;

public class RangedWeapon : MonoBehaviour {

    public bool playerWeapon;

    private Player player;
    public GameObject projectile;
    public float manaCost = 2.5f;

    public float fireIntervalForAI = 1.5f;
    private float lastFireTime;

	// Use this for initialization
	void Start () {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
        if (playerWeapon && Input.GetKeyDown(Bindings.Get(Bindings.Key.Fire)) && !UICamera.inputHasFocus)
            Cast();
	}

    private void Cast()
    {
        if (playerWeapon)
        {
            if (player.stats.mana > manaCost)
            {
                player.DrainMana(manaCost);
                FireProjectile(transform.forward);
            }
            else
            {
                player.OnNotEnoughMana();
            }
        }
    }

    private void FireProjectile(Vector3 dir)
    {
        GameObject go = (GameObject)Instantiate(projectile, transform.position, Quaternion.identity);
        go.GetComponent<Projectile>().Fire(transform.position, dir, transform.root.tag);

    }

    internal void FireAtPlayer()
    {
        if (Time.time - lastFireTime > fireIntervalForAI)
        {
            lastFireTime = Time.time;
            FireProjectile(player.transform.position - transform.position);
        }
    }
}
