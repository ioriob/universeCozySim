using Godot;

namespace UniverseCozySim.Core;

/// <summary>
/// Radice della scena di gioco: avvia una nuova partita all'ingresso
/// e ferma l'orologio quando si esce (es. ritorno al menu).
/// </summary>
public partial class MainScene : Node2D
{
    public override void _Ready()
    {
        StationResources.Instance?.ResetToInitial();
        TimeManager.Instance?.ResetClock();
        TimeManager.Instance?.StartClock();
    }

    public override void _ExitTree()
    {
        TimeManager.Instance?.StopClock();
    }
}
