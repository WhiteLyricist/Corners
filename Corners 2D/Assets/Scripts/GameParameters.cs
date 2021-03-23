using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameParameters
{
    private static int typeGame = 0;
    public static float TypeGame
    { get => typeGame; }

    public static void GameParametr(int type)
    {
        typeGame = type;
    }

}
