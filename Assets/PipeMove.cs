using UnityEngine;

public class PipeMove : MonoBehaviour
{
    public float tocDo = 5f; // Tốc độ trôi

    void Update()
    {
        // Lệnh này đẩy ống sang trái
        transform.position += Vector3.left * tocDo * Time.deltaTime;

        // Nếu ống trôi quá xa khỏi màn hình (x < -15) thì tự xóa đi
        if (transform.position.x < -3.5)
        {
            Destroy(gameObject);
        }
    }
}