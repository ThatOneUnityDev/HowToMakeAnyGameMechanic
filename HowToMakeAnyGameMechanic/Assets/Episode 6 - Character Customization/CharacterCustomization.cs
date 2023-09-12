using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCustomization : MonoBehaviour
{
    [SerializeField] private Transform[] eyeOptions;
    [SerializeField] private Transform[] hairOptions;
    [SerializeField] private Transform[] coatOptions;
    [SerializeField] private Transform[] pantsOptions;
    [SerializeField] private Transform[] shoeOptions;

    private int eyeSelected;
    private int hairSelected;
    private int coatSelected;
    private int pantsSelected;
    private int shoesSelected;

    public void ChangeEyeSelection()
    {
        for (int i = 0; i < eyeOptions.Length; i++)
        {
            eyeOptions[i].gameObject.SetActive(false);
        }

        if(eyeSelected+1 >= eyeOptions.Length)
        {
            eyeSelected =0;
        }
        else
        {
            eyeSelected++;
        }
        eyeOptions[eyeSelected].gameObject.SetActive(true);
       
    }

    public void ChangeHairSelection()
    {
        for (int i = 0; i < hairOptions.Length; i++)
        {
            hairOptions[i].gameObject.SetActive(false);
        }

        if (hairSelected + 1 >= hairOptions.Length)
        {
            hairSelected = 0;
        }
        else
        {
            hairSelected++;
        }
        hairOptions[hairSelected].gameObject.SetActive(true);

    }

    public void ChangeCoatSelection()
    {
        for (int i = 0; i < coatOptions.Length; i++)
        {
            coatOptions[i].gameObject.SetActive(false);
        }

        if (coatSelected + 1 >= coatOptions.Length)
        {
            coatSelected = 0;
        }
        else
        {
            coatSelected++;
        }
        coatOptions[coatSelected].gameObject.SetActive(true);

    }

    public void ChangePantsSelection()
    {
        for (int i = 0; i < pantsOptions.Length; i++)
        {
            pantsOptions[i].gameObject.SetActive(false);
        }

        if (pantsSelected + 1 >= pantsOptions.Length)
        {
            pantsSelected = 0;
        }
        else
        {
            pantsSelected++;
        }
        pantsOptions[pantsSelected].gameObject.SetActive(true);

    }

    public void ChangeShoesSelection()
    {
        for (int i = 0; i < shoeOptions.Length; i++)
        {
            shoeOptions[i].gameObject.SetActive(false);
        }

        if (shoesSelected + 1 >= shoeOptions.Length)
        {
            shoesSelected = 0;
        }
        else
        {
            shoesSelected++;
        }
        shoeOptions[shoesSelected].gameObject.SetActive(true);

    }
}
