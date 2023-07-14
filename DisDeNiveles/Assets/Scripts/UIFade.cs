using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFade : MonoBehaviour
{
    public Image uiImageRef;

    [Header("configs")]
    public Color outColor = new Color();
    public Color inColor = new Color();
    public float defaultDuration = 5;

    private void Start()
    {
        Fade(true, defaultDuration);
    }

    public void Fade(bool fadeIn = true, float duration = 5)
    {
        if (fadeIn)
            uiImageRef.CrossFadeColor(inColor, duration, true, true);
        else
            uiImageRef.CrossFadeColor(outColor, duration, true, true);
    }
}
