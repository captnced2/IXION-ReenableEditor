using System;
using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using BulwarkStudios.GameSystems.Ui;
using UnityEngine;

namespace ReenableEditor;

[BepInPlugin(Guid, Name, Version)]
[BepInProcess("IXION.exe")]
[BepInDependency("captnced.IMHelper")]
public class Plugin : BasePlugin
{
    private const string Guid = "captnced.ReenableEditor";
    private const string Name = "ReenableEditor";
    private const string Version = "1.0.0";
    internal new static ManualLogSource Log;

    public override void Load()
    {
        Log = base.Log;
        IMHelper.GameStateHelper.addSceneChangedToInGameListener(inGameListener);
        Log.LogInfo("Loaded \"" + Name + "\" version " + Version + "!");
    }

    private static void inGameListener()
    {
        var editorButton = GameObject.Find("Canvas/1920x1080/Top/Settings Button/Editor");
        editorButton.gameObject.SetActive(true);
        editorButton.GetComponent<UiButton>().add_OnTriggered(new Action(delegate { buttonTriggered(); }));
        Log.LogInfo("Enabled Editor Button");
    }

    private static void buttonTriggered()
    {
        GameObject.Find("Canvas/WindowManagerCenter/UI Window Player Settings/Scroll View/Viewport/Content").gameObject.SetActive(true);
    }
}
