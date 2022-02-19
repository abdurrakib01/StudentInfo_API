using Microsoft.EntityFrameworkCore;
using WEB_API01.Model;


namespace WEB_API01.DBContext
{
    public class studentdbcontext : DbContext
    {
        public studentdbcontext(DbContextOptions<studentdbcontext> options)
            : base(options)
        {

        }
        public DbSet<StudentInfo> Students { get; set; }
    }
}
