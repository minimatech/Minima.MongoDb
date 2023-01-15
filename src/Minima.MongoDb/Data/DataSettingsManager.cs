// using System.Reflection;
// using System.Text.Json;
//
// namespace Minima.MongoDb.Data;
//
// /// <summary>
// /// Manager of data settings (connection string)
// /// </summary>
// public static class DataSettingsManager
// {
//
//     private static DataSettings _dataSettings;
//
//     private static bool? _databaseIsInstalled;
//
//     private static string _settingsPath =
//         Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/Configuration/mongodb.json";
//
//     /// <summary>
//     /// Load settings
//     /// </summary>
//     public static DataSettings LoadSettings(bool reloadSettings = false)
//     {
//         // if (!reloadSettings && _dataSettings != null)
//         //     return _dataSettings;
//         //
//         // if (!File.Exists(_settingsPath))
//         //     return new DataSettings();
//         //
//         // try
//         // {
//         //     var text = File.ReadAllText(_settingsPath);
//         //     _dataSettings = JsonSerializer.Deserialize<DataSettings>(text);
//         // }
//         // catcha
//         // {
//         //     //Try to read file
//         //     var connectionString = File.ReadLines(_settingsPath).FirstOrDefault();
//         //     _dataSettings = new DataSettings() { ConnectionString = connectionString};
//         //
//         // }
//         return _dataSettings;
//     }
//
//     public static DataSettings LoadDataSettings(DataSettings dataSettings)
//     {
//         _dataSettings = dataSettings;
//         return _dataSettings;
//     }
//
//
//     /// <summary>
//     /// Returns a value indicating whether database is already installed
//     /// </summary>
//     /// <returns></returns>
//     public static bool DatabaseIsInstalled()
//     {
//         if (!_databaseIsInstalled.HasValue)
//         {
//             var settings = _dataSettings ?? LoadSettings();
//             _databaseIsInstalled = settings != null && !string.IsNullOrEmpty(settings.ConnectionString);
//         }
//         return _databaseIsInstalled.Value;
//     }
//
//     public static void ResetCache()
//     {
//         _databaseIsInstalled = false;
//     }
//     
// }