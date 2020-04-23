using System.IO;
using System.Windows.Forms;
using GalaSoft.MvvmLight.Command;
using MusicXmlSchema;
using WPF.App.Model.Base;
using Application = System.Windows.Application;
using Window = System.Windows.Window;

namespace WPF.App.ViewModel
{
    public class MusicXmlLoadVM : Singleton<MusicXmlLoadVM>
    {
        public Window MainWindow => Application.Current.MainWindow;

        #region 构造函数
        public MusicXmlLoadVM()
        {
            instance = this;
        }
        #endregion

        #region 绑定属性

        string _filePath;
        public string FilePath
        {
            get => _filePath;
            set => Set(ref _filePath, value, "FilePath");
        }

        ScoreData _scoreData;
        public ScoreData ScoreData
        {
            get => _scoreData;
            set => Set(ref _scoreData, value, "ScoreData");
        }

        #endregion

        #region 绑定命令

        RelayCommand _openFile;
        public RelayCommand OpenFile => _openFile ?? (_openFile = new RelayCommand(() =>
        {
            var dialog = new OpenFileDialog
            {
                Filter = "MusicXML files|*.musicxml"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                FilePath = dialog.FileName;
                if (File.Exists(FilePath))
                {
                    ScoreData = MusicXmlParser.GetScore(FilePath);
                }
            }
        }));

        RelayCommand _play;
        public RelayCommand Play => _play ?? (_play = new RelayCommand(() =>
        {

        }));

        #endregion

    }
}