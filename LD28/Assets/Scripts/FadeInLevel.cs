using UnityEngine;
using System.Collections;

public class FadeInLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
        CameraFade.StartAlphaFade(Color.black, true, 16f, 0f);
	}
	
}
