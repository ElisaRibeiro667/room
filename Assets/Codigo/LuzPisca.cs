using UnityEngine;

public class LuzPisca : MonoBehaviour
{
    private Light luz;
    public float intensidadeMaxima = 2.0f;
    public float intensidadeMinima = 0.0f;

    void Start()
    {
        luz = GetComponent<Light>();
    }

    void Update()
    {
        // Cria um efeito de "flicker" aleatório usando ruído
        // Isto faz a luz tremer em vez de apenas ligar/desligar
        if (Random.value > 0.9f) // 10% de chance de falhar em cada frame
        {
            luz.intensity = Random.Range(intensidadeMinima, intensidadeMaxima);
        }
    }
}