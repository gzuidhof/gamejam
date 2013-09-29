using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Progress : MonoBehaviour {


    /// <summary>
    /// Sound played when a new step is reached.
    /// </summary>
    public AudioClip pointSound;

    /// <summary>
    /// Sound played when game is done due to victory.
    /// </summary>
    public AudioClip victorySound;

    public List<GameObject> steps;
    public GameObject finishText;

    public int nextToBeAchieved = 0;
    public static Progress instance;
    public bool gameFinished = false;

    void Awake()
    {
        instance = this;
    }

    public void IAmNowHere(Vector3 pos, int playerNumber)
    {
        if (!gameFinished && pos.y > steps[nextToBeAchieved].transform.position.y + 0.4f)
        {
            //Add points to the player who reached the line.
            ChainJam.AddPoints((ChainJam.PLAYER)(playerNumber - 1), 1);

            //Color the line
            steps[nextToBeAchieved].renderer.material.color = Color.yellow;

            //Play point sound
            audio.PlayOneShot(pointSound);
            nextToBeAchieved++;
            
            //Reached the last step
            if (nextToBeAchieved > steps.Count - 1)
            {
                gameFinished = true;
                audio.PlayOneShot(victorySound);
                finishText.SetActive(true);
            } 
        }
    }

    public IEnumerable endgameSoon()
    {
        // Wait for 3 seconds
        yield return new WaitForSeconds(3f);
        ChainJam.GameEnd();
        

    }

}
