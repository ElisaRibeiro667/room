using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Cronometro : MonoBehaviour
{
    public float tempoRestante = 60f; 
    public TextMeshProUGUI textoTempo;
    public GameObject painelGameOver; 

    void Start()
    {
        // Garante que o tempo corre quando o jogo inicia ou reinicia
        Time.timeScale = 1f;
        
        // Verifica se te esqueceste de arrastar os objetos no Unity
        if (textoTempo == null) Debug.LogError("Falta arrastar o Texto para o script!");
        if (painelGameOver == null) Debug.LogError("Falta arrastar o PainelGameOver para o script!");
    }

    void Update()
    {
        if (tempoRestante > 0)
        {
            tempoRestante -= Time.deltaTime;
            AtualizarTexto();
        }
        else if (Time.timeScale > 0) // Só chama Finalizar se o jogo ainda não parou
        {
            FinalizarJogo();
        }
    }

    void AtualizarTexto()
    {
        int minutos = Mathf.FloorToInt(tempoRestante / 60);
        int segundos = Mathf.FloorToInt(tempoRestante % 60);
        textoTempo.text = string.Format("{0:00}:{1:00}", minutos, segundos);
    }

    void FinalizarJogo()
    {
        tempoRestante = 0;
        AtualizarTexto(); // Força o 00:00 no ecrã
        
        if (painelGameOver != null){
            painelGameOver.SetActive(true); 
            Debug.Log("Tempo esgotado! Game Over!");
        }
        else
        {
            Debug.LogError("PainelGameOver não está atribuído no Inspector!");
        }
            

        Time.timeScale = 0f; 
        
        Cursor.lockState = CursorLockMode.None; 
        Cursor.visible = true;
    }
    
    public void Reiniciar()
    {
        // Importante: resetar o Time.timeScale ANTES de carregar a cena
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
}