using UnityEngine;

namespace PistolGame
{
    public class Goal : MonoBehaviour
    {
        [SerializeField] private float _lifes = 5;
        [SerializeField] private bool isActiveGoal = false;
        [SerializeField] private GoalView _goalView;

        public bool IsActiveGoal => isActiveGoal;

        private void Start()
        {
            if (!isActiveGoal)
            {
                _goalView.SetInactive();
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!isActiveGoal) return;
            Bullet bullet = other.GetComponent<Bullet>();
            if (bullet)
            {
                _lifes -= bullet.BulletDamage;
                _goalView.PlayDamage();
                Destroy(other.gameObject);
                if (_lifes <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
