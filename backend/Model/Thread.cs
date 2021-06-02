using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using backend.Model.Sead;

namespace backend.Model
{
    public class Thread
    {
        [Key]
        public int ThreadId { get; set; }
        public int? UserId { get; set; }
        public virtual User User { get; set; }
        public string Titulli { get; set; }
        public int Text { get; set; }
        public string  Date { get; set; }
        public int? NiveliId { get; set; }
        public virtual Niveli Niveli { get; set; }
        public int? DrejtimiId { get; set; }
        public virtual Drejtimet Drejtimi  { get; set; }
        //public int LandaId { get; set; }
       //public virtual Landa Landa { get; set; }
        public string Viti { get; set; }
        public int? CategoriaId { get; set; }
        public virtual  ThreadCategory Categoria { get; set; }
        public virtual List<Posts> Posts { get; set; }
       public virtual List<ReportedThread> Reports { get; set; } 
        public List<Like_Thread> Likes { get; set; }
        
        



    }
}