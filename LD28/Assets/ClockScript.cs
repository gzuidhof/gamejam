using UnityEngine;
using System.Collections;

public class ClockScript : MonoBehaviour {

    private float lastTick;


    void Tick()
    {
        if (audio)
            audio.Play();
        transform.Rotate(transform.forward, -1f);
    }

	// Update is called once per frame
	void Update () {
        if (Time.time - lastTick >= 1)
        {
            lastTick = Time.time;
            Tick();
        }
        

	}
}
