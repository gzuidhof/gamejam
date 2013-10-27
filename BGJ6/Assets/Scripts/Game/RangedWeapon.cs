using UnityEngine;
using System.Collections;

public class RangedWeapon : MonoBehaviour {

    public bool playerWeapon;

    private Player player;
    public GameObject projectile;
    public float manaCost = 2.5f;


	// Use this for initialization
	void Start () {
        if (playerWeapon)
            player = transform.root.GetComponent<Player>();
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
                FireProjectile();
            }
            else
            {
                player.OnNotEnoughMana();
            }
        }
    }

    private void FireProjectile()
    {
        GameObject go = (GameObject)Instantiate(projectile, transform.position, Quaternion.identity);
        go.GetComponent<Projectile>().Fire(transform.position, transform.forward, transform.root.tag);

    }
}
