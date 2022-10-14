using UnityEngine;

public class GhostRun : GhostBehaviour
{

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetAnimations(AnimatorOverrideController overrideController)
    {
        _animator.runtimeAnimatorController = overrideController;
    }

    public bool eaten { get; private set; }

    public override void Enable(float duration)
    {
        base.Enable(duration);
        //change to powerup animation
        //Invoke(nameof(Flash), duration / 2.0f);
    }

    private overrride void Disable()
    {
        base.Disable();
        //change back to normal
    }

    private void Flash()
    {
        if (!this.eaten)
        {
        //flash between blue and white powerup
        }
    }

    private void OnEnable()
    {
        
    }
}
