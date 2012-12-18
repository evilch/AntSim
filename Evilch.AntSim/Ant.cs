using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Evilch.AntSim
{

    public class Ant
    {
        public static Size[] DirectionArray = new []{new Size(0, -1), new Size(1,-1), new Size(1, 0), new Size(1, 1)
            , new Size(0, 1), new Size(-1, 1), new Size(-1, 0), new Size(-1, -1),};

        internal Ant(AntHive hive, World world)
        {
            DirectFactor = world.RandomGen.Next(25, 99)*0.01;
            HiveBelong = hive;
            Direction = -1;

            AntPosition = hive.HivePosition;
            DistanceFromHive = 0.0;
        }

        public double DirectFactor { get; private set; }
        public Point AntPosition { get; private set; }

        public AntHive HiveBelong { get; private set; }

        public bool Loaded { get; private set; }

        public string AntName { get; internal set; }

        /// <summary>
        /// 7 0 1
        /// 6 * 2
        /// 5 4 3
        /// </summary>
        public int Direction { get; private set; }


        public double DistanceFromHive { get; private set; }

        public string LastDecision { get; private set; }
        public void FillData(DataGridViewRow row, World world)
        {
            row.SetValues(
                    AntName,
                    DirectFactor,
                    string.Format("{0}, {1}", AntPosition.X, AntPosition.Y),
                    world.hiveSmell[AntPosition.X, AntPosition.Y],
                    world.foodSmell[AntPosition.X, AntPosition.Y],
                    Loaded,
                    DistanceFromHive,
                    LastDecision);
        }

        public void NextStep(World world)
        {
            // make choice
            Point nextPoint = AntPosition;
            if (Loaded)
            {
                nextPoint = SniffAround(
                        world.WorldSize,
                        AntPosition,
                        world.hiveSmell,
                        (value1, value2) => { return value1 < value2; },
                        world.hiveSmell[AntPosition.X, AntPosition.Y]);
                LastDecision = "Ls Hive";
            }
            else
            {
                nextPoint = SniffAround(
                        world.WorldSize,
                        AntPosition,
                        world.foodSmell,
                        (value1, value2) => { return value1 > value2; },
                        world.foodSmell[AntPosition.X, AntPosition.Y]);
                LastDecision = "Gt Food";
                if (nextPoint == AntPosition)
                {
                    nextPoint = SniffAround(
                            world.WorldSize,
                            AntPosition,
                            world.hiveSmell,
                            (value1, value2) => { return value1 > value2; },
                            world.hiveSmell[AntPosition.X, AntPosition.Y]);
                    LastDecision = "Gt Hive";
                }
            }

            if (nextPoint == AntPosition)
            {
                do
                {
                    if (Direction < 0 || Loaded)
                    {
                        Direction = world.RandomGen.Next(8);
                        LastDecision = "Random";
                    }
                    else
                    {
                        if (world.RandomGen.NextDouble() > DirectFactor)
                        {
                            Direction = (Direction + world.RandomGen.Next(-1, 2) + 8)%8;
                            LastDecision = "Random change";
                        }
                        else
                        {
                            LastDecision = "Keep";
                        }
                    }
                    nextPoint = Point.Add(AntPosition, DirectionArray[Direction]);
                } while (nextPoint.X < 0 || nextPoint.X >= world.WorldSize.Width
                         || nextPoint.Y < 0 || nextPoint.Y >= world.WorldSize.Height);
            }

            //Debug.WriteLine("Ant {0}: {1} -> {2}", AntName, AntPosition, nextPoint);

            // leave trace
            if(Loaded)
            {
                world.foodSmell[AntPosition.X, AntPosition.Y] = Math.Min(
                        world.foodSmell[AntPosition.X, AntPosition.Y] + World.FarFarAwayValue*0.8, World.FarFarAwayValue);
            }
            else
            {
                world.hiveSmell[AntPosition.X, AntPosition.Y] = Math.Min(world.hiveSmell[AntPosition.X, AntPosition.Y], DistanceFromHive);
            }

            // move
            AntPosition = nextPoint;
            DistanceFromHive = Math.Min(DistanceFromHive + 2.0, world.hiveSmell[AntPosition.X, AntPosition.Y]);

            // moved
            foreach (Rectangle food in world.Foods)
            {
                Loaded |= food.Contains(AntPosition);
            }

            if (Loaded && (AntPosition == HiveBelong.HivePosition))
            {
                HiveBelong.FoodStock += 1.0;
                this.Loaded = false;
            }


        }


        private Point SniffAround(Size worldSize, Point position, double[,] smell, Func<double, double, bool> v1Betterv2Func, double initValue = 0.0)
        {
            double value = initValue;
            Point result = position;

            for (int i = 0; i < 7;i++ )
            {
                Point r = Point.Add(position, DirectionArray[i]);
                if(r.X < 0 || r.X >= worldSize.Width
                    || r.Y < 0 || r.Y >= worldSize.Height)
                {
                    continue;
                }

                if(v1Betterv2Func(smell[r.X, r.Y], value))
                {
                    result = r;
                    value = smell[r.X, r.Y];
                }
            }
            return result;
        }

        


    }
}
