using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringAudioVisualizer : IAudioVisualizationBehaviour 
{
    public void VisualizePoint(SpectralFluxInfo point)
    {
        Debug.Log(point.ToString());
    }

    public void VisualizePoint(SpectralFluxInfo point, GameObject target)
    {
        Debug.Log(target.ToString() + " - " + point.ToString());
    }

    public void SpawnMonster(SpectralFluxInfo point, ObjectPooler objectPooler, string tag)
    {
        Debug.Log(tag + " - " + point.ToString());
    }
}
