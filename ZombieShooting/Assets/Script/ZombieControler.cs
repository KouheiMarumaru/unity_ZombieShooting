using UnityEngine;
using System.Collections;

public class ZombieControler : MonoBehaviour {

	// 向かせたい方向のオブジェクトのTransformを取得
	public Transform target;

	//HP
	public int hp = 100;

	public GameObject gameController;

	GameController gameManager;

	public GameObject Particle_System;

	public AudioClip zombieVoice;
	public AudioClip zombieDeathVoice;
	AudioSource audioSource;

	// Use this for initialization
	void Start () {
		//プレハブ側のgameControllerではなく、ヒエラルキー側のgameControllerを参照するための記述
		//プレハブを参照するとデータが蓄積されるため、スコアが累計して表示されてしまう。
		gameController = GameObject.Find ("GameController");

		gameManager = gameController.GetComponent<GameController> ();

		//ゾンビ音声
		zombieVoice = Resources.Load<AudioClip>("Sounds/zombie-breath1");
		zombieDeathVoice = Resources.Load<AudioClip>("Sounds/zombie-death-throes1");
		audioSource = transform.GetComponent<AudioSource>();

	
	}
	
	// Update is called once per frame
	void Update() {
//		print (hp);

		if (target) {
			// オブジェクトをtarget方向に向かせる
			transform.LookAt (target.transform.position);

			//ゾンビ声
			audioSource.PlayOneShot (zombieVoice);

			//「targetの位置」の二乗から、「ゾンビがいる位置の二乗」を引いて１以下なら処理を実行
			//（つまりtargetがゾンビから離れていたなら）
			if (Vector3.Magnitude (target.transform.position - this.transform.position) <= 1) {
				
				//transform.Translate (0, 0, 0);と同義
				transform.position = this.transform.position + new Vector3 (0, 0, 0);

			} else {

				//y軸に進む。それに速度1をかけて速度は増さない　フレームレートも一定にする
				transform.Translate (new Vector3 (0, 0, 1) * 1 * Time.deltaTime);
			}
		}

	}

	void  OnCollisionEnter (Collision collision){
			hp -= 10;
			print (hp);

			if (hp <= 0) {
				gameManager.score += 10;

				Destroy	(this.gameObject);
				
				//ゾンビ死ぬ声
				audioSource.PlayOneShot (zombieDeathVoice);
				print ("ゾンビ死ぬ声");
			}
			
	}
}
