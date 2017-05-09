using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using System.Xml;

using System.Threading;

namespace rutracker
{
    public partial class MainWindow : Form
    {
        XmlReader reader;
        Size oldSize;
        List<structTorrent> foundTor;
        bool continueSearch, eof, endCyrcle;
        int countTorrents = 0, countTorrentsFound = 0;
        string path, stateProg = "Состояние: ";

        Thread threadSearch;
        delegate void delegateAddRow(structTorrent _st);
        delegate void delegateLableText(structTorrent _st);


        public MainWindow()
        {
            InitializeComponent();
            buttonNewSearch.Enabled = true;
            buttonStopSearch.Enabled = false;
            buttonContinueSearch.Enabled = false;

            path = "C:\\Users\\Dev\\Documents\\backup.20170208185701.xml";

            //path = ".\\backup.20170208185701.xml";
            if (!File.Exists(path))
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.InitialDirectory = "c:\\";
                ofd.Filter = "xml files (*.xml)|*xml";
                ofd.RestoreDirectory = true;

                ofd.ShowDialog();
                path = ofd.FileName;
            }
            oldSize = this.Size;
        }

        private void buttonStopSearch_Click(object sender, EventArgs e)
        {
            if (threadSearch.IsAlive)
            {
                string strCT = "Количество торрентов: ", strCFT = "Количество найденых торрентов: ";
                continueSearch = false;
                labelState.Text = stateProg + " остановка поиска";
                while (threadSearch.IsAlive) ;
                threadSearch.Abort();
                threadSearch = new Thread(Search);
                LableCountTorrents.Text = strCT + countTorrents.ToString();
                LableCountFoundTor.Text = strCFT + countTorrentsFound.ToString();
                labelState.Text = stateProg + " поиск остановлен";
                buttonNewSearch.Enabled = true;
                buttonStopSearch.Enabled = false;
                buttonContinueSearch.Enabled = true;
            }
        }

        private void buttonNewSearch_Click(object sender, MouseEventArgs e)
        {
            if (textFieldSearch.Text.Length > 2)
            {
                reader = XmlReader.Create(path);
                foundTor = new List<structTorrent>();
                FoundItemsView.Rows.Clear();

                threadSearch = new Thread(Search);
                continueSearch = true;
                if (threadSearch.ThreadState == ThreadState.Unstarted)
                {
                    threadSearch.Start();
                    labelState.Text = stateProg + " идет поиск";
                    buttonNewSearch.Enabled = false;
                    buttonStopSearch.Enabled = true;
                    buttonContinueSearch.Enabled = false;
                }
            }
            else
                MessageBox.Show("Введите тектс для поиска");
        }

