namespace APPseries
{
    public class Series : EntidadeBase
    {
        //Atributos

        private Genero Genero {get; set;}
        private string Titulo {get; set;}
        private string Descricao {get; set;}
        private int Ano {get; set;}
        private bool Excluido {get; set;}

        //Metodos

        public Series(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Genero: " + this.Genero + "\n";
            retorno += "Titulo: " + this.Titulo + "\n";
            retorno += "Descricao: " + this.Descricao + "\n";
            retorno += "Ano de Inicio: " + this.Ano + "\n";
            return retorno;
        }

        public string RetornoTitulo()
        {
            return this.Titulo;
        }
        public int RetornoId()
        {
            return this.Id;
        }
        public void Excluir()
        {
            this.Excluido = true;
        }
    }
}