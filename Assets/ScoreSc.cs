using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSc : MonoBehaviour
{
    public Text Score;
    public static int score;
    // Start is called before the first frame update
    void Start()
    {
        //Score = GetComponent<scoreSc>();
        SetText();
    }


    // Update is called once per frame
    void Update()
    {
        //score += 10; //몹 죽을 때 올라가는걸로 변경

        SetText();
    }

    public void SetText()
    {
        Score.text = string.Format($"Score : {score}");
    }
}
