using Godot;
using System;

public partial class PlayerIdleState : PlayerState
{

    public override void _PhysicsProcess(double delta)
    {

        if (characterNode.direction != Vector2.Zero)
        {
            characterNode.StateMachineNode.SwitchState<PlayerMoveState>();
        }
    }
    public override void _Input(InputEvent @event)
    {
        CheckForAttackInput();
        CheckForDashInput();
    }

    protected override void EnterState()
    {
        characterNode.AnimPlayerNode.Play(GameConstants.ANIM_IDLE);
    }
}
