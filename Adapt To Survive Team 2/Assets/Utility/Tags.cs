using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//this is a static class that does not need to be placed on GameObjects


public class Tags : MonoBehaviour {
    public const string Player = "Player";
    public const string PlayerParticleEffect = "PlayerParticleEffect";
    public const string Light = "Light";
    public const string Tree = "Tree";
    public const string Water = "Water";
    public const string Fire = "Fire";
    public const string Boulder = "Boulder";
    public const string Pitfall = "Pitfall";
    public const string Predator = "Predator";
    public static HashSet<string> Obstacles = new HashSet<string>{Tags.Water, Tags.Tree, Tags.Fire, Tags.Boulder, Tags.Predator, Tags.Pitfall};
    public static Dictionary<string, int> obstacleToInt = new Dictionary<string, int>
    {
        {Tags.Tree, 1},
        {Tags.Pitfall, 2},
        {Tags.Water, 3},
        {Tags.Boulder, 4},
        {Tags.Fire, 5},
        {Tags.Predator, 6},
    };
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