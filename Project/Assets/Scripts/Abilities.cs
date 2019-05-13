/********************************************************************************** Ability Ideas ***************************************************************************************
Player throws egg
	Throw egg player animation
	Costs some stamina

 Seal lions walk back and forth
	Probably in seallion script...
	Seal lion walking animation
****************************************************************************************************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    private static bool doubleJump = false;
    private static bool slide = false;

    private static bool fly = false;
    private static bool glide = false;

    private static bool eggThrow = false;

    private static bool enableDoubleJump = true;
    private static bool enableSlide = true;

    private static bool enableFly = true;
    private static bool enableGlide = true;

    private static bool enableEggThrow = true;

    public static bool GetDoubleJump()
    {
        return doubleJump;
    }

    public static bool GetSlide()
    {
        return slide;
    }

    public static bool GetFly()
    {
        return fly;
    }

    public static bool GetGlide()
    {
        return glide;
    }

    public static bool GetEggThrow()
    {
        return eggThrow;
    }

    public static void EnableDoubleJump()
    {
        enableDoubleJump = true;
    }

    public static void EnableSlide()
    {
        enableSlide = true;
    }

    public static void EnableFly()
    {
        enableFly = true;
    }

    public static void EnableGlide()
    {
        enableGlide = true;
    }

    public static void EnableEggThrow()
    {
        enableEggThrow = true;
    }

    public static void SetDoubleJump(bool canDoubleJump)
    {
        if(enableDoubleJump)
        {
            if(canDoubleJump)
            {
                doubleJump = true;
            }
            else
            {
                doubleJump = false;
            }
        }
    }

    public static void SetSlide(bool canSlide)
    {
        if(enableSlide)
        {
            if(canSlide)
            {
                slide = true;
            }
            else
            {
                slide = false;
            }
        }
    }

    public static void SetFly(bool canFly)
    {
        if(enableFly)
        {
            if (canFly)
            {
                fly = true;
            }
            else
            {
                fly = false;
            }
        }
    }

    public static void SetGlide(bool canGlide)
    {
        if(enableGlide)
        {
            if (canGlide)
            {
                glide = true;
            }
            else
            {
                glide = false;
            }
        }
    }

    public static void SetEggThrow(bool canThrow)
    {
        if(enableEggThrow)
        {
            if(canThrow)
            {
                eggThrow = true;
            }
            else
            {
                eggThrow = false;
            }
        }
    }
}
