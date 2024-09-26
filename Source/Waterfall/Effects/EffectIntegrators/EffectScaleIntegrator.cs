using System;
using System.Collections.Generic;
using UnityEngine;

namespace Waterfall
{
  public class EffectScaleIntegrator : EffectIntegrator_Vector3
  { 
    public EffectScaleIntegrator(WaterfallEffect effect, EffectScaleModifier mod) : base(effect, mod)
    {
      for(int i = xforms.Count; i-- > 0;)
        initialValues[i] = xforms[i].localScale;
    }

    protected override void Apply()
    {
      for (int i = xforms.Count; i-- > 0;)
        xforms[i].localScale = workingValues[i];
    }
  }
}
