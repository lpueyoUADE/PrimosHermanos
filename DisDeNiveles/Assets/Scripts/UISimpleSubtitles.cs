using TMPro;
using UnityEngine;

public class UISimpleSubtitles : MonoBehaviour
{
    public TextMeshProUGUI tmp;
    public string currentLine = "";

    public float maxShowTime = 3;
    public float defaultMaxShowTime = 3;
    public float currentShowTime = 0;

    private void Update()
    {
        if (currentLine != "" && tmp.text == currentLine && currentShowTime >= maxShowTime)
        {
            currentLine = "";
            tmp.text = currentLine;
            currentShowTime = 0;
            maxShowTime = defaultMaxShowTime;
        }
        else if (currentLine != "")
            currentShowTime += Time.deltaTime;
    }

    public void ShowSubtitle(Color color, string line, float newTimeOnScreen)
    {
        tmp.text = line;
        tmp.color = color;
        currentLine = line;
        currentShowTime = 0;
        maxShowTime = newTimeOnScreen;
    }
}
