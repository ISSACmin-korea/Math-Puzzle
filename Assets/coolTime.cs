using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coolTime : MonoBehaviour
{
    public Image coolTimeSlider;
    public Text coolTimeText;

    private bool canSlider;
    private float coolTimedownTime;

    private float updateTime;

    void Start()
    {
        canSlider = true;
        updateTime = 0.0f;
        coolTimedownTime = 60.0f;
    }

    void Update()
    {
        if (canSlider)
        {
            updateTime = updateTime + Time.deltaTime;
            coolTimeSlider.fillAmount = 1.0f - (Mathf.SmoothStep(0, 100, updateTime / coolTimedownTime) / 100);

            if(60 - (int)(updateTime) == 0)
            {
                coolTimeText.text = "STOP";
                coolTimeText.color = Color.red;
            }
            else
            {
                coolTimeText.text = (60 - (int)(updateTime)).ToString();
            }

            if (updateTime > coolTimedownTime)
            {
                coolTimeSlider.fillAmount = 0.0f;
                updateTime = 0.0f;
                canSlider = false;
            }
        }
    }
}
