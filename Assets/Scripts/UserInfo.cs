using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class UserInfo : MonoBehaviour
{
    static float weight;
    static int drink;

    static GameObject WeightPlaceholder;
    static GameObject DrinkPlaceholder;
    static GameObject WeightText;
    static GameObject DrinkText;
    static GameObject BottleText;
    static GameObject BottlePlaceholder;


    static GameObject[] tree1;
    static GameObject[] tree2;
    static GameObject[] tree3;
    static GameObject[] tree4;


    // Start is called before the first frame update
    void Start()
    {
        WeightPlaceholder = GameObject.Find("WeightPlaceholder");
        DrinkPlaceholder = GameObject.Find("DrinkPlaceholder");
        WeightText = GameObject.Find("WeightInputField");
        DrinkText = GameObject.Find("DrinkInputField");

        BottleText = GameObject.Find("BottleInputField");
        BottlePlaceholder = GameObject.Find("BottlePlaceholder");

        var date = GetDate();

        //測試時重設數據用
        //PlayerPrefs.SetInt(date + "DrinkScore", 0);

        //default calendaer use image level
        PlayerPrefs.SetInt("201981" + "DrinkScoreLevel", 2);
        PlayerPrefs.SetInt("201983" + "DrinkScoreLevel", 4);
        PlayerPrefs.SetInt("201988" + "DrinkScoreLevel", 1);
        PlayerPrefs.SetInt("2019815" + "DrinkScoreLevel", 3);
        PlayerPrefs.SetInt("2019818" + "DrinkScoreLevel", 2);
        PlayerPrefs.SetInt("2019819" + "DrinkScoreLevel", 4);
        PlayerPrefs.SetInt("2019825" + "DrinkScoreLevel", 1);
        PlayerPrefs.SetInt("2019831" + "DrinkScoreLevel", 3);


        UpdateInfo();

        tree1 = new GameObject[6];
        tree2 = new GameObject[6];
        tree3 = new GameObject[6];
        tree4 = new GameObject[6];


        print("!!!!!!!!!!!!");
        //Tree object
        for (int i = 1; i <= 6; i++)
        {
            tree1[i-1] = GameObject.Find("樹01_" + i.ToString());
            tree2[i-1] = GameObject.Find("樹02_" + i.ToString());
            tree3[i-1] = GameObject.Find("樹03_" + i.ToString());
            tree4[i-1] = GameObject.Find("樹04_" + i.ToString());
        }
        

        SetARTree();
    }

    public static void SetInfo()
    {
        print("set");
        var weightText = WeightText.GetComponent<InputField>().text;
        var drinkText = DrinkText.GetComponent<InputField>().text;
        var bottleText = BottleText.GetComponent<InputField>().text;
        print(weightText);
        print(drinkText);
        print(bottleText);

        if(weightText != "")
        {
            PlayerPrefs.SetFloat("playerWeight", float.Parse(weightText));
        }

        if (drinkText != "")
        {
            PlayerPrefs.SetInt("playerDrink", int.Parse(drinkText));
        }

        if(bottleText != ""){
            PlayerPrefs.SetInt("playerBottle", int.Parse(bottleText));
        }
        
    }

    static string GetDate()
    {
        return DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString();
    }

    public static void UpdateInfo()
    {
        print("Update...");

        weight = PlayerPrefs.GetFloat("playerWeight", 60);
        print(weight);
        WeightPlaceholder.GetComponent<Text>().text = weight.ToString() + "kg";

        drink = PlayerPrefs.GetInt("playerDrink", 200);
        print(drink);

        DrinkPlaceholder.GetComponent<Text>().text = drink.ToString() + "cc";

        BottlePlaceholder.GetComponent<Text>().text = PlayerPrefs.GetInt("playerBottle", 400).ToString() + "cc";

        //Clear input text
        WeightText.GetComponent<InputField>().text = "";
        DrinkText.GetComponent<InputField>().text = "";
        BottleText.GetComponent<InputField>().text = "";

    }

    public static float GetTotalDrink()
    {
        var weight = PlayerPrefs.GetFloat("playerWeight", 60);

        return weight * 30;
    }

    public static string GetDrinkScoreStr()
    {
        var date = GetDate();
        var score = PlayerPrefs.GetInt(date + "DrinkScore", 0);
        string str = score.ToString() + "/" + GetTotalDrink().ToString();

        return str;
    }

    public static int GetDrinkScore()
    {
        var date = GetDate();
        var score = PlayerPrefs.GetInt(date + "DrinkScore", 0);
       

        return score;
    }

    public static void AddDrinkScore()
    {
        var date = GetDate();
        var addScore = PlayerPrefs.GetInt("playerDrink", 200);
        var score = PlayerPrefs.GetInt(date + "DrinkScore", 0);
        PlayerPrefs.SetInt(date + "DrinkScore", score + addScore);

        //set level
        score = PlayerPrefs.GetInt(date + "DrinkScore", 0);
        if (score<=800 && score >0)
        {
            PlayerPrefs.SetInt(date + "DrinkScoreLevel", 1);
        }
        if (score <= 1600 && score > 800)
        {
            PlayerPrefs.SetInt(date + "DrinkScoreLevel", 2);
        }
        if (score <= 2000 && score > 1600)
        {
            PlayerPrefs.SetInt(date + "DrinkScoreLevel", 3);
        }
        if (score >= 2000)
        {
            PlayerPrefs.SetInt(date + "DrinkScoreLevel", 4);
        }

        Basic.SetARBloodStripText();
        bloodstrip.SetBloodStrip();

    }

    

    public static void SetARTree()
    {
        var t = GetTotalDrink();
        var s = GetDrinkScore();
        var user_blood = s / t;
        var temp = 0;
        int scanNum = 1;


        if (user_blood < 0.3)
        {
           
            tree1[scanNum].SetActive(true);
            tree2[scanNum].SetActive(false);
            tree3[scanNum].SetActive(false);
            tree4[scanNum].SetActive(false);



            temp = 1;


        }
        else if(user_blood < 0.5)
        {

            tree1[scanNum].SetActive(false);
            tree2[scanNum].SetActive(true);
            tree3[scanNum].SetActive(false);
            tree4[scanNum].SetActive(false);
            temp = 2;

        }
        else if(user_blood < 0.9)
        {

            tree1[scanNum].SetActive(false);
            tree2[scanNum].SetActive(false);
            tree3[scanNum].SetActive(true);
            tree4[scanNum].SetActive(false);
            temp = 3;
        }
        else
        {

            tree1[scanNum].SetActive(false);
            tree2[scanNum].SetActive(false);
            tree3[scanNum].SetActive(false);
            tree4[scanNum].SetActive(true);
            temp = 4;
        }


        var time = getTime.count();
        float test = 0;
        if (time >= 1800){
            test = (float)(time / 1800);
            if(test>=2){

                tree1[scanNum].SetActive(true);
                tree2[scanNum].SetActive(false);
                tree3[scanNum].SetActive(false);
                tree4[scanNum].SetActive(false);
            }
            else if(test>=3){

                tree1[scanNum].SetActive(false);
                tree2[scanNum].SetActive(true);
                tree3[scanNum].SetActive(false);
                tree4[scanNum].SetActive(false);

            }
            else{
                tree1[scanNum].SetActive(false);
                tree2[scanNum].SetActive(false);
                tree3[scanNum].SetActive(true);
                tree4[scanNum].SetActive(false);
            }
        }

    }

    public static void SetDrinkingFountain(){
        print("set drink fountain");
        var date = GetDate();
        var addScore = PlayerPrefs.GetInt("playerBottle", 400);

        var score = PlayerPrefs.GetInt(date + "DrinkingFountain", 0);
        PlayerPrefs.SetInt(date + "DrinkingFountain", score + addScore);

        print(PlayerPrefs.GetInt(date + "DrinkingFountain", 0));
    }

    public static int GetDrinkingFountain()
    {
        var date = GetDate();


        return PlayerPrefs.GetInt(date + "DrinkingFountain", 0);
    }

    public static string GetDrinkingFountainStr()
    {
        var date = GetDate();
        var score = PlayerPrefs.GetInt(date + "DrinkingFountain", 0);
        string str = score.ToString() + "/" + GetTotalDrink().ToString();

        return str;
    }
}
