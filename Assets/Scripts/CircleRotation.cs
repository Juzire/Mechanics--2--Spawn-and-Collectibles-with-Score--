using UnityEngine;

public class CircleRotation : MonoBehaviour
{
    public Transform center;   
    public float radius;       
    public float speed;        

    private bool isClockwise = true;  
    private CircleMechanics mainCircle;  

    private void Start()
    {
        mainCircle = FindObjectOfType<CircleMechanics>();  
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isClockwise = !isClockwise;  
        }

        float direction = isClockwise ? 1f : -1f;  

        transform.RotateAround(center.position, Vector3.forward, speed * direction * Time.deltaTime);

        Vector3 offset = (transform.position - center.position).normalized * radius;
        transform.position = center.position + offset;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectible") || collision.CompareTag("Obstacle"))
        {
            if (mainCircle != null)
            {
                mainCircle.HandleCollision(collision); 
            }
        }
    }
}
