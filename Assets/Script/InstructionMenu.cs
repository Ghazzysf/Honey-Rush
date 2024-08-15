using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionMenu : MonoBehaviour
{
    [SerializeField] GameObject[] instruction;
   
    private int selectedInstruction = 0;

    public void Next()
    {
        instruction[selectedInstruction].SetActive(false);
        selectedInstruction = (selectedInstruction + 1) % instruction.Length;
        instruction[selectedInstruction].SetActive(true);
    }

    public void Previous()
    {
        instruction[selectedInstruction].SetActive(false);
        selectedInstruction--;
        if(selectedInstruction < 0)
        {
            selectedInstruction += instruction.Length;
        }
        instruction[selectedInstruction].SetActive(true);
    }

    public void Play()
    {
        SceneManager.LoadScene(2);
    }
}
