using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public Transform[] fruitObj;
    static public string spawnedYet = "n";
    public float moveSpeed = 5f;  // Tốc độ di chuyển
    private float minX, maxX;     // Khoảng giới hạn di chuyển theo chiều ngang

    // Start is called before the first frame update
    void Start()
    {
         minX = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x; // Giới hạn bên trái
        maxX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x; // Giới hạn bên phải
    }

    // Update is called once per frame
    void Update()
    {
        // Lấy vị trí chuột trên màn hình
        Vector3 mousePos = Input.mousePosition;

        // Chuyển đổi vị trí chuột từ màn hình sang không gian thế giới (world space)
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        // Chỉ thay đổi giá trị X, giữ nguyên Y và Z (giới hạn theo chiều ngang)
        mousePos.y = transform.position.y;
        mousePos.z = transform.position.z;

        // Giới hạn di chuyển của đối tượng trong khoảng từ minX đến maxX
        mousePos.x = Mathf.Clamp(mousePos.x, minX, maxX);

        // Cập nhật vị trí của đối tượng
        transform.position = Vector3.Lerp(transform.position, mousePos, moveSpeed * Time.deltaTime);

    }
    
    void spawnFruit()
    {
        if(spawnedYet == "n")
        {
            Instantiate(fruitObj[Random.Range(0, 3)], transform.position, fruitObj[0].rotation);
            spawnedYet = "y";
        }
    }
}
