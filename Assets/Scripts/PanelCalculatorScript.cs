using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelCalculatorScript : MonoBehaviour
{
    public string kOplate;
    public Text textKOplate;

    public void Button1()
    {
        kOplate += "1";
        TextUpdate();
    }

    public void Button2()
    {
        kOplate += "2";
        TextUpdate();
    }

    public void Button3()
    {
        kOplate += "3";
        TextUpdate();
    }

    public void Button4()
    {
        kOplate += "4";
        TextUpdate();
    }

    public void Button5()
    {
        kOplate += "5";
        TextUpdate();
    }

    public void Button6()
    {
        kOplate += "6";
        TextUpdate();
    }

    public void Button7()
    {
        kOplate += "7";
        TextUpdate();
    }

    public void Button8()
    {
        kOplate += "8";
        TextUpdate();
    }

    public void Button9()
    {
        kOplate += "9";
        TextUpdate();
    }

    public void Button0()
    {
        kOplate += "0";
        TextUpdate();
    }

    public void ButtonClear()
    {
        if (kOplate != "К оплате: ")
        {
            kOplate = kOplate.Substring(0, kOplate.Length-1);
            TextUpdate();
        }     
    }

    public void TextUpdate()
    {
        textKOplate.text = "К оплате: " + kOplate;
    }

    public void TextClear()
    {
        kOplate = "";
        textKOplate.text = "К оплате: ";
    }
}
