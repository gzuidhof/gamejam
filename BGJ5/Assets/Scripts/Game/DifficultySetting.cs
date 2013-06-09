using UnityEngine;
using System.Collections;

public enum Difficulty
{
    Normal,
    Easy,
    Tryhard
}

public class DifficultySetting : MonoBehaviour {

    public Difficulty difficulty;


    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.transform.root.gameObject.tag == "Player")
        {

                Debug.Log("Difficulty: " + difficulty);
                if (difficulty == Difficulty.Easy)
                {
                    GameManager.instance.EasyMode();
                }
                else if (difficulty == Difficulty.Normal)
                {
                    GameManager.instance.NormalMode();
                }
                else
                {
                    GameManager.instance.HardMode();
                }
        }
    }

}
