using Encog.Neural.Networks;
using Encog.Neural.Pattern;
using Encog.Engine.Network.Activation;
using Encog.ML.Train;
using Encog.ML.Genetic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Encog.ML;

namespace PondGame2.Source.Training
{
    class MainTrainer
    {
        //Layers
        static int inputs = 8;
        static int outputs = 2;
        static int[] hid = new int[] { 8 };

        static IMLTrain sharkTrainer, fishTrainer;

        public static BasicNetwork shark, fish;

        public static void setup()
        {
            
        }

        public static void train(int ticks)
        {
            
        }
        
        public static BasicNetwork CreateNetwork(int start, int end, params int[] layers)
        {
            var pattern = new FeedForwardPattern { InputNeurons = start };

            foreach (int i in layers)
                pattern.AddHiddenLayer(i);

            pattern.OutputNeurons = end;
            pattern.ActivationFunction = new ActivationTANH();
            var network = (BasicNetwork)pattern.Generate();
            network.Reset();
            return network;
        }
    }
}
