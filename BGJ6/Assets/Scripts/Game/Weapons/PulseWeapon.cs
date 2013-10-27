using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PulseWeapon : MonoBehaviour {

    public float distance = 4f;
    public float strength = 1000f;

    private Player p;

    public float disableTime = 2f;

    public AudioClip pulseSound;

    public float baseManaCost = 35f;

    private Dictionary<GameObject,float> dict = new Dictionary<GameObject,float>();

    //Do Pulse
    void FusRoDah()
    {
        Collider[] col = Physics.OverlapSphere(transform.position, distance);
        foreach (Collider c in col)
        {
            if (c.rigidbody)
            {
                if (c.GetComponent<EnemyBrain>() != null)
                {
                    StartCoroutine(TemporarilyPauseAgent(c.gameObject));
                    c.rigidbody.AddExplosionForce(strength * 1/c.transform.localScale.magnitude, transform.position, distance);
                }
                else
                    c.rigidbody.AddExplosionForce(strength, transform.position, distance);
            }
        }
        AudioSource.PlayClipAtPoint(pulseSound, transform.position);
    }

    IEnumerator TemporarilyPauseAgent(GameObject e)
    {
        e.rigidbody.isKinematic = false;
        e.rigidbody.useGravity = true;
        e.GetComponent<NavMeshAgent>().enabled = false;
        e.GetComponent<EnemyBrain>().enabled = false;
        e.GetComponent<EnemyBrain>().lastDisableTime = Time.time;
        yield return new WaitForSeconds(disableTime + 0.15f);
        RestartAgent(e);
    }

    void RestartAgent(GameObject e)
    {
        if (Time.time - e.GetComponent<EnemyBrain>().lastDisableTime < disableTime) return;
        e.rigidbody.isKinematic = true;
        e.rigidbody.useGravity = false;
        e.GetComponent<NavMeshAgent>().enabled = true;
        e.GetComponent<EnemyBrain>().enabled = true;
    }

	// Use this for initialization
	void Start () {
        p = transform.root.GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(Bindings.Get(Bindings.Key.Fire)) && !UICamera.inputHasFocus)
        {
            if (p.stats.mana > baseManaCost)
            {
                FusRoDah();
                DrainMana();
            }
            else
                p.OnNotEnoughMana();
        }
	}

    void DrainMana()
    {
        p.DrainMana(baseManaCost);
    }

}
