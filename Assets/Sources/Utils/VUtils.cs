using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Sources.Utils {
    public sealed class VUtils {
        private static readonly string path = Application.persistentDataPath + "/PlayerData.txt";
        private static VUtils instance;

        private VUtils() {
            if(!File.Exists(path)) {
                FileStream file = File.Open(path, FileMode.OpenOrCreate);
                StreamWriter writer = new StreamWriter(file);
                writer.Write("0;0");
                writer.Flush();
                writer.Close();
                file.Close();
            }
        }

        public static VUtils getInstance() {
            if(instance == null) {
                instance = new VUtils();
            }
            return instance;
        }

        public int getLevel() {
            return Convert.ToInt32(File.ReadAllText(path).Split(';')[0]);
        }

        public int getXP() {
            return Convert.ToInt32(File.ReadAllText(path).Split(';')[1]);
        }

        public int getHighscore() {
            return 30;
        }
    }
}