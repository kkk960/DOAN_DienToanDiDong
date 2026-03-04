using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Tìm ông GameManager và bảo ông ấy cộng điểm đi
        FindObjectOfType<GameManager>().CongDiem();
    }
}