using UnityEngine;

namespace RaceGame
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private StartTimer _startTimer;
        [SerializeField]
        private RaceTimer _raceTimer;
        [SerializeField]
        private CarController _carController;

        private void Start() {
            _carController.enabled = false;
            _startTimer.gameObject.SetActive(true);
        }

        public void OnStartTimerFired() {
            _startTimer.gameObject.SetActive(false);
            _raceTimer.StartTimer();
            _carController.enabled = true;
        }
    }
}