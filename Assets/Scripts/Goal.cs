using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private int _lifes = 5;
    [SerializeField] private GoalType goalType = GoalType.Type1;
    [SerializeField] private bool isActiveGoal = false;

    public bool IsActiveGoal => isActiveGoal;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log("OnTriggerEnter2D");
        if(other.gameObject.tag == "bullet"){
            _lifes -= 1;
            PlayDamage();
            Destroy(other.gameObject);
            if (_lifes == 0){
                Destroy(gameObject);
            }
        }
    }

    private void PlayDamage(){
        Debug.Log("Damage " + goalType);
    }
}