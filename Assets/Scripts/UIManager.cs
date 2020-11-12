using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    Text _pickupText;
    [SerializeField]
    Text _dropText;
    private Player _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateDropText()
    {
        _dropText.gameObject.SetActive(true);
    }
    public void DeactivateDropText()
    {
        _dropText.gameObject.SetActive(false);
    }
    public void ActivatePickupText()
    {
        if (!_player.hasPumpkin)
        {
            _pickupText.gameObject.SetActive(true);
        }
    }
    public void DeactivatePickupText()
    {
        _pickupText.gameObject.SetActive(false);
    }
}
