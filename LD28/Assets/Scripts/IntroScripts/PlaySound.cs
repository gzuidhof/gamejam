using UnityEngine;
using System.Collections;

/// <summary>
/// component 'PlaySound'
/// ADD COMPONENT DESCRIPTION HERE
/// </summary>
[AddComponentMenu("Scripts/PlaySound")]
public class PlaySound : MonoBehaviour
{

    public AudioClip sound;

    public void Play()
    {
        audio.PlayOneShot(sound);
    }

}
