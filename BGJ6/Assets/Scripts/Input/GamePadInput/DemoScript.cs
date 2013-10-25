using UnityEngine;
using System.Collections;

public class DemoScript : MonoBehaviour
{
    /*
    void Examples()
    {
        
        GamePad.GetButtonDown(GamePad.Button.A, 1);
        GamePad.GetAxis(GamePad.Axis.LeftStick, 1);
        GamePad.GetTrigger(GamePad.Trigger.RightTrigger, 1);
        GamepadPadState state = GamePad.GetState(1);
        
    }*/

    void OnGUI()
    {
        DrawLabels();

        for (int i = 1; i < 5; i++)
            DrawState(i);
    }

    void DrawState( int controller)
    {
        float width = Screen.width / 5;
        GUILayout.BeginArea(new Rect(width * controller, 0, width, Screen.height));

        GamepadPadState state = GamePad.GetState(controller);

        // buttons
        GUILayout.Label("Controller " + controller);
        GUILayout.Label("" + state.A);
        GUILayout.Label("" + state.B);
        GUILayout.Label("" + state.X);
        GUILayout.Label("" + state.Y);
        GUILayout.Label("" + state.Start);
        GUILayout.Label("" + state.Back);
        GUILayout.Label("" + state.LeftShoulder);
        GUILayout.Label("" + state.RightShoulder);
        GUILayout.Label("" + state.Left);
        GUILayout.Label("" + state.Right);
        GUILayout.Label("" + state.Up);
        GUILayout.Label("" + state.Down);
        GUILayout.Label("" + state.LeftStick);
        GUILayout.Label("" + state.RightStick);

        GUILayout.Label("");

        // triggers
        GUILayout.Label("" + state.LeftTrigger);
        GUILayout.Label("" + state.RightTrigger);

        GUILayout.Label("");

        // Axes
        GUILayout.Label("" + state.LeftStickAxis);
        GUILayout.Label("" + state.rightStickAxis);
        GUILayout.Label("" + state.dPadAxis);
        

        GUILayout.EndArea();

    }

    void DrawLabels()
    {
        float width = Screen.width / 5;
        GUILayout.BeginArea(new Rect(30, 0, width - 30, Screen.height));


        // buttons
        GUILayout.Label("Controller index");
        GUILayout.Label("A");
        GUILayout.Label("B");
        GUILayout.Label("X");
        GUILayout.Label("Y");
        GUILayout.Label("Start");
        GUILayout.Label("Back");
        GUILayout.Label("LeftShoulder");
        GUILayout.Label("RightShoulder");
        GUILayout.Label("Left");
        GUILayout.Label("Right");
        GUILayout.Label("Up");
        GUILayout.Label("Down");
        GUILayout.Label("LeftStick");
        GUILayout.Label("RightStick");

        GUILayout.Label("");

        GUILayout.Label("LeftTrigger");
        GUILayout.Label("RightTrigger");

        GUILayout.Label("");

        GUILayout.Label("LeftStickAxis");
        GUILayout.Label("rightStickAxis");
        GUILayout.Label("dPadAxis");

        GUILayout.EndArea();

    }
}
