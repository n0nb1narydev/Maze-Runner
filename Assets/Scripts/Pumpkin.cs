using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pumpkin : MonoBehaviour
{
    private UIManager _uiManager;
    private Player _player;
    // Start is called before the first frame update
    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_player.hasPumpkin)
        {
            _uiManager.ActivateDropText();
        }
        else 
        {
            _uiManager.DeactivateDropText();
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            _uiManager.ActivatePickupText();
            _player.playerCanPickUp = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _uiManager.DeactivatePickupText();
            _player.playerCanPickUp = false;
        }
    }
}
