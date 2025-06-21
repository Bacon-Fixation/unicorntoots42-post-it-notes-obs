# Post-It Notes Update v3

As requested a random post-it note is added per redemption to the avatar

## Changes Made

> - added a 10 second cooldown to the script - (noticed on stream when you ran Zaygnors, they appeared all at once, and when you ran my revision, they seemed to appear sequentially but at an insane speed, sooo it's possibly being ran more than once per button press)
> - added a chat message when the cooldown is hit - To test the theory mentioned above
> - added OBS Log Entries in an attempt to see where in the loop it is failing - logs which function is running (next or random), along with the index number for the source that got rolled, and the value that was set for the source state that got picked
> - Keeps the redeemed post-its visible and adds another until the post-it note pool is emptied and reset
> - Added back Credits for the original creator of the script (confirmed the version of the C# interpreter does handle them properly)
> - Added ResetAll() so the avatar can be cleared off and start the cycle again

Much Love
-Bacon
