using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class DialogManager : MonoBehaviour
{
    [SerializeField] GameObject teacherBodyActive;

    [SerializeField] private TMP_Text nameNPC, textNPC, answer1, answer2, answer3, answer4;
    [SerializeField] private Teacher teacher;
    [SerializeField] GameObject dialog;
    private Dialogs dialogActive;
    private Answer answer1Active, answer2Active, answer3Active, answer4Active;
    private GameObject player;

    public void SetTeacher(Teacher activeTeacher, GameObject bodyTeacher)
    {
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
        teacherBodyActive = bodyTeacher;
        teacher = activeTeacher;

        
        nameNPC.SetText(teacher.name);
        dialogActive = teacher.dialog;
        textNPC.SetText(dialogActive.dialog);
        try
        {
            answer1Active = teacher.dialog.answer1;
            answer1.SetText(answer1Active.answer);
            answer2Active = teacher.dialog.answer2;
            answer2.SetText(answer2Active.answer);
            answer3Active = teacher.dialog.answer3;
            answer3.SetText(answer3Active.answer);
            answer4Active = teacher.dialog.answer4;
            answer4.SetText(answer4Active.answer);
        }
        catch { }
    }
    private void Start()
    {
    }
    public void ExitDialog()
    {
        Cursor.visible = false;
        dialog.SetActive(false);
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponentInChildren<PlayerLoop>().enabled = true;
    }
    public void answer11()
    {
        
        if (answer1Active.id == 0)
        {
            ExitDialog();

        }
        else
        {
            if (answer1Active.id == 6)
            {
                teacherBodyActive.transform.position += new Vector3(0, 10, 0);
                ExitDialog();
            }
            else
            {
                dialogActive = answer1Active.dialog;
                Ans(dialogActive);
            }
        }
        
    }
    public void answer12()
    {
        
        if (answer2Active.id == 0)
        {
            ExitDialog();
        }
        else
        {
            dialogActive = answer2Active.dialog;
            Ans(dialogActive);
        }
        
    }
    public void answer13()
    {
        
        if (answer3Active.id == 0)
        {
            ExitDialog();
        }
        else
        {
            dialogActive = answer3Active.dialog;
            Ans(dialogActive);
        }
        
    }
    public void answer14()
    {
        
        if (answer4Active.id == 0)
        {
            ExitDialog();
        }
        else
        {
            dialogActive = answer4Active.dialog;
            Ans(dialogActive);
        }
        
    }
    private void Ans(Dialogs dial)
    {
        textNPC.SetText(dialogActive.dialog);

        

        try
        {
            answer1Active = dialogActive.answer1;
        }
        catch { answer1.SetText(""); }
        try
        {
            answer2Active = dialogActive.answer2;
        }
        catch { answer2.SetText(""); }
        try
        {
            answer3Active = dialogActive.answer3;
        }
        catch { answer3.SetText(""); }
        try
        {
            answer4Active = dialogActive.answer4;
        }
        catch { answer4.SetText(""); }
        try
        {
            answer1.SetText(answer1Active.answer);

            answer2.SetText(answer2Active.answer);

            answer3.SetText(answer3Active.answer);

            answer4.SetText(answer4Active.answer);
        }
        catch { }
    }

}
