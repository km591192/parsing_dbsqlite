using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net;
using HtmlAgilityPack;
using parsing_wf.Model;

namespace parsing_wf
{
    class Pars
    {
            HttpClient http = new HttpClient();
            String source;
            HtmlAgilityPack.HtmlDocument Document = new HtmlAgilityPack.HtmlDocument();
            HttpWebRequest request;
            HttpWebResponse resp;
            WebClient client = new WebClient();

            Stopwatch timer = new Stopwatch();
            TimeSpan timetaken;

            Controller control = new Controller();
           IInfoRepository rep = new SqLiteInfoRepository();

            List<string> hrefTags = new List<string>();
            List<string> imgTags = new List<string>();

            public async Task<string> runparsing (string website)
            {
                string titlestr = String.Empty;
                string descstr = String.Empty;
                string ahref = String.Empty;
                string src = String.Empty;
                string h1 = String.Empty;
                string httpstatuscode = String.Empty;
                string statusdesc = String.Empty;
                string statuscode = String.Empty;
                string answer = String.Empty;

                try
                {
                    var date = DateTime.Now;
                    timer.Start();
                    if (!(website.StartsWith("http") || website.StartsWith("https")))
                        MessageBox.Show("no correct link (without http or https)");

                    request = (HttpWebRequest)WebRequest.Create(website);
                    resp = (HttpWebResponse)request.GetResponse();

                    if (request.HaveResponse)
                    {
                        timer.Stop();
                        timetaken = timer.Elapsed;

                        var response = await http.GetByteArrayAsync(website);
                        source = Encoding.GetEncoding("utf-8").GetString(response, 0, response.Length - 1);
                        source = WebUtility.HtmlDecode(source);
                        Document.LoadHtml(source);

                        httpstatuscode = (resp.StatusCode == HttpStatusCode.OK).ToString();
                        statusdesc = resp.StatusDescription;
                        statuscode = ((int)resp.StatusCode).ToString();

                        var nhref = Document.DocumentNode.SelectNodes("//a");
                        if (nhref != null)
                        {
                            foreach (var tag in nhref)
                            {
                                if (tag.Attributes["href"] != null)
                                {
                                    if (tag.Attributes["href"].Value != "#")
                                    {
                                        hrefTags.Add(tag.Attributes["href"].Value);
                                        ahref = tag.Attributes["href"].Value;
                                    }
                                }
                            }
                        }

                        var nimg = Document.DocumentNode.SelectNodes("//img");
                        if (nimg != null)
                        {
                            foreach (var tag in nimg)
                            {
                                if (tag.Attributes["src"] != null)
                                {
                                    if (!(tag.Attributes["src"].Value.Contains("data:")))
                                    {
                                        imgTags.Add(tag.Attributes["src"].Value);
                                        src = tag.Attributes["src"].Value;
                                    }
                                }
                            }
                        }


                        var nh1 = Document.DocumentNode.SelectNodes("//h1");
                        if (nh1 != null)
                        {
                            foreach (var tag in nh1)
                            {
                                h1 += tag.InnerText + "\n";
                            }
                        }

                        var ndesc = Document.DocumentNode.SelectNodes("//meta");
                        if (ndesc != null)
                        {
                            foreach (var tag in ndesc)
                            {
                                if (tag.Attributes["name"] != null && tag.Attributes["name"].Value == "description")
                                {
                                    descstr = tag.Attributes["content"].Value;
                                }
                            }
                        }

                        var ntitle = Document.DocumentNode.SelectNodes("//title");
                        if (ntitle != null)
                        {
                            titlestr = ntitle["title"].InnerText;
                        }

                        StringBuilder SB = new StringBuilder();
                        SB.AppendFormat("URL: {0}\r\nStatus:{1}\r\nDescription status:{2}\r\nStatus code:{3}\r\nTitle:{4}\r\nDescription:{5}\r\nA-HREF:\r\n{6}Img tag:\r\n{7}H1:{8}\r\n",
                            website, httpstatuscode, statusdesc, statuscode, titlestr, descstr, control.Listtostring(hrefTags), control.Listtostring(imgTags), h1);
                        answer = SB.ToString();

                        var info = new GetSet
                        {
                              url = website,
                              httpstatus = httpstatuscode,
                              statusdes = statusdesc,
                              status = statuscode,
                              title = titlestr,
                              desc = descstr,
                              hrefTag = control.Listtostring(hrefTags),
                              imgTag = control.Listtostring(imgTags),
                              h = h1,
                              time = timetaken.ToString()
                        };

                        rep.SaveInfo(info);

                    }

                    hrefTags.Clear();
                    imgTags.Clear();
                    resp.Close();
                    request.Abort();
                }
                catch (Exception ex)
                {
                    answer = ex.ToString();
                }
                return answer + "~" + timetaken;
            }

        }
    }


