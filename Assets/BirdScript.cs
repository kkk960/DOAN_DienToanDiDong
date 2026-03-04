using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float lucNhay = 5f;
    private bool conSong = true;

    void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }

    void Update()
    {
        // 1. Nhảy lên khi bấm chuột
        if (conSong == true && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)))
        {
            rb.velocity = Vector2.up * lucNhay;
        }

        // 2. CHẾT KHI RỚT KHỎI MÀN HÌNH BÊN DƯỚI (y < -6)
        if (transform.position.y < -6f && conSong == true)
        {
            conSong = false;
            FindObjectOfType<GameManager>().ChimChet();
        }

        // 3. NGĂN CHIM BAY VƯỢT QUÁ MÀN HÌNH BÊN TRÊN (y > 5)
        if (transform.position.y > 5f)
        {
            // Ép tọa độ của chim ở lại mức 5f, không cho phép bay cao hơn
            transform.position = new Vector3(transform.position.x, 5f, transform.position.z);

            // Xóa lực bay thẳng đứng để chim không bị "dính" trên trần nhà mà sẽ rơi xuống ngay
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
    }

    // 4. CHẾT KHI VA CHẠM (Đập cột)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (conSong == true)
        {
            conSong = false;
            FindObjectOfType<GameManager>().ChimChet();
        }
    }
}