using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Problema2 : MonoBehaviour
{
    //int[] arregloNums = {1, 2, 1, 2, 8, 8, 4};
    int[] arregloNums = {4, 1, 2, 1, 2};
    
    void Start()
    {
        busquedaElemntoUnico(arregloNums);
    }

    void busquedaElemntoUnico(int[] arregloNums)
    {  
        int result = 0;
        //Array.Sort(arregloNums); 
        
        for(int i=0; i<arregloNums.Length; i++)
        {
            result ^= arregloNums[i]; //XOR to all elements in array
        }
        Debug.Log(result);
    }
}


/*
traversing
O(n) complexity
    4 ^ 1 = 5
    5 ^ 2 = 7
    7 ^ 1 = 6
    6 ^ 2 = 4
*/