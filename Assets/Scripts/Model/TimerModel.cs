using System;
using System.Collections;
using UniRx;
using UnityEngine;

namespace Model
{
    public class TimerModel
    {
        private int _time;
        private Subject<int> _timeSubject = new Subject<int>();
        public IObservable<int> Time => _timeSubject;

        public IEnumerator StartTimer(int num)
        {
            for (_time = num; _time >= 0; _time--)
            {
                yield return new WaitForSeconds(1.0f);
                _timeSubject.OnNext(_time);
            }
        }

        public void SubTime(int num)
        {
            if (_time < 0)
            {
                return;
            }
            _time -= num;
            _timeSubject.OnNext(_time);
        }
    }
}