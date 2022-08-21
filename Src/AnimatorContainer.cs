using ATGAnimatorHC.Interfaces;
using UnityEngine;

namespace ATGAnimatorHC
{
    public class AnimatorContainer: IAnimator
    {
        private readonly Animator _animator;
        private readonly AnimatorStateData _data;

        public AnimatorContainer(Animator animator, AnimatorStateData data)
        {
            _animator = animator;
            _data = data;
        }
        
        public void SetOnlyOneState(in AnimatorAction action,in bool value) =>
            _data.SetState(_animator, action, value);

        public void SetOneStateAndOffOther(in AnimatorAction action,in bool value) =>
            _data.SetState(_animator, action, value, true);
    }
}