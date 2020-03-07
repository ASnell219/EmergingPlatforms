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
        if (point.IsPeak && count > 10)
        {
            Vector3 position = new Vector3(0, 0, 0);
            if (tag == "Zombie") position = new Vector3(-5, 0, 0);
            else if (tag == "Skeleton") position = new Vector3(0, 0, 0);
            else if (tag == "Ghoost") position = new Vector3(5, 0, 0);

            objectPooler.SpawnFromPool(tag, position, Quaternion.identity);
            count = 0;
        }
        else
        {
            count++;
        }
    }
}
