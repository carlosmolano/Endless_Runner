using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour {

    private Image bg; 

	// Use this for initialization
	void Start () {
        bg = GetComponent<Image>();
        StartCoroutine(FadeIn(1));
	}
	
    IEnumerator FadeIn(float alphaTarget){
        while(bg.color.a != alphaTarget){
            Color c = bg.color;
            c.a = Mathf.MoveTowards(c.a, alphaTarget, Time.deltaTime);
            bg.color = c;
            yield return null;
        }
    }
}
