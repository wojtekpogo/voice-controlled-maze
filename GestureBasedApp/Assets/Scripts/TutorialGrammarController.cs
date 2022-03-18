using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.IO;
using System.Text;
using UnityEngine.UI;

// Set up a Grammer Recogniser (Same as Keyword Recogniser)
// Tell the grammar file - Compile this to read it.
// Wait for the Input.
// Parse out the Input and tell me if it was a yes or a no.
// Uses English US on the settings (Keyboard, Region, Preferred Language and Speech).
// Might have to change all of those in the Windows settings

public class TutorialGrammarController : MonoBehaviour
{
    const string GRAMMAR = "Grammar.xml";
    [SerializeField] private Text DisplayText;
    // American spelling - Z
    GrammarRecognizer gr;
    [SerializeField] private TutorialController tc;

    private void Start()
    {
        // Read the grammar and listen
        gr = new GrammarRecognizer(
                Path.Combine(Application.streamingAssetsPath, GRAMMAR),
                ConfidenceLevel.Low);

        Debug.Log("Grammar is loaded " + gr.GrammarFilePath);

        gr.OnPhraseRecognized += GR_OnPhrasesRecognised;

        gr.Start();

        if (gr.IsRunning) Debug.Log("GR is running.");
    }

    private void GR_OnPhrasesRecognised(PhraseRecognizedEventArgs args)
    {
        Debug.Log("Recognised Something...");
        // Read the semantic meanings from the args returned
        // Put them in a string to print a message in the console
        StringBuilder message = new StringBuilder();

        SemanticMeaning[] meanings = args.semanticMeanings;

        foreach (SemanticMeaning meaning in meanings)
        {
            string keyString = meaning.key.Trim();
            string valueString = meaning.values[0].Trim();

            message.Append("Key: " + keyString +
                            ", Value: " + valueString +
                            System.Environment.NewLine);

            tc.TextSaid(valueString);
        }
    }

    private void OnApplicationQuit()
    {
        if (gr != null && gr.IsRunning)
        {
            gr.OnPhraseRecognized -= GR_OnPhrasesRecognised;

            Debug.Log("GR has stopped.");
            gr.Stop();
        }
    }
}