using System;
using System.Collections.Generic;
using UnityEngine;

namespace Waterfall
{
  public class EffectLightColorIntegrator : EffectIntegrator_Color
  {
    public string                         colorName;

    private readonly Light[]     l;

    public EffectLightColorIntegrator(WaterfallEffect effect, EffectLightColorModifier floatMod) : base(effect, floatMod)
    {
      // light-color specific
      colorName        = floatMod.colorName;
      l = new Light[xforms.Count];

      for (int i = xforms.Count; i-- > 0;)
      {
        l[i] = xforms[i].GetComponent<Light>();
        initialValues[i] = l[i].color;
      }
    }

    protected override void Apply()
    {
      for (int i = l.Length; i-- > 0;)
        l[i].color = workingValues[i];
    }
  }
}
