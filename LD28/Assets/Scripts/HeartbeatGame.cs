using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]
public class HeartbeatGame : MonoBehaviour {

    public GameObject disableUI;
    public GameObject enableAstronaut;
    public float oxygen = 1f;
    public float oxygenDepletion = 0.05f;
    public float hitDamage = 0.1f;
    public float beatOxygen = 0.25f;
    public UISlider slider;

    public bool ended = false;
    public AudioClip hitSound;

    void UpdateUI()
    {
        slider.value = oxygen;
    }

    void Update()
    {
        oxygen -= oxygenDepletion * Time.deltaTime;
        UpdateUI();

        if (oxygen <= 0.1f && !ended)
        {
            CameraFade.StartAlphaFade(Color.black, false, 8f, 0f, () => { Application.LoadLevel("outro"); });
            Camera.main.GetComponent<MusicFade>().StartFade();
            ended = true;
        }

    }

    public void StartGame()
    {
        disableUI.SetActive(false);
        enableAstronaut.SetActive(true);
    }

    public void Hit()
    {
        audio.PlayOneShot(hitSound);
        oxygen -= hitDamage;
        UpdateUI();
    }

    public void Beat()
    {
        
        oxygen += beatOxygen;
        if (oxygen >= 1f) oxygen = 1f;
        UpdateUI();
    }


}
