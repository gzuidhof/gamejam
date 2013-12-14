using UnityEngine;
using System.Collections;

public class FadeRoomScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    CameraFade.StartAlphaFade(Color.black, true, 12f, 0f, () => gameObject.SetActive(false));
    }

}
