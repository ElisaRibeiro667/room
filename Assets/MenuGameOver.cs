using UnityEngine;
using UnityEngine.SceneManagement; // Necessário para carregar cenas

public class MenuGameOver : MonoBehaviour
{
    public void ReiniciarJogo()
    {
        // Carrega a cena atual novamente
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
        // Garante que o tempo do jogo volte ao normal caso tenha sido pausado
        Time.timeScale = 1f;
    }

public void SairDoJogo()
{
    // Fecha o jogo se estiver rodando como programa
    Application.Quit();

    // Para o modo de teste se estiver dentro da Unity
    #if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
    #endif
}
}