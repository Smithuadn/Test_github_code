using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CalculateStatistic : MonoBehaviour {
	static public int Level_mode;
	static public float Twice;
	static public float Statistic=5082;
	public Text result_text;

	int i;
	public Image[] img_medal = new Image[4];
	public List<Sprite>imgMed = new List <Sprite> ();
	// Use this for initialization
	void Awake () {
		
		result_text = gameObject.GetComponent<Text>();

	}
	float Calculate(int Level_mode)
	{
		
		switch (Level_mode)
		{
		case 1:
			Statistic = 12 * (GameController.countCorrectCheck*2+100f);
				break;
		case 2:
			Statistic = (Timer.statistic_time * 50) + (GameController.countCorrectCheck*2 *123);
				break;
		case 3:
			Statistic = (Timer.statistic_time * 120) + (GameController.countCorrectCheck*2*1234);
				break;
		}
		return Statistic;
	}

	public void Attach_Medal (float Statistic)
	{ 
		GameObject obj;

		if (Statistic < 2460) {
			
			obj = GameObject.Find ("Med4");
			if (obj !=null)
			obj.SetActive (false);
		}

		if (Statistic <= 18010) {
			obj = GameObject.Find ("Med3");
			if (obj !=null)
				obj.SetActive (false);
		}
		if (Statistic < 25080) {
			obj = GameObject.Find ("Med1");
			if (obj !=null)
				obj.SetActive (false);
		}
	}

	void Update () {
		Calculate(Level_mode);
		Attach_Medal (Statistic);
		if (result_text!=null)
			result_text.text = "Congratulations! Your Score:" + (int)Statistic;
	}
}
