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
using System.Data.SQLite;

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
        string path, stateProg = "Состояние: ", strCFT = "Количество найденых торрентов: ";
        bool sqLite;

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
            labelState.Text = stateProg;
            lableCountFoundTor.Text = strCFT;

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
                continueSearch = false;
                labelState.Text = stateProg + " остановка поиска";
                while (threadSearch.IsAlive) ;
                threadSearch.Abort();
                threadSearch = new Thread(Search);
                lableCountFoundTor.Text = strCFT + countTorrentsFound.ToString();
                labelState.Text = stateProg + " поиск остановлен";
                buttonNewSearch.Enabled = true;
                buttonStopSearch.Enabled = false;
                buttonContinueSearch.Enabled = true;
            }
        }

        private void xmlВSqLiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = "c:\\";
            ofd.Filter = "xml files (*.xml)|*xml";
            ofd.RestoreDirectory = true;

            ofd.ShowDialog();

            if (ofd.FileName != "")
            {
                XmlReader xmlToSqlReader = XmlReader.Create(ofd.FileName);
                string sqlDbTorrents, sqlDbContent, nameElement="";
                if (File.Exists("torrents.sqlite"))
                {
                    File.Delete("torrents.sqlite");
                }
                if (File.Exists("content.sqlite"))
                {
                    File.Delete("content.sqlite");
                }
                
                int countInTransaction = 0;

                SQLiteConnection.CreateFile("torrents.sqlite");
                SQLiteConnection.CreateFile("content.sqlite");

                SQLiteConnection m_dbTorrentsConnection = new SQLiteConnection("Data Source=torrents.sqlite;Version=3;");
                SQLiteConnection m_dbContentConnection = new SQLiteConnection("Data Source=content.sqlite;Version=3;");


                m_dbTorrentsConnection.Open();
                sqlDbTorrents= "CREATE TABLE[torrents](" +
                    "[id_topic] integer NOT NULL, " +
                    "[registred_at] integer NOT NULL, " +
                    "[size] integer NOT NULL, " +
                    "[title] text NOT NULL, " +
                    "[magnet] text NOT NULL, " +
                    "[id_forum] integer NOT NULL, " +
                    "[forum_name] text NOT NULL ); ";
                SQLiteTransaction transTorrents = m_dbTorrentsConnection.BeginTransaction();
                SQLiteCommand commandToDbTorrents = new SQLiteCommand(sqlDbTorrents, m_dbTorrentsConnection);
                commandToDbTorrents.ExecuteNonQuery();
                commandToDbTorrents.Transaction = transTorrents;

                m_dbContentConnection.Open();
                sqlDbContent = "CREATE TABLE[content] (" +
                    "[id_topic] integer NOT NULL, " +
                    "[content] text NOT NULL ); "; 
                SQLiteTransaction transContent = m_dbContentConnection.BeginTransaction();
                SQLiteCommand commandToDbContent = new SQLiteCommand(sqlDbContent, m_dbContentConnection);
                commandToDbContent.ExecuteNonQuery();
                commandToDbContent.Transaction = transContent;

                structTorrent temp = new structTorrent();
                while (xmlToSqlReader.Read())
                {
                    switch (xmlToSqlReader.NodeType)
                    {
                        case XmlNodeType.Element:
                            switch (xmlToSqlReader.Name)
                            {
                                case "torrent":
                                    nameElement = xmlToSqlReader.Name;
                                    temp.idTopic = Int32.Parse(xmlToSqlReader.GetAttribute("id"));
                                    temp.registred_at = DateTime.Parse(xmlToSqlReader.GetAttribute("registred_at"));
                                    temp.setSize(Int64.Parse(xmlToSqlReader.GetAttribute("size")));
                                    temp.magnetURL = "";
                                    temp.content = "";
                                    countTorrents++;
                                    break;
                                case "title":
                                    nameElement = xmlToSqlReader.Name;
                                    break;
                                case "magnet":
                                    nameElement = xmlToSqlReader.Name;
                                    break;
                                case "forum":
                                    nameElement = xmlToSqlReader.Name;
                                    temp.idForum = Int32.Parse(xmlToSqlReader.GetAttribute("id"));
                                    break;
                                case "content":
                                    nameElement = xmlToSqlReader.Name;
                                    break;
                            }
                            break;
                        case XmlNodeType.CDATA:
                            switch (nameElement)
                            {
                                case "title":
                                    temp.titel = xmlToSqlReader.Value;
                                    break;
                                case "magnet":
                                    temp.magnetURL = xmlToSqlReader.Value;
                                    break;
                                case "forum":
                                    temp.forumName = xmlToSqlReader.Value;
                                    break;
                                case "content":
                                    temp.content = xmlToSqlReader.Value;
                                    break;
                            }
                            break;
                        case XmlNodeType.EndElement:
                            if (xmlToSqlReader.Name == "torrent")
                            {
                                if (countInTransaction == 20000)
                                {

                                    transTorrents.Commit();
                                    transContent.Commit();

                                    transTorrents = m_dbTorrentsConnection.BeginTransaction();
                                    transContent = m_dbContentConnection.BeginTransaction();

                                    countInTransaction = 0;
                                }

                                var date = new DateTime(1970, 1, 1, 0, 0, 0, temp.registred_at.Kind);
                                var unixTimestamp = System.Convert.ToInt64((temp.registred_at - date).TotalSeconds);

                                sqlDbTorrents = "INSERT INTO [torrents] ([id_topic], [registred_at], [size], [title], [magnet], [id_forum], [forum_name]) VALUES (";
                                sqlDbTorrents += temp.idTopic.ToString() + ", '" + unixTimestamp.ToString() + "', " + temp.sizeByts.ToString() + ", '" + temp.titel.Replace("'", "''") + "', '" + temp.magnetURL + "', "  + temp.idForum.ToString() + ", '" + temp.forumName.Replace("'", "''") + "');";

                                commandToDbTorrents.CommandText = sqlDbTorrents;
                                commandToDbTorrents.ExecuteNonQuery();

                                sqlDbContent = "INSERT INTO [content] ([id_topic], [content]) VALUES (";
                                sqlDbContent += temp.idTopic.ToString() + ", '" + temp.content.Replace("'", "''") + "');";
                                commandToDbContent.CommandText = sqlDbContent;
                                commandToDbContent.ExecuteNonQuery();

                                countInTransaction++;
                            }
                            break;
                    }
                }
                
                transTorrents.Commit();
                transContent.Commit();

                m_dbTorrentsConnection.Close();
                m_dbContentConnection.Close();
            }
        }

        private void sqlInsetCommandTorrent(structTorrent temp, SQLiteConnection dbConTorrent)
        {
            var date = new DateTime(1970, 1, 1, 0, 0, 0, temp.registred_at.Kind);
            var unixTimestamp = System.Convert.ToInt64((temp.registred_at - date).TotalSeconds);

            string sqlDbTorrents = "INSERT INTO [torrents] ([id_topic], [registred_at], [size], [title], [id_forum], [forum_name]) VALUES (";
            sqlDbTorrents += temp.idTopic.ToString() + ", '" + unixTimestamp.ToString() + "', " + temp.sizeByts.ToString() + ", '" + temp.titel.Replace("'", "''") + "', " + temp.idForum.ToString() + ", '" + temp.forumName.Replace("'", "''") + "');";
            SQLiteCommand commandToDbTorrents = new SQLiteCommand(sqlDbTorrents, dbConTorrent);
            commandToDbTorrents.ExecuteNonQuery();
        }

        private void sqlInsetCommandContent(structTorrent temp, SQLiteConnection dbConContent)
        {
            string sqlDbContent = "INSERT INTO [content] ([id_topic], [content], [magnet]) VALUES (";
            sqlDbContent += temp.idTopic.ToString() + ", '" + temp.content.Replace("'", "''") + "', '" + temp.magnetURL + "');";
            SQLiteCommand commandToDbContent = new SQLiteCommand(sqlDbContent, dbConContent);
            commandToDbContent.ExecuteNonQuery();
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
        
        private void Search()
        {
            string[] SearchParts = textFieldSearch.Text.Split(' ');

            structTorrent temp = new structTorrent();

            string nameElement = "";
            bool suitable = false;
            
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
