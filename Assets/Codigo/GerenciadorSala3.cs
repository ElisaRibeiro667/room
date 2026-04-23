using UnityEngine;

public class GerenciadorSala3 : MonoBehaviour
{
    [Header("Recompensas")]
    public GameObject numeroDaSala;
    public GameObject teletransporte;

    [Header("Configuração do Puzzle")]
    [Tooltip("Arrasta os 3 tanques para aqui")]
    public CilindroQuimico[] tanques;
    
    [Tooltip("Qual é o índice da cor certa para cada tanque? (ex: 1, 0, 2)")]
    public int[] combinacaoCerta;

    public bool puzzleResolvido = false;

    void Start()
    {
        if (numeroDaSala) numeroDaSala.SetActive(false);
        if (teletransporte) teletransporte.SetActive(false);
    }

    public void VerificarVitoria()
    {
        if (puzzleResolvido) return;

        // Compara a cor de cada tanque com a tua chave de respostas
        for (int i = 0; i < tanques.Length; i++)
        {
            // Se um único tanque estiver com a cor errada, para de verificar
            if (tanques[i].indiceCorAtual != combinacaoCerta[i])
            {
                return; 
            }
        }

        // Se o código não parou, significa que os 3 estão certos!
        GanharJogo();
    }

    void GanharJogo()
    {
        puzzleResolvido = true;
        Debug.Log("ANTIVÍRUS SINTETIZADO! Acesso Concedido.");

        if (numeroDaSala) numeroDaSala.SetActive(true);
        if (teletransporte) teletransporte.SetActive(true);
    }
}