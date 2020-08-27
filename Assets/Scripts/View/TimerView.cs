using System.Collections;
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
            StartCoroutine(StartTimer(int.Parse(_maxTime)));
        }

        private void SetStartTime()
        {
            UpdateTime(int.Parse(_maxTime));
        }

        private void UpdateTime(int time)
        {
            _time.text = FormatTime(time);
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

        private IEnumerator StartTimer(int num)
        {
            for (var i = num; i >= 0; i--)
            {
                UpdateTime(i);
                yield return new WaitForSeconds(1.0f);
            }
        }
    }
}