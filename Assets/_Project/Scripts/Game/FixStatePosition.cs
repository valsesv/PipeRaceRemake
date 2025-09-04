using UnityEngine;

public class FixStatePosition : MonoBehaviour
{
    private void OnValidate()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).name.Contains("State"))
            {
                var prevPosition = transform.GetChild(i).position;
                prevPosition.x = 0f;
                prevPosition.y = 0f;
                transform.GetChild(i).position = prevPosition;
            }
        }
    }
}