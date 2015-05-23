using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Controls : MonoBehaviour
{

    // Command: enumeration of possible commands
    public enum Command
    {
        LEFT,
        RIGHT,
    };

    // the dictionary of command-to-key dictionaries, one dictionary for each controller.
    private static Dictionary<Command, HashSet<KeyCode>> theInputMap = new Dictionary<Command, HashSet<KeyCode>>
          {
                { Command.LEFT,   new HashSet<KeyCode> { KeyCode.A, KeyCode.LeftArrow, } },
                { Command.RIGHT,   new HashSet<KeyCode> { KeyCode.D, KeyCode.RightArrow, } },
            };

    // PRIVATE VARIABLES
    private Dictionary<Command, float> holdDict;			// tracks command hold duration
    private Dictionary<Command, HashSet<KeyCode>> keyDict;	// stores association between commands and controller inputs
    private Dictionary<Command, bool> startDict;			// track newly issued commands
    private Dictionary<Command, bool> endDict;				// track newly ended commands

    // INITIALIZE
    void Awake()
    {
        holdDict = new Dictionary<Command, float>();
        keyDict = new Dictionary<Command, HashSet<KeyCode>>();
        startDict = new Dictionary<Command, bool>();
        endDict = new Dictionary<Command, bool>();
        InitializeKeyDict();
        InitializeHoldDict();
        InitializeStartDict();
        InitializeEndDict();
    }

    // DoUpdate forces controls to update values so it stays synced with other Update calls
    public void DoUpdate()
    {
        foreach (Command com in keyDict.Keys)
        {
                if (GetCommand(com))
                {			// if the command is being issued ...
                    if (holdDict[com] == 0f)
                    {
                        startDict[com] = true;			// flag start command
                    }
                    endDict[com] = false;
                    holdDict[com] += Time.deltaTime;	// add to hold time
                    //if (com == Command.DASH)
                    //Debug.Log(GetCommand(com));
                }
                else
                {						// Otherwise ...
                    if (holdDict[com] > 0f)
                    {
                        endDict[com] = true;			// flag end command
                    }
                    startDict[com] = false;				// clear start command
                    holdDict[com] = 0f;					// reset hold time
                }
            }
    }

    // INITIALIZERS
    private void InitializeKeyDict()
    {
        keyDict = theInputMap;
    }
    private void InitializeHoldDict() { foreach (Command com in keyDict.Keys) holdDict[com] = 0f; }
    private void InitializeStartDict() { foreach (Command com in keyDict.Keys) startDict[com] = false; }
    private void InitializeEndDict() { foreach (Command com in keyDict.Keys) endDict[com] = false; }

    // GETTERS
    public float GetCommandHoldDuration(Command com) { return holdDict[com]; }
    public bool GetCommand(Command com) { return GetCommandMagnitude(com) != 0f; }
    public bool GetCommandStart(Command com) { return startDict[com]; }
    public bool GetCommandEnd(Command com) { return endDict[com]; }
    // FLAG CONSUMERS
    public bool ConsumeCommandStart(Command com)
    {
        bool result = startDict[com];
        startDict[com] = false;
        return result;
    }
    public bool ConsumeCommandEnd(Command com)
    {
        bool result = endDict[com];
        endDict[com] = false;
        return result;
    }
    public bool ConsumeTriggerStart(Command com)
    {
        return ConsumeCommandStart(com);
    }

    public float GetCommandMagnitude(Command com)
    {
        HashSet<KeyCode> validKeys = keyDict[com];
        foreach (KeyCode s in validKeys)
        {

            if (Input.GetKey(s))						// Normal commands
                return 1f;
        }
        return 0f;
    }
}
