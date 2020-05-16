using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelCassaCashScript : MonoBehaviour
{
    public Text textSdacha;

    public Text textFiveThousand;
    //public Text textTwoThousand;
    public Text textOneThousand;
    public Text textFiveHundred;
    //public Text textTwoHundred;
    public Text textOneHundred;
    public Text textFifty;
    public Text textTen;
    public Text textFive;
    public Text textTwo;
    public Text textOne; 

    public int fiveThousand;
    //public int twoThousand;
    public int oneThousand;
    public int fiveHundred;
    //public int twoHundred;
    public int oneHundred;
    public int fifty;
    public int ten;
    public int five;
    public int two;
    public int one;

    public int sdacha;

    public void Button5000()
    {
        if (fiveThousand > 0)
        {
            fiveThousand--;
            SdachaUpdate(5000);
        }         
    }

    public void Button1000()
    {
        if (oneThousand > 0)
        {
            oneThousand--;
            SdachaUpdate(1000);
        }
    }

    public void Button500()
    {
        if (fiveHundred > 0)
        {
            fiveHundred--;
            SdachaUpdate(500);
        }
    }

    public void Button100()
    { 
        if (oneHundred > 0)
        {
            oneHundred--;
            SdachaUpdate(100);
        }
    }

    public void Button50()
    {   
        if (fifty > 0)
        {
            fifty--;
            SdachaUpdate(50);
        }
    }

    public void Button10()
    { 
        if (ten > 0)
        {
            ten--;
            SdachaUpdate(10);
        }
    }

    public void Button5()
    { 
        if (five > 0)
        {
            five--;
            SdachaUpdate(5);
        }
    }

    public void Button2()
    { 
        if (two > 0)
        {
            two--;
            SdachaUpdate(2);
        }
    }

    public void Button1()
    { 
        if (one > 0)
        {
            one--;
            SdachaUpdate(1);
        }
    }

    public void SdachaUpdate (int kupyura)
    {
        sdacha += kupyura;
        TextUpdate();
    }

    public void Razmen()
    {
        if (fiveThousand > 0)
        {
            fiveThousand--;
            oneThousand += 3;
            fiveHundred += 2;
            oneHundred += 5;
            fifty += 8;
            ten += 6;
            five += 5;
            two += 5;
            one += 5;
        } else if (oneThousand > 0)
        {
            oneThousand--;
            fiveHundred += 1;
            oneHundred += 3;
            fifty += 2;
            ten += 6;
            five += 5;
            two += 5;
            one += 5;
        } else if (fiveHundred > 0)
        {
            fiveHundred--;
            oneHundred += 3;
            fifty += 2;
            ten += 6;
            five += 5;
            two += 5;
            one += 5;
        } else if (oneHundred > 0)
        {
            oneHundred--;
            fifty += 1;
            ten += 3;
            five += 2;
            two += 3;
            one += 4;
        } else if (fifty > 0)
        {
            fifty--;
            ten += 3;
            five += 2;
            two += 3;
            one += 4;
        } else if (ten > 0)
        {
            ten--;
            five += 1;
            two += 1;
            one += 3;
        } else if (five > 0)
        {
            five--;
            two += 1;
            one += 3;
        } else if (two > 0)
        {
            two--;
            one += 2;
        } else
        {
            fiveHundred += 1;
            oneHundred += 3;
            fifty += 2;
            ten += 6;
            five += 5;
            two += 5;
            one += 5;
        }
        TextUpdate();
    }

    public void TextUpdate()
    {
        textSdacha.text = "Сдача: " + sdacha;
        textFiveThousand.text = ("5000\n(" + fiveThousand + " шт.)");
        //textTwoThousand;
        textOneThousand.text = ("1000\n(" + oneThousand + " шт.)");
        textFiveHundred.text = ("500\n(" + fiveHundred + " шт.)");
        //textTwoHundred;
        textOneHundred.text = ("100\n(" + oneHundred + " шт.)");
        textFifty.text = ("50\n(" + fifty + " шт.)");
        textTen.text = ("10\n(" + ten + " шт.)");
        textFive.text = ("5\n(" + five + " шт.)");
        textTwo.text = ("2\n(" + two + " шт.)");
        textOne.text = ("1\n(" + one + " шт.)");
    }

    public void SdachaClear()
    {
        textSdacha.text = "Сдача: ";
        sdacha = 0;
    }
}
