﻿namespace School.Data.MongoDb
{
    public interface IDbSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
