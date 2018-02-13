using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGame;

public class GameMethods {
	public static GameObject activateMenu(MenuStates state, bool hidePrev){
        if(MainMenuDatas.instance.menuMapping[state]!=null){
            if(MainMenuDatas.instance.menuStack.Count>0){
                MenuStates prevMen = MainMenuDatas.instance.menuStack.Peek();
                if(MainMenuDatas.instance.menuMapping[prevMen]!=null)
                    MainMenuDatas.instance.menuMapping[prevMen].SetActive(!hidePrev);
            }
            MainMenuDatas.instance.menuMapping[state].SetActive(true);
            MainMenuDatas.instance.menuStack.Push(state);
            return MainMenuDatas.instance.menuMapping[state];
        }
        return null;
    }
    public static void deactivateMenu(){
        if(MainMenuDatas.instance.menuStack.Count>0){
            MenuStates curMen = MainMenuDatas.instance.menuStack.Pop();
            MenuStates prevMen = MainMenuDatas.instance.menuStack.Peek();
            if(MainMenuDatas.instance.menuMapping[curMen]!=null)
                MainMenuDatas.instance.menuMapping[curMen].SetActive(false);
            if(MainMenuDatas.instance.menuMapping[prevMen]!=null)
                MainMenuDatas.instance.menuMapping[prevMen].SetActive(true);
        }
    }
    public static MenuStates getCurrentMenu(){
        return MainMenuDatas.instance.menuStack.Peek();
    }
    public static void activateMenuAbsolutely(MenuStates state){
        if(MainMenuDatas.instance.menuMapping[state]!=null){
            while(MainMenuDatas.instance.menuStack.Count>0){
                MenuStates prevMen = MainMenuDatas.instance.menuStack.Pop();
                if(MainMenuDatas.instance.menuMapping[prevMen]!=null)
                    MainMenuDatas.instance.menuMapping[prevMen].SetActive(false);
            }
            // if(MainMenuDatas.instance.menuStack.Count>0){
            //     MenuStates prevMen = MainMenuDatas.instance.menuStack.Pop();
            //     if(MainMenuDatas.instance.menuMapping[prevMen]!=null)
            //         MainMenuDatas.instance.menuMapping[prevMen].SetActive(false);
            // }
            MainMenuDatas.instance.menuMapping[state].SetActive(true);
            MainMenuDatas.instance.menuStack.Push(state);
            Debug.Log("Absolute : "+MainMenuDatas.instance.menuStack.Count);
        }
    }

    public static void deactivateAllMenu(){
        foreach(GameObject go in MainMenuDatas.instance.menuMapping.Values){
            go.SetActive(false);
        }
    }

    public static void goBack(){
        if(MainMenuDatas.instance.menuStack.Count>1){
            MenuStates prevMenu = MainMenuDatas.instance.menuStack.Pop();
            MenuStates nextMenu = MainMenuDatas.instance.menuStack.Peek();
            if(MainMenuDatas.instance.menuMapping[prevMenu]!=null)
                MainMenuDatas.instance.menuMapping[prevMenu].SetActive(false);
            if(MainMenuDatas.instance.menuMapping[nextMenu]!=null)
                MainMenuDatas.instance.menuMapping[nextMenu].SetActive(true);
        }
    }
}
