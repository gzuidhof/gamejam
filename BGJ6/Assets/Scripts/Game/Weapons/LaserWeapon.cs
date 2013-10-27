using UnityEngine;
using System.Collections;

public class LaserWeapon : MonoBehaviour {

    public LineRenderer lineRenderer;
    public ParticleSystem psystem;

    public Transform origin;
    public float range = 10f;
    public bool playerWeapon = true;
    public bool firing = false;
    public float dmg = 5f;

    private Player p;

    public float manaDrain = 15f;

    void ShootLaser()
    {
        RaycastHit hit;
        bool hitAnything = Physics.Raycast(origin.position,origin.forward, out hit, range);
        if (hitAnything)
        {
            Debug.DrawLine(transform.position, hit.point, Color.red, 1f);
            StartCoroutine(LineEffect(hit.point));
            Collider c = hit.collider;
            if (c.transform.root.tag == "Player")
            {
                c.transform.root.GetComponent<Player>().DealDamage(dmg*Time.deltaTime);
            }
            else if (c.transform.root.tag == "Enemy")
            {
                //Debug.Log("Dealing Damage");
                c.GetComponent<Enemy>().DealDamage(dmg * Time.deltaTime, true);
            }
        }
        else
        {
            StartCoroutine(LineEffect(origin.position + origin.forward*range));
        }
    }


	// Use this for initialization
	void Start () {
        p = transform.root.GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
        if (playerWeapon && Input.GetKey(Bindings.Get(Bindings.Key.Fire)) && !UICamera.inputHasFocus && p.stats.mana > 10f)
        {
            firing = true;
            psystem.Play();
        }
        else if (!Input.GetKey(Bindings.Get(Bindings.Key.Fire)) || UICamera.inputHasFocus || p.stats.mana < 2f)
        {
            firing = false;
            psystem.Stop();
            psystem.Clear();
        }

        if (firing)
        {
            if (p.stats.mana < 3f)
            {
                firing = false;
                psystem.Stop();
                psystem.Clear();
                p.OnNotEnoughMana();
            }
            ShootLaser();
            DrainMana();
        }
	}

    IEnumerator LineEffect(Vector3 hit)
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, hit);
        yield return null;
        if (!firing)
        {
            lineRenderer.SetPosition(0, Vector3.zero);
            lineRenderer.SetPosition(1, Vector3.zero);
        }
       yield return null;
       if (!firing)
       {
           lineRenderer.SetPosition(0, Vector3.zero);
           lineRenderer.SetPosition(1, Vector3.zero);
       }
    }

    void DrainMana()
    {
        p.DrainMana(manaDrain * Time.deltaTime);

    }
}
