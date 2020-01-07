using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class PopUpDialogue : MonoBehaviour
{

    public string[] messages;
    public float delay;

    // Start is called before the first frame update
    void Start()
    {
        // Calling the coroutine method in Unity to run the function of sentences
        StartCoroutine(LoadNextSentence(delay));
    }

    // IEnumerator is used for adding a delay
    IEnumerator LoadNextSentence(float delay)
    {
        // Looping through the messages array and passing it into text component after delay
        for(int i = 0; i < messages.Length; i++)
        {
            yield return new WaitForSeconds(delay);
            gameObject.GetComponent<Text>().text = messages[i];
        }
    }


}
