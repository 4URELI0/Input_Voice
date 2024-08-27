using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Windows.Speech;
using System.Diagnostics.Tracing;
using System;

public class InputVoice : MonoBehaviour
{
    KeywordRecognizer keywordRecognizer;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    private void Start()
    {
        keywords.Add("Insomnio", Insomnio);
        keywords.Add("Morado", Morado);
        keywords.Add("Rojo", Rojo);
        keywords.Add("Esternocleidomastoideo", Esternocleidomastoideo);

        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;

        keywordRecognizer.Start();
    }
    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;
        // if the keyword recognized is in our dictionary, call that Action.
        if (keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
        }
    }


    private void Insomnio()
    {
        Debug.Log("Insomnio");
    }

    private void Morado()
    {
        Debug.Log("Morado");
    }

    private void Rojo()
    {
        Debug.Log("Rojo");
    }

    private void Esternocleidomastoideo()
    {
        Debug.Log("Esternocleidomastoideo");
    }    
}