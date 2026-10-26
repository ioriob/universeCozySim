using Godot;
using System;

namespace UniverseCozySim.Core;

/// <summary>
/// Orologio di gioco. Registrato come Autoload in project.godot,
/// quindi vive per tutta la durata del gioco, a prescindere dalla scena.
/// Parte fermo: è la scena di gioco a chiamare <see cref="StartClock"/>.
/// </summary>
public partial class TimeManager : Node
{
    public static TimeManager Instance { get; private set; }

    /// <summary>Scatta ogni ora di gioco (1 tick). Parametri: (ora, giorno).</summary>
    public event Action<int, int> OnGameHourPassed;

    /// <summary>Scatta a mezzanotte. Parametro: nuovo giorno.</summary>
    public event Action<int> OnGameDayPassed;

    [Export] public float SecondsPerGameHour { get; set; } = 2.5f; // 2.5 s reali = 1 ora di gioco
    [Export] public int StartHour { get; set; } = 6;               // Inizio turno alle 06:00

    public int CurrentHour { get; private set; }
    public int CurrentDay { get; private set; } = 1;
    public bool IsRunning { get; private set; }

    private float _timer;

    public override void _EnterTree()
    {
        // _EnterTree arriva prima di qualsiasi _Ready: gli altri nodi trovano già l'istanza.
        Instance = this;
        CurrentHour = StartHour;
    }

    public override void _ExitTree()
    {
        if (Instance == this) Instance = null;
    }

    public override void _Process(double delta)
    {
        if (!IsRunning) return;

        _timer += (float)delta;

        while (_timer >= SecondsPerGameHour)
        {
            _timer -= SecondsPerGameHour;
            AdvanceHour();
        }
    }

    public void StartClock() => IsRunning = true;
    public void StopClock() => IsRunning = false;
    public void TogglePause() => IsRunning = !IsRunning;

    /// <summary>Riporta l'orologio all'inizio (nuova partita).</summary>
    public void ResetClock()
    {
        CurrentDay = 1;
        CurrentHour = StartHour;
        _timer = 0f;
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
    }
}
