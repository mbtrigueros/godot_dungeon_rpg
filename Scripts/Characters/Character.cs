using Godot;
using System;
using System.Linq;
public abstract partial class Character : CharacterBody3D
{
    [Export] private StatResource[] stats;

    [ExportGroup("Required Nodes")]

    // since we changed these fields to properties (adding the get and set, so we can view them from anywhere but only change them from this class), we use PascalCase to name them, instead of camelCase. it's a common practice of c# 
    [Export] public AnimationPlayer AnimPlayerNode { get; private set; }
    [Export] public Sprite3D Sprite3DNode { get; private set; }
    [Export] public StateMachine StateMachineNode { get; private set; }
    [Export] public Area3D HurtBoxNode { get; private set; }
    [Export] public Area3D HitBoxNode { get; private set; }
    [Export] public CollisionShape3D HitBoxShape3DNode { get; private set; }
    [Export] public Timer HurtTimer { get; private set; }

    [ExportGroup("AI Nodes")]
    [Export] public Path3D PathNode { get; private set; }
    [Export] public NavigationAgent3D AgentNode { get; private set; }
    [Export] public Area3D ChaseAreaNode { get; private set; }
    [Export] public Area3D AttackAreaNode { get; private set; }


    private ShaderMaterial shader;

    public override void _Ready()
    {
        shader = (ShaderMaterial)Sprite3DNode.MaterialOverlay;
        HurtBoxNode.AreaEntered += HandleHurtBoxEntered;

        Sprite3DNode.TextureChanged += HandleTextureChanged;
        HurtTimer.Timeout += () => shader.SetShaderParameter("active", false);
    }

    private void HandleTextureChanged()
    {
        shader.SetShaderParameter(
            "tex", Sprite3DNode.Texture
        );
    }

    private void HandleHurtBoxEntered(Area3D area)
    {
        if (area is not IHitbox hitbox) { return; }

        StatResource health = GetStatResource(Stat.Health);

        float damage = hitbox.GetDamage();

        health.StatValue -= damage;

        shader.SetShaderParameter("active", true);
        HurtTimer.Start();

    }

    public StatResource GetStatResource(Stat stat)
    {
        return stats.Where((element) => element.StatType == stat).FirstOrDefault();
    }

    public Vector2 direction = new();

    public void Flip()
    {
        bool isNotMovingHorizontally = Velocity.X == 0;
        if (isNotMovingHorizontally) { return; }
        bool isMovingLeft = Velocity.X < 0;
        Sprite3DNode.FlipH = isMovingLeft;
    }

    // With this method we'll disable or enable the hitbox collision shape node.
    public void ToggleHitBox(bool flag)
    {
        HitBoxShape3DNode.Disabled = flag;
    }
}