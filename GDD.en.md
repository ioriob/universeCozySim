# UniverseCozySim — Game Design Document

> Working title. Version 0.2 — October 2026. Italian version: [GDD.md](GDD.md).

## 1. In one sentence

A farming and community life game in the spirit of Stardew Valley, set on the Moon: bring an old domed greenhouse next to the Apollo 11 site back to life, get to know your neighbours, and revive a lunar village everyone had forgotten, with the Earth always hanging in the sky.

## 2. Pillars

Every new idea is checked against these four points. If it breaks one, it gets cut or changed.

1. **Cozy first.** No death, no game over, no punishing timers. A mistake costs a harvest or a day, never the whole game.
2. **Every drop counts.** Water, air and energy are the heart of the economy. Scarcity should never make the player feel threatened, but solving it should make them feel clever.
3. **Down-to-earth science fiction.** No aliens, no teleporting, no magic. Low gravity, regolith, water recycling, the long lunar night: realism is what makes the world believable and welcoming.
4. **A small, real community.** Few characters, each with a story that unfolds over time. The big politics of the solar system only arrive over the radio.

## 3. Setting and lore

### The world

The year is 2291. Humanity is scattered across the solar system.

- **The Central Planets** (Earth, Mars and the big orbital cities) are rich, crowded and hectic. They are home to the corporations, the megacities and the spaceports.
- **The Outer Colonies** are the most distant outposts: mines in the asteroid belt, ice depots, transit stations.

There is constant tension between the two worlds: water tariffs, mining contracts, protests, negotiations. **In the game it stays in the background.** You hear it on the news, in the chatter at the canteen, in the goods that arrive or don't. It never becomes a threat to the player.

The Moon sits in between. It used to be the gateway to the solar system; today the big ships leave from orbital stations, and the Moon has become a kind of province: too close to Earth to be adventurous, too far to be comfortable.

### Tranquillity

In the Sea of Tranquillity, a few hundred metres from where Apollo 11 landed in 1969, lies **Tranquillity**: a small lunar village.

A hundred years ago it was a model farming colony, built to prove that real food could be grown on the Moon. The greenhouses were numbered in honour of the landing, and the first one was called **Module 069**. Then the big orbital farms arrived, cheaper and more efficient, and the colony emptied out.

Today about thirty people live in Tranquillity. Those who stayed did so out of love, stubbornness, or because they had nowhere else to go. The village is laid out like this:

- **The Domes**: geodesic greenhouses on the surface, almost all of them dark. The oldest is **Module 069, "Ada's Greenhouse"**, the player's "farm".
- **The Village**: living quarters dug under the regolith for radiation shielding, with the square, the dry fountain, the canteen and the general store.
- **The Tubes**: ancient lava tubes beneath the Sea, discovered by the first settlers and used for mining. The deeper you go, the darker they get and the more surprises they hold. They are the game's "mine".
- **The Enclosure**: the Apollo 11 historic site, protected by a fence. The descent stage and the flag are still there. It is the village's pride, even if tourists hardly come any more.
- **The Pad**: the landing pad, where the shuttle *Stork* arrives every cycle.

And above it all there is **the Earth**. From the Sea of Tranquillity it never sets: it stays fixed in the same spot in the sky, and only its phase changes.

### The player

For years the player has worked in a gigantic vertical farm in an Earth megacity, growing algae for a corporation in twelve-hour shifts, in a place where nobody knows their name.

One day a message arrives from the Moon: **their grandmother Ada has died and left them her greenhouse in Tranquillity.** With the message comes a voice recording: *"Whenever you've had enough of all that concrete, come and see what grows up here. The Earth looks beautiful from here."*

The player quits, boards the shuttle, and after a three-day trip lands on the Pad.

### The gentle mystery: the Seedbank

When the colony was built, the **Seedbank** was set up deep in the Tubes: a bank of seeds and small ecosystems, meant to one day supply distant colonies. When the colony shut down, the project was forgotten. Ada had found it again and spent her last years secretly bringing it back to life.

The main thread of the game is recovering her work: scattered notes, rare seeds, the glowing moss that grows in the Tubes (an organism engineered by the Seedbank, not alien). In the end Tranquillity can once again become **the garden of the Moon**, the place that sends seeds to the Outer Colonies and the reason the village comes back to life.

### Tranquillity's culture

Small details that make the place recognisable:

- **The greeting**: *"May your air be light."* The reply is *"And the Earth always in sight."*
- **Water is never wasted.** It arrives as blocks of ice from the craters at the lunar poles, on board the *Stork*. Leaving a tap running is the worst faux pas imaginable, and offering a glass of water is a gesture of friendship.
- **Gifts are plants.** A potted seedling is the most precious gift you can give on the Moon.
- **Earth Greeting.** When the Earth is "full", everyone goes up under the domes to watch it together.
- **The Fountain Festival.** Once a year the fountain in the square is switched on and everyone contributes a little of their own water. Turning it on for good is one of the game's goals.
- **Time is counted in sols** (standard 24-hour days, called that by tradition), because a real lunar day lasts almost a month.

