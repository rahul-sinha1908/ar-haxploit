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
	public bool wonLast;
	public int rights, wrongs;

	void Awake(){
		instance=this;
	}

	// Use this for initialization
	void Start () {
		detTrack=new List<MyPair>();
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
}
