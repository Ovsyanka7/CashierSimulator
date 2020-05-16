using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CashierScreenScript : MonoBehaviour
{
    public Text textSumma;
    public Text textPosition4;
    public Text textPosition3;
    public Text textPosition2;
    public Text textPosition1;
    public static string lastproduct;
    public static int i;

    void Start()
    {
        ClearScreen();
    }

    public void AddSumm(int summa)
    {
        textSumma.text = "" + summa + " Руб.";
    }

    public void AddPosition(string product, int price)
    {
        if (product == lastproduct)
        {   
            textPosition1.text = product + " " + price + "р (" + ++i + ")";
        } else
        {
            lastproduct = product;
            i = 1;
            textPosition4.text = textPosition3.text;
            textPosition3.text = textPosition2.text;
            textPosition2.text = textPosition1.text;
            textPosition1.text = product + " " + price + "р";
        }
    }

    public void ClearScreen()
    {
        lastproduct = null;
        i = 1;
        textSumma.text = "";
        textPosition4.text = "";
        textPosition3.text = "";
        textPosition2.text = "";
        textPosition1.text = "";
    }
}
