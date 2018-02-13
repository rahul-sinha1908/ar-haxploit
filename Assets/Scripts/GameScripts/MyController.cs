using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyController : MonoBehaviour {
	UniWebView webView;
	// Use this for initialization
	void Start () {
		var webViewGameObject = new GameObject("UniWebView");
        webView = webViewGameObject.AddComponent<UniWebView>();

		webView.Frame = new Rect(0, 0, Screen.width, Screen.height);
    	webView.Load("http://www.flipkart.com");
    	webView.Show();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
