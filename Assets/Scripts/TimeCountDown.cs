using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCountDown : MonoBehaviour
{
    public GameObject textDisplay;
    public int secondLeft = 3;
    public bool takingAway = false;

    public void Start()
    {
        textDisplay.GetComponent<Text>().text = "" + secondLeft;
    }
    public void Update()
    {
        if(takingAway == false && secondLeft > 0)
        {
            
            StartCoroutine(TimerTake());
        }
        else if(takingAway == false && secondLeft < 0)
        {
            StartCoroutine(TimerTake());
        }
    }

    public IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondLeft -= 1;
        if (secondLeft == 0)
        {
            textDisplay.GetComponent<Text>().text = "" ;
        }
        else
        {
            textDisplay.GetComponent<Text>().text = "" + secondLeft;
        }
        
        takingAway = false;
    }
}
