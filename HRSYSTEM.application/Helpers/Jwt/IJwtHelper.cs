using HRSYSTEM.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSYSTEM.application
{
    public interface IJwtHelper
    {
        string GenerateJWT(UserEntity user);
    }
}
