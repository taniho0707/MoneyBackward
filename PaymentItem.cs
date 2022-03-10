using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

using CsvHelper.Configuration.Attributes;

namespace MoneyBackward
{
    public class PaymentItem
    {
        [Name("CommonPayment")]
        public bool CommonPayment { get; set; }

        [Name("計算対象")]
        public bool CalculationTarget { get; set; }

        [Name("日付")]
        public string Date { get; set; }

        [Name("内容")]
        public string Content { get; set; }

        [Name("金額（円）")]
        public int Yen { get; set; }

        public string Payer { get; set; }

        [Name("保有金融機関")]
        public string FinancialInstitution { get; set; }

        [Name("大項目")]
        public string Head1 { get; set; }

        [Name("中項目")]
        public string Head2 { get; set; }

        [Name("メモ")]
        public string Comment { get; set; }

        [Name("振替")]
        public string PostalTransfer { get; set; }

        [Name("ID")]
        public string Id { get; set; }
    }

    public class PaymentItemList
    {
        public BindingList<PaymentItem> Data { get; }
        public List<String> Person { get; }
        public List<List<int>> OneselfPaymentList { get; }
        private string AllLogs;

        public PaymentItemList()
        {
            Data = new BindingList<PaymentItem> { };
            Person = new List<String>();
            OneselfPaymentList = new List<List<int>>();
            AllLogs = "";
        }

        public void AddItem(PaymentItem item)
        {
            Data.Add(item);
            string name = item.FinancialInstitution.Split("：")[0];
            Data[Data.Count - 1].Payer = name;
        }

        public void CleanList()
        {
            Data.Clear();
            Person.Clear();
            OneselfPaymentList.Clear();
            AllLogs = "";
        }

        public void CalcBalance()
        {
            Person.Clear();
            OneselfPaymentList.Clear();
            AllLogs = "";

            for (int i = 0; i < Data.Count; ++i)
            {
                var item = Data[i];
                if (item.CommonPayment == true)
                {
                    int index = Person.IndexOf(item.Payer);
                    if (index == -1)
                    {
                        Person.Add(item.Payer);
                        OneselfPaymentList.Add(new List<int>());
                        index = Person.IndexOf(item.Payer);
                    }

                    OneselfPaymentList[index].Add(i);
                }
            }
        }

        public string GetSummary()
        {
            string message = "";
            for (int i=0; i<Person.Count; ++i)
            {
                var person = Person[i];
                message += person;
                message += " さんの支払額：";
                AllLogs += "○";
                AllLogs += person;
                AllLogs += " さんの支払い内容\n";

                int sum = 0;
                foreach (var index in OneselfPaymentList[i])
                {
                    sum += Data[index].Yen;
                    AllLogs += Data[index].Content;
                    AllLogs += " (";
                    AllLogs += Data[index].Yen.ToString();
                    AllLogs += " 円): ";
                    AllLogs += Data[index].Id;
                    AllLogs += "\n";
                }

                message += (sum * -1).ToString();
                message += " 円\n";
                AllLogs += "※合計 ";
                AllLogs += (sum * -1).ToString();
                AllLogs += " 円\n\n";
            }

            return message;
        }

        public BindingList<PaymentItem> GetAllRecords()
        {
            return Data;
        }

        public string GetAllLogs()
        {
            return AllLogs;
        }
    }
}