## 4. Main characters

| Character | Role | In short |
|---|---|---|
| **Ada Ferraris** | The grandmother (absent) | Speaks through letters, recordings and notes in the greenhouse. She is the voice of the tutorial and of the main story. |
| **Ines Okafor** | Mayor and administrator | Practical, tired, buried in paperwork. Sceptical of the player at first, she becomes their greatest ally. |
| **Tobia Rank** | Former Tubes miner | Grumpy, knows the tunnels better than anyone. Owes Ada a debt he doesn't want to talk about. |
| **Lula and Kenji Moreau** | Run the canteen | A cheerful couple who cook with everything the player grows. They are the gateway to recipes. |
| **Mira Solano** | Pilot of the *Stork* | Shuttles between the lunar poles, Tranquillity and Earth. Brings ice, goods, news and requests. She connects the game to the rest of the solar system. |
| **Sasha** | Radio operator, 16 | Listens to every channel and reports the news from the Central Planets. Dreams of leaving for the Outer Colonies. |
| **Doc Ravel** | Doctor and keeper of the Enclosure | Old and curious, knows the history of Apollo 11 by heart and tells it to anyone who'll listen. He was Ada's best friend and keeps some of her secrets. |
| **Pistachio** | Maintenance drone | The player's companion (the equivalent of the pet). Old, dented and affectionate, and talks in beeps. |

## 5. Gameplay loop

### The day (one sol)

1. **06:00** — Wake up in the greenhouse to Sasha's radio bulletin (solar activity, prices, news from Earth).
2. Tend the plants: sowing, watering and harvesting. Watering uses the village's water.
3. Choose how to spend the rest of the day: explore the Tubes, sift the craters, do odd jobs, talk to the residents or build.
4. **Evening** — Sell at the store terminal, cook, go to the canteen.
5. **02:00** — If the player isn't in bed yet, they pass out from exhaustion. Pistachio carries them home, and the next morning there's a small energy penalty, nothing more.

### Lunar day and lunar night

A real lunar day lasts about 28 sols: **14 sols of light and 14 sols of darkness.** This is the underlying rhythm of the game, a kind of "long week":

| Phase | Sols | Gameplay effect |
|---|---|---|
| **Lunar day** | 1–14 | Full sun on the domes: plenty of solar energy, plants grow faster. Time to farm and work on the surface. |
| **Lunar night** | 15–28 | Darkness and cold. The grow lamps draw on battery power and the surface is inhospitable. Time for the Tubes, crafting, the canteen and relationships. In the sky, the Earth shines full. |

### Seasons: the four cycles

A year is made of **4 cycles of 28 sols**. Each cycle is one full lunar day, and the *Stork* arrives at every change of cycle. Each cycle has different crops, events and festivals:

| Cycle | Theme | Main event |
|---|---|---|
| **Cycle of the Seed** | A fresh start, new seeds from Earth | Arrival of the year's first *Stork* |
| **Cycle of the Sprout** | Growth, the greenhouse expands | Fountain Festival |
| **Cycle of the Harvest** | Abundance, trade | Harvest Fair, with travelling merchants |
| **Cycle of Rest** | Reflection, the deepest Tubes | Apollo 11 anniversary, celebrated at the Enclosure |

### Resources

| Resource | Where it comes from | What it's for |
|---|---|---|
| **Water** | Ice from the poles (on the *Stork*), recycler, hydrated minerals from the Tubes | Watering, cooking, trade |
| **Oxygen** | Greenhouse plants, extraction from regolith | Grows with the greenhouse. If it gets too low, the player tires faster (no death) |
| **Energy** | Solar panels (by day), batteries (by night) | Grow lamps, machines |
| **Credits** | Selling at the terminal, jobs | Seeds, tools, upgrades |
| **Standing** | Helping the residents | Unlocks dialogue, recipes and areas |

### Activities (what replaces what compared to Stardew)

| Stardew Valley | UniverseCozySim |
|---|---|
| Farm | **Module 069**: hydroponic tanks, lamps, dwarf fruit trees, mushrooms in the Tubes |
| Mine | **The Tubes**: levels of lava tubes with minerals, old machinery, Ada's notes and the Seedbank |
| Fishing | **Sifting**: in the craters around the village you sift regolith for meteorites, rare minerals and relics of the old colony (timing minigame) |
| Animals | **Living crops**: algae, compost worms, bees in low gravity (later) |
| Crafting | **Recycling workshop**: everything can be taken apart and rebuilt |
| Community Center | **The Dome Register**: relight the dark domes by bringing the required materials |
| Relationships | Gifts, dialogue, heart events, with seedlings as the most appreciated gift |

