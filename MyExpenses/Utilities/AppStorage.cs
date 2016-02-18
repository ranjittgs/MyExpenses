
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace MyExpenses.Utilities
{
    public static class AppStorage
    {
        public static async void CreateFileAsync(string desiredName)
        {
            StorageFile strmTempFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(desiredName,
          CreationCollisionOption.ReplaceExisting);
        }

        public static async Task<bool> CreateFileAsync(string desiredName, string contents)
        {
            bool isSuccess = true;
            try
            {
                StorageFile file = await ApplicationData.Current.LocalFolder.CreateFileAsync(desiredName, CreationCollisionOption.ReplaceExisting);
                await FileIO.WriteTextAsync(file, contents);
            }
            catch { isSuccess = false; }
            return isSuccess;
        }
        public static void SaveKeyValue(string key, int value)
        {
            SaveKeyValue(key, value.ToString());
        }
        public static void SaveKeyValue(string key, string value)
        {
            try
            {
                if (ApplicationData.Current.LocalSettings.Values.ContainsKey(key))
                {
                    ApplicationData.Current.LocalSettings.Values.Remove(key);
                }
                ApplicationData.Current.LocalSettings.Values.Add(key, value);
            }
            catch { }
        }
        public static string GetKeyValue(string key)
        {
            try
            {
                if (ApplicationData.Current.LocalSettings.Values.ContainsKey(key))
                    return ApplicationData.Current.LocalSettings.Values[key].ToString();
                else
                    return string.Empty;
            }
            catch { return string.Empty; }
        }
        public static int GetIntValue(string key)
        {
            try
            {
                if (ApplicationData.Current.LocalSettings.Values.ContainsKey(key))
                    return int.Parse(ApplicationData.Current.LocalSettings.Values[key].ToString());
                else
                    return 0;
            }
            catch { return 0; }
        }

        public static void RemoveKey(string key)
        {
            try
            {
                if (ApplicationData.Current.LocalSettings.Values.ContainsKey(key))
                {
                    ApplicationData.Current.LocalSettings.Values.Remove(key);
                }
            }
            catch { }
        }
        public static async Task<bool> CreateFileAsync(string desiredName, byte[] buffer)
        {
            bool isSuccess = true;
            try
            {
                StorageFile file = await ApplicationData.Current.LocalFolder.CreateFileAsync(desiredName, CreationCollisionOption.ReplaceExisting);
                await FileIO.WriteBytesAsync(file, buffer);
            }
            catch { isSuccess = false; }
            return isSuccess;
        }

        public static async Task<Stream> OpenStreamForReadAsync(IStorageFile windowsRuntimeFile)
        {
            try
            {
                return await windowsRuntimeFile.OpenStreamForReadAsync();
            }
            catch { return null; }
        }

        public static async Task<string> GetTextAsync(string name)
        {
            try
            {
                StorageFile file = await ApplicationData.Current.LocalFolder.GetFileAsync(name);
                Stream stream = await file.OpenStreamForReadAsync();
                StreamReader reader = new StreamReader(stream);
                return reader.ReadToEnd();
            }
            catch { return null; }
        }
        public static async Task<string> GetTextAsync(StorageFile file)
        {
            try
            {
                Stream stream = await file.OpenStreamForReadAsync();
                StreamReader reader = new StreamReader(stream);
                return reader.ReadToEnd();
            }
            catch { return null; }
        }

        public static async Task<StorageFile> GetFileAsync(string name)
        {
            try
            {
                return await ApplicationData.Current.LocalFolder.GetFileAsync(name);
            }
            catch { return null; }
        }

        public static void deleteValue(String key)
        {
            try
            {
               
            }
            catch { }
        }
        internal static void clearUploadSettings()
        {
            try
            {
               


               
            }
            catch (Exception e)
            {
            }
        }

        internal static void emptyaLLOfflineCache()
        {
            /*  String folderPath = context.getExternalCacheDir().toString() + AppConstants.GOO_CACHE_PATH;
              clearAllCacheByType(folderPath);

              folderPath = context.getExternalCacheDir().toString() + "/HyperLyncGoo";
              clearAllCacheByType(folderPath);*/
        }

        public static void clearAllCacheByType(String dirType)
        {

        }
    }

}
