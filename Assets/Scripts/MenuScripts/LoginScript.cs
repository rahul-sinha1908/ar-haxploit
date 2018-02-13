using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Unity;
using Firebase.Auth;
using MyGame;

public class LoginScript : MonoBehaviour {

	public InputField emailTxt, passTxt;
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
		Debug.Log("Starting to log in");
		auth.SignInWithEmailAndPasswordAsync(emailTxt.text, passTxt.text).ContinueWith(task => {
			if (task.IsCanceled) {
				Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
				MyCanvasScript.instance.showToast("Cancelled");
				return;
			}
			if (task.IsFaulted) {
				Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
				MyCanvasScript.instance.showToast("Error : "+task.Exception);
				return;
			}

			Firebase.Auth.FirebaseUser newUser = task.Result;
			MyCanvasScript.instance.showToast("Successful");
			Debug.LogFormat("User signed in successfully: {0} ({1})",
				newUser.DisplayName, newUser.UserId);
			GameMethods.activateMenuAbsolutely(MenuStates.MainMenu);
		});
	}
	private void onClickRegister(){
		GameMethods.activateMenu(MenuStates.RegisterPanel, true);
	}
	

	// Update is called once per frame
	void Update () {
		
	}
}
