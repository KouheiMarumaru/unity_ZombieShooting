using UnityEngine;
using System.Collections;

public class GyroScript : MonoBehaviour {

	Quaternion currentGyro;
//	GameController gameController;

	void Start(){
		Input.gyro.enabled = true;
	}

	void Update () {
 			currentGyro = Input.gyro.attitude;
			this.transform.localRotation = 
				Quaternion.Euler (90, 145, 0) * (new Quaternion (-currentGyro.x, -currentGyro.y, currentGyro.z, currentGyro.w));
	}

	//クラスメソッド。GameControllerクラスから呼ばれるので、staticで記述
	public static void FixedCamera(){
		Input.gyro.enabled = false;
	}
}