using System;
using System.IO;
using YamlDotNet.Serialization;

namespace Indusoft.PPS.StartSecondaryProcessesMiniSolver.Input
{
    /// <summary>
    /// Настройки расчета солвера
    /// </summary>
    public class Settings
    {
        /// <summary>
        /// Начальная дата-время
        /// </summary>
        public DateTime InitialDateTime { get; set; }

        /// <summary>
        /// Чтение настроек из yaml-файла
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static Settings GetFromYamlFile(string fileName)
        {
            //CreateYamlFile(fileName);
            var deserializer = new DeserializerBuilder().IgnoreUnmatchedProperties().Build();
            using var file = new StreamReader(fileName);
            var res = deserializer.Deserialize<Settings>(file);
            return res;
        }

        /// <summary>
        /// Сохранение настроек в yaml-файл
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public void SaveToYamlFile(string fileName)
        {
            var builder = new SerializerBuilder();
            builder = builder.EmitDefaults(); // Для принудительной сериализации 0-вых значений
            var serializer = builder.Build();
            using var file = new StreamWriter(fileName);
            serializer.Serialize(file, this);
            file.Flush();
        }

        /// <summary>
        /// Генератор для трафарета yaml-файла настроек при изменении структуры класса настроек
        /// </summary>
        /// <param name="fileName"></param>
        private static void CreateYamlFile(string fileName)
        {
            var builder = new SerializerBuilder();
            builder.EmitDefaults(); // Для принудительной сериализации 0 значений
            var serializer = builder.Build();
            var settings = new Settings
            {
                InitialDateTime = new DateTime(2020, 9, 7, 9, 0, 0)
            };
            using var file = new StreamWriter(fileName);
            serializer.Serialize(file, settings);
            file.Flush();
        }
    }
}