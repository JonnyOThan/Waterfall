using System;
using System.Collections.Generic;
using UnityEngine;

namespace Waterfall
{
  public class EffectRotationIntegrator : EffectIntegrator_Vector3
  {
    public EffectRotationIntegrator(WaterfallEffect effect, EffectRotationModifier mod) : base(effect, mod)
    {
      for (int i = xforms.Count; i-- > 0;)
        initialValues[i] = xforms[i].localEulerAngles;
    }

    protected override void Apply()
    {
      for (int i = xforms.Count; i-- > 0;)
        xforms[i].localEulerAngles = workingValues[i];
    }
  }
}
