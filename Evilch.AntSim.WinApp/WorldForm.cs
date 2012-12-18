using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Evilch.AntSim.WinApp
{
    public partial class WorldForm : Form
    {
        public WorldForm()
        {
            InitializeComponent();
        }

        private World world = null;



        private void btnCreate_Click(object sender, EventArgs e)
        {
            world = new World(new Size(400, 200));
            world.OnAntAdd += (Ant a) =>
                              {
                                  dgvAntData.Rows.Add();
                              };

            world.CreateAnts(15);


            picSimAntWorld.Size = world.WorldSize;

            btnCreate.Enabled = false;
            btnPauseResume.Text = "Pause";
            btnPauseResume.Enabled = true;

            worldTimer.Start();
        }

        private void picSimAntWorld_Paint(object sender, PaintEventArgs e)
        {
            if (world == null)
            {
                e.Graphics.Clear(Color.Black);
                e.Graphics.DrawString("Empty", SystemFonts.DefaultFont, Brushes.White, picSimAntWorld.Location);
                return;
            }
            e.Graphics.DrawImageUnscaledAndClipped(world.Image, e.ClipRectangle);
        }

        private void worldTimer_Tick(object sender, EventArgs e)
        {
            if (world != null)
            {
                world.TimeGoes();
                for (int i = 0; i < world.TheHive.Ants.Count; i++)
                {
                    world.TheHive.Ants[i].FillData(dgvAntData.Rows[i], world);
                }
                picSimAntWorld.Refresh();
            }
        }

        private void btnPauseResume_Click(object sender, EventArgs e)
        {
            if (worldTimer.Enabled)
            {
                worldTimer.Stop();
                btnPauseResume.Text = "Resume";
                btnStep.Enabled = true;
            }
            else
            {
                worldTimer.Start();
                btnPauseResume.Text = "Pause";
                btnStep.Enabled = false;
            }
        }

        private void WorldForm_Load(object sender, EventArgs e)
        {
            btnPauseResume.Enabled = btnStep.Enabled = false;
            
        }

        private void btnStep_Click(object sender, EventArgs e)
        {
            worldTimer_Tick(sender, e);
        }

    }
}
