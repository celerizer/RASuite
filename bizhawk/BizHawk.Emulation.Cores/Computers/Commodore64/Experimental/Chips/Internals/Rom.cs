﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BizHawk.Common;

namespace BizHawk.Emulation.Cores.Computers.Commodore64.Experimental
{
	public class Rom
	{
		int addressMask;
		int[] memory;

		public Rom(int size, int addressMask, byte[] data)
		{
			this.addressMask = addressMask;
			this.memory = new int[size];
			for (int i = 0; i < size; i++)
				memory[i] = data[i];
		}

		public int Peek(int addr)
		{
			return memory[addr & addressMask];
		}

		public int Read(int addr)
		{
			return memory[addr & addressMask];
		}

		public void SyncState(Serializer ser) { SaveState.SyncObject(ser, this); }
	}
}
