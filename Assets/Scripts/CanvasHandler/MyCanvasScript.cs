using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MyCanvasScript : MonoBehaviour {

	public static MyCanvasScript instance;

	public GameObject progressDialog, dialogBox, toast, inputBox, listPanel, listPanelHolder, listButtonPrefab;
	public Text progressTitleText, progressDetailsTxt, toastText;
	public Text dialogTitleText, dialogDetailsTxt, dialogBtnOk, dialogBtnDisc;
	public Image progressImage;
	public Button dialogOkBtn, dialogCancelBtn;
	private RectTransform dialogOkTrans, dialogCancelTrans;

	public Text inputTitleText, inputPlaceHolder;
	public InputField inputField;
	public Button inputBtnOk;
	private Vector2 dOkV, dCancelV;


	void Awake(){
		instance=this;
	}
	// Use this for initialization
	void Start () {
		dialogOkTrans = dialogOkBtn.transform.GetComponent<RectTransform>();
		dialogCancelTrans = dialogCancelBtn.transform.GetComponent<RectTransform>();
		dOkV=dialogOkTrans.anchoredPosition;
		dCancelV=dialogCancelTrans.anchoredPosition;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// public void showList(string[] displayNames, Action[] actions){
	// 	gameObject.SetActive(true);
	// 	listPanel.SetActive(true);
	// 	foreach(Transform t in listPanelHolder.transform){
	// 		Destroy(t.gameObject);
	// 	}

	// 	for(int i=0;i<displayNames.Length && i<actions.Length;i++){
	// 		GameObject obj = GameObject.Instantiate(listButtonPrefab);
	// 		obj.transform.SetParent(listPanelHolder.transform,false);
	// 		ListButtonScript script = obj.GetComponent<ListButtonScript>();
	// 		script.init(actions[i], displayNames[i]);
	// 	}
	// }
	public void hideList(){
		listPanel.SetActive(false);
		gameObject.SetActive(false);
	}
	private bool bProgress;
	public void showProgressDialog(string title, string details){
		gameObject.SetActive(true);
		progressDialog.SetActive(true);
		progressTitleText.text = title;
		progressDetailsTxt.text = details;
		StartCoroutine(rotateProgress());
	}
	private IEnumerator rotateProgress(){
		// bProgress=true;
		// progressImage.fillClockwise=true;
		// progressImage.fillAmount=0;
		// while(bProgress){
		// 	if(progressImage.fillClockwise){
		// 		progressImage.fillAmount += 0.05f;
		// 		if(progressImage.fillAmount>=1){
		// 			progressImage.fillAmount=1;
		// 			progressImage.fillClockwise=false;
		// 		}
		// 	}else{
		// 		progressImage.fillAmount -= 0.05f;
		// 		if(progressImage.fillAmount<=0){
		// 			progressImage.fillAmount=0;
		// 			progressImage.fillClockwise=true;
		// 		}
		// 	}
		// 	yield return new WaitForSeconds(0.03f);
		// }
		// progressImage.fillClockwise=true;
		// progressImage.fillAmount=0;
		bProgress=true;
		Quaternion rot = progressImage.gameObject.transform.rotation;
		rot.z=0;
		progressImage.gameObject.transform.rotation=rot;
		while(bProgress){
			rot = progressImage.gameObject.transform.rotation;
			rot = Quaternion.Euler(rot.eulerAngles-new Vector3(0,0,7));
			// Debug.Log("Angle : "+rot.z+" : "+(rot.z+0.05f));
			// rot.z = rot.z+0.05f;
			progressImage.gameObject.transform.rotation=rot;
			// Debug.Log("Angle2 : "+progressImage.gameObject.transform.rotation.z);
			yield return new WaitForSeconds(0.03f);
		}
		rot = progressImage.gameObject.transform.rotation;
		rot.z=0;
		progressImage.gameObject.transform.rotation=rot;
		yield break;
	}
	public void hideProgressDialog(){
		bProgress=false;
		progressDialog.SetActive(false);
		gameObject.SetActive(false);
	}

	public void showDialogBox(string title, string details, Action okReturn, Action cancelReturn=null, string okButtonTxt="Ok", string cancelBtnTxt="Cancel", bool twoButtons=true){
		gameObject.SetActive(true);
		dialogBox.SetActive(true);
		
		if(twoButtons){
			dialogOkBtn.gameObject.SetActive(true);
			dialogCancelBtn.gameObject.SetActive(true);
			dialogOkTrans.anchoredPosition=dOkV;
			dialogCancelTrans.anchoredPosition=dCancelV;
		}else{
			dialogOkBtn.gameObject.SetActive(true);
			dialogCancelBtn.gameObject.SetActive(false);
			dialogOkTrans.anchoredPosition=dCancelV;
			dialogCancelTrans.anchoredPosition=dCancelV;
		}
		dialogTitleText.text = title;
		dialogDetailsTxt.text = details;
		dialogBtnOk.text=okButtonTxt;
		dialogBtnDisc.text=cancelBtnTxt;

		dialogOkBtn.onClick.RemoveAllListeners();
		dialogCancelBtn.onClick.RemoveAllListeners();

		dialogOkBtn.onClick.AddListener(()=>hideDialogBox());
		if(okReturn!=null)
			dialogOkBtn.onClick.AddListener(()=>okReturn());

		dialogCancelBtn.onClick.AddListener(()=>hideDialogBox());
		if(cancelReturn!=null)
			dialogCancelBtn.onClick.AddListener(()=>cancelReturn());
	}
	public void showYesNoDialog(string title, string details, Action<bool> callBack, string okButtonTxt="Yes", string cancelBtnTxt="No", bool twoButtons=true){
		gameObject.SetActive(true);
		dialogBox.SetActive(true);
		
		if(twoButtons){
			dialogOkBtn.gameObject.SetActive(true);
			dialogCancelBtn.gameObject.SetActive(true);
			dialogOkTrans.anchoredPosition=dOkV;
			dialogCancelTrans.anchoredPosition=dCancelV;
		}else{
			dialogOkBtn.gameObject.SetActive(true);
			dialogCancelBtn.gameObject.SetActive(false);
			dialogOkTrans.anchoredPosition=dCancelV;
			dialogCancelTrans.anchoredPosition=dCancelV;
		}
		dialogTitleText.text = title;
		dialogDetailsTxt.text = details;
		dialogBtnOk.text=okButtonTxt;
		dialogBtnDisc.text=cancelBtnTxt;

		dialogOkBtn.onClick.RemoveAllListeners();
		dialogCancelBtn.onClick.RemoveAllListeners();

		dialogOkBtn.onClick.AddListener(()=>hideDialogBox());
		if(callBack!=null)
			dialogOkBtn.onClick.AddListener(()=>callBack(true));

		dialogCancelBtn.onClick.AddListener(()=>hideDialogBox());
		if(callBack!=null)
			dialogCancelBtn.onClick.AddListener(()=>callBack(false));
	}
	
	public void showInputBox(string title, string placeHolder, Action<string> okReturn){
		gameObject.SetActive(true);
		inputBox.SetActive(true);

		inputTitleText.text=title;
		inputPlaceHolder.text=placeHolder;
		inputField.text="";
		inputBtnOk.onClick.RemoveAllListeners();
		inputBtnOk.onClick.AddListener(() => hideInputBox());
		inputBtnOk.onClick.AddListener(() => okReturn(inputField.text));
	}

	private void hideInputBox(){
		inputBox.SetActive(false);
		gameObject.SetActive(false);
	}
	private void hideDialogBox(){
		dialogBox.SetActive(false);
		gameObject.SetActive(false);
	}
	public void showToast(string txt, float seconds=2){
		gameObject.SetActive(true);
		toast.SetActive(true);
		toastText.text = txt;
		StartCoroutine(switchOffToast(seconds));
	}

	private IEnumerator switchOffToast(float secs){
		yield return new WaitForSeconds(secs);
		toast.SetActive(false);
		gameObject.SetActive(false);
		yield break;
	}
}
