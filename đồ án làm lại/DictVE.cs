using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace đồ_án_làm_lại
{
    class DictVE : Idict
    {
        private Dictionary<string, string> dic = new Dictionary<string, string>();
        public string getName(string a)
        {
            string first = new StringReader(a).ReadLine(); // read the first line
            return first; // cut name from the first line
        }
        public void load()
        {
            // lấy dữ liệu từ file txt
            FileStream fs = new FileStream("VE.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs, Encoding.UTF8);

            string a = sr.ReadToEnd();
            string[] g = new string[10];
            g = a.Split('@');
            fs.Close();

            for (int i = 0; i < g.Length; i++)
            {
                if (getName(g[i])!= null)
                {
                    // add từ xử lý từ bị trùng
                    if (!dic.ContainsKey(getName(g[i])))
                        dic.Add(getName(g[i]), g[i]); // add new entry
                    else
                        dic[getName(g[i])] = g[i]; // update entry value
                }
               
            }
        }
        public void save(string a)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter("saveVE.txt", true))
            {
                file.WriteLine(a.ToLower());
            }
        }
        public string search(string a)
        {
            if (dic.ContainsKey(a))
            {
               // sửa lỗi hiển thị
                dic[a] = dic[a].Replace("=", "- ");
                return dic[a].Replace("+"," = ");
            }
            else return "Không tìm thấy từ này !";
        }
        public void add(string _key, string _value)
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
