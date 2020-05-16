using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductMoveScript : MonoBehaviour
{
    public List<IProduct> products;
    Vector2 startPos;    // Первая позиция касания.
    Vector2 direction;   // Расстояние свайпа.
    float dragDistance;  // Минимальная дистанция для определения свайпа.

    void Start()
    {
        products = new List<IProduct>();
        dragDistance = Screen.height*5/100;
    }

    void Update()
    {
        // Обработка кнопки Вправо.
        if (Input.GetKeyDown(KeyCode.RightArrow)) 
        {             
            SwipeRight();
        }

        // Обработка кнопки Влево.    
        if (Input.GetKeyDown(KeyCode.LeftArrow)) 
        { 
            SwipeLeft();  
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); 
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPos.x = touch.position.x;
                break;

                case TouchPhase.Moved:
                    direction.x = touch.position.x - startPos.x;
                break;

                case TouchPhase.Ended:
                    if (direction.x > dragDistance)
                    {
                        SwipeRight();
                    } else if (direction.x < -dragDistance)
                    {
                        SwipeLeft();
                    }
                    else
                    {
                        // Tap.
                    }
                break;
            }
        }
    }

    public void RegisterObserverProduct(IProduct product)
    {
        products.Add(product);
    }

    public void SwipeRight()
    {
        foreach(IProduct product in products)
        {
            product.SwipeRight();
        }
    }

    public void SwipeLeft()
    {
        foreach(IProduct product in products)
        {
            product.SwipeLeft();
        }
    }
}
