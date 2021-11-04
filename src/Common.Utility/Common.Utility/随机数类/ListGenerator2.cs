using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utility
{
    /// <summary>
    /// 随机数组分区列表
    /// </summary>
    public class ListGenerator2
    {
        public ListGenerator2_ItemModel[] Rows { get; set; }
        public ListGenerator2_ItemTypeCount[] Type1 { get; set; }
        public ListGenerator2_ItemTypeCount[] Type2 { get; set; }
        public ListGenerator2(ListGenerator2_ItemModel[] rows, ListGenerator2_ItemTypeCount[] type1, ListGenerator2_ItemTypeCount[] type2)
        {
            Rows = rows;
            Type1 = type1;
            Type2 = type2;
        }
        public ListGenerator2_ItemModel[] Randomize()
        {
            int count = Type1.Sum(o => o.Count);
            var list = new List<ListGenerator2_ItemModel>();

            //检查参数
            if (count != Type2.Sum(o => o.Count)) throw new Exception("类型数量不正确");
            if (count > Rows.Length) throw new Exception("类型数量不能大于总数量");

            //设置分组
            ListGenerator2_ItemTypeCount[] type1 = Type1.Select(o => new ListGenerator2_ItemTypeCount() { Type = o.Type, Count = o.Count }).ToArray(),
                type2 = Type2.Select(o => new ListGenerator2_ItemTypeCount() { Type = o.Type, Count = o.Count }).ToArray();
            var groups = new List<Tuple<ListGenerator2_ItemTypeCount, ListGenerator2_ItemTypeCount>>();
            foreach (ListGenerator2_ItemTypeCount item1 in Type1)
                foreach (ListGenerator2_ItemTypeCount item2 in Type2)
                    groups.Add(new Tuple<ListGenerator2_ItemTypeCount, ListGenerator2_ItemTypeCount>(item1, item2));
            var groupsDic = new Dictionary<Tuple<ListGenerator2_ItemTypeCount, ListGenerator2_ItemTypeCount>, Tuple<int, int>>();
            foreach (Tuple<ListGenerator2_ItemTypeCount, ListGenerator2_ItemTypeCount> item in groups)
                groupsDic[item] = new Tuple<int, int>(Rows.Where(o => o.Type1 == item.Item1.Type && o.Type2 == item.Item2.Type).Count(), 0);

            //计算分组
            int times = count * 1;
            for (int i = 0, num = 0; i < times; i++)
            {
                foreach (Tuple<ListGenerator2_ItemTypeCount, ListGenerator2_ItemTypeCount> item in groups)
                {
                    Tuple<int, int> value = groupsDic[item];
                    ListGenerator2_ItemTypeCount item1 = item.Item1, item2 = item.Item2;
                    if (count > num && value.Item1 > 0 && item1.Count > 0 && item2.Count > 0)
                    {
                        value = new Tuple<int, int>(value.Item1 - 1, value.Item2 + 1);
                        num += 1; item1.Count -= 1; item2.Count -= 1;
                        groupsDic[item] = value;
                        continue;
                    }
                }
            }

            //检查分组
            foreach (ListGenerator2_ItemTypeCount item1 in type1)
            {
                int c = 0; foreach (Tuple<ListGenerator2_ItemTypeCount, ListGenerator2_ItemTypeCount> item in groups)
                    if (item.Item1.Type == item1.Type) c += groupsDic[item].Item2;
                if (c > item1.Count) throw new Exception($"【{item1.Type}】数量不正确");
            }
            foreach (ListGenerator2_ItemTypeCount item2 in type2)
            {
                int c = 0; foreach (Tuple<ListGenerator2_ItemTypeCount, ListGenerator2_ItemTypeCount> item in groups)
                    if (item.Item2.Type == item2.Type) c += groupsDic[item].Item2;
                if (c > item2.Count) throw new Exception($"【{item2.Type}】数量不正确");
            }

            //输出日志
#if DEBUG
            foreach (Tuple<ListGenerator2_ItemTypeCount, ListGenerator2_ItemTypeCount> item in groupsDic.Keys)
                Console.WriteLine($"{item.Item1.Type.PadLeft(4, ' ')} {item.Item2.Type.PadLeft(4, ' ')} {groupsDic[item].Item2.ToString().PadLeft(4, ' ')}   /{(groupsDic[item].Item1 + groupsDic[item].Item2).ToString().PadLeft(4, ' ')}");
#endif
            //填充列表
            Random a = new Random(Guid.NewGuid().GetHashCode());
            foreach (Tuple<ListGenerator2_ItemTypeCount, ListGenerator2_ItemTypeCount> item in groupsDic.Keys)
            {
                var l = Rows.Where(o => o.Type1 == item.Item1.Type && o.Type2 == item.Item2.Type).ToList();
                for (int i = 0, len = groupsDic[item].Item2; 0 < len && 0 < l.Count; len--)
                {
                    i = a.Next(0, l.Count);
                    list.Add(l[i]);
                    l.RemoveAt(i);
                }
            }
            return list.ToArray();
        }
    }
    public class ListGenerator2_ItemModel
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 类型1
        /// </summary>
        public string Type1 { get; set; }
        /// <summary>
        /// 类型2
        /// </summary>
        public string Type2 { get; set; }
    }
    public class ListGenerator2_ItemTypeCount
    {
        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int Count { get; set; }
    }
}
