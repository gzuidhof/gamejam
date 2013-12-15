using UnityEngine;
using System.Collections;

public class FadeAndLoadLevel : MonoBehaviour {

    public string levelName;

    public void Play()
    {
        CameraFade.StartAlphaFade(Color.black, false, 8f, 0f, () => { Application.LoadLevel(levelName); });
    }
}
