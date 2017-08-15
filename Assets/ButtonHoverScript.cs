using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHoverScript : MonoBehaviour {

    ColorBlock colors;
    Color normalColor;
    Color highlightedColor;
    public GameObject Object;
    private bool hasChanged;
    public bool isHover;
    //private bool lastState;

    // Use this for initialization
    void Start () {

        isHover = false;

        colors = new ColorBlock();

        highlightedColor =  gameObject.GetComponent<Button>().colors.highlightedColor;
        normalColor = gameObject.GetComponent<Button>().colors.normalColor;

        colors.normalColor = normalColor;
        colors.fadeDuration = gameObject.GetComponent<Button>().colors.fadeDuration;
        colors.colorMultiplier = gameObject.GetComponent<Button>().colors.colorMultiplier;
        colors.highlightedColor = highlightedColor;
        colors.disabledColor = gameObject.GetComponent<Button>().colors.disabledColor;
        colors.pressedColor = gameObject.GetComponent<Button>().colors.pressedColor;
    }
	
	// Update is called once per frame
	void Update () {


            if (isHover)
            {
               // Debug.Log(gameObject.name + ": Changing color");
                colors.normalColor = highlightedColor;
                colors.highlightedColor = normalColor;
                gameObject.GetComponent<Button>().colors = colors;
                isHover = false;
                
            }
            else
            {
                colors.normalColor = normalColor;
                colors.highlightedColor = highlightedColor;
                gameObject.GetComponent<Button>().colors = colors;
            }
   
    }

    void OnHover()
    {
        //Debug.Log(gameObject.name + ": On Hover");
        isHover = true;
    }

    
    void OnSelect()
    {
        Debug.Log(gameObject.name + ": On Select");
        gameObject.GetComponent<Button>().onClick.Invoke();
        Object.GetComponent<PositionManager>().SetPosition(
                                            gameObject.transform.position.x,
                                            gameObject.transform.position.y,
                                            gameObject.transform.position.z);
    }
}
