using HomeWork;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using DevExpress.Mvvm.Native;
using Microsoft.EntityFrameworkCore;
using HomeWork.Database;
using HomeWork.MVVM;

namespace HomeWork.ViewModel
{
    public class MainWindowVM : ViewModelBase
    {
        private ObservableCollection<Good> listGood;
        private ObservableCollection<Category> listCatgory;
        private ObservableCollection<Manufacturer> listManufacturer;
        private Category selectedCategory;
        private Manufacturer selectedManufacturer;

        public ObservableCollection<Good> ListGood { get => listGood; set { listGood = value; RaisePropertyChanged(); } }
        public ObservableCollection<Category> ListCatgory { get => listCatgory; set { listCatgory = value; RaisePropertyChanged(); } }
        public ObservableCollection<Manufacturer> ListManufacturer { get => listManufacturer; set { listManufacturer = value; RaisePropertyChanged(); } }

        public Category SelectedCategory { get => selectedCategory; set { selectedCategory = value; RaisePropertyChanged(); } }
        public Manufacturer SelectedManufacturer { get => selectedManufacturer; set { selectedManufacturer = value; RaisePropertyChanged();} }

        public CommandVM Apply { get; set; }
        public CommandVM Reset { get; set; }

        public MainWindowVM()
        {
            ListGood = DataBase.GetInstance().Goods.Include(s => s.IdManufacturerNavigation).Include(s => s.IdCategoryNavigation).ToObservableCollection();
            ListCatgory = DataBase.GetInstance().Categories.ToObservableCollection();
            ListManufacturer = DataBase.GetInstance().Manufacturers.ToObservableCollection();

            Apply = new CommandVM(() =>
            {
                ListGood = DataBase.GetInstance().Goods.Include(s => s.IdManufacturerNavigation).Include(s => s.IdCategoryNavigation)
                                                       .Where(s => (SelectedCategory == null || s.IdCategoryNavigation.Title == SelectedCategory.Title) &&
                                                                  (SelectedManufacturer == null || s.IdManufacturerNavigation.Title == SelectedManufacturer.Title)).ToObservableCollection();
            });

            Reset = new CommandVM(() =>
            {
                SelectedManufacturer = null;
                SelectedCategory = null;
                Apply.action.Invoke();
            });
        }
    }
}
