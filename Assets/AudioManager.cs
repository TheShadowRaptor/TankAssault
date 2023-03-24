using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankAssault
{
    public class AudioManager : MonoBehaviour
    {
        [Header("Clips")]
        public AudioClip playerHurt;
        public AudioClip playerShoot;
        public AudioClip enemyHurt;
        public AudioClip enemySlain;
        
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void PlayAudio(AudioSource audioSource, AudioClip audioClip)
        {
            if (audioSource.isPlaying) return;
            audioSource.clip = audioClip;
            audioSource.Play();
        }
        public void StopAudio(AudioSource audioSource)
        {
            audioSource.Stop();
        }

        public void PauseAudio(AudioSource audioSource)
        {
            audioSource.Pause();
        }
        public void ResumeAudio(AudioSource audioSource)
        {
            audioSource.UnPause();
        }

    }
}
