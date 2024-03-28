using System;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Mirage.Sharp.Asfw
{
  public struct ByteStream : IDisposable
  {
    public byte[] Data;
    public int Head;

    public ByteStream(int initialSize = 4)
    {
      if (initialSize < 1)
        initialSize = 4;
      this.Data = new byte[initialSize];
      this.Head = 0;
    }

    public ByteStream(byte[] bytes)
    {
      this.Data = bytes;
      this.Head = 0;
    }

    public void Dispose()
    {
      this.Data = (byte[]) null;
      this.Head = 0;
    }

    public byte[] ToArray()
    {
      byte[] dst = new byte[this.Head];
      Buffer.BlockCopy((Array) this.Data, 0, (Array) dst, 0, this.Head);
      return dst;
    }

    public byte[] ToPacket()
    {
      byte[] dst = new byte[4 + this.Head];
      Buffer.BlockCopy((Array) BitConverter.GetBytes(this.Head), 0, (Array) dst, 0, 4);
      Buffer.BlockCopy((Array) this.Data, 0, (Array) dst, 4, this.Head);
      return dst;
    }

    private void CheckSize(int length)
    {
      int num = this.Data.Length;
      if (length + this.Head < num)
        return;
      if (num < 4)
        num = 4;
      int length1 = num * 2;
      while (length + this.Head >= length1)
        length1 *= 2;
      byte[] dst = new byte[length1];
      Buffer.BlockCopy((Array) this.Data, 0, (Array) dst, 0, this.Head);
      this.Data = dst;
    }

    public byte[] ReadBlock(int size)
    {
      if (size <= 0 || this.Head + size > this.Data.Length)
        return new byte[0];
      byte[] dst = new byte[size];
      Buffer.BlockCopy((Array) this.Data, this.Head, (Array) dst, 0, size);
      this.Head += size;
      return dst;
    }

    public byte[] ReadBytes()
    {
      if (this.Head + 4 > this.Data.Length)
        return new byte[0];
      int int32 = BitConverter.ToInt32(this.Data, this.Head);
      this.Head += 4;
      if (int32 <= 0 || this.Head + int32 > this.Data.Length)
        return new byte[0];
      byte[] dst = new byte[int32];
      Buffer.BlockCopy((Array) this.Data, this.Head, (Array) dst, 0, int32);
      this.Head += int32;
      return dst;
    }

    public string ReadString()
    {
      if (this.Head + 4 > this.Data.Length)
        return "";
      int int32 = BitConverter.ToInt32(this.Data, this.Head);
      this.Head += 4;
      if (int32 <= 0 || this.Head + int32 > this.Data.Length)
        return "";
      string str = Encoding.UTF8.GetString(this.Data, this.Head, int32);
      this.Head += int32;
      return str;
    }

    public char ReadChar()
    {
      if (this.Head + 2 > this.Data.Length)
        return char.MinValue;
      int num = (int) BitConverter.ToChar(this.Data, this.Head);
      this.Head += 2;
      return (char) num;
    }

    public byte ReadByte()
    {
      if (this.Head + 1 > this.Data.Length)
        return 0;
      int num = (int) this.Data[this.Head];
      ++this.Head;
      return (byte) num;
    }

    public bool ReadBoolean()
    {
        if (this.Head + 1 > this.Data.Length)
            return false; // Or throw an exception if unexpected end of data is an error condition.

        bool result = BitConverter.ToBoolean(this.Data, this.Head);
        this.Head += 1; // Increment the Head to move to the next piece of data.
        return result;
    }

    public short ReadInt16()
    {
      if (this.Head + 2 > this.Data.Length)
        return 0;
      int int16 = (int) BitConverter.ToInt16(this.Data, this.Head);
      this.Head += 2;
      return (short) int16;
    }

    public ushort ReadUInt16()
    {
      if (this.Head + 2 > this.Data.Length)
        return 0;
      int uint16 = (int) BitConverter.ToUInt16(this.Data, this.Head);
      this.Head += 2;
      return (ushort) uint16;
    }

    public int ReadInt32()
    {
      if (this.Head + 4 > this.Data.Length)
        return 0;
      int int32 = BitConverter.ToInt32(this.Data, this.Head);
      this.Head += 4;
      return int32;
    }

    public uint ReadUInt32()
    {
      if (this.Head + 4 > this.Data.Length)
        return 0;
      int uint32 = (int) BitConverter.ToUInt32(this.Data, this.Head);
      this.Head += 4;
      return (uint) uint32;
    }

    public float ReadSingle()
    {
      if (this.Head + 4 > this.Data.Length)
        return 0.0f;
      double single = (double) BitConverter.ToSingle(this.Data, this.Head);
      this.Head += 4;
      return (float) single;
    }

    public long ReadInt64()
    {
      if (this.Head + 8 > this.Data.Length)
        return 0;
      long int64 = BitConverter.ToInt64(this.Data, this.Head);
      this.Head += 8;
      return int64;
    }

    public ulong ReadUInt64()
    {
      if (this.Head + 8 > this.Data.Length)
        return 0;
      long uint64 = (long) BitConverter.ToUInt64(this.Data, this.Head);
      this.Head += 8;
      return (ulong) uint64;
    }

    public double ReadDouble()
    {
      if (this.Head + 8 > this.Data.Length)
        return 0.0;
      double num = BitConverter.ToDouble(this.Data, this.Head);
      this.Head += 8;
      return num;
    }

    public void WriteBlock(byte[] bytes)
    {
      this.CheckSize(bytes.Length);
      Buffer.BlockCopy((Array) bytes, 0, (Array) this.Data, this.Head, bytes.Length);
      this.Head += bytes.Length;
    }

    public void WriteBlock(byte[] bytes, int offset, int size)
    {
      this.CheckSize(size);
      Buffer.BlockCopy((Array) bytes, offset, (Array) this.Data, this.Head, size);
      this.Head += size;
    }

    public void WriteBytes(byte[] value, int offset, int size)
    {
      this.WriteBlock(BitConverter.GetBytes(size));
      this.WriteBlock(value, offset, size);
    }

    public void WriteBytes(byte[] value)
    {
      this.WriteBlock(BitConverter.GetBytes(value.Length));
      this.WriteBlock(value);
    }

    public void WriteString(string value)
    {
      if (value == null)
      {
        this.WriteBlock(BitConverter.GetBytes(0));
      }
      else
      {
        byte[] bytes = Encoding.UTF8.GetBytes(value);
        this.WriteBlock(BitConverter.GetBytes(bytes.Length));
        this.WriteBlock(bytes);
      }
    }

    public void WriteChar(char value) => this.WriteBlock(BitConverter.GetBytes(value));

    public void WriteByte(byte value)
    {
      this.CheckSize(1);
      this.Data[this.Head] = value;
      ++this.Head;
    }

    public void WriteBoolean(bool value) => this.WriteBlock(BitConverter.GetBytes(value));

    public void WriteInt16(short value) => this.WriteBlock(BitConverter.GetBytes(value));

    public void WriteUInt16(ushort value) => this.WriteBlock(BitConverter.GetBytes(value));

    public void WriteInt32(int value) => this.WriteBlock(BitConverter.GetBytes(value));

    public void WriteUInt32(uint value) => this.WriteBlock(BitConverter.GetBytes(value));

    public void WriteSingle(float value) => this.WriteBlock(BitConverter.GetBytes(value));

    public void WriteInt64(long value) => this.WriteBlock(BitConverter.GetBytes(value));

    public void WriteUInt64(ulong value) => this.WriteBlock(BitConverter.GetBytes(value));

    public void WriteDouble(double value) => this.WriteBlock(BitConverter.GetBytes(value));

    private class AsfwBinder : SerializationBinder
    {
      public override Type BindToType(string assemblyName, string typeName)
      {
        if (assemblyName == null)
          throw new ArgumentNullException(nameof (assemblyName));
        assemblyName = Assembly.GetEntryAssembly()?.FullName;
        return Type.GetType(typeName + ", " + assemblyName);
      }
    }
  }
}
