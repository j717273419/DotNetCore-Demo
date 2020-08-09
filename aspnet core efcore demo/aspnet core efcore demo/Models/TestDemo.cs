using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet_core_efcore_demo.Models
{
    public class TestDemo
    {
        public async void TestSQliteCRUD()
        {
            using (DbContext db = new YpfDbContext())
            {
                //1.新增
                UserInfor userInfor = new UserInfor()
                {
                    id = Guid.NewGuid().ToString("N"),
                    userName = "ypf",
                    userSex = "男"
                };
                await db.Set<UserInfor>().AddAsync(userInfor);
                int count = await db.SaveChangesAsync();
                Console.WriteLine($"成功插入{count}条数据");

                //2.查询全部
                List<UserInfor> uList = db.Set<UserInfor>().ToList();
                foreach (var item in uList)
                {
                    Console.WriteLine($"id为：{item.id},名字为：{item.userName},性别为：{item.userSex}");
                }

                //3.修改
                //sqlite根据主键查询记录
                var updateModel = db.Set<UserInfor>().Find("46455da9c8b24a7c9d5c155955aa0b76");
                if (updateModel != null)
                {
                    updateModel.userSex = "female";
                    db.Update(updateModel);
                    db.SaveChanges();
                    Console.WriteLine($"修改成功{updateModel.userName}");
                }

                //4.删除
                var deleteModel = db.Set<UserInfor>().Find("46455da9c8b24a7c9d5c155955aa0b76");
                if (deleteModel != null)
                {
                    db.Remove(deleteModel);
                    db.SaveChanges();
                    Console.WriteLine($"删除成功{deleteModel.userName}");
                }
                //5。sqlite在netcore中使用where查询
                var sqliteQuery = db.Set<UserInfor>().AsQueryable().Where(p => p.userName == "foo").FirstOrDefault();
                if (!string.IsNullOrWhiteSpace(sqliteQuery?.id))
                {
                    sqliteQuery.userSex = "male";
                    db.Update(sqliteQuery);
                    db.SaveChanges();
                    Console.WriteLine($"sqlite在netcore下使用where查询成功{sqliteQuery.userName}");
                }

                //5.直接执行sql select
                Console.WriteLine($"sqlite在netcore下使用sql查询=====================");
                var sqlResult = db.Set<UserInfor>().FromSqlRaw<UserInfor>("select * from UserInfors where username ='ypf'");
                foreach (var item in sqlResult)
                {
                    Console.WriteLine($"sqlite在netcore下使用sql查询成功{item.id},{item.userName},{item.userSex}");
                }

                //6.直接执行sql parameterized 参数化sql
                Console.WriteLine($"sqlite在netcore下直接执行sql parameterized 参数化sql查询=====================");
                var p1 = new SqliteParameter();
                p1.ParameterName = "@sex";
                p1.Value = "直男";
                var executeNum = db.Database.ExecuteSqlRaw("update UserInfors set usersex = @sex where usersex='男'", p1);
                if (executeNum > 0)
                {
                    Console.WriteLine($"直接执行sql parameterized 参数化sql成功{executeNum}");
                }
            }
        }
    }
}
