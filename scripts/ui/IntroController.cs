using Godot;

namespace UniverseCozySim.UI;

/// <summary>
/// Schermata introduttiva: prima l'illustrazione da sola, poi il riquadro della storia
/// in dissolvenza con il testo a macchina da scrivere, scelta lingua, e infine
/// il passaggio alla scena di gioco. I testi vengono da localization/translations.csv.
/// </summary>
public partial class IntroController : Control
{
    [Export(PropertyHint.File, "*.tscn")]
    public string NextScenePath { get; set; } = "res://scenes/main/main_scene.tscn";

    [Export] public float SecondsPerCharacter { get; set; } = 0.025f;
    [Export] public float IllustrationOnlySeconds { get; set; } = 2.0f; // l'immagine da sola, prima del testo
    [Export] public float PanelFadeSeconds { get; set; } = 0.6f;

    private Control _storyPanel;
    private RichTextLabel _storyLabel;
    private Label _continuePrompt;
    private Tween _typewriter;
    private bool _panelShown;

    private bool IsTyping => _typewriter != null && _typewriter.IsRunning();

    public override void _Ready()
    {
        _storyPanel = GetNode<Control>("StoryPanel");
        _storyLabel = GetNode<RichTextLabel>("%StoryLabel");
        _continuePrompt = GetNode<Label>("%ContinuePrompt"); // testo = chiave PROMPT_CONTINUE, tradotto in automatico

        GetNode<Button>("%BtnItalian").Pressed += () => SetLanguage("it");
        GetNode<Button>("%BtnEnglish").Pressed += () => SetLanguage("en");

        SetAlpha(_storyPanel, 0f);
        SetLanguage("it"); // lingua di default
    }

    private void SetLanguage(string locale)
    {
        TranslationServer.SetLocale(locale);
        _storyLabel.Text = $"[b]{Tr("INTRO_TITLE")}[/b]\n[color=#f29a40]{Tr("INTRO_SUBTITLE")}[/color]\n\n{Tr("INTRO_BODY")}";
        StartTypewriter();
    }

    private void StartTypewriter()
    {
        _typewriter?.Kill(); // se si cambia lingua a metà, si riparte da capo senza mescolare i testi
        SetAlpha(_continuePrompt, 0f); // trasparente, non nascosto: il riquadro non cambia altezza
        _storyLabel.VisibleRatio = 0f;

        _typewriter = CreateTween(); // legato a questo nodo: si ferma da solo se la scena cambia

        if (!_panelShown)
        {
            _typewriter.TweenInterval(IllustrationOnlySeconds);
            _typewriter.TweenProperty(_storyPanel, "modulate:a", 1f, PanelFadeSeconds);
            _typewriter.TweenCallback(Callable.From(() => _panelShown = true));
        }

        float duration = _storyLabel.GetParsedText().Length * SecondsPerCharacter; // senza i tag BBCode
        _typewriter.TweenProperty(_storyLabel, "visible_ratio", 1f, duration);
        _typewriter.Finished += ShowAll;
    }

    /// <summary>Mostra subito tutto: riquadro, testo completo e invito a continuare.</summary>
    private void ShowAll()
    {
        _panelShown = true;
        SetAlpha(_storyPanel, 1f);
        _storyLabel.VisibleRatio = 1f;
        SetAlpha(_continuePrompt, 1f);
    }

    private static void SetAlpha(CanvasItem item, float alpha) =>
        item.Modulate = item.Modulate with { A = alpha };

    public override void _UnhandledInput(InputEvent @event)
    {
        bool pressed = (@event is InputEventKey key && key.Pressed && !key.Echo)
                    || (@event is InputEventMouseButton mouse && mouse.Pressed);
        if (!pressed) return;

        GetViewport().SetInputAsHandled();

        if (IsTyping)
        {
            // Primo input: salta l'attesa e completa subito il testo
            _typewriter.Kill();
            ShowAll();
        }
        else
        {
            GetTree().ChangeSceneToFile(NextScenePath);
        }
    }
}
