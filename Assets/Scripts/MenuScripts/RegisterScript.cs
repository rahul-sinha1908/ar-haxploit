using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MyGame;
using Firebase.Unity;
using Firebase.Auth;

public class RegisterScript : MonoBehaviour {

	public InputField nameTxt, emailTxt, passTxt;
	public Button registerBtn;
	// Use this for initialization
	void Start () {
		bindListener();
	}
	
	public void bindListener(){
		registerBtn.onClick.AddListener(()=>onClickRegister());
	}
	// Update is called once per frame
	void Update () {
		
	}

	public void onClickRegister(){
		FirebaseAuth auth = MainMenuHandler.instance.GetFirebaseAuth();
		Debug.Log("Starting to register in");
		auth.CreateUserWithEmailAndPasswordAsync(emailTxt.text, passTxt.text).ContinueWith(task => {
			if (task.IsCanceled) {
				Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
				MyCanvasScript.instance.showToast("Cancelled");
				return;
			}
			if (task.IsFaulted) {
				Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
				MyCanvasScript.instance.showToast("Error : "+task.Exception, 4);
				return;
			}

			// Firebase user has been created.
			MyCanvasScript.instance.showToast("Successful");
			Firebase.Auth.FirebaseUser newUser = task.Result;
			Debug.LogFormat("Firebase user created successfully: {0} ({1})",
				newUser.DisplayName, newUser.UserId);
		});
	}
}
