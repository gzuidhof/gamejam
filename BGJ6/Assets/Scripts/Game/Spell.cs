using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spell : MonoBehaviour {

    public bool unlocked;
    public GameObject hudIcon;
    public string spellName = "Green";

    private GameObject selectedSpellIcon;

    public static List<Spell> spells = new List<Spell>();


    public void Unlock()
    {
        unlocked = true;

        hudIcon.SetActive(true);
    }

    public void Select()
    {
        //Disable all others
        foreach (Spell s in spells)
            s.gameObject.SetActive(false);

        gameObject.SetActive(true);
        selectedSpellIcon.GetComponent<UISprite>().spriteName = spellName;
        
        //TODO Why is this not working
        foreach (UITweener t in selectedSpellIcon.GetComponents<UITweener>())
        {
            t.Reset();
            t.Play();
        }

    }

	// Use this for initialization
	void Awake () {
        spells.Add(this);
        selectedSpellIcon = GameObject.FindGameObjectWithTag("MainSpellIcon");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
            Select();
	}
}
