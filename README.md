# PLEASE DON'T USE THIS ANYMORE!!
Use my new and (very, very, **very**) improved [audiosurf-rpc](github.com/rubberduckshobe/audiosurf-rpc) instead because that actually works properly and is more convenient (doesn't choke on japanese, korean, chinese or specific songs, has proper capitalization, runs and starts with/inside the game)
Thank you.

# AudiosurfRichPresence
## What does it do?
It shows if you're on the character select screen, what song you're playing and the score you got on Discord using Discord Rich Presence.
## How does it work?
It uses [Audiosurf's WM_COPYDATA messages](https://web.archive.org/web/20190911112730/http://www.audio-surf.com/forum/index.php/topic,2885.0.html) via SendMessage to register itself as the listener window for Audiosurf's reports and then displays the data from those reports as the Discord Rich Presence.
