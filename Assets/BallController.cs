using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

	private float visiblePosZ = -6.5f;
	private GameObject gameoverText;

	private GameObject scorecountText;
	//score　スコアの値
	private int score;


	// Use this for initialization
	void Start () {
		this.gameoverText = GameObject.Find("GameOverText");

		//ScoreCountTextをscorecountTextに代入
		this.scorecountText = GameObject.Find("ScoreCountText");
		//スコアを０にセット
		this.score = 0;

	}
	
	// Update is called once per frame
	void Update () {
		if(this.transform.position.z < this.visiblePosZ)
        {
			this.gameoverText.GetComponent<Text>().text = "Game Over";
			
		}

		//最新のスコアの値を表示
		this.scorecountText.GetComponent<Text>().text = score.ToString();
		
	}

	void OnCollisionEnter(Collision other)
	{
		//小さい星　10点、大きい星　20点、　雲　15点
		if (other.gameObject.tag == "SmallStarTag")
		{
			this.score += 10;
		}
		else if (other.gameObject.tag == "LargeStarTag")
		{
			this.score += 20;
		}
		else if (other.gameObject.tag == "SmallCloudTag" || other.gameObject.tag == "LargeCloudTag")
		{
			this.score += 15;
		}
		
	}
}
