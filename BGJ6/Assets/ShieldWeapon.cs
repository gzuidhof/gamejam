using UnityEngine;
using System.Collections;

public class ShieldWeapon : MonoBehaviour {



    private bool shieldOn = false;

    public GameObject shield;
    public UITweener tween;
    public float manaDrain = 10f;

    public AudioClip shieldOnSound;

    private Player p;

    public void TurnShieldOn()
    {
        if (shieldOn) return;

        if (p.stats.mana < 5f) return;

        AudioSource.PlayClipAtPoint(shieldOnSound, transform.position);
        shieldOn = true;
        shield.SetActive(true);
        tween.Reset();
        tween.Play(true);
    }

    public void TurnShieldOff()
    {
        AudioSource.PlayClipAtPoint(shieldOnSound, transform.position, 0.8f);

       // tween.Reset();
       // tween.Play(false);


        shield.SetActive(false);
        shieldOn = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(Bindings.Get(Bindings.Key.Fire)) && !UICamera.inputHasFocus && p.stats.mana > 1f)
        {
            TurnShieldOn();
            if (shieldOn)
                DrainMana();
        }
        else if (shieldOn)
        {
            if (p.stats.mana < 1f) p.OnNotEnoughMana();
            TurnShieldOff();
        }
        
	}

    void Start()
    {
        p = transform.root.GetComponent<Player>();

    }

    void DrainMana()
    {
        p.DrainMana(manaDrain * Time.deltaTime);

    }

    void OnDisable()
    {
        TurnShieldOff();
    }


}
