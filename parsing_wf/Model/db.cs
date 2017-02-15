using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using Dapper;

namespace parsing_wf.Model
{
        public interface IInfoRepository
        {
            GetSet GetInfo(int id);
            void SaveInfo(GetSet info);
           List<GetSet> GetAll();
           List<GetSet> GetId_Url();
           GetSet GetInfobyURL(string url);
        }
        public class SqLiteBaseRepository
        {
            public static string DbFile
            {
                get { return Environment.CurrentDirectory + "\\SimpleDb.sqlite"; }
            }

            public static SQLiteConnection SimpleDbConnection()
            {
                return new SQLiteConnection("Data Source=" + DbFile);
            }
        }

        public class SqLiteInfoRepository : SqLiteBaseRepository, IInfoRepository
        {
            public List<GetSet> GetAll()
            {
                try
                { 
                if (!File.Exists(DbFile)) return null;

                using (var cnn = SimpleDbConnection())
                {
                    cnn.Open();
                    return cnn.Query<GetSet>("SELECT * FROM Info ").ToList();
                }
                }
                catch (Exception ex) { return null; }
            }
            
            public List<GetSet> GetId_Url()
            {
                try 
                { 
                if (!File.Exists(DbFile)) return null;

                using (var cnn = SimpleDbConnection())
                {
                    cnn.Open();
                    return cnn.Query<GetSet>("SELECT id, url FROM Info ").ToList();
                }
                }
                catch (Exception ex) { return null; }
            }


            public GetSet GetInfo(int id)
            {
                try
                {
                if (!File.Exists(DbFile)) return null;
                using (var cnn = SimpleDbConnection())
                {
                    cnn.Open();
                    GetSet result = cnn.Query<GetSet>(
                        @"SELECT id, url, httpstatus, statusdes, status, title, desc, hrefTag, imgTag, h, time
                    FROM Info
                    WHERE id = @id", new { id }).FirstOrDefault();
                    return result;
                }
                }
                catch (Exception ex) { return null; }
            }

            public GetSet GetInfobyURL(string url)
            {
                try
                {
                    if (!File.Exists(DbFile)) return null;

                    using (var cnn = SimpleDbConnection())
                    {
                        cnn.Open();
                        GetSet result = cnn.Query<GetSet>(
                            @"SELECT id, url, httpstatus, statusdes, status, title, desc, hrefTag, imgTag, h, time
                    FROM Info
                    WHERE url = @url", new { url }).Last();
                        return result;
                    }
                }
                catch (Exception ex) { return null; }
            }

            public void SaveInfo(GetSet info)
            {
                if (! File.Exists(DbFile))
                {
                    CreateDatabase();
                }

                using (var cnn = SimpleDbConnection())
                {
                    cnn.Open();
                    info.id = cnn.Query<int>(
                        @"INSERT INTO Info
                    (  url, httpstatus, statusdes, status, title, desc, hrefTag, imgTag, h, time ) VALUES 
                    (  @url, @httpstatus, @statusdes, @status, @title, @desc, @hrefTag, @imgTag, @h, @time );
                    select last_insert_rowid()", info).Single();
                    GetAlldescnotnull();
                }
            }

            private List<GetSet> GetAlldescnotnull()
            {
                try
                {
                    if (!File.Exists(DbFile)) return null;

                    using (var cnn = SimpleDbConnection())
                    {
                        cnn.Open();
                        return cnn.Query<GetSet>("UPDATE Info SET desc='!!!!! NULL DESCRIPTION FIELD !!!!!' WHERE desc LIKE 'NULL DESCRIPTION FIELD' ").ToList(); 
                    }
                }
                catch (Exception ex) { return null; }
            }

            private static void CreateDatabase()
            {
                using (var cnn = SimpleDbConnection())
                {
                    cnn.Open();
                    cnn.Execute(
                     @"create table Info
                      (
                         id                                  integer primary key AUTOINCREMENT,
                         url                                  varchar(100) not null,
                         httpstatus                        varchar(10) not null,
                         statusdes                            varchar(50) not null,
                         status                            varchar(50) not null,      
                         title ,    
                         desc ,   
                         hrefTag ,   
                         imgTag ,
                         h ,
                         time                           varchar(20) not null
                      )");

                }
            }
        }
    }

