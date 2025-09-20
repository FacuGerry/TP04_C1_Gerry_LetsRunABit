using UnityEngine;

public class AnimationsPlayer : MonoBehaviour
{
    private Animator anim;
    private static readonly int state = Animator.StringToHash("State");

    private enum PlayerState
    {
        Run = 1,
        Jump = 2,
        Invincible = 3,
    }

    [SerializeField] private PlayerState playerState;
    
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        anim.SetInteger(state, (int)playerState);
    }

    public void Run()
    {
        anim.SetInteger(state, (int)PlayerState.Run);
    }

    public void Jumping()
    {
        anim.SetInteger(state, (int)PlayerState.Jump);
    }
}
