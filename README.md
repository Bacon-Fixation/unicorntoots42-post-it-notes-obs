# Post-It Notes Update

I added a couple of things to help narrow down the issue. I would not recommend testing the script during a scheduled stream, as the changes that were made could possibly throw an error on OBS (tested using OBS v31.0.3)

## Changes Made

> - added a 10 second cooldown to the script - (noticed on stream when you ran Zaygnors, they appeared all at once, and when you ran my revision, they seemed to appear sequentially but at an insane speed, sooo it's possibly being ran more than once per button press)
> - added a chat message when the cooldown is hit - To test the theory mentioned above
> - added OBS Log Entries in an attempt to see where in the loop it is failing - logs which function is running (next or random), along with the index number for the source that got rolled, and the value that was set for the source state that got picked
> - removed all comments - not sure the version or type of C# interpreter Streamer Bot is using, and removed to rule them out as the issue

Much Love
-Bacon
