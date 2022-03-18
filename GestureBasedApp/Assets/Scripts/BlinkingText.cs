using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingText : MonoBehaviour
{
    [SerializeField] Text start;
    [SerializeField] Text tutorial;
    private float blinkFadeIn = 0.5f;
    private float blinkStayTime = 0.8f;
    private float blinkFadeOut = 0.5f;
    private float _timeChecker = 0;
    private Color _color;

    // Start is called before the first frame update
    void Start()
    {
        _color = start.color;
    }

    // Update is called once per frame
    void Update()
    {
        _timeChecker +=Time.deltaTime;

        if(_timeChecker <blinkFadeIn)
        {
            tutorial.color = start.color = new Color(_color.r,_color.g,_color.b, _timeChecker / blinkFadeIn); 
        }
        else if(_timeChecker < blinkFadeIn + blinkStayTime)
        {
            tutorial.color = start.color = new Color(_color.r,_color.g,_color.b, 1); 
        }
        else if(_timeChecker <blinkFadeIn + blinkStayTime + blinkFadeOut )
        {
            tutorial.color = start.color = new Color(_color.r,_color.g,_color.b, 1- (_timeChecker - (blinkFadeIn + blinkStayTime))/blinkFadeOut);
        }
        else{
            _timeChecker =0;
        }     
    }
}
