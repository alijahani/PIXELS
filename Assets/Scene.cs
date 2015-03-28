using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Scene : MonoBehaviour
{
    public static List<Sprite> Sprites;
    public GameObject L, R, sPixels;
    public SpriteRenderer srL, srR, srLs, srRs;
    public GUISkin Skin;
    public Texture t1, t2, Cam;
    private float time = 0, sTime;
    private int Score = 0;
    private bool IsEnded = false;

    // Use this for initialization
    void Start()
    {
        Helper.FeelL();
        Sprites = Helper.LoadSprites();
        LevelControl.RanFeel(0);
    }

    // Update is called once per frame
    void Update()
    {
        srL.sprite = LevelControl.Ls;
        srR.sprite = LevelControl.Rs;
        if (!IsEnded)
            Score += LevelControl.GetScore(L, R);
        sTime = UnityEngine.Time.timeSinceLevelLoad;
        if (sTime < 51)
            time = 51 - sTime;
        if ((int)time == 0 && !IsEnded)
        {
            IsEnded = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel("Start");
        }
    }

    void OnGUI()
    {
        GUI.skin = Skin;
        string str;
        if (!IsEnded)
        {
            str = ((int)time).ToString() + '\n' + Score;
            if (GUI.Button(new Rect(0, 0, 50, 50), t1))
                Application.LoadLevel("Scene");
            if (GUI.Button(new Rect(50, 0, 50, 50), t2))
                Application.LoadLevel("Start");
        }
        else
        {
            str = "Your Score:\n" + Score;

            if (GUI.Button(new Rect(10, Screen.height - 110, 150, 100), "Play again"))
                Application.LoadLevel("Scene");
            if (GUI.Button(new Rect(170, Screen.height - 110, 150, 100), "Menu"))
                Application.LoadLevel("Start");
            //if (GUI.Button(new Rect(330, Screen.height - 60, 50, 50), Fb))
            //if (GUI.Button(new Rect(390, Screen.height - 60, 50, 50), Gp))
            //if (GUI.Button(new Rect(450, Screen.height - 60, 50, 50), Tw))

            if (GUI.Button(new Rect(330, Screen.height - 110, 100, 100), Cam))
            {
                string text = Application.persistentDataPath + "/" + Score.ToString() + ".png";
                if (Application.platform == RuntimePlatform.Android)
                {
                    Application.CaptureScreenshot("/../../../../DCIM/Camera/" + Score.ToString() + ".png" );
                    Application.OpenURL(Application.persistentDataPath + "/../../../../DCIM/Camera/" + Score.ToString() + ".png");
                }
                else if (Application.isWebPlayer)
                {
                    StartCoroutine(Helper.PngWebPage());
                }
                else
                {
                    Application.CaptureScreenshot(text);
                    Application.OpenURL(text);
                }
            }
        }

        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 250, 200, 500), str);

    }
}
