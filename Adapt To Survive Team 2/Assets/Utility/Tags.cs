using UnityEngine;
using System.Collections;

//this is a static class that does not need to be placed on GameObjects


public class Tags : MonoBehaviour {
    public const string Player = "Player";
}

public static class Options
{
    public const string SoundLevel = "SoundLevel";
    public const string MusicLevel = "MusicLevel";
    public const string HighScore = "HighScore";
}

public static class Snapshots
{
    public const string Default = "Default";
    public const string Muffled = "Muffled";
}