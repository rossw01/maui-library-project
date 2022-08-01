using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using LibraryProject.Models;

namespace LibraryProject.ViewModels
{
    public class BranchSelectionViewModel : INotifyPropertyChanged
    {

        readonly IList<SelectableBranch> source;
        SelectableBranch selectedBranch;

        public ObservableCollection<SelectableBranch> Branches { get; private set; }

        public ObservableCollection<SelectableBranch> FilteredBranches { get; private set; }

        public SelectableBranch SelectedBranch
        {
            get
            {
                return selectedBranch;
            }
            set
            {
                if (selectedBranch != value)
                {
                    selectedBranch = value;
                }
            }
        }

        public BranchSelectionViewModel()
        {
            source = new List<SelectableBranch>();
            PopulateSelectableBranchesCollection();

            selectedBranch = Branches.FirstOrDefault();
        }

        void PopulateSelectableBranchesCollection()
        {
            List<SelectableBranch> selectableBranches = SelectableBranch.BranchesToSelectableBranches(App.DataReader.GetBranches());
            foreach (SelectableBranch branch in selectableBranches)
            {
                source.Add(branch);
            }
            Branches = new ObservableCollection<SelectableBranch>(source);
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion


    }
}