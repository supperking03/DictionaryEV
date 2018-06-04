using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace đồ_án_làm_lại
{
    class DictEV : Idict
    {
        private Dictionary<string, string> dic = new Dictionary<string, string>();
        public DictEV()
        {

        }
        public string getName(string a)
        {
            string first = new StringReader(a).ReadLine(); // read the first line
            int pos = 0;
            for (int i = 0; i < first.Length; i++) // search for the first / and find pos
            {
                if (first[i] == '/')
                {
                    pos = i - 1;
                    break;
                }
            }
            return first.Substring(0, pos); // cut name from the first line
        }
        public void load()
        {
            // lấy dữ liệu từ file txt
            FileStream fs = new FileStream("tudien.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs, Encoding.UTF8);

            string a = sr.ReadToEnd();
            string[] g = new string[10];
            g = a.Split('@');
            fs.Close();

            for (int i = 0; i < g.Length; i++)
            {
                // add từ xử lý từ bị trùng
                if (!dic.ContainsKey(getName(g[i])))
                    dic.Add(getName(g[i]), g[i]); // add new entry
                else
                    dic[getName(g[i])] = g[i]; // update entry value

            }
           
            // load từ đã thêm
            FileStream fss = new FileStream("WordAdded.txt", FileMode.Open);
            StreamReader srr = new StreamReader(fss, Encoding.UTF8);

            string aa = srr.ReadToEnd();
            string[] gg = new string[10];
            gg = aa.Split('@');
            fss.Close();

            for (int i = 0; i < gg.Length; i++)
            {
                // add từ xử lý từ bị trùng
                if (!dic.ContainsKey(gg[i].Split('/')[0]))
                    dic.Add(gg[i].Split('/')[0], gg[i].Split('/')[1]); // add new entry
                else
                    dic[gg[i].Split('/')[0]] = gg[i].Split('/')[0]; // update entry value

            }

        }
        public string search(string a)
        {
            if (dic.ContainsKey(a))
            {
                dic[a] = dic[a].Replace("=", "- ");
                return dic[a].Replace("+", " = ");
            }
            else return "Không tìm thấy từ này !";
        }
        public void save(string a)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter("saveEV.txt", true))
            {
                file.WriteLine(a.ToLower());
            }
        }
        public void add(string _key,string _value)
        {
            dic.Add(_key, _value);
        }
        public void remove(string _key)
        {
            dic.Remove(_key);
        }

        public Dictionary<string, string> Dic
        { 
            get
            {
                return dic;
            }
            set
            {
                dic = value;
            }
        }
    }
}
