using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounterRound : MonoBehaviour
{
    public GameObject textDisplay;
    public int secondLeft;
    public bool takingAway = false;

    public void Start()
    {
        var timer = Mathf.Max(0, secondLeft - Time.deltaTime);
        var timeSpan = System.TimeSpan.FromSeconds(timer);
        textDisplay.GetComponent<Text>().text = timeSpan.Hours.ToString("00") + ":" +
                                                timeSpan.Minutes.ToString("00") + ":" +
                                                timeSpan.Seconds.ToString("00");
    }
    public void Update()
    {
        if (takingAway == false && secondLeft > 0)
        {

            StartCoroutine(TimerTake());
        }
    }

    public IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondLeft -= 1;
        var timer = Mathf.Max(0, secondLeft - Time.deltaTime);
        var timeSpan = System.TimeSpan.FromSeconds(timer);
        textDisplay.GetComponent<Text>().text = timeSpan.Hours.ToString("00") + ":" +
                                                timeSpan.Minutes.ToString("00") + ":" +
                                                timeSpan.Seconds.ToString("00");
        takingAway = false;
    }
}
