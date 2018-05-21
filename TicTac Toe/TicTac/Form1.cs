using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTac
{
    public partial class Form1 : Form
    {
        private bool player1 = true,player2=false;
        private List<Button> btnList;
        public Form1()
        {
            InitializeComponent();
            this.btnList = new List<Button>();
            this.btnList.Add(this.button1);
            this.btnList.Add(this.button2);
            this.btnList.Add(this.button3);
            this.btnList.Add(this.button6);
            this.btnList.Add(this.button5);
            this.btnList.Add(this.button4);
            this.btnList.Add(this.button9);
            this.btnList.Add(this.button8);
            this.btnList.Add(this.button7);
            this.GamePanel.Hide();
            this.StartPanel.Show();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
           
            this.GamePanel.Show();
            //this.StartPanel.Hide();
            this.lblShowName.Text = this.txtBox1.Text+" ( X ) ";
            
        }

        private void Btn_clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            //CheckPlayer1();
            //CheckPlayer2();
            if (player1)
            {
                button.Text = "X";
                button.Enabled = false;
                button.Focus();
                button.BackColor = Color.LightYellow;
                this.player1 = false;
                this.player2 = true;
                this.lblShowName.Text = txtBox2.Text + " ( O ) ";
                if(this.Draw())
                {
                    this.lblShowName.Text = "Match Draw";
                    MessageBox.Show("Match Draw", "Game over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (this.CheckPlayer1())
                {
                    this.lblShowName.Text = this.txtBox1.Text + " win";
                    MessageBox.Show(this.txtBox1.Text + " win", "Game over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                }
                
            }
            else if (player2)
            {
                button.Text = "O";
                button.Enabled = false;
                button.Focus();
                button.BackColor = Color.LightYellow;
                this.player2 = false;
                this.player1 = true;
                this.lblShowName.Text = txtBox1.Text + " ( X ) ";
                if (this.Draw())
                {
                    this.lblShowName.Text = "Match Draw";
                    MessageBox.Show("Match Draw", "Game over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (this.CheckPlayer2())
                {
                    this.lblShowName.Text = this.txtBox2.Text + " win";
                    MessageBox.Show(this.txtBox2.Text + " win", "Game over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.GamePanel.Hide();
            this.StartPanel.Show();
            Repeat();
        }

        private void txtBox1_MouseClick(object sender, MouseEventArgs e)
        {
            this.txtBox1.Text = string.Empty;
            this.txtBox1.ForeColor = Color.Black;
        }

        private void txtBox2_MouseClick(object sender, MouseEventArgs e)
        {
            this.txtBox2.Text = string.Empty;
            this.txtBox2.ForeColor = Color.Black;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Repeat()
        {
            foreach (Button btn in btnList)
            {
                btn.Text = string.Empty;
                btn.BackColor = Color.White;
                btn.Enabled = true;
            }
            player1 = true; player2 = false;
            //this.lblShowName.Text = this.txtBox1.Text;
            this.txtBox1.ForeColor = Color.Silver;
            this.txtBox2.ForeColor = Color.Silver;
            this.txtBox1.Text = "Player 1";
            this.txtBox2.Text = "Player 2";
        }

        private bool CheckPlayer1()
        {
            if(button1.Text=="X"&& button2.Text == "X"&& button3.Text == "X") { GetPath( ref button1, ref button2, ref button3); return true; }
            else if (button4.Text == "X" && button5.Text == "X" && button6.Text == "X") { GetPath(ref button4,ref button5, ref button6); return true; }
            else if (button7.Text == "X" && button8.Text == "X" && button9.Text == "X") { GetPath(ref button7,ref button8,ref button9); return true; }

            else if (button1.Text == "X" && button5.Text == "X" && button9.Text == "X") { GetPath(ref button1,ref button5,ref button9); return true; }           
            else if (button3.Text == "X" && button5.Text == "X" && button7.Text == "X") { GetPath(ref button3, ref button5, ref button7); return true; }
          
            else if (button1.Text == "X" && button4.Text == "X" && button7.Text == "X") { GetPath(ref button1,ref button4, ref button7); return true; }
            else if (button2.Text == "X" && button5.Text == "X" && button8.Text == "X") { GetPath(ref button2,ref button5,ref button8); return true; }
            else if (button3.Text == "X" && button6.Text == "X" && button9.Text == "X") { GetPath(ref button3,ref button6, ref button9); return true; }
            return false;
        }

        private bool CheckPlayer2()
        {
            if (button1.Text == "O" && button2.Text == "O" && button3.Text == "O") { GetPath(ref button1, ref button2, ref button3); return true; }
            else if (button4.Text == "O" && button5.Text == "O" && button6.Text == "O") { GetPath(ref button4, ref button5, ref button6); return true; }
            else if (button7.Text == "O" && button8.Text == "O" && button9.Text == "O") { GetPath(ref button7, ref button8, ref button9); return true; }

            else if (button1.Text == "O" && button5.Text == "O" && button9.Text == "O") { GetPath(ref button1, ref button5, ref button9); return true; }
            else if (button3.Text == "O" && button5.Text == "O" && button7.Text == "O") { GetPath(ref button3, ref button5, ref button7); return true; }

            else if (button1.Text == "O" && button4.Text == "O" && button7.Text == "O") { GetPath(ref button1, ref button4, ref button7); return true; }
            else if (button2.Text == "O" && button5.Text == "O" && button8.Text == "O") { GetPath(ref button2, ref button5, ref button8); return true; }
            else if (button3.Text == "O" && button6.Text == "O" && button9.Text == "O") { GetPath(ref button3, ref button6, ref button9); return true; }
            return false;
        }
        private void GetPath( ref Button button1,ref Button button2,ref Button button3 )
        {
            button1.BackColor = Color.DarkRed;
            button2.BackColor = Color.DarkRed;
            button3.BackColor = Color.DarkRed;
            foreach (Button item in btnList)
            {
                item.Enabled = false;
            }
        }

        private bool Draw()
        {
            foreach (Button item in btnList)
            {
                if (item.Enabled) { return false; }
            }
            return true;
        }
    }
}
