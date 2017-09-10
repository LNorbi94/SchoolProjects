using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication2
{
    public partial class txtShow : Form
    {
        struct client
        {
            public string name;
            public string zipcode;
            public string town;
            public string street;
        };
        struct table
        {
            public string company;
            public string ktvnumber;
            public client client;
            public string yearly_fee;
            public string fee_interval;
            public string license_plate_number;
            public string start;
            public string storno;
            public string description;
            public string payment_method;
            public string ending;
            public string MABISZfee;
            public string fee_done_until;
            public string actual_payment;
            public string BMclass;
        };
        
        List<table> datas = new List<table>();
        List<table> temporary = new List<table>();

        public txtShow()
        {
            InitializeComponent();
        }

        private void read(ref List<table> datas)
        {
            try
            {
              OpenFileDialog fldial = new OpenFileDialog();
              fldial.ShowDialog();
              StreamReader f = File.OpenText(fldial.FileName);
              f.ReadLine();
              while (!f.EndOfStream)
              {
                  string[] cut = f.ReadLine().Split(new char[] { '\t' });
                  table data;
                  data.company = cut[0];
                  data.ktvnumber = cut[1];
                  data.client.name = cut[2];
                  data.client.zipcode = cut[3];
                  data.client.town = cut[4];
                  data.client.street = cut[5];
                  data.yearly_fee = cut[6];
                  data.fee_interval = cut[7];
                  data.license_plate_number = cut[8];
                  data.start = cut[9];
                  data.storno = cut[10];
                  data.description = cut[11];
                  data.payment_method = cut[12];
                  data.ending = cut[13];
                  data.MABISZfee = cut[14];
                  data.fee_done_until = cut[15];
                  data.actual_payment = cut[16];
                  data.BMclass = cut[17];
                  datas.Add(data);
              }
            }
            catch (Exception error)
            {
                MessageBox.Show("Hiba történt! \n"+error);
                throw;
            }
        }

        private void show(ref List<table> datas, ref DataGridView dview)
        {
            int size = datas.Count;
            dview.RowCount = size;
            dview.ColumnCount = 18;
            dview.Columns[0].Width = 100;
            dview.Columns[1].Width = 100;
            dview.Columns[2].Width = 100;
            dview.Columns[3].Width = 100;
            dview.Columns[4].Width = 100;
            dview.Columns[5].Width = 100;
            dview.Columns[6].Width = 100;
            dview.Columns[7].Width = 100;
            dview.Columns[8].Width = 100;
            dview.Columns[9].Width = 100;
            dview.Columns[10].Width = 100;
            dview.Columns[11].Width = 100;
            dview.Columns[12].Width = 100;
            dview.Columns[13].Width = 100;
            dview.Columns[14].Width = 100;
            dview.Columns[15].Width = 100;
            dview.Columns[16].Width = 100;
            dview.Columns[17].Width = 100;
            dview.Columns[0].HeaderText = "BIZTNEVE";
            dview.Columns[1].HeaderText = "KTVSZAM";
            dview.Columns[2].HeaderText = "Szerződő";
            dview.Columns[3].HeaderText = "UGISZAM";
            dview.Columns[4].HeaderText = "UGVAROS";
            dview.Columns[5].HeaderText = "UGUTCA";
            dview.Columns[6].HeaderText = "EvesDij";
            dview.Columns[7].HeaderText = "FizUtem";
            dview.Columns[8].HeaderText = "Rendszám";
            dview.Columns[9].HeaderText = "KEZDET";
            dview.Columns[10].HeaderText = "STORNO";
            dview.Columns[11].HeaderText = "Megnevezés";
            dview.Columns[12].HeaderText = "FIZMOD";
            dview.Columns[13].HeaderText = "Lejarat";
            dview.Columns[14].HeaderText = "MABISZdij";
            dview.Columns[15].HeaderText = "DijRendezveIg";
            dview.Columns[16].HeaderText = "AktualisFizUtemSzDij";
            dview.Columns[17].HeaderText = "BMbesorolas";
            dview.RowHeadersWidth = 65;
            for (int i = 0; i < size; i++)
            {
                dview.Rows[i].HeaderCell.Value = (i + 1) + ".";
                dview.Rows[i].Cells[0].Value = datas[i].company;
                dview.Rows[i].Cells[1].Value = datas[i].ktvnumber;
                dview.Rows[i].Cells[2].Value = datas[i].client.name;
                dview.Rows[i].Cells[3].Value = datas[i].client.zipcode;
                dview.Rows[i].Cells[4].Value = datas[i].client.town;
                dview.Rows[i].Cells[5].Value = datas[i].client.street;
                dview.Rows[i].Cells[6].Value = datas[i].yearly_fee;
                dview.Rows[i].Cells[7].Value = datas[i].fee_interval;
                dview.Rows[i].Cells[8].Value = datas[i].license_plate_number;
                dview.Rows[i].Cells[9].Value = datas[i].start;
                dview.Rows[i].Cells[10].Value = datas[i].storno;
                dview.Rows[i].Cells[11].Value = datas[i].description;
                dview.Rows[i].Cells[12].Value = datas[i].payment_method;
                dview.Rows[i].Cells[13].Value = datas[i].ending;
                dview.Rows[i].Cells[14].Value = datas[i].MABISZfee;
                dview.Rows[i].Cells[15].Value = datas[i].fee_done_until;
                dview.Rows[i].Cells[16].Value = datas[i].actual_payment;
                dview.Rows[i].Cells[17].Value = datas[i].BMclass;
            }
        }

        private void feltolt_Click(object sender, EventArgs e)
        {
            read(ref datas);
            datas.Sort((x, y) => x.company.CompareTo(y.company));
            show(ref datas, ref main);
            gB.Visible = true;
        }

        private void quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void search(List<table> datas, ref List<table> temp){
            temp = datas.FindAll(x => x.company.Contains(tb_search.Text));
            if (temporary.Count == 0)
                temp = datas.FindAll(x => x.ktvnumber.Contains(tb_search.Text));
            if (temporary.Count == 0)
                temp = datas.FindAll(x => x.client.name.Contains(tb_search.Text));
            if (temporary.Count == 0)
                temp = datas.FindAll(x => x.client.street.Contains(tb_search.Text));
            if (temporary.Count == 0)
                temp = datas.FindAll(x => x.client.town.Contains(tb_search.Text));
            if (temporary.Count == 0)
                temp = datas.FindAll(x => x.client.zipcode.Contains(tb_search.Text));
            if (temporary.Count == 0)
                temp = datas.FindAll(x => x.yearly_fee.Contains(tb_search.Text));
            if (temporary.Count == 0)
                temp = datas.FindAll(x => x.fee_interval.Contains(tb_search.Text));
            if (temporary.Count == 0)
                temp = datas.FindAll(x => x.license_plate_number.Contains(tb_search.Text));
            if (temporary.Count == 0)
                temp = datas.FindAll(x => x.start.Contains(tb_search.Text));
            if (temporary.Count == 0)
                temp = datas.FindAll(x => x.storno.Contains(tb_search.Text));
            if (temporary.Count == 0)
                temp = datas.FindAll(x => x.description.Contains(tb_search.Text));
            if (temporary.Count == 0)
                temp = datas.FindAll(x => x.payment_method.Contains(tb_search.Text));
            if (temporary.Count == 0)
                temp = datas.FindAll(x => x.ending.Contains(tb_search.Text));
            if (temporary.Count == 0)
                temp = datas.FindAll(x => x.MABISZfee.Contains(tb_search.Text));
            if (temporary.Count == 0)
                temp = datas.FindAll(x => x.fee_done_until.Contains(tb_search.Text));
            if (temporary.Count == 0)
                temp = datas.FindAll(x => x.actual_payment.Contains(tb_search.Text));
            if (temporary.Count == 0)
                temp = datas.FindAll(x => x.BMclass.Contains(tb_search.Text));
        }

        private void searching_Click(object sender, EventArgs e)
        {
            search(datas, ref temporary);
            if (temporary.Count > 0)
                show(ref temporary, ref results);
            else
                MessageBox.Show("Nem találtam egy ehhez hasonló adatot se");
            temporary.Clear();
        }
        
    }
}
