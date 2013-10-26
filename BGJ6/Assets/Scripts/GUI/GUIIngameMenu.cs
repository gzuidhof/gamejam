using UnityEngine;
using System.Collections;

[RequireComponent (typeof(AudioSource))]
public class GUIIngameMenu : MonoBehaviour {


    public PlayerInput input;
    public GameObject credits;

    public AudioClip keymouse;
    public AudioClip x360;

    public void OnQuitButton()
    {
        Application.Quit();
    }

    public void OnInputButton()
    {
        input.ChangeControlScheme();
        audio.pitch = 1.3f;
        if (input.controlScheme == PlayerInput.ControlScheme.Keyboard)
            audio.PlayOneShot(keymouse);
        else if (input.controlScheme == PlayerInput.ControlScheme.XBOX360_1)
            audio.PlayOneShot(x360);


    }

    public void OnPlayButton()
    {
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
