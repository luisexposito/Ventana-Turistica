using System;
using System.ComponentModel.DataAnnotations;
using Iesi.Collections.Generic;

namespace VentanaTuristica.Model
{
	[Serializable]
	public partial class CarpetaViajera
	{
        [Required]
		public virtual int IdPublicacion
		{
			get;
			set;
		}

        [Required]
		public virtual string IdUsuario
		{
			get;
			set;
		}
		
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj))
				return true;
				
			return Equals(obj as CarpetaViajera);
		}
		
		public virtual bool Equals(CarpetaViajera obj)
		{
			if (obj == null) return false;

			if (Equals(IdPublicacion, obj.IdPublicacion) == false)
				return false;

			if (Equals(IdUsuario, obj.IdUsuario) == false)
				return false;

			return true;
		}
		
		public override int GetHashCode()
		{
			int result = 1;

			result = (result * 397) ^ (IdPublicacion != null ? IdPublicacion.GetHashCode() : 0);
			result = (result * 397) ^ (IdUsuario != null ? IdUsuario.GetHashCode() : 0);			
			return result;
		}
	}
}