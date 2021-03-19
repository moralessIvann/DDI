using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Problema1 : MonoBehaviour
{
   int[] arregloNums = {12, 345, 2, 6, 7896, 99, 54};
    
    void Start()
    {
        buscaPardeDigitos(arregloNums);
    }

    void buscaPardeDigitos(int[] arregloNums)
    {
        int countDigit = 0, numDigit = 0, countNumParDigit = 0;
        
        for(int i=0; i<arregloNums.Length; i++)
        {
            numDigit = arregloNums[i];
            countDigit = 0;

            while(numDigit != 0)
            {
                countDigit++;
                numDigit = (numDigit/10); 
            }

            if(countDigit%2 == 0)
                countNumParDigit++;
        }
        Debug.Log("Elementos con número par del arreglo: " + countNumParDigit);
    }  
}
