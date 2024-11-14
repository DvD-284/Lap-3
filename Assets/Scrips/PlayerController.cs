using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float moveSpeed = 5f; // Tốc độ di chuyển của vật thể
    private Vector3 startPosition;// Vị trí ban đầu của vật thể
    void Start()
    {
        // Lưu vị trí ban đầu của ô vuông
        startPosition = transform.position;
    }

    void Update()
    {
        // Lấy đầu vào từ bàn phím
        float moveX = Input.GetAxis("Horizontal"); // Phím mũi tên trái/phải
        float moveY = Input.GetAxis("Vertical");   // Phím mũi tên lên/xuống

        // Tạo vector di chuyển
        Vector3 move = new Vector3(moveX, moveY, 0);

        // Dịch chuyển vật thể
        transform.Translate(move * moveSpeed * Time.deltaTime);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Kiểm tra nếu ô vuông chạm vào chướng ngại vật
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Đưa ô vuông trở về vị trí ban đầu
            transform.position = startPosition;
        }
        // Kiểm tra nếu ô vuông chạm đến khu vực màu xanh
        else if (collision.gameObject.CompareTag("Goal"))
        {
            Debug.Log("Chúc mừng! Bạn đã đến đích!");
        }
    }
}
