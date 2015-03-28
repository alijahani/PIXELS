using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class LevelControl
{
    public static bool L;
    public static Sprite Ls, Rs;

    public static void RanL()
    {
        L = UnityEngine.Random.Range(0, 2) == 0 ? true : false;
    }

    public static void RanFeel(int Level)
    {
        RanL();
        if (L)
        {
            Ls = Scene.Sprites[Helper.L[UnityEngine.Random.Range(0, Level)]];
            Rs = Scene.Sprites[Helper.L[UnityEngine.Random.Range(0, Level)]];
        }
        else
        {
            Ls = Scene.Sprites[Helper.R[UnityEngine.Random.Range(0, Level)]];
            Rs = Scene.Sprites[Helper.R[UnityEngine.Random.Range(0, Level)]];
        }
    }

    public static int GetScore(GameObject Lo, GameObject Ro)
    {
        int Level = (int)UnityEngine.Time.timeSinceLevelLoad / 10 + 1;
        if (Level > 4)
                Level = 4;
        bool pL = L;

        if (Helper.IsClicked(Lo))
        {
            RanFeel(Level);
            if (pL)
                return 1;
            else
                return -1;
        }

        if (Helper.IsClicked(Ro))
        {
            RanFeel(Level);
            if (pL)
                return -1;
            else
                return 1;
        }

        return 0;
    }

}
