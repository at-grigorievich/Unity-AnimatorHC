using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ATGAnimatorHC
{
    [CreateAssetMenu(fileName = "Animator States Data", 
        menuName = "Animator Control / New Animator States Data", order = 0)]
    public class AnimatorStateData : ScriptableObject
    {
        [SerializeField] private AnimatorState[] states;

        private Dictionary<AnimatorAction, AnimatorState> _statesDictionary;

        private void OnEnable()
        {
            _statesDictionary = new Dictionary<AnimatorAction, AnimatorState>();

            foreach (var state in states)
            {
                state.OnEnable();
                _statesDictionary.Add(state.ActionType,state);
            }
        }

        private void OnDisable()
        {
            _statesDictionary = null;
        }

        public void SetState(Animator animator, AnimatorAction action, bool actionValue, bool isOffOther = false)
        {
            if (_statesDictionary.ContainsKey(action))
            {
                SetOneState(animator, _statesDictionary[action], actionValue);

                if (!isOffOther) return;
                
                foreach (var offState in _statesDictionary.Values
                             .Where(offState => !offState.ActionType.Equals(action)))
                {
                    SetOneState(animator,offState,false);
                }
            }
            else throw new NullReferenceException($"{action} AnimatorAction doesnt exist!");
        }


        private static void SetOneState(Animator animator, AnimatorState state, bool value)
        {
            state.ChangeState(animator,value);
        }
    }
}
