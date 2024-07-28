using UnityEngine;
using System.Threading.Tasks;

namespace PistolGame
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class GoalView : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        [SerializeField] private Color _damageColor;
        [SerializeField] private Color _inactiveColor;
        private Color _goalColor;

        private bool _isPlayingDamage = false;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            _goalColor = _spriteRenderer.color;
        }

        public void SetInactive()
        {
            _spriteRenderer.color = _inactiveColor;
        }

        public async void PlayDamage()
        {
            if (_isPlayingDamage) return;

            _isPlayingDamage = true;

            _spriteRenderer.color = _damageColor;
            await Task.Delay(200);
            if (!this) return;
            _spriteRenderer.color = _goalColor;

            _isPlayingDamage = false;
        }
    }
}
