using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public enum Status { Opening, Closing, Open, Closed }
    [Header("Doors")]
    public GameObject doorLeft;
    public GameObject doorRight;

    [Header("Collider")]
    public GameObject doorsCollider;

    [Header("Sounds")]
    private AudioSource elevatorSoundsSource;
    public AudioClip doorsMovingSound;
    public AudioClip doorsClosedSound;
    public AudioClip elevatorMovingSound;

    [Header("Buttons")]
    public Button callButton;
    public Button ExitLevelButton;

    [Header("Next Level")]
    public string nextLevelScene;

    [Header("Configs")]
    public Status status = Status.Closed;
    public float openingSpeed = 1;
    public float openOffset = 4.5f;
    public float delayBeforeSceneChange = 5;
    private float startingX = 0;
    bool exitingLevel = false;

    [Header("UI Fade Reference")]
    public UIFade uiFadeScript;

    public void endLevel()
        {
            //CloseDoors();
            uiFadeScript.Fade(false);
            exitingLevel = true;
        }

private void Update()
    {           
        if (exitingLevel)
        {
            if (delayBeforeSceneChange <= 0)
                StartCoroutine(GotoLevel());

            else
                delayBeforeSceneChange -= Time.deltaTime;
        }
    }

    IEnumerator GotoLevel()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(nextLevelScene);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}

