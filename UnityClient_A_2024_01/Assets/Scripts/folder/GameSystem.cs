using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Text;
using STORYGAME;


public class GameSystem : MonoBehaviour
{
    public StoryModel[] storyModels;

    public static GameSystem instance;


    private void Awake()
    {
        instance = this;
    }

    public enum GAMESTATE
    {
        STORYSHOW,
        WAITSELECT,
        STORYEND,
        BATTLEMODE,
        BATTLEDONE,
        SHOPMODE,
        ENDMODE
    }

    public Stats state;
    public GAMESTATE currentState;

    public int currentStoryIndex = 1;

    public void ApplyChoice(StoryModel.Result result)
    {
        switch (result.resultType)
        {
            case StoryModel.Result.ResultType.ChangeHp:
                //stats.currentHpPoint += result.value;
                ChangeState(result);
                break;

            case StoryModel.Result.ResultType.AddExpreience:
                ChangeState(result);
                break;

            case StoryModel.Result.ResultType.GoNextStory:
                currentStoryIndex = result.value;
                StoryShow(currentStoryIndex);
                break;

            case StoryModel.Result.ResultType.GoToRandomStory:
                StoryModel temp = RandomStory();
                StoryShow(temp.storyNumber);
                break;

        }
    }

    public void StoryShow(int number)
    {
        StoryModel tempStoryModel = FindStoryModels(number);
    }





    public void ChangeState(StoryModel.Result result)
    {
        if (result.stats.hpPoint > 0) result.stats.hpPoint += result.stats.hpPoint;
        if (result.stats.spPoint > 0) result.stats.spPoint += result.stats.spPoint;
        if (result.stats.currentHpPoint > 0) result.stats.currentHpPoint += result.stats.currentHpPoint;
        if (result.stats.currentSpPoint > 0) result.stats.currentSpPoint += result.stats.currentSpPoint;
        if (result.stats.currentXpPoint > 0) result.stats.currentXpPoint += result.stats.currentXpPoint;
        if (result.stats.strength > 0) result.stats.hpPoint += result.stats.strength;
        if (result.stats.dexterity > 0) result.stats.dexterity += result.stats.dexterity;
        if (result.stats.wisdom > 0) result.stats.wisdom += result.stats.wisdom;
        if (result.stats.Intelligence > 0) result.stats.Intelligence += result.stats.Intelligence;
        if (result.stats.charisma > 0) result.stats.charisma += result.stats.charisma;

    }

    StoryModel RandomStory ()
    {
        StoryModel tempStoryModels = null;
        List<StoryModel> StoryModelList = new List<StoryModel>();

        for (int i = 0; i < storyModels.Length; i++)
        {
            if(storyModels[i].storytype == StoryModel.STORYTYPE.MAIN)
            {
                StoryModelList.Add(storyModels[i]);
            }
        }

        tempStoryModels = StoryModelList[Random.Range(0, StoryModelList.Count)];
        currentStoryIndex = tempStoryModels.storyNumber;
        Debug.Log("currentStoryIndex" + currentStoryIndex);

        return tempStoryModels;
    }

    StoryModel FindStoryModels(int number)
    {
        StoryModel tempStoryModels = null;

        for (int i = 0; i < storyModels.Length; i++)
        {
            if(storyModels[i].storyNumber == number)
            {
                tempStoryModels = storyModels[i];
                break;
            }
        }

        return tempStoryModels;
    }

#if UNITY_EDITOR
    [ContextMenu("Reset Story Models")]

    public void ResetStoryModels()
    {
        storyModels = Resources.LoadAll<StoryModel>("");
    }




#endif
}
