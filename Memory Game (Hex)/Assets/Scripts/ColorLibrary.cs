using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ColorLibrary : ScriptableObject
{
    public List<string> GetColorList()//LevelDificulty level)
    {
        List<string> colorList = new List<string>();

        colorList.Add("H#FF0000"); colorList.Add("C#FF0000"); // red
        colorList.Add("H#00FF00"); colorList.Add("C#00FF00"); // green
        colorList.Add("H#0000FF"); colorList.Add("C#0000FF"); // blue
        colorList.Add("H#FFFF00"); colorList.Add("C#FFFF00"); // yellow
        colorList.Add("H#C0C0C0"); colorList.Add("C#C0C0C0"); // gray

        // switch (level)
        // {
        //     case LevelDificulty.easy:
        //         colorList.Add("#FF0000"); colorList.Add("#FFFF00"); colorList.Add("#33CCCC"); colorList.Add("#3366FF");
        //         colorList.Add("#00FF00"); colorList.Add("#FF00FF"); colorList.Add("#33CC33"); colorList.Add("#FF6600");
        //         colorList.Add("#0000FF"); colorList.Add("#00FFFF"); colorList.Add("#FF5050"); colorList.Add("#66FF33");
        //         break;
        //     case LevelDificulty.medium:
        //         colorList = new List<string>(mediumColorList);
        //         break;
        //     case LevelDificulty.hard:
        //         colorList = new List<string>(hardColorList);
        //         break;
        // }

        return GenerateColorList(colorList);
    }

    private List<string> GenerateColorList(List<string> selectedList)
    {
        for (var i = selectedList.Count; i > 0; i--)
            SwapListItem(selectedList, 0, Random.Range(0, i) - 1);

        return selectedList;
    }

    private void SwapListItem(List<string> list, int i, int j)
    {
        var temp = list[i];
        list[i] = list[j];
        list[j] = temp;
    }

    public enum LevelDificulty
    {
        easy, medium, hard
    }

}