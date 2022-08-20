using System;
using UnityEngine;

namespace ATGAnimatorHC
{
    public enum StateType
    {
        Bool,
        Trigger,
        CrossFade
    }
    
    [Serializable]
    public class CrossFadeOption
    {
        [field: SerializeField] public float CrossFadeDuration;
        [field: SerializeField] public int AnimatorLayer = -1;
    }
    
    [Serializable]
    public class AnimatorState
    {
        [SerializeField] private AnimatorAction _actionType;
        [SerializeField] private StateType _stateType;
        [SerializeField] private string _stateName;

        [Header("Available only in CrossFade State")]
        [SerializeField] private CrossFadeOption _crossFadeOption;
        
        private int _stateIndex;

        public AnimatorAction ActionType => _actionType;


        public void OnEnable() =>
            _stateIndex = Animator.StringToHash(_stateName);
        
        
        public void ChangeState(Animator animator,bool value)
        {
            switch (_stateType)
            {
                case StateType.Bool: 
                    animator.SetBool(_stateIndex, value);
                    break;
                case StateType.Trigger: 
                    animator.SetTrigger(_stateIndex);
                    break;
                case StateType.CrossFade:
                    if (!value) break;
                    animator.CrossFade(_stateIndex,
                        _crossFadeOption.CrossFadeDuration,_crossFadeOption.AnimatorLayer);
                    break;
            }
        }
    }
}