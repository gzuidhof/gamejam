using UnityEngine;
using System.Collections;

public class Decoupler : MonoBehaviour {

    private SpriteRenderer sRenderer;
    private ParticleSystem part;

    void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
        part = GetComponent<ParticleSystem>();
    }

    public void Decouple()
    {
        part.Play();
        sRenderer.enabled = false;
        if (audio)
            audio.Play();
    }

}
