using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class TimerView : MonoBehaviour
    {
        [SerializeField]
        private Text _time = default;

        [SerializeField]
        private Button _startButton = default;

        [SerializeField]
        private string _maxTime = default;

        private void Start()
        {
            SetStartTime();
        }

        private void SetStartTime()
        {
            var time = FormatTime(int.Parse(_maxTime));
            _time.text = time;
        }
        
        // 時間ようにフォーマットするだけ
        private string FormatTime(int time)
        {
            var min = time / 60;
            var sec = time % 60;
            var minString = min < 10 ? $"0{min}" : $"{min}";
            var secString = sec < 10 ? $"0{sec}" : $"{sec}";
            return $"{minString}:{secString}";
        }
    }
}