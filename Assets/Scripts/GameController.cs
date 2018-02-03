using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Button shapeBtn, colorBtn;
	// Use this for initialization
	void Start () {

		bindListener();	
	}
	
	void bindListener(){
		shapeBtn.onClick.AddListener(()=>onClickShape());
		colorBtn.onClick.AddListener(()=>onClickColor());
	}
	private void onClickShape(){

	}
	private void onClickColor(){

	}

	// Update is called once per frame
	void Update () {
		
	}
}
