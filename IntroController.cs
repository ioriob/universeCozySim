using Godot;
using System;
using System.Threading.Tasks;

namespace SpaceSim.Core;

public partial class IntroController : Control
{
    private RichTextLabel _storyLabel;
    private Label _continuePrompt;
    private Button _btnItalian;
    private Button _btnEnglish;

    [Export] public string NextScenePath { get; set; } = "res://main_scene.tscn";

    private bool _textFinished = false;
    private bool _introStarted = false;
    private string _currentFullText = "";

    // Testi in Italiano
    private const string TitleIT = "LUNA - TRANQUILLITY BASE\nSito Storico Apollo 11";
    private const string BodyIT = 
        "Mentre la tensione geopolitica tra i Pianeti Centrali e le Colonie Esterne è al punto di rottura, " +
        "ti è stata affidata la gestione del 'Modulo 069': un'antica biosfera sotterranea a circuito chiuso costruita nel 1969.\n\n" +
        "Le riserve di acqua e ossigeno sono limitate.\n" +
        "La sopravvivenza della struttura dipende solo da te.\n\n" +
        "Stabilizza l'habitat, coltiva le risorse e prepara il modulo all'espansione.";
    private const string PromptIT = "Premi un tasto o clicca per continuare...";

    // Testi in Inglese
    private const string TitleEN = "MOON - TRANQUILLITY BASE\nApollo 11 Historic Site";
    private const string BodyEN = 
        "As geopolitical tensions between the Central Planets and Outer Colonies reach a breaking point, " +
        "you have been entrusted with managing 'Module 069': an ancient closed-loop underground biosphere built in 1969.\n\n" +
        "Water and oxygen reserves are limited.\n" +
        "The survival of the facility depends entirely on you.\n\n" +
        "Stabilize the habitat, farm resources, and prepare the module for expansion.";
    private const string PromptEN = "Press any key or click to continue...";

    public override void _Ready()
    {
        _storyLabel = GetNodeOrNull<RichTextLabel>("%StoryLabel");
        _continuePrompt = GetNodeOrNull<Label>("%ContinuePrompt");
        _btnItalian = GetNodeOrNull<Button>("%BtnItalian");
        _btnEnglish = GetNodeOrNull<Button>("%BtnEnglish");

        if (_continuePrompt != null)
        {
            _continuePrompt.Visible = false;
        }

        if (_btnItalian != null)
            _btnItalian.Pressed += () => SetLanguage("it");

        if (_btnEnglish != null)
            _btnEnglish.Pressed += () => SetLanguage("en");

        // Lingua di default: Italiano
        SetLanguage("it");
    }

    private void SetLanguage(string lang)
    {
        if (lang == "en")
        {
            TranslationServer.SetLocale("en");
            _currentFullText = $"{TitleEN}\n\n{BodyEN}";
            if (_continuePrompt != null) _continuePrompt.Text = PromptEN;
        }
        else
        {
            TranslationServer.SetLocale("it");
            _currentFullText = $"{TitleIT}\n\n{BodyIT}";
            if (_continuePrompt != null) _continuePrompt.Text = PromptIT;
        }

        if (_continuePrompt != null) _continuePrompt.Visible = false;
        _introStarted = true;
        _ = DisplayTypewriterText(_currentFullText);
    }

    private async Task DisplayTypewriterText(string fullText)
    {
        _textFinished = false;
        if (_storyLabel == null) return;

        _storyLabel.Text = "";

        foreach (char c in fullText)
        {
            // Se l'utente cambia lingua a metà digitazione o salta
            if (_textFinished)
            {
                _storyLabel.Text = fullText;
                break;
            }

            _storyLabel.Text += c;
            await Task.Delay(25);
        }

        _textFinished = true;

        if (_continuePrompt != null)
        {
            _continuePrompt.Visible = true;
        }
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        if (!_introStarted) return;

        if ((@event is InputEventKey keyEvent && keyEvent.Pressed && !keyEvent.Echo) ||
            (@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed))
        {
            Proceed();
        }
    }

    private void Proceed()
    {
        if (!_textFinished)
        {
            // Se sta ancora digitando, completa subito il testo
            _textFinished = true;
            if (_storyLabel != null) _storyLabel.Text = _currentFullText;
            if (_continuePrompt != null) _continuePrompt.Visible = true;
        }
        else
        {
            // Passa alla scena di gioco principale
            GetTree().ChangeSceneToFile(NextScenePath);
        }
    }
}