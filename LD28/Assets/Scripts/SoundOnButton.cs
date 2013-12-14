using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class SoundOnButton : MonoBehaviour {

    public AudioClip sound;
    public KeyCode key;

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(key))
        {
            audio.PlayOneShot(sound);
        }
	}
}
