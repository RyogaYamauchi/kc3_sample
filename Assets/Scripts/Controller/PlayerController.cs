using Model;
using View;

namespace Controller
{
    public class PlayerController
    {
        private PlayerView _view;
        private PlayerModel _model;


        public PlayerController(PlayerView view)
        {
            _model = new PlayerModel();
            _view = view;
        }

        //ダメージを受けた時の処理
        public void TakeDamage()
        {
            // タイマーを減らしたい
            var timerModel = GameModel.Instance.TimerModel;
            timerModel.SubTime(2);
        }

    }
}