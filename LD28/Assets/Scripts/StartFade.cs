using UnityEngine;
using System.Collections;

public class StartFade : MonoBehaviour {

    public MusicFade musicFade;
    public bool fadeIn;

    void OnEnable()
    {
        musicFade.fadeIn = fadeIn;
        if (fadeIn)
            musicFade.goalVolume = 1f;
        else
            musicFade.goalVolume = 0f;
        musicFade.StartFade();
    }
}
