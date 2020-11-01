using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dragon_Stones.TerrainPainting
{
    public class Terrain_Painter : MonoBehaviour
    {
        [System.Serializable]
        public class SplatHeights
        {
            public int texIndex;
            public int startHeight;
        }

        public SplatHeights[] splatHeights;

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
                    float terrainHeight = terrainData.GetHeight(j, i);

                    float[] splat = new float[splatHeights.Length];

                    for (int k = 0; k < splatHeights.Length; k++)
                    {
                        if (terrainHeight >= splatHeights[k].startHeight)
                        {
                            splat[k] = 1;
                        }
                    }

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
