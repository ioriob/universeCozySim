using Godot;
using System;

namespace UniverseCozySim.Core;

/// <summary>
/// Risorse vitali della stazione (acqua, ossigeno). Autoload.
/// Si aggancia da sola a <see cref="TimeManager"/> per il consumo orario di base:
/// TimeManager non sa nulla delle risorse, così i due sistemi restano indipendenti.
/// </summary>
public partial class StationResources : Node
{
    public static StationResources Instance { get; private set; }

    /// <summary>(valore attuale, massimo)</summary>
    public event Action<float, float> OnWaterChanged;
    /// <summary>(valore attuale, massimo)</summary>
    public event Action<float, float> OnOxygenChanged;
    /// <summary>Scatta una volta quando l'acqua arriva a zero.</summary>
    public event Action OnWaterDepleted;
    /// <summary>Scatta una volta quando l'ossigeno arriva a zero.</summary>
    public event Action OnOxygenDepleted;

    [ExportGroup("Capacità massima")]
    [Export] public float MaxWaterLiters { get; set; } = 1000f;
    [Export] public float MaxOxygenUnits { get; set; } = 500f;

    [ExportGroup("Livelli iniziali")]
    [Export] public float InitialWater { get; set; } = 500f;
    [Export] public float InitialOxygen { get; set; } = 300f;

    [ExportGroup("Consumo orario di base")]
    [Export] public float WaterUsePerHour { get; set; } = 1.5f;
    [Export] public float OxygenUsePerHour { get; set; } = 0.5f;

    public float CurrentWater { get; private set; }
    public float CurrentOxygen { get; private set; }

    public override void _EnterTree()
    {
        Instance = this;
        CurrentWater = InitialWater;
        CurrentOxygen = InitialOxygen;
    }

    public override void _Ready()
    {
        if (TimeManager.Instance != null)
            TimeManager.Instance.OnGameHourPassed += HandleHourPassed;
    }

    public override void _ExitTree()
    {
        if (TimeManager.Instance != null)
            TimeManager.Instance.OnGameHourPassed -= HandleHourPassed;

        if (Instance == this) Instance = null;
    }

    /// <summary>Riporta le risorse ai valori iniziali (nuova partita).</summary>
    public void ResetToInitial()
    {
        SetWater(InitialWater);
        SetOxygen(InitialOxygen);
    }

    /// <summary>
    /// Consuma acqua. Se non basta, consuma quella che c'è e restituisce false.
    /// </summary>
    public bool ConsumeWater(float amount)
    {
        bool enough = CurrentWater >= amount;
        SetWater(CurrentWater - amount);
        return enough;
    }

    public void AddWater(float amount) => SetWater(CurrentWater + amount);

    /// <summary>
    /// Consuma ossigeno. Se non basta, consuma quello che c'è e restituisce false.
    /// </summary>
    public bool ConsumeOxygen(float amount)
    {
        bool enough = CurrentOxygen >= amount;
        SetOxygen(CurrentOxygen - amount);
        return enough;
    }

    public void AddOxygen(float amount) => SetOxygen(CurrentOxygen + amount);

    private void HandleHourPassed(int hour, int day)
    {
        ConsumeWater(WaterUsePerHour);
        ConsumeOxygen(OxygenUsePerHour);
    }

    private void SetWater(float value)
    {
        float old = CurrentWater;
        CurrentWater = Mathf.Clamp(value, 0f, MaxWaterLiters);

        if (!Mathf.IsEqualApprox(old, CurrentWater))
            OnWaterChanged?.Invoke(CurrentWater, MaxWaterLiters);

        if (old > 0f && CurrentWater <= 0f)
            OnWaterDepleted?.Invoke();
    }

    private void SetOxygen(float value)
    {
        float old = CurrentOxygen;
        CurrentOxygen = Mathf.Clamp(value, 0f, MaxOxygenUnits);

        if (!Mathf.IsEqualApprox(old, CurrentOxygen))
            OnOxygenChanged?.Invoke(CurrentOxygen, MaxOxygenUnits);

        if (old > 0f && CurrentOxygen <= 0f)
            OnOxygenDepleted?.Invoke();
    }
}
