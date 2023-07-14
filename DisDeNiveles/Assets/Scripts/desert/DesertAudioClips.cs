using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertAudioClips : MonoBehaviour
{
    [Header("elevator")]
    public Elevator elevScript;
    public Button elevatorOpenButton;
    public Button elevatorExitButton;

    [Header("desert stuff")]
    public GameObject photoScene;
    public AudioClip[] clips;
    public UISimpleSubtitlesObject[] subtitlesScripts;
    public int selection;
    public DesertDirtyMoney2 dirtyMoney2;

    [Header("ui barrels")]
    public DesertBarrelsUI dbui;


    private void Start()
    {
        elevScript.OpenDoors();
    }

    public AudioClip GetNextAudioClip()
    {
        if (photoScene.activeSelf)
        {
            photoScene.gameObject.SetActive(false);
        }

        AudioClip theClip;
        if (clips[selection] != null && subtitlesScripts[selection] != null)
        {
            theClip = clips[selection];
            subtitlesScripts[selection].StartExec();
            selection++;

            if (clips.Length == selection)
                dirtyMoney2.StartExec();

            dbui.RemoveOneBarrel(selection - 1);
        }
        else
        {
            theClip = clips[selection];
            print("either clips or subtitles selection is NULL");
        }

        return theClip;
    }
}
