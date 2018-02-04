using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

	//ボールが見える可能性のあるz軸の最大値
	private float visiblePosZ = -6.5f;

	//ゲームオーバを表示するテキスト
	private GameObject gameoverText;

    //点数を表示するテキスト
    private GameObject scoreText;
    //Score
    private int score;

	// Use this for initialization
	void Start () {
		//シーン中のGameOverTextオブジェクトを取得
		this.gameoverText = GameObject.Find("GameOverText");
        //シーン中のGameOverTextオブジェクトを取得
        this.scoreText = GameObject.Find("ScoreNumber");
	}

	// Update is called once per frame
	void Update () {
		//ボールが画面外に出た場合
		if (this.transform.position.z < this.visiblePosZ) {
			//GameoverTextにゲームオーバを表示
			this.gameoverText.GetComponent<Text> ().text = "Game Over";
		}

        this.scoreText.GetComponent<Text>().text = score.ToString();
	}

    //衝突時に呼ばれる関数
    void OnCollisionEnter(Collision other)
    {

        //Task
        if (other.gameObject.tag == "SmallStarTag")
        {
            AddPoint(10);
        }
        else if (other.gameObject.tag == "LargeStarTag")
        {
            AddPoint(20);
        }

        else if (other.gameObject.tag == "SmallCloudTag" || other.gameObject.tag == "LargeCloudTag")
        {
            AddPoint(30);
        }

        this.scoreText.GetComponent<Text>().text = score.ToString();
    }
    // Add point
    public void AddPoint(int point)
    {
        score = score + point;
    }

}