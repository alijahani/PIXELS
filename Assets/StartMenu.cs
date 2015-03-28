using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour
{
    public GUISkin Skin;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void OnGUI()
    {
        GUI.skin = Skin;

        if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 50), "Start"))
            Application.LoadLevel("Scene");

        if (!Application.isWebPlayer)
            if (GUI.Button(new Rect(10, Screen.height - (Screen.width / 12 + 10), Screen.width / 6, Screen.width / 12), "Exit"))
                Application.Quit();
    }
}
