using TextCleaner.BusinessLogic;
using TextCleaner.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace TextCleaner.ViewModel
{
    public class MainVM : BaseVM
    {
        public string TextBefore
        {
            get { return textBefore; }
            set
            {
                textBefore = value;
                OnPropertyChanged(nameof(TextBefore));
                ConvertText(null);//запуск конвертации
            }
        }
        private string textBefore = "";

        public string TextAfter
        {
            get { return textAfter; }
            set
            {
                textAfter = value;
                OnPropertyChanged(nameof(TextAfter));
            }
        }
        private string textAfter = "";


        #region Commands
        public ICommand PasteFromClipboardCommand
        {
            get
            {
                return pasteFromClipboardCommand ??
                  (pasteFromClipboardCommand = new RelayCommand(PasteFromClipboard));
            }
        }
        private ICommand pasteFromClipboardCommand = null;


        public ICommand CopyResultToClipboardCommand
        {
            get
            {
                return copyResultToClipboardCommand ??
                  (copyResultToClipboardCommand = new RelayCommand(CopyResultToClipboard));
            }
        }
        private ICommand copyResultToClipboardCommand = null;

        public ICommand ConvertTextCommand
        {
            get
            {
                return convertTextCommand ??
                  (convertTextCommand = new RelayCommand(ConvertText));
            }
        }
        private ICommand convertTextCommand = null;

        public ICommand FullCommand
        {
            get
            {
                return fullCommand ??
                  (fullCommand = new RelayCommand(Full));
            }
        }
        private ICommand fullCommand = null;

        public ICommand ShowAboutAppCommand
        {
            get
            {
                return showAboutAppCommand ??
                  (showAboutAppCommand = new RelayCommand(ShowAboutApp));
            }
        }
        private ICommand showAboutAppCommand = null;

        #region Window Menu
        public ICommand CloseCommand
        {
            get
            {
                return closeCommand ??
                  (closeCommand = new RelayCommand(Close));
            }
        }
        private ICommand closeCommand = null;

        public ICommand MinimizeCommand
        {
            get
            {
                return minimizeCommand ??
                  (minimizeCommand = new RelayCommand(Minimize));
            }
        }
        private ICommand minimizeCommand = null;
        #endregion
        #endregion

        #region Methods

        public void PasteFromClipboard(object o)
        {
            TextBefore = Clipboard.GetText();
        }

        public void CopyResultToClipboard(object o)
        {
            Clipboard.SetText(TextAfter);
        }

        private void ConvertText(object o)
        {
            try
            {
                var clearedText = Cleaner.RemoveSpecialSymbols(TextBefore, new List<char>() { '​' });

                var strings = new List<string>(clearedText.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.RemoveEmptyEntries));

                Cleaner.RemoveStartSpaces(strings);

                TextAfter = string.Join(Environment.NewLine, strings);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Something went wrong. Details: {ex.Message}");
            }
        }

        public void Full(object o)
        {
            PasteFromClipboard(null);
            CopyResultToClipboard(null);
        }

        public void ShowAboutApp(object o)
        {
            var aboutApp = new WindowAboutApp();
            aboutApp.ShowDialog();
        }

        public void Close(object o)
        {
            if (o is Window)
            {
                (o as Window).Close();
            }
        }

        public void Minimize(object o)
        {
            if (o is Window)
            {
                (o as Window).WindowState = WindowState.Minimized;
            }
        }
    }
    #endregion

}
