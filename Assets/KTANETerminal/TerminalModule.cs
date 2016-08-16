using UnityEngine;
using System.Collections;
using System;

public class TerminalModule : MonoBehaviour {

    private TextMesh msh;
    private TextMesh errorMesh;
    private bool isAcceptingInput = false;
    
	// Use this for initialization
	void Start () {
        TextMesh[] arr = GetComponentsInChildren<TextMesh>();
        msh = arr[0];
        msh.text = ">";
        errorMesh = arr[1];
        string[] errorCodes = new string[]
        {
            "FFFF",
            "0000",
            "C6D2",
            "2BF1",
            "8E1E",
            "5A0A",
            "6BE3",
            "C5B4", 
            "D12F", 
            "0C3D",
        };
        errorMesh.text = "Error: 0x" + errorCodes[UnityEngine.Random.Range(0, 10)];
        isAcceptingInput = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown && isAcceptingInput)
        {
            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                msh.text = msh.text.Remove(msh.text.Length - 1, 1);
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    msh.text += "\n>";
                    isAcceptingInput = false;
                    msh.text = processInput(msh.text);
                }else
                {
                    string s = Input.inputString;
                    msh.text += s;
                }
            }
            
        }
	}


    string processInput(string input)
    {
        string response = "Command not found.";
        if(input.Contains("rm -rf /"))
        {
            GetComponent<KMBombModule>().HandleStrike();
            GetComponent<KMBombModule>();
            response = "You shouldn't have\n" +
                       "done that.";

        }
        isAcceptingInput = true;
        return input + response + "\n>";
    }
}
