using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public Button shapeBtn, colorBtn, closeBtn;
	public Button nPNextBtn, nPRetryBtn, nPMainMenuBtn, sPRetryBtn, sPMainMenuBtn;
	public Text rText, wText, nText;
	public GameObject nextLevelPanel, sameLevelPanel;
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
		closeBtn.onClick.AddListener(()=>onClickClose());

		nPNextBtn.onClick.AddListener(()=>onnPNextBtn());
		nPRetryBtn.onClick.AddListener(()=>onnPRetryBtn());
		nPMainMenuBtn.onClick.AddListener(()=>onnPMainMenuBtn());
		sPRetryBtn.onClick.AddListener(()=>onsPRetryBtn());
		sPMainMenuBtn.onClick.AddListener(()=>onsPMainMenuBtn());
	}
	
	private void onClickClose(){
		SceneManager.LoadScene(0);
	}
	private void onnPNextBtn(){
		loadLevel(GameDatas.instance.nVal+1);
	}
	private void onnPRetryBtn(){
		loadLevel(GameDatas.instance.nVal);
	}
	private void onnPMainMenuBtn(){
		SceneManager.LoadScene(0);
	}
	private void onsPRetryBtn(){
		loadLevel(GameDatas.instance.nVal);
	}
	private void onsPMainMenuBtn(){
		SceneManager.LoadScene(0);
	}

	private void loadLevel(int n){
		nextLevelPanel.SetActive(false);
		sameLevelPanel.SetActive(false);
		GameDatas.instance.reinitGameDatas(n);
		MyPrefabController.instance.gameObject.SetActive(true);
	}
	private void onClickEnd(){
		SceneManager.LoadScene(0);
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

	public void showNextLevel(){
		MyPrefabController.instance.gameObject.SetActive(false);
		int rights = GameDatas.instance.getRights();
		int wrongs = GameDatas.instance.getWrongs();

		GameDatas.instance.isGameAlive=false;

		if(rights>wrongs){
			nextLevelPanel.SetActive(true);
		}else{
			sameLevelPanel.SetActive(true);
		}
	}
}
