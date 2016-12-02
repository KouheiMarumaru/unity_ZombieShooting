using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class TitleRayController : MonoBehaviour {

	public GameObject diveCamera;

	//後に、ButtonオブジェクトのColliderをアタッチする為の変数です。
	public GameObject buttonCollider;
	public GameObject ui;

	//今回変化させるのは、先ほど追加したピンク色のゲージを持つButtonGaugeです。なので、取得するようにしましょう。
	public Image buttonGauge;

	//ゲージがどこまで伸びるのかについての定義
	public int endPositionX = -4;
	float gaugeTime;

	//初めピンク色のゲージがどこにあるのかについての変数firstButtonGaugePositionを定義
	Vector3 firstButtonGaugePosition;

	void Start () {
		firstButtonGaugePosition = buttonGauge.rectTransform.localPosition;
	}

	void Update () {

		//rayの生成
		Ray ray = new Ray (diveCamera.transform.position, diveCamera.transform.forward);
		RaycastHit hit;

		//もし発射しているRayがオブジェクトに衝突をしたら
		//Physics.Raycast関数はRayがオブジェクトのコライダーと衝突した場合はtrue、
		//それ以外はfalseを返します。
		//第一引数にRay型の値を指定し、第二引数にRayが衝突した際のオブジェクトの情報を取得するために
		//RayCastHit型の値を指定します
		if (Physics.Raycast (ray, out hit)) {

			//Debug.DrawLineは、指定した開始位置と終了位置の間にラインを描画します。
			//Debug.DrawLine(ラインの開始位置, ラインの終了位置, ラインの色);
			Debug.DrawLine (ray.origin, hit.point, Color.white);

			//RayがヒットしたオブジェクトがアタッチしたButtonだったら
			if (hit.collider.gameObject == buttonCollider) {

				//ゲージを目線に合わせている時間の長さで位置を変化
				gaugeTime += Time.deltaTime * 0.01f;
				buttonGauge.rectTransform.localPosition = Vector3.Lerp (buttonGauge.rectTransform.localPosition, new Vector3 (0, 0, 1), gaugeTime);
			} else {
				gaugeTime = 0;
				buttonGauge.rectTransform.localPosition = firstButtonGaugePosition;
			}

			//「ボタンのピンク色のゲージの位置が、endPositionより大きくなった場合trueを返す」という条件式
			if (buttonGauge.rectTransform.localPosition.x > endPositionX) {
				SceneManager.LoadScene ("Main");
			}
		}
	}
}