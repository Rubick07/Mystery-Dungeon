using UnityEngine;

public class CardGravity : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Physics.gravity = new Vector3(0, 0, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
