using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace bp_sys_wpf.ViewModel
{
    public class ComboBoxItemViewModel
    {
        private List<string> _hun;

        public List<string> hun
        {
            get
            {
                if (_hun == null)
                {
                    _hun = new List<string>();
                    _hun = LoadCharacters("hun");
                }
                return _hun;
            }
            set { _hun = value; }
        }

        private List<string> _sur;

        public List<string> sur
        {
            get
            {
                if (_sur == null)
                {
                    _sur = new List<string>();
                    _sur = LoadCharacters("sur");
                }
                return _sur;
            }
            set { _sur = value; }
        }

        private List<string> _BoList3;

        public List<string> BoList3
        {
            get {
                if (_BoList3 == null)
                {
                    _BoList3 = new List<string>();
                    _BoList3.Add("BO1 1st half");
                    _BoList3.Add("BO1 2nd half");
                    _BoList3.Add("BO2 1st half");
                    _BoList3.Add("BO2 2nd half");
                    _BoList3.Add("BO3 1st half");
                    _BoList3.Add("BO3 2nd half");
                    _BoList3.Add("Overtime 1st half");
                    _BoList3.Add("Overtime 2nd half");
                }
                return _BoList3; }
            set { _BoList3 = value; }
        }

        private List<string> _BoList5;

        public List<string> BoList5
        {
            get
            {
                if (_BoList5 == null)
                {
                    _BoList5 = new List<string>();
                    _BoList5.Add("BO1 1st half");
                    _BoList5.Add("BO1 2nd half");
                    _BoList5.Add("BO2 1st half");
                    _BoList5.Add("BO2 2nd half");
                    _BoList5.Add("BO3 1st half");
                    _BoList5.Add("BO3 2nd half");
                    _BoList5.Add("BO4 1st half");
                    _BoList5.Add("BO4 2nd half");
                    _BoList5.Add("BO5 1st half");
                    _BoList5.Add("BO5 2nd half");
                }
                return _BoList5;
            }
            set { _BoList5 = value; }
        }

        private List<string> _MapPick;

        public List<string> MapPick
        {
            get
            {
                if (_MapPick == null)
                {
                    _MapPick = new List<string>();
                    _MapPick.Add("The Red Church");
                    _MapPick.Add("Lakeside Village");
                    _MapPick.Add("Arms Factory");
                    _MapPick.Add("Leos Memory");
                    _MapPick.Add("Sacred Heart Hospital");
                    _MapPick.Add("China Town");
                    _MapPick.Add("Eversleeping Town");
                    _MapPick.Add("Moonlit River Park");
                }
                return _MapPick;
            }
            set { _MapPick = value; }
        }

        private List<string> _MapBan;

        public List<string> MapBan
        {
            get
            {
                if (_MapBan == null)
                {
                    _MapBan = new List<string>();
                    _MapBan.Add("No Ban");
                    _MapBan.Add("The Red Church");
                    _MapBan.Add("Lakeside Village");
                    _MapBan.Add("Arms Factory");
                    _MapBan.Add("Leos Memory");
                    _MapBan.Add("Sacred Heart Hospital");
                    _MapBan.Add("China Town");
                    _MapBan.Add("Eversleeping Town");
                    _MapBan.Add("Moonlit River Park");
                }
                return _MapBan;
            }
            set { _MapBan = value; }
        }

        private List<string> _Trait;

        public List<string> Trait
        {
            get
            {
                if (_Trait == null)
                {
                    _Trait = new List<string>();
                    _Trait.Add("Listen");
                    _Trait.Add("Abnormal");
                    _Trait.Add("Excitement");
                    _Trait.Add("Patroller");
                    _Trait.Add("Teleport");
                    _Trait.Add("Peepers");
                    _Trait.Add("Blink");
                    _Trait.Add("Warp");
                }
                return _Trait;
            }
            set { _Trait = value; }
        }


        public List<string> LoadCharacters(string type)
        {
            GetFilePath getFilePath = new GetFilePath();
            string filePath = getFilePath.GetAbsoluteFilePath("CharactersList.txt"); // 角色数据文件的路径  
            if (!File.Exists(filePath))
            {
                MessageBox.Show("未找到角色列表文件CharactersList.txt", "错误");
                Environment.Exit(0);
            }

            // 读取文件的所有行  
            string[] lines = File.ReadAllLines(filePath);

            // 创建一个字典用于存储角色列表  
            Dictionary<string, List<string>> characterLists = new Dictionary<string, List<string>>();

            // 遍历文件的每一行  
            foreach (string line in lines)
            {
                // 使用冒号分割键和值  
                string[] parts = line.Trim().Split(':');
                if (parts.Length == 2)
                {
                    // 获取键，并去除两边的空白字符  
                    string key = parts[0].Trim();

                    // 获取值，并去除两边的空白字符，以及开头和结尾的大括号  
                    string valueStr = parts[1].Trim();
                    valueStr = valueStr.TrimStart('{').TrimEnd('}');

                    // 使用逗号分割字符串得到角色列表  
                    string[] characters = valueStr.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    // 将字符串数组转换为List，并对列表中的项目进行排序  
                    List<string> sortedCharacters = characters.ToList().OrderBy(c => c).ToList();

                    // 将排序后的角色列表添加到字典中  
                    characterLists[key] = sortedCharacters;
                }
            }
            //返回字典
            return characterLists[type];
        }
    }
}
