using System.Collections.Generic;
using UnityEngine;

namespace NoodleEater
{
    [System.Serializable]
    public struct AudioClipInfo
    {
        public string id;
        public AudioClip clip;
    }
    
    public class AudioPlayer : MonoBehaviour
    {
        [SerializeField] private List<AudioClipInfo> audioClipInfos;

        private readonly Dictionary<string, AudioSource> _audioSources = new Dictionary<string, AudioSource>();
        
        private void Start()
        {
            foreach (AudioClipInfo clipInfo in audioClipInfos)
            {
                AudioSource audioSource = gameObject.AddComponent<AudioSource>();
                audioSource.playOnAwake = false;
                audioSource.loop = false;
                audioSource.clip = clipInfo.clip;
                
                _audioSources.Add(clipInfo.id, audioSource);
            }
        }

        public void PlayAudio(string id)
        {
            if (_audioSources.TryGetValue(id, out var audioSource))
            {
                audioSource.Play();
            }
            else
            {
                Debug.Log($"AudioPlayer: {id} not found");
            }
        }
    }
}