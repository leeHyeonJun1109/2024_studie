using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static STORYGAME.StoryTableObject;
using STORYGAME;

[CreateAssetMenu(fileName = "NewStory", menuName = "ScriptableObjects/StoryModel")]
public class StoryModel : ScriptableObject
{
    public int storyNumber;
    public Texture2D MainImage;

    public enum STORYTYPE
    {
        MAIN,
        SUB,
        SERIAL
    }

    public STORYTYPE storytype;
    public bool storyDone;

    [TextArea(10, 10)]
    public string storyText;

    public Option[] options;

    [System.Serializable]

    public enum ResultType : int
    {
        ChangeHp,
        ChangeSp,
        AddExperience,
        GoToShop,
        GoToNextStory,
        GoToRnadomStory,
        GoToeeEnding
        
    }
    public ResultType resultType;
    public int value;
    public Stats stats;

    [System.Serializable]
    public class Option
    {
        public string optionText;
        public string buttonText;
        public EventCheck eventCheck;
    }


    [System.Serializable]
    public class EventCheck
    {
        public enum EventType : int
        {
            NONE,
            GoToBattle,
            CheckSTR,
            CheckDEX,
            CheckCON,
            CheckINT,
            CheckWis,
            CheckCHA
        }

        public EventType eventType;

        public Result[] suceessResult;
        public Result[] failResult;

    }


    [System.Serializable]
    public class Result
    {
        public enum ResultType
        {
            ChangeHp,
            ChangeSp,
            AddExpreience,
            GoToShop,
            GoNextStory,
            GoToRandomStory,
            GoToEnding
        }

        public ResultType resultType;
        public int value;
        public Stats stats;
    }









}
