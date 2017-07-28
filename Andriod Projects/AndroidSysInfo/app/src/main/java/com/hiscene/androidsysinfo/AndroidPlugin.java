package com.hiscene.androidsysinfo;

import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;
import android.os.BatteryManager;
import java.text.SimpleDateFormat;
import java.util.Date;

/**
 * Created by roly on 2017/7/27.
 */

public class AndroidPlugin
{
    private Context context;

    public AndroidPlugin(Context context)
    {
        this.context = context;
    }

    
    public float GetBatteryPct()
    {
        Intent batteryStatus = GetBatteryStatusIntent();

        int level = batteryStatus.getIntExtra(BatteryManager.EXTRA_LEVEL, -1);
        int scale = batteryStatus.getIntExtra(BatteryManager.EXTRA_SCALE, -1);

        float batteryPct = level / (float)scale;
        return batteryPct;
    }

    public boolean IsBatteryCharging()
    {
        Intent batteryStatus = GetBatteryStatusIntent();

        int status = batteryStatus.getIntExtra(BatteryManager.EXTRA_STATUS, -1);
        return status == BatteryManager.BATTERY_STATUS_CHARGING ||
                status == BatteryManager.BATTERY_STATUS_FULL;
    }

    private Intent GetBatteryStatusIntent()
    {
        IntentFilter ifilter = new IntentFilter(Intent.ACTION_BATTERY_CHANGED);
        return context.registerReceiver(null, ifilter);
    }

    public String getSysTime(){
        return new SimpleDateFormat("yyyy-MM-dd HH:mm:ss").format(new Date()).toString();
    }
}
