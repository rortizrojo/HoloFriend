using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class SpeechManager : MonoBehaviour
{
    public GameObject toy;
    public GameObject ball;
    public GameObject avatar;

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

        keywords.Add("Give me a paw", () =>
        {
            // Call the GiveMeAPaw method on avatar object.
            avatar.SendMessage("OnGiveMeAPaw");
        });




        /*
        keywords.Add("Drop Sphere", () =>
        {
            var focusObject = GazeGestureManager.Instance.FocusedObject;
            if (focusObject != null)
            {
                // Call the OnDrop method on just the focused object.
                focusObject.SendMessage("OnDrop");
            }
        });*/

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
