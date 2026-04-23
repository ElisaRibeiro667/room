using UnityEngine;
using UnityEngine.UI;

public class ControloSeta : MonoBehaviour
{
    public Image imagemFundo;    // O brilho/fundo
    public RectTransform setaTransform; 
    
    private int estado = 0; 

    public void AlterarEstado()
    {
        estado = (estado + 1) % 4; // 4 posições: Cima, Direita, Baixo, Esquerda

        // 1. Roda a seta (90 graus por clique)
        setaTransform.localRotation = Quaternion.Euler(0, 0, -90 * estado);

        // 2. Verifica se está na posição correta (Ex: Estado 2 é Baixo)
        if (estado == 2) 
        {
            imagemFundo.color = Color.green; // Fica VERDE
        }
        else 
        {
            // Fica branco ou transparente enquanto estiver errado
            imagemFundo.color = new Color(1, 1, 1, 0.2f); 
        }
    }
}