﻿using AzRBlog.Entities;

namespace AzRBlog.Services
{

    public interface IUserProfileService : IBaseService<UserProfile>
    {
        UserProfile GetById(long id);
    }
}
