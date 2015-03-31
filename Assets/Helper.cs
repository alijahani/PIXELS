using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;

public class Helper
{
    private static bool[] LR = new bool[8];
    public static List<int> L = new List<int>();
    public static List<int> R = new List<int>();

    public static void FeelL()
    {
        List<int> t = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7 };
        LR = new bool[8];
        L.Clear();
        for (int i = 0; i < 4; i++)
        {
            int k = UnityEngine.Random.Range(0, t.Count);
            LR[k] = true;
            Console.Write(k);
            L.Add(k);
            t.Remove(k);
        }
        R = t;
    }

    public static bool IsL(int i)
    {
        if (LR[i] == true)
            return true;
        return false;
    }

    public static string GetString(int i)
    {
        return "Sprites/Enem" + i.ToString();
    }

    public static List<Sprite> LoadSprites()
    {
        List<Sprite> Sprites = new List<Sprite>();
        for (int i = 1; i <= 8; i++)
        {
            Sprites.Add(Resources.Load<Sprite>(GetString(i)));
        }
        return Sprites;
    }

    public static bool IsClicked(GameObject g)
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(position, Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == g)
            {
                return true;
            }
        }
        return false;
    }

    public static IEnumerator PngWebPage()
    {
        yield return new WaitForEndOfFrame();

        Texture2D Tex = new Texture2D(Screen.width, Screen.height);
        Tex.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        Tex.Apply();

        Application.ExternalCall("SH", System.Convert.ToBase64String(Tex.EncodeToPNG()));

/*
*       In the HTML Page:
* 		
*       function SH(base64) 
*       {
*	        window.open("data:image/png;base64," + base64);
*       }
*
*/
    }

}
