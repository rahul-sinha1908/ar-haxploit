using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPrefabController : MonoBehaviour {
	public static MyPrefabController instance;
	public Vector3 initialPos, finalPos;
	public GameObject[] objs;
	public Material[] myMats;
	private int objPointer, colorPointer;

	void Awake(){
		instance=this;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
