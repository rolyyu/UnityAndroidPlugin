using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AndroidTest : MonoBehaviour {


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void BtnShowMessage()
	{
        using (AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            using(AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity"))
            {
                // 调用Android端方法
                jo.Call("ShowToast", "Unity调用了Android中的AlertDialog");
            }
        } 
	}

    public void BtnSetText()
    {
        using (AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            using (AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity"))
            {
                jo.Call("setUnityText");
            }
        }
    }

	//Android端调用该方法
	public void setText(string result){
		Text text = GameObject.Find ("UnityText").GetComponent<Text> ();
		text.text = result;
	}

}
