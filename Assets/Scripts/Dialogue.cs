using UnityEngine;
using System.Collections;
using TMPro;

public class Dialogue : MonoBehaviour
{

    public TextMeshProUGUI textComponent;
    [Header ("===== Dialogue ======")]
    [SerializeField]
    private string[] lines; //this is where the text stored.
    public float textSpeed = 0.05f;
    private int index; //main index for anything, included for the index of the dialogue, so which sentence is diplayed are determined by this variable.
    public AudioClip typeSound; //this play the SFX which are the typing sound, played when the is at the process of revealing.
    private AudioSource audioSource;
    public UIFade fade;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.Log("AudioSource Null");
        }
        textComponent.text = string.Empty;
        StartDialogue();
    }



    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Klik kiri mouse
        {
            // Saat klik mouse
            if (textComponent.text == lines[index])
            {
                NewLine();
                Debug.Log(index);
            }

            else
            {
                StopAllCoroutines();
                audioSource.Stop();
                textComponent.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }
    

    // Menampilkan teks satu per satu (efek mengetik)
    IEnumerator TypeLine()
    {
        if (typeSound != null && audioSource != null)
        {
            audioSource.clip = typeSound;
            audioSource.loop = true;
            audioSource.Play();
        }

        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }


    public void NewLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            Debug.Log("Dialogue Finished!");
            fade.isFade = true;
        }
    }
}
