﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using MaterialSkin;
using MaterialSkin.Controls;

namespace WindowsFormsApplication1
{
    public partial class Form1 : MaterialForm
    {
        public int MiseCurr = 12;
        public Form1()
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            InitializeComponent();
            LoadInformation();
            materialProgressBar1.Value = 0;
            Box1.BackColor = Color.Brown;
            MiseLoad();
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Indigo500, Primary.Indigo700, Primary.Indigo100, Accent.Pink200, TextShade.WHITE);
            this.KeyPreview = true;
        }


        private void ButtonLargerImage_Click(object sender, EventArgs e)
        {
            try
            {
                Form pictform = new Form2(deck[current_index].cardno);
                pictform.ShowDialog();
            }
            catch
            {

            }

        }

        private void ButtonPrev_Click(object sender, EventArgs e)
        {
            if (deck.Count == 0)
                return;
            if (current_index - 1 <= 0)
                current_index = 0;
            else
                current_index--;
            ShowCardInfo(current_index);
        }

        private void ButtonPrev10_Click(object sender, EventArgs e)
        {
            if (deck.Count == 0)
                return;
            if (current_index - 10 <= 0)
                current_index = 0;
            else
                current_index -= 10;
            ShowCardInfo(current_index);
        }

        private void ButtonNext_Click(object sender, EventArgs e)
        {
            if (deck.Count == 0)
                return;
            if (current_index + 1 >= deck.Count)
                current_index = deck.Count-1;
            else
                current_index++;
            ShowCardInfo(current_index);
        }

        private void ButtonNext10_Click(object sender, EventArgs e)
        {
            if (deck.Count == 0)
                return;
            if (current_index + 10 >= deck.Count)
                current_index = deck.Count - 1;
            else
                current_index += 10;
            ShowCardInfo(current_index);
        }

        private void ButtonRandom_Click(object sender, EventArgs e)
        {
            if (list.Count == 0 || deck.Count == 0)
                return;
            Random rnd = new Random();
            current_index = rnd.Next(0, deck.Count);
            ShowCardInfo(current_index);  
        }

        private void ButtonNina_Click(object sender, EventArgs e)
        {
            InitDeck();
            AllListToDeck();
            CharacterSearch("nina");
            NewDeckFirstPage();
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            InitDeck();
            AllListToDeck();
            RankSearch();
            NumberSearch(InputStartValue.Text, InputEndValue.Text);
            if(CharBox.SelectedItem != null)
                 CharacterSearch(CharBox.SelectedItem.ToString());
            if (AppealBox.SelectedItem != null)
                AppealSearch(AppealBox.SelectedItem.ToString());
            SubstringSearch(InputCharName.Text);
            NewDeckFirstPage();
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            InputStartValue.Clear();
            InputEndValue.Clear();
            InputCharName.Clear();
            Box1.Checked = true;
            Box2.Checked = true;
            Box3.Checked = true;
            Box4.Checked = true;
            Box5.Checked = true;
            Box6.Checked = true;
            Box7.Checked = true;
            Box8.Checked = true;
            CharBox.SelectedIndex = -1;
            AppealBox.SelectedIndex = -1;
        }

        private void ButtonDownloadAll_Click(object sender, EventArgs e)
        {
            DownloadAll();
        }

        private void ButtonRenew_Click(object sender, EventArgs e)
        {
            RenewCard();
        }

        private void ButtonInitalize_Click(object sender, EventArgs e)
        {
            InitList();
            string initname = AppDomain.CurrentDomain.BaseDirectory + @"\resources\inital";
            string Store = AppDomain.CurrentDomain.BaseDirectory + @"\resources\source";
            string temp = System.IO.File.ReadAllText(initname);
            System.IO.File.WriteAllText(Store, temp, Encoding.Default);
            MessageBox.Show("초기화되었습니다. 프로그램을 다시 실행해주세요.");
            Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.airkorea.or.kr/dustForecast");
        }

        private void materialLabel8_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/LimeSecret/Photokatsu-CardViewer");
        }

        private void materialLabel9_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://gall.dcinside.com/board/lists/?id=aikatsu");
        }

        private void materialLabel3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/IgnaceMaes/MaterialSkin");
        }

        private void materialLabel20_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://aikatsu.wikia.com/wiki/Aikatsu_Wiki");
        }

        private void materialLabel25_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/zzzprojects/html-agility-pack");
        }

        private void MisePrev_Click(object sender, EventArgs e)
        {
            if (MiseCurr <= 12)
                return;
            MisePicture.Invalidate();
            MiseCurr = MiseCurr - 3;
            MiseLoad();
        }

        private void MiseNext_Click(object sender, EventArgs e)
        {
            if (MiseCurr >= 75)
                return;
            MisePicture.Invalidate();
            MiseCurr = MiseCurr + 3;
            MiseLoad();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control)    // Ctrl 키 조합
            {
                switch (e.KeyCode)
                {
                    case Keys.A:
                        ButtonPrev10_Click(sender, e);
                        break;
                    case Keys.D:
                        ButtonNext10_Click(sender, e);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (e.KeyCode)
                {
                    case Keys.A:
                        ButtonPrev_Click(sender, e);
                        break;
                    case Keys.D:
                        ButtonNext_Click(sender, e);
                        break;
                    case Keys.S:
                        ButtonLargerImage_Click(sender, e);
                        break;
                    case Keys.W:
                        ButtonRandom_Click(sender, e);
                        break;
                    default:
                        break;
                }
            }


        }


    }

}
