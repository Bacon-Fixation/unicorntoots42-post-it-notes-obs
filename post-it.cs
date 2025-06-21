/**
* Original Script by Zaygnor: 2025-04-01 | Rewritten by Bacon Fixation: 2025-6-21
*/

using System;
using System.Collections.Generic;
using System.Linq;

public class CPHInline
{
    private static Random rnd = new Random();

    public bool Execute()
    {
        int cooldownSeconds = 10;
        string cooldownVar = $"PostItNoteCooldown";

        DateTime lastRun = CPH.GetGlobalVar<DateTime>(cooldownVar, false);
        DateTime now = DateTime.Now;

        TimeSpan elapsed = now - lastRun;

        if (elapsed.TotalSeconds < cooldownSeconds)
        {
            CPH.SendMessage($"Slow down! Wait {cooldownSeconds - (int)elapsed.TotalSeconds}s.");
            return false;
        }
        CPH.SetGlobalVar(cooldownVar, now, false);

        List<KeyValuePair<string, string>> allNotes = new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>("PS5", "Need Money"),
            new KeyValuePair<string, string>("PS5", "Stinky"),
            new KeyValuePair<string, string>("PS5", "Dumb B"),
            new KeyValuePair<string, string>("PS5", "Horny"),
            new KeyValuePair<string, string>("PS5", "Dum"),
            new KeyValuePair<string, string>("PS5", "Waifu"),
            new KeyValuePair<string, string>("PS5", "Mommy"),
            new KeyValuePair<string, string>("PS5", "UwU Post It"),
        };

        List<string> activeValues = CPH.GetGlobalVar<List<string>>("ActivePostItNotes", false) ?? new List<string>();


        var availableNotes = allNotes.Where(n => !activeValues.Contains(n.Value)).ToList();

        if (availableNotes.Count == 0)
        {
            CPH.SendMessage("All post-it notes are already showing!");
            return false;
        }

        var noteToShow = availableNotes[rnd.Next(availableNotes.Count)];

        CPH.ObsShowSource(noteToShow.Key, noteToShow.Value);
        CPH.LogInfo($"[PostItNote] Showing '{noteToShow.Value}' from scene '{noteToShow.Key}'");

        activeValues.Add(noteToShow.Value);
        CPH.SetGlobalVar("ActivePostItNotes", activeValues, false);

        return true;
    }

    public void ResetAll()
    {
        List<KeyValuePair<string, string>> allNotes = new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>("PS5", "Need Money"),
            new KeyValuePair<string, string>("PS5", "Stinky"),
            new KeyValuePair<string, string>("PS5", "Dumb B"),
            new KeyValuePair<string, string>("PS5", "Horny"),
            new KeyValuePair<string, string>("PS5", "Dum"),
            new KeyValuePair<string, string>("PS5", "Waifu"),
            new KeyValuePair<string, string>("PS5", "Mommy"),
            new KeyValuePair<string, string>("PS5", "UwU Post It"),
        };

        foreach (var note in allNotes)
        {
            CPH.ObsHideSource(note.Key, note.Value);
        }

        CPH.SetGlobalVar("ActivePostItNotes", new List<string>(), false);
        CPH.SendMessage("All post-it notes have been reset!");
    }
}
