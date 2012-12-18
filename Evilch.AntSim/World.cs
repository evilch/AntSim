using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;

namespace Evilch.AntSim
{
    public class World
    {
        public static int DistanceTo255(double distance)
        {
            distance = Math.Min(distance, FarFarAwayValue);
            return (int)(((FarFarAwayValue - distance)/FarFarAwayValue)*255);
        }

        public event Action<Ant> OnAntAdd;
 
        public const double FarFarAwayValue = 1000.0;

        public Random RandomGen = new Random();

        public AntHive TheHive { get; private set; }

        public Size WorldSize { get; private set; }

        public ulong IterationCount { get; private set; }

        public World(Size size)
        {
            IterationCount = 0;
            WorldSize = size;
            hiveSmell = new double[size.Width, size.Height];
            foodSmell = new double[size.Width, size.Height];
            for (int x = 0; x < WorldSize.Width;x++ )
                for (int y = 0; y < WorldSize.Height; y++)
                {
                    hiveSmell[x, y] = FarFarAwayValue;
                    foodSmell[x, y] = 0;
                }

            Foods = new List<Rectangle>();

            TheHive = new AntHive(new Point(
                RandomGen.Next((int)(size.Width*0.25), (int)(size.Width*0.75)),
                RandomGen.Next((int)(size.Height*0.25), (int)(size.Height*0.75))));


            int foodCount = RandomGen.Next(5, 11);
            for (int i = 0; i < foodCount; i++)
            {
                AddFood();
            }
        }

        public void CreateAnts(int count)
        {
            foreach (int n in Enumerable.Range(1, count))
            {
                AddAnt();
            }
        }

        private void AddAnt()
        {
            var ant = new Ant(TheHive, this) {AntName = TheHive.Ants.Count.ToString("D02")};
            TheHive.Ants.Add(ant);
            if (OnAntAdd != null)
                OnAntAdd(ant);
        }

        internal List<Rectangle> Foods { get; private set; }

        public void AddFood()
        {
            Foods.Add(new Rectangle(RandomGen.Next(WorldSize.Width-10), RandomGen.Next(WorldSize.Height-10), RandomGen.Next(3, 10), RandomGen.Next(3, 10)));
        }

        internal double[,] hiveSmell;
        internal double[,] foodSmell;

        private static Font _infoFont = null;
        public static Font InfoFont
        {
            get
            {
                if (_infoFont == null)
                {
                    _infoFont = new Font(SystemFonts.DefaultFont.FontFamily, 7);
                }
                return _infoFont;
            }
        }

        public Image Image
        {
            get
            {
                Bitmap bmp = new Bitmap(WorldSize.Width, WorldSize.Height, PixelFormat.Format32bppArgb);

                using (Graphics graph = Graphics.FromImage(bmp))
                {
                    #region clear background
                    graph.Clear(Color.Olive);
                    #endregion

                    #region draw smells
                    for (int x = 0; x < WorldSize.Width; x++)
                        for (int y = 0; y < WorldSize.Height; y++)
                        {

                            graph.FillRectangle(
                                    new SolidBrush(
                                            Color.FromArgb(
                                                    DistanceTo255(hiveSmell[x, y]),255-DistanceTo255(foodSmell[x, y]),
                                                    0))
                                    ,
                                    new Rectangle(x, y, 1, 1));
                        }
                    #endregion

                    #region draw food

                    foreach (var food in Foods)
                    {
                        graph.DrawRectangle(Pens.Green, food);
                    }
                    #endregion

                    #region draw hive
                    graph.DrawEllipse(Pens.Gold, new Rectangle(TheHive.HivePosition - new Size(2, 2), new Size(4, 4)));
                    graph.FillEllipse(Brushes.Goldenrod, new Rectangle(TheHive.HivePosition - new Size(2, 2), new Size(4, 4)));
                    #endregion

                    #region draw ants
                    foreach (Ant ant in this.TheHive.Ants)
                    {
                        if (ant.Loaded)
                        {
                            graph.DrawLine(Pens.LimeGreen, ant.AntPosition.X - 2, ant.AntPosition.Y, ant.AntPosition.X + 2, ant.AntPosition.Y);
                            graph.DrawLine(Pens.LimeGreen, ant.AntPosition.X, ant.AntPosition.Y - 2, ant.AntPosition.X, ant.AntPosition.Y + 2);
                        }
                        else
                        {
                            graph.FillRectangle(Brushes.Yellow,
                                    new Rectangle(ant.AntPosition, new Size(1, 1)));
                        }
                        var nameSize = graph.MeasureString(ant.AntName, InfoFont);
                        graph.DrawString(ant.AntName, InfoFont, Brushes.Khaki, ant.AntPosition.X - nameSize.Width*0.5f, ant.AntPosition.Y - nameSize.Height -1.2f);
                    }
                    #endregion

                    #region Draw info
                    DrawInfo(graph);
                    #endregion
                }

                return bmp;

            }
        }

        private void DrawInfo(Graphics graph)
        {
            string worldInfo;
            float y = 1;
            SizeF infoSize;

            worldInfo = string.Format("Food Stock: {0}\n", TheHive.FoodStock);
            infoSize = graph.MeasureString(worldInfo, InfoFont);
            graph.DrawString(worldInfo, InfoFont, Brushes.Wheat, 1, y);
            y += infoSize.Height + 1;

            worldInfo = string.Format("Ants: {0}", TheHive.Ants.Count);
            infoSize = graph.MeasureString(worldInfo, InfoFont);
            graph.DrawString(worldInfo, InfoFont, Brushes.Wheat, 1, y);
            y += infoSize.Height + 1;

            worldInfo = string.Format("Iterations: {0,8:D}", IterationCount);
            infoSize = graph.MeasureString(worldInfo, InfoFont);
            graph.DrawString(worldInfo, InfoFont, Brushes.Wheat, 1, y);
            y += infoSize.Height + 1;
        }

        public void TimeGoes()
        {
            for (int x = 0; x < WorldSize.Width; x++)
            {
                for (int y = 0; y < WorldSize.Height; y++)
                {
                    foodSmell[x, y] = Math.Max(foodSmell[x, y] - 0.1, 0.0);
                    hiveSmell[x, y] = Math.Min(hiveSmell[x, y]*1.001, FarFarAwayValue);
                }
            }

            foreach (Ant ant in this.TheHive.Ants)
            {
                ant.NextStep(this);
            }

            while (TheHive.FoodStock >= 5)
            {
                CreateAnts(1);
                TheHive.FoodStock -= 5;
            }

            IterationCount++;
        }
    }
}
