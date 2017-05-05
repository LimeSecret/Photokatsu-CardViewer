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

        public Form1()
        {
            InitializeComponent();
            LoadInformation();
            materialProgressBar1.Value = 0;
            Box1.BackColor = Color.Brown;
        }

        private void ButtonPrev_Click(object sender, EventArgs e)
        {
            if (deckamount == 0)
                return;
            if (current_index - 1 <= 0)
                current_index = 1;
            else
                current_index--;
            ShowCardInfo(current_index);
        }

        private void ButtonPrev10_Click(object sender, EventArgs e)
        {
            if (deckamount == 0)
                return;
            if (current_index - 10 <= 0)
                current_index = 1;
            else
                current_index -= 10;
            ShowCardInfo(current_index);
        }

        private void ButtonNext_Click(object sender, EventArgs e)
        {
            if (deckamount == 0)
                return;
            if (current_index + 1 > deckamount)
                current_index = deckamount;
            else
                current_index++;
            ShowCardInfo(current_index);
        }

        private void ButtonNext10_Click(object sender, EventArgs e)
        {
            if (deckamount == 0)
                return;
            if (current_index + 10 > deckamount)
                current_index = deckamount;
            else
                current_index += 10;
            ShowCardInfo(current_index);
        }

        private void ButtonRandom_Click(object sender, EventArgs e)
        {
            if (amount == 0 || deckamount == 0)
                return;
            Random rnd = new Random();
            current_index = rnd.Next(1, deckamount + 1);
            ShowCardInfo(current_index);  
        }

        private void ButtonNina_Click(object sender, EventArgs e)
        {
            InitDeck();
            AllListToDeck();
            CharacterSearch("nina");
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            InitDeck();
            AllListToDeck();
            RankSearch();
            NumberSearch(InputStartValue.Text, InputEndValue.Text);
            CharacterSearch(InputCharName.Text);
        }

        private void ButtonRenew_Click(object sender, EventArgs e)
        {
            RenewCard();
        }

        private void ButtonInitalize_Click(object sender, EventArgs e)
        {
            InitList();
            string initname = "inital";
            string Store = "source";
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
    }

}
