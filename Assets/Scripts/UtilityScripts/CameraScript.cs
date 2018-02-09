using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	public bool arCamera;
	// Use this for initialization
	void Start () {
		#if UNITY_EDITOR
			Debug.Log("It reaced Here !! "+arCamera);
			if(arCamera){
				gameObject.SetActive(false);
			}else{
				gameObject.SetActive(true);
			}
		#else
			if(arCamera){
				gameObject.SetActive(true);
			}else{
				gameObject.SetActive(false);
			}
		#endif
	}	
}
