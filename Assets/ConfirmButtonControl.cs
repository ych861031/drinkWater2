using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmButtonControl : MonoBehaviour
{
    public static GameObject comBtn;
    // Start is called before the first frame update
    void Start()
    {
        comBtn = GameObject.Find("ConfirmButton");
        Hide();
    }

    public static void Show()
    {
        comBtn.SetActive(true);
    }

    public static void Hide()
    {
        comBtn.SetActive(false);
    }
}
