using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinterHomework
{
    class Program
    {
        static void Main(string[] args)
        {
            //影片資料集合
            List<Video> videoList = new List<Video>() {
                new Video() { Name = "天竺鼠車車", Country = "日本", Duration = 2.6, Type = "動漫" },
                new Video() { Name = "鬼滅之刃", Country = "日本", Duration = 25, Type = "動漫" },
                new Video() { Name = "鬼滅之刃-無限列車", Country = "日本", Duration = 100, Type = "電影" },
                new Video() { Name = "甜蜜家園SweetHome", Country = "韓國", Duration = 50, Type = "影集" },
                new Video() { Name = "The 100 地球百子", Country = "歐美", Duration = 48, Type = "影集" },
                new Video() { Name = "冰與火之歌Game of thrones", Country = "歐美", Duration = 60, Type = "影集" },
                new Video() { Name = "半澤直樹", Country = "日本", Duration = 40, Type = "影集" },
                new Video() { Name = "古魯家族：新石代", Country = "歐美", Duration = 90, Type = "電影" },
                new Video() { Name = "角落小夥伴電影版：魔法繪本裡的新朋友", Country = "日本", Duration = 77, Type = "電影" },
                new Video() { Name = "TENET天能", Country = "歐美", Duration = 80, Type = "電影" },
                new Video() { Name = "倚天屠龍記2019", Country = "中國", Duration = 58, Type = "影集" },
                new Video() { Name = "下一站是幸福", Country = "中國", Duration = 45, Type = "影集" },
            };

            //人物資料集合
            List<Person> personList = new List<Person>()
            {
                new Person() { Name = "Bill", CountryPrefer = new List<string>() { "中國", "日本" }, TypePrefer = new List<string>() { "影集" } },
                new Person() { Name = "Jimmy", CountryPrefer = new List<string>() { "日本" }, TypePrefer = new List<string>() { "動漫", "電影" } },
                new Person() { Name = "Andy", CountryPrefer = new List<string>() { "歐美", "日本" }, TypePrefer = new List<string>() { "影集", "電影" } },
            };


            // 1. 找出所有日本的影片名稱
            Console.WriteLine($"{Environment.NewLine}Q: 找出所有日本的影片名稱");
            #region Ans01
            // 解1
            var japan_video = videoList.Where(x => x.Country == "日本").Select(x => x.Name);
            Console.WriteLine(string.Join(", ", japan_video));
            // 解2 
            Console.WriteLine(string.Join(Environment.NewLine, videoList.Where(x => x.Country == "日本").Select(x => x.Name)));
            #endregion

            // 2. 找出所有歐美的影片且類型為"影集"的影片名稱
            Console.WriteLine($"{Environment.NewLine}Q: 找出所有歐美的影片且類型為'影集'的影片名稱");
            // 解1
            var om = videoList.Where(x => x.Country == "歐美" && x.Type == "影集").Select(x => x.Name);
            Console.WriteLine(string.Join(", ", om));



            // 3. 是否有影片片長超過120分鐘的影片
            Console.WriteLine($"{Environment.NewLine}Q: 是否有影片片長超過120分鐘的影片");
            // 解1
            var dr_120 = videoList.Where(x => x.Duration > 120).Select(x => x.Name).ToList();
            Console.WriteLine(dr_120.Any() ? string.Join(", ", dr_120) : "NULL");
            // 解2 
            Console.WriteLine(videoList.Any(x => x.Duration > 120) ? "是" : "否");

            // 4. 請列出所有人的名稱，並且用大寫英文表示，ex: Bill -> BILL
            Console.WriteLine($"{Environment.NewLine}Q: 請列出所有人的名稱，並且用大寫英文表示");
            // 解1
            var name = personList.Select(x => x.Name.ToUpper());
            Console.WriteLine(string.Join(", ", name));


            // 5. 將所有影片用片長排序(最長的在前)，並顯示排序過的排名以及片名，ex: No1: 天竺鼠車車
            Console.WriteLine($"{Environment.NewLine}Q: 將所有影片用片長排序(最長的在前)，並顯示排序過的排名以及片名");
            // 解1
            var order_video = videoList.OrderByDescending(x => x.Duration).Select((x, index) => string.Concat("No", index + 1, ": ", x.Name));
            Console.WriteLine(string.Join(Environment.NewLine, order_video));
            // 解2
            videoList.OrderByDescending(x => x.Duration).Select((x, index) => $"No{index + 1} : {x.Name}");
            //new string(" ", Encoding.Default.GetByteCount("123")); // 切齊空格

            // 6. 將所有影片進行以"類型"分類，並顯示以下樣式(注意縮排)
            /* 
            動漫:
                天竺鼠車車
                鬼滅之刃
            */
            Console.WriteLine($"{Environment.NewLine}Q: 將所有影片進行以'類型'分類");
            // 解1
            var group_video = videoList.GroupBy(x => x.Type);
            foreach (var item in group_video)
            {
                Console.WriteLine($"{item.Key}:");
                foreach (var p in item)
                {
                    Console.WriteLine($"    {p.Name}");
                }
            }
            // 解2
            Console.WriteLine(string.Join(Environment.NewLine, videoList.GroupBy(x => x.Type).Select(x => string.Concat($"{x.Key} : \n", string.Join(Environment.NewLine, x.Select(y => $"\t{y.Name}"))))));


            // 7. 找到第一個喜歡歐美影片的人
            Console.WriteLine($"{Environment.NewLine}Q: 找到第一個喜歡歐美影片的人");
            // 解1
            var person1 = personList.FirstOrDefault((x) => x.CountryPrefer.Contains("歐美")); //預設值為NULL
            Console.WriteLine(person1.Name);
            // 解2
            var person01 = personList.FirstOrDefault((x) => x.CountryPrefer.Contains("歐美")).Name;

            // 8. 找到每個人喜歡的影片(根據國家以及類型)，ex: Bill: 天竺鼠車車, 倚天屠龍記2019
            Console.WriteLine($"{Environment.NewLine}Q: 找到每個人喜歡的影片");
            // 解1
            var output1 = from v in videoList
                          from p in personList
                          where p.CountryPrefer.Any(ct => v.Country.Contains(ct)) && p.TypePrefer.Any(ct => v.Type.Contains(ct))
                          select new { p.Name, video = v.Name };
            var output2 = output1.GroupBy((x) => x.Name, y => y.video, (pName, vName) => new { pName, vName }).Select(x => string.Concat(x.pName + ": ", string.Join(", ", x.vName)));
            Console.WriteLine(string.Join(Environment.NewLine, output2));
            // 解2
            personList.ForEach(p => 
            { 
                Console.WriteLine($"{p.Name} : ");
                Console.WriteLine(string.Join(",", videoList.Where(x => p.CountryPrefer.Contains(x.Country) && p.TypePrefer.Contains(x.Type)).Select(x => x.Name)));
            });


            // 9. 列出所有類型的影片總時長，ex: 動漫: 100min
            Console.WriteLine($"{Environment.NewLine}Q: 列出所有類型的影片總時長");
            // 解1
            var all_time = videoList.GroupBy(x => x.Type).Select(x => $"{x.Key}: {x.Sum(y => y.Duration)} min");
            Console.WriteLine(string.Join(Environment.NewLine, all_time));


            // 10. 列出所有國家出產的影片數量，ex: 日本: 3部
            Console.WriteLine($"{Environment.NewLine}Q: 列出所有國家出產的影片數量");
            // 解1
            var group_country = videoList.GroupBy(x => x.Country).ToList();
            foreach (var item in group_country)
            {
                Console.WriteLine($"{item.Key}: {item.Count()}部");
            }
            // 解2
            videoList.GroupBy(x => x.Country).Select(x => $"{x.Key} : {x.Count()}部");


            Console.ReadLine();
        }
    }
}
