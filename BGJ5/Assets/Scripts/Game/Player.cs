using UnityEngine;
using System.Collections;
using System;

public class Player : MonoBehaviour {

    public enum ControlScheme
    {
        Unspecified = -1, //X360_1 + Keyboard combined input
        Computer = 0, //Computer controlled, TODO in code below if required
        XBOX360_1 = 1,
        XBOX360_2 = 2,
        XBOX360_3 = 3,
        XBOX360_4 = 4,
        Keyboard = 5,
    }

    public const string KEYBOARD_POSITIVE = "enter";
    public const string KEYBOARD_NEGATIVE = "escape";

    public int playerNumber = -1;
    public ControlScheme controlScheme;

    public void changeControlScheme() //Cycle through control schemes.
    {
        if ((int)controlScheme == 5)
        {
            controlScheme = ControlScheme.Unspecified;
        }
        else
        {
            controlScheme = (ControlScheme)((int)controlScheme + 1);
        }
    }

    public float GetHorizontalInput()
    {
        if ((int)controlScheme >= 1 && (int)controlScheme < 5)
        {
            return GamePad.GetAxis(GamePad.Axis.LeftStick, (int)controlScheme).x;
        }
        else if (controlScheme == ControlScheme.Keyboard)
        {
            return (Convert.ToSingle(Input.GetKey("d")) - Convert.ToSingle(Input.GetKey("a")));
        }
        else if (controlScheme == ControlScheme.Unspecified)
        {
            return GamePad.GetAxis(GamePad.Axis.LeftStick, 1).x +
                (Convert.ToSingle(Input.GetKey("d")) - Convert.ToSingle(Input.GetKey("a"))) +
                Convert.ToSingle(Input.GetKey("right")) - Convert.ToSingle(Input.GetKey("left"));
        }
            return 0f;
    }
    public float GetVerticalInput()
    {
        if ((int)controlScheme >= 1 && (int)controlScheme < 5)
        {
            return GamePad.GetAxis(GamePad.Axis.LeftStick, (int)controlScheme).y;
        }
        else if (controlScheme == ControlScheme.Keyboard)
        {
            return (Convert.ToSingle(Input.GetKey("w")) - Convert.ToSingle(Input.GetKey("s")));
        }
        else if (controlScheme == ControlScheme.Unspecified)
        {
            return GamePad.GetAxis(GamePad.Axis.LeftStick, 1).y +
                Convert.ToSingle(Input.GetKey("w")) - Convert.ToSingle(Input.GetKey("s"))
                + Convert.ToSingle(Input.GetKey("up")) - Convert.ToSingle(Input.GetKey("down"));
        }
        else
            return 0f;
    }

    public Vector3 GetFaceDirection()
    {
        if ((int)controlScheme >= 1 && (int)controlScheme < 5)
        {
			return GetControllerFaceDirection((int) controlScheme);
        }
        else if (controlScheme == ControlScheme.Keyboard)
        {
			//Debug ray that shows in scene view
            //Debug.DrawRay(Camera.main.ScreenPointToRay(Input.mousePosition).origin, Camera.main.ScreenPointToRay(Input.mousePosition).direction*100f, Color.yellow); 
            return GetMouseFaceDirection();
        }
		else if (controlScheme == ControlScheme.Unspecified) {
			return GetMouseFaceDirection() + GetControllerFaceDirection(1);
		}
		
        return Vector3.zero;
    }
	
	/// <summary> 
	/// Face direction of character by controller right stick (note: Y will always be 0).
    /// </summary> 
	private Vector3 GetControllerFaceDirection(int controllerNumber) 
	{
		Vector2 rs = GamePad.GetAxis(GamePad.Axis.RightStick, controllerNumber);
        return new Vector3(rs.x, 0f, rs.y) ;
	}
	
	/// <summary> 
	/// Face direction of character (looking at mouse ray intersection).
    /// </summary> 
	private Vector3 GetMouseFaceDirection() 
	{
		RaycastHit h = new RaycastHit();
        Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out h);
        return (h.point - transform.position).normalized;
	}


    public bool GetPositiveButton()
    {
        if ((int)controlScheme >= 1 && (int)controlScheme < 5)
        {
            return GamePad.GetButton(GamePad.Button.A, (int)controlScheme);
        }
        else if (controlScheme == ControlScheme.Keyboard)
        {
            return Input.GetKey(KEYBOARD_POSITIVE);
        }
		else if (controlScheme == ControlScheme.Unspecified)
        {
			return Input.GetKey(KEYBOARD_POSITIVE) || GamePad.GetButton(GamePad.Button.A, 1);
		}
        return false;
    }
    public bool GetNegativeButton()
    {
        if ((int)controlScheme >= 1 && (int)controlScheme < 5)
        {
            return GamePad.GetButton(GamePad.Button.B, (int)controlScheme);
        }
        else if (controlScheme == ControlScheme.Keyboard)
        {
            return Input.GetKey(KEYBOARD_NEGATIVE);
        }
		else if (controlScheme == ControlScheme.Unspecified)
        {
			return Input.GetKey(KEYBOARD_NEGATIVE) || GamePad.GetButton(GamePad.Button.B, 1);
		}
        return false;
    }

	/// <summary> 
	/// Positive button as a float
    /// </summary> 
    public float GetPositiveButtonF()
    {
        return Convert.ToSingle(GetPositiveButton());
    }
	
	/// <summary> 
	/// Negative button as a float
    /// </summary> 
    public float GetNegativeButtonF()
    {
        return Convert.ToSingle(GetNegativeButton());
    }
}
