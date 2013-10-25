using UnityEngine;
using System.Collections;



public static class GamePad
{

    public enum Button { A, B, Y, X, RightShoulder, LeftShoulder, RightStick, LeftStick, Back, Start }
    public enum Trigger { LeftTrigger, RightTrigger }
    public enum Axis { LeftStick, RightStick, Dpad }

	public static bool GetButtonDown(Button button, int controller)
    {
        if (controller < 1 || controller > 4)
        {
            Debug.Log("Invalid Controller: " + controller);
            return false;
        }
     
        string buttonName = GetButtonName(button) + "_" + controller;
        return Input.GetButtonDown(buttonName);
    }

    public static bool GetButtonUp(Button button, int controller)
    {
        if (controller < 1 || controller > 4)
        {
            Debug.Log("Invalid Controller: " + controller);
            return false;
        }

        string buttonName = GetButtonName(button) + "_" + controller;
        return Input.GetButtonUp(buttonName);
    }

    public static bool GetButton(Button button, int controller)
    {
        if (controller < 1 || controller > 4)
        {
            Debug.Log("Invalid Controller: " + controller);
            return false;
        }

        string buttonName = GetButtonName(button) + "_" + controller;
        return Input.GetButton(buttonName);
    }

    /// <summary>
    /// returns a specified axis
    /// </summary>
    /// <param name="axis">One of the analogue sticks, or the dpad</param>
    /// <param name="controller">The controller number between 1 and 4</param>
    /// <param name="raw">if raw is false then the controller will be returned with a deadspot</param>
    /// <returns></returns>
    public static Vector2 GetAxis(Axis axis, int controller, bool raw = false)
    {
        if (controller < 1 || controller > 4)
        {
            Debug.Log("Invalid Controller: " + controller);
            return Vector3.zero;
        }

        string xName = "", yName = "";
        switch (axis)
        {
            case Axis.Dpad:
                xName = "DPad_XAxis_" + controller;
                yName = "DPad_YAxis_" + controller;
                break;
            case Axis.LeftStick:
                xName = "L_XAxis_" + controller;
                yName = "L_YAxis_" + controller;
                break;
            case Axis.RightStick:
                xName = "R_XAxis_" + controller;
                yName = "R_YAxis_" + controller;
                break;
        }

        Vector2 axisXY = Vector3.zero;

        if (raw == false)
        {
            axisXY.x = Input.GetAxis(xName);
            axisXY.y = -Input.GetAxis(yName);
        }
        else
        {
            axisXY.x = Input.GetAxisRaw(xName);
            axisXY.y = -Input.GetAxisRaw(yName);
        }
        return axisXY;
    }

    public static float GetTrigger(Trigger trigger, int controller, bool raw = false)
    {
        if (controller < 1 || controller > 4)
        {
            Debug.Log("Invalid Controller: " + controller);
            return 0;
        }

        //
        string name = "";
        if (trigger == Trigger.LeftTrigger)
            name = "TriggersL_" + controller;
        else if (trigger == Trigger.RightTrigger)
            name = "TriggersR_" + controller;

        //
        float axis = 0;
        if (raw == false)
            axis = Input.GetAxis(name);
        else
            axis = Input.GetAxisRaw(name);

        return axis;
    }

    static string GetButtonName(Button button)
    {

        switch(button)
        {
            case Button.A: return "A"; 
            case Button.B: return "B"; 
            case Button.X: return "X"; 
            case Button.Y: return "Y";
            case Button.RightShoulder: return "RB";
            case Button.LeftShoulder: return "LB";
            case Button.Start: return "Start";
            case Button.Back: return "Back"; 
            case Button.RightStick: return "RS"; 
            case Button.LeftStick: return "LS"; 
            default: Debug.Log("Button has not been added " + button); break;
        }
        return "";
    }

    public static GamepadPadState GetState(int controller, bool raw = false)
    {
        GamepadPadState state = new GamepadPadState();
        if (controller < 1 || controller > 4)
        {
            Debug.Log("Invalid Controller: " + controller + ". Index must lie between 1 and 4");
            return state;
        }

        state.A = GetButton(Button.A, controller);
        state.B = GetButton(Button.B, controller);
        state.Y = GetButton(Button.Y, controller);
        state.X = GetButton(Button.X, controller);

        state.RightShoulder = GetButton(Button.RightShoulder, controller);
        state.LeftShoulder = GetButton(Button.LeftShoulder, controller);
        state.RightStick = GetButton(Button.RightStick, controller);
        state.LeftStick = GetButton(Button.LeftStick, controller);

        state.Start = GetButton(Button.Start, controller);
        state.Back = GetButton(Button.Back, controller);

        state.LeftStickAxis = GetAxis(Axis.LeftStick, controller, raw);
        state.rightStickAxis = GetAxis(Axis.RightStick, controller, raw);
        state.dPadAxis = GetAxis(Axis.Dpad, controller, raw);

        state.Left = (state.dPadAxis.x < 0);
        state.Right = (state.dPadAxis.x > 0);
        state.Up = (state.dPadAxis.y > 0);
        state.Down = (state.dPadAxis.y < 0);

        state.LeftTrigger = GetTrigger(Trigger.LeftTrigger, controller, raw);
        state.RightTrigger = GetTrigger(Trigger.RightTrigger, controller, raw);
        
        return state;
    }

}

public class GamepadPadState
{
    public bool A = false;
    public bool B = false;
    public bool X = false;
    public bool Y = false;
    public bool Start = false;
    public bool Back = false;
    public bool Left = false;
    public bool Right = false;
    public bool Up = false;
    public bool Down = false;
    public bool LeftStick = false;
    public bool RightStick = false;
    public bool RightShoulder = false;
    public bool LeftShoulder = false;

    public Vector2 LeftStickAxis = Vector2.zero;
    public Vector2 rightStickAxis = Vector2.zero;
    public Vector2 dPadAxis = Vector2.zero;

    public float LeftTrigger = 0;
    public float RightTrigger = 0;

}
