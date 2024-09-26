using System;
using System.Collections.Generic;
using UnityEngine;

namespace Waterfall
{
  public class EffectPositionIntegrator : EffectIntegrator_Vector3
  {

    public EffectPositionIntegrator(WaterfallEffect effect, EffectPositionModifier posMod) : base(effect, posMod)
    {
      for (int i = xforms.Count; i-- > 0;)
        initialValues[i] = xforms[i].localPosition;
    }

    protected override void Apply()
    {
      for (int i = xforms.Count; i-- > 0;)
        xforms[i].localPosition = workingValues[i];
    }
  }
}
