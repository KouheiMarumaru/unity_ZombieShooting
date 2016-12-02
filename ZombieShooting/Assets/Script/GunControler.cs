using UnityEngine;
using System.Collections;

public class GunControler : MonoBehaviour {

	public GameObject bullet;
	Vector3 bulletY;
	GameObject bullet2;

	// Use this for initialization
	void Start () {
		
		bullet2 = GameObject.Find ("Bullet(Clone)");
	}
	
	// Update is called once per frame
	void Update () {

		bulletY = bullet.transform.position;

		if (bulletY.y < 0) {
			Destroy (bullet2);
//			print ("bulletY.y < 0 OK");
		}

			
	}

	void  OnCollisionEnter (Collision other){
//		
//		print (other.gameObject.name);
//		if (other.gameObject.tag == "zombie") {
			//Destroy (other.gameObject);
			Destroy (this.gameObject);
//		}
	}
}
