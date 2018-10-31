using Prism.Commands;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using PrismApp.Model;
namespace PrismApp.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        private ObservableCollection<Item> _sequence = new ObservableCollection<Item>();
        private int _selectedIndex;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ICommand SequenceSettingCommand { get; private set; }
        public ICommand DataGridInsertCommand { get; private set; }
        public ICommand DataGridDeleteCommand { get; private set; }
        public ICommand DataGridDeleteAllCommand { get; private set; }
        public ICommand DataGridCutItemsCommand { get; private set; }
        public ICommand DataGridCopyItemsCommand { get; private set; }
        public ICommand DataGridPasteItemsCommand { get; private set; }
        public ICommand DataGridExportCommand { get; private set; }
        public ICommand DataGridImportCommand { get; private set; }

        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                if (value == _selectedIndex) return;
                _selectedIndex = value;
                RaisePropertyChanged("SelectedIndex");
            }
        }

        private void DataGridInsert()
        {
            var model = new Item();
            if (SelectedIndex == -1)
                _sequence.Add(model);
            else
                _sequence.Insert(SelectedIndex, model);
        }
        //private void DataGridDelete(ICollection<object> selectItems)
        //{
        //    if (selectItems.Count == 0)
        //        return;
        //    var tempIndex = SelectedIndex;
        //    var deleteItems = new List<Step>();
        //    foreach (var itemInList in _sequence)
        //    {
        //        foreach (var item in selectItems)
        //        {
        //            if (item == itemInList)

        //                deleteItems.Add(item as Step);
        //        }
        //    }
        //    _sequence.RemoveRange(deleteItems);
        //    if (_sequence.Count <= tempIndex)
        //        SelectedIndex = _sequence.Count - 1;
        //    else
        //        SelectedIndex = tempIndex;
        //}
        //private void DataGridDeleteAll()
        //{
        //    _sequence.Clear();
        //}
        //private void DataGridCutItems(ICollection<object> selectItems)
        //{
        //    if (selectItems.Count == 0)
        //        return;
        //    copyItems.Clear();
        //    foreach (var itemInList in _sequence)
        //    {
        //        foreach (var item in selectItems)
        //        {
        //            if (item == itemInList)
        //                copyItems.Add(item as Step);
        //        }
        //    }
        //    _sequence.RemoveRange(copyItems);
        //}
        //private void DataGridCopyItems(ICollection<object> selectItems)
        //{
        //    if (selectItems.Count == 0)
        //        return;

        //    copyItems.Clear();
        //    foreach (var itemInList in _sequence)
        //    {
        //        foreach (var item in selectItems)
        //        {
        //            if (item == itemInList)
        //                copyItems.Add(item as Step);
        //        }
        //    }
        //}
        //private void DataGridPasteItems()
        //{
        //    if (copyItems.Count == 0)
        //        return;
        //    var pasteItems = new List<Step>();
        //    foreach (var item in copyItems)
        //    {
        //        pasteItems.Add(item.Clone() as Step);
        //    }
        //    if (SelectedIndex == -1)
        //        _sequence.AddRange(pasteItems);
        //    else
        //        _sequence.InsertRange(SelectedIndex, pasteItems);
        //}
        //private void DataGridExport()
        //{
        //    var dialog = new SaveFileDialog() { Filter = "csv files (*.csv)|*.csv;" };
        //    var result = dialog.ShowDialog();
        //    if (!result.Value)
        //        return;
        //    var fileStream = new FileStream(dialog.FileName, FileMode.Create);
        //    var streamWriter = new StreamWriter(fileStream, System.Text.Encoding.ASCII);
        //    string linestring = "";
        //    for (int i = 0; i < _sequence.Count; i++)
        //    {
        //        linestring = "";
        //        linestring += _sequence[i].Id.ToString() + ",";
        //        linestring += _sequence[i].StepTarget.ToString() + ",";
        //        if (_sequence[i].StepTarget == StepTarget.Wait)
        //            linestring += " " + ",";
        //        else
        //            linestring += _sequence[i].TargetValue.ToString() + ",";
        //        if (_sequence[i].StepTarget == StepTarget.Temperature)
        //        {
        //            linestring += " " + ",";
        //            linestring += " ";
        //        }
        //        else
        //        {
        //            linestring += _sequence[i].RampMode.ToString() + ",";
        //            linestring += _sequence[i].RampValue.ToString() + ",";
        //        }
        //        streamWriter.WriteLine(linestring);
        //    }
        //    streamWriter.Close();
        //    fileStream.Close();
        //}
        //private void DataGridImport()
        //{
        //    var dialog = new OpenFileDialog() { Filter = "csv files (*.csv)|*.csv;" };
        //    var result = dialog.ShowDialog();
        //    if (!result.Value)
        //        return;
        //    try
        //    {
        //        _sequence.Clear();
        //        var fileStream = new FileStream(dialog.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
        //        var streamReader = new StreamReader(fileStream, System.Text.Encoding.ASCII);
        //        string linestring = "";
        //        string[] linedata = null;
        //        while ((linestring = streamReader.ReadLine()) != null)
        //        {
        //            linedata = linestring.Split(',');
        //            StepTarget stepTarget = StepTarget.Current;
        //            double targetValue = 0;
        //            RampMode rampMode = RampMode.Time;
        //            double rampValue = 5;
        //            if (!Enum.TryParse(linedata[1], out stepTarget)) throw new Exception("Load data failed.");
        //            if (stepTarget != StepTarget.Wait)
        //            {
        //                if (!double.TryParse(linedata[2], out targetValue)) throw new Exception("Load data failed.");
        //            }
        //            if (stepTarget != StepTarget.Temperature)
        //            {
        //                if (!Enum.TryParse(linedata[3], out rampMode) ||
        //                !double.TryParse(linedata[4], out rampValue))
        //                    throw new Exception("Load data failed.");
        //            }
        //            var waveListItem = new Step(dataService)
        //            {
        //                StepTarget = stepTarget,
        //                TargetValue = targetValue.ToString(),
        //                RampMode = rampMode,
        //                RampValue = rampValue.ToString(),
        //            };
        //            _sequence.Add(waveListItem);
        //        }
        //        fileStream.Close();
        //        streamReader.Close();
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message);
        //    }
        //}

        public MainWindowViewModel()
        {
            //SequenceSettingCommand = new DelegateCommand(OnSequenceSetting);
            DataGridInsertCommand = new DelegateCommand(DataGridInsert);
            //DataGridDeleteCommand = new DelegateCommand<ICollection<object>>(DataGridDelete);
            //DataGridDeleteAllCommand = new DelegateCommand(DataGridDeleteAll);
            //DataGridCutItemsCommand = new DelegateCommand<ICollection<object>>(DataGridCutItems);
            //DataGridCopyItemsCommand = new DelegateCommand<ICollection<object>>(DataGridCopyItems);
            //DataGridPasteItemsCommand = new DelegateCommand(DataGridPasteItems);
            //DataGridExportCommand = new DelegateCommand(DataGridExport);
            //DataGridImportCommand = new DelegateCommand(DataGridImport);
        }
    }
}
