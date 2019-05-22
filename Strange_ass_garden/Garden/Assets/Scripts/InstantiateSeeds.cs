using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateSeeds : MonoBehaviour
{
    public GameObject[] publicSeeds;

    private void Awake()
    {
        for (int i = 0; i < 100; i++)
        {
            if (i < publicSeeds.Length)
            {
                GameManager.UpdateSeeds(i, publicSeeds[i]);
            }
            else
            {
                GameManager.UpdateSeeds(i, publicSeeds[0]);
            }
        }

        for (int j = 0; j < 10; j++)
        {
            float random = Random.Range(1f, publicSeeds.Length + 1);

            if (random == publicSeeds.Length + 1f)
            {
                random = publicSeeds.Length;
            }

            GameManager.UpdateStartingSeeds(j, (int)random);
        }

        for (int k = 0; k < 10; k++)
        {
            switch (GameManager.GetStartingSeeds(k))
            {
                case 1:
                    GameManager.UpdatePizzaSeeds(1);
                    break;

                case 2:
                    GameManager.UpdateiPhoneSeeds(1);
                    break;

                case 3:
                    GameManager.UpdateVinylSeeds(1);
                    break;

                case 4:
                    GameManager.UpdateMilkSeeds(1);
                    break;

                default:
                    break;
            }
        }
    }
}
