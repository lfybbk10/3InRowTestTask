
using System;
using System.Collections.Generic;

public static class ArrTools
{

    public static T[,] CopyArr<T>(T[,] arr)
    {
        T[,] copiedArr = new T[arr.GetLength(0),arr.GetLength(1)];
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                copiedArr[i, j] = arr[i, j];
            }
        }

        return copiedArr;
    }
    public static void DelElemAndMoveUpperElems<T>(this T[,] arr, int posI, int posJ)
    {
        for (int i = posI; i > 0; i--)
        {
            arr[i, posJ] = arr[i - 1, posJ];
        }

        arr[0, posJ] = default;
    }
    
    public static void Shuffle<T>(this List<T> ts) {
        var count = ts.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i) {
            var r = UnityEngine.Random.Range(i, count);
            var tmp = ts[i];
            ts[i] = ts[r];
            ts[r] = tmp;
        }
    }
}
