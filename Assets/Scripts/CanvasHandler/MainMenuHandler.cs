using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Firebase.Unity;
using Firebase.Auth;

public class MainMenuHandler : MonoBehaviour {

	public Button playBtn;
	private FirebaseAuth auth;
	private FirebaseUser user;

	public static MainMenuHandler instance;

	void Awake(){
		instance=this;
	}

	// Use this for initialization
	void Start () {
		Screen.orientation=ScreenOrientation.Portrait;
		InitializeFirebase();
		bindListeners();
	}

	private void bindListeners(){
		playBtn.onClick.AddListener(()=>onClickPlay());
	}
	private void onClickPlay(){
		SceneManager.LoadScene(1);
	}
	// Update is called once per frame
	void Update () {
		
	}

	void InitializeFirebase() {
		auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
		auth.StateChanged += AuthStateChanged;
		AuthStateChanged(this, null);
	}

	void AuthStateChanged(object sender, System.EventArgs eventArgs) {
		if (auth.CurrentUser != user) {
			bool signedIn = user != auth.CurrentUser && auth.CurrentUser != null;
			if (!signedIn && user != null) {
				Debug.Log("Signed out " + user.UserId);
			}
			user = auth.CurrentUser;
			if (signedIn) {
				Debug.Log("Signed in " + user.UserId);
			}
		}
	}

	public FirebaseAuth GetFirebaseAuth(){
		return auth;
	}
}
