package com.hiscene.androidsysinfo;

import java.text.SimpleDateFormat;
import java.util.Date;

/**
 * Created by roly on 2017/7/27.
 */
public class SysTime {
    //Get System Time
    public String getSysTime(){
        return new SimpleDateFormat("yyyy-MM-dd HH:mm:ss").format(new Date()).toString();
    }
}
