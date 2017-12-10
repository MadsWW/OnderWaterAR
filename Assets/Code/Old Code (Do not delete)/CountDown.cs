using System;
using System.Timers;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    private int cDownFrom = 10;
    private Coroutine corout;
    private bool timeLeft;

    public Text text;

    public int CDownFrom
        {
            get
            {
                return cDownFrom;
            }
        }

    public bool TimeLeft
        {
            get
            {
                return timeLeft;
            }
        }

    public void InitCountDown(int countDownFrom)
    {
        cDownFrom = countDownFrom;
        timeLeft = true;
    }

    public void StartCountDown()
        {
            corout = StartCoroutine(CountDownEnabled());
        }

    public void StopCountDown()
        {
            StopCoroutine(corout);
        }

    private IEnumerator CountDownEnabled()
    {
        while (cDownFrom > 0)
        {
            yield return new WaitForSeconds(1);
            cDownFrom--;
            SetTimerText();
        }

        if (cDownFrom <= 0)
        {
            timeLeft = false;
        }
    }

    private void SetTimerText()
    {
        text.text = "Time: " + cDownFrom;
    }
}