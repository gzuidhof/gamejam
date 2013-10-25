using UnityEngine;
using System.Collections;





/// <summary>
/// Simple bindings class, that reads and writes the settings to a file.
/// </summary>
public class Bindings : MonoBehaviour
{

    private string settingsFilePath = "Settings/bindings.ini";
    private string settingsDirectory = "Settings";
    private static Bindings instance;


    /// <summary>
    /// The DEFAULT binds, in order of the Keys.
    /// </summary>
    private KeyCode[] binds = 
        {KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D, 
        KeyCode.Mouse0,
        KeyCode.E,
        KeyCode.Escape};

    public enum Key //An action of sorts, a binding
    {
        Forward = 0, Backward, Left, Right,
        Fire, 
         Use,
        Menu
    }


    void Start()
    {
        if (instance)
        {
            Debug.LogError("Bindings instance already present! This should be singleton, this instance will be destroyed.");
            Destroy(this);
            return;
        }
        instance = this;

        Init();



    }

    /// <summary>
    /// Load Settings
    /// </summary>
    private void Init()
    {
        ReadFromFile(); //Read all settings from the file.

        WriteToFile(); //This will write the read options and options that are new to the file (with default values).
    }

    private KeyCode GetBinding(Bindings.Key key)
    {
        return binds[(int)key];
    }


    /// <summary>
    /// Get a keybinding with a certain key.
    /// Example usage: Input.GetKey( Bindings.Get(Bindings.Key.Fire) );
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public static KeyCode Get(Bindings.Key key)
    {

        if (!instance) Debug.LogError("No Bindings script present in the scene!");

        //Remove this line if you are not using NGUI, this line disables input if NGUI has focus. 
        //So for example when you type W in a chatwindow, your character doesn't move forward.
        if (UICamera.inputHasFocus) return KeyCode.None;


        return instance.GetBinding(key);
    }
    /// <summary>
    /// Match string to a keycode, if none found returns KeyCode.None
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static KeyCode StringToKeyCode(string s)
    {
        KeyCode r = KeyCode.None;
        try
        {
            r = (KeyCode)System.Enum.Parse(typeof(KeyCode), s, true);
        }
        catch (System.Exception e)
        {
            Debug.LogException(e);
        }
        return r;
    }


    /// <summary>
    /// Parse a line from the file
    /// </summary>
    /// <param name="s"></param>
    private void ParseOptionLine(string s)
    {
        string[] ss = s.Split('=');
        if (ss.Length < 1) return; //Silently ignore this line, there is no "=" in it..

        try
        {
            Key k = (Key)System.Enum.Parse(typeof(Key), ss[0], true);
            KeyCode kc = StringToKeyCode(ss[1]);
            binds[(int)k] = kc;

        }
        catch (System.Exception)
        {
            return; //Ignore this faulty line.
        }

    }

    /// <summary>
    /// Generate a line, ready to be printed to a file.
    /// </summary>
    /// <param name="kc"></param>
    private string GetOptionLine(Key k)
    {
        return k.ToString() + "=" + binds[(int)k];
    }

    /// <summary>
    /// Write current bindings to a file
    /// </summary>
    public void WriteToFile()
    {

        // Create StreamWriter
        try
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(settingsFilePath);

            //Write every option-line to the file
            for (int i = 0; i < System.Enum.GetValues(typeof(Key)).Length; i++)
            {
                file.WriteLine(GetOptionLine((Key)i));
            }
            file.Close();
        }
        catch (System.Exception e)
        {
            //Maybe notify the user that something went wrong writing to the file!
            Debug.LogException(e);
        }

    }

    /// <summary>
    /// Read settings from a file.
    /// </summary>
    public void ReadFromFile()
    {
        try
        {
            //Create the directory if it doesn't exist.
            System.IO.Directory.CreateDirectory(settingsDirectory);

            //Create the file if it doesn't exist.
            if (!System.IO.File.Exists(settingsFilePath))
            {
                using (System.IO.FileStream fs = System.IO.File.Create(settingsFilePath))
                {
                    //We aren't actually writing anything to the file.
                }

            }


            // Create an instance of StreamReader to read from a file. 
            // The using statement also closes the StreamReader. 
            using (System.IO.StreamReader sr = new System.IO.StreamReader(settingsFilePath))
            {
                string line;
                // Parse lines from the file until the end of the file is reached. 
                while ((line = sr.ReadLine()) != null)
                {
                    ParseOptionLine(line);
                }
            }
        }
        catch (System.Exception e)
        {
            // Let the user know what went wrong.
            Debug.LogError("The file could not be read:" + e.Message);
        }

    }



}
