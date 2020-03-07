using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PeakAudioVisualizerBehaviour : IAudioVisualizationBehaviour
{
    private Animator _animator;

    private bool _lastWasPeak;

    int count = 0;

    public void VisualizePoint([NotNull] SpectralFluxInfo point)
    {
    }

    public void VisualizePoint([NotNull] SpectralFluxInfo point, GameObject target)
    {
        if (_animator == null) _animator = target.GetComponent<Animator>();
        if (point.IsPeak)
        {
            //target.SetActive(!target.activeSelf);
            //Spawn Object instead
            _animator.SetTrigger("Flash");
        }
    }

    public void SpawnMonster([NotNull] SpectralFluxInfo point, ObjectPooler objectPooler, string tag)
    {
        if (count > 20 && point.IsPeak)
        {
            objectPooler.SpawnFromPool(tag, new Vector3(0, 3, 0), Quaternion.identity);
            count = 0;
        }
        else
        {
            count++;
        }
    }
}
