using UnityEngine;

public class MonitorInterativo : MonoBehaviour
{
    [Tooltip("Arrasta o Canvas/Painel do teu puzzle de UI para aqui")]
    public GameObject puzzleDeUI;

    // Esta função deteta quando clicas com o botão esquerdo do rato neste objeto
    void OnMouseDown()
    {
        // Verifica se o puzzle não está vazio e ativa-o
        if (puzzleDeUI != null)
        {
            puzzleDeUI.SetActive(true);
            
            // Opcional: Se o teu rato estiver escondido (típico em jogos de 1ª pessoa),
            // estas duas linhas forçam o rato a aparecer para poderes clicar no puzzle.
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}