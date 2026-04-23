using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Adicionado para controlar botões

public class PortaCodigo : MonoBehaviour
{
    [Header("Configurações")]
    public string codigoCorreto = "4502"; 
    public GameObject painelUI;
    public TMP_InputField campoEntrada;
    public GameObject textoDica; 
    public GameObject paredeParaSumir;

    [Header("Sistema de Tentativas")]
    public int tentativasRestantes = 1; // Você pode mudar para 3 se quiser ser mais bonzinho!
    public GameObject botaoRecomecar; // Arraste o botão "Começar de novo" para aqui

    private bool jogadorPerto = false;

    void Start()
    {
        if (painelUI != null) painelUI.SetActive(false);
        if (textoDica != null) textoDica.SetActive(false);
        if (botaoRecomecar != null) botaoRecomecar.SetActive(false); // Escondido no início
    }

    void Update()
    {
        if (jogadorPerto && Input.GetKeyDown(KeyCode.E))
        {
            AbrirPainel();
        }
    }

    void AbrirPainel()
    {
        if (painelUI != null)
        {
            painelUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            campoEntrada.ActivateInputField();
        }
    }

    public void VerificarCodigo()
    {
        if (campoEntrada.text == codigoCorreto)
        {
            Ganhar();
        }
        else
        {
            tentativasRestantes--; // Perde uma vida
            Debug.Log("Código Errado! Tentativas: " + tentativasRestantes);

            if (tentativasRestantes <= 0)
            {
                GameOverCodigo();
            }
            else
            {
                TentarNovamente(); 
            }
        }
    }

    void GameOverCodigo()
    {
        campoEntrada.text = "BLOQUEADO";
        campoEntrada.interactable = false; // Desativa a escrita
        
        if (botaoRecomecar != null) 
            botaoRecomecar.SetActive(true); // Mostra o botão de reiniciar
            
        Debug.Log("Você esgotou as tentativas!");
    }

    void Ganhar()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        if (paredeParaSumir != null) paredeParaSumir.SetActive(false);
        painelUI.SetActive(false);
        this.enabled = false; 
    }

    public void ReiniciarSala()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void TentarNovamente()
    {
        campoEntrada.text = "";
        campoEntrada.ActivateInputField();
    }

    // --- TRIGGERS ---
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorPerto = true;
            if (textoDica != null) textoDica.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorPerto = false;
            if (textoDica != null) textoDica.SetActive(false);
            if (painelUI != null && painelUI.activeSelf)
            {
                painelUI.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }
}