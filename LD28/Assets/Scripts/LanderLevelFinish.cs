using UnityEngine;
using System.Collections;

public class LanderLevelFinish : MonoBehaviour {


    public GameObject rocket;
    public MusicFade music;
    public bool finished = false;

	void Update () {
        if (rocket.transform.position.x > transform.position.x && !finished)
        {
            Finish();
        }
	}

    public void Finish()
    {
        finished = true;
        CameraFade.StartAlphaFade(Color.black, false, 6f, 0f, () => { Application.LoadLevel("room"); });
        music.StartFade();
        Debug.Log("Game finished!");
    }
}
