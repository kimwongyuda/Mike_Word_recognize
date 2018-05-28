using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class SpeechRecognition : MonoBehaviour {

    public string[] keywords = new string[] { "shot", "shotshot", "shot shot", "shotshotshot", "shot shot shot", "main"};
    public ConfidenceLevel confidence = ConfidenceLevel.Medium;
    public Text result;
    public Image target;

    protected PhraseRecognizer recognizer;
    public string word;
    public int count;

	// Use this for initialization
	void Start () {
        count = 0;
		if (keywords != null)
        {
            recognizer = new KeywordRecognizer(keywords, confidence);
            recognizer.OnPhraseRecognized += Recognizer_OnPhraseRecognized;
            recognizer.Start();
            //print(word);
        }
	}

    private void Recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        word = args.text;
        result.text = "You Said: <b>" + word + "</b>";
    }
	
	// Update is called once per frame
	void Update () {
		switch (word)
        {
            case "shot":
                count++;
                break;
            case "shotshot":
                count+= 2;
                break;
            case "shot shot":
                count += 2;
                break;
            case "shotshotshot":
                count += 3;
                break;
            case "shot shot shot":
                count += 3;
                break;
            case "main":
                print("main");
                break;
        }
        word = "";
        Debug.Log(count);
    }
}
