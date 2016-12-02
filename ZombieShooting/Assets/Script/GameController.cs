using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public GameObject zombie,panel,messeage,ResetMessage,YourScore;
	public GameObject stage;
	GameObject[] zombies;
	float stageWidth;
	float stageHeight;
//	public GameObject PlayerArea;
//	public Image panel_flashMonitor;

 
	public int score = 0;
	public int PlayerHP = 50;
	public int isDead = 0;

	Text YourScore1;


	// Use this for initialization
	void Start () {

		stageWidth = stage.GetComponent<Renderer> ().bounds.size.x;
		stageHeight = stage.GetComponent<Renderer> ().bounds.size.z;

		YourScore1 = YourScore.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {

		//ゾンビの増殖
		zombies = GameObject.FindGameObjectsWithTag ("zombie");
		if (zombies.Length < 4) {
			Instantiate(zombie,
				new Vector3(Random.Range(-stageWidth/2, stageWidth/2),0,Random.Range(-stageHeight/2, stageHeight/2)),Quaternion.identity);
		} 

		//HPが0になった時
		if(PlayerHP <= 0){
			print("YouDied");

			//プレイヤーのHPがゼロの時に表示
			panel.SetActive(true);
			messeage.SetActive(true);
			ResetMessage.SetActive(true);
			YourScore.SetActive(true);
			YourScore1.text ="Your Score:"+ score;


			////GameControllerクラスにあるクラスメソッド・FixedCameraを呼び出す。
			GyroScript.FixedCamera ();

			//タイトルへ戻るメソッドの呼び出し
			Invoke ("ReturnTitle", 5.0f);
		}
	}


	//タイトルへ戻るメソッド
	void ReturnTitle() {
		SceneManager.LoadScene ("Title");
	}
		
}
