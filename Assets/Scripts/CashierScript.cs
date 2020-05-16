using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CashierScript : DialogsScript
{
    public GameObject PanelBuyerCash;
    public GameObject PanelCashierCash;
    public GameObject PanelCalculator;
    List<IProduct> productsObservers;
    List<IProduct> productsOtmena;
    public FabricBuyerScript generateBuyer;
    CashierScreenScript cashierScreen;
    PanelCalculatorScript panelCalculator;
    PanelCassaCashScript panelCassaCash;
    PanelBuyerCashScript panelBuyerCash;
    Buyer buyer;
    IProduct iProduct;
    public int summa;
    public int paketOtmena;
    public int realSdacha; 
    public int playerSdacha; 
    public int paket;
    public bool pay;
    public bool lastProduct;
    bool oneOtmenaPakets;

    public void Start()
    {
        // Поиск скриптов.
        GameObject ScriptsObject = GameObject.Find("Scripts");
        if (ScriptsObject != null)      
        {
            cashierScreen = ScriptsObject.GetComponent<CashierScreenScript>();
            panelChat = ScriptsObject.GetComponent<ChatScript>();
            panelCassaCash = ScriptsObject.GetComponent<PanelCassaCashScript>();
            panelBuyerCash = ScriptsObject.GetComponent<PanelBuyerCashScript>();
        }

        productsObservers = new List<IProduct>();
        productsOtmena = new List<IProduct>();
        panelBuyerCash.TextClear();
        NextBuyer();

        panelCassaCash.fiveThousand = 0;
        //panelCassaCash.twoThousand;
        panelCassaCash.oneThousand = 0;
        panelCassaCash.fiveHundred = 0;
        //panelCassaCash.twoHundred = 5;
        panelCassaCash.oneHundred = 5;
        panelCassaCash.fifty = 5;
        panelCassaCash.ten = 5;
        panelCassaCash.five = 5;
        panelCassaCash.two = 5;
        panelCassaCash.one = 5;
        panelCassaCash.TextUpdate();
    }

    // Запись всех продуктов, чтобы потом убрать их со сцены.
    public void RegisterObserverProduct(IProduct product)
    {
        productsObservers.Add(product);
    }

    // Следующий покупатель.
    public void NextBuyer()
    {
        foreach(IProduct product in productsObservers)
        {
            product.DestroyProduct();
        }
        productsObservers.Clear();
        productsOtmena.Clear();

        generateBuyer = new FabricBuyerScript();
        buyer = generateBuyer.NextBuyer();

        AddText("", true, 2f);
        paketOtmena = 0;
        summa = 0;
        realSdacha = 0;
        playerSdacha = 0;
        paket = 0;
        pay = false;  
        lastProduct = false;
        oneOtmenaPakets = true;
        panelCassaCash.SdachaClear();
        cashierScreen.ClearScreen();
        DialogPaket(buyer.paket);  
    }

    // Сканирование продукта.
    public void AddProduct(ProductScript product)
    {
        // Включает кнопку Subtotal (Итого).
        buyer.firstProduct = true;

        // Последний продукт.
        if (product.lastProduct)
        {
            this.lastProduct = true;
        }

        // Пробился ли продукт.
        if (Random.Range(0, 10) <= 7)
        {
            summa += product.price;
            cashierScreen.AddSumm(summa);
            cashierScreen.AddPosition(product.name, product.price);

            // Если продукт пробился дважды.
            if (product.checkProduct)
            {
                Otmena(product);
            } else
            {
                product.checkProduct = true;
            }
        }     
    }

    // Добавление Пакета.
    public void AddPaket()
    {
        summa += 7;
        paket += 1;
        cashierScreen.AddSumm(summa);
        cashierScreen.AddPosition("Пакет", 7);

        // Проверка на лишние пакеты.
        if ((paket > 1) || (!buyer.paket))
        {
            Otmena();
        }
    }

    // Отмена продуктов.    
    public void Otmena(ProductScript product)
    {
        productsOtmena.Add(product);
        if (!DIALOGS)
        {
            DIALOGS = true;
            AddText("Вы что, " + product.nickname + " два раза пробили?", true, 1f);
            AddText("Мне их не надо, отмените.", true, 2f);
            Invoke("StopDialogs", 2f);
        }
    }

    // Отмена пакетов.    
    public void Otmena()
    {   
        paketOtmena++;
        if (oneOtmenaPakets)
        {
            if (!DIALOGS)
            {
                DIALOGS = true;
                oneOtmenaPakets = false;

                if (buyer.paket)
                {
                    AddText("Куда мне столько пакетов?!", true, 1f);
                    AddText("Мне их не надо, отмените.", true, 2f); 
                } else 
                {
                    AddText("Вы мне пакет пробили?", true, 1f);
                    AddText("Мне их не надо, отмените.", true, 2f); 
                }
                Invoke("StopDialogs", 2f);
            } else
            {
                Invoke("Otmena", 1f);
            }
        }
    }

    // Итого.
    public void Subtotal()
    {
        if (!DIALOGS)
        {
            DIALOGS = true;
            if ((paketOtmena == 0) && (productsOtmena.Count == 0))
            {
                // Если небыл пробит ни один продукт.
                if (!buyer.firstProduct)
                {
                // Если все продукты были пробиты.
                } else if (lastProduct)
                {
                    DIALOGS = true;
                    AddText(summa+" Рублей.", false, 0.5f);
                    AddText("Оплата картой, наличными?", false, 1f);

                    if (buyer.paket && paket == 0)
                    {
                        AddText("Вы пакет мне дадите или нет?", true, 2f);
                    } else if (buyer.payCash)
                    {
                        AddText("Наличными.", true, 2f);
                        pay = true;
                    } else 
                    {
                        AddText("Картой.", true, 2f);
                        pay = true;
                    }
                } else
                {
                    DIALOGS = true;
                    AddText(summa+" Рублей.", false, 0.5f);
                    AddText("Оплата картой, наличными?", false, 1f);
                    AddText("Глаза разуйте, тут ещё продукты остались!", true, 2f);
                } 
                Invoke("StopDialogs", 2f);
            } else
            {
                AddText(summa+" Рублей.", false, 0.5f);
                AddText("Оплата картой, наличными?", false, 1f);
                AddText("Я не собираюсь платить.", true, 2f);
                AddText("Зовите администратора, отменяйте!.", true, 3f);
                Invoke("StopDialogs", 3f);
            }
        }
    }

    // Отмена лишних позиций.
    public void Administrator()
    {
        if (productsOtmena.Count > 0)
        {
            foreach(ProductScript product in productsOtmena)
            {
                DeleteProduct(product);
            }
            productsOtmena.Clear();
        }

        if (paketOtmena > 0)
        {
            while (paketOtmena > 0)
            {
                DeletePaket();
                paketOtmena--;
            }
        } 
    }
    
    // Отмена продуктов
    public void DeleteProduct(ProductScript product)
    {
        summa -= product.price;
        cashierScreen.AddSumm(summa);
        cashierScreen.AddPosition(product.name + "*", -product.price);

    }

    // Отмена пакетов.
    public void DeletePaket()
    {
        summa -= 7;
        cashierScreen.AddSumm(summa);
        cashierScreen.AddPosition("Пакет*", -7);
    }
    
    // Оплата картой.
    public void PayCard()
    {
        if (!DIALOGS)
        {
            if (pay && !buyer.payCash)
            {
                pay = false;
                AddText("Оплачено", false, 1f);
                DialogThinksNext(1.5f);
                Invoke ("NextBuyer", 2.5f);
            } else if (pay)
            {
                DIALOGS = true;
                AddText("Вообще-то у меня наличные!", true, 1f);
                AddText("Внимательней нужно быть.", true, 2f);
                Invoke("StopDialogs", 2f);
            }
        }
    }

    // Оплата наличными.
    public void PayCash()
    {
        if (!DIALOGS)
        {
            if (pay && buyer.payCash)
            {
                pay = false;
                // Покупатель считает купюры.
                buyer.CountingMoney(summa);
                realSdacha = buyer.cash - summa;

                OpenPanelBuyerCash();
                OpenPanelCashierCash();

                panelBuyerCash.CashUpdate(buyer.fiveThousand, buyer.oneThousand, buyer.fiveHundred, buyer.oneHundred, 
                    buyer.fifty, buyer.ten, buyer.five, buyer.two, buyer.one);
            } else if (pay)
            {
                DIALOGS = true;
                AddText("Вообще-то оплата картой!", true, 1f);
                Invoke("StopDialogs", 1f);
            }
        }
    }   

    // Открыть панель с деньгами покупателя.
    public void OpenPanelBuyerCash()
    {
        PanelBuyerCash.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
    }

    // Открыть панель с деньгами кассы.
    public void OpenPanelCashierCash()
    {
        PanelCashierCash.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        panelBuyerCash.infoText.text = "Выдайте сдачу.";
    }

    // Закрыть панель с деньгами покупателя.
    public void ClosePanelBuyerCash()
    {
        PanelBuyerCash.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 600);
    }

    // Закрыть кассу.
    public void ClosePanelCashierCash()
    {
        PanelCashierCash.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -850);
        Receipt();
    }

    // Выдача чека.
    public void Receipt()
    {
        panelCassaCash.fiveThousand += buyer.fiveThousand;
        panelCassaCash.oneThousand += buyer.oneThousand;
        panelCassaCash.fiveHundred += buyer.fiveHundred;
        panelCassaCash.oneHundred += buyer.oneHundred;
        panelCassaCash.fifty += buyer.fifty;
        panelCassaCash.ten += buyer.ten;
        panelCassaCash.five += buyer.five;
        panelCassaCash.two += buyer.two;
        panelCassaCash.one += buyer.one;
        panelCassaCash.TextUpdate();

        if (panelCassaCash.sdacha < realSdacha)
        {
            DialogLittleSdacha(realSdacha, panelCassaCash.sdacha);
            Invoke ("NextBuyer", 12f);
        } else
        {
            DialogThinksNext(0.5f);
            Invoke ("NextBuyer", 2f);
        }
    }
}