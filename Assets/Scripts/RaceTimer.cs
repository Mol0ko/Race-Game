using System;
using System.Collections;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.UI;

namespace RaceGame
{
    public class RaceTimer : MonoBehaviour
    {
        [SerializeField]
        private Text _text;

        private float _milliseconds = 0f;

        public void StartTimer()
        {
            StartCoroutine(TimerRoutine());
        }

        public void StopTimer()
        {
            StopCoroutine(TimerRoutine());
        }

        private IEnumerator TimerRoutine()
        {
            while (true)
            {
                _milliseconds += (Time.deltaTime * 1000);
                var dateTime = new DateTime(TimeSpan.FromMilliseconds(_milliseconds).Ticks);
                _text.text = dateTime.ToString("mm:ss:fff");
                yield return null;
            }
        }
    }
}