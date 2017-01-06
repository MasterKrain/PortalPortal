using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PortalPortal
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager Instance = null;

        private AudioSource[] m_SFXSources;

        [SerializeField]
        private AudioSource m_MusicSource;
        public AudioSource MusicSource { get { return m_MusicSource; } }

        [SerializeField]
        private int m_SFXBuffers = 8;
        public int SFXBuffers { get { return m_SFXBuffers; } }

        [SerializeField]
        private const float m_DefaultSFXVolume = .5f;
        public float DefaultSFXVolume { get { return m_DefaultSFXVolume; } }

        private MinMax m_DefaultPitchRange = new MinMax(.95f, 1.05f);

        private class MinMax
        {
            public float min, max;

            public MinMax( float min, float max )
            {
                this.min = min;
                this.max = max;
            }
        }

        void Awake()
        {
            if (Instance == null) Instance = this;
            else if (Instance != this) Destroy(gameObject);

            DontDestroyOnLoad(gameObject);

            // Get any component references down here
        }

        void Start()
        {
            m_SFXSources = new AudioSource[m_SFXBuffers];

            for (int i = 0; i < m_SFXSources.Length; i++)
            {
                m_SFXSources[i] = gameObject.AddComponent<AudioSource>();
            }
        }

        public void PlayEffect( AudioClip clip, float volume = m_DefaultSFXVolume, bool loop = false )
        {
            AudioSource source = GetInactiveAudioSource();
            source.pitch = Random.Range(m_DefaultPitchRange.min, m_DefaultPitchRange.max);
            source.clip = clip;
            source.volume = volume;
            source.loop = loop;
            source.Play();
        }

        public void PlayEffect( AudioClip clip, int priority, float volume = m_DefaultSFXVolume, bool loop = false )
        {
            AudioSource source = m_SFXSources[Mathf.Clamp(priority, 0, m_SFXSources.Length)];
            source.pitch = Random.Range(m_DefaultPitchRange.min, m_DefaultPitchRange.max);
            source.clip = clip;
            source.volume = volume;
            source.Play();
        }

        public void PlayRandomEffect( AudioClip[] clips, float volume = m_DefaultSFXVolume, bool loop = false )
        {
            AudioSource source = GetInactiveAudioSource();
            source.pitch = Random.Range(m_DefaultPitchRange.min, m_DefaultPitchRange.max);
            source.clip = clips[Random.Range(0, clips.Length)];
            source.volume = volume;
            source.loop = loop;
            source.Play();
        }

        public void PlayRandomEffect( AudioClip[] clips, int priority, float volume = m_DefaultSFXVolume, bool loop = false )
        {
            AudioSource source = m_SFXSources[Mathf.Clamp(priority, 0, m_SFXSources.Length)];
            source.pitch = Random.Range(m_DefaultPitchRange.min, m_DefaultPitchRange.max);
            source.clip = clips[Random.Range(0, clips.Length)];
            source.volume = volume;
            source.loop = loop;
            source.Play();
        }

        private AudioSource GetInactiveAudioSource()
        {
            foreach (AudioSource source in m_SFXSources)
            {
                if (!source.isPlaying) return source;
            }

            Debug.LogWarning("Cannot find inactive audio source! Returning last in list.");
            return m_SFXSources[m_SFXSources.Length - 1];
        }
    }
}
