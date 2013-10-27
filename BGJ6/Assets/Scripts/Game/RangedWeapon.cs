using UnityEngine;
using System.Collections;

public class RangedWeapon : MonoBehaviour {

    public bool playerWeapon;

    public GameObject projectile;



	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (playerWeapon && Input.GetKeyDown(Bindings.Get(Bindings.Key.Fire)) && !UICamera.inputHasFocus)
            FireProjectile();
	}

    private void FireProjectile()
    {
        GameObject go = (GameObject) Instantiate(projectile, transform.position, Quaternion.identity);
        go.GetComponent<Projectile>().Fire(transform.position, transform.forward, transform.root.tag);
    }
}
