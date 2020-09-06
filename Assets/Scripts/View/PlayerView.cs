using System;
using Controller;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace View
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField]
        private Button _button = default;

        private PlayerController _controller;


        [Inject]
        private void Construct(PlayerController controller)
        {
            _controller = controller;
        }
        
        private void Start()
        {
            // _controller = new PlayerController(this);
            _button.onClick.AddListener(() =>
            {
                _controller.TakeDamage();
            });
        }
    }
}