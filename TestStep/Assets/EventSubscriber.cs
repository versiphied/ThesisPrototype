﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicBloom.Koreo;

public class EventSubscriber : MonoBehaviour {
    //public delegate void KoreographyEventCallback(KoreographyEvent koreoEvent);
    //public delegate void KoreographyEventCallbackWithTime(KoreographyEvent koreoEvent, int sampleTime, int sampleDelta, DeltaSlice deltaSlice);
    [EventID]
    public string eventID;
    public GameObject Check;
    public GameObject Check2;
    public List<KoreographyEvent> eventsList;
    public AudioClip currentTrack;
    public bool KoreographyColor;
    public bool KoreographyColor2;
    public int EventFrame;
    public int CurrentFrame;
   
    // Use this for initialization
    void Start () {
        Koreographer.Instance.RegisterForEvents(eventID, FireEventDebugLog);
        
    }

    void FireEventDebugLog(KoreographyEvent koreoEvent)
    {

        EventFrame = Time.frameCount;
       
        //if KoreographyColor is true, make the check color the same color as the event color valor
        if (KoreographyColor == true)
        {
           
            Debug.Log(Check.GetComponent<SpriteRenderer>().color);
            Check.GetComponent<SpriteRenderer>().color = koreoEvent.GetColorValue();
            Debug.Log("Koreography Event Fired: " + koreoEvent.StartSample);
            Debug.Log(koreoEvent.GetColorValue());
            Debug.Log(Check.GetComponent<SpriteRenderer>().color);
           // Debug.Log("");


        }
        else
        {
            Check.GetComponent<SpriteRenderer>().color = Color.red;
        }
        if (KoreographyColor2 == true)
        {
            Debug.Log(Check.GetComponent<SpriteRenderer>().color);
            Check2.GetComponent<SpriteRenderer>().color = koreoEvent.GetColorValue();
            Debug.Log("Koreography Event Fired: " + koreoEvent.StartSample);
            Debug.Log(koreoEvent.GetColorValue());
            Debug.Log(Check.GetComponent<SpriteRenderer>().color);
        }
        else
        {
            Check2.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    void Update()
    {
        //press key to end event, thus changing the color back to its orignal color

        CurrentFrame = Time.frameCount;
        Debug.Log(CurrentFrame + " " + EventFrame);
        //if (Input.GetKeyDown(KeyCode.LeftControl))
        if (CurrentFrame-1 == EventFrame && Input.GetKey(KeyCode.LeftControl)) 
        {

            KoreographyColor = true;
            Debug.Log("Key Is Pressed");
        }
        else
        {
            KoreographyColor = false;
        }
        if (CurrentFrame - 1 == EventFrame && Input.GetKey(KeyCode.RightControl))
        {

            KoreographyColor2 = true;
            Debug.Log("Key Is Pressed");
        }
        else
        {
            KoreographyColor2 = false;
        }
    }

}
    

