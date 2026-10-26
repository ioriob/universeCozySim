using Godot;
using UniverseCozySim.Core;

namespace UniverseCozySim.UI;

/// <summary>
/// HUD in sovrimpressione (scenes/ui/hud.tscn). Ascolta gli eventi dei manager
/// e si scollega in _ExitTree, perché i manager (Autoload) sopravvivono alla scena.
/// </summary>
public partial class HUDController : CanvasLayer
{
    private Label _timeLabel;
    private Label _waterLabel;
    private Label _oxygenLabel;

    public override void _Ready()
    {
        _timeLabel = GetNode<Label>("%TimeLabel");
        _waterLabel = GetNode<Label>("%WaterLabel");
        _oxygenLabel = GetNode<Label>("%OxygenLabel");

        if (TimeManager.Instance is { } time)
        {
            time.OnGameHourPassed += UpdateTimeDisplay;
            UpdateTimeDisplay(time.CurrentHour, time.CurrentDay);
        }

        if (StationResources.Instance is { } res)
        {
            res.OnWaterChanged += UpdateWaterDisplay;
            res.OnOxygenChanged += UpdateOxygenDisplay;
            UpdateWaterDisplay(res.CurrentWater, res.MaxWaterLiters);
            UpdateOxygenDisplay(res.CurrentOxygen, res.MaxOxygenUnits);
        }
    }

    public override void _ExitTree()
    {
        if (TimeManager.Instance is { } time)
            time.OnGameHourPassed -= UpdateTimeDisplay;

        if (StationResources.Instance is { } res)
        {
            res.OnWaterChanged -= UpdateWaterDisplay;
            res.OnOxygenChanged -= UpdateOxygenDisplay;
        }
    }

    private void UpdateTimeDisplay(int hour, int day) =>
        _timeLabel.Text = $"SOL {day} - {hour:D2}:00";

    private void UpdateWaterDisplay(float current, float max) =>
        _waterLabel.Text = $"H2O: {current:F1} / {max:F0} L";

    private void UpdateOxygenDisplay(float current, float max) =>
        _oxygenLabel.Text = $"O2:  {current:F1} / {max:F0} u";
}
