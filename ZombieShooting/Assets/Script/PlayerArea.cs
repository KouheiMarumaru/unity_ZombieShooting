using UnityEngine;
using System.Collections;

public class PlayerArea : MonoBehaviour {

	public GameObject gameController;
	 GameController gameManager;

	// Use this for initialization
	void Start () {
	
		gameManager = gameController.GetComponent<GameController> ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void  OnCollisionEnter (Collision other){
		if (other.gameObject.tag == "zombie") {
//			print ("プレイヤーエリア侵入");
			gameManager.PlayerHP -= 10;
//			print (gameManager.PlayerHP);
		} 

	}
}
