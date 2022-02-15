﻿using UnityEngine;

namespace Waterfall
{
  [KSPAddon(KSPAddon.Startup.EveryScene, false)]
  public class Waterfall : MonoBehaviour
  {
    public static Waterfall Instance { get; private set; }

    protected void Awake()
    {
      Instance = this;
    }

    protected void Start()
    {
      WaterfallAssets.Load();
    }
  }

  /// <summary>
  ///   Static class to hold settings and configuration
  /// </summary>
  public static class Settings
  {
    /// Settings go here
    public static bool ShowEffectEditor = false;

    public static bool DebugModules   = false;
    public static bool DebugSettings  = false;
    public static bool DebugEffects   = false;
    public static bool DebugModifiers = false;
    public static bool DebugMode      = false;
    public static bool DebugUIMode    = false;

    public static float AtmosphereDensityExponent = 0.5128f;
    public static float MinimumEffectIntensity    = 0.005f;
    public static float MinimumLightIntensity     = 0.05f;
    public static bool  EnableLights              = true;
    public static bool  EnableDistortion          = true;
    public static bool  EnableLegacyBlendModes    = false;

    private static bool _loadedOnce = false;

    /// <summary>
    ///   Load data from configuration
    /// </summary>
    public static void Load()
    {
      if (_loadedOnce) return;

      _loadedOnce = true;
      var settingsNode = GameDatabase.Instance.GetConfigNode("Waterfall/WaterfallSettings/WATERFALL_SETTINGS");

      Utils.Log("[Settings]: Started loading", LogType.Settings);
      if (settingsNode != null)
      {
        Utils.Log("[Settings]: Using specified settings", LogType.Settings);
        // Setting parsing goes here

        settingsNode.TryGetValue("ShowEffectEditor",          ref ShowEffectEditor);
        settingsNode.TryGetValue("DebugModules",              ref DebugModules);
        settingsNode.TryGetValue("DebugSettings",             ref DebugSettings);
        settingsNode.TryGetValue("DebugEffects",              ref DebugEffects);
        settingsNode.TryGetValue("DebugModifiers",            ref DebugModifiers);
        settingsNode.TryGetValue("DebugMode",                 ref DebugMode);
        settingsNode.TryGetValue("DebugUIMode",               ref DebugUIMode);
        settingsNode.TryGetValue("AtmosphereDensityExponent", ref AtmosphereDensityExponent);
        settingsNode.TryGetValue("MinimumEffectIntensity",    ref MinimumEffectIntensity);
        settingsNode.TryGetValue("MinimumLightIntensity",     ref MinimumLightIntensity);
        settingsNode.TryGetValue("EnableLights",              ref EnableLights);
        settingsNode.TryGetValue("EnableDistortion",          ref EnableDistortion);
        settingsNode.TryGetValue("EnableLegacyBlendModes",    ref EnableLegacyBlendModes);
      }
      else
      {
        Utils.Log("[Settings]: Couldn't find settings file, using defaults", LogType.Settings);
      }

      Utils.Log("[Settings]: Finished loading", LogType.Settings);
    }
  }
}