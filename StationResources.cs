using Godot;
using System;

namespace SpaceSim.Core;

public partial class StationResources : Node
{
    public static StationResources Instance { get; private set; }

    public event Action<float, float> OnWaterChanged;
    public event Action<float, float> OnOxygenChanged;

    [ExportGroup("Capacità Massima Stazione")]
    [Export] public float MaxWaterLiters { get; set; } = 1000.0f;
    [Export] public float MaxOxygenUnits { get; set; } = 500.0f;

    [ExportGroup("Livelli Attuali")]
    private float _currentWater = 500.0f;
    private float _currentOxygen = 300.0f;

    public float CurrentWater => _currentWater;
    public float CurrentOxygen => _currentOxygen;

    public override void _Ready()
    {
        Instance = this;
    }

    public bool ConsumeWater(float amount)
    {
        if (_currentWater >= amount)
        {
            _currentWater -= amount;
            OnWaterChanged?.Invoke(_currentWater, MaxWaterLiters);
            return true;
        }
        return false;
    }

    public void AddWater(float amount)
    {
        _currentWater = MathF.Min(MaxWaterLiters, _currentWater + amount);
        OnWaterChanged?.Invoke(_currentWater, MaxWaterLiters);
    }

    public void UpdateOxygen(float delta)
    {
        _currentOxygen = (float)Math.Clamp(_currentOxygen + delta, 0.0, MaxOxygenUnits);
        OnOxygenChanged?.Invoke(_currentOxygen, MaxOxygenUnits);
    }
}