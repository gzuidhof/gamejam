using UnityEngine;
using System.Collections;

[RequireComponent (typeof(AudioSource))]
public class GUIIngameMenu : MonoBehaviour {


    public PlayerInput input;
    public GameObject credits;

    public AudioClip keymouse;
    public AudioClip x360;

    public PlayerMovementMotor motor;
    public AudioSource music;

    public void OnQuitButton()
    {
        Application.Quit();
    }

    public void OnMusic()
    {
        if (music.volume > 0f)
            music.volume = 0f;
        else music.volume = 0.15f;

    }

    public void OnPlayButton()
    {
        motor.enabled = true;
        gameObject.SetActive(false);
    }

    public void OnCreditsButton()
    {

        if (credits)
        {
            gameObject.SetActive(false);
            credits.SetActive(true);
        }
    }

}
