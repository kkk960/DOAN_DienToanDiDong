using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject ongMau; // Biến chứa cái khuôn
    public float thoiGianDem = 0;

    // THÊM DÒNG NÀY: Biến để bạn tự chỉnh khoảng cách ngoài màn hình (mặc định 2 giây)
    public float thoiGianSinhOng = 2f;

    void Update()
    {
        thoiGianDem += Time.deltaTime; // Đếm thời gian

        // Cứ mỗi thoiGianSinhOng giây thì sinh 1 ống
        if (thoiGianDem > thoiGianSinhOng)
        {
            // Tạo ra ống mới tại vị trí của Spawner, nhưng độ cao Y ngẫu nhiên từ -2 đến 2
            Instantiate(ongMau, transform.position + new Vector3(0, Random.Range(-2f, 2f), 0), Quaternion.identity);

            thoiGianDem = 0; // Reset đồng hồ về 0
        }
    }
}