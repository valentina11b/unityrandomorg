using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Text;

public class NativeCodeRunner : MonoBehaviour {

    [SerializeField] public TMP_Text messageText; 
    public string message = "";

    [SerializeField] public Button runButton;

    public void OnButtonPress()
    {
        runButton.enabled = false;

        string msg = "Result:\n";
        try
        {
        if (m_Dropdown.value == 0)
            {
                msg += string.Join("\n", GetRandomInteger());
            }
            else if (m_Dropdown.value == 1)
            {
                int[][] matrix = GetRandomIntegerSequences(5, 5);
                for (int i = 0; i < 5; i++)
                {
                    msg += "[" + string.Join(", ", matrix[i]) + "]\n";
                }


        }
            else if (m_Dropdown.value == 2)
            {
                msg += string.Join("\n", GetRandomDecimalFractions());
            }
            else if (m_Dropdown.value == 3)
            {
                msg += string.Join("\n", GetRandomGaussians());
            }
            else if (m_Dropdown.value == 4)
            {
                msg += string.Join("\n", GetRandomStrings());
            }
            else if (m_Dropdown.value == 5)
            {
                msg += string.Join("\n", GetRandomUUIDs(5));
            }
            else if (m_Dropdown.value == 6)
            {
                msg += string.Join("\n", GetRandomBlobs());
            }
            } catch(Exception e)
            {
            msg += e.Message;
            }
            messageText.text = msg;
        messageText.enabled = true;
        runButton.enabled = true;
    }

    [SerializeField] public TMP_Dropdown m_Dropdown;

    public void DropdownValueChanged(TMP_Dropdown change)
    {
        messageText.text = "New Value : " + change.value;
    }

    void Start() {
    } 

     public int[] GetRandomInteger() {
       if (Application.platform == RuntimePlatform.Android) {
           AndroidJavaClass unityPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
           AndroidJavaObject unityActivity = unityPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");        
           AndroidJavaObject alert = new AndroidJavaObject("rs.assignments.basicapi.RandomORGApp");            
           object[] parameters = new object[4];
           parameters[0] = unityActivity;
           parameters[1] = 5; // n
           parameters[2] = 0; // min
           parameters[3] = 55; // max
           return alert.Call<int[]>("GetRandomInteger", parameters);
       }
       return new int[0];
    }

    public int[][] GetRandomIntegerSequences(int n, int len)
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            AndroidJavaClass unityPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject unityActivity = unityPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaObject alert = new AndroidJavaObject("rs.assignments.basicapi.RandomORGApp");
            object[] parameters = new object[5];
            parameters[0] = unityActivity;
            parameters[1] = n; // n
            parameters[2] = len; // len
            parameters[3] = 0; // min
            parameters[4] = 55; // max
            int[] ret = alert.Call<int[]>("GetRandomIntegerSequences", parameters);
            int[][] split = new int[n][];
            for (int i = 0; i < n; i++)
            {
                split[i] = new int[len];
                for (int j = 0; j < len; j++)
                {
                    split[i][j] = ret[i * n + j];
                }
            }
            return split;
        }
        return new int[0][];
    }

    public double[] GetRandomDecimalFractions()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            AndroidJavaClass unityPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject unityActivity = unityPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaObject alert = new AndroidJavaObject("rs.assignments.basicapi.RandomORGApp");
            object[] parameters = new object[3];
            parameters[0] = unityActivity;
            parameters[1] = 5; // n
            parameters[2] = 3; // decimalPlaces
            return alert.Call<double[]>("GetRandomDecimalFractions", parameters);
        }
        return new double[0];
    }

    public double[] GetRandomGaussians()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            AndroidJavaClass unityPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject unityActivity = unityPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaObject alert = new AndroidJavaObject("rs.assignments.basicapi.RandomORGApp");
            object[] parameters = new object[5];
            parameters[0] = unityActivity;
            parameters[1] = 4; // n
            parameters[2] = 0.0; // mean
            parameters[3] = 1.0; // standardDeviation
            parameters[4] = 8; // significantDigits
            return alert.Call<double[]>("GetRandomGaussians", parameters);
        }
        return new double[0];
    }
    public string[] GetRandomStrings()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            AndroidJavaClass unityPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject unityActivity = unityPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaObject alert = new AndroidJavaObject("rs.assignments.basicapi.RandomORGApp");
            object[] parameters = new object[4];
            parameters[0] = unityActivity;
            parameters[1] = 4; // n
            parameters[2] = 9; // len
            parameters[3] = "abcdefghijklmnopqrstuvwxyz"; // characters
            return alert.Call<string[]>("GetRandomStrings", parameters);
        }
        return new string[0];
    }
    public Guid[] GetRandomUUIDs(int n)
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            AndroidJavaClass unityPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject unityActivity = unityPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaObject alert = new AndroidJavaObject("rs.assignments.basicapi.RandomORGApp");
            object[] parameters = new object[2];
            parameters[0] = unityActivity;
            parameters[1] = n;
            string[] strs = alert.Call<string[]>("GetRandomUUIDs", parameters);
            Guid[] guids = new Guid[n];
            for (int i = 0; i < n; i++)
            {
                guids[i] = new Guid(strs[i]);
            }
            return guids;
        }
        return new Guid[0];
    }
    public string[] GetRandomBlobs()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            AndroidJavaClass unityPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject unityActivity = unityPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaObject alert = new AndroidJavaObject("rs.assignments.basicapi.RandomORGApp");
            object[] parameters = new object[3];
            parameters[0] = unityActivity;
            parameters[1] = 4; // n
            parameters[2] = 8; // size, must be divisible by 8
            return alert.Call<string[]>("GetRandomBlobs", parameters);
        }
        return new string[0];
    }
}