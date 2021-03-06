using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Stroke : MonoBehaviour
{

    public static Action<int, int, GameObject> OnClick = delegate { };
    public static Action<int, int, GameObject> OnChange = delegate { };
    public static Action OnClear = delegate { };

    private int i;

    private int j;

    public void OnMouseDown()
    {
        if (tag != "0" && tag != "3") 
        {
            if (GameObject.FindGameObjectsWithTag("3").Length == 0)
            {
                OnClick(i, j, gameObject);
            }
            else OnClear();
        }
        if (tag == "3") 
        {
            OnChange(i, j, gameObject);
        }
        if (tag == "0") 
        {
            OnClear();
        }

    }

    public void SetPosition(int a, int b) 
    {
        i = a;
        j = b;
    }

}
