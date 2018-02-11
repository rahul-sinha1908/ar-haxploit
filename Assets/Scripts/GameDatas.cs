using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDatas : MonoBehaviour {
	public class MyPair{
		public int obj;
		public int col;
		public MyPair(int o, int c){
			obj=o;
			col=c;
		}
	};
	public static GameDatas instance;
	private List<MyPair> detTrack;
	public int nVal;
	public bool objPressed, colPressed;
	public bool isGameAlive;
	private int rights, wrongs;

	void Awake(){
		instance=this;
		isGameAlive=true;
	}

	// Use this for initialization
	void Start () {
		detTrack=new List<MyPair>();
	}
	public void reinitGameDatas(int n){
		nVal=n;
		detTrack.Clear();
		rights=0;
		wrongs=0;
		isGameAlive=true;
	}

	public void pushMe(int obj, int col){
		if(detTrack.Count==nVal){
			detTrack.RemoveAt(0);
		}
		MyPair pair=new MyPair(obj, col);

		detTrack.Add(pair);
	}
	
	public MyPair getNBack(){
		if(detTrack.Count<nVal)
			return null;
		return detTrack[0];
	}
	public int getNBackObj(){
		if(detTrack.Count<nVal)
			return -1;
		return detTrack[0].obj;
	}
	public int getNBackCol(){
		if(detTrack.Count<nVal)
			return -1;
		return detTrack[0].col;
	}

	public void increaseRight(){
		rights++;
	}
	public void increaseWrong(){
		wrongs++;
	}
	public int getRights(){
		return rights;
	}
	public int getWrongs(){
		return wrongs;
	}
}
