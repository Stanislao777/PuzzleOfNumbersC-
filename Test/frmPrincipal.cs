using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Game
{
    public partial class frmPrincipal : Form
    {
        private Puzzle puzzle;
        private Chronometer chronometer;

        public frmPrincipal()
        {
            InitializeComponent();
            puzzle = new Puzzle(grpMain);
            chronometer = new Chronometer(timer1);
        }

        private void updateMovesNumber()
        {
            lblNoOfMoves.Text = "Número de movimientos : " + puzzle.getMovesNumber();
        }

        private void initializePuzzle()
        {
            puzzle.initializePuzzle();
            updateMovesNumber();
        }

        private void swapNumbers(object sender, EventArgs e)
        {
            puzzle.moveElement((Button)sender);
            updateMovesNumber();
            if (puzzle.checkWin())
            {
                chronometer.stop();
                MessageBox.Show("Felicidades ! Lo hiciste " + puzzle.getMovesNumber() + " movimientos");
            }
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            chronometer.start();
            initializePuzzle();
            btnNewGame.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            chronometer.addSecond();
            lblCronometro.Text = chronometer.getTimeString();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            chronometer.stop();

            const string message = "Estas seguro de cerrar el juego?";
            const string caption = "Cerrar juego";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            
            result = MessageBox.Show(message, caption, buttons);
            if (result == DialogResult.No)
            {
                chronometer.start();
            }
            else
            {
                Close();                
            }
        }

        // ===========================================================================
        int m, mx, my;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            m = 1;
            mx = e.X;
            my = e.Y;
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (m == 1)
            {
                this.SetDesktopLocation(MousePosition.X - mx, MousePosition.Y - my);
            }
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            m = 0;
        }
        // ===========================================================================

    }
}
