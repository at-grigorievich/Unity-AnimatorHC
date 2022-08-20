using ATGAnimatorHC.Interfaces;
using UnityEngine;

namespace ATGAnimatorHC
{
    public class AnimatorBehaviour : MonoBehaviour, IAnimator
    {
        [SerializeField] protected Animator _animator;
        [SerializeField] protected AnimatorStateData _animatorStates;

        private IAnimator _animatorContainer;
        
        public void SetOnlyOneState(in AnimatorAction action,in bool value) =>
            GetAnimatorContainer().SetOnlyOneState(action, value);

        public void SetOneStateAndOffOther(in AnimatorAction action, in bool value) =>
            GetAnimatorContainer().SetOneStateAndOffOther(action, value);

        
        private IAnimator GetAnimatorContainer()
        {
            _animatorContainer ??= new AnimatorContainer(_animator, _animatorStates);
            return _animatorContainer;
        }
    }
}