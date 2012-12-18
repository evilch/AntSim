using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Evilch.AntSim
{
    public class AntHive
    {
        public Point HivePosition { get; private set; }

        public double FoodStock { get; internal set; }

        public List<Ant> Ants { get; private set; }

        public AntHive(Point position)
        {
            HivePosition = position;
            Ants = new List<Ant>();
        }
    }
}
