using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAIBrain : MonoBehaviour, IAgentInput
{
    [field: SerializeField]
    public GameObject Target { get; set; }

    [field: SerializeField]
    private AIState  CurrentState { get; set; }
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
        Target = FindObjectOfType<Player>().gameObject;
    }

    private void Update()
    {
        if (Target == null)
        {
            OnMovementKeyPressed?.Invoke(Vector2.zero);
        }
        else
        {
            CurrentState.UdateState();
        }

    }

    public void Attack()
    {
        OnFireButonDown?.Invoke();
    }

    public void EnemyMove(Vector2 movementDirection, Vector2 targetPosition)
    {
        OnMovementKeyPressed?.Invoke(movementDirection);
        OnPointerPositionChange?.Invoke(targetPosition);
    }

    internal void ChangeToState(AIState state)
    {
        CurrentState = state;
    }
}
