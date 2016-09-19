using Sisacon.Domain;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Sisacon.Infra
{
    public class Files
    {
        private string ApplicationPath { get; set; }

        public Files(string applicationPath)
        {
            ApplicationPath = applicationPath;
        }

        public async Task createUserPathAsync(User user)
        {
            try
            {
                await Task.Run(() => {

                    return createUserPath(user);

                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool createUserPath(User user)
        {
            var created = false;

            try
            {
                if(Directory.Exists(ApplicationPath))
                {
                    var userPath = string.Concat(ApplicationPath, user.Email);

                    if(!Directory.Exists(userPath))
                    {
                        created = createPath(userPath);
                    }
                }
                else
                {
                    createPath(ApplicationPath);
                }
            }
            catch (Exception ex)
            {
                throw ex;          
            }

            return created;
        }

        private bool createPath(string path)
        {
            var created = false;

            try
            {
                Directory.CreateDirectory(path);

                created = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return created;
        }
    }
}