## 6. Tone and naming rules

- **Inspired, not copied.** The kind of science fiction is that of *The Expanse*: realistic, made of gravity, water and distances. But all proper names are original. No names, factions, ships, terms or expressions from the series.
- Real places (the Moon, the Sea of Tranquillity, Apollo 11, the lunar poles) are fine and must be treated with respect. The Enclosure is a historic site, not a playground.
- The tone is warm, wry and just melancholy enough. Conflicts are personal and small, like a water bill or an old grudge between neighbours, never epic.
- Radio bulletins can talk about distant crises, but always with a human angle and never with an ultimatum for the player.

## 7. Art and audio direction

- **Reference**: the intro image (`assets/images/intro_moonbase.jpg`). Pixel art, blue-grey lunar surface, geodesic domes with green plants inside, orange beacon lights, a large Earth in the sky.
- **In-game art**: top-down pixel art, 16×16 or 32×32. The contrast between the warm green inside the domes and the cold grey of the regolith is the game's signature look. The Tubes are blue and violet, lit by the glowing moss.
- **Interface**: retro terminals with green phosphor screens, slightly battered.
- **Music**: acoustic and lo-fi with soft synths. One theme for the lunar day and one for the lunar night, with variations per cycle.
- **Sound**: the hum of the lamps, dripping water, Pistachio's beeps. Outside, only the breathing inside the helmet: there is no sound in a vacuum.

## 8. Scope: first playable version (vertical slice)

The goal is **a complete, playable loop of 3 sols**, with no extra content.

- [x] Intro with illustration, text and language choice
- [ ] Top-down player movement inside Module 069
- [ ] Day/night loop with the bed (sleeping moves to the next sol, passing out at 02:00)
- [ ] 6 hydroponic tanks: sow, water (uses water) and harvest
- [ ] 3 crops: lettuce (2 sols), potato (4 sols), dwarf tomato (6 sols, regrows)
- [ ] Plants produce oxygen; the HUD shows water, oxygen, time and credits
- [ ] Terminal for selling produce and buying seeds
- [ ] 1 character with dialogue (Ines) and Ada's first letter
- [ ] Save and load
- [ ] Italian and English text

### Later phases

1. **Community**: canteen, 4 characters, gifts, Standing
2. **The Tubes**: first 10 levels, minerals, full water cycle
3. **Lunar day and night, cycles**: solar energy and batteries, arrival of the *Stork*
4. **Dome Register** and the Seedbank story
5. **Sifting**, workshop, events and festivals

## 9. Technical notes

- **Day length**: currently 1 in-game hour lasts 2.5 s, so a sol lasts 60 s. For a Stardew-like pace (12–15 real minutes per day) you need about 40 s per in-game hour. Tune it with `TimeManager.SecondsPerGameHour`.
- **Lunar phase**: derived from the day, `((CurrentDay - 1) % 28) < 14` → lunar day. No separate system needed.
- **Game data** as Godot `Resource`s (`.tres` files): `CropData` (name, growth days, water per day, oxygen produced, price), `ItemData`, `NpcData`. Balancing without touching code.
- **New folders** following the README: `scripts/farming/`, `scripts/player/`, `scripts/save/`, `data/crops/`.
- **Daily events**: plants grow on `TimeManager.OnGameDayPassed`, so the day really only advances by sleeping.
- **Saving**: a JSON file in `user://` with the state of resources, time, greenhouse, inventory and relationships.

## 10. Glossary

| Term (EN / IT) | Meaning |
|---|---|
| **Sol** / Sol | In-game day (24 hours) |
| **Lunar day / night** / Giorno / notte lunare | The two halves of a cycle: 14 sols of light, 14 of darkness |
| **Cycle** / Ciclo | In-game season (28 sols, one full lunar day) |
| **Tranquillity** / Tranquillità | The lunar village where the game takes place |
| **Domes** / Cupole | The geodesic greenhouses on the surface |
| **Module 069** / Modulo 069 | Ada's greenhouse, the player's "farm" |
| **Tubes** / Tubi | The lava tubes under the village, the "mine" |
| **Enclosure** / Recinto | The Apollo 11 historic site |
| **Pad** / Rampa | The landing pad |
| **Seedbank** / Semenzaio | The forgotten seed bank, the story's main thread |
| **Stork** / Cicogna | The shuttle that arrives every cycle |
| **Sifting** / Setaccio | Searching the craters (the "fishing") |
| **Standing** / Stima | Reputation with the residents |
