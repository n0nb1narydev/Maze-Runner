using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    public bool endLevel;
    private UIManager uiManager;
    // Start is called before the first frame update
    void Start()
    {
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        endLevel = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (endLevel)
        {
            uiManager.ActivateGameOverText();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            endLevel = true;
        }
    }
}
