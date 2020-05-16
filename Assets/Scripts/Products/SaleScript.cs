using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaleScript : MonoBehaviour
{
    public List<string> listSales;
    public List<string> listNotSales;

    public void Start()
    {
        listSales = new List<string>();
        listNotSales = new List<string>();
    }

    public int Sale(string nameProduct, int price)
    {
        // Если продукта нет в списках.
        if (!SpisokSale(nameProduct) && !SpisokNotSale(nameProduct))
        {
            // Добавить скидку.
            if (Random.Range(0, 5) != 1)
            {
                listSales.Add(nameProduct);
                return price*90/100; 
            } else
            // Без скидки.
            {
                listNotSales.Add(nameProduct);
                return price; 
            }   
        } else
        // Если есть в списке.
        {
            // С скидкой.
            if (SpisokSale(nameProduct))
            {
                return price*90/100;
            } else
            // Без скидки.
            {
                return price;
            }
        }
    }

    // Есть ли продукт в списке акций.
    public bool SpisokSale(string nameProduct)
    {
        foreach(string name in listSales)
        {
            if (nameProduct == name)
            {
                return true;
            }
        } 
        return false;
    }

    // Есть ли продукт в списке без акций.
    public bool SpisokNotSale(string nameProduct)
    {
        foreach(string name in listNotSales)
        {
            if (nameProduct == name)
            {
                return true;
            }
        } 
        return false;
    }
}
