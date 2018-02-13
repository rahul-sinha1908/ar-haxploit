using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SizeAdjusterScript : MonoBehaviour {

	public bool adjustHieght, adjustWidth, verticalPanelAdjuster;
	public int heightPadding;
	private VerticalLayoutGroup verticalLayout;
	private RectTransform rect;

	// Use this for initialization
	void Start () {
		rect = GetComponent<RectTransform>();
		if(verticalPanelAdjuster)
			verticalLayout=GetComponent<VerticalLayoutGroup>();
	}
	
	// Update is called once per frame
	void Update () {
		if(adjustHieght)
			checkHieght();
		if(adjustWidth)
			checkWidth();
		if(verticalPanelAdjuster)
			checkLayoutHieght();
	}

	private void checkHieght(){
		float height=0;
		foreach(Transform t in transform){
			if(t.gameObject.activeSelf){
				RectTransform child = t.GetComponent<RectTransform>();
				height+=child.sizeDelta.y;
			}
		}
		Vector2 v = rect.sizeDelta;
		v.y=height+heightPadding;
		rect.sizeDelta=v;
	}
	private void checkLayoutHieght(){
		float height=0;
		int tot=0;
		foreach(Transform t in transform){
			if(t.gameObject.activeSelf){
				RectTransform child = t.GetComponent<RectTransform>();
				height+=child.sizeDelta.y;
				tot++;
			}
		}
		if(tot>0)
			tot--;
		Vector2 v = rect.sizeDelta;
		v.y=height+verticalLayout.spacing*tot+verticalLayout.padding.top+verticalLayout.padding.bottom;
		rect.sizeDelta=v;
	}
	private void checkWidth(){
		float width=0;
		foreach(Transform t in transform){
			if(t.gameObject.activeSelf){
				RectTransform child = t.GetComponent<RectTransform>();
				width= Mathf.Max(child.sizeDelta.x, width);
			}
		}
		Vector2 v = rect.sizeDelta;
		v.x=width+heightPadding;
		rect.sizeDelta=v;
	}
}
