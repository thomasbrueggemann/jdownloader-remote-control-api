using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jDownloaderRemoteControlAPI
{
    public enum DownloadStatus
    {
        RUNNING,
        NOT_RUNNING,
        STOPPING
    }

    public class jDownloaderRemoteControlAPI
    {
        private string _host;
        private int _port;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Host">The host url of jDownloader RemoteControl</param>
        /// <param name="Port">The port jDownloader RemoteControl is listenig</param>
        public jDownloaderRemoteControlAPI(string Host, int Port)
        {
            // sanitize host url
            string tmpHost = Host;
            if (!Host.StartsWith("http://")) tmpHost = "http://" + tmpHost;

            // set properties
            this._host = tmpHost;
            this._port = Port;
        }

        /// <summary>
        /// Constructor, assuming Host is localhost
        /// </summary>
        /// <param name="Port">The port jDownloader RemoteControl is listenig</param>
        public jDownloaderRemoteControlAPI(int Port)
        {
            // set properties
            this._host = "http://localhost";
            this._port = Port;
        }

        /// <summary>
        /// Constructor, that uses default values from jDownloader
        /// </summary>
        public jDownloaderRemoteControlAPI()
        {
            this._host = "http://localhost";
            this._port = 10025;
        }

        private string BaseUrl
        {
            get
            {
                return this._host + ":" + this._port + "/";
            }
        }

        #region Values

            /// <summary>
            /// Returns the current download speed
            /// </summary>
            /// <returns>The Speed</returns>
            public double CurrentSpeed
            {
                get
                {
                    string a = "get/speed";
                    Remote r = new Remote(this.BaseUrl + a, "GET");

                    return Double.Parse(r.Response());
                }
            }
            /// <summary>
            /// Get IP
            /// </summary>
            public string IP
            {
                get
                {
                    string a = "get/ip";
                    Remote r = new Remote(this.BaseUrl + a, "GET");

                    return r.Response();
                }
            }

            /// <summary>
            /// Answers with Random IP as replacement for real IP-Check
            /// </summary>
            public string RandomIP
            {
                get
                {
                    string a = "get/randomip";
                    Remote r = new Remote(this.BaseUrl + a, "GET");

                    return r.Response();
                }
            }

            /// <summary>
            /// Get config
            /// </summary>
            public string Config
            {
                get
                {
                    string a = "get/config";
                    Remote r = new Remote(this.BaseUrl + a, "GET");

                    return r.Response();
                }
            }

            /// <summary>
            /// Get Version
            /// </summary>
            public string Version
            {
                get
                {
                    string a = "get/version";
                    Remote r = new Remote(this.BaseUrl + a, "GET");

                    return r.Response();
                }
            }

            /// <summary>
            /// Get RemoteControl Version
            /// </summary>
            public int RCVersion
            {
                get
                {
                    string a = "get/rcversion";
                    Remote r = new Remote(this.BaseUrl + a, "GET");

                    return Int32.Parse(r.Response());
                }
            }

            /// <summary>
            /// Get current Speedlimit
            /// </summary>
            public double SpeedLimit
            {
                get
                {
                    string a = "get/speedlimit";
                    Remote r = new Remote(this.BaseUrl + a, "GET");

                    return Double.Parse(r.Response());
                }
                set
                {
                    string a = "action/set/download/limit/" + value.ToString();
                    Remote r = new Remote(this.BaseUrl + a, "GET");
                    r.Response();
                }
            }

            /// <summary>
            /// Get If Reconnect
            /// </summary>
            public bool IsReconnect
            {
                get
                {
                    string a = "get/isreconnect";
                    Remote r = new Remote(this.BaseUrl + a, "GET");

                    return Boolean.Parse(r.Response());
                }
            }

            /// <summary>
            /// Get Downloadstatus.
            /// Values: RUNNING, NOT_RUNNING, STOPPING
            /// </summary>
            public DownloadStatus DownloadStatus
            {
                get
                {
                    string a = "get/downloadstatus";
                    Remote r = new Remote(this.BaseUrl + a, "GET");

                    return (DownloadStatus)Enum.Parse(typeof(DownloadStatus), r.Response());
                }
            }

            /// <summary>
            /// Get amount of current downloads
            /// </summary>
            public int CountCurrentDownloads
            {
                get
                {
                    string a = "get/downloads/currentcount";
                    Remote r = new Remote(this.BaseUrl + a, "GET");

                    return Int32.Parse(r.Response());
                }
            }

            /// <summary>
            /// Get current downloads list
            /// </summary>
            public List<String> CurrentDownloads
            {
                get
                {
                    string a = "get/downloads/currentlist";
                    Remote r = new Remote(this.BaseUrl + a, "GET");

                    return null;//r.Response();
                }
            }

            /// <summary>
            /// Get amount of downloads in list
            /// </summary>
            public int CountAllDownloads
            {
                get
                {
                    string a = "get/downloads/allcount";
                    Remote r = new Remote(this.BaseUrl + a, "GET");

                    return Int32.Parse(r.Response());
                }
            }

            /// <summary>
            /// Get list of all downloads in list
            /// </summary>
            public List<String> AllDownloads
            {
                get
                {
                    string a = "get/downloads/alllist";
                    Remote r = new Remote(this.BaseUrl + a, "GET");

                    return null;// r.Response();
                }
            }

            /// <summary>
            /// Get amount of finished Downloads
            /// </summary>
            public int CountFinishedDownloads
            {
                get
                {
                    string a = "get/isreconnect/";
                    Remote r = new Remote(this.BaseUrl + a, "GET");

                    return Int32.Parse(r.Response());
                }
            }

            /// <summary>
            /// Get finished Downloads List
            /// </summary>
            public List<String> FinishedDownloads
            {
                get
                {
                    string a = "get/downloads/finishedlist";
                    Remote r = new Remote(this.BaseUrl + a, "GET");

                    return null;// r.Response();
                }
            }

        #endregion

        #region Actions

            /// <summary>
            /// Start DLs
            /// </summary>
            public void Start()
            {
                string a = "action/start/";
                Remote r = new Remote(this.BaseUrl + a, "GET");
                r.Response();
            }

            /// <summary>
            /// Pause DLs
            /// </summary>
            public void Pause()
            {
                string a = "action/pause/";
                Remote r = new Remote(this.BaseUrl + a, "GET");
                r.Response();
            }

            /// <summary>
            /// Stop DLs
            /// </summary>
            public void Stop()
            {
                string a = "action/stop/";
                Remote r = new Remote(this.BaseUrl + a, "GET");
                r.Response();
            }

            /// <summary>
            /// Toggle DLs
            /// </summary>
            public void Toggle()
            {
                string a = "action/toggle/";
                Remote r = new Remote(this.BaseUrl + a, "GET");
                r.Response();
            }

            /// <summary>
            /// Do Webupdate
            /// </summary>
            /// <param name="force">Activates auto-restart if update is possible</param>
            public void Update(bool force = false)
            {
                int fInt = (force == true) ? 1 : 0;
                string a = "action/update/force"+fInt+"";
                Remote r = new Remote(this.BaseUrl + a, "GET");
                r.Response();
            }

            /// <summary>
            /// Do Reconnect
            /// </summary>
            public void Reconnect()
            {
                string a = "action/reconnect/";
                Remote r = new Remote(this.BaseUrl + a, "GET");
                r.Response();
            }

            /// <summary>
            /// Restart JD
            /// </summary>
            public void Restart()
            {
                string a = "action/restart/";
                Remote r = new Remote(this.BaseUrl + a, "GET");
                r.Response();
            }

            /// <summary>
            /// Shutdown JD
            /// </summary>
            public void Shutdown()
            {
                string a = "action/shutdown/";
                Remote r = new Remote(this.BaseUrl + a, "GET");
                r.Response();
            }

            /// <summary>
            /// Set max sim. Downloads
            /// </summary>
            /// <param name="Downloads"></param>
            public void SetMaximumSimulatanousDownloads(int Downloads)
            {
                string a = "action/set/download/max/" + Downloads.ToString();
                Remote r = new Remote(this.BaseUrl + a, "GET");
                r.Response();
            }

            /// <summary>
            /// Add links to grabber
            /// </summary>
            /// <param name="Links"></param>
            /// <param name="Grabber">Hide/Show LinkGrabber</param>
            /// <param name="Start">Start downloads afterwards</param>
            public void AddLinks(List<String> Links, bool Grabber = false, bool Start = true)
            {
                int iGrabber = (Grabber == true) ? 1 : 0;
                int iStart = (Start == true) ? 1 : 0;
                string links = String.Empty;

                foreach(string link in Links)
                {
                    links += link + " ";
                }

                string a = "action/add/links/grabber" + iGrabber + "/start" + iStart + "/"+ links;
                Remote r = new Remote(this.BaseUrl + a, "GET");
                r.Response();
            }

            /// <summary>
            /// Add links to grabber
            /// </summary>
            /// <param name="Links"></param>
            /// <param name="Grabber">Hide/Show LinkGrabber</param>
            /// <param name="Start">Start downloads afterwards</param>
            public void AddContainer(List<String> ContainerPaths, bool Grabber = false, bool Start = true)
            {
                int iGrabber = (Grabber == true) ? 1 : 0;
                int iStart = (Start == true) ? 1 : 0;
                string containers = String.Empty;

                foreach (string path in ContainerPaths)
                {
                    containers += path + " ";
                }

                string a = "action/add/container/grabber" + iGrabber + "/start" + iStart + "/" + containers;
                Remote r = new Remote(this.BaseUrl + a, "GET");
                r.Response();
            }

            /// <summary>
            /// Save DLC-Container with all links to path
            /// </summary>
            /// <param name="ToPath"></param>
            public void SaveContainer(String ToPath)
            {
                string a = "action/save/container/" + ToPath;
                Remote r = new Remote(this.BaseUrl + a, "GET");
                r.Response();
            }

            /// <summary>
            /// Set Reconnect enabled or not
            /// </summary>
            /// <param name="Value"></param>
            public void SetReconnectEnabled(bool Value)
            {
                string a = "action/set/reconnectenabled/" + Value.ToString();
                Remote r = new Remote(this.BaseUrl + a, "GET");
                r.Response();
            }

            /// <summary>
            /// Set Use Premium enabled or not
            /// </summary>
            /// <param name="Value"></param>
            public void SetPremiumEnabled(bool Value)
            {
                string a = "action/set/premiumenabled/" + Value.ToString();
                Remote r = new Remote(this.BaseUrl + a, "GET");
                r.Response();
            }

        #endregion
    }
}
