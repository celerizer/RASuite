﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BizHawk.Common;

namespace BizHawk.Emulation.Cores.Computers.Commodore64.Experimental
{
	sealed public class Ram
	{
		int addressMask;
		int dataMask;
		int[] memory;

		public Ram(int size, int addressMask, int dataMask)
		{
			this.addressMask = addressMask;
			this.dataMask = dataMask;
			this.memory = new int[size];
		}

		public int Peek(int addr)
		{
			return memory[addr & addressMask];
		}

		public void Poke(int addr, int val)
		{
			memory[addr & addressMask] = val;
		}

		public int Read(int addr)
		{
			return memory[addr & addressMask];
		}

		public void Write(int addr, int val)
		{
			memory[addr & addressMask] = val & dataMask;
		}

		public void SyncState(Serializer ser) { SaveState.SyncObject(ser, this); }
	}
}
