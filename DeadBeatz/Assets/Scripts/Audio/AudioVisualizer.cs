// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AudioVisualizer.cs" author="Lars" company="None">
// Copyright (c) 2018, Lars-Kristian Svenoey. All rights reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class AudioVisualizer : MonoBehaviour
{
    private AudioProcessor _audioProcessor;

    private AudioSource _audioSource;
    public AudioSource _playedSource;

    private bool _playClip;

    private readonly IAudioVisualizationBehaviour _bassVisualizationBehaviour = new PeakAudioVisualizerBehaviour();
    //private readonly IAudioVisualizationBehaviour _bassVisualizationBehaviour2 = new PeakAudioVisualizerBehaviour();

    private readonly IAudioVisualizationBehaviour _midRangeVisualizationBehaviour = new PeakAudioVisualizerBehaviour();
    //private readonly IAudioVisualizationBehaviour _midRangeVisualizationBehaviour2 = new PeakAudioVisualizerBehaviour();

    private readonly IAudioVisualizationBehaviour _highRangeVisualizationBehaviour = new PeakAudioVisualizerBehaviour();
    //private readonly IAudioVisualizationBehaviour _highRangeVisualizationBehaviour2 = new PeakAudioVisualizerBehaviour();

    [SerializeField]
    //private GameObject _bassObj, _midRangeObj, _highRangeObj;

    private SpectralFluxAnalyzer _bassAnalyzer, _midRangeAnalyzer, _highRangeAnalyzer;//, _bassAnalyzer2, _midRangeAnalyzer2, _highRangeAnalyzer2;

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
            new SpectralFluxAnalyzer(1024, _audioSource.clip.frequency, 60, 200),
            analyzer => { _bassAnalyzer = analyzer; });
        //_audioProcessor.ProcessClip(
        //    _audioSource.clip,
        //    new SpectralFluxAnalyzer(1024, _audioSource.clip.frequency, 201, 400),
        //    analyzer => { _bassAnalyzer2 = analyzer; });

        // Midrange
        _audioProcessor.ProcessClip(
            _audioSource.clip,
            new SpectralFluxAnalyzer(1024, _audioSource.clip.frequency, 2000, 4000),
            analyzer => { _midRangeAnalyzer = analyzer; });
        //_audioProcessor.ProcessClip(
        //    _audioSource.clip,
        //    new SpectralFluxAnalyzer(1024, _audioSource.clip.frequency, 3000, 4000),
        //    analyzer => { _midRangeAnalyzer2 = analyzer; });

        // High
        _audioProcessor.ProcessClip(
            _audioSource.clip,
            new SpectralFluxAnalyzer(1024, _audioSource.clip.frequency, 6000, 10000),
            analyzer => { _highRangeAnalyzer = analyzer; });
        //_audioProcessor.ProcessClip(
        //    _audioSource.clip,
        //    new SpectralFluxAnalyzer(1024, _audioSource.clip.frequency, 7000, 8000),
        //    analyzer => { _highRangeAnalyzer2 = analyzer; });
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
        //_bassVisualizationBehaviour.VisualizePoint(_bassAnalyzer.SpectralFluxSamples[currentPoint], _bassObj);
        _bassVisualizationBehaviour.SpawnMonster(_bassAnalyzer.SpectralFluxSamples[currentPoint], objectPooler, "Zombie");

        //_midRangeVisualizationBehaviour.VisualizePoint(_midRangeAnalyzer.SpectralFluxSamples[currentPoint], _midRangeObj);
        _midRangeVisualizationBehaviour.SpawnMonster(_midRangeAnalyzer.SpectralFluxSamples[currentPoint], objectPooler, "Skeleton");

        //_highRangeVisualizationBehaviour.VisualizePoint(_highRangeAnalyzer.SpectralFluxSamples[currentPoint], _highRangeObj);
        _highRangeVisualizationBehaviour.SpawnMonster(_highRangeAnalyzer.SpectralFluxSamples[currentPoint], objectPooler, "Ghoost");

        //_bassVisualizationBehaviour2.VisualizePoint(_bassAnalyzer2.SpectralFluxSamples[currentPoint], _bassObj);
        //_bassVisualizationBehaviour2.SpawnMonster(_bassAnalyzer2.SpectralFluxSamples[currentPoint], objectPooler, "Zombie2");

        //_midRangeVisualizationBehaviour2.VisualizePoint(_midRangeAnalyzer2.SpectralFluxSamples[currentPoint], _midRangeObj);
        //_midRangeVisualizationBehaviour2.SpawnMonster(_midRangeAnalyzer2.SpectralFluxSamples[currentPoint], objectPooler, "Skeleton2");

        //_highRangeVisualizationBehaviour2.VisualizePoint(_highRangeAnalyzer2.SpectralFluxSamples[currentPoint], _highRangeObj);
        //_highRangeVisualizationBehaviour2.SpawnMonster(_highRangeAnalyzer2.SpectralFluxSamples[currentPoint], objectPooler, "Ghoost2");

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