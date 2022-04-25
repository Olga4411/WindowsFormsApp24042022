using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp24042022
{
    public partial class Parent : Form
    {
        Color c;
        public Parent()
        {
            InitializeComponent();
            //базовый цвет
            //заполним текущий цвет формы
            c = this.BackColor;
            //настроим изображение меню
            menuStrip_en.Visible = false;
            bt_l.Text = "English";
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // создали объетк item
            // явно приводим sender к tool
           ToolStripMenuItem it= (ToolStripMenuItem)sender;
            if (it.Checked == true) BackColor = Color.Red;
            else BackColor = c;
        }

        private void bt_l_Click(object sender, EventArgs e)
        {
            if (bt_l.Text.CompareTo("English") == 0)
            {
                bt_l.Text = "Русский";
                menuStrip_en.Visible = true;
                menuStrip_ru.Visible = false;
                this.MainMenuStrip = menuStrip_en;
            }
            else
            {
                bt_l.Text = "English";
                menuStrip_en.Visible = false;
                menuStrip_ru.Visible = true;
                this.MainMenuStrip = menuStrip_ru;
            }

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //какие файлы отражаем
            //1создадим объект
            openFileDialog1.Filter = "Text Files (*.txt)|*.txt|All files(*.*)|*.*";
            //проверяем
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                if (openFileDialog1.FileName == "") return;
                else
                {
                    StreamReader sr = new StreamReader(openFileDialog1.FileName);
                    richTextBox1.Text = sr.ReadToEnd();
                    sr.Close();      
                }
            }
        }
    }
}
