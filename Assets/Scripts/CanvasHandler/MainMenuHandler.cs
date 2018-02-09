using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour {

	public Button playBtn;
	// Use this for initialization
	void Start () {
		Screen.orientation=ScreenOrientation.Portrait;
		bindListeners();
	}
	

	private void bindListeners(){
		playBtn.onClick.AddListener(()=>onClickPlay());
	}
	private void onClickPlay(){
		SceneManager.LoadScene(1);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
