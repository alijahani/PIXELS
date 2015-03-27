using UnityEngine;
using System.Collections;

public class sPixels : MonoBehaviour
{
    public SpriteRenderer srLs, srRs;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int k = ((int)UnityEngine.Time.timeSinceLevelLoad) / 10;
        if (k < 4)
        {
            srLs.sprite = Scene.Sprites[Helper.L[k]];
            srRs.sprite = Scene.Sprites[Helper.R[k]];
        }
        if (UnityEngine.Time.timeSinceLevelLoad < 40)
            this.gameObject.transform.position = new Vector3(0, Mathf.Tan(UnityEngine.Time.timeSinceLevelLoad * 3.14f / 10 + 3.14f / 2) / 15);
        else
            this.gameObject.transform.position = new Vector3(0, 10);
    }

}
