using BindingToObject.Models;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MvvmSample.ViewModels
{
    public class MainPageViewModel :ViewModelBase
    {
       
        public ObservableCollection<Student> Students { get; set; }

        public ICommand LoadDataCommand { get; private set; } 

        public ICommand ClearDataCommand { get; private set; }
        public ICommand RefreshCommand { get; private set; }
        private bool isrefreshing;
        public bool Isrefreshing { get { return isrefreshing; } set { if (isrefreshing != value) { isrefreshing = value; OnPropertyChanged(); } } }
 

        public MainPageViewModel()
        {
            Students = new ObservableCollection<Student>(); 
            LoadDataCommand=new Command(LoadData);
            ClearDataCommand = new Command(() => Students.Clear());
            RefreshCommand = new Command(LoadData);
        }

        public void LoadData()
        {
            Students.Clear();
           Students.Add(new Student() { BirthDate = DateTime.Now, Name = "ג'ופיר", Image = "jofir.jpg" });
            Isrefreshing = false;
           
        }
    }
}
