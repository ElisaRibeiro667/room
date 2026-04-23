using UnityEngine;

public class ControladorJogador : MonoBehaviour
{
    public float velocidade = 5.0f;
    public float sensibilidadeRato = 2.0f;
    
    private CharacterController controller;
    private Transform cameraTransform;
    private float rotacaoX = 0f;

    void Start()
    {
        // 1. Tenta encontrar o Character Controller no próprio objeto
        controller = GetComponent<CharacterController>();

        // 2. Tenta encontrar a Câmara que está dentro do Jogador
        Camera cameraPrincipal = GetComponentInChildren<Camera>();
        
        if (cameraPrincipal != null) 
        {
            cameraTransform = cameraPrincipal.transform;
        }

        // Verificação de segurança na Consola
        if (controller == null) Debug.LogError("Falta o Character Controller no Jogador!");
        if (cameraTransform == null) Debug.LogError("Falta uma Camera dentro do Jogador!");

        // Esconde o rato e prende-o no centro
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Se faltar o controlador ou a câmara, o código para aqui para não dar erro
        if (controller == null || cameraTransform == null) return;

        // --- ROTAÇÃO (Olhar para os lados) ---
        float ratoX = Input.GetAxis("Mouse X") * sensibilidadeRato;
        float ratoY = Input.GetAxis("Mouse Y") * sensibilidadeRato;

        rotacaoX -= ratoY;
        rotacaoX = Mathf.Clamp(rotacaoX, -90f, 90f); 

        // USAR cameraTransform aqui (corrigido!)
        cameraTransform.localRotation = Quaternion.Euler(rotacaoX, 0f, 0f);
        transform.Rotate(Vector3.up * ratoX);

        // --- MOVIMENTO (Andar) ---
        float moverX = Input.GetAxis("Horizontal"); // A e D
        float moverZ = Input.GetAxis("Vertical");   // W e S

        Vector3 movimento = transform.right * moverX + transform.forward * moverZ;
        
        // SimpleMove já aplica o DeltaTime automaticamente para gravidade básica
        controller.SimpleMove(movimento * velocidade);
    }
}