        private void buttonContinueSearch_Click(object sender, EventArgs e)
        {
            threadSearch = new Thread(Search);
            continueSearch = true;
            if (threadSearch.ThreadState == ThreadState.Unstarted)
            {
                threadSearch.Start();
                labelState.Text = stateProg + " поиск продолжен";
                buttonNewSearch.Enabled = false;
                buttonStopSearch.Enabled = true;
                buttonContinueSearch.Enabled = false;
            }
        }
        /*
        private void SearchButtonClick(object sender, MouseEventArgs e)
        {
            if (threadSearch == null)
            {
                threadSearch = new Thread(Search);
            }
            if (threadSearch.IsAlive)
            {
                string strCT = "Количество торрентов: ", strCFT = "Количество найденых торрентов: ";
                continueSearch = false;
                this.buttonNewSearch.Text = "Поиск";
                labelState.Text = stateProg + " остановка поиска";
                while (threadSearch.IsAlive);
                threadSearch.Abort();
                threadSearch = new Thread(Search);
                LableCountTorrents.Text = strCT + countTorrents.ToString();
                LableCountFoundTor.Text = strCFT + countTorrentsFound.ToString();
                labelState.Text = stateProg + " поиск остановлен";
            }
            else
            {
                if (reader.EOF)
                {
                    reader = XmlReader.Create(path);
                    foundTor = new List<structTorrent>();
                    countTorrents = 0;
                    countTorrentsFound = 0;
                    FoundItemsView.Rows.Clear();
                }
                continueSearch = true;
                if(threadSearch.ThreadState == ThreadState.Unstarted)
                {
                    this.buttonNewSearch.Text = "Стоп";
                    threadSearch.Start();
                    labelState.Text = stateProg + " идет поиск";
                }
            }
        }
        */
        private void Search()
        {
            string[] SearchParts = textFieldSearch.Text.Split(' ');

            structTorrent temp = new structTorrent();

            string nameElement = "";
            bool suitable = false;

            endCyrcle = false;
            while (reader.Read() && continueSearch)
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        switch (reader.Name)
                        {
                            case "torrent":
                                nameElement = reader.Name;
                                temp.idTopic = Int32.Parse(reader.GetAttribute("id"));
                                temp.registred_at = DateTime.Parse(reader.GetAttribute("registred_at"));
                                temp.setSize(Int64.Parse(reader.GetAttribute("size")));
                                temp.magnetURL = "";
                                temp.content = "";
                                countTorrents++;
                                break;
                            case "title":
                                nameElement = reader.Name;
                                break;
                            case "magnet":
                                nameElement = reader.Name;
                                break;
                            case "forum":
                                nameElement = reader.Name;
                                temp.idForum = Int32.Parse(reader.GetAttribute("id"));
                                break;
                            case "content":
                                nameElement = reader.Name;
                                break;
                        }
                        break;
                    case XmlNodeType.CDATA:
                        switch (nameElement)
                        {
                            case "title":
                                if (searchInCDATA(SearchParts, reader.Value))
                                {
                                    temp.titel = reader.Value;
                                    suitable = true;
                                    countTorrentsFound++;
                                }
                                break;
                            case "magnet":
                                if (suitable)
                                {
                                    temp.magnetURL = reader.Value;
                                }
                                break;
                            case "forum":
                                if (suitable)
                                {
                                    temp.forumName = reader.Value;
                                }
                                break;
                            case "content":
                                if (suitable)
                                {
                                    temp.content = reader.Value;
                                }
                                break;
                        }
                        break;
                    case XmlNodeType.EndElement:
                        if (reader.Name == "torrent")
                        {
                            if (suitable)
                            {
                                foundTor.Add(temp);
                                if (FoundItemsView.InvokeRequired)
                                {
                                    delegateAddRow dAddRow = delegate (structTorrent st)
                                    {
                                        string[] str = new string[] { st.forumName, st.titel, st.getSize(), st.registred_at.ToShortDateString() };
                                        FoundItemsView.Rows.Add(str);
                                    };
                                    FoundItemsView.Invoke(dAddRow, temp);
                                }
                                else
                                {
                                    string[] str = new string[] { temp.forumName, temp.titel, temp.getSize(), temp.registred_at.ToShortDateString() };
                                    FoundItemsView.Rows.Add(str);
                                }
                            }
                            suitable = false;
                        }
                        break;
                }
            }
            if (continueSearch)
                MessageBox.Show("Поиск окончен");
            else
                MessageBox.Show("Поиск остановлен");
        }

        private bool searchInCDATA(string[] found, string inStr)
        {
            string str = inStr.ToLower();
            int countFound = 0;
            for (int i = 0; i < found.Length; i++)
                if (str.Contains(found[i].ToLower()))
                    countFound++;
            if (countFound == found.Length)
                return true;
            return false;
        }

        public struct structTorrent
        {
            public int idTopic, idForum;
            public DateTime registred_at;
            public Int64 sizeByts;
            short size;
            byte sizeUnit;
            string[] Units;
            public string titel,magnetURL,content,forumName;

            public void setSize(Int64 _size)
            {
                creataUnits();
                sizeUnit = 0;
                sizeByts = _size;
                Int64 _sizeT = _size;
                while (_sizeT > 1024)
                {
                    _sizeT /= 1024;
                    sizeUnit++;
                }
                size = (short)(_sizeT%short.MaxValue);
            }
            public string getSize()
            {
                if (sizeUnit < Units.Length)
                    return size.ToString() + " " + Units[sizeUnit];
                return size.ToString() + " " + Units[Units.Length - 1];
            }
            public void creataUnits()
            {
                Units = new string[] {"Б", "Кбайт", "Мбайт", "Гбайт", "Тбайт"};
            }
        }
    }
}
