using UnityEngine;

public class PuzzleDeCircuito : MonoBehaviour
{
    public GameObject numeroDaPorta; 
    public GameObject teletransporte; 
    public RectTransform[] pecas; 
    public float[] rotacoesCorretas;
    public AudioSource somDeVitoria; 

    private bool puzzleResolvido = false;

    void Start()
    {
        if (numeroDaPorta != null) numeroDaPorta.SetActive(false);
        if (teletransporte != null) teletransporte.SetActive(false);
        
        // Baralhar as peças
        foreach (var peca in pecas)
        {
            int rotacoesAleatorias = Random.Range(1, 4);
            peca.Rotate(0, 0, rotacoesAleatorias * 90f);
        }
    }

    public void RodarPeca(int index)
    {
        if (puzzleResolvido) return;

        // Roda a peça
        pecas[index].Rotate(0, 0, -90f); 
        
        VerificarVitoria();
    }

    void VerificarVitoria()
    {
        for (int i = 0; i < pecas.Length; i++)
        {
            // 1. Vai buscar a rotação do Unity
            float rotacaoBruta = pecas[i].eulerAngles.z;
            
            // 2. Transforma em número inteiro e arredonda (ex: 89.9 vira 90, 360 vira 0)
            int anguloAtual = Mathf.RoundToInt(rotacaoBruta) % 360;
            if (anguloAtual < 0) anguloAtual += 360; // Evita ângulos negativos

            // 3. Faz o mesmo para a tua resposta correta
            int anguloAlvo = Mathf.RoundToInt(rotacoesCorretas[i]) % 360;
            if (anguloAlvo < 0) anguloAlvo += 360;

            // 4. Compara
            if (anguloAtual != anguloAlvo)
            {
                // Imprime na consola o que está a falhar!
                Debug.Log($"[DETETIVE] O puzzle parou na Peça {i}. A peça está a {anguloAtual} graus, mas o Inspector pede {anguloAlvo} graus.");
                return; 
            }
        }

        // Se chegou aqui, ganhámos
        GanharJogo();
    }

void GanharJogo()
    {
        puzzleResolvido = true;
        
        if (numeroDaPorta != null) numeroDaPorta.SetActive(true);
        if (teletransporte != null) teletransporte.SetActive(true);

        // NOVO: Toca o som de vitória se ele estiver configurado
        if (somDeVitoria != null)
        {
            somDeVitoria.Play();
        }

        // Esconde a interface do puzzle
        gameObject.SetActive(false); 
    }
}