package com.hiscene.unitydemo;

import android.app.Activity;
import android.app.AlertDialog;
import android.os.Bundle;
import android.widget.Toast;

import com.unity3d.player.UnityPlayer;
import com.unity3d.player.UnityPlayerActivity;

public class MainActivity extends UnityPlayerActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }
    //Unity端调用该函数
    public void ShowToast(final String msg){
        // 需要在UI线程下执行
        runOnUiThread(new Runnable() {
            @Override
            public void run() {
                Toast.makeText(getApplicationContext(),msg, Toast.LENGTH_SHORT).show();
                new AlertDialog.Builder(MainActivity.this).setMessage(msg).show();
            }
        });
    }
    //Unity端调用该函数
    public void setUnityText(){
        runOnUiThread(new Runnable() {
            @Override
            public void run() {
                Toast.makeText(getApplicationContext(),"Android 端调用setText", Toast.LENGTH_SHORT).show();
                //调用Unity端函数
                UnityPlayer.UnitySendMessage("Canvas","setText","Android 端调用setText");
            }
        });
    }

}
