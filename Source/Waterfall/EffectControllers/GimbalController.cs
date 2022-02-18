﻿using System.Collections.Generic;
using System.ComponentModel;

namespace Waterfall
{
  [DisplayName("Gimbal")]
  public class GimbalController : WaterfallController
  {
    public  string       axis            = "x";
    private ModuleGimbal gimbalController;

    public GimbalController() : base() { }
    public GimbalController(ConfigNode node) : base(node)
    {
      node.TryGetValue(nameof(axis), ref axis);
    }

    public override ConfigNode Save()
    {
      var c = base.Save();
      c.AddValue(nameof(axis), axis);
      return c;
    }

    public override void Initialize(ModuleWaterfallFX host)
    {
      base.Initialize(host);

      gimbalController = host.part.FindModuleImplementing<ModuleGimbal>();

      if (gimbalController == null)
        Utils.LogError("[GimbalController] Could not find gimbal controller on Initialize");
    }

    public override void Update()
    {
      if (gimbalController == null)
        Utils.LogWarning("[GimbalController] Gimbal controller not assigned");

      if (gimbalController == null) value = 0;
      else if (overridden) value = overrideValue;
      else if (axis == "x") value = gimbalController.actuationLocal.x / gimbalController.gimbalRangeXP;
      else if (axis == "y") value = gimbalController.actuationLocal.y / gimbalController.gimbalRangeYP;
      else if (axis == "z") value = gimbalController.actuationLocal.z;
    }
  }
}
