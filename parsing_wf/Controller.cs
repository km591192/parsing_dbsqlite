using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using parsing_wf.Model;

namespace parsing_wf
{
    class Controller
    {

        IInfoRepository rep = new SqLiteInfoRepository();
        GetSet getset = new GetSet();

        public string Listtostring(List<string> list)
        {
            string answer = String.Empty;
            foreach (var el in list)
            {
                answer += el + "\r\n";
            }
            return answer;
        }

        StringBuilder b = new StringBuilder();
        public string GetAll()
        {
            List<GetSet> gs = (List<GetSet>)rep.GetAll();
            string str = "";
           foreach (GetSet a in gs)
               b.AppendFormat("\r\nId:{0}\r\nURL: {1}\r\nStatus:{2}\r\nDescription status:{3}\r\nStatus code:{4}\r\nTitle:{5}\r\nDescription:{6}\r\nA-HREF:\r\n{7}Img tag:\r\n{8}H1:{9}\r\nTime:{10}\r\n",
                   a.id,a.url, a.httpstatus, a.statusdes, a.status, a.title, a.desc, a.hrefTag, a.imgTag, a.h, a.time);
            str = b.ToString();
            return str;

        }

        public string GetInfobyURL (string str)
        {
            try
            {
               return infofromdb(rep.GetInfobyURL(str));
            }
            catch (Exception ex) { return "Nothing was found by this URL"; }
        }
        public string GetInfobyId(string id)
        {
            try
            {
                return infofromdb(rep.GetInfo(Convert.ToInt32(id)));
            }
            catch (Exception ex) { return "Nothing was found by this ID"; }
        }
        public string GetInfobyId_URL()
        {
            try
            {
                List<GetSet> gs = (List<GetSet>)rep.GetAll();
                string str = "";
                foreach (GetSet a in gs)
                    b.AppendFormat("\r\nId:{0}\r\nURL: {1}\r\n",a.id, a.url);
                str = b.ToString();
                return str;
            }
            catch (Exception ex) { return ""; }
        }

        private string infofromdb(GetSet getset)
        {
            string id = getset.id.ToString();
            string website = getset.url;
            string httpstatuscode = getset.httpstatus;
            string statusdesc = getset.statusdes;
            string statuscode = getset.status;
            string titlestr = getset.title;
            string descstr = getset.desc;
            string hrefTags = getset.hrefTag;
            string imgTags = getset.imgTag;
            string h1 = getset.h;
            string timetaken = getset.time;

            StringBuilder SB = new StringBuilder();
            SB.AppendFormat("URL: {0}\r\nStatus:{1}\r\nDescription status:{2}\r\nStatus code:{3}\r\nTitle:{4}\r\nDescription:{5}\r\nA-HREF:\r\n{6}Img tag:\r\n{7}H1:{8}\r\nTime:{9}\r\nID:{10}\r\n",
                website, httpstatuscode, statusdesc, statuscode, titlestr, descstr, hrefTags, imgTags, h1, timetaken, id);
            string answer = SB.ToString();
            return answer;
        }
    }
}