using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Button shapeBtn, colorBtn;
	public Text rText, wText, nText;
	public static GameController instance;

	void Awake(){
		instance=this;
	}

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
			shapeBtn.interactable=false;
		}
	}
	private void onClickColor(){
		if(!GameDatas.instance.colPressed){
			GameDatas.instance.colPressed=true;
			colorBtn.interactable=false;
		}
	}
	public void refreshButtons(){
		shapeBtn.interactable=true;
		colorBtn.interactable=true;
	}

	// Update is called once per frame
	void Update () {
		if(rText!=null)
			rText.text="Right : "+GameDatas.instance.getRights();
		if(wText!=null)
			wText.text="Wrongs : "+GameDatas.instance.getWrongs();
		if(nText!=null)
			nText.text="N = "+GameDatas.instance.nVal;
	}
}
