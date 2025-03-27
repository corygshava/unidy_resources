// last modified on 19/01/25 at 4:15PM - (last used in Codename racer)

using System.Collections;
using System;
using System.Reflection;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

// for using unity standard assets
// using UnityStandardAssets.Vehicles.Car;

public class cm : MonoBehaviour {

	// * gameObject ops
	public static void deact(GameObject what,int no){
		if(what != null){
			bool con = no != 1;
			what.SetActive (con);
		}
	}

	public static void deact(GameObject what,bool con){
		if(what != null){
			what.SetActive (con);
		}
	}

	public static void toggleActive(GameObject what){
		if(what != null){
			bool con = !what.activeSelf;
			what.SetActive (con);
		}
	}

	public static void deactArray(GameObject[] items,int reqNo){
		for (int x = 0; x < items.Length; x++) {
			if(items [x] != null){cm.deact (items [x], reqNo);}
		}
	}

	public static void deactArray(GameObject[] items,bool con){
		// false to enable, true to disable
		int reqNo = con ? 1 : 2;
		for (int x = 0; x < items.Length; x++) {
			if(items [x] != null){cm.deact (items [x], reqNo);}
		}
	}

	public static void deactArray(List<GameObject> items,bool con){
		// false to enable, true to disable
		int reqNo = con ? 1 : 2;

		for (int x = 0; x < items.Count; x++) {
			if(items [x] != null){cm.deact (items [x], reqNo);}
		}
	}

	public static void destroyArray(GameObject[] items){
		for (int x = 0; x < items.Length; x++) {
			if(items [x] != null){Destroy(items [x]);}
		}
	}

	public static void destroyArray(List<GameObject> items){
		for (int x = 0; x < items.Count; x++) {
			if(items [x] != null){Destroy(items [x]);}
		}
	}

	public static void destroyArray(GameObject[] items,float delay){
		for (int x = 0; x < items.Length; x++) {
			if(items [x] != null){Destroy(items [x],delay);}
		}
	}

	public static void destroyArray(List<GameObject> items,float delay){
		for (int x = 0; x < items.Count; x++) {
			if(items [x] != null){Destroy(items [x],delay);}
		}
	}

	public static GameObject getObject(GameObject rootItem,string path){
        string[] pathNodes = cm.splitTxt("/",path);
        GameObject temptrans = null;
		temptrans = rootItem;

        for (var x = 0; x < pathNodes.Length; x++){
            temptrans = temptrans.transform.Find(pathNodes[x]).gameObject;
        }

        return temptrans;
    }

	// debug.log alternatives

	public static void smartlog(Component who,string what){
        Debug.Log($"[{who.gameObject.name}] {what}");
    }

	public static void smartlog(string what){
        Debug.Log($"{what}");
    }

	public static void logme(Component who,string what){
        Debug.Log($"{who} : {what}");
    }

	public static void logme(string what){
        Debug.Log($"{what}");
    }

	/*
	assumes you have the unitystandard assets in your project

	public static void killAudio (GameObject thecar){
		// assumes you added StoopSoundAgain() in the CarAudio script

		thecar.GetComponent<CarAudio> ().StopSoundAgain ();
		thecar.GetComponent<CarAudio> ().enabled = false;
	}
	*/

	// * scene ops

	public static void loadLvla(int lnum){
		SceneManager.LoadScene (lnum);
	}

	public static void loadLvlb(string name){
		SceneManager.LoadScene (name);
	}

	public static void Restart(){
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
	}

	public static void QuitGame () {
		Application.Quit();
	}

	public static void loadLvlDelay(int sceneNo,float seconds){
		loadLvla (sceneNo);
		// Invoke("loadLvla",seconds,sceneNo);
		// print ("too many errors, so had to make it do the same thing as loadLvla");
	}

	// * UI ops

	public static bool checkTxt(GameObject textObject){
		return textObject.GetComponent<Text>();
	}

	public static void seTxt (GameObject textObject,string text){
		if(textObject == null){logme("no valid text object assigned");return;}
		if(textObject.GetComponent<Text>()){
			textObject.GetComponent<Text> ().text = text;
		}
	}

	public static void seTxt (GameObject textObject,string text,bool append){
		if(textObject == null){logme("no valid text object assigned");return;}
		if(textObject.GetComponent<Text>()){
			if(!append){seTxt(textObject,text);}
			else{addTxt(textObject,text);}
		}
	}

	public static string geTxt (GameObject textObject){
		string res = "nada";
		if(textObject == null){logme("no valid text object assigned");return $"{res} (no text assigned)";}
		if(textObject.GetComponent<Text>()){
			res = textObject.GetComponent<Text> ().text;
		}

		return res;
	}

