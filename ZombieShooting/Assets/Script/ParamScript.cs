using UnityEngine;
using System.Collections;


public class ParamScript : MonoBehaviour {

	public GameController gameController;
	public GUIStyle guiStyle;

	void  OnGUI (){     
		Rect position1 = new Rect (10, 10, 200, 40);
		Rect position2 = new Rect (10, 50, 200, 40);
		Rect position3 = new Rect (10, 120, 200, 40);
		Rect position4 = new Rect (10, 160, 200, 40);

		GUI.Label ( position1, "スコア", guiStyle);
		GUI.Label ( position2, gameController.score.ToString(), guiStyle);
	}
}