using UnityEngine;
using System.Collections;

public class MusicFade : MonoBehaviour {

    public float fadeSpeed;
    public float goalVolume;
    public bool fadeIn = true;
    public bool doOnStart = true;

	// Update is called once per frame
	void Start () {
        if (doOnStart) StartFade();
	}


    public void StartFade()
    {
        StartCoroutine("Fade");
    }

    IEnumerator Fade()
    {
        while (true)
        { 
            yield return null;
            if (fadeIn) {
                audio.volume += Time.deltaTime * fadeSpeed;
                if (audio.volume >= goalVolume)
                    StopCoroutine("Fade");
            }
            else
            {
                audio.volume -= Time.deltaTime * fadeSpeed;
                if (audio.volume <= goalVolume)
                    StopCoroutine("Fade");
            }
        }

    }


}
