using UnityEngine;

namespace Model
{
    public class GameModel
    {
        public static GameModel Instance { get; } = new GameModel();
        
        public TimerModel TimerModel { get; } = new TimerModel();

        public PlayerModel PlayerModel { get; } = new PlayerModel();

        
    }
}