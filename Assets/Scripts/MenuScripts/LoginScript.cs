using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Unity;
using Firebase.Auth;

public class LoginScript : MonoBehaviour {

	public Text emailTxt, passTxt;
	public Button loginBtn, registerBtn;
	// Use this for initialization
	void Start () {
		bindListener();
	}
	private void bindListener(){
		loginBtn.onClick.AddListener(()=>onClickLogin());
		registerBtn.onClick.AddListener(()=>onClickRegister());
	}
	private void onClickLogin(){
		FirebaseAuth auth = MainMenuHandler.instance.GetFirebaseAuth();
		auth.CreateUserWithEmailAndPasswordAsync(emailTxt.text, passTxt.text).ContinueWith(task => {
			if (task.IsCanceled) {
				Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
				return;
			}
			if (task.IsFaulted) {
				Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
				return;
			}

			// Firebase user has been created.
			Firebase.Auth.FirebaseUser newUser = task.Result;
			Debug.LogFormat("Firebase user created successfully: {0} ({1})",
				newUser.DisplayName, newUser.UserId);
		});
	}
	private void onClickRegister(){

	}
	

	// Update is called once per frame
	void Update () {
		
	}
}
