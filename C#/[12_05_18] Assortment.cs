using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        struct Record
        {
            public string nev;
            public string szulovaros;
            public string varos;
            public string szido;
            public int testver;
            public double atlag;
            public int jovedelem;
        }
        int n;
        int db, dbsz, dbl, dbv, db88, db89, dba1, dba2, dba3, dba4;
        const int maxn = 100;
        new Record[] v = new Record[maxn];
        new Record[] a = new Record[maxn];
        new Record[] b = new Record[maxn];
        new Record[] c = new Record[maxn];
        new Record[] d = new Record[maxn];
        new Record[] nyolc = new Record[maxn];
        new Record[] kilenc = new Record[maxn];
        new Record[] atlag1 = new Record[maxn];
        new Record[] atlag2 = new Record[maxn];
        new Record[] atlag3 = new Record[maxn];
        new Record[] atlag4 = new Record[maxn];
        
        public Form1()
        {
            InitializeComponent();
        }

        private void kilep_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            feltoltes(ref v, ref  n);
            megjelenites(ref v, n, ref dg_tanulok);
            azonossz(ref v, n, ref db);
            megjelenites(ref a, db, ref dg_szul);
            szsegely(ref v, n, ref dbsz);
            megjelenit2(ref b, dbsz);
            budapestk(ref v, n, ref dbl, ref dbv);
            megjelenit3(ref c, dbl, ref dg_bpl);
            megjelenit3(ref d, dbv, ref dg_vdl);
            verseny(ref v, n, ref db88, ref db89);
            megjelenit4(ref nyolc, db88, ref dg88);
            megjelenit4(ref kilenc, db89, ref dg89);
            atlag(ref v, n, ref dba1, ref dba2, ref dba3, ref dba4);
            megjelenit5(ref atlag1, n, ref dg_tana);
            megjelenit6(ref atlag2, n, ref dg_tana);

        }

        private void feltoltes(ref Record[] v, ref int n)
        {
            StreamReader f = File.OpenText("adatok.txt");
            while (!f.EndOfStream && n<=maxn)
            {
                v[n].nev = f.ReadLine();
                v[n].szulovaros = f.ReadLine();
                v[n].varos = f.ReadLine();
                v[n].szido = f.ReadLine();
                v[n].testver = int.Parse(f.ReadLine());
                v[n].atlag = double.Parse(f.ReadLine());
                v[n].jovedelem = int.Parse(f.ReadLine());
                n++; 
            }
        }

        private void megjelenites(ref Record[] v, int n, ref DataGridView dg_tanulok)
        {
            dg_tanulok.RowCount = n;
            dg_tanulok.ColumnCount = 7;
            dg_tanulok.TopLeftHeaderCell.Value = "Sorszám:";
            for (int i = 0; i < 7; i++)
            {
                dg_tanulok.Columns[i].Width = 88;
                dg_tanulok.Columns[0].HeaderText = "Név";
                dg_tanulok.Columns[1].HeaderText = "Szülőváros";
                dg_tanulok.Columns[2].HeaderText = "Város";
                dg_tanulok.Columns[3].HeaderText = "Sz. Idő";
                dg_tanulok.Columns[4].HeaderText = "Testvérek";
                dg_tanulok.Columns[5].HeaderText = "Átlag";
                dg_tanulok.Columns[6].HeaderText = "Jövedelem";
            }
            dg_tanulok.RowHeadersWidth = 55;
            for (int i = 0; i < n; i++)
            {
                dg_tanulok.Rows[i].HeaderCell.Value = (i + 1) + "."; 
            }
            for (int i = 0; i < n; i++)
            {
                dg_tanulok.Rows[i].Cells[0].Value = v[i].nev;
                dg_tanulok.Rows[i].Cells[1].Value = v[i].szulovaros;
                dg_tanulok.Rows[i].Cells[2].Value = v[i].varos;
                dg_tanulok.Rows[i].Cells[3].Value = v[i].szido;
                dg_tanulok.Rows[i].Cells[4].Value = v[i].testver;
                dg_tanulok.Rows[i].Cells[5].Value = v[i].atlag;
                dg_tanulok.Rows[i].Cells[6].Value = v[i].jovedelem;
            }
        }

        private void azonossz(ref Record[] v, int n, ref int db)
        {
            db = 0;
            for (int i = 0; i < n; i++)
            {
                if (v[i].szulovaros == v[i].varos)
                {
                    a[db] = v[i];
                    db++;
                }  
            }
        }

        private void szsegely(ref Record[] v, int n, ref int dbsz)
        {
            dbsz = 0;
            for (int i = 0; i < n; i++)
            {
                if ((v[i].testver >= 2) && (v[i].atlag >= 3.5) && (v[i].jovedelem <= 120000))
                {
                    b[dbsz] = v[i];
                    dbsz++;
                }
            }
        }

        private void megjelenit2(ref Record[] v, int n)
        {
            dg_szseg.RowCount = n;
            dg_szseg.ColumnCount = 4;
            for (int i = 0; i < 4; i++)
            {
                dg_szseg.Columns[i].Width = 88;
                dg_szseg.Columns[0].HeaderText = "Név";
                dg_szseg.Columns[1].HeaderText = "Testvérek";
                dg_szseg.Columns[2].HeaderText = "Átlag";
                dg_szseg.Columns[3].HeaderText = "Jövedelem";
            }
            dg_szseg.RowHeadersWidth = 55;
            for (int i = 0; i < n; i++)
            {
                dg_szseg.Rows[i].HeaderCell.Value = (i + 1) + ".";
            }
            for (int i = 0; i < n; i++)
            {
                dg_szseg.Rows[i].Cells[0].Value = v[i].nev;
                dg_szseg.Rows[i].Cells[1].Value = v[i].testver;
                dg_szseg.Rows[i].Cells[2].Value = v[i].atlag;
                dg_szseg.Rows[i].Cells[3].Value = v[i].jovedelem;
            }
        }

        private void budapestk(ref Record[] v, int n, ref int dbl, ref int dbv)
        {
            dbl = 0;
            for (int i = 0; i < n; i++)
            {
                if (v[i].varos == "Budapest")
                {
                    c[dbl] = v[i];
                    dbl++;
                }
                else
                {
                    d[dbv] = v[i];
                    dbv++;
                }
            }
        }

        private void megjelenit3(ref Record[] v, int n, ref DataGridView dg_bpl)
        {
            dg_bpl.RowCount = n;
            dg_bpl.ColumnCount = 3;
            for (int i = 0; i < 3; i++)
            {
                dg_bpl.Columns[i].Width = 88;
                dg_bpl.Columns[0].HeaderText = "Név";
                dg_bpl.Columns[1].HeaderText = "Szülőváros";
                dg_bpl.Columns[2].HeaderText = "Város";
            }
            dg_bpl.RowHeadersWidth = 55;
            for (int i = 0; i < n; i++)
            {
                dg_bpl.Rows[i].HeaderCell.Value = (i + 1) + ".";
            }
            for (int i = 0; i < n; i++)
            {
                dg_bpl.Rows[i].Cells[0].Value = v[i].nev;
                dg_bpl.Rows[i].Cells[1].Value = v[i].szulovaros;
                dg_bpl.Rows[i].Cells[2].Value = v[i].varos;
            }
        }

        private void verseny(ref Record[] v, int n, ref int db88, ref int db89)
        {
            db88 = 0;
            db89 = 0;
            for (int i = 0; i < n; i++)
            {
                if (v[i].szido.CompareTo("1990") == 1)
                {
                    nyolc[db88] = v[i];
                    db88++;
                }
                else
                {
                    kilenc[db89] = v[i];
                    db89++;
                }
            }
        }

        private void megjelenit4(ref Record[] v, int n, ref DataGridView dg_bpl)
        {

            dg_bpl.RowCount = n;
            dg_bpl.ColumnCount = 2;
            for (int i = 0; i < 2; i++)
            {
                dg_bpl.Columns[i].Width = 88;
                dg_bpl.Columns[0].HeaderText = "Név";
                dg_bpl.Columns[1].HeaderText = "Születési idő";
            }
            dg_bpl.RowHeadersWidth = 55;
            for (int i = 0; i < n; i++)
            {
                dg_bpl.Rows[i].HeaderCell.Value = (i + 1) + ".";
            }
            for (int i = 0; i < n; i++)
            {
                dg_bpl.Rows[i].Cells[0].Value = v[i].nev;
                dg_bpl.Rows[i].Cells[1].Value = v[i].szido;
            }
        }

        private void atlag(ref Record[] v, int n, ref int dba1, ref int dba2, ref int dba3, ref int dba4)
        {
            for (int i = 0; i < n; i++)
            {
                if ((v[i].atlag > 1.0) && (v[i].atlag < 2.0))
                {
                    atlag1[dba1] = v[i];
                    dba1++;
                }
                if ((v[i].atlag > 2.0) && (v[i].atlag < 3.0))
                {
                    atlag2[dba2] = v[i];
                    dba2++;
                }
                if ((v[i].atlag > 3.0) && (v[i].atlag < 4.0))
                {
                    atlag3[dba3] = v[i];
                    dba3++;
                }
                if ((v[i].atlag > 4.0) && (v[i].atlag < 5.0))
                {
                    atlag4[dba4] = v[i];
                    dba4++;
                }
            }
        }

        private void megjelenit5(ref Record[] v, int n, ref DataGridView dg_bpl)
        {
            dg_bpl.RowCount = n;
            dg_bpl.ColumnCount = 2;
            for (int i = 0; i < 2; i++)
            {
                dg_bpl.Columns[i].Width = 88;
                dg_bpl.Columns[0].HeaderText = "Név";
                dg_bpl.Columns[1].HeaderText = "Átlag";
            }
            dg_bpl.RowHeadersWidth = 55;
            for (int i = 0; i < n; i++)
            {
                dg_bpl.Rows[i].HeaderCell.Value = (i + 1) + ".";
            }
            for (int i = 0; i < dba1; i++)
            {
                dg_bpl.Rows[i].Cells[0].Value = v[i].nev;
                dg_bpl.Rows[i].Cells[1].Value = v[i].atlag;
            }
        }

        private void megjelenit6(ref Record[] v, int n, ref DataGridView dg_bpl)
        {
            int dbz = dba1 + dba2;
            for (int i = dba1; i < 49; i++)
            {
                dg_bpl.Rows[i].Cells[0].Value = v[i].nev;
                dg_bpl.Rows[i].Cells[1].Value = v[i].atlag;
            }
        }

        private void megjelenit7(ref Record[] v, int n, ref DataGridView dg_bpl)
        {
            dg_bpl.RowCount = n;
            dg_bpl.ColumnCount = 2;
            for (int i = 0; i < 2; i++)
            {
                dg_bpl.Columns[i].Width = 88;
                dg_bpl.Columns[0].HeaderText = "Név";
                dg_bpl.Columns[1].HeaderText = "Átlag";
            }
            dg_bpl.RowHeadersWidth = 55;
            for (int i = 0; i < n; i++)
            {
                dg_bpl.Rows[i].HeaderCell.Value = (i + 1) + ".";
            }
            for (int i = dba2; i < dba3; i++)
            {
                dg_bpl.Rows[i].Cells[0].Value = v[i].nev;
                dg_bpl.Rows[i].Cells[1].Value = v[i].atlag;
            }
        }

        private void megjelenit8(ref Record[] v, int n, ref DataGridView dg_bpl)
        {
            dg_bpl.RowCount = n;
            dg_bpl.ColumnCount = 2;
            for (int i = 0; i < 2; i++)
            {
                dg_bpl.Columns[i].Width = 88;
                dg_bpl.Columns[0].HeaderText = "Név";
                dg_bpl.Columns[1].HeaderText = "Átlag";
            }
            dg_bpl.RowHeadersWidth = 55;
            for (int i = 0; i < n; i++)
            {
                dg_bpl.Rows[i].HeaderCell.Value = (i + 1) + ".";
            }
            for (int i = dba3; i < n; i++)
            {
                dg_bpl.Rows[i].Cells[0].Value = v[i].nev;
                dg_bpl.Rows[i].Cells[1].Value = v[i].atlag;
            }
        }
    }
}
