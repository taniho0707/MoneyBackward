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
using System.Globalization;

using CsvHelper;
using CsvHelper.Configuration;

namespace MoneyBackward
{
    public partial class Form1 : Form
    {
        public PaymentItemList payment_list;

        public Form1()
        {
            InitializeComponent();
        }

        private void LoadCsv(string file, PaymentItemList list)
        {
            list.CleanList();

            CultureInfo cultureinfo = new CultureInfo("ja-JP");
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            using (var reader = new StreamReader(file, Encoding.GetEncoding("shift_jis")))
            {
                var csvconfig = new CsvConfiguration(cultureinfo)
                {
                    MissingFieldFound = null,
                };

                using (var csvreader = new CsvReader(reader, csvconfig))
                {
                    csvreader.Read();
                    csvreader.ReadHeader();

                    var records = csvreader.GetRecords<PaymentItem>();

                    foreach (var item in records)
                    {
                        list.AddItem(item);
                    }
                }
            }
        }

        private string GetCsvFilename()
        {
            string name = Path.GetFileName(textbox_load_csv.Text);
            return name;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            payment_list = new PaymentItemList();
            dataGridView1.DataSource = payment_list.Data;

            dataGridView1.Columns[0].HeaderText = "共通支出";
            dataGridView1.Columns[1].HeaderText = "計算対象";
            dataGridView1.Columns[2].HeaderText = "日付";
            dataGridView1.Columns[3].HeaderText = "内容";
            dataGridView1.Columns[4].HeaderText = "金額(円)";
            dataGridView1.Columns[5].HeaderText = "支払者";
            dataGridView1.Columns[6].HeaderText = "保有金融機関";
            dataGridView1.Columns[7].HeaderText = "大項目";
            dataGridView1.Columns[8].HeaderText = "中項目";
            dataGridView1.Columns[9].HeaderText = "メモ";
            dataGridView1.Columns[10].HeaderText = "振替";
            dataGridView1.Columns[11].HeaderText = "ID";

            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dataGridView1.CellBeginEdit += delegate (object sender, DataGridViewCellCancelEventArgs e)
            {
                DataGridView dgv = sender as DataGridView;
                if (e.ColumnIndex != 0 || (bool)dgv[1, e.RowIndex].Value != true)
                {
                    e.Cancel = true;
                }
                else
                {
                    button_save.Enabled = false;
                }
            };

            //dataGridView1.CellMouseClick += delegate (object sender, DataGridViewCellMouseEventArgs e)
            //{
            //    DataGridView dgv = sender as DataGridView;
            //    if (e.ColumnIndex == 0)
            //    {
            //        if (payment_list.Data[e.RowIndex].CommonPayment == true)
            //        {
            //            payment_list.Data[e.RowIndex].CommonPayment = false;
            //        }
            //        else
            //        {
            //            payment_list.Data[e.RowIndex].CommonPayment = true;
            //        }
            //        dataGridView1.Refresh();
            //        dataGridView1.RefreshEdit();
            //    }
            //};
        }

        private void button_load_csv_Click(object sender, EventArgs e)
        {
            if (textbox_load_csv.Text != "")
            {
                var res = MessageBox.Show("現在の編集内容を破棄し、新しくファイルを開きますか？",
                    "確認",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2);
                if (res != DialogResult.OK)
                {
                    return;
                }
            }

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "*.csv";
            ofd.InitialDirectory = "S:\\git\\MoneyBackward";
            ofd.Filter = "カンマ区切りcsvファイル(*.csv)|*.csv";
            ofd.Title = "開く家計簿ファイルを選択してください";
            ofd.RestoreDirectory = true;
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                payment_list.CleanList();

                textbox_load_csv.Text = ofd.FileName;
                LoadCsv(ofd.FileName, payment_list);
                dataGridView1.Refresh();

                dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                for (int i = 0; i < payment_list.Data.Count; ++i)
                {
                    if (payment_list.Data[i].CalculationTarget == false)
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Gray;
                    }
                }

                button_calc.Enabled = true;
                button_save.Enabled = false;
            }
        }

        private void button_calc_Click(object sender, EventArgs e)
        {
            payment_list.CalcBalance();
            MessageBox.Show(payment_list.GetSummary(),
                "計算結果",
                MessageBoxButtons.OK,
                MessageBoxIcon.Asterisk);
            button_save.Enabled = true;
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            string origin_filename = textbox_load_csv.Text;
            string marked_filename = origin_filename.Insert(origin_filename.Length - 4, "_marked");
            string log_filename = origin_filename.Replace(".csv", "_log.log");

            CultureInfo cultureinfo = new CultureInfo("ja-JP");
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            using (var writer = new StreamWriter(marked_filename, false, Encoding.GetEncoding("shift_jis")))
            {
                var csvconfig = new CsvConfiguration(cultureinfo)
                {
                    MissingFieldFound = null,
                };

                using (var csvwriter = new CsvWriter(writer, csvconfig))
                {
                    csvwriter.WriteRecords(payment_list.GetAllRecords());
                }
            }
            File.WriteAllText(log_filename, payment_list.GetAllLogs());
        }
    }
}
