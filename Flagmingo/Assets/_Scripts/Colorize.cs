using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colorize
{
    #region Standard Colors
    public static string Red(string message)
    {
        return $"<color=red>{message}</color>";
    }

    public static string Blue(string message)
    {
        return $"<color=blue>{message}</color>";
    }

    public static string Green(string message)
    {
        return $"<color=green>{message}</color>";
    }

    public static string Yellow(string message)
    {
        return $"<color=yellow>{message}</color>";
    }

    public static string LightBlue(string message)
    {
        return $"<color=cyan>{message}</color>";
    }

    public static string LightGreen(string message)
    {
        return $"<color=lime>{message}</color>";
    }

    public static string Pink(string message)
    {
        return $"<color=#FF7FC5>{message}</color>";
    }

    public static string Flamingo(string message)
    {
        return $"<color=#EB588F>{message}</color>";
    }

    public static string DarkRed(string message)
    {
        return $"<color=maroon>{message}</color>";
    }

    public static string DarkBlue(string message)
    {
        return $"<color=darkblue>{message}</color>";
    }

    public static string DarkGreen(string message)
    {
        return $"<color=darkgreen>{message}</color>";
    }

    public static string White(string message)
    {
        return $"<color=white>{message}</color>";
    }

    public static string Black(string message)
    {
        return $"<color=black>{message}</color>";
    }

    public static string Gray(string message)
    {
        return $"<color=gray>{message}</color>";
    }

    public static string LightGray(string message)
    {
        return $"<color=#C1C1C1>{message}</color>";
    }
    #endregion
    #region Categories
    public static string Player(string message)
    {
        return $"<color=#EB588F>[PLAYER] - {message}</color>";
    }

    public static string Round(string message)
    {
        return $"<color=#BBEA54>[ROUND] - {message}</color>";
    }

    public static string Audio(string message)
    {
        return $"<color=#E8C91B>[AUDIO] - {message}</color>";
    }

    public static string Flag(string message)
    {
        return $"<color=#44E5B7>[FLAG] - {message}</color>";
    }

    public static string Item(string message)
    {
        return $"<color=#BBEAD6>[ITEM] - {message}</color>";
    }

    public static string Spawn(string message)
    {
        return $"<color=#9B5DE2>[SPAWN] - {message}</color>";
    }

    public static string Input(string message)
    {
        return $"<color=#8FD0E0>[INPUT] - {message}</color>";
    }

    public static string UI(string message)
    {
        return $"<color=#FF7742>[UI] - {message}</color>";
    }

    public static string Attack(string message)
    {
        return $"<color=#E80017>[ATTACK] - {message}</color>";
    }
    #endregion
}
