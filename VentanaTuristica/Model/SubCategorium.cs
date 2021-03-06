using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Iesi.Collections.Generic;

namespace VentanaTuristica.Model
{
	[Serializable]
	public partial class SubCategorium
	{
        [DataType(DataType.MultilineText)]
		public virtual string Descripcion
		{
			get;
			set;
		}

		public virtual int FkIdSubCategoria
		{
			get;
			set;
		}

        [Required]
		public virtual int IdCategoria
		{
			get;
			set;
		}

        [DataType(DataType.Text)]
        [RegularExpression(@"en-US|es-MX")]
		public virtual string Idioma
		{
			get;
			set;
		}

		public virtual int IdSubCategoria
		{
			get;
			set;
		}

        [Required]
        [DataType(DataType.Text)]
		public virtual string Nombre
		{
			get;
			set;
		}

        public virtual Categorium Categorium
        {
            get;
            set;
        }

        public virtual IList<string> Lugares
        {
            get;
            set;
        }
		
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj))
				return true;
				
			return Equals(obj as SubCategorium);
		}
		
		public virtual bool Equals(SubCategorium obj)
		{
			if (obj == null) return false;

			if (Equals(Descripcion, obj.Descripcion) == false)
				return false;

			if (Equals(FkIdSubCategoria, obj.FkIdSubCategoria) == false)
				return false;

			if (Equals(IdCategoria, obj.IdCategoria) == false)
				return false;

			if (Equals(Idioma, obj.Idioma) == false)
				return false;

			if (Equals(IdSubCategoria, obj.IdSubCategoria) == false)
				return false;

			if (Equals(Nombre, obj.Nombre) == false)
				return false;

			return true;
		}
		
		public override int GetHashCode()
		{
			int result = 1;

			result = (result * 397) ^ (Descripcion != null ? Descripcion.GetHashCode() : 0);
			result = (result * 397) ^ (FkIdSubCategoria != null ? FkIdSubCategoria.GetHashCode() : 0);
			result = (result * 397) ^ (IdCategoria != null ? IdCategoria.GetHashCode() : 0);
			result = (result * 397) ^ (Idioma != null ? Idioma.GetHashCode() : 0);
			result = (result * 397) ^ (IdSubCategoria != null ? IdSubCategoria.GetHashCode() : 0);
			result = (result * 397) ^ (Nombre != null ? Nombre.GetHashCode() : 0);			
			return result;
		}
	}
}