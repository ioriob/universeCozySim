using Godot;
using System;

namespace SpaceSim.Core;

public partial class HUDController : Control
{
	[Export] public Label TimeLabel { get; set; }
	[Export] public Label WaterLabel { get; set; }
	[Export] public Label OxygenLabel { get; set; }

	public override void _Ready()
	{
		// Se non sono stati assegnati da Inspector, proviamo a prenderli dai nodi figli
		TimeLabel ??= GetNodeOrNull<Label>("VBoxContainer/TimeLabel") ?? GetNodeOrNull<Label>("%TimeLabel");
		WaterLabel ??= GetNodeOrNull<Label>("VBoxContainer/WaterLabel") ?? GetNodeOrNull<Label>("%WaterLabel");
		OxygenLabel ??= GetNodeOrNull<Label>("VBoxContainer/OxygenLabel") ?? GetNodeOrNull<Label>("%OxygenLabel");

		if (TimeManager.Instance != null)
		{
			TimeManager.Instance.OnGameHourPassed += UpdateTimeDisplay;
			UpdateTimeDisplay(TimeManager.Instance.CurrentHour, TimeManager.Instance.CurrentDay);
		}

		if (StationResources.Instance != null)
		{
			StationResources.Instance.OnWaterChanged += UpdateWaterDisplay;
			StationResources.Instance.OnOxygenChanged += UpdateOxygenDisplay;

			UpdateWaterDisplay(StationResources.Instance.CurrentWater, StationResources.Instance.MaxWaterLiters);
			UpdateOxygenDisplay(StationResources.Instance.CurrentOxygen, StationResources.Instance.MaxOxygenUnits);
		}
	}

	private void UpdateTimeDisplay(int hour, int day)
	{
		if (TimeLabel != null)
			TimeLabel.Text = $"SOL {day} - {hour:D2}:00";
	}

	private void UpdateWaterDisplay(float current, float max)
	{
		if (WaterLabel != null)
			WaterLabel.Text = $"H2O: {current:F1} / {max:F0} L";
	}

	private void UpdateOxygenDisplay(float current, float max)
	{
		if (OxygenLabel != null)
			OxygenLabel.Text = $"O2:  {current:F1} / {max:F0} u";
	}
}
