﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScottPlotTests
{
    [TestClass]
    public class Layout
    {
        string outputPath;
        readonly int width = 640;
        readonly int height = 480;

        public Layout()
        {
            this.outputPath = System.IO.Path.GetFullPath("manualTests");
            if (!System.IO.Directory.Exists(this.outputPath))
                System.IO.Directory.CreateDirectory(this.outputPath);
        }

        [TestMethod]
        public void Test_Layout()
        {
            string name = System.Reflection.MethodBase.GetCurrentMethod().Name.Replace("Figure_", "");
            string fileName = System.IO.Path.GetFullPath($"{outputPath}/{name}.png");

            int pointCount = 50;
            double[] dataXs = ScottPlot.DataGen.Consecutive(pointCount);
            double[] dataSin = ScottPlot.DataGen.Sin(pointCount);
            double[] dataCos = ScottPlot.DataGen.Cos(pointCount);

            var plt = new ScottPlot.Plot(width, height);
            plt.PlotScatter(dataXs, dataSin);
            plt.PlotScatter(dataXs, dataCos);

            plt.Title("Very Complicated Data");
            plt.XLabel("Experiment Duration");
            plt.YLabel("Productivity");

            if (outputPath != null) plt.SaveFig(fileName); else Console.WriteLine(plt.GetHashCode());
            Console.WriteLine($"Saved: {fileName}");
        }
    }
}
