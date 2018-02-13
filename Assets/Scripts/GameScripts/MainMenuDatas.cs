using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGame;

namespace MyGame{
	public enum MenuStates{
			MainMenu, LoginPanel, RegisterPanel
	};
}

public class MainMenuDatas : MonoBehaviour {
	
	public Stack<MenuStates> menuStack;
    public Dictionary<MenuStates, GameObject> menuMapping;
	public static MainMenuDatas instance;

	void Awake(){
		instance=this;
		
		menuStack=new Stack<MenuStates>();
		menuMapping=new Dictionary<MenuStates, GameObject>();
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
