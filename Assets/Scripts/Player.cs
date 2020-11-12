using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    CharacterController _cc;
    [SerializeField]
    private float _speed = 3.5f;
    private float _gravity = 1f;
    private float _yVelocity;
    NavMeshAgent _navMeshAgent;
    [SerializeField]
    private AudioSource _foot;
    Vector3 lastPosition; // last place player was on update
    float moveMinimum = 0.01f; 
    public bool playerCanPickUp = false;
    public bool hasPumpkin = false;
    [SerializeField]
    private GameObject _pumpkinInHand;
    public bool droppedPumpkin = false;

    void Start()
    {
        _cc = GetComponent<CharacterController>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        StartCoroutine(PlaySounds());

    }

    // Update is called once per frame
    void Update()
    {
        lastPosition = transform.position;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        CalculateMovement();
        if(Input.GetKeyDown(KeyCode.E))
        {
            if (playerCanPickUp && !hasPumpkin)
            {
                PickupPumpkin();
            }
        }
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(hasPumpkin)
            {
                StopCoroutine(DropPumpkin());
            }
        }
    }


    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        Vector3 velocity = _speed * direction;

        velocity.y = _yVelocity;
        _yVelocity -= _gravity;

        velocity = transform.transform.TransformDirection(velocity);

        _cc.Move(velocity * Time.deltaTime);
    }

    IEnumerator DisableAgent()
    {
        _navMeshAgent.enabled = false;
        yield return new WaitForSeconds(1f);
        _navMeshAgent.enabled = true;
    }

    IEnumerator PlaySounds()
    {
        while(true)
        {
            if(Input.GetAxis("Vertical") != 0f)
            {
                if(!_foot.isPlaying)
                {
                    _foot.Play();
                }
            }
            else
            {
                _foot.Stop();
            }
            yield return null;
        }
    }

    private void PickupPumpkin()
    {
        _pumpkinInHand.SetActive(true);
        hasPumpkin = true;
    }
    
    private IEnumerator DropPumpkin()
    {
        _pumpkinInHand.SetActive(false);
        hasPumpkin = false;
        droppedPumpkin = true;
        yield return new WaitForSeconds(3f);
        droppedPumpkin = false;
    }
}
