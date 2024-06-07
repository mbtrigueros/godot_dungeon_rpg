using Godot;
using System;

public partial class PlayerDashState : PlayerState
{
    [Export] private Timer dashTimerNode;
    [Export] private Timer cooldownTimerNode;
    [Export] private PackedScene bombScene;

    [Export(PropertyHint.Range, "0.5,20,0.1")] private float speed = 10;
    public override void _Ready()
    {
        // For the ready method to work correctly we first have to call the base, and then add whatever we want to modify.
        base._Ready();
        dashTimerNode.Timeout += HandleDashTimeout;
        CanTransition = () => cooldownTimerNode.IsStopped();
    }

    public override void _PhysicsProcess(double delta)
    {
        characterNode.MoveAndSlide();
        characterNode.Flip();
    }

    private void HandleDashTimeout()
    {
        characterNode.Velocity = Vector3.Zero;
        characterNode.StateMachineNode.SwitchState<PlayerIdleState>();
        cooldownTimerNode.Start();
    }

    protected override void EnterState()
    {
        characterNode.AnimPlayerNode.Play(GameConstants.ANIM_DASH);
        characterNode.Velocity = new(
            characterNode.direction.X, 0, characterNode.direction.Y
        );

        if (characterNode.Velocity == Vector3.Zero)
        {
            characterNode.Velocity =
            characterNode.Sprite3DNode.FlipH
            ? Vector3.Left
            : Vector3.Right;
        }
        characterNode.Velocity *= speed;

        // Timer start
        dashTimerNode.Start();

        Node3D bomb = bombScene.Instantiate<Node3D>();
        GetTree().CurrentScene.AddChild(bomb);
        bomb.GlobalPosition = characterNode.GlobalPosition;
    }
}