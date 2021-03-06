using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Iesi.Collections.Generic;

namespace VentanaTuristica.Model
{
	[Serializable]
	public partial class Idioma
	{
        [Required]
        [DataType(DataType.Text)]
		public virtual string Categoria
		{
			get;
			set;
		}

        [Required]
        [DataType(DataType.MultilineText)]
		public virtual string Descripcion
		{
			get;
			set;
		}

		public virtual int IdIdioma
		{
			get;
			set;
		}

        [Required]
		public virtual int IdPublicacion
		{
			get;
			set;
		}

        [DataType(DataType.MultilineText)]
		public virtual string Notas
		{
			get;
			set;
		}

        [DataType(DataType.MultilineText)]
        [DisplayName("Procesos Ecologicos")]
		public virtual string ProcesosEcologicos
		{
			get;
			set;
		}
		
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj))
				return true;
				
			return Equals(obj as Idioma);
		}
		
		public virtual bool Equals(Idioma obj)
		{
			if (obj == null) return false;

			if (Equals(Categoria, obj.Categoria) == false)
				return false;

			if (Equals(Descripcion, obj.Descripcion) == false)
				return false;

			if (Equals(IdIdioma, obj.IdIdioma) == false)
				return false;

			if (Equals(IdPublicacion, obj.IdPublicacion) == false)
				return false;

			if (Equals(Notas, obj.Notas) == false)
				return false;

			if (Equals(ProcesosEcologicos, obj.ProcesosEcologicos) == false)
				return false;

			return true;
		}
		
		public override int GetHashCode()
		{
			int result = 1;

			result = (result * 397) ^ (Categoria != null ? Categoria.GetHashCode() : 0);
			result = (result * 397) ^ (Descripcion != null ? Descripcion.GetHashCode() : 0);
			result = (result * 397) ^ (IdIdioma != null ? IdIdioma.GetHashCode() : 0);
			result = (result * 397) ^ (IdPublicacion != null ? IdPublicacion.GetHashCode() : 0);
			result = (result * 397) ^ (Notas != null ? Notas.GetHashCode() : 0);
			result = (result * 397) ^ (ProcesosEcologicos != null ? ProcesosEcologicos.GetHashCode() : 0);			
			return result;
		}
	}
}