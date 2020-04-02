using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageSelectManager : MonoBehaviour {
	public GameObject[] stageButtons;
	// Use this for initialization
	void Start () {
		int clearStageNo = PlayerPrefs.GetInt ("CLEAR", 0);
		for (int i = 0; i <= stageButtons.GetUpperBound (0); i++) {
			bool b;
			if (clearStageNo < i) {
				b = false;
			} else {
				b = true;
			}
			stageButtons [i].GetComponent<Button> ().interactable = b;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void PushStageSelectButton (int stageNo){
		SceneManager.LoadScene ("PuzzleScene" + stageNo);
	}
}
