using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Button shapeBtn, colorBtn;
	public Text displayMsg;

	// Use this for initialization
	void Start () {

		bindListener();	
	}
	
	void bindListener(){
		shapeBtn.onClick.AddListener(()=>onClickShape());
		colorBtn.onClick.AddListener(()=>onClickColor());
	}
	private void onClickShape(){
		if(!GameDatas.instance.objPressed){
			GameDatas.instance.objPressed=true;
		}
	}
	private void onClickColor(){
		if(!GameDatas.instance.colPressed){
			GameDatas.instance.colPressed=true;
		}
	}

	// Update is called once per frame
	void Update () {
		if(displayMsg!=null)
			displayMsg.text="Right : "+GameDatas.instance.getRights()+", Wrongs : "+GameDatas.instance.getWrongs();
	}
}
