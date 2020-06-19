# mStats
SkaterXL Download Statistics Library

# What is this?

Barebones asf right now...

I plan to mimic something like [bStats](https://bstats.org) into this but for now it's just a download counter :)

# How do I get a Mod ID?

Contact me on Discord @macs#0420, you'll find me easily and active in the SXL Modding Discord. If you have released a mod already I'll gladly give you an ID to implement!

# Why

I'm working on a site [SXLServers.com](https://sxlservers.com) and I thought this would be a cool addition as a developer tool. 

You will be able to find live download counts here: https://mstats.sxlservers.com

# How

Add `mStats.dll` from the Releases tab as a Reference in your project (Make sure to copy locally and package with your mod!)

In your `onToggle` function or wherever call something like this:


```
int modId = 1234;
var modStats = new ModStats(modId);
```

Yeah, that's pretty much it :)

# As a developer, it is up to you to tell the user that you are uploading stats to the server. It currently only sends a Unique Identifier and no other information so it's completely unobtrusive! However you should still tell users that it's a feature and give the ability to turn it off prior to starting the game!
