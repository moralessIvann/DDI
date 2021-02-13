using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Prac1 : MonoBehaviour
{
    private void Start() {
    
    //int[] arreglo = {8,1,2,2,3}; //4,0,1,1,3
    int[] arreglo = {4,0,5,2,9}; //2,0,3,1,4
    FindNum(arreglo);

    }

    public void FindNum(int[] arreglo)
    {
        int cont = 0;

        for(int i=0; i<5; i++){				
            for(int j=0; j<5; j++){
                if(arreglo[i] > arreglo[j]){
                    cont++;
                }
            }
            Debug.Log(cont);
            cont = 0;
        }
    }

    
}
