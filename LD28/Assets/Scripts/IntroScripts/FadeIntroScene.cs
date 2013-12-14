using UnityEngine;
using System.Collections;

public class FadeIntroScene : MonoBehaviour
{
    public float pitchSpeed;
    public float delay;
    public GameObject enableAfterFade;

    void Start()
    {
        Invoke("StartPitchOut", delay);
        CameraFade.StartAlphaFade(Color.black, false, 30f, delay, () => { enableAfterFade.SetActive(true); });
    }
    public void StartPitchOut()
    {
        StartCoroutine("PitchOut");
       }

    IEnumerator PitchOut()
    {
        while (true)
        {
            yield return null;

            audio.pitch += Time.deltaTime * -pitchSpeed;
            if (audio.pitch <= 0)
                StopCoroutine("PitchOut");
        }

    }
}
