using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SimpleButton : MonoBehaviour
{
    public bool startActivated;
    public bool activated;
    [SerializeField] bool onlyOnce;
    public UnityEvent OnActivation;
    public UnityEvent OnDeactivation;

    // Start is called before the first frame update
    void Start()
    {
        if (startActivated)
        {
            activated = true;
            OnActivation.Invoke();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            if (activated == false)
            {
                OnActivation.Invoke();
                Debug.Log("Button Activated!");
                activated = true;
            }
            else if (activated && onlyOnce == false)
            {
                OnDeactivation.Invoke();
            }
        }
    }

    public void Reset()
    {
        startActivated = false;
        activated = false;
    }

}
