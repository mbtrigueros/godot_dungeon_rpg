using System;
using Godot;

[GlobalClass]
public partial class StatResource : Resource
{
    // We are creating an event. These are written conventionally in PascalCase with the On prefix, and we use the Action keyword as it's type. It's also recommended to use the event keyword so C# recognizes it as an event. This is helpful to prevent errors.
    public event Action OnZero;
    public event Action OnUpdate;

    // These are properties, they're written in PascalCase. 
    [Export] public Stat StatType { get; private set; }

    // It's common practice to write the properties variables the same name, with an underscore prefix and in camelCase. This indicates this variable is manipulated by a property.
    private float _statValue;
    [Export]
    public float StatValue
    {
        get => _statValue;
        set
        {
            _statValue = Mathf.Clamp(value, 0, Mathf.Inf);

            OnUpdate?.Invoke();
            if (_statValue == 0)
            {
                OnZero?.Invoke();
            }
        }
    }
}