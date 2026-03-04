using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("--- Điểm Số & Kỷ Lục ---")]
    public Text diemSoText;
    public GameObject highScoreObject;
    public Text highScoreText;

    [Header("--- Nút Bấm Giao Diện ---")]
    public GameObject manHinhBatDau;
    public GameObject manHinhGameOver;

    int diem = 0;

    void Start()
    {
        Time.timeScale = 0; // Dừng hình game lúc mới mở
        highScoreObject.SetActive(false); // Giấu bảng kỷ lục

        // Hiện nút Bắt Đầu, Giấu nút Chơi Lại
        manHinhBatDau.SetActive(true);
        manHinhGameOver.SetActive(false);
    }

    // --- HÀM CHO NÚT BẮT ĐẦU ---
    public void BatDauGame()
    {
        Time.timeScale = 1; // Cho thời gian chạy bình thường
        manHinhBatDau.SetActive(false); // Ẩn nút bắt đầu đi để chơi
    }

    public void CongDiem()
    {
        diem++;
        diemSoText.text = diem.ToString();
    }

    // --- HÀM KHI CHIM CHẾT ---
    public void ChimChet()
    {
        Time.timeScale = 0; // Dừng hình game (game over)

        highScoreObject.SetActive(true); // Hiện chữ Kỷ lục
        manHinhGameOver.SetActive(true); // Hiện nút Chơi Lại

        // Xử lý lưu kỷ lục
        int kyLucCu = PlayerPrefs.GetInt("KyLucCuaToi", 0);
        if (diem > kyLucCu)
        {
            PlayerPrefs.SetInt("KyLucCuaToi", diem);
            highScoreText.text = "Kỷ lục: " + diem.ToString();
        }
        else
        {
            highScoreText.text = "Kỷ lục: " + kyLucCu.ToString();
        }
    }

    // --- HÀM CHO NÚT CHƠI LẠI ---
    public void ChoiLaiGame()
    {
        Time.timeScale = 1; // Khôi phục lại thời gian
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Load lại màn chơi
    }
}