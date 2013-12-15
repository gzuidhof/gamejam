using UnityEngine;
using System.Collections;

public class DeadLinePitcher : MonoBehaviour {

    public float minPitch;
    public float maxPitch;


	// Update is called once per frame
	void Update () {

        audio.pitch =  (1.4f - transform.position.y * 0.08f);
        audio.pitch = Mathf.Clamp(audio.pitch, minPitch, maxPitch);
	}
}
