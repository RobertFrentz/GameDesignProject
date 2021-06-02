using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnSound : MonoBehaviour
{
    	public AudioSource hoverS;
    	public AudioSource clickS;
    	public void HoverSound() {
		hoverS.Play();
	}
    	public void ClickSound(){
		clickS.Play();
    	}

}
