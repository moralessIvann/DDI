using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prac2 : MonoBehaviour
{
    string[] studentsNames = {"Alberto","Berenice","Julian","Martin","Peter","Sebastian"};
    //string nme = "Peter";
    string nme = "John";
    
    // Start is called before the first frame update
    void Start()
    {
        searchName(studentsNames,nme);
        Debug.Log((searchName(studentsNames,nme)) ? "True":"False");
    }

     private bool searchName(string[] studentsNames, string nme)
    {
        foreach (var item in studentsNames)
        {
            if(item == nme)
            {
                return true; 
            }
        }
        return false;
    }
}
