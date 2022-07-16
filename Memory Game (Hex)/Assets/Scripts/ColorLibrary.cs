using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class ColorLibrary
{
    public List<string> GetColorList(LevelDificulty level)
    {
        List<string> colorList = new List<string>();

        // colorList.Add("H#FF0000"); colorList.Add("C#FF0000"); // red
        // colorList.Add("H#00FF00"); colorList.Add("C#00FF00"); // green
        // colorList.Add("H#0000FF"); colorList.Add("C#0000FF"); // blue
        // colorList.Add("H#FFFF00"); colorList.Add("C#FFFF00"); // yellow
        // colorList.Add("H#C0C0C0"); colorList.Add("C#C0C0C0"); // gray

        // colorList.Add("H#FF0000"); colorList.Add("C#FF0000"); // red
        // colorList.Add("H#00FF00"); colorList.Add("C#00FF00"); // green
        // colorList.Add("H#0000FF"); colorList.Add("C#0000FF"); // blue
        // colorList.Add("H#FFFF00"); colorList.Add("C#FFFF00"); // yellow
        // colorList.Add("H#C0C0C0"); colorList.Add("C#C0C0C0"); // gray

        switch (level)
        {
            case LevelDificulty.easy:
                colorList.Add("H#FF0000"); colorList.Add("C#FF0000");
                colorList.Add("H#00FF00"); colorList.Add("C#00FF00");
                colorList.Add("H#0000FF"); colorList.Add("C#0000FF");
                colorList.Add("H#FFFF00"); colorList.Add("C#FFFF00");
                colorList.Add("H#FF00FF"); colorList.Add("C#FF00FF");
                colorList.Add("H#33CCCC"); colorList.Add("C#33CCCC");
                colorList.Add("H#FF5050"); colorList.Add("C#FF5050");
                colorList.Add("H#3366FF"); colorList.Add("C#3366FF");
                colorList.Add("H#FF6600"); colorList.Add("C#FF6600");
                colorList.Add("H#66FF33"); colorList.Add("C#66FF33");
                break;
            case LevelDificulty.medium:
                //colorList = new List<string>(mediumColorList);
                break;
            case LevelDificulty.hard:
                //colorList = new List<string>(hardColorList);
                break;
            case LevelDificulty.impossible:
                int cardCount = 20;
                while (cardCount != colorList.Count)
                {
                    Color color = GenerateRandomColor();
                    colorList.Add(string.Concat("H#", ColorUtility.ToHtmlStringRGB(color)));
                    colorList.Add(string.Concat("C#", ColorUtility.ToHtmlStringRGB(color)));
                }
                break;
        }

        return GenerateColorList(colorList);
    }

    private Color GenerateRandomColor()
    {
        if (ColorUtility.TryParseHtmlString(string.Concat(UnityEngine.Random.Range(0, 256), UnityEngine.Random.Range(0, 256), UnityEngine.Random.Range(0, 256)), out Color randomColor))
            return randomColor;
        return randomColor;

    }

    private List<string> GenerateColorList(List<string> selectedList)
    {
        for (var i = selectedList.Count; i > 0; i--)
        {
            SwapListItem(selectedList, 0, UnityEngine.Random.Range(0, i - 1));
        }

        return selectedList;
    }

    private void SwapListItem(List<string> list, int i, int j)
    {
        string temp = list[i];
        list[i] = list[j];
        list[j] = temp;
    }
}


public enum LevelDificulty
{
    easy, medium, hard, impossible
}