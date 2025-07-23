using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement; // Sahne yönetimi için

public class Box : MonoBehaviour
{
    public float speed = 5f; // İleri hız 
    public float jumpForce = 10f; //Yukarı doğru sıçrama gücü
    
    private Rigidbody2D rb;
    void Start()
    {
        print("Hello World");  
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
         // Sağ yönlü sabit hareket (x yönünde) 
         rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y); 

          // Mouse sol tuşa basılıysa yukarı zıpla 
          if (Mouse.current.leftButton.isPressed) 
          { 
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); 
            }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Çarpışma algılandı: " + collision.gameObject.name);

        // Sahneyi yeniden başlatarak oyunu sıfırla
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
