using System.Collections.Generic;
using System;


public class NN {

    private int[] layers;
    private float[][] neruons;
    private float[][][] weights;

    private Random random;

    public NN(int[] layers)
    {
        this.layers = new int[layers.Length];
        for (int i = 0; i < layers.Length; i++)
        {
            this.layers[i] = layers[i];
        }

        random = new Random(System.DateTime.Today.Millisecond);

        InitNeurons();
        InitWeights();
    }

    private void InitNeurons()
    {
        List<float[]> neuronsList = new List<float[]>();

        for (int i = 0; i < layers.Length; i++)
        {
            neuronsList.Add(new float[layers[i]]);
        }

        neruons = neuronsList.ToArray();
    }
    private void InitWeights()
    {
        List<float[][]> weightsList = new List<float[][]>();

        for(int i = 1; i < layers.Length; i++)
        {
            List<float[]> layerWeightList = new List<float[]>();

            int neuronsInPreviousLayer = layers[i - 1];

            for(int j = 0; j < neruons[i].Length; j++)
            {
                float[] neuronsWeights = new float[neuronsInPreviousLayer];

                for(int k = 0; k < neuronsInPreviousLayer; k++)
                {
                    neuronsWeights[k] = (float)random.NextDouble() - 0.5f;
                }

                layerWeightList.Add(neuronsWeights);
            }

            weightsList.Add(layerWeightList.ToArray());
        }

        weights = weightsList.ToArray();
    }

    public float[] feedForward(float[] inputs)
    {
        for(int i = 0; i)
    }
}
