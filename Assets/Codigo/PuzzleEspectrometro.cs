using UnityEngine;
using UnityEngine.UI;

public class PuzzleEspectrometro : MonoBehaviour
{
    [Header("Configurações do Puzzle")]
    public LineRenderer linha;
    public Slider sliderAlt;
    public Slider sliderLarg;
    public GameObject numeroDois;
    public GameObject painelCompleto;

    private bool estaAtivo = false;

    void Start() {
        painelCompleto.SetActive(false); // Começa escondido
    }

    // Função para abrir o puzzle (vamos ligar ao clique no monitor)
    public void AtivarPuzzle() {
        estaAtivo = true;
        painelCompleto.SetActive(true);
        Cursor.lockState = CursorLockMode.None; // Liberta o rato
        Cursor.visible = true;
    }

    void Update() {
        if (!estaAtivo) return;

        // Desenha a onda baseada nos Sliders
        for (int i = 0; i < 50; i++) {
            float x = i * 0.2f;
            float y = sliderAlt.value * Mathf.Sin(sliderLarg.value * x);
            linha.SetPosition(i, new Vector3(x, y, 0));
        }

        // Verifica se o jogador acertou os valores (ex: Altura 4, Largura 2)
        if (sliderAlt.value > 3.8f && sliderLarg.value > 1.8f && sliderLarg.value < 2.2f) {
            Ganhou();
        }
    }

    void Ganhou() {
        numeroDois.SetActive(true);
        // Aqui podes adicionar um som de "Sucesso"
    }
}