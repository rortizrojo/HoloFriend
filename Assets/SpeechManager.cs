using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class SpeechManager : MonoBehaviour
{
    public GameObject toy;
    public GameObject ball;
    public GameObject avatar;
    public GameObject canvas;
    public GameObject renderSM;
    public GameObject water;
    public GameObject food;
    public GameObject instructionsCanvas;
    public GameObject voiceCommandsCanvas;

    KeywordRecognizer keywordRecognizer = null;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();



    // Use this for initialization
    void Start()
    {
        
        keywords.Add("Reset ball", () =>
        {
            // Call the OnReset method on ball object.
            ball.SendMessage("OnReset");
        });

        //Is used the word toy because "bone" is similar to "ball" and the KeywordRecognizer could confuse
        keywords.Add("Reset toy", () =>
        {
            // Call the OnReset method on bone object.
            toy.SendMessage("OnReset");
        });

        keywords.Add("Paw", () =>
        {
            // Call the OnPaw method on avatar object.
            avatar.SendMessage("OnPaw");
        });

        keywords.Add("Sit", () =>
        {
            // Call the OnSit method on avatar object.
            avatar.SendMessage("OnSit");
        });

        keywords.Add("Get up", () =>
        {
            // Call the OnUp method on avatar object.
            avatar.SendMessage("OnUp");
        });

        keywords.Add("Canvas", () =>
        {
            // Call the OnResetCanvas method on canvas object.
            canvas.SendMessage("OnResetCanvas");
        });

        keywords.Add("Render", () =>
        {
            // Call the OnRender method on renderSM object.
            renderSM.SendMessage("OnRender");
        });

        
        keywords.Add("Food", () =>
        {
            // Call the OnSelect method on food object.
            food.SendMessage("OnSelect");
        });

        keywords.Add("Water", () =>
        {
            // Call the OnSelect method on water object.
            water.SendMessage("OnSelect");
        });
        

        keywords.Add("Help", () =>
        {
            // Enable/Disable the instructions canvas
            Debug.Log("instructionsCanvas: " + instructionsCanvas.activeSelf);
            instructionsCanvas.SetActive(!instructionsCanvas.activeSelf);
            voiceCommandsCanvas.SetActive(false);
        });

        keywords.Add("Voice", () =>
        {
            // Enable/Disable the instructions canvas
            Debug.Log("voiceCommandsCanvas: " + voiceCommandsCanvas.activeSelf);
            voiceCommandsCanvas.SetActive(!voiceCommandsCanvas.activeSelf);
            instructionsCanvas.SetActive(false);
        });


        // Tell the KeywordRecognizer about our keywords.
        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());

        // Register a callback for the KeywordRecognizer and start recognizing!
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        keywordRecognizer.Start();
    }


    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;
        if (keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
        }
    }
}
