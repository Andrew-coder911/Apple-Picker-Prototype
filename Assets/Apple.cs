using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public static float bottomY = -20f;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < bottomY)
		{
            //по сути с добовлением кода ниже эта строчка нахрен не нужна но пока хз
            Destroy(this.gameObject);

            //Получить ссылку на компонент ApplePicker главной камеры Main Camera
            ApplePicker apScipt = Camera.main.GetComponent<ApplePicker>();
            //Вызвать общедоступный метод AppleDestroyed() из apScript
            apScipt.AppleDestroyed();
		}
    }
}
