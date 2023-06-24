using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanRuou
{
    public class MyClass : INotifyPropertyChanged
    {
        private string myPrice;
        QLBREntities db = new QLBREntities();
        public string MyPrice
        {
            get { return myPrice; }
            set
            {
                if (myPrice == value.ToString()) return;
                if (value.ToString() != "")
                {
                    DMHangHoa hh = db.DMHangHoas.Find(value.ToString());
                    myPrice = hh.dongiaban.ToString();
                    int a = Int32.Parse(value.ToString());
                    myPrice = (a * 1.1).ToString();

                }
                if (value.ToString() == "")
                {
                    myPrice = "";
                }
                OnPropertyChanged("MyPrice");
            }
        }
        public MyClass(string s)
        {
            MyPrice = s;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string newSalePrice)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(newSalePrice));
            }
        }
    }
}
