using System;
using System.Collections.Generic;
using Sources;
using Sources.Interfaces;
using UnityEngine;

public class PointerStateMachine : MonoBehaviour,ICoroutineRunner
{
    [SerializeField] private Transform _buildingTransform;
    [SerializeField] private LoaderStage _loaderStage;
    [SerializeField] private InputRouter _inputRouter;
    [SerializeField] private Animator _animator;

    private Dictionary<Type,IState> _states;

    private void Awake()
    {
        Transform currentTransform = transform;

        _states = new Dictionary<Type,IState>()
        {
            [typeof(PointerMoveState)] = new PointerMoveState(this,currentTransform,_buildingTransform),
            [typeof(PointerClickState)] = new PointerClickState(this,_inputRouter,_animator,currentTransform),
        };
    }


    private void OnEnable()
    {
        _loaderStage.Finished += OnLoaderFinished;
    }

    private void OnDisable()
    {
        _loaderStage.Finished -= OnLoaderFinished;
    }

    public void Enter<TState>() where TState : IState
    {
        IState state = _states[typeof(TState)];
        state.Enter();
    }

    private void OnLoaderFinished()
    {
        Enter<PointerMoveState>();
    }
}
