using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonClick : MonoBehaviour
{

    [SerializeField] Button[] buttons;
    
    // Start is called before the first frame update
    void Start()
    {
        
            foreach (Button button in buttons)
            {
                button.onClick.AddListener(() => SelectButton(button));

            }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SelectButton(Button selectedButton)
    {
        
        foreach (Button button in buttons)
        {
            bool isButtonSelected = (button == selectedButton);
            button.interactable = !isButtonSelected;
        }
        
    }
    
}
