using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogsScript : MonoBehaviour
{
    public ChatScript panelChat;
    // Чтобы небыло два диалога одновременно.
    protected static bool DIALOGS;
    float time1;
    float time2;
    float time3;

    public void Start()
    {
        // Поиск скриптов.
        GameObject ScriptsObject = GameObject.Find("Scripts");
        if (ScriptsObject != null)      
        {
            panelChat = ScriptsObject.GetComponent<ChatScript>();
        }
        DIALOGS = false;       
    }

    // Добрый день, пакет нужен?
    public void DialogPaket(bool buyerPaket)
    {
        DIALOGS = true;
        AddText("Добрый день, пакет нужен?", false, 2f);
        time1 = 2.1f;
        time2 = 3f;
        time3 = 4f;

        if (buyerPaket)
        {
            switch(Random.Range(0, 9)) 
            {
                case 0:
                    AddText("Конечно.", true, time1);
                    Invoke("StopDialogs", time1);
                    break;
                case 1:
                    AddText("А я что, должен всё в руках носить?", true, time1);
                    AddText("Давайте ваш пакет.", true, time2);
                    Invoke("StopDialogs", time2);
                    break;
                case 2:
                    AddText("Что?", true, time1);
                    AddText("Вам пакет нужен?", false, time2);
                    AddText("Нужен.", true, time3);
                    Invoke("StopDialogs", time3);
                    break;
                case 3:
                    AddText("А сколько стоит?", true, time1);
                    AddText("7 рублей?", false, time2);
                    AddText("Ну ладно, давайте.", true, time3);
                    Invoke("StopDialogs", time3);
                    break;
                case 4:
                    AddText("Да.", true, time1);
                    Invoke("StopDialogs", time1);
                    break;
                case 5:
                    AddText("Давайте.", true, time1);
                    Invoke("StopDialogs", time1);
                    break;
                case 6:
                    AddText("Да, давайте.", true, time1);
                    Invoke("StopDialogs", time1);
                    break;
                case 7:
                    Invoke("StopDialogs", time1);
                    break;
                case 8:
                    AddText("Непрозрачный.", true, time1);
                    AddText("Непрозрачных нет.", false, time2);
                    AddText("Давайте уже какой нибудь.", true, time3);
                    Invoke("StopDialogs", time3);
                    break;
            }
        } else 
        {
            switch(Random.Range(0, 10)) 
            {
                case 0:
                    AddText("Вообще-то уже вечер.", true, time1);
                    Invoke("StopDialogs", time1);
                    break;
                case 1:
                    AddText("Нет, не нужен. Вы у меня каждый раз спрашиваете!", true, time1);
                    Invoke("StopDialogs", time1);
                    break;
                case 2:
                    AddText("У меня свой.", true, time1);
                    Invoke("StopDialogs", time1);
                    break;
                case 3:
                    AddText("Что?", true, time1);
                    AddText("Вам пакет нужен?", false, time2);
                    AddText("Нет.", true, time3);
                    Invoke("StopDialogs", time3);
                    break;
                case 4:
                    AddText("Непрозрачный.", true, time1);
                    AddText("Непрозрачных нет.", false, time2);
                    AddText("Тогда не надо.", true, time3);
                    Invoke("StopDialogs", time3);
                    break;
                case 5:
                    AddText("Не надо.", true, time1);
                    Invoke("StopDialogs", time1);
                    break;
                case 6:
                    AddText("Не.", true, time1);
                    Invoke("StopDialogs", time1);
                    break;
                case 7:
                    AddText("А сколько стоит?", true, time1);
                    AddText("7 рублей.", false, time2);
                    AddText("Нет, не надо.", true, time3);
                    Invoke("StopDialogs", time3);
                    break;
                case 8:
                    AddText("Конечно же нет!", true, time1);
                    AddText("Вы вообще в курсе как эти пакеты влияют на природу?", true, time2);
                    AddText("Вам лишь бы денег побольше стрясти.", true, time3);
                    Invoke("StopDialogs", time3);
                    break;    
                case 9:
                    break;    
            } 
        }
    }

    public void DialogLittleSdacha(int realSdacha, int userSdacha)
    {
        AddText ("Вы что, с ума сошли?! Этого мало, где мои деньги?!", true, 1);
        AddText ("Зовите администратора! где " + Rubley(realSdacha - userSdacha), true, 3);
        AddText ("Хотели мои деньги присвоить? Думали, я не замечу?", true, 5);
        AddText ("Наберут студентов, сил уже на вас не хватает!", true, 7);
        AddText ("Простите за неудобство.", false, 9);
    }

    public void DialogThinksNext(float wait)
    {
        AddText("Спасибо за покупку!", false, wait);
        AddText("Приходите ещё!", false, wait + 0.5f);
    }

    // Склонения слова "Рубль".
    public string Rubley(int rub)
    {
        if (rub < 10)
        {
            switch(rub)
            {
                case 1:
                    return "мой рубль!?";
                case 2: 
                case 3:
                case 4:
                    return "мои " + rub + " рубля!?";
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                    return "мои " + rub + " рублей!?";  
            }  
        } else if (rub < 20)
        {
            return "мои " + rub + " рублей!?"; 
        } else 
        {
            // Последняя цифра числа.
            switch(rub.ToString().Substring(rub.ToString().Length-1))
            {
                case "0":
                    return "мои " + rub + " рублей!?"; 
                case "1":
                    return "мой " + rub + " рубль!?";  
                case "2": 
                case "3":
                case "4":
                    return "мои " + rub + " рубля!?";
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    return "мои " + rub + " рублей!?";
                default:
                    return "мои деньги!?"; 
            }
        } 
        return "мои деньги!?"; 
    }

    public void StopDialogs()
    {
        DIALOGS = false;
    }

    public void AddText (string text, bool buyer, float time)
    {
        StartCoroutine(panelChat.AddText(text, buyer, time));
    }
}
