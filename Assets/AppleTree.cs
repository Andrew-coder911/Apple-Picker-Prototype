using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    //Шаблон для создания яблок
    public GameObject applePrefab;
    //Скорость движения яблони
    public float speed = 10f;
    //Расстояние на котором должно изменяться направление движения яблони
    public float leftAndRightEdge = 15f;
    //Вероятность случайного изменения направления движения яблони
    public float chanceToChangeDirections = 0.02f;
    //Частота создания экземпляров яблок
    public float secondsBetweenAppleDrops = 1f;

    void Start()
    {
       //Сбрасывать яблоки раз в секунду
       Invoke("DropApple", 2f);
    }

    void DropApple()
	{
        GameObject apple = Instantiate<GameObject>(applePrefab); //Создает экземпляр ApplePrefab и присваевает его переменной apple типа GameObject
        apple.transform.position = transform.position;           //местоположение нового объекта apple устанавливается равным местоположению яблони AppleTree
        Invoke("DropApple", secondsBetweenAppleDrops);           //Снова вызывается Invoke() вызывающий функцию DropApple через secondBetweenAppleDrops(1 секунда) при каждом вызове DropApple она планирует вызов самой себя
	}

    // Update is called once per frame
    void Update()
    {
        //Простое перемещение
        Vector3 pos = transform.position;           // определяет локальную переменную Vector3 pos для хранения текщей позиции яблони
        pos.x = pos.x + (speed * Time.deltaTime);   //Компонент Х переменной POS увеличивается на произведение скорости(speed) и интервала времени
        transform.position = pos;                   //измененное значение pos присваивается свойству transform.position что вызывает перемещение 

        //Изменение направления
        if (pos.x < -leftAndRightEdge)              //Проверить не оказалось ли значение pos.x меньше ОТРИЦАТЕЛЬНОГО предела расстояния движения яблони
		{
            speed = Mathf.Abs(speed);               //Если ДА(величина слишком маленькая) speed присваивается абсолютное положительное значение
		}else if (pos.x > leftAndRightEdge)
		{
            speed = -Mathf.Abs(speed);
		}
    }

	void FixedUpdate ()
	{
        if (Random.value < chanceToChangeDirections)//Random.value возвращает случайное число float от 0 до 1 если оно меньше переменной ChanceToChange Direction
        { 
            speed = speed * (-1);                   //то изменяется знак переменной speed на противоположный
        }
    }
}
