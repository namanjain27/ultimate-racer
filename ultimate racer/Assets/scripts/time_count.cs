using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class time_count : MonoBehaviour
{
    public static int min;
    public static int sec;
    public static float milli;
    


    public Text min_count;
    public Text sec_count;
    public Text milli_count;

    

    void count_total_time()
    {
        milli += Time.deltaTime * 10;
        milli_count.text = milli.ToString("F0");
        if (milli >= 10f)
        {
            milli = 0;
            sec += 1;
        }
        if (sec <= 9)
        {
            sec_count.text = ("0" + sec + ".").ToString();
        }
        else
        {
            sec_count.text = ("" + sec + ".").ToString();
        }
        if (sec >= 60)
        {
            sec = 0;
            min += 1;
        }
        if (min <= 9)
        {
            min_count.text = ("0" + min + ".").ToString();
        }
        else
        {
            min_count.text = ("" + min + ".").ToString();
        }
    }

    private void Update()
    {
        count_total_time();
    }
        

}
