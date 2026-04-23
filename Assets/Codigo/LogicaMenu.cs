using UnityEngine;
using UnityEngine.SceneManagement; // Esta linha permite mudar de cena

public class LogicaMenu : MonoBehaviour
{
    public void Jogar()
    {
        // Aqui colocas o nome EXATO da cena do teu laboratório
        SceneManager.LoadScene("Laboratorio"); 
    }

   public void Sair()
    {
        Debug.Log("O jogador carregou em Sair!");

        // Se estiveres a correr o jogo DENTRO do Unity
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            // Se o jogo já estiver exportado (ficheiro .exe)
            Application.Quit();
        #endif
    }
}