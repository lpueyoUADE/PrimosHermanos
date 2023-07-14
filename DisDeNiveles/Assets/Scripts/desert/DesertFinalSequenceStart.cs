using UnityEngine;
using UnityEngine.SceneManagement;

public class DesertFinalSequenceStart : Interactable
{
    public AudioSource[] audioSrcStop;
    public AudioSource audioSrcStart;
    public UISimpleSubtitlesObject subtitles;
    public DesertRiseCars riseThis;
    public Camera theCamera;

    [Header("elevator stuff")]
    public DesertRiseCars elevatorRise;
    public Elevator elevatorScript;
    public Button[] elevatorButtons;

    [Header("additional")]
    public GameObject[] addActivations;

    public override void Interact()
    {
        base.Interact();
        _alreadyInteracted = true;
        audioSrcStart.Play();
        subtitles.StartExec();
        riseThis.EnableRisingCars();

        

        for (int i = 0; i < audioSrcStop.Length; i++)
            audioSrcStop[i].Stop();

        if (addActivations.Length != 0)
            for (int i = 0; i < addActivations.Length; i++)
                addActivations[i].SetActive(true);
    }

    private void Update()
    {
        if (_alreadyInteracted && !audioSrcStart.isPlaying)
        {
            elevatorRise.EnableRisingCars();

            for (int i = 0; i < elevatorButtons.Length; i++)
                elevatorButtons[i].active = true;
        }
    }
}
