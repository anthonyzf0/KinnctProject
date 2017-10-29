using Encog.Engine.Network.Activation;
using Encog.ML.Data.Basic;
using Encog.Neural.Networks;
using Encog.Neural.Networks.Layers;
using Encog.Neural.Networks.Training.Propagation.Resilient;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PondGame2.Source.Training
{
    class MainDataSet
    {
        public static BasicNetwork setup(BasicNetwork net) {

            Pond.Pond pond = new Pond.Pond(null, null);

            List<double[]> inputData = new List<double[]>();
            List<double[]> outputData = new List<double[]>();

            for (int i = 0; i < 600; i++)
            {
                double[] d = new double[8];
                BasicMLData data = pond.getInputData();

                for (int j = 0; j < 8; j++)
                    d[j] = data[j];

                Vector2 vect = pond.getLineTarget();
                double[] e = new double[2]{ (double)vect.X, (double)vect.Y };

                inputData.Add(d);
                outputData.Add(e);

            }

            BasicMLDataSet trainingSet = new BasicMLDataSet(inputData.ToArray(), outputData.ToArray());

            ResilientPropagation train = new ResilientPropagation(net, trainingSet);

            int epoch = 0;
            do{
                train.Iteration();
                Console.WriteLine("Epoch #" + epoch + " Error:" + train.Error);
                epoch++;
            } while (train.Error > 0.01);

            return net;

        }
    }
}
