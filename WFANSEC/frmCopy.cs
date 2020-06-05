using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WFANSEC
{
    //pafap_global namespace;
    namespace pafap_global
    {
        public class Init
        {
            public static string logfile;
            public static string listfile;
            public static string tmplistfile;

            public void readConf()
            {
                pafap_files pf = new pafap_files();
                logfile = pf.GetValueFromXmlFile("configure.xml", "conf/LogFile");
                listfile = pf.GetValueFromXmlFile("configure.xml", "conf/FileName");
                tmplistfile = pf.GetValueFromXmlFile("configure.xml", "conf/TempFile");
            }
        }
    }

    public partial class Copy : Form
    {
        private class UIProgress
        {
            public UIProgress(string _source, string _dest, long _bytes, long _maxbytes, int _count)
            {
                source = _source;
                destination = _dest;
                bytes = _bytes;
                maxbytes = _maxbytes;
                count = _count;
            }
            public string source;
            public string destination;
            public long bytes;
            public long maxbytes;
            public int count;
        }
        private class UIError
        {
            public UIError(Exception ex, string _path)
            {
                msg = ex.Message;
                path = _path;
                result = DialogResult.Cancel;
            }
            public string msg;
            public string path;
            public DialogResult result;
        }
        bool done = false;
        private DateTime start = new DateTime();
        public FileSystemWatcher watcher = new FileSystemWatcher();
        public bool OnChangedWatching = false;
        private BackgroundWorker bw;
        private delegate void ProgressChanged(UIProgress info);
        private delegate void CopyError(UIError err);
        private ProgressChanged OnChange;
        private CopyError OnError;
        public int nrOFfilesCopied = 0;
        string list;
        string tmplist;
        string log;

        public Copy()
        {
            InitializeComponent();
            pafap_global.Init init = new pafap_global.Init();
            init.readConf();
            this.lbl_source.Text = string.Empty;
            this.lbl_dest.Text = string.Empty;
            this.lbl_nrfn.Text = string.Empty;
            this.lblkbps.Text = string.Empty;
            this.lblcompleted.Text = string.Empty;
            this.lblelapsed.Text = string.Empty;
            this.lblremaining.Text = string.Empty;
            bw = new BackgroundWorker();
            bw.DoWork += Copier_DoWork;
            bw.RunWorkerCompleted += Copier_RunWorkerCompleted;
            bw.WorkerSupportsCancellation = true;
            OnChange += Copier_ProgressChanged;
            OnError += Copier_Error;
            this.watcher.Changed += new FileSystemEventHandler(WatchOnChanged);
        }

        private void Copier_DoWork(object sender, DoWorkEventArgs e)
        {
            pafap_files pf = new pafap_files();
            pafap_lists pl = new pafap_lists();
            list = pafap_global.Init.listfile;
            tmplist = pafap_global.Init.tmplistfile;
            log = pafap_global.Init.logfile;
            do
            {
                if (!pf.checkIfIsOpen(list)) pf.makeTempFile(list, tmplist);
                if (!pf.checkIfIsOpen(list)) pf.clearFile(list);
                pl.init();
                pf.readLinesFromFile(tmplist, '>', pl);
                nrOFfilesCopied = pl.l.Count;
                int findex = 0;
                start = DateTime.Now;
                foreach (pafap_files.loadpath plp in pl.l)
                {
                    try
                    {
                        findex++;
                        FileInfo fis = new FileInfo(plp.source);
                        FileInfo fid = new FileInfo(plp.destination + Path.GetFileName(plp.source));
                        using (FileStream sourceStream = new FileStream(plp.source, FileMode.Open, FileAccess.Read))
                        {
                            byte[] buffer = new byte[64 * 1024];
                            using (FileStream destStream = new FileStream(plp.destination + Path.GetFileName(plp.source), FileMode.Create))
                            {
                                int j;
                                while ((j = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
                                {
                                    destStream.Write(buffer, 0, j);
                                    this.Invoke(OnChange, new object[] { new UIProgress(plp.source, plp.destination, sourceStream.Position, fis.Length, findex) });
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        UIError err = new UIError(ex, plp.source);
                        this.Invoke(OnError, new object[] { err });
                        //if (err.result == DialogResult.Cancel) continue;
                    }
                    if (pf.CheckFileHasCopied(plp.destination + Path.GetFileName(plp.source)))
                        pf.LogFile(plp.destination + Path.GetFileName(plp.source) + "Copied!", log);
                }
                if (done) pf.clearFile(tmplist);
                pl.l.Clear();
            } while (!pf.checkIsEmpty(list));
        }

        private void Copier_ProgressChanged(UIProgress info)
        {
            TimeSpan ts = DateTime.Now - start;
            this.pbcompleted.Maximum = nrOFfilesCopied;
            this.pbcurrent.Value = (int)(100 * info.bytes / info.maxbytes);
            long copied = info.bytes / 1024;
            long total = info.maxbytes / 1024;
            this.lbl_source.Text = "From: " + info.source;
            this.lbl_dest.Text = "To: " + info.destination;
            this.lblkbps.Text = "Transfered: " + copied + " /" + total + " bytes";
            this.lbl_nrfn.Text = "Files: " + Convert.ToString(info.count) + "/ " + nrOFfilesCopied + " Copied!";
            this.lblcompleted.Text = "Completed: %" + (info.bytes * 100 / info.maxbytes).ToString();
            this.lblelapsed.Text = "Elapsed: " + Convert.ToInt32(ts.TotalSeconds).ToString() + " seconds";
            this.lblremaining.Text = "Remaining: " + ((info.maxbytes - info.bytes) * Convert.ToInt32(ts.TotalSeconds) / info.bytes).ToString() + " seconds";
            this.pbcompleted.Value = info.count;
        }

        private void Copier_Error(UIError err)
        {
            pafap_files pf = new pafap_files();
            string msg = string.Format("Copy file error: {0}\n{1}\n", err.path, err.msg);
            //err.result = MessageBox.Show(msg, "Copy error", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            pf.LogFile(msg, pafap_global.Init.logfile);
        }

        private void Copier_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            done = false;
            this.bw.CancelAsync();
            if (OnChangedWatching) btnCopy.Enabled = false;
            else btnCopy.Enabled = true;
        }

        public void startFileWatcher(string fn)
        {
            watcher.Path = Path.GetDirectoryName(fn);
            watcher.Filter = Path.GetFileName(fn);
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite;
            this.watcher.Changed += new FileSystemEventHandler(WatchOnChanged);
        }
        public void WatchOnChanged(object sender, FileSystemEventArgs e)
        {
            done = true;
            System.Threading.Thread.Sleep(1000);
            if (done && !this.bw.IsBusy) this.bw.RunWorkerAsync();
            else this.bw.CancelAsync();
        }

        private void chkwatch_CheckedChanged(object sender, EventArgs e)
        {
            if (chkwatch.Checked == true)
            {
                OnChangedWatching = true;
                startFileWatcher(pafap_global.Init.listfile);
                watcher.EnableRaisingEvents = OnChangedWatching;
                chkwatch.Text = "Watching";
                chkwatch.ForeColor = System.Drawing.Color.Green;
                btnCopy.Enabled = false;
            }
            else
            {
                OnChangedWatching = false;
                watcher.EnableRaisingEvents = OnChangedWatching;
                chkwatch.Text = "Watch";
                chkwatch.ForeColor = System.Drawing.Color.Red;
                btnCopy.Enabled = true;
            }
        }

        private void btnlog_Click(object sender, EventArgs e)
        {
            ViewLog vl = new ViewLog();
            vl.Show();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            done = true;
            btnCopy.Enabled = false;
            if (done && !this.bw.IsBusy) this.bw.RunWorkerAsync();
            else this.bw.CancelAsync();
        }

        private void Copy_Load(object sender, EventArgs e)
        {
            Icon viewIcon = new Icon("logo.ico");
            this.Icon = viewIcon;
        }

        private void TimeCalc(FileStream read, FileStream write)
        {
            DateTime start = DateTime.Now;
            byte[] buffer = new byte[8192];
            int i = read.Read(buffer, 0, 8192);
            while (i > 0)
            {
                TimeSpan ts = DateTime.Now - start;
                long percent = (read.Position * 100 / read.Length);
                string remaining = "Calculating";
                if (percent > 0)
                {
                    remaining = ((read.Length - read.Position) * Convert.ToInt32(ts.TotalSeconds) / read.Position).ToString();
                }
                lblcompleted.Text = "Completed: %" + percent.ToString();
                lblelapsed.Text = "Elapsed: " + ts.TotalSeconds.ToString() + " seconds";
                lblremaining.Text = "Remaining: " + remaining + " seconds";
                write.Write(buffer, 0, i);
                i = read.Read(buffer, 0, 8192);
            }
        }
    }
}