	public static void addTxt (GameObject textObject,string text){
		if(textObject == null){logme("no valid text object assigned");return;}
		if(textObject.GetComponent<Text>()){
			textObject.GetComponent<Text> ().text += text;
		}
	}

	public static void seTxtColor (GameObject textObject,Color txtColor){
		if(textObject == null){logme("no valid text object assigned");return;}
		if(textObject.GetComponent<Text>()){
			textObject.GetComponent<Text> ().color = txtColor;
		}
	}

	public static void blockbtn(GameObject btn,int reqno){
		if (reqno == 1) {
			btn.GetComponent<Button> ().interactable = false;
		} else {
			btn.GetComponent<Button> ().interactable = true;
		}
	}

	public static void setColorText(GameObject thetext,Color thecolor){
		thetext.GetComponent<Text> ().color = thecolor;
	}

	public static void setTxtColor(GameObject thetext,Color thecolor){
		thetext.GetComponent<Text> ().color = thecolor;
	}

	public static Color getTxtColor(GameObject thetext){
		return thetext.GetComponent<Text> ().color;
	}

	public static void setColorBg(GameObject theImage,Color thecolor){
		if(theImage != null){
			if(theImage.GetComponent<Image> ()){
			theImage.GetComponent<Image> ().color = thecolor;
			}
		}
	}

	public static void setColorBgAmt(GameObject theImage,float amt){
		if(theImage != null){
			amt = Mathf.Clamp (amt, 0.0f, 1.0f);
			if(theImage.GetComponent<Image> ()){
				theImage.GetComponent<Image> ().fillAmount = amt;
			}
		}
	}

	public static void setBgAmt(GameObject theImage,float amt){
		if(theImage != null){
			amt = Mathf.Clamp (amt, 0.0f, 1.0f);
			if(theImage.GetComponent<Image> ()){
				theImage.GetComponent<Image> ().fillAmount = amt;
			}
		}
	}

	public static void setBg(GameObject theImage,Sprite image){
		if(theImage.GetComponent<Image> ()){
			theImage.GetComponent<Image> ().sprite = image;
		}
	}

	public static void setColorMat(Material mat,Color col){
		mat.color = col;
	}

	// array and list ops

	public static bool isInArray(GameObject needle,GameObject[] hay){
        int found = 0;
        for (var x = 0; x < hay.Length; x++){
            if(hay[x] == needle){found += 1;}
        }

        return found > 0;
    }

	public static bool isInArray(GameObject needle,List<GameObject> hay){
        int found = 0;
        for (var x = 0; x < hay.Count; x++){
            if(hay[x] == needle){found += 1;}
        }

        return found > 0;
    }

    public static bool isInList(GameObject needle,List<GameObject> hay){
        int found = 0;
        for (var x = 0; x < hay.Count; x++){
            if(hay[x] == needle){found += 1;}
        }

        return found > 0;
    }

	public static T[] ListToArray<T>(List<T> hay){
		T[] res = new T[hay.Count];

        for (var x = 0; x < hay.Count; x++){
            res[x] = hay[x];
        }

        return res;
    }

	public static List<T> ArrayToList<T>(T[] hay){
		List<T> res = new List<T>();

        for (var x = 0; x < hay.Length; x++){
            res.Add(hay[x]);
        }

        return res;
    }

	public static GameObject[] ListToArray(List<GameObject> hay){
		GameObject[] res = new GameObject[hay.Count];

        for (var x = 0; x < hay.Count; x++){
            res[x] = hay[x];
        }

        return res;
    }

	public static int getMyIndex(GameObject needle,GameObject[] hay){
		int res = 0;
        if(isInArray(needle,hay)){
			for (var x = 0; x < hay.Length; x++){
				if(hay[x] == needle){res = x;}
			}
		} else {
			logme("cm : unreliable output, "+needle.name+" is not in the presented array");
		}

		return res;
    }

	public static int getMyIndex(GameObject needle,List<GameObject> hay){
		int res = 0;
        if(isInArray(needle,hay)){
			for (var x = 0; x < hay.Count; x++){
				if(hay[x] == needle){res = x;}
			}
		} else {
			logme("cm : unreliable output, "+needle.name+" is not in the presented array ");
		}

		return res;
    }

    // special High level operations (Dont ask how they do what they do, just know that they work)

    public static object GetPropertyValue(object obj, string propertyName){
        Type classType = obj.GetType();
        PropertyInfo propertyInfo = classType.GetProperty(propertyName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
        if (propertyInfo != null){
            return propertyInfo.GetValue(obj);
        } else {
            Debug.LogError($"Property '{propertyName}' not found in class '{classType}'.");
            return null;
        }
    }

