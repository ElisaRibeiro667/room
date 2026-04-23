using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class CilindroQuimico : MonoBehaviour
{
    [Header("Configuração do Tanque")]
    [Tooltip("As cores que este tanque pode ter (ex: Vermelho, Verde, Azul, Amarelo)")]
    public Color[] coresPossiveis;
    
    // O índice da cor atual (0 é a primeira cor da lista)
    public int indiceCorAtual = 0; 
    
    // Referência ao gestor da sala que vai verificar a vitória
    public GerenciadorSala3 gerenciador; 
    
    private Renderer renderizador;

    void Start()
    {
        renderizador = GetComponent<Renderer>();
        AtualizarCorVisual();
    }

    // Quando clicas no cilindro, ele avança para a cor seguinte
    void OnMouseDown()
    {
        // Se a sala já foi resolvida, não deixa mudar mais as cores
        if (gerenciador != null && gerenciador.puzzleResolvido) return;

        indiceCorAtual++;
        
        // Se passar da última cor, volta à primeira (loop)
        if (indiceCorAtual >= coresPossiveis.Length)
        {
            indiceCorAtual = 0;
        }

        AtualizarCorVisual();
        
        // Avisa o gestor da sala para verificar se a combinação agora está certa
        if (gerenciador != null)
        {
            gerenciador.VerificarVitoria();
        }
    }

    void AtualizarCorVisual()
    {
        if (coresPossiveis.Length > 0)
        {
            renderizador.material.color = coresPossiveis[indiceCorAtual];
        }
    }
}