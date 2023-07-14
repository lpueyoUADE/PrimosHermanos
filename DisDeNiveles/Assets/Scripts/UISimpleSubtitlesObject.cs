using TMPro;
using System.Collections.Generic;
using UnityEngine;

public class UISimpleSubtitlesObject : MonoBehaviour
{
    public UISimpleSubtitles subScript;

    [Header("Subtitle stuff")]
    public float[] timesInDelta;
    public string[] line;
    public float[] subtitleTimeOnScreen;
    public List<bool> executed;

    public Color defaultColor = new Color(1, 1, 1);

    [Header("Status")]
    public int currentIndex = 0;
    public float currentTime = 0;

    public bool exec = false;

    [Header("other")]
    public bool showMS = true;
    public TextMeshProUGUI text;


    private void Start()
    {
        if (timesInDelta.Length == line.Length)
        {
            for (int i = 0; i < timesInDelta.Length; i++)
            {
                executed.Add(false);
            }
        }
        else
            print("something wrong with subtitles entries, check Lengths");
    }

    void Update()
    {
        if (exec)
        {
            if (showMS)
                text.text = currentTime.ToString();

            currentTime += Time.deltaTime;

            for (int i = 0; i < timesInDelta.Length; i++)
            {
                if (currentTime >= timesInDelta[i] && !executed[i])
                {
                    float newSubtitleTimeOnScreen = 3;

                    if (i < subtitleTimeOnScreen.Length)
                        newSubtitleTimeOnScreen = subtitleTimeOnScreen[i];

                    executed[i] = true;

                    SendSubtitle2UI(defaultColor, line[i], newSubtitleTimeOnScreen);

                    if (executed[timesInDelta.Length - 1] == true)
                    {
                        exec = false;
                        if (showMS)
                            text.text = "";
                    }
                }
            }
        }
    }

    void SendSubtitle2UI(Color color, string line, float newTimeOnScreen)
    {
        subScript.ShowSubtitle(color, line, newTimeOnScreen);
    }

    public void StartExec()
    {
        
        exec = true;
    }
}
