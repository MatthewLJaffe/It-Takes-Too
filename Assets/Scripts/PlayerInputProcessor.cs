using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInputProcessor : MonoBehaviour
{
    public UnityEvent Attack;
    public UnityEvent Jump;
    public UnityEvent Interact;

    private bool upKeyPressed;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))// || Input.GetKeyDown(KeyCode.Space))
        {
            Attack.Invoke();
        }

        if (!upKeyPressed && Input.GetAxis("Jump") > 0.01f)// || Input.GetKeyDown(KeyCode.W))
        {
            upKeyPressed = true;
            Jump.Invoke();
        }

        if (Input.GetAxis("Jump") < 0.01f)// || Input.GetKeyUp(KeyCode.W))
        {
            upKeyPressed = false;
        }

        if (Input.GetButtonDown("Interact"))// || Input.GetKeyDown(KeyCode.E))
        {
            Interact.Invoke();
        }
        
    }
}
