using UnityEngine;

public class SonsPassos : MonoBehaviour
{
    public AudioSource somPassos; // Arrastas o Audio Source do jogador para aqui

    void Update()
    {
        // Verifica se o jogador está a carregar numa tecla de movimento
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            // Se estiver a andar e o som não estiver a tocar, toca o som
            if (!somPassos.isPlaying)
            {
                somPassos.Play();
            }
        }
        else
        {
            // Se parou de carregar nas teclas, para o som
            somPassos.Stop();
        }
    }
}
