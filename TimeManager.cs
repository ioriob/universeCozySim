using Godot;
using System;

namespace SpaceSim.Core;

public partial class TimeManager : Node
{
    public static TimeManager Instance { get; private set; }

    // Evento scatenato ogni volta che passa 1 ora di gioco (1 Tick)
    public event Action<int, int> OnGameHourPassed; // (Ora, Giorno)
    public event Action<int> OnGameDayPassed;       // (Giorno)

    [Export] public float SecondsPerGameHour { get; set; } = 2.5f; // 2.5 sec reali = 1 ora in gioco

    public int CurrentHour { get; private set; } = 6;  // Inizio turno alle 06:00
    public int CurrentDay { get; private set; } = 1;

    private float _timer = 0.0f;
    private bool _isPaused = false;

    public override void _Ready()
    {
        Instance = this;
    }

    public override void _Process(double delta)
    {
        if (_isPaused) return;

        _timer += (float)delta;

        if (_timer >= SecondsPerGameHour)
        {
            _timer -= SecondsPerGameHour;
            AdvanceHour();
        }
    }

    private void AdvanceHour()
    {
        CurrentHour++;

        if (CurrentHour >= 24)
        {
            CurrentHour = 0;
            CurrentDay++;
            OnGameDayPassed?.Invoke(CurrentDay);
        }

        OnGameHourPassed?.Invoke(CurrentHour, CurrentDay);

        // Ad ogni ora trascurata, la stazione consuma ossigeno e acqua di base!
        if (StationResources.Instance != null)
        {
            // Consumo di base di mantenimento habitat
            StationResources.Instance.ConsumeWater(1.5f);
            StationResources.Instance.UpdateOxygen(-0.5f);
        }
    }

    public void TogglePause()
    {
        _isPaused = !_isPaused;
    }
}