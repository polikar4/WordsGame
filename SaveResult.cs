using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameWorld
{
    public static class SaveResult
    {
        public struct AllGameResult
        {
            public int win;
            public int los;
            public int len;
            public AllGameResult(int win, int los, int len)
            {
                this.win = win;
                this.los = los;
                this.len = len;
            }
        }

        public struct Result
        {
            public AllGameResult[] games;

            public Result(AllGameResult[] games)
            {
                this.games = games;
            }
        }

        public struct GameResult
        {
            public string[] words;
            public string hidden_word;
            public int len;
            public bool win_game;
            public GameResult(string[] words, string hidden_word, int len, bool win_game)
            {
                this.words = words;
                this.hidden_word = hidden_word;
                this.len = len;
                this.win_game = win_game; 
            } 
        }


        public static string path;
        public static string path_result;

        public static Result GetResult()
        {
            string json;
            StreamReader sr = new StreamReader(path_result);
            json = sr.ReadToEnd();
            sr.Close();
            return JsonConvert.DeserializeObject<Result>(json);
        }
        public static void Start()
        {
            // create path to save result games
            path = Application.StartupPath.Split('\\')[0] + '\\' + "Games\\WordGame";

            if (!Directory.Exists(path)) // create directory
                Directory.CreateDirectory(path);

            // create file result
            path_result = path + "\\resultGames.json";
            if (!File.Exists(path_result)) 
            {
                StreamWriter sw = new StreamWriter(path_result);
                AllGameResult[] allGameResults = new AllGameResult[5];
                for(int i = 0; i < allGameResults.Length; i++)
                    allGameResults[i] = new AllGameResult(0,0,i+4);
                Result result = new Result(allGameResults);
                sw.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
                sw.Close();
            }
                

        }

        public static void Save(string[] words, string hidden_word, int len, bool win_game)
        {
            // convert result to game to stuct
            GameResult GameResult = new GameResult(words, hidden_word, len, win_game);

            // save result to json
            StreamWriter sw = new StreamWriter(path + "\\" + GameResult.hidden_word + ".json");
            sw.WriteLine(JsonConvert.SerializeObject(GameResult, Formatting.Indented));
            sw.Close();

            // get all results
            StreamReader sr = new StreamReader(path_result);
            string json = sr.ReadToEnd();
            sr.Close();
            Result result = JsonConvert.DeserializeObject<Result>(json);

            // edit json result
            for(int i = 0; i < result.games.Length; i++)
            {
                if(result.games[i].len == hidden_word.Length)
                {
                    if (win_game)
                        result.games[i].win++;
                    else
                        result.games[i].los++;
                }
            }

            // save result
            sw = new StreamWriter(path_result);
            sw.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
            sw.Close();
        }
    }
}
