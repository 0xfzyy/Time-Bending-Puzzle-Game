using UnityEngine;
using UnityEngine.Events;

public class PressurePlate : MonoBehaviour
{
    public UnityEvent onPressed;
    public UnityEvent onReleased;
    
    private int objectsOnPlate = 0;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("TimeEcho"))
        {
            objectsOnPlate++;
            if (objectsOnPlate == 1)
            {
                onPressed?.Invoke();
            }
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("TimeEcho"))
        {
            objectsOnPlate--;
            if (objectsOnPlate == 0)
            {
                onReleased?.Invoke();
            }
        }
    }
} 