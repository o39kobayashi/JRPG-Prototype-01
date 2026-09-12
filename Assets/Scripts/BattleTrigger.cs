using UnityEngine;

public class BattleTrigger : MonoBehaviour
{
    private Vector3 _rotationSpeed;

    private const float MULTIPLIER = 1.5F;

    private void Start() {

        _rotationSpeed = new Vector3(50, 50, 50); 
    
    }

    private void Update() {

        transform.Rotate(_rotationSpeed * MULTIPLIER * Time.deltaTime);
    
    }

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("BATTLE TRIGGERED");

        gameObject.SetActive(false);

    }

}