    public static void SetPropertyValue(object obj, string propertyName, object value){
        Type classType = obj.GetType();
        PropertyInfo propertyInfo = classType.GetProperty(propertyName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
        if (propertyInfo != null){
            propertyInfo.SetValue(obj, value);
            Debug.Log($"Updated {propertyName} value to: {value}");
        } else {
            Debug.LogError($"Property '{propertyName}' not found in class '{classType}'.");
        }
    }

	// * misc codes (i just kept adding functions until i got tired)

	public static void setDecalMat(Material mat,Texture decal){
		mat.mainTexture = decal;
	}

	public static Texture getDecalMat(Material mat){
		return mat.mainTexture;
	}

	public static void set3DText(GameObject text3d,string what){
		text3d.GetComponent<TextMesh> ().text = what;
	}

	public static void set3DTextColor(GameObject text3d,Color what){
		text3d.GetComponent<TextMesh> ().color = what;
	}

	public static string convertTime(float what){
		TimeSpan time = TimeSpan.FromSeconds(what);
		string hms = time.Minutes.ToString("00") + ":" + time.Seconds.ToString("00") + "." + time.Milliseconds.ToString("00");
		return hms;
	}

	public static string convertTimeLong(float what){
		TimeSpan time = TimeSpan.FromSeconds(what);
		string hms = time.Hours.ToString("00") + ":" + time.Minutes.ToString("00") + ":" + time.Seconds.ToString("00") + "." + time.Milliseconds.ToString("00");
		return hms;
	}

	public static string[] splitTxt(string separator,string what){
		return what.Split(new[] {separator},System.StringSplitOptions.None);
	}

	public static string[] splitTxt(string what){
		return what.Split(new[] {"|"},System.StringSplitOptions.None);
	}

	public static string joinTxt(string separator,string[] what){
		return string.Join(separator,what);
	}

	public static string plural(string what,int thecount){
		return (thecount == 1) ? $"{what}" : $"{what}s";
	}

	public static string vector3ToTxt(Vector3 what){
		return what.x + "," + what.y + "," + what.z;
	}

	public static string vector2ToTxt(Vector2 what){
		return what.x + "," + what.y;
	}

	public static Vector3 multiplyVector3(Vector3 a,Vector3 b){
		Vector3 res = new Vector3(a.x * b.x,a.y * b.y,a.z * b.z);
		return res;
	}

	public static Vector3 txtToVector3(string what){
		string[] res = splitTxt(",",what);
		Vector3 output = new Vector3(float.Parse(res[0]),float.Parse(res[1]),float.Parse(res[2]));
		return output;
	}

	public static Vector2 txtToVector2(string what){
		string[] res = splitTxt(",",what);
		Vector2 output = new Vector2(float.Parse(res[0]),float.Parse(res[1]));
		return output;
	}

	public static bool hasTxt(string needle,string hay){
		needle.ToLower();
		hay.ToLower();
		return hay.Contains(needle);
	}

	public static string getValue(GameObject what){
		string res = "";

		if(what.GetComponent<Text>()){
			res = what.GetComponent<Text>().text;
		}

		return res;
	}

	// pref ops

	public static void recordmyPref(string key,string mytype,int prefix){
		if(PlayerPrefs.HasKey(key)){
			// Debug.Log("pref : " + key + " - " +getpref(key,mytype,"none"));
		} else {
			mytype = mytype.ToLower();
			string registerMe = PlayerPrefs.GetString("registered_prefs" + prefix,"") + key + "|" + mytype + "_endl_";
			PlayerPrefs.SetString("registered_prefs" + prefix, registerMe);
			Debug.Log("pref registered");
		}
	}

	public static string getpref(string key,string mytype,string defaultValue){
		mytype = mytype.ToUpper();

		switch(mytype){
			case "INT":
				return PlayerPrefs.GetInt(key,int.Parse(defaultValue)) + "";
				break;
			case "FLOAT":
				return PlayerPrefs.GetFloat(key,float.Parse(defaultValue)) + "";
				break;
			default:
				return PlayerPrefs.GetString(key,defaultValue) + "";
				break;
		}
	}

	#region
	public static void setpref(string key,string mytype,string thevalue){
		mytype = mytype.ToUpper();

		switch(mytype){
			case "INT":
				PlayerPrefs.SetInt(key,int.Parse(thevalue));
				break;
			case "FLOAT":
				PlayerPrefs.SetFloat(key,float.Parse(thevalue));
				break;
			default:
				PlayerPrefs.SetString(key,thevalue);
				break;
		}
	}

	public static void updatepref(string thekey,string thetype,string thevalue,string theaction){
        theaction = theaction.ToUpper();
        thetype = thetype.ToUpper();
		string val = thevalue;

        switch (theaction){
            case "ADD":
				if(thetype != "STRING"){
                	val = getpref(thekey,thetype,"0");
				} else {
					val = getpref(thekey,thetype,"");
				}

                if(thetype == "INT"){val = (int.Parse(val) + int.Parse(thevalue)) + "";}
                else if(thetype == "FLOAT"){val = (float.Parse(val) + float.Parse(thevalue)) + "";}
                else {val = val + thevalue;}
                break;
			case "MINUS":
				val = getpref(thekey,thetype,"0");

                if(thetype == "INT"){val = (int.Parse(val) - int.Parse(thevalue)) + "";}
                else if(thetype == "FLOAT"){val = (float.Parse(val) - float.Parse(thevalue)) + "";}
                else {Debug.Log("cm : cant minus from a string");}
				break;
			case "DELETE":
				killpref(theaction);
				return;
			case "KILL":
				killpref(theaction);
				return;
			case "UPDATE":
				break;
            default:
				val = getpref(thekey,thetype,"0");
				logme("cm : specify an action first");
                break;
        }

		setpref(thekey,thetype,val);
    }
	#endregion

	public static void killpref(string mykey){
		if(PlayerPrefs.HasKey(mykey)){PlayerPrefs.DeleteKey(mykey);}
	}

	//end of statics

	//public functions (requires cm to be attached to a gameObject) also usefull for unity events

	public void b_deact(GameObject what,int no){
		if(what != null){
			if (no == 1) {
				what.SetActive (false);
			} else {
				what.SetActive (true);
			}
		}
	}

	public void b_toggleActive(GameObject what){
		if(what != null){
			bool con = !what.activeSelf;
			what.SetActive (con);
		}
	}

	public void b_destroyArray(GameObject[] items){
		for (int x = 0; x < items.Length; x++) {
			if(items [x] != null){Destroy(items [x]);}
		}
	}

	public void b_destroyArray(List<GameObject> items){
		for (int x = 0; x < items.Count; x++) {
			if(items [x] != null){Destroy(items [x]);}
		}
	}

	public void b_logme(string what){
        Debug.Log($"{what}");
    }

	public void b_smartlog(string what){
        Debug.Log($"{what}");
    }

	public void b_seTxt (GameObject textObject,string text){
		textObject.GetComponent<Text> ().text = text;
	}

	public void b_blockbtn(GameObject btn,int reqno){
		if (reqno == 1) {
			btn.GetComponent<Button> ().interactable = false;
		} else {
			btn.GetComponent<Button> ().interactable = true;
		}
	}

	public void b_LoadLvla(int lnum){
		SceneManager.LoadScene (lnum);
	}

	public void b_loadLvlb(string name){
		SceneManager.LoadScene (name);
	}

	public void b_Restart(){
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
	}

	public void b_deactArray(GameObject[] items,int reqNo){
		for (int x = 0; x < items.Length; x++) {
			if(items [x] != null){cm.deact (items [x], reqNo);}
		}
	}

	public void showIt(GameObject what){
		deact (what,2);
	}

	public void hideIt(GameObject what){
		deact (what,1);
	}

	public void showItB(GameObject what){
		deact (what,2);
		gameObject.SetActive (false);
	}

	public void hideItB(GameObject what){
		deact (what,1);
		gameObject.SetActive (false);
	}

	public void b_toggleMe(GameObject what){
		toggleActive(what);
	}

	public void b_setColorText(GameObject thetext,Color thecolor){
		thetext.GetComponent<Text> ().color = thecolor;
	}

	public void b_setColorBg(GameObject theImage,Color thecolor){
		if(theImage.GetComponent<Image> ()){
			theImage.GetComponent<Image> ().color = thecolor;
		}
	}

	public void b_setColorMat(Material mat,Color col){
		mat.color = col;
	}

	public void b_setDecalMat(Material mat,Texture decal){
		mat.mainTexture = decal;
	}

	public void b_set3DText(GameObject text3d,string what){
		text3d.GetComponent<TextMesh> ().text = what;
	}

	public void b_set3DTextColor(GameObject text3d,Color what){
		text3d.GetComponent<TextMesh> ().color = what;
	}

	public void b_quitGame(){
		print ("quiting");
		Application.Quit ();
	}

	public void b_loadLvlDelay(int sceneNo,float seconds){
		StartCoroutine (b_startScene(sceneNo,seconds));
	}

	public void KillMe(){
		deact (gameObject, 1);
	}

	IEnumerator b_startScene (int SceneNo, float seconds){
		yield return new WaitForSeconds (seconds);
		cm.loadLvla (SceneNo);
	}
}

// some public enums
public enum updatemode{Normal,FixedUpdate,LateUpdate};