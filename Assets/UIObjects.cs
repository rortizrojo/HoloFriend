using UnityEngine;

public class UIObjects : MonoBehaviour {

    public GameObject ball;
    public GameObject bone;
    public GameObject foodBowl;
    public GameObject waterBowl;
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ShowBall() {
        ball.SetActive(true);

    }

}
