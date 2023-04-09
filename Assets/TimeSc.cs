using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSc : MonoBehaviour
{
    public Text[] timeText;
    float time = 25;
    int min, sec;
    // Start is called before the first frame update
    void Start()
    {
        // 제한 시간 설정
        timeText[0].text = "00";
        timeText[1].text = "25";
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        //timeValue = 0;
       

        min = (int)time / 60;
        sec = ((int)time - min * 60) % 60;

        if (min <= 0 && sec <= 0)
        {
            timeText[0].text = 0.ToString();
            timeText[1].text = 0.ToString();
        }

        else
        {
            if (sec >= 60)
            {
                min += 1;
                sec -= 60;
            }

            else
            {
                timeText[0].text = min.ToString();
                timeText[1].text = sec.ToString();
            }
        }
 
    }
}