using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class getTime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        print("get time");
        //setTime();
    }


    string temp = "";
    // Update is called once per frame
    void Update()
    {
        //double timestamp = (DateTime.Now.AddHours(-8) - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;
        ////print(timestamp.ToString("#0"));
        //if (temp == ""){
        //    temp = timestamp.ToString("#0");
        //}else if(Int32.Parse(timestamp.ToString("#0")) - Int32.Parse(temp) >=30){
        //    print("after 30s");
        //    temp = timestamp.ToString("#0");
        //}


    }

    // 計算距離上次喝水多久
    public static double count(int num){
        double now = (DateTime.Now.AddHours(-8) - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;
        int lastTime = Int32.Parse(PlayerPrefs.GetString("lastTime_" + num.ToString(), "0"));

        return now-lastTime;
    }

    public static void setTime(int num)
    {
        double timestamp = (DateTime.Now.AddHours(-8) - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;
        PlayerPrefs.SetString("lastTime_" + num.ToString(), timestamp.ToString("#0"));
    } 

    //判斷時間是否超過30min
    public static bool checkShow(int num){
        
        double now = (DateTime.Now.AddHours(-8) - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;
        
        int lastTime = Int32.Parse(PlayerPrefs.GetString("lastTime_" + num.ToString(),"0"));
        
        // 30 * 60 =>30 min
        if (now - lastTime >= 30 * 60){
            print("return true");
            return true;
        }
        print("return false");
        return false;
    }

    public static void setTimeDrinkingFountain()
    {
        double timestamp = (DateTime.Now.AddHours(-8) - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;
        PlayerPrefs.SetString("lastTimeDrinkingFountain", timestamp.ToString("#0"));
    }


    public static bool checkShowDrinkingFountain(){
        double now = (DateTime.Now.AddHours(-8) - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;
        int lastTime = Int32.Parse(PlayerPrefs.GetString("lastTimeDrinkingFountain","0"));

        // 30 * 60 =>30 min
        if (now - lastTime >= 30*60)
        {
            return true;
        }

        return false;
    }
}
