using System.Collections.Generic;
using backend.Model.Sead;

namespace backend.Model
{
    public class Thread
    {
        public int ThreadId { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public string Titulli { get; set; }
        public int Text { get; set; }
        public string  Date { get; set; }
        public int NiveliId { get; set; }
        //public virtual Niveli Niveli { get; set; }
        public int DrejtimiId { get; set; }
        //public virtual Drejtimi Drejtimi  { get; set; }
        public int LandaId { get; set; }
       // public virtual Landa Landa { get; set; }
        public int Viti { get; set; }
        public int CategoriaId { get; set; }
        public virtual  ThreadCategory Categoria { get; set; }
        public List<Like_Thread> Likes { get; set; }
        
        



    }
}