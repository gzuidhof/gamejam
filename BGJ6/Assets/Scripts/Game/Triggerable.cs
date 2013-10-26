using UnityEngine;
using System.Collections;

public class Triggerable : MonoBehaviour {


    public bool playTweens;
    public bool activate;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void OnTrigger(bool dir)
    {
        if (activate)
            gameObject.SetActive(dir);
        if (playTweens) 
            PlayAllTweens(dir);
        
    }


    void PlayAllTweens(bool dir)
    {
        foreach (UITweener t in GetComponents<UITweener>())
        {
            //t.Reset();
            t.Play(dir);
        }

    }
}
