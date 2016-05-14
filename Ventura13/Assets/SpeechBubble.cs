using UnityEngine;
using System.Collections;

public class SpeechBubble : MonoBehaviour {
    
    public float messageCountdown;
    public float messageDisplayTime;
    private float messageCountdownStartTime;
    private float messageDisplayStartTime;
    private bool displaying = false;
    private int messageCount = 0;
    private static string[] messages = {"Man, this is just the shittiest day", "Who the hell designed this ship?", "Maybe I should go back to the apocalypse", "Hey, \"partner\", get your shit together!"};
    private int amountOfMessages = 4;

    // Use this for initialization
    void Start () {
        messageCountdownStartTime = Time.time;
        this.GetComponent<Canvas>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {

        if(Time.time - messageCountdownStartTime >= messageCountdown)
        {
            startDisplayCountdown();

            if (Time.time - messageDisplayStartTime <= messageDisplayTime)
            {
                this.GetComponent<Canvas>().enabled = true;
                this.GetComponentInChildren<UnityEngine.UI.Text>().text = messages[messageCount];
            }
            else
            {
                this.GetComponent<Canvas>().enabled = false;
                stopDisplayCountdown();
                messageCountdownStartTime = Time.time;
            }
        }
	}

    void startDisplayCountdown()
    {
        if(!displaying)
        {
            displaying = true;
            messageDisplayStartTime = Time.time - 0.001f;
        }
    }

    void stopDisplayCountdown()
    {
        if (displaying)
        {
            messageCount++;
            if (messageCount >= amountOfMessages)
                messageCount = 0;
            displaying = false;
        }
    }
}
