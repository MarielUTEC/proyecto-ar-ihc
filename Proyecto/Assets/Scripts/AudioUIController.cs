using UnityEngine;
using UnityEngine.UI;

public class AudioUIController : MonoBehaviour
{
    public AudioSource audioSource; // Para controlar el audio
    public Button playPauseButton; // Botón de reproducir/pausar
    public Slider progressBar; // Barra de progreso
    public Text audioTimeText; // Texto para mostrar el tiempo

    public Sprite playSprite; // Sprite para el botón de Play
    public Sprite stopSprite; // Sprite para el botón de Stop

    private bool isPlaying = false;

    void Start()
    {
        playPauseButton.onClick.AddListener(TogglePlayPause);
        progressBar.onValueChanged.AddListener(OnProgressBarChanged); // Listener para el cambio en el Slider
    }

    void TogglePlayPause()
    {
        if (isPlaying)
        {
            audioSource.Pause(); // Pausa el audio
            playPauseButton.GetComponent<Image>().sprite = playSprite; // Cambia a sprite de Play
        }
        else
        {
            audioSource.Play(); // Reproduce el audio
            playPauseButton.GetComponent<Image>().sprite = stopSprite; // Cambia a sprite de Stop
        }
        isPlaying = !isPlaying;
    }

    void OnProgressBarChanged(float value)
    {
        audioSource.time = value * audioSource.clip.length; // Actualiza el tiempo del audio según la posición del Slider
        if (!audioSource.isPlaying)
        {
            audioSource.Play(); // Reproduce el audio si no se está reproduciendo
            playPauseButton.GetComponent<Image>().sprite = stopSprite; // Asegúrate de mostrar el botón de Stop
            isPlaying = true; // Actualiza el estado
        }
    }

    void Update()
    {
        // Actualizar la barra de progreso y el texto de tiempo si el audio está reproduciéndose
        if (audioSource.isPlaying)
        {
            progressBar.value = audioSource.time / audioSource.clip.length; // Normaliza el valor de la barra de progreso
            UpdateAudioTime();
            
            // Verificar si el audio ha llegado al final
            if (audioSource.time >= audioSource.clip.length)
            {
                audioSource.Stop(); // Detener el audio
                audioSource.time = 0; // Reiniciar al inicio
                playPauseButton.GetComponent<Image>().sprite = playSprite; // Cambiar a sprite de Play
                isPlaying = false; // Actualizar el estado a no reproduciendo
            }
        }
    }

    void UpdateAudioTime()
    {
        float currentTime = audioSource.time;
        float totalDuration = audioSource.clip.length;
        audioTimeText.text = $"{FormatTime(currentTime)} / {FormatTime(totalDuration)}";
    }

    // Formatear el tiempo en minutos y segundos
    string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60F);
        int seconds = Mathf.FloorToInt(time - minutes * 60);
        return string.Format("{0:0}:{1:00}", minutes, seconds);
    }
}
