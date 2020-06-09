using NetEmu.Models;
using NetEmu.Views.Custom;
using System;
using static NetEmu.Models.Enum.EnumCollection;

using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Xamarin.Essentials;
using System.Threading.Tasks;
using System.Diagnostics;

namespace NetEmu.Services
{
    public class UserServices
    {
        public static bool hasUserData { get; set; } = false;
         public static UserModel User { get; set; }
        public static async Task SaveUserData(string id, string name, string nickname, Gender gender) {
            var user = new UserModel()
            {
                ID = id,
                Name = name,
                Nickname = nickname,
                Gender = gender
            };
            var serial = JsonConvert.SerializeObject(user);
            try {
              await  SecureStorage.SetAsync("user",serial);
               await LoadUserData();
            } catch (Exception ex) {
                Debug.WriteLine(">> error saving: "+ex.ToString());
                CocoSharpControlUI.DisplayAlert("Error","Saving failed...");
                return;
            }
        }

        public static async Task<bool> LoadUserData()
        {
            var success = false;
            try {
                User = new UserModel();
                var des =await SecureStorage.GetAsync("user");
                User = JsonConvert.DeserializeObject<UserModel>(des);
                success = true;
                hasUserData = true;
            } catch (Exception ex) {
                Debug.WriteLine(">> error loading: " + ex.ToString());
                //CocoSharpControlUI.DisplayAlert("Error", "Load failed...");
                success = false;
                hasUserData = false;
            }

            return success;
        }
        public static bool DeleteUserData()
        {
            var success = false;
            try
            {
                User = new UserModel();
                SecureStorage.Remove("user");
             //   User = JsonConvert.DeserializeObject<UserModel>(des);
                success = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">> error loading: " + ex.ToString());
                //CocoSharpControlUI.DisplayAlert("Error", "Load failed...");
                success = false;

            }

            return success;
        }
    }
}
