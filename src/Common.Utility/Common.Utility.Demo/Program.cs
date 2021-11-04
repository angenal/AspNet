using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Common.Utility;

namespace Common.Utility.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //var url = "http://upload.qixueyun.com/UpLoadFiles/doc/20181114/%E4%B9%A1%E6%84%81%E9%99%84%E4%BB%B6_20181114103057133%20(1)_20181114162235945.doc";
            //var row = new { FilePath = "http://upload.qixueyun.com/UpLoadFiles/doc/20181114/乡愁附件_20181114103057133 (1)_20181114162235945.doc" };

            //var FilePath = row.FilePath.ChineseUrlEncode();
            //if (FilePath.Equals(url, StringComparison.OrdinalIgnoreCase))
            //    Console.WriteLine(FilePath);

            //随机数组
            //int count = 8; while (count-- >= 0)
            //{
            //    var ints = new ArrayGenerator().GenerateArray(50);
            //    Console.WriteLine($"{ints.Count}: {string.Join(",", ints)}");
            //}

            //随机数组分区列表
            //string filename = "dat.txt";
            //Console.WriteLine($"分组数据：{filename}");
            //string[] txts = System.IO.File.ReadAllLines(System.IO.Path.Combine(System.Environment.CurrentDirectory, filename));
            //var rows = new List<ListGenerator2_ItemModel>();
            //foreach (string txt in txts)
            //{
            //    string[] s = txt.Split(" \t".ToCharArray());
            //    rows.Add(new ListGenerator2_ItemModel { Id = s[0], Type1 = s[1], Type2 = s[2] });
            //}
            //var type1 = new ListGenerator2_ItemTypeCount[4]
            //{
            //    new ListGenerator2_ItemTypeCount(){ Type = "1", Count = 0 },
            //    new ListGenerator2_ItemTypeCount(){ Type = "2", Count = 0 },
            //    new ListGenerator2_ItemTypeCount(){ Type = "3", Count = 0 },
            //    new ListGenerator2_ItemTypeCount(){ Type = "4", Count = 10 },
            //};
            //var type2 = new ListGenerator2_ItemTypeCount[3]
            //{
            //    new ListGenerator2_ItemTypeCount(){ Type = "1", Count = 0 },
            //    new ListGenerator2_ItemTypeCount(){ Type = "2", Count = 0 },
            //    new ListGenerator2_ItemTypeCount(){ Type = "3", Count = 10 },
            //};
            //var listg = new ListGenerator2(rows.ToArray(), type1, type2);
            //var list = listg.Randomize();
            //Console.WriteLine("分组结果：list");
            //for (int i = 0; i < list.Length; i++) Console.WriteLine($"{(i + 1).ToString().PadLeft(2, ' ')}: {list[i].Id}");
            //Console.WriteLine();

            //周相关计算
            //Func<DateTime, int> funcWeek = (_) =>
            //{
            //    Console.WriteLine($"{TimeHelper.FormatDate(_, "0")} {DateTimeUtility.WeekDayName(_)} WeekOfMonth:{DateTimeUtility.WeekOfMonth(_, 1)}");
            //    Console.WriteLine();
            //    return 0;
            //};
            //funcWeek(new DateTime(2019, 7, 30));
            //funcWeek(new DateTime(2019, 7, 31));
            //funcWeek(new DateTime(2019, 8, 1));
            //funcWeek(new DateTime(2019, 8, 4));
            //funcWeek(new DateTime(2019, 8, 5));
            //funcWeek(new DateTime(2019, 8, 31));
            //funcWeek(new DateTime(2019, 9, 1));
            //funcWeek(new DateTime(2019, 9, 2));


            Console.Read();

        }
    }
}
