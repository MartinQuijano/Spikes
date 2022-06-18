using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float horizontal;
    public float vertical;

    private bool readyToClearInputs;

    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        ClearInput();
        ProcessInputs();
    }

    private void FixedUpdate()
    {
        readyToClearInputs = true;
    }

    private void ClearInput()
    {
        if (!readyToClearInputs)
            return;

        horizontal = 0f;
        vertical = 0f;

        readyToClearInputs = false;
    }

    private void ProcessInputs()
    {
        if(Input.GetKeyDown(KeyCode.R)){
            gameManager.RestartGame();
        }
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }
}
