using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Text;

public class GameSystem : MonoBehaviour
{
    public StoryModel[] storyModels;

#if UNITY_EDITOR
    [ContextMenu("Reset Story Models")]

    public void ResetStoryModels()
    {
        storyModels = Resources.LoadAll<StoryModel>("");
    }




#endif
}
