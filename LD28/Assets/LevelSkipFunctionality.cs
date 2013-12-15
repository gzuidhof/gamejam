using UnityEngine;
using System.Collections;

public class LevelSkipFunctionality : MonoBehaviour {


    public static int attemptNumber;
    public int afterTries = 5;
    public GameObject toEnable;

    private static int lastLevel = -2;

    void Start()
    {

        if (lastLevel == Application.loadedLevel)
        {
            Debug.Log("level was loaded!");
            attemptNumber++;
        }
        else
        {
            lastLevel = Application.loadedLevel;
            attemptNumber = 1;
        }

        if (attemptNumber > afterTries)
            toEnable.SetActive(true);

    }
}
