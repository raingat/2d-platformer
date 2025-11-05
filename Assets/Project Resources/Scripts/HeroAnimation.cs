using UnityEngine;

public class HeroAnimation : MonoBehaviour
{
    private static readonly int IsRunning = Animator.StringToHash(nameof(IsRunning));
    private static readonly int IsJumping = Animator.StringToHash(nameof(IsJumping));

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayAnimationRun(bool isRunning)
    {
        _animator.SetBool(IsRunning, isRunning);
    }

    public void PlayAnimationJump(bool isJumping)
    {
        _animator.SetBool(IsJumping, isJumping);
    }
}
