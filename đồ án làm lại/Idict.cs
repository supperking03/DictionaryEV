using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace đồ_án_làm_lại
{
    public interface Idict
    {
        string search(string a);
        void load();
        void add(string _key, string _value);
        void remove(string _key);
        void save(string a);
        string getName(string a);

        Dictionary<string, string> Dic { get; set; }
    }
}
