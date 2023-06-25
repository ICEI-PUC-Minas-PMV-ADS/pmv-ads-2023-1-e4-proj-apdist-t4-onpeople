namespace OnPeople.Integration.Models.Dashboard;    
    public class ListaMetas
    {
        public string NomeEmpresa { get; set; }
        public int QtdeMetas { get; set; }
        public int QtdeMetasCumpridas { get; set; }
        public double PercentualMetasCumpridas { get; set; }
        public int QtdeMetasNaoCumpridas { get; set; }
        public double PercentualMetasNaoCumpridas { get; set; }

    }