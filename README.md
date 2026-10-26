# UniverseCozySim

Gestionale "cozy" sulla Luna, in stile Stardew Valley, in Godot 4.7 (C#/.NET 8).
Visione, lore e piano di sviluppo: [docs/GDD.md](docs/GDD.md) (English: [docs/GDD.en.md](docs/GDD.en.md)).

## Struttura

```
res://
├── assets/             Grafica, audio, font (icons/, images/, sprites/, audio/…)
├── docs/               Documento di progetto (GDD.md, GDD.en.md)
├── localization/       translations.csv: TUTTI i testi visibili al giocatore (chiavi IT/EN)
├── scenes/
│   ├── intro/          Schermata introduttiva (scena di avvio)
│   ├── main/           Scena di gioco
│   └── ui/             Pezzi di interfaccia riutilizzabili (HUD, menu…)
└── scripts/
    ├── core/           Logica di gioco e manager globali (namespace UniverseCozySim.Core)
    └── ui/             Script delle interfacce (namespace UniverseCozySim.UI)
```

Una scena e il suo script vanno in cartelle parallele (`scenes/ui/hud.tscn` ↔ `scripts/ui/HUDController.cs`).
Quando un sistema cresce (es. coltivazioni) gli si dà una sottocartella in entrambe: `scenes/farming/`, `scripts/farming/`.

## Flusso

1. `scenes/intro/intro_scene.tscn` è la scena di avvio: illustrazione, testo della storia, scelta lingua.
2. Al tasto/click si passa a `scenes/main/main_scene.tscn`.
3. `MainScene` azzera le risorse e avvia l'orologio.

## Manager globali (Autoload)

Registrati in *Project Settings → Globals → Autoload*, esistono per tutta la partita:

| Nome               | Ruolo                                                         |
|--------------------|---------------------------------------------------------------|
| `TimeManager`      | Orologio di gioco: 1 ora ogni `SecondsPerGameHour` secondi     |
| `StationResources` | Acqua e ossigeno; consumo orario di base agganciato all'orologio |

L'ordine conta: `TimeManager` va elencato prima di `StationResources`.

## Convenzioni

- **Testi**: mai scritti nel codice. Si aggiunge una chiave in `localization/translations.csv`
  e si usa `Tr("CHIAVE")`, oppure si mette la chiave come testo di Label/Button (vengono tradotti in automatico).
- **Eventi**: chi si iscrive a un evento di un manager (`+=`) si disiscrive in `_ExitTree` (`-=`),
  perché i manager sopravvivono ai cambi di scena.
- **Riferimenti ai nodi**: nomi unici (`%NomeNodo`) invece di percorsi fissi.
- **Bilanciamento**: i numeri regolabili sono proprietà `[Export]` con valore di default nel codice.
