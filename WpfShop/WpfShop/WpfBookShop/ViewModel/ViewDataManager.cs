using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfBookShop.Model;
using WpfBookShop.View;

namespace WpfBookShop.ViewModel
{
    public class ViewDataManager
    {
        #region HTTP
        private HttpClient httpClient { get; set; }

        public ViewDataManager()
        {
            httpClient = new HttpClient();
        }

        public IEnumerable<Book> AllBook
        {
            get
            {
                return GetBooks();
            }
        }
        public void AddBook(Book book)
        {
            string url = @"https://localhost:5001/api/values";

            var r = httpClient.PostAsync(
                requestUri: url,
                content: new StringContent(JsonConvert.SerializeObject(book), Encoding.UTF8,
                mediaType: "application/json")
                ).Result;
        }
        public IEnumerable<Book> GetBooks()
        {
            string url = @"https://localhost:5001/api/values";
            string json = httpClient.GetStringAsync(url).Result;
            return JsonConvert.DeserializeObject<IEnumerable<Book>>(json);
        }
        public void DeleteBook(int? id)
        {
            string url = @"https://localhost:5001/api/values/" + id;
            var r = httpClient.DeleteAsync(url).Result;
        }

        public void EditeBook(Book book)
        {
            string url = @"https://localhost:5001/api/values";
            var r = httpClient.PutAsync(
                requestUri: url,
                content: new StringContent(JsonConvert.SerializeObject(book), Encoding.UTF8,
                mediaType: "application/json")).Result;
        }

        public Book GetBookOnId(int? id)
        {
            string url = @"https://localhost:5001/api/values/" + id;

            string json = httpClient.GetStringAsync(url).Result;

            return JsonConvert.DeserializeObject<Book>(json);
        }
        #endregion

        #region СВОЙСТВА BOOK
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public static Book SelectedBook { get; set; }
        #endregion

        #region МЕТОД ОКТКРЫТИЯ ОКОН
        private void SetCenterPositionAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }
        private void OpenAddWindowMethod()
        {
            AddWindow addWindow = new AddWindow();
            SetCenterPositionAndOpen(addWindow);
        }
        private void OpenEditeWindowMethod()
        {
            EditWindow editWindow = new EditWindow();
            SetCenterPositionAndOpen(editWindow);
        }
        #endregion

        #region КОМАНДЫ ОТКРЫТИЯ ОКОН
        private RelayCommand openAddWindow;
        public RelayCommand OpenAddWindow
        {
            get
            {
                return openAddWindow ?? new RelayCommand(obj =>
                 {
                     OpenAddWindowMethod();
                 });
            }
        }

        private RelayCommand openEditWindow;
        public RelayCommand OpenEditWindow
        {
            get
            {
                return openEditWindow ?? new RelayCommand(obj =>
                {
                    OpenEditeWindowMethod();
                });
            }
        }
        #endregion

        #region COMMAND TO ADD/EDIT/DELETE/CLOUSE
        private RelayCommand addNewBook;
        public RelayCommand AddNewBook
        {
            get
            {
                return addNewBook ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    if (BookName==null||AuthorName==null||Description==null||Price==null)
                    {
                        MessageBox.Show("Вы заполнили не все поля!");
                    }
                    else
                    {
                        Book newbook = new Book()
                        {
                            BookName = BookName,
                            AuthorName = AuthorName,
                            Description = Description,
                            Price = Convert.ToUInt32(Price)
                        };
                        AddBook(newbook);
                        UpdateAllBooksView();
                        wnd.Close();
                    }

                });
            }
        }
        private RelayCommand closeButton;
        public RelayCommand CloseButton
        {
            get
            {
                return closeButton ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    wnd.Close();
                });
            }
        }

        private RelayCommand deleteButton;
        public RelayCommand DeleteButton
        {
            get
            {
                return deleteButton ?? new RelayCommand(obj =>
                {
                    DeleteBook(SelectedBook.Id);
                    UpdateAllBooksView();
                });
            }
        }

        private RelayCommand editeButton;
        public RelayCommand EditeButton
        {
            get
            {
                return editeButton ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    Book newbook = new Book()
                    {
                        Id = SelectedBook.Id,
                        BookName = SelectedBook.BookName,
                        AuthorName = SelectedBook.AuthorName,
                        Description = SelectedBook.Description,
                        Img= SelectedBook.Img,
                        Price = Convert.ToUInt32(SelectedBook.Price)
                    };

                    EditeBook(newbook);
                    UpdateAllBooksView();
                    wnd.Close();
                });
            }
        }
        #endregion
        private void UpdateAllBooksView()
        {
            MainWindow.ListBookView.ItemsSource = null;
            MainWindow.ListBookView.Items.Clear();
            MainWindow.ListBookView.ItemsSource = AllBook;
            MainWindow.ListBookView.Items.Refresh();

        }
    }
}
