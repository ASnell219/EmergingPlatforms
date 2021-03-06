﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AudioVisualizer.cs" author="Lars" company="None">
// Copyright (c) 2018, Lars-Kristian Svenoey. All rights reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class AudioVisualizerOof : MonoBehaviour
{
    private AudioProcessor _audioProcessor;

    private AudioSource _audioSource;
    public AudioSource _playedSource;

    private bool _playClip;

    private readonly IAudioVisualizationBehaviour _bassVisualizationBehaviour = new PeakAudioVisualizerBehaviour();

    private readonly IAudioVisualizationBehaviour _midRangeVisualizationBehaviour = new PeakAudioVisualizerBehaviour();

    private readonly IAudioVisualizationBehaviour _highRangeVisualizationBehaviour = new PeakAudioVisualizerBehaviour();

    [SerializeField]
    private GameObject _bassObj, _midRangeObj, _highRangeObj;

    private SpectralFluxAnalyzer _bassAnalyzer, _midRangeAnalyzer, _highRangeAnalyzer;

    ObjectPooler objectPooler;
    // Use this for initialization
    private void Start()
    {
        objectPooler = ObjectPooler.Instance;
        
        _audioSource = GetComponent<AudioSource>();

        _audioProcessor = new AudioProcessor(1024);

        // Bass
        _audioProcessor.ProcessClip(
            _audioSource.clip,
            new SpectralFluxAnalyzer(1024, _audioSource.clip.frequency, 2000, 2499),
            analyzer => { _bassAnalyzer = analyzer; });

        // Midrange
        _audioProcessor.ProcessClip(
            _audioSource.clip,
            new SpectralFluxAnalyzer(1024, _audioSource.clip.frequency, 2500, 4000),
            analyzer => { _midRangeAnalyzer = analyzer; });

        // High
        _audioProcessor.ProcessClip(
            _audioSource.clip,
            new SpectralFluxAnalyzer(1024, _audioSource.clip.frequency, 4000, 20000),
            analyzer => { _highRangeAnalyzer = analyzer; });
    }

    // Update is called once per frame
    private void Update()
    {
        if (_bassAnalyzer == null || _midRangeAnalyzer == null || _highRangeAnalyzer == null) return;

        if (!_audioSource.isPlaying)
        {
            _audioSource.Play();
            StartCoroutine(WaitTest());
        }
        
        var currentPoint = _audioProcessor.GetCurrentPlayingPointIndex(_audioSource); //can go ahead of song (maybe)
                                                                                      //delay song by at least length of lane and spawn on beat detection. Player should only hear second song and beats should line up.

        //Change Frequencies that are tracked for the lanes to be more 'relevant';
        _bassVisualizationBehaviour.VisualizePoint(_bassAnalyzer.SpectralFluxSamples[currentPoint], _bassObj);
        _bassVisualizationBehaviour.SpawnMonster(_bassAnalyzer.SpectralFluxSamples[currentPoint], objectPooler, "Zombie");

        _midRangeVisualizationBehaviour.VisualizePoint(_midRangeAnalyzer.SpectralFluxSamples[currentPoint], _midRangeObj);
        _midRangeVisualizationBehaviour.SpawnMonster(_midRangeAnalyzer.SpectralFluxSamples[currentPoint], objectPooler, "Skeleton");

        _highRangeVisualizationBehaviour.VisualizePoint(_highRangeAnalyzer.SpectralFluxSamples[currentPoint], _highRangeObj);
        _highRangeVisualizationBehaviour.SpawnMonster(_highRangeAnalyzer.SpectralFluxSamples[currentPoint], objectPooler, "Ghoost");

    }

    IEnumerator WaitTest()
    {
        if(_playedSource != null)
        {
            if (!_playedSource.isPlaying)
            {
                yield return new WaitForSeconds(5); //time a note takes to reach the player
                _playedSource.Play();
            }
        }
    }
}