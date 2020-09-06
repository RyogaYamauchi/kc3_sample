using System.Threading;
using Controller;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace View
{
    public class TimerView : MonoBehaviour
    {
        [SerializeField]
        private Text _timeText = default;

        [SerializeField]
        private Button _startButton = default;

        [SerializeField]
        private string _maxTime = default;

        private TimerController _controller;

        private void Start()
        {
            _controller = new TimerController(this);
            var time = int.Parse(_maxTime);
            _startButton.onClick.AddListener(() => { StartCoroutine(_controller.StartTime(time)); });
        }

        // 時間用にフォーマットする
        private string FormatTime(int time)
        {
            var min = time / 60;
            var sec = time % 60;
            var minString = min < 10 ? $"0{min}" : $"{min}";
            var secString = sec < 10 ? $"0{sec}" : $"{sec}";
            return $"{minString}:{secString}";
        }

        public void OnUpdateTime(int time)
        {
            _timeText.text = FormatTime(time);
        }

        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private CancellationToken _cancellationToken => _cancellationTokenSource.Token;
        public async UniTask Wait()
        {
            await UniTask.Yield(PlayerLoopTiming.Update, _cancellationToken);
        }

        public void Cancel()
        {
            _cancellationTokenSource.Cancel();
        }
    }
}