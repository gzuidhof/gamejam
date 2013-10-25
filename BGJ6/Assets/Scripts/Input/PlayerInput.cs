using UnityEngine;
using System.Collections;
using System;

public class PlayerInput : MonoBehaviour{

    public enum ControlScheme
    {
        Unspecified = -1, //All
        Computer = 0,
        XBOX360_1 = 1,
        XBOX360_2 = 2,
        XBOX360_3 = 3,
        XBOX360_4 = 4,
        Keyboard = 5,
    }

    public static GameObject defaultPlayerInputPrefab;

    public ControlScheme controlScheme = ControlScheme.Unspecified;

    public void changeControlScheme()
    {
        if ((int)controlScheme == 6)
        {
            controlScheme = ControlScheme.XBOX360_1;
        }
        else
        {
            controlScheme = (ControlScheme)((int)controlScheme + 1);
        }
    }

    public static PlayerInput GetDefaultPlayerInput()
    {
        if (GameObject.FindGameObjectWithTag("PlayerInput") == null)
            GameObject.Instantiate(Resources.Load("DefaultPlayerInput"));
        return GameObject.FindGameObjectWithTag("PlayerInput").GetComponent<PlayerInput>();
    }

    public float GetHorizontalInput()
    {
        if ((int)controlScheme >= 1 && (int)controlScheme < 5)
        {
            return GamePad.GetAxis(GamePad.Axis.LeftStick, (int)controlScheme).x;
        }
        else if (controlScheme == ControlScheme.Keyboard)
        {
            return (Convert.ToSingle(Input.GetKey(Bindings.Get(Bindings.Key.Right)))
                - Convert.ToSingle( Input.GetKey( Bindings.Get(Bindings.Key.Left) ) ));
        }
        else if (controlScheme == ControlScheme.Unspecified)
        {
            return GamePad.GetAxis(GamePad.Axis.LeftStick, 1).x +
                (Convert.ToSingle(Input.GetKey(Bindings.Get(Bindings.Key.Right)))
                - Convert.ToSingle(Input.GetKey(Bindings.Get(Bindings.Key.Left))));
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
            return (Convert.ToSingle(Input.GetKey(Bindings.Get(Bindings.Key.Forward)))
                - Convert.ToSingle(Input.GetKey(Bindings.Get(Bindings.Key.Backward))));
        }
        else if (controlScheme == ControlScheme.Unspecified)
        {
            return GamePad.GetAxis(GamePad.Axis.LeftStick, 1).y +
                (Convert.ToSingle(Input.GetKey(Bindings.Get(Bindings.Key.Forward)))
                - Convert.ToSingle(Input.GetKey(Bindings.Get(Bindings.Key.Backward))));
        }
        else
            return 0f;
    }

    Rect screenRect = new Rect(0, 0, Screen.width, Screen.height);

    //Returns Vector3 with facingdirection.
    public Vector3 GetFaceDirection(Transform from)
    {
        if ((int)controlScheme >= 1 && (int)controlScheme < 5)
        {
           // Debug.Log(GamePad.GetAxis(GamePad.Axis.RightStick, (int)controlScheme));
            Vector2 rs = GamePad.GetAxis(GamePad.Axis.RightStick, (int)controlScheme);
            return new Vector3(rs.x, 0f, rs.y);
        }
        else if (controlScheme == ControlScheme.Keyboard)
        {
            if (!screenRect.Contains(Input.mousePosition))
                return Vector3.zero;
            Debug.DrawRay(Camera.main.ScreenPointToRay(Input.mousePosition).origin, Camera.main.ScreenPointToRay(Input.mousePosition).direction * 100f, Color.yellow);

            RaycastHit h = new RaycastHit();
            Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out h);
            return (h.point - from.position).normalized;

        }
        return Vector3.zero;
    }



    public bool GetUseButton()
    {
        if ((int)controlScheme >= 1 && (int)controlScheme < 5)
        {
            return GamePad.GetButton(GamePad.Button.A, (int)controlScheme);
        }
        else if (controlScheme == ControlScheme.Keyboard)
        {
            return Input.GetKey(Bindings.Get(Bindings.Key.Use));
        }
        return false;
    }
}
