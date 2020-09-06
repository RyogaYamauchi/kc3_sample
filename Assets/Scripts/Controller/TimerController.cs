using System.Collections;
using Model;
using UniRx;
using View;

namespace Controller
{
    public class TimerController
    {
        private TimerView _view;
        private TimerModel _model;

        public TimerController(TimerView view)
        {
            _view = view;
            _model = GameModel.Instance.TimerModel;
            _model.Time.Subscribe(x =>
            {
                _view.OnUpdateTime(x);
            });
        }

        public IEnumerator StartTime(int time)
        {
            return _model.StartTimer(time);
        }
    }

}