using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NativeCodeRunner : MonoBehaviour {

    [SerializeField] public TMP_Text messageText; // Reference to the Text component you want to show
    public string message = "Button Pressed!"; // Message to display

    public void OnButtonPress()
    {
      string msg = "Number: " + (GetRandomInteger());
        messageText.text = msg;
        messageText.enabled = true; // Ensure the text is enabled and visible
    }

    [SerializeField] public TMP_Dropdown m_Dropdown;

    public void DropdownValueChanged(TMP_Dropdown change)
    {
        messageText.text = "New Value : " + change.value;
    }

    void Start() {
    } 

     public float GetRandomInteger() {
       if (Application.platform == RuntimePlatform.Android) {
           AndroidJavaClass unityPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
           AndroidJavaObject unityActivity = unityPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");        
           AndroidJavaObject alert = new AndroidJavaObject("rs.assignments.basicapi.RandomORGApp");            
           object[] parameters = new object[1];
           parameters[0] = unityActivity;
           return alert.Call<float>("GetRandomInteger", parameters);
       }
       return -1f;
     }
}