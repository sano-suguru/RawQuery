using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace RawQuery {
  class Program {
    static void Main(string[] args) => 
      SQLInjectionMeasures3();

    static void ExecRawQuery() {
      using (var context = new BlogContext()) {
        var posts = context.Posts
          .FromSql("select * from Posts") //=> `FromSql`での生クエリは、モデルのすべてのプロパティを返す必要があるためカラムを全て取得
          .ToList();
      }
    }

    static void SqlInjection() {
      using (var context = new BlogContext()) {
        string category = "C#"; //=> 検索条件として渡されたと仮定

#pragma warning disable EF1000 // Possible SQL injection vulnerability.
        var posts = context.Posts
          .FromSql("select * from Posts where Category = '" + category + "' and IsPrivate = 0")
#pragma warning restore EF1000 // Possible SQL injection vulnerability.
          .ToList();

        foreach (var p in posts) {
          Console.WriteLine($@"
          {p.Title}
          {p.Category}
          {(p.IsPrivate ? "非公開" : "公開")}");
        }
      }
    }

    static void SQLInjectionMeasures1() {
      using (var context = new BlogContext()) {
        var category = new SqlParameter("category", "C#");

        var posts = context.Posts
          .FromSql("select * from Posts where Category = @category and IsPrivate = 0", category)
          .ToList();
      }
    }

    static void SQLInjectionMeasures2() {
      using (var context = new BlogContext()) {
        var category = "C#";

        var posts = context.Posts
          .FromSql("select * from Posts where Category = {0} and IsPrivate = 0", category)
          .ToList();
      }
    }

    static void SQLInjectionMeasures3() {
      using (var context = new BlogContext()) {
        var category = "C#";

        var posts = context.Posts
          .FromSql($"select * from Posts where Category = {category} and IsPrivate = 0")
          .ToList();

        foreach (var p in posts) {
          Console.WriteLine($@"
          {p.Title}
          {p.Category}
          {(p.IsPrivate ? "非公開" : "公開")}");
        }
      }
    }
  }
}

