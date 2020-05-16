using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelBuyerCashScript : MonoBehaviour
{
    public Text note1;
    public Text note2;
    public Text note3;
    public Text note4;
    public Text note5;
    public Text note6;
    public Text note7;
    public Text note8;
    public Text note9;
    public Text infoText;

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

    public string dmpString;

    public void TextClear()
    {
        note1.text = "";
        note2.text = "";
        note3.text = "";
        note4.text = "";
        note5.text = "";
        note6.text = "";
        note7.text = "";
        note8.text = "";
        note9.text = "";
    }
    
    public void CashUpdate(int fiveThousand, int oneThousand, int fiveHundred, int oneHundred,
        int fifty, int ten, int five, int two, int one)
    {
        this.fiveThousand = fiveThousand;
        this.oneThousand = oneThousand;
        this.fiveHundred = fiveHundred;
        this.oneHundred = oneHundred;
        this.fifty = fifty;
        this.ten = ten;
        this.five = five;
        this.two = two;
        this.one = one;
        note1.text = BuyerNote();
        note2.text = BuyerNote();
        note3.text = BuyerNote();
        note4.text = BuyerNote();
        note5.text = BuyerNote();
        note6.text = BuyerNote();
        note7.text = BuyerNote();
        note8.text = BuyerNote();
        note9.text = BuyerNote();
    }

    // Покупатель кладёт купюры на панель.
    public string BuyerNote()
    {
        if (fiveThousand != 0)
        {
            dmpString = "5000: " + fiveThousand;
            fiveThousand = 0;
            return dmpString;
        } else
        if (oneThousand != 0)
        {
            dmpString = "1000: " + oneThousand;
            oneThousand = 0;
            return dmpString;
        } else
        if (fiveHundred != 0)
        {
            dmpString = "500: " + fiveHundred;
            fiveHundred = 0;
            return dmpString;
        } else
        if (oneHundred != 0)
        {
            dmpString = "100: " + oneHundred;
            oneHundred = 0;
            return dmpString;
        } else
        if (fifty != 0)
        {
            dmpString = "50: " + fifty;
           fifty = 0;
            return dmpString;
        } else
        if (ten != 0)
        {
            dmpString = "10: " + ten;
            ten = 0;
            return dmpString;
        } else
        if (five != 0)
        {
            dmpString = "5: " + five;
            five = 0;
            return dmpString;
        } else
        if (two != 0)
        {
            dmpString = "2: " + two;
            two = 0;
            return dmpString;
        } else
        if (one != 0)
        {
            dmpString = "1: " + one;
            one = 0;
            return dmpString;
        } else 
        return "";
    }
}
