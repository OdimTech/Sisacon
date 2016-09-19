using Sisacon.BLL;
using Sisacon.Domain;
using Sisacon.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.BLL
{
    public class FilesBLL
    {
        private string ApplicationPath { get; set; }
        public Files files { get; set; }

        public FilesBLL(string applicationPath)
        {
            ApplicationPath = applicationPath;
            files = new Files(ApplicationPath);
        }

        public async Task createUserPathAsync(User user)
        {
            try
            {
                await files.createUserPathAsync(user);
            }
            catch (Exception ex)
            {
                LogBLL<string>.createLogNoResponse(ex);
            }
        }
    }
}
