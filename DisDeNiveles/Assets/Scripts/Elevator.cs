using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Elevator : MonoBehaviour
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

    private void Start()
    {
        startingX = doorLeft.transform.localPosition.x;
        elevatorSoundsSource = GetComponent<AudioSource>();
    }

    public void OpenDoors()
    {
        if (status == Status.Closed)
        {
            status = Status.Opening;
            elevatorSoundsSource.PlayOneShot(doorsMovingSound);
        }
    }

    public void CloseDoors()
    {
        if (status == Status.Open)
        {
            status = Status.Closing;
            elevatorSoundsSource.PlayOneShot(doorsMovingSound);
        }
            
    }

    private void Update()
    {
         if (status == Status.Closed && callButton._alreadyInteracted && !exitingLevel)
            OpenDoors();
        
        if (status == Status.Open && ExitLevelButton._alreadyInteracted)
        {
            CloseDoors();
            uiFadeScript.Fade(false);
            exitingLevel = true;
        }

        float finalSpeed = (Time.deltaTime * openingSpeed) / 100;
        float x = doorLeft.transform.localPosition.x;

        if (status == Status.Opening && (doorLeft.transform.localPosition.x < startingX + openOffset))
        {
            doorLeft.transform.localPosition = new Vector3(
            doorLeft.transform.localPosition.x + finalSpeed,
            doorLeft.transform.localPosition.y,
            doorLeft.transform.localPosition.z);

            doorRight.transform.localPosition = new Vector3(
            doorRight.transform.localPosition.x - finalSpeed,
            doorRight.transform.localPosition.y,
            doorRight.transform.localPosition.z);
        }

        if (status == Status.Closing && (doorLeft.transform.localPosition.x > startingX - openOffset))
        {
            doorLeft.transform.localPosition = new Vector3(
            doorLeft.transform.localPosition.x - finalSpeed,
            doorLeft.transform.localPosition.y,
            doorLeft.transform.localPosition.z);

            doorRight.transform.localPosition = new Vector3(
            doorRight.transform.localPosition.x + finalSpeed,
            doorRight.transform.localPosition.y,
            doorRight.transform.localPosition.z);
        }

        if (status == Status.Opening && x >= startingX + openOffset)
        {
            status = Status.Open;
            elevatorSoundsSource.PlayOneShot(doorsClosedSound);
        }

        if (status == Status.Closing && x <= startingX)
            status = Status.Closed;

        if (doorsCollider != null)
        {
            if (status == Status.Closing && !doorsCollider.activeSelf) 
                doorsCollider.SetActive(true);

            else if ((status == Status.Open || status == Status.Closed) && doorsCollider.activeSelf)
            {
                doorsCollider.SetActive(false);
                elevatorSoundsSource.PlayOneShot(doorsClosedSound);
            }
        }

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
