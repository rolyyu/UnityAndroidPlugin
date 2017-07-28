using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryMonitor : MonoBehaviour {

    public Text batteryLevelText;
    public Text batteryLevelIcon;
    public Text sysTime;

    static readonly string BATTERY_LEVEL_100 = Char.ConvertFromUtf32(0xf240);
    static readonly string BATTERY_LEVEL_75 = Char.ConvertFromUtf32(0xf241);
    static readonly string BATTERY_LEVEL_50 = Char.ConvertFromUtf32(0xf242);
    static readonly string BATTERY_LEVEL_25 = Char.ConvertFromUtf32(0xf243);
    static readonly string BATTERY_LEVEL_0 = Char.ConvertFromUtf32(0xf244);


    void Update () {
        UpdateStatusIndicators();
        sysTime.text = BatteryLevelPlugin.GetSysTime();
        
	}

    void UpdateStatusIndicators()
    {
        var currentBatteryLevel = BatteryLevelPlugin.GetBatteryLevel() * 100f;
        batteryLevelText.text = String.Format("{0}%", currentBatteryLevel);

        if (currentBatteryLevel >= 88)
        {
            batteryLevelIcon.text = BATTERY_LEVEL_100;
        }
        else if (currentBatteryLevel >= 63)
        {
            batteryLevelIcon.text = BATTERY_LEVEL_75;
        }
        else if (currentBatteryLevel >= 38)
        {
            batteryLevelIcon.text = BATTERY_LEVEL_50;
        }
        else if (currentBatteryLevel >= 13)
        {
            batteryLevelIcon.text = BATTERY_LEVEL_25;
        }
        else
        {
            batteryLevelIcon.text = BATTERY_LEVEL_0;
        }
    }
}
