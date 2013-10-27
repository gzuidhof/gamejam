using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class LaserWeapon : MonoBehaviour {

    public LineRenderer lineRenderer;
    public ParticleSystem psystem;

    public Transform origin;
    public float range = 10f;
    public bool playerWeapon = true;
    public bool firing = false;
    public float dmg = 5f;

    public AudioClip laserSound;

    private Player p;

    public float manaDrain = 15f;
    private float audioDelay;
    private float lastAudioTime;

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
                PlaySounds(true);
                c.transform.root.GetComponent<Player>().DealDamage(dmg*Time.deltaTime);
            }
            else if (c.transform.root.tag == "Enemy" && c.GetComponent<Enemy>() != null)
            {
                PlaySounds(true);
                //Debug.Log("Dealing Damage");
                c.GetComponent<Enemy>().DealDamage(dmg * Time.deltaTime, true);
            }
            else PlaySounds(false);
        }
        else
        {
            StartCoroutine(LineEffect(origin.position + origin.forward*range));
            PlaySounds(false);
        }
    }


    void PlaySounds(bool hitEnemy)
    {
        if (Time.time - lastAudioTime > audioDelay)
        {
            if (hitEnemy) audio.pitch = 0.75f;
            else audio.pitch = 1f;
            audio.PlayOneShot(laserSound);
            lastAudioTime = Time.time;
        }

    }
	// Use this for initialization
	void Start () {
        p = transform.root.GetComponent<Player>();
        audioDelay = laserSound.length - 0.05f;
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
