using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AgentInput : MonoBehaviour, IAgentInput
{
    private Camera mainCamara;
    [field: SerializeField]
    private bool fireButtonDown = false;
    [field: SerializeField]
    public UnityEvent<Vector2> OnMovementKeyPressed { get; set; }

    [field: SerializeField]
    public UnityEvent<Vector2> OnPointerPositionChange { get; set; }

    [field: SerializeField]
    public UnityEvent OnFireButonDown { get; set; }
    [field: SerializeField]
    public UnityEvent OnFireButonRelease { get; set; }

    private void Awake()
    {
        mainCamara = Camera.main;
    }
    private void Update()
    {
        GetMovementInout();
        GetPointerInput();
        GetFireInput();
    }

    private void GetFireInput()
    {
        if (Input.GetAxisRaw("Fire1") > 0)
        {
            if (fireButtonDown == false)
            {
                fireButtonDown = true;
                OnFireButonDown?.Invoke();
            }
        }
        else
        {
            if (fireButtonDown)
            {
                fireButtonDown = false;
                OnFireButonRelease?.Invoke();
            }
        }
    }

    private void GetPointerInput()
    {
        var mouseInWoldSpace = mainCamara.ScreenToWorldPoint(Input.mousePosition);
        OnPointerPositionChange?.Invoke(mouseInWoldSpace);
    }

    private void GetMovementInout()
    {
        OnMovementKeyPressed?.Invoke(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
    }
}
