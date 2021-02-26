using System;

// FROM : https://visualstudiomagazine.com/Articles/2020/05/06/data-clustering-k-means.aspx?Page=2

namespace K_Means_CS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nBegin k-means clustering demo\n");

            // real data likely to come from a text file or SQL
            double[][] rawData = new double[54][];
            
            rawData[0] = new double[] { 108.367011564212, 76.1335970785149, 50.9321363359708, 255 };
            rawData[1] = new double[] { 133.51094017094, 105.516923076923, 43.4844444444444, 255 };
            rawData[2] = new double[] { 154.332684404067, 122.446247025741, 49.528661042613, 255 };
            rawData[3] = new double[] { 123.117508997027, 53.3074636207166, 28.3093412611485, 255 };
            rawData[4] = new double[] { 126.971231300345, 100.449284892323, 40.6375143843498, 255 };
            rawData[5] = new double[] { 156.267692307692, 125.233136094675, 52.232426035503, 255 };
            rawData[6] = new double[] { 137.484723854289, 59.3719153936545, 31.3319623971798, 255 };
            rawData[7] = new double[] { 145.437027964891, 115.58950806287, 46.382527046336, 255 };
            rawData[8] = new double[] { 132.298438934803, 109.548438934803, 113.725895316804, 255 };

            rawData[9] = new double[] { 118.83917559234, 112.196364816618, 123.324569944823, 255 };
            rawData[10] = new double[] { 123.07640317367, 112.373200117543, 53.2101087275933, 255 };
            rawData[11] = new double[] { 140.912162162162, 129.258765522279, 60.3252373995617, 255 };
            rawData[12] = new double[] { 132.894969818913, 126.486116700201, 138.762977867203, 255 };
            rawData[13] = new double[] { 102.867563291139, 98.9498417721519, 108.085601265823, 255 };
            rawData[14] = new double[] { 122.527250828064, 113.015808491418, 48.2831978319783, 255 };
            rawData[15] = new double[] { 113.40671875, 108.2525, 125.78328125, 255 };
            rawData[16] = new double[] { 131.243827160494, 125.683256172839, 144.350115740741, 255 };
            rawData[17] = new double[] { 141.519046725464, 130.673109401389, 54.0835053480953, 255 };

            rawData[18] = new double[] { 141.166914850413, 72.6886422092866, 47.8900771625829, 255 };
            rawData[19] = new double[] { 132.554365610591, 125.399375278893, 139.738360850811, 255 };
            rawData[20] = new double[] { 147.537534246575, 140.017534246575, 155.811689497717, 255 };
            rawData[21] = new double[] { 158.987004219409, 81.7886919831224, 53.4486075949367, 255 };
            rawData[22] = new double[] { 36.1392857142857, 72.2660714285714, 50.6330357142857, 255 };
            rawData[23] = new double[] { 39.7474074074074, 79.3664814814815, 55.2848148148148, 255 };
            rawData[24] = new double[] { 150.691538974017, 143.546469020653, 161.214023984011, 255 };
            rawData[25] = new double[] { 141.026439645626, 70.5769656699889, 45.0181339977852, 255 };
            rawData[26] = new double[] { 158.688653451811, 79.1847231715653, 49.6737867395762, 255 };

            rawData[27] = new double[] { 114.516720171215, 103.748662386303, 45.3279828785447, 255 };
            rawData[28] = new double[] { 130.994333333333, 119.314166666667, 51.8138333333333, 255 };
            rawData[29] = new double[] { 113.24360670194, 93.1338183421517, 73.1688712522046, 255 };
            rawData[30] = new double[] { 115.632884479093, 105.494117647059, 47.0883061658398, 255 };
            rawData[31] = new double[] { 134.352418207681, 122.808143669986, 53.448613086771, 255 };
            rawData[32] = new double[] { 114.009298780488, 106.922713414634, 125.39131097561, 255 };
            rawData[33] = new double[] { 116.475198412698, 107.390022675737, 47.7701247165533, 255 };
            rawData[34] = new double[] { 133.873333333333, 123.503157894737, 53.8161403508772, 255 };
            rawData[35] = new double[] { 130.421803652968, 123.027587519026, 142.083333333333, 255 };

            rawData[36] = new double[] { 171.239202657807, 85.8012181616833, 54.7857142857143, 255 };
            rawData[37] = new double[] { 136.694824509221, 48.9369422962522, 50.6353361094587, 255 };
            rawData[38] = new double[] { 43.94625, 98.37125, 68.77625, 255 };
            rawData[39] = new double[] { 30.1701812800592, 43.6008139104698, 94.9840917499075, 255 };
            rawData[40] = new double[] { 35.1975, 55.75625, 122.89, 255 };
            rawData[41] = new double[] { 150.883125, 48.61125, 53.0475, 255 };
            rawData[42] = new double[] { 126.428042328042, 37.6767195767196, 42.0148148148148, 255 };
            rawData[43] = new double[] { 142.11375, 41.298125, 47.868125, 255 };
            rawData[44] = new double[] { 151.671341463415, 46.9378048780488, 53.1378048780488, 255 };

            rawData[45] = new double[] { 163.879591836735, 143.969795918367, 157.252653061224, 255 };
            rawData[46] = new double[] { 183.966411564626, 157.47193877551, 65.7040816326531, 255 };
            rawData[47] = new double[] { 35.5104166666667, 48.4958333333333, 96.8204166666667, 255 };
            rawData[48] = new double[] { 41.6679421768707, 80.0365646258503, 49.1313775510204, 255 };
            rawData[49] = new double[] { 147.128559102675, 70.6862237561116, 41.7339660626977, 255 };
            rawData[50] = new double[] { 184.506455643482, 86.1391087047064, 48.0583090379009, 255 };
            rawData[51] = new double[] { 178.921568627451, 83.0300120048019, 48.6854741896759, 255 };
            rawData[52] = new double[] { 144.834766862834, 46.000905387053, 48.1444092349479, 255 };
            rawData[53] = new double[] { 44.004625346901, 86.7289546716004, 54.7372802960222, 255 };

            Console.WriteLine("Raw unclustered data:\n");
            ShowData(rawData, 1, true, true);

            int numClusters = 6;
            Console.WriteLine("\nSetting numClusters to " + numClusters);

            int[] clustering = Cluster(rawData, numClusters); // this is it

            Console.WriteLine("\nK-means clustering complete\n");

            Console.WriteLine("Final clustering in internal form:\n");
            ShowVector(clustering, true);

            Console.WriteLine("Raw data by cluster:\n");
            ShowClustered(rawData, clustering, numClusters, 1);

            Console.WriteLine("\nEnd k-means clustering demo\n");
            Console.ReadLine();

        } // Main


    public static int[] Cluster(double[][] rawData, int numClusters)
    {
      // k-means clustering
      // index of return is tuple ID, cell is cluster ID
      // ex: [2 1 0 0 2 2] means tuple 0 is cluster 2, tuple 1 is cluster 1, tuple 2 is cluster 0, tuple 3 is cluster 0, etc.
      // an alternative clustering DS to save space is to use the .NET BitArray class
      double[][] data = Normalized(rawData); // so large values don't dominate

      bool changed = true; // was there a change in at least one cluster assignment?
      bool success = true; // were all means able to be computed? (no zero-count clusters)

      // init clustering[] to get things started
      // an alternative is to initialize means to randomly selected tuples
      // then the processing loop is
      // loop
      //    update clustering
      //    update means
      // end loop
      int[] clustering = InitClustering(data.Length, numClusters, 0); // semi-random initialization
      double[][] means = Allocate(numClusters, data[0].Length); // small convenience

      int maxCount = data.Length * 10; // sanity check
      int ct = 0;
      while (changed == true && success == true && ct < maxCount)
      {
        ++ct; // k-means typically converges very quickly
        success = UpdateMeans(data, clustering, means); // compute new cluster means if possible. no effect if fail
        changed = UpdateClustering(data, clustering, means); // (re)assign tuples to clusters. no effect if fail
      }
      // consider adding means[][] as an out parameter - the final means could be computed
      // the final means are useful in some scenarios (e.g., discretization and RBF centroids)
      // and even though you can compute final means from final clustering, in some cases it
      // makes sense to return the means (at the expense of some method signature uglinesss)
      //
      // another alternative is to return, as an out parameter, some measure of cluster goodness
      // such as the average distance between cluster means, or the average distance between tuples in 
      // a cluster, or a weighted combination of both
      return clustering;
    }

    private static double[][] Normalized(double[][] rawData)
    {
      // normalize raw data by computing (x - mean) / stddev
      // primary alternative is min-max:
      // v' = (v - min) / (max - min)

      // make a copy of input data
      double[][] result = new double[rawData.Length][];
      for (int i = 0; i < rawData.Length; ++i)
      {
        result[i] = new double[rawData[i].Length];
        Array.Copy(rawData[i], result[i], rawData[i].Length);
      }

      for (int j = 0; j < result[0].Length; ++j) // each col
      {
        double colSum = 0.0;
        for (int i = 0; i < result.Length; ++i)
          colSum += result[i][j];
        double mean = colSum / result.Length;
        double sum = 0.0;
        for (int i = 0; i < result.Length; ++i)
          sum += (result[i][j] - mean) * (result[i][j] - mean);
        double sd = sum / result.Length;
        for (int i = 0; i < result.Length; ++i)
          result[i][j] = (result[i][j] - mean) / sd;
      }
      return result;
    }

    private static int[] InitClustering(int numTuples, int numClusters, int randomSeed)
    {
      // init clustering semi-randomly (at least one tuple in each cluster)
      // consider alternatives, especially k-means++ initialization,
      // or instead of randomly assigning each tuple to a cluster, pick
      // numClusters of the tuples as initial centroids/means then use
      // those means to assign each tuple to an initial cluster.
      Random random = new Random(randomSeed);
      int[] clustering = new int[numTuples];
      for (int i = 0; i < numClusters; ++i) // make sure each cluster has at least one tuple
        clustering[i] = i;
      for (int i = numClusters; i < clustering.Length; ++i)
        clustering[i] = random.Next(0, numClusters); // other assignments random
      return clustering;
    }

    private static double[][] Allocate(int numClusters, int numColumns)
    {
      // convenience matrix allocator for Cluster()
      double[][] result = new double[numClusters][];
      for (int k = 0; k < numClusters; ++k)
        result[k] = new double[numColumns];
      return result;
    }

    private static bool UpdateMeans(double[][] data, int[] clustering, double[][] means)
    {
      // returns false if there is a cluster that has no tuples assigned to it
      // parameter means[][] is really a ref parameter

      // check existing cluster counts
      // can omit this check if InitClustering and UpdateClustering
      // both guarantee at least one tuple in each cluster (usually true)
      int numClusters = means.Length;
      int[] clusterCounts = new int[numClusters];
      for (int i = 0; i < data.Length; ++i)
      {
        int cluster = clustering[i];
        ++clusterCounts[cluster];
      }

      for (int k = 0; k < numClusters; ++k)
        if (clusterCounts[k] == 0)
          return false; // bad clustering. no change to means[][]

      // update, zero-out means so it can be used as scratch matrix 
      for (int k = 0; k < means.Length; ++k)
        for (int j = 0; j < means[k].Length; ++j)
          means[k][j] = 0.0;

      for (int i = 0; i < data.Length; ++i)
      {
        int cluster = clustering[i];
        for (int j = 0; j < data[i].Length; ++j)
          means[cluster][j] += data[i][j]; // accumulate sum
      }

      for (int k = 0; k < means.Length; ++k)
        for (int j = 0; j < means[k].Length; ++j)
          means[k][j] /= clusterCounts[k]; // danger of div by 0
      return true;
    }

    private static bool UpdateClustering(double[][] data, int[] clustering, double[][] means)
    {
      // (re)assign each tuple to a cluster (closest mean)
      // returns false if no tuple assignments change OR
      // if the reassignment would result in a clustering where
      // one or more clusters have no tuples.

      int numClusters = means.Length;
      bool changed = false;

      int[] newClustering = new int[clustering.Length]; // proposed result
      Array.Copy(clustering, newClustering, clustering.Length);

      double[] distances = new double[numClusters]; // distances from curr tuple to each mean

      for (int i = 0; i < data.Length; ++i) // walk thru each tuple
      {
        for (int k = 0; k < numClusters; ++k)
          distances[k] = Distance(data[i], means[k]); // compute distances from curr tuple to all k means

        int newClusterID = MinIndex(distances); // find closest mean ID
        if (newClusterID != newClustering[i])
        {
          changed = true;
          newClustering[i] = newClusterID; // update
        }
      }

      if (changed == false)
        return false; // no change so bail and don't update clustering[][]

      // check proposed clustering[] cluster counts
      int[] clusterCounts = new int[numClusters];
      for (int i = 0; i < data.Length; ++i)
      {
        int cluster = newClustering[i];
        ++clusterCounts[cluster];
      }

      for (int k = 0; k < numClusters; ++k)
        if (clusterCounts[k] == 0)
          return false; // bad clustering. no change to clustering[][]

      Array.Copy(newClustering, clustering, newClustering.Length); // update
      return true; // good clustering and at least one change
    }

    private static double Distance(double[] tuple, double[] mean)
    {
      // Euclidean distance between two vectors for UpdateClustering()
      // consider alternatives such as Manhattan distance
      double sumSquaredDiffs = 0.0;
      for (int j = 0; j < tuple.Length; ++j)
        sumSquaredDiffs += Math.Pow((tuple[j] - mean[j]), 2);
      return Math.Sqrt(sumSquaredDiffs);
    }

    private static int MinIndex(double[] distances)
    {
      // index of smallest value in array
      // helper for UpdateClustering()
      int indexOfMin = 0;
      double smallDist = distances[0];
      for (int k = 0; k < distances.Length; ++k)
      {
        if (distances[k] < smallDist)
        {
          smallDist = distances[k];
          indexOfMin = k;
        }
      }
      return indexOfMin;
    }
    static void ShowData(double[][] data, int decimals, bool indices, bool newLine)
    {
      for (int i = 0; i < data.Length; ++i)
      {
        if (indices) Console.Write(i.ToString().PadLeft(3) + " ");
        for (int j = 0; j < data[i].Length; ++j)
        {
          if (data[i][j] >= 0.0) Console.Write(" ");
          Console.Write(data[i][j].ToString("F" + decimals) + " ");
        }
        Console.WriteLine("");
      }
      if (newLine) Console.WriteLine("");
    } // ShowData

    static void ShowVector(int[] vector, bool newLine)
    {
      for (int i = 0; i < vector.Length; ++i)
        Console.Write(vector[i] + " ");
      if (newLine) Console.WriteLine("\n");
    }

    static void ShowClustered(double[][] data, int[] clustering, int numClusters, int decimals)
    {
      for (int k = 0; k < numClusters; ++k)
      {
        Console.WriteLine("===================");
        for (int i = 0; i < data.Length; ++i)
        {
          int clusterID = clustering[i];
          if (clusterID != k) continue;
          Console.Write(i.ToString().PadLeft(3) + " ");
          for (int j = 0; j < data[i].Length; ++j)
          {
            if (data[i][j] >= 0.0) Console.Write(" ");
            Console.Write(data[i][j].ToString("F" + decimals) + " ");
          }
          Console.WriteLine("");
        }
        Console.WriteLine("===================");
      } // k
    }
    }
}
