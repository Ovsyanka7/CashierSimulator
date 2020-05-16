using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FabricProducts : MonoBehaviour
{
    // public SaleScript sale = GameObject.Find("Scripts").GetComponent<SaleScript>();
    public Vector3 scale;
    public Sprite sprite;
    public string name;
    public string nickname;
    public int price;
}

// Список всех продуктов;
// Данные этих продуктов копируются в скрипт префабов.

// Мясной отдел.
class ProductChickenFillet : FabricProducts
{
    public ProductChickenFillet()
    {
        name = "Кур. филе";
        nickname = "курицу";
        price = 249;
        scale = new Vector3 (Screen.width*5/100, Screen.width*5/100, 0);       
        sprite = Resources.Load<Sprite>("Products/Chicken fillet");
    }
}

class ProductCutlets : FabricProducts
{
    public ProductCutlets()
    {
        name = "Котлеты";
        nickname = "котлеты";
        price = 110;
        scale = new Vector3 (Screen.width*2/100, Screen.width*2/100, 0);       
        sprite = Resources.Load<Sprite>("Products/Cutlets");
    }
}

// Напитки.
public class ProductWater : FabricProducts
{
    public ProductWater()
    {
        name = "Вода";
        nickname = "воду";
        price = 49;
        scale = new Vector3 (Screen.width*4/100, Screen.width*4/100, 0);       
        sprite = Resources.Load<Sprite>("Products/Water"); 
    }
}

public class ProductSoda : FabricProducts
{
    public ProductSoda()
    {
        name = "Газировка";
        nickname = "газировку";
        price = 59;
        scale = new Vector3 (Screen.width*3/100, Screen.width*3/100, 0);       
        sprite = Resources.Load<Sprite>("Products/Soda"); 
    }
}

// Конфеты.
class ProductChocolate : FabricProducts
{
    public ProductChocolate()
    {
        name = "Шоколад";
        nickname = "шоколадку";
        price = 79;
        scale = new Vector3 (Screen.width*2/100, Screen.width*2/100, 0);       
        sprite = Resources.Load<Sprite>("Products/Chocolate");
    }
}

// Молочный отдел.
public class ProductMilk : FabricProducts
{
    public ProductMilk()
    {
        name = "Молоко";
        nickname = "молоко";
        price = 49;
        scale = new Vector3 (Screen.width*5/100, Screen.width*5/100, 0);       
        sprite = Resources.Load<Sprite>("Products/Milk"); 
    }
}

// Хлебный отдел.
class ProductPasta : FabricProducts
{
    public ProductPasta()
    {
        name = "Макароны";
        nickname = "макароны";
        price = 39;
        scale = new Vector3 (Screen.width*5/100, Screen.width*5/100, 0);       
        sprite = Resources.Load<Sprite>("Products/Pasta");
    }
}

class ProductDrying : FabricProducts
{
    public ProductDrying()
    {
        name = "Сушки";
        nickname = "сушки";
        price = 29;
        scale = new Vector3 (Screen.width*5/100, Screen.width*5/100, 0);       
        sprite = Resources.Load<Sprite>("Products/Drying");
    }
}

// Крупы.
class ProductBuckwheat : FabricProducts
{
    public ProductBuckwheat()
    {
        name = "Гречка";
        nickname = "гречку";
        price = 54;
        scale = new Vector3 (Screen.width*5/100, Screen.width*5/100, 0);       
        sprite = Resources.Load<Sprite>("Products/Buckwheat");
    }
}

class ProductMuesli : FabricProducts
{
    public ProductMuesli()
    {
        name = "Мюсли";
        nickname = "мюсли";
        price = 99;
        scale = new Vector3 (Screen.width*3/100, Screen.width*3/100, 0);       
        sprite = Resources.Load<Sprite>("Products/Muesli");
    }
}

// Прочее.
class ProductGum : FabricProducts
{
    public ProductGum()
    {
        name = "Жвачка";
        nickname = "жвачку";
        price = 39;
        scale = new Vector3 (Screen.width*1/100, Screen.width*1/100, 0);       
        sprite = Resources.Load<Sprite>("Products/Gum");
    }
}