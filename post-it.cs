using System;
using System.Collections.Generic;

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
            CPH.SendMessage($"@unicorntoots42, slow down! Wait {cooldownSeconds - (int)elapsed.TotalSeconds}s.");
            return false;
        }
        CPH.SetGlobalVar(cooldownVar, now, false);
        List<KeyValuePair<string, string>> elementList = new List<KeyValuePair<string, string>>
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
        bool useRandom = true;
        if (useRandom)
        {
            showRandom(elementList);
        }
        else
        {
            showNext(elementList);
        }
        return true;
    }
    public void hideAll(List<KeyValuePair<string, string>> elementList)
    {
        foreach (var item in elementList)
        {
            CPH.ObsHideSource(item.Key, item.Value);
        }
    }
    public void showRandom(List<KeyValuePair<string, string>> elementList)
    {
        hideAll(elementList);
        int toShow = rnd.Next(0, elementList.Count);
        CPH.SetGlobalVar("ElementCycleIndex", toShow, false);
        CPH.ObsShowSource(elementList[toShow].Key, elementList[toShow].Value);
        CPH.LogInfo($"[PostItNote] Showing '{elementList[toShow].Value}' from scene '{elementList[toShow].Key}'");
    }
    public void showNext(List<KeyValuePair<string, string>> elementList)
    {
        hideAll(elementList);
        int toShow = CPH.GetGlobalVar<int>("ElementCycleIndex", false);
        toShow += 1;
        if (toShow >= elementList.Count)
        {
            toShow = 0;
        }
        CPH.SetGlobalVar("ElementCycleIndex", toShow, false);
        CPH.ObsShowSource(elementList[toShow].Key, elementList[toShow].Value);
        CPH.LogInfo($"[PostItNote] Showing '{elementList[toShow].Value}' from scene '{elementList[toShow].Key}'");
    }
}