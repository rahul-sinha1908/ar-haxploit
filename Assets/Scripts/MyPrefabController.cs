using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPrefabController : MonoBehaviour {
	public static MyPrefabController instance;
	public Vector3 initialPos, finalPos;
	public GameObject[] objs;
	public Material[] myMats;
	private int objPointer, colorPointer;
	private float curPos=0;
	public float speedLerp;
	private System.Random random;

	void Awake(){
		instance=this;
	}
	// Use this for initialization
	void Start () {
		Screen.orientation=ScreenOrientation.LandscapeLeft;
		//ScreenOrientation.LandscapeLeft
		Debug.Log(initialPos+" : "+finalPos);
		reinitPos();
	}
	
	// Update is called once per frame
	void Update () {
		curPos+=speedLerp*Time.deltaTime;
		transform.localPosition = Vector3.Lerp(initialPos, finalPos, curPos);

		if(curPos>=1){
			curPos=0;
			reachedEnd();
		}
	}

	public int getObjPointer(){
		return objPointer;
	}
	public int getColPointer(){
		return colorPointer;
	}

	private void reachedEnd(){
		calcScore();
		GameDatas.instance.pushMe(objPointer, colorPointer);

		GameDatas.instance.objPressed=false;
		GameDatas.instance.colPressed=false;

		GameController.instance.refreshButtons();

		reinitPos();
	}
	private void reinitPos(){
		if(random==null)
			random=new System.Random();
		objPointer=random.Next(4);
		colorPointer=random.Next(4);

		transform.position=initialPos;
		deactivateAll();
		objs[objPointer].SetActive(true);
		objs[objPointer].GetComponent<MeshRenderer>().material=myMats[colorPointer];
	}
	private void deactivateAll(){
		for(int i=0;i<objs.Length;i++){
			objs[i].SetActive(false);
		}
	}
	private void calcScore(){
		GameDatas.MyPair nBack=GameDatas.instance.getNBack();
		if(nBack==null)
			return;
		bool colB = (nBack.col==colorPointer);
		bool objB = (nBack.obj==objPointer);

		Debug.Log(objB+" : "+colB);
		if(colB==GameDatas.instance.colPressed && objB==GameDatas.instance.objPressed && (colB || objB)){
			GameDatas.instance.increaseRight();
		}else if(GameDatas.instance.objPressed || GameDatas.instance.colPressed || colB || objB){
			GameDatas.instance.increaseWrong();
		}
	}
}
