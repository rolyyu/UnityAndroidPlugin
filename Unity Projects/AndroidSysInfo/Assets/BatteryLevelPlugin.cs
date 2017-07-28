using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryLevelPlugin{

    public static float GetBatteryLevel()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            using (var javaUnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            {
                using (var currentActivity = javaUnityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
                {
                    using (var androidPlugin = new AndroidJavaObject("com.hiscene.androidsysinfo.AndroidPlugin", currentActivity))
                    {
                        return androidPlugin.Call<float>("GetBatteryPct");
                    }
                }
            }
        }

        return 1f;
    }

    public static string GetSysTime() {

        AndroidJNI.AttachCurrentThread();


        IntPtr javaClass = AndroidJNI.FindClass("com/unity3d/player/UnityPlayer");

        IntPtr fid = AndroidJNI.GetStaticFieldID(javaClass, "currentActivity", "Landroid/app/Activity;");

        IntPtr obj = AndroidJNI.GetStaticObjectField(javaClass, fid);


        IntPtr pluginClass = AndroidJNI.FindClass("com/hiscene/androidsysinfo/AndroidPlugin");

        IntPtr initMethod = AndroidJNI.GetMethodID(pluginClass, "<init>", "(Landroid/content/Context;)V");

        jvalue[] jv = new jvalue[1];

        //TODO
        
        IntPtr pobj = AndroidJNI.NewObject(pluginClass, initMethod,jv);


        IntPtr enableMethod = AndroidJNI.GetMethodID(pluginClass, "getSysTime", "()Ljava/lang/String;");

        return AndroidJNI.CallStringMethod(pobj, enableMethod, new jvalue[1]);

    }

    public static string GetSysTimeAndroidJNI()
    {

        AndroidJNI.AttachCurrentThread();

        IntPtr javaClass = AndroidJNI.FindClass("com/hiscene/androidsysinfo/SysTime");

        IntPtr initMethod = AndroidJNI.GetMethodID(javaClass, "<init>", "()V");


        IntPtr pobj = AndroidJNI.NewObject(javaClass, initMethod, AndroidJNIHelper.CreateJNIArgArray(new object[1]));


        IntPtr enableMethod = AndroidJNI.GetMethodID(javaClass, "getSysTime", "()Ljava/lang/String;");

        return AndroidJNI.CallStringMethod(pobj, enableMethod, new jvalue[1]);

    }

    public static string GetSysTimeAndroidJavaClass()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            using (var javaUnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            {
                using (var currentActivity = javaUnityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
                {
                    using (var androidPlugin = new AndroidJavaObject("com.hiscene.androidsysinfo.AndroidPlugin", currentActivity))
                    {
                        return androidPlugin.Call<string>("getSysTime");
                    }
                }
            }
        }

        return "Time yyyy-MM-dd HH:mm:ss";
    }
}
