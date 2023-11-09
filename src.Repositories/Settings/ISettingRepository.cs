using System.Collections.Generic;
using System.Threading.Tasks;
using src.Core.Domains;

namespace src.Repositories.Settings
{
    public interface ISettingRepository
    {
        Setting GetSettingById(int settingId);
        
        string GetSettingByKey(string key, string defaultValue);
        
        T GetSettingByKey<T>(string key, T defaultValue);
        
        IList<Setting> GetAllSettings();

        void ClearCache();

        Task UpdateSettingAsync(Setting setting);
    }
}