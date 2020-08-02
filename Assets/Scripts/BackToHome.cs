using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;



public class BackToHome : MonoBehaviour
{

    Button btn;
    // Start is called before the first frame update
    void Start()
    {
        btn = this.gameObject.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        Basic.ARCanvas.SetActive(false);
        Basic.HomeCanvas.SetActive(true);
        Basic.SetHomeBloodStripText();
        Basic.SetHomeBloodStrip();
        CalendarSetting.UpdateCalender();


        Basic.SetHomeBloodStrip2();
        Basic.UpdateHomeBar2Text();
        //update calender
    }
    
}
