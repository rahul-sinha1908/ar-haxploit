using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuHandler : MonoBehaviour {

	public Button playBtn;
	// Use this for initialization
	void Start () {

		bindListeners();
	}
	

	private void bindListeners(){
		playBtn.onClick.AddListener(()=>onClickPlay());
	}
	private void onClickPlay(){
		
	}
	// Update is called once per frame
	void Update () {
		
	}
}
