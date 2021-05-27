using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfBookShop.Model
{
    public static class Ext
    {
        public static double ToDouble(this string e) => Convert.ToDouble(e);

        public static ObservableCollection<Book> ToObservableCollection(this IEnumerable<Book> e)
        {
            ObservableCollection<Book> t = new ObservableCollection<Book>();
            foreach (var item in e)
            {
                t.Add(item);
            }
            return t;
        }


    }
}
