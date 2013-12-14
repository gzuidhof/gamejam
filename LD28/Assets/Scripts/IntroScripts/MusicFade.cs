using UnityEngine;
using System.Collections;

public class MusicFade : MonoBehaviour {

    public float fadeSpeed;
    public float maxVolume;

	// Update is called once per frame
	void Start () {
        StartFadeIn();
	}


    public void StartFadeIn()
    {
        StartCoroutine("FadeIn");
    }

    IEnumerator FadeIn()
    {
        while (true)
        { 
            yield return null;

            audio.volume += Time.deltaTime * fadeSpeed;
            if (audio.volume >= maxVolume)
                StopCoroutine("FadeIn");
        }

    }


}
