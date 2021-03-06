using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    static public int score = 0;

	void Awake ()
	{
		//Если значение HighScore уже существует в PlayerPrefs, прочитать его
		if (PlayerPrefs.HasKey ("HighScore"))
		{
			score = PlayerPrefs.GetInt("HighScore");
		}
		PlayerPrefs.SetInt("HighScore", score);
	}

	void Update()
    {
        Text gt = this.GetComponent<Text>();
        gt.text = "High Score:" + score;
		//Обновить HighScore в PlayerPrefs, если необходимо
		if(score > PlayerPrefs.GetInt ("HighScore"))
		{
			PlayerPrefs.SetInt("HighScore", score);
		}
    }
}
