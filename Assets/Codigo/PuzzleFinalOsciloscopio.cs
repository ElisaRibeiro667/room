using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PuzzleFinalOsciloscopio : MonoBehaviour 
{
    [Header("Controles")]
    public Slider sliderFreq;
    public Slider sliderAmp;

    [Header("Configurações do Objetivo")]
    [Range(0, 1)] public float freqCorreta = 0.75f;
    [Range(0, 1)] public float ampCorreta = 0.5f;
    public float margemErro = 0.08f;

    [Header("Elementos Visuais e Sonoros")]
    public TextMeshProUGUI textoDisplay;
    public GameObject somDeSucesso; // Agora o buraquinho aceita o objeto de som

    void Update()
    {
        float erroFreq = Mathf.Abs(sliderFreq.value - freqCorreta);
        float erroAmp = Mathf.Abs(sliderAmp.value - ampCorreta);

        if (erroFreq < margemErro && erroAmp < margemErro)
        {
            // --- SUCESSO ---
            textoDisplay.text = "2";
            textoDisplay.color = Color.green;
            
            // Liga o objeto que tem a música
            if (somDeSucesso != null) somDeSucesso.SetActive(true);
        }
        else
        {
            // --- PROCURANDO ---
            textoDisplay.text = "NO SIGNAL...";
            textoDisplay.color = new Color(0, 1, 0, 0.2f);
            
            // Mantém a música desligada até acertar
            if (somDeSucesso != null) somDeSucesso.SetActive(false);
        }
    }
}