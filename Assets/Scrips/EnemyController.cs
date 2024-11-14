using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float initialSpeed = 3f; // Tốc độ ban đầu của vật thể
    public float moveRange = 2f; // Phạm vi di chuyển theo trục Y
    private float currentSpeed; // Tốc độ hiện tại của vật thể
    private float initialY; // Vị trí Y ban đầu
    private float timer = 0f; // Bộ đếm thời gian
    public float speedChangeAmount = 0.5f; // Mức tăng hoặc giảm tốc độ
    public float maxSpeed = 10f; // Tốc độ tối đa
    public float minSpeed = 1f; // Tốc độ tối thiểu

    void Start()
    {
        // Ghi nhận tốc độ hiện tại và vị trí Y ban đầu
        currentSpeed = initialSpeed;
        initialY = transform.position.y;
    }

    void Update()
    {
        // Tạo chuyển động lên xuống theo dạng sóng sin
        float newY = initialY + Mathf.PingPong(Time.time * currentSpeed, moveRange);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        // Tăng thời gian theo thời gian thực
        timer += Time.deltaTime;

        // Kiểm tra nếu đủ 5 giây thì thay đổi tốc độ
        if (timer >= 5f)
        {
            ChangeSpeed();
            timer = 0f; // Đặt lại bộ đếm thời gian
        }
    }

    // Hàm thay đổi tốc độ tăng dần hoặc giảm dần
    void ChangeSpeed()
    {
        // Kiểm tra nếu tốc độ hiện tại đạt đến giới hạn tối đa, chuyển hướng giảm
        if (currentSpeed >= maxSpeed)
        {
            speedChangeAmount = -Mathf.Abs(speedChangeAmount); // Chuyển sang giảm tốc độ
        }
        // Kiểm tra nếu tốc độ hiện tại đạt đến giới hạn tối thiểu, chuyển hướng tăng
        else if (currentSpeed <= minSpeed)
        {
            speedChangeAmount = Mathf.Abs(speedChangeAmount); // Chuyển sang tăng tốc độ
        }

        // Cập nhật tốc độ hiện tại với giới hạn từ 1 đến 10
        currentSpeed = Mathf.Clamp(currentSpeed + speedChangeAmount, minSpeed, maxSpeed);
        Debug.Log("Tốc độ mới: " + currentSpeed);
    }
}
