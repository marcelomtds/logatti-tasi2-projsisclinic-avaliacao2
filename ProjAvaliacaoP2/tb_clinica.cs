//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjAvaliacaoP2
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_clinica
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_clinica()
        {
            this.tb_consulta = new HashSet<tb_consulta>();
        }
    
        public int id { get; set; }
        public string nome { get; set; }
        public string telefone { get; set; }
        public Nullable<int> id_endereco { get; set; }
    
        public virtual tb_endereco tb_endereco { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_consulta> tb_consulta { get; set; }
    }
}
