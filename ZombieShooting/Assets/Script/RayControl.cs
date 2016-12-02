using UnityEngine;
using System.Collections;

//UIを利用するので、UnityEngine.UI
using UnityEngine.UI;

public class RayControl : MonoBehaviour {
	
	public GameObject diveCamera;
	public Camera Camera_left;
	public Camera Camera_right;
	public GameObject bullet;
	public float speed = 10;
//	public Image scope;
	public GameObject Particle_System;
	bool isPlay = true;


	float
		timer = 0f,
		
		//数値が小さいほど、銃を撃つ間隔が短い
		coolTime = 0.1f;

	public AudioClip machinegunPlay;
	AudioSource audioSource;

	void Start () {

		//マシンガンの発射音設定
		machinegunPlay = Resources.Load<AudioClip>("Sounds/fire");
		audioSource = transform.GetComponent<AudioSource>();

		//マシンガンのエフェクト
		Particle_System.GetComponent<ParticleSystem> ().Stop ();
	}

	void Update () {
		
		//Ray ray = new Ray (起点, 方向);
		Ray ray = new Ray (diveCamera.transform.position, diveCamera.transform.forward);
		RaycastHit hit;

		//「Update関数が呼び出される時間間隔」の数値だけ、timer変数から引かれる
		timer -= Time.deltaTime;

		//timer変数がゼロ以下なら下記実行
		if (timer <= 0) {

			//timer変数にcoolTimeの数値分、代入される。Update関数なのでdeltaTimeごとに呼び出される。もう一度上から。
			timer = coolTime;

			//rayが当たったら
			if (Physics.Raycast (ray, out hit)) {
				
				//Sceneビュー上での表示
				Debug.DrawLine (diveCamera.transform.position, hit.transform.position);

				//ゾンビだったら
				if (hit.collider.tag == "zombie") {
					GameObject bullet2 = (GameObject)Instantiate (bullet, diveCamera.transform.position, Quaternion.identity);
					Vector3 direction = ray.direction;	
					bullet2.GetComponent<Rigidbody> ().velocity = direction * speed;
		
					Particle_System.GetComponent<ParticleSystem> ().Play ();

					//発射音
					audioSource.PlayOneShot (machinegunPlay);
					print ("銃声");

				} 

			} else {
				Particle_System.GetComponent<ParticleSystem> ().Stop ();

			}
		}
	}
}
