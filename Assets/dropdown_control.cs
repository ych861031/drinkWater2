using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class dropdown_control : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Dropdown").GetComponent<Dropdown>().onValueChanged.AddListener(ConsoleResult);
    }

    public void ConsoleResult(int value)
    {
        CalendarSetting.num = value;
        CalendarSetting.UpdateCalender();
        bloodstrip.SetHomeBloodStrip();
        Basic.SetHomeBloodStripText();
        //这里用 if else if也可，看自己喜欢
        //分别对应：第一项、第二项....以此类推
        switch (value)
        {
            case 0:
                print("第1页");
                break;
            case 1:
                print("第2页");
                break;
            case 2:
                print("第3页");
                break;
            case 3:
                print("第4页");
                break;
            //如果只设置的了4项，而代码中有第五个，是永远调用不到的
            //需要对应在 Dropdown组件中的 Options属性 中增加选择项即可
            case 4:
                print("第5页");
                break;
            case 5:
                print("第6页");
                break;
        }

    }

}
