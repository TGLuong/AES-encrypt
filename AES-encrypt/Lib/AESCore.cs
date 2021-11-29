using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AES_encrypt.Lib
{
    internal class AESCore
    {
        private byte[,] state = new byte[4, 4];
        private byte[,] expanKey;
        private byte[] planText;
        private byte[] key;

        public byte[] Encrypt128bit(byte[] planText, byte[] key)
        {
            this.planText = planText;
            this.key = key;
            if (this.key.Length != 16)
            {
                return null;
            }
            else
            {
                int length = this.key.Length;
                if (this.planText.Length % 16 != 0) length = this.planText.Length + (16 - this.planText.Length % 16);
                byte[] result = new byte[length];
                KeyExpantion(4, 10);
                int index = 0;
                int resultIndex = 0;
                while (index < this.planText.Length)
                {
                    for (int m = 0; m < 4; m++)
                    {
                        for (int n = 0; n < 4; n++)
                        {
                            if (index < planText.Length)
                            {
                                state[n, m] = this.planText[index];
                                index++;
                            }
                            else
                            {
                                state[n, m] = 0x00;
                            }
                        }
                    }
                    AddRoundKey(0);
                    for (int i = 1; i <= 9; i++)
                    {
                        SubBytes();
                        ShiftRows();
                        MixColumns();
                        AddRoundKey(i * 4);
                    }
                    SubBytes();
                    ShiftRows();
                    AddRoundKey(40);
                    StateLog();
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            result[resultIndex++] = state[j, i];
                        }
                    }
                }
                return result;
            }
        }

        public byte[] Encrypt192bit(byte[] planText, byte[] key)
        {
            this.planText = planText;
            this.key = key;
            if (this.key.Length != 24)
            {
                return null;
            }
            else
            {
                int length = this.planText.Length;
                if (this.planText.Length % 16 != 0) length = this.planText.Length + (16 - this.planText.Length % 16);
                byte[] result = new byte[length];
                Console.WriteLine(length);
                KeyExpantion(6, 12);
                int index = 0;
                int resultIndex = 0;
                while (index < this.planText.Length)
                {
                    Console.WriteLine($"{index} {this.planText.Length}");
                    for (int m = 0; m < 4; m++)
                    {
                        for (int n = 0; n < 4; n++)
                        {
                            if (index < planText.Length)
                            {
                                state[n, m] = this.planText[index];
                                index++;
                            }
                            else
                            {
                                state[n, m] = 0x00;
                            }
                        }
                    }
                    AddRoundKey(0);
                    for (int i = 1; i <= 11; i++)
                    {
                        SubBytes();
                        ShiftRows();
                        MixColumns();
                        AddRoundKey(i * 4);
                    }
                    SubBytes();
                    ShiftRows();
                    AddRoundKey(48);
                    StateLog();
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            result[resultIndex] = state[j, i];
                            resultIndex++;
                        }
                    }
                }
                return result;
            }
        }

        public byte[] Encrypt256bit(byte[] planText, byte[] key)
        {
            this.planText = planText;
            this.key = key;
            if (this.key.Length != 32)
            {
                return null;
            }
            else
            {
                int length = this.planText.Length;
                if (this.planText.Length % 16 != 0) length = this.planText.Length + (16 - this.planText.Length % 16);
                byte[] result = new byte[length];
                KeyExpantion(8, 14);
                int index = 0;
                int resultIndex = 0;
                while (index < this.planText.Length)
                {
                    for (int m = 0; m < 4; m++)
                    {
                        for (int n = 0; n < 4; n++)
                        {
                            if (index < planText.Length)
                            {
                                state[n, m] = this.planText[index];
                                index++;
                            }
                            else
                            {
                                state[m, n] = 0x00;
                            }
                        }
                    }
                    AddRoundKey(0);
                    for (int i = 1; i <= 13; i++)
                    {
                        SubBytes();
                        ShiftRows();
                        MixColumns();
                        AddRoundKey(i * 4);
                    }
                    SubBytes();
                    ShiftRows();
                    AddRoundKey(56);
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            result[resultIndex] = state[j, i];
                            resultIndex++;
                        }
                    }
                }
                return result;
            }
        }

        private void SubBytes()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    state[i, j] = SubByte(state[i, j]);
                }
            }
        }

        private byte SubByte(byte alterByte)
        {
            int x = alterByte & 0xf;
            int y = (alterByte & 0xf0) >> 4;
            return Sbox.sbox[y, x];
        }

        private void ShiftRows()
        {
            Shift(1, 1);
            Shift(2, 2);
            Shift(3, 3);
        }

        private void Shift(int NRow, int shift)
        {
            for (int i = 1; i <= shift; i++)
            {
                byte temp = state[NRow, 0];
                state[NRow, 0] = state[NRow, 1];
                state[NRow, 1] = state[NRow, 2];
                state[NRow, 2] = state[NRow, 3];
                state[NRow, 3] = temp;
            }
            //StateLog();
        }

        private void MixColumns()
        {
            for (int i = 0; i < 4; i++)
            {
                byte[] a = new byte[4];
                byte[] b = new byte[4];
                byte[] result = new byte[4];

                for (int c = 0; c < 4; c++)
                {
                    a[c] = state[c, i];
                    byte h = (byte)((state[c, i] >> 7) & 1);
                    b[c] = (byte)(state[c, i] << 1);
                    b[c] = (byte)(b[c] ^ h * 0x1b);
                }

                result[0] = (byte)((b[0] ^ a[3] ^ a[2] ^ b[1] ^ a[1]) % 256);
                result[1] = (byte)((b[1] ^ a[0] ^ a[3] ^ b[2] ^ a[2]) % 256);
                result[2] = (byte)((b[2] ^ a[1] ^ a[0] ^ b[3] ^ a[3]) % 256);
                result[3] = (byte)((b[3] ^ a[2] ^ a[1] ^ b[0] ^ a[0]) % 256);
                state[0, i] = result[0];
                state[1, i] = result[1];
                state[2, i] = result[2];
                state[3, i] = result[3];
            }
        }

        private void AddRoundKey(int index)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    state[i, j] ^= expanKey[i, index + j];
                }
            }
        }

        private void KeyExpantion(int Nk, int Nr)
        {
            expanKey = new byte[4, 4 * (Nr + 1)];
            int i = 0;
            while (i < Nk)
            {
                expanKey[0, i] = key[i * 4];
                expanKey[1, i] = key[i * 4 + 1];
                expanKey[2, i] = key[i * 4 + 2];
                expanKey[3, i] = key[i * 4 + 3];
                i++;
            }
            while (i < 4 * (Nr + 1))
            {
                byte[] temp = new byte[4] { expanKey[0, i - 1], expanKey[1, i - 1], expanKey[2, i - 1], expanKey[3, i - 1] };
                if (i % Nk == 0)
                {
                    temp = RotWords(temp);
                    temp[0] = (byte)(SubByte(temp[0]) ^ Sbox.rcon[(i / Nk) - 1]);
                    temp[1] = SubByte(temp[1]);
                    temp[2] = SubByte(temp[2]);
                    temp[3] = SubByte(temp[3]);
                }
                else if (Nk > 6 && i % Nk == 4)
                {
                    temp[0] = SubByte(temp[0]);
                    temp[1] = SubByte(temp[1]);
                    temp[2] = SubByte(temp[2]);
                    temp[3] = SubByte(temp[3]);
                }
                expanKey[0, i] = (byte)(expanKey[0, i - Nk] ^ temp[0]);
                expanKey[1, i] = (byte)(expanKey[1, i - Nk] ^ temp[1]);
                expanKey[2, i] = (byte)(expanKey[2, i - Nk] ^ temp[2]);
                expanKey[3, i] = (byte)(expanKey[3, i - Nk] ^ temp[3]);
                i++;
            }
            ExpanLog(Nr);
            return;
        }
        private byte[] RotWords(byte[] array)
        {
            if (array.Length != 4)
            {
                throw new Exception("RotWords error !");
            }
            byte temp = array[0];
            array[0] = array[1];
            array[1] = array[2];
            array[2] = array[3];
            array[3] = temp;
            return array;
        }

        private void StateLog()
        {
            Console.WriteLine("");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write($"{state[i, j],3:x}");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");
        }

        private void ExpanLog(int Nr)
        {
            Console.WriteLine("");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < (Nr + 1) * 4; j++)
                {
                    Console.Write($"{expanKey[i, j],3:x}");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");
        }
    }
}
