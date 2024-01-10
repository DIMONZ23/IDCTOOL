using DocumentFormat.OpenXml.Bibliography;
using IDC.App.Models;
using IDC.App.ProjectManagement.ViewModels;
using IDC.Common.Dictionaries;
using IDC.Common.Models;
using IDC.Services.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IDC.Common.Dictionaries.Modifications;

namespace IDC.App.ViewModels
{
    
    public class ModificationDetailVM:IViewModel
    {
       

        public Dictionary<int,string> ModList 
        {
            get 
            { 
                return Modifications.ModList; 
            } 
        }
        private string _modNameValue { get; set; }
        public string modName
        {
            get { return _modNameValue; }
            set
            {
                _modNameValue = value;
                OnPropertyChanged(nameof(modName));
            }
        }
        public int _selectedMod {  get; set; }
        public int previousMod {  get; set; }
        public int selectedMod
        {
            get { return _selectedMod; }
            set
            {
                previousMod = selectedMod;
                selectedMod = _selectedMod;
                OnPropertyChanged(nameof(selectedMod));
            }
        }
        public FileMergeRule mergeRule { get; set; }
        public AdditionalRecordRule additionalRecord {  get; set; }
        
    }
}
