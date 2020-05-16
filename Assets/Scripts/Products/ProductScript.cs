using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProduct
{
    void DestroyProduct();
    void SwipeLeft();
    void SwipeRight();
}

public class ProductScript : MonoBehaviour, IProduct
{    
    public FabricProducts product;
    protected static CashierScript cashierScript;
    protected static ProductMoveScript productMoveScript;
    public SaleScript sale;
    SpriteRenderer spriteR;
    Vector3 target;
    Vector3 positionScan;
    Vector3 productLeft;
    Vector3 productRight;
    int speed;
    bool nextProduct;
    bool productInLenta;
    bool productInHand;
    bool moveOff;
    bool destroy;
    bool posScan;
    bool posLeft;
    protected static bool LENTAMOVE;
    protected static bool HANDFREE;

    public string name;
    public string nickname;
    public int price;
    public bool lastProduct;
    public bool checkProduct;

    void Start()
    {     
        // dragDistance = Screen.height*5/100;
        productLeft = new Vector3 (-200, -200, 0);
        positionScan = new Vector3 (0, -200, 0);  
        productRight = new Vector3 (Random.Range(400, 300), Random.Range(-450, -350), 0);
        target = transform.position;
        nextProduct = false;
        productInHand = false;
        productInLenta = true;
        moveOff = false;
        destroy = false;
        HANDFREE = true;
        LENTAMOVE = true;    
        speed = Speed(target); 
    }

    public void Peremennye()    
    {
        GameObject ScriptsObject = GameObject.Find("Scripts");
        if (ScriptsObject != null)  
        {
            cashierScript = ScriptsObject.GetComponent<CashierScript>();
            productMoveScript = ScriptsObject.GetComponent<ProductMoveScript>();
            sale = ScriptsObject.GetComponent<SaleScript>();
        }
        
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        spriteR.sprite = product.sprite;
        transform.localScale = product.scale;
        name = product.name;
        price = sale.Sale(product.name, product.price);
        // Если со скидкой.
        if (sale.SpisokSale(name))
        {
            name += "*";
        } 
        nickname = product.nickname;
        cashierScript.RegisterObserverProduct(this);
        productMoveScript.RegisterObserverProduct(this);
        lastProduct = false;
        posScan =  false;
        posLeft = false;
        checkProduct = false; 
    }

    void FixedUpdate()
    {
        if ( (LENTAMOVE) && (productInLenta) )
        {
            target.x = transform.position.x+15;
        }
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    } 

    // Касание LentaStop.
    void OnTriggerEnter2D(Collider2D collider)
    {
        if ((collider.tag == "LentaStop") && (!productInHand))
        {
            nextProduct = true;  
            LENTAMOVE = false;
            productInLenta = false;
        }
    }

    public void Check()
    {
        cashierScript.AddProduct(this);
    }

    // Двигайся вправо.
    public void SwipeRight()
    { 
        if (!destroy)
        {
            if ((!productInHand) && (!moveOff))
            {
                target = transform.position;
            }
            
            // Под сканером.
            if (posScan)
            {
                target = productRight;
                HANDFREE = true;
                productInHand = false;
                moveOff = true;
                posScan = false;
            } 

            // Если продукт слева.
            if (posLeft)
            {
                target = positionScan; 
                posLeft = false;
                posScan = true;
                Invoke ("Check", 0.4f);
            }

            // Следующий.
            if ( (nextProduct) && (HANDFREE) )
            {
                HANDFREE = false;
                nextProduct = false; 
                productInHand = true;
                target = positionScan;
                Invoke ("Check", 0.4f);
                LENTAMOVE = true;
                posScan =  true;
            }
            speed = Speed(target);
        }
    }

    // Двигайся влево.
    public void SwipeLeft()
    {
        if ( (posScan) && (!destroy) )
        {
            target = productLeft;
            posLeft = true;
            posScan = false;
        }
    }

    // Скорость продукта.
    public int Speed(Vector3 target)
    {
        if (target.x >= 0)
        {
            return 1200;
        } else
        {
            return 200;
        }
    }

    // Удаление старых продуктов. Работает через Наблюдателя.
    public void DestroyProduct()
    {
        destroy = true;
        HANDFREE = true;
        LENTAMOVE = true;
        Invoke ("Destroy", Random.Range(1, 5));
    }

    public void Destroy()
    {
        target.x = 1000;
        speed = 200;
        Destroy(gameObject, 10f);
    }
}