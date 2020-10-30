﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Animals.Core.Interfaces
{
	public interface IFileReader
	{
		bool Open(string path);
		IEnumerable<IAnimal> Read();
	}
}
