using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FabricBuyerScript : MonoBehaviour
{
    Buyer nextBuyer;

    // Генерация покупателя.
    public Buyer NextBuyer()
    {
        int value = Random.Range(0, 2);
        if (value == 0)
        {
            nextBuyer = new BuyerRandom();
        } else 
        {
            nextBuyer = new BuyerRandom();
        } 
        return nextBuyer;
    }
}

abstract public class Buyer : MonoBehaviour
{
    public static FabricProducts product;
    public static GameObject prefabProduct = Resources.Load("Product") as GameObject;
    public static ProductScript productScript;

    string dmpString;

    public int distance;
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

    public int sumProducts;
    public int ostatok;
    public int cash; // Сумма, которую протягивает покупатель.
    public bool payCash;
    public bool firstProduct;
    public bool paket;
    
    // Покупатель считает купюры.
    public void CountingMoney(int summa)
    {
        ostatok = summa;

        while (ostatok > 0)
        {
            if (ostatok > 3800)
            {
                fiveThousand++;
                ostatok = ostatok - 5000;
                cash += 5000;
            } else
            if (ostatok > 850)
            {
                oneThousand++;
                ostatok = ostatok - 1000;
                cash += 1000;
            } else
            if (ostatok > 450)
            {
                fiveHundred++;
                ostatok = ostatok - 500;
                cash += 500;
            } else
            if (ostatok > 25)
            {
                oneHundred++;
                ostatok = ostatok - 100;
                cash += 100;
            } else
            if (ostatok > 17)
            {
                fifty++;
                ostatok = ostatok - 50;
                cash += 50;
            } else
            if (ostatok > 8)
            {
                ten++;
                ostatok = ostatok - 10;
                cash += 10;
            } else
            if (ostatok > 4)
            {
                five++;
                ostatok = ostatok - 5;
                cash += 5;
            } else
            if (ostatok > 2)
            {
                two++;
                ostatok = ostatok - 2;
                cash += 2;
            } else
            {
                one++;
                ostatok = ostatok - 1;
                cash += 1;
            }
        }
    }
}

class BuyerRandom : Buyer
{
    public BuyerRandom()
    {  
        firstProduct = false;
        distance = -Screen.width/2;

        // Пакет нужен?
        if (Random.Range(0, 2) == 0)
        {
            paket = true;
        } else
        {
            paket = false;
        }

        if (Random.Range(0, 2) == 0)
        {
            // Оплата наличными.
            payCash = true;
        } else 
        {
            // Оплата картой.
            payCash = false;
        }

        // Продукты покупателя.
        sumProducts = Random.Range(2, 10);
        for (int i = 0; i <= sumProducts; i++)
        {
            // Создание (абстрактного) продукта.
            distance -= 100;
            GameObject productID = Instantiate(prefabProduct, new Vector3 (distance, -200, 100), Quaternion.identity);
            productScript = productID.GetComponent<ProductScript>();

            // Идентификация продукта.
            switch(Random.Range(0, 11))
            {
                case 0:
                    product = new ProductMilk();
                    break;
                case 1:
                    product = new ProductChickenFillet();
                    break;
                case 2:
                    product = new ProductBuckwheat();
                    break;
                case 3:
                    product = new ProductPasta();
                    break;
                case 4:
                    product = new ProductWater();
                    break;
                case 5:
                    product = new ProductSoda();
                    break;
                case 6:
                    product = new ProductDrying();
                    break;
                case 7:
                    product = new ProductMuesli();
                    break;
                case 8:
                    product = new ProductCutlets();
                    break;
                case 9:
                    product = new ProductGum();
                    break;
                case 10:
                    product = new ProductChocolate();
                    break;
            }

            productScript.product = product;
            productScript.Peremennye();

            // Последний продукт.
            if (i == sumProducts)
            {
                productScript.lastProduct = true;
            }
        }
    }
}