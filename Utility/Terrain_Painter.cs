using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dragon_Stones.TerrainPainting
{
    public class Terrain_Painter : MonoBehaviour
    {
        //Coordinates for where the splat on terrain should be as well as the index of the terrain layer
        [System.Serializable]
        public class SplatHeights
        {
            public int texIndex;
            public int startHeight;
            public int overlap;
        }

        public SplatHeights[] splatHeights;
        public float jNoise, iNoise, xClamp, yClamp;

        private void Normalize(float[] v)
        {
            float total = 0f;

            for (int i = 0; i < v.Length; i++)
            {
                total += v[i];
            }

            for (int i = 0; i < v.Length; i++)
            {
                v[i] /= total;
            }
        }

        public float Map(float val, float sMin, float sMax, float mMin, float mMax)
        {
            return (val - sMin) * (mMax - mMin) / (sMax - sMin) + mMin;
        }

        private void Start()
        {
            //Get this terrains data
            TerrainData terrainData = this.GetComponent<Terrain>().terrainData;

            //Create 3d float to store data as well as point to Terrain Layers
            float[,,] splatData = new float[terrainData.alphamapWidth, terrainData.alphamapHeight, terrainData.alphamapLayers];

            //Create a 3d loop to paste layer data at appropriate heights and blend
            for (int i = 0; i < terrainData.alphamapHeight; i++)
            {
                for (int j = 0; j < terrainData.alphamapWidth; j++)
                {
                    //get terrain height at each x and y 
                    float terrainHeight = terrainData.GetHeight(i, j);

                    float[] splat = new float[splatHeights.Length];

                    for (int k = 0; k < splatHeights.Length; k++)
                    {
                        float thisNoise = Map(Mathf.PerlinNoise(j * jNoise, i * iNoise), 0, 1, xClamp, yClamp);

                        float thisHeightStart = splatHeights[k].startHeight * thisNoise - splatHeights[k].overlap * thisNoise;
                        
                        float nextHeightStart = 0f;

                        if (k != splatHeights.Length - 1)
                        {
                            nextHeightStart = splatHeights[k + 1].startHeight * thisNoise + splatHeights[k + 1].overlap * thisNoise;
                        }

                        if (k == splatHeights.Length - 1 && terrainHeight >= thisHeightStart)
                        {
                            splat[k] = 1;
                        }
                        else if (terrainHeight >= thisHeightStart && terrainHeight <= nextHeightStart)
                        {
                            splat[k] = 1;
                        }
                    }

                    Normalize(splat);

                    for (int l = 0; l < splatHeights.Length; l++)
                    {
                        splatData[j, i, l] = splat[l];
                    }
                }
            }

            terrainData.SetAlphamaps(0, 0, splatData);
        }
    }
}
