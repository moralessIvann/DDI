using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Prac3 : MonoBehaviour
{
    int[] nums = {6,7,9,5,2,3};
    //int target = 7;
    int target = 15;
    
    void Start()
    {
        string[] strArray = Array.ConvertAll((SumaDos(nums,target)), ele => ele.ToString());
        Debug.Log(string.Join(",", strArray));
    }

    public int[] SumaDos(int[] nums, int target)
    {   
        int[] outArray = new int[2];

        for(int i = 0; i<nums.Length; i++)
        {
            for(int j = 0; j<nums.Length; j++)
            {
                if(nums[i] + nums[j] == target)
                {
                    outArray[0] = i;
                    outArray[1] = j;
                    break;
                }
            }
        }
        return outArray;
    }
}
