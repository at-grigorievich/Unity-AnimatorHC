namespace ATGAnimatorHC.Interfaces
{
    public interface IAnimator
    {
        void SetOnlyOneState(in AnimatorAction action,in bool value);
        void SetOneStateAndOffOther(in AnimatorAction action,in bool value);
    }
}