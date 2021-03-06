using System;
using System.ComponentModel.DataAnnotations;
using Iesi.Collections.Generic;

namespace VentanaTuristica.Model
{
	[Serializable]
	public partial class Servicio
	{

        [DataType(DataType.MultilineText)]
		public virtual string Descripcion
		{
			get;
			set;
		}

		public virtual int? FkIdServicio
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

		public virtual int IdServicio
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
		
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj))
				return true;
				
			return Equals(obj as Servicio);
		}
		
		public virtual bool Equals(Servicio obj)
		{
			if (obj == null) return false;

			if (Equals(Descripcion, obj.Descripcion) == false)
				return false;

			if (Equals(FkIdServicio, obj.FkIdServicio) == false)
				return false;

			if (Equals(Idioma, obj.Idioma) == false)
				return false;

			if (Equals(IdServicio, obj.IdServicio) == false)
				return false;

			if (Equals(Nombre, obj.Nombre) == false)
				return false;

			return true;
		}
		
		public override int GetHashCode()
		{
			int result = 1;

			result = (result * 397) ^ (Descripcion != null ? Descripcion.GetHashCode() : 0);
			result = (result * 397) ^ (FkIdServicio != null ? FkIdServicio.GetHashCode() : 0);
			result = (result * 397) ^ (Idioma != null ? Idioma.GetHashCode() : 0);
			result = (result * 397) ^ (IdServicio != null ? IdServicio.GetHashCode() : 0);
			result = (result * 397) ^ (Nombre != null ? Nombre.GetHashCode() : 0);			
			return result;
		}
	}
}