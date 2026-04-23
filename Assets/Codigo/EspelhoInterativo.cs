using UnityEngine;

public class EspelhoInterativo : MonoBehaviour
{
    [Tooltip("Controla a velocidade com que o espelho roda. Aumenta se achares muito lento.")]
    public float velocidadeRotacao = 10f;

    // O OnMouseDrag é executado a todos os frames enquanto mantiveres o botão esquerdo do rato pressionado em cima do objeto
    void OnMouseDrag()
    {
        // Vai buscar o movimento horizontal do rato (se moves para a esquerda ou direita)
        float movimentoRato = Input.GetAxis("Mouse X");

        // Roda o espelho livremente a toda a volta no eixo Y (Esquerda/Direita)
        // O sinal negativo (-) serve para a rotação acompanhar o movimento do rato de forma natural
        transform.Rotate(0, -movimentoRato * velocidadeRotacao, 0);
    }
}