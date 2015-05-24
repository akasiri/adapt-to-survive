﻿using UnityEngine;
using System.Collections;

//this is a static class that does not need to be placed on GameObjects


public class Tags : MonoBehaviour {
    public const string Player = "Player";
    public const string PlayerParticleEffect = "PlayerParticleEffect";
    public const string Light = "Light";
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

public static class Scenes
{
    public const string Menu = "Menu";
    public const string Tutorial = "Tutorial";
    public const string Game = "MainGamePlay";
}

public class Parameters
{
    public static int State = Animator.StringToHash("State");
}