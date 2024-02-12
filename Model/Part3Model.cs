using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace MVP.Model
{
    public class Part3Model : IPart3Model
    {
    public static class BitMixEncrypt
    {
        public delegate void EncodeBitHandler(string message);
        public delegate void ReturnDoubleValue(double value);
        public static event EncodeBitHandler EncodeFinished;
        public static event ReturnDoubleValue SetMaximum;
        public static event ReturnDoubleValue SetValue;

        public static void EncryptDecrypt(string iFineName, string oFileName, int[] mix, bool NeedEncrypt = false)
        {
            long i = 0;

            using (FileStream iFileStream = new FileStream(iFineName, FileMode.Open))
            {
                var lenght = iFileStream.Length;
                SetMaximum(lenght);
                using (FileStream oFileStream = new FileStream(oFileName, FileMode.Create))
                {
                    while (lenght > i)
                    {
                        var bt = (byte)iFileStream.ReadByte();
                        if (NeedEncrypt)
                        {
                            oFileStream.WriteByte(MixBitsE(bt, mix));
                        }
                        else
                        {
                            oFileStream.WriteByte(MixBitsD(bt, mix));
                        }
                        i++;
                        SetValue.Invoke(i);
                    }
                    EncodeFinished($"Файл\n{iFineName}\nуспешно зашифрован\n\nСоздан файл\n{oFileName}\nс шифротекстом");
                }
            }

        }

        private static byte MixBitsE(byte num, int[] mix)
        {
            int answer = 0;
            foreach (int index in mix)
            {
                int hit = (byte)((num & (1 << index)) >> index);
                answer = answer | hit;
                answer = answer << 1;
            }

            answer = answer >> 1;
            return (byte)answer;
        }

        private static byte MixBitsD(byte num, int[] mix)
        {
            int answer = 0;
            for (int i = 7; i >= 0; i--)
            {
                answer = answer | ((num & (1 << i)) >> i) << mix[7 - i];
                /*int hit = (byte)((num & (1 << mix[i])) >> index);
                answer = answer | hit;
                answer = answer << 1;*/
            }
            /*foreach (int index in mix)
            {
                int hit = (byte)((num & (1 << index)) >> index);
                answer = answer | hit;
                answer = answer << 1;
            }

            answer = answer >> 1;*/
            return (byte)answer;
        }
    }

    public static class VernamEncrypt
    {
        public delegate void EncodeBitHandler(string message);
        public delegate void ReturnDoubleValue(double value);
        public static event EncodeBitHandler EncodeFinished;
        public static event ReturnDoubleValue SetMaximum;
        public static event ReturnDoubleValue SetValue;

        static Random rnd = new Random();

        public static void Encrypt(string iFineName, string oFileName, string keyFileName)
        {
            long i = 0;

            using (FileStream iFileStream = new FileStream(iFineName, FileMode.Open))
            {
                var lenght = iFileStream.Length;
                SetMaximum(lenght);
                using (FileStream oFileStream = new FileStream(oFileName, FileMode.Create))
                {
                    using (FileStream keyFileStream = new FileStream(keyFileName, FileMode.Create))
                    {
                        while (lenght > i)
                        {
                            var bt = (byte)iFileStream.ReadByte();
                            byte key = (byte)rnd.Next();
                            //oFileStream.WriteByte((byte)(bt ^ key));
                            oFileStream.WriteByte(EncodeBytes(bt, key));
                            keyFileStream.WriteByte(key);
                            i++;
                            SetValue.Invoke(i);
                        }
                        EncodeFinished($"Файл\n{iFineName}\nуспешно зашифрован\n\nСоздан файл\n{oFileName}\nс шифротекстом\n\nКлюч сохранён в файле\n{keyFileName}");
                    }
                }
            }
        }

        public static void Decrypt(string iFineName, string oFileName, string keyFileName)
        {
            long i = 0;

            using (FileStream iFileStream = new FileStream(iFineName, FileMode.Open))
            {
                var lenght = iFileStream.Length;
                SetMaximum(lenght);
                using (FileStream oFileStream = new FileStream(oFileName, FileMode.Create))
                {
                    using (FileStream keyFileStream = new FileStream(keyFileName, FileMode.Open))
                    {
                        while (lenght > i)
                        {
                            var bt = (byte)iFileStream.ReadByte();
                            byte key = (byte)keyFileStream.ReadByte();
                            //oFileStream.WriteByte((byte)(bt ^ key));
                            oFileStream.WriteByte(EncodeBytes(bt, key));
                            i++;
                            SetValue.Invoke(i);
                        }
                        EncodeFinished($"Файл\n{iFineName}\nуспешно дешифрован\n\nСоздан файл\n{oFileName}\nс открытым текстом");
                    }
                }
            }

            //File.Delete(keyFileName);
        }

        private static byte EncodeBytes(byte num, byte key)
        {
            return (byte)(num ^ key);
        }
    }

    public enum CouplingMode
    {
        ECB,
        CBC,
        CFB,
        OFB
    }

    public static class CryptFile
    {
        public delegate void EncodeBitHandler(string message);
        public delegate void ReturnDoubleValue(double value);
        public static event EncodeBitHandler EncodeFinished;
        public static event ReturnDoubleValue SetMaximum;
        public static event ReturnDoubleValue SetValue;

        private static double codingValue = 0;
        private static void Write(string message)
        {
            using (StreamWriter log = new StreamWriter("log.txt", true))
            {
                log.WriteLine(message);
            }
        }

        private static UInt64 _key;
        private static long _wasEncrypted;

        private static List<UInt64> _blocks = new List<ulong>();
        public static CouplingMode SetCouplingMode { get; set; }
        public static UInt64 IV { get; set; }

        public static void StartEncryptDecrypt(string iFileName, string oFileName, UInt64 key, CouplingMode couplingMode, bool isEncrypt = true)
        {
            codingValue = 0;
            _key = key;
            _wasEncrypted = 0;

            FileStream iFStream = new FileStream(iFileName, FileMode.Open);
            using (BinaryReader iFileStream = new BinaryReader(iFStream))
            {
                var lenght = iFStream.Length;//количество байт
                SetMaximum.Invoke(lenght * 3 / 8);
                ulong blocks = (ulong)lenght / (ulong)8;//количество unsigned long int (UInt64)
                ulong cryptedBlocks = 0;
                UInt64 block = 0;
                _blocks.Clear();
                using (BinaryWriter oFileStream = new BinaryWriter(new FileStream(oFileName, FileMode.Create)))
                {
                    while (blocks > cryptedBlocks)
                    {
                        block = iFileStream.ReadUInt64();
                        _blocks.Add(block);
                        //Write(block.ToString());
                        block = 0;

                        cryptedBlocks++;

                        codingValue++;
                        SetValue.Invoke(codingValue);
                    }

                    if (isEncrypt)
                    {
                        if (lenght % 8 != 0)
                        {
                            for (int i = 0; i < lenght % 8; i++)
                            {
                                var bt = (byte)iFileStream.ReadByte();
                                block = block << 8;
                                block |= bt;
                            }
                            block = MakeFullBlock(block, (int)(lenght % 8));
                        }
                        else
                        {
                            block = 8;
                        }
                        _blocks.Add(block);
                        //Write(block.ToString());
                        codingValue++;
                        SetValue.Invoke(codingValue);
                    }

                    List<UInt64> newBlocks = new List<ulong>();

                    switch (SetCouplingMode)
                    {
                        case CouplingMode.ECB:
                            newBlocks = ECB(isEncrypt);
                            break;
                        case CouplingMode.CBC:
                            newBlocks = CBC(isEncrypt);
                            break;
                        case CouplingMode.CFB:
                            newBlocks = CFB(isEncrypt);
                            break;
                        case CouplingMode.OFB:
                            newBlocks = OFB(isEncrypt);
                            break;
                    }

                    for (int i = 0; i < newBlocks.Count; i++)
                    {
                        var tmpBlock = newBlocks[i];
                        if (!isEncrypt && i == newBlocks.Count - 1)
                        {
                            var tmp = MakeCuttedBlock(tmpBlock);
                            if (tmp.Length != 10)
                            {
                                foreach (var b in tmp)
                                {
                                    oFileStream.Write(b);
                                }
                            }
                        }
                        else
                        {
                            oFileStream.Write(tmpBlock);
                            //Write(tmpBlock.ToString());
                        }
                        codingValue++;
                        SetValue.Invoke(codingValue);
                    }

                    EncodeFinished($"Файл\n{iFileName}\nуспешно зашифрован\n\nСоздан файл\n{oFileName}\nс шифротекстом");
                }
            }
        }

        private static ulong MakeFullBlock(ulong block, int significantByte)
        {
            int zeros = 8 - significantByte;
            ulong result = block << (8 * zeros);
            result |= (ulong)zeros;
            return result;
        }

        private static byte[] MakeCuttedBlock(ulong block)
        {
            List<byte> result = new List<byte>();
            ulong mask8 = (1 << 8) - 1;
            while (block > 0)
            {
                result.Add((byte)(block & mask8));
                block = block >> 8;
            }
            int unsignificantBytes = result[0];
            if (unsignificantBytes == 8)
                return new byte[10];
            result.Reverse();
            result.RemoveRange(8 - unsignificantBytes, unsignificantBytes);

            return result.ToArray();
        }

        private static List<UInt64> ECB(bool isEncrypt = true)
        {
            List<UInt64> result = new List<ulong>();

            foreach (var block in _blocks)
            {
                result.Add((isEncrypt) ? (DES.EncodeBlock(block, _key)) : (DES.DecodeBlock(block, _key)));
                codingValue++;
                SetValue.Invoke(codingValue);
            }

            return result;
        }

        private static List<UInt64> CBC(bool isEncrypt = true)
        {
            List<UInt64> result = new List<ulong>();
            UInt64 c = IV;

            foreach (var block in _blocks)
            {
                if (isEncrypt)
                {
                    var newBlock = c ^ block;
                    var tmp = DES.EncodeBlock(newBlock, _key);
                    c = tmp;
                    result.Add(tmp);
                }
                else
                {
                    var decryptedBlock = DES.DecodeBlock(block, _key);
                    var tmpBlock = block;
                    result.Add(c ^ decryptedBlock);
                    c = tmpBlock;
                }
                codingValue++;
                SetValue.Invoke(codingValue);
            }

            return result;
        }

        private static List<UInt64> CFB(bool isEncrypt = true)
        {
            UInt64 c = IV;
            List<UInt64> result = new List<ulong>();

            foreach (var block in _blocks)
            {
                var tmpC = DES.EncodeBlock(c, _key);
                if (isEncrypt)
                {
                    var tmp = block ^ tmpC;
                    result.Add(tmp);
                    c = tmp;
                }
                else
                {
                    c = block;
                    result.Add(block ^ tmpC);
                }
                codingValue++;
                SetValue.Invoke(codingValue);
            }

            return result;
        }

        private static List<UInt64> OFB(bool isEncrypt = true)
        {
            UInt64 c = IV;
            List<UInt64> result = new List<ulong>();

            foreach (var block in _blocks)
            {
                var tmpC = DES.EncodeBlock(c, _key);
                result.Add(block ^ tmpC);
                c = tmpC;
                codingValue++;
                SetValue.Invoke(codingValue);
            }

            return result;
        }
    }

    public static class DES
    {
        private static readonly int[] _initialPermutation = new[]
        {
            58, 50, 42, 34, 26, 18, 10, 2,
            60, 52, 44, 36, 28, 20, 12, 4,
            62, 54, 46, 38, 30, 22, 14, 6,
            64, 56, 48, 40, 32, 24, 16, 8,
            57, 49, 41, 33, 25, 17,  9, 1,
            59, 51, 43, 35, 27, 19, 11, 3,
            61, 53, 45, 37, 29, 21, 13, 5,
            63, 55, 47, 39, 31, 23, 15, 7
        };

        private static readonly int[] _inverseInitialPermutation = new[]
        {
            40, 8, 48, 16, 56, 24, 64, 32,
            39, 7, 47, 15, 55, 23, 63, 31,
            38, 6, 46, 14, 54, 22, 62, 30,
            37, 5, 45, 13, 53, 21, 61, 29,
            36, 4, 44, 12, 52, 20, 60, 28,
            35, 3, 43, 11, 51, 19, 59, 27,
            34, 2, 42, 10, 50, 18, 58, 26,
            33, 1, 41, 9,  49, 17, 57, 25
        };

        private static readonly int[] _extentionPermutation = new[]
        {
            32, 1,   2,  3,  4,  5,
             4, 5,   6,  7,  8,  9,
             8, 9,  10, 11, 12, 13,
            12, 13, 14, 15, 16, 17,
            16, 17, 18, 19, 20, 21,
            20, 21, 22, 23, 24, 25,
            24, 25, 26, 27, 28, 29,
            28, 29, 30, 31, 32,  1
        };

        private static readonly int[,,] _sBoxes = new[, ,]
        {
            {//S1
                { 14,  4, 13,  1,  2, 15, 11,  8,  3, 10,  6, 12,  5,  9,  0,  7},
                {  0, 15, 7,   4, 14,  2, 13,  1, 10,  6, 12, 11,  9,  5,  3,  8},
                {  4,  1, 14,  8, 13,  6,  2, 11, 15, 12,  9,  7,  3, 10,  5,  0},
                { 15, 12, 8,   2,  4,  9,  1,  7,  5, 11,  3, 14, 10,  0,  6, 13}
            },
            {//S2
                { 15,  1,  8, 14,  6, 11,  3,  4,  9,  7,  2, 13, 12,  0,  5, 10},
                {  3, 13,  4,  7, 15,  2,  8, 14, 12,  0,  1, 10,  6,  9, 11,  5},
                {  0, 14,  7, 11, 10,  4, 13,  1,  5,  8, 12,  6,  9,  3,  2, 15},
                { 13,  8, 10,  1,  3, 15,  4,  2, 11,  6,  7, 12,  0,  5, 14,  9}
            },
            {//S3
                { 10,  0,  9, 14,  6,  3, 15,  5,  1, 13, 12,  7, 11,  4,  2,  8},
                { 13,  7,  0,  9,  3,  4,  6, 10,  2,  8,  5, 14, 12, 11, 15,  1},
                { 13,  6,  4,  9,  8, 15,  3,  0, 11,  1,  2, 12,  5, 10, 14,  7},
                {  1, 10, 13,  0,  6,  9,  8,  7,  4, 15, 14,  3, 11,  5,  2, 12}
            },
            {//S4
                {  7, 13, 14,  3,  0,  6,  9, 10,  1,  2,  8,  5, 11, 12,  4, 15},
                { 13,  8, 11,  5,  6, 15,  0,  3,  4,  7,  2, 12,  1, 10, 14,  9},
                { 10,  6,  9,  0, 12, 11,  7, 13, 15,  1,  3, 14,  5,  2,  8,  4},
                { 3,  15,  0,  6, 10,  1, 13,  8,  9,  4,  5, 11, 12,  7,  2, 14}
            },
            {//S5
                {  2, 12,  4,  1,  7, 10, 11,  6,  8,  5,  3, 15, 13,  0, 14,  9},
                { 14, 11,  2, 12,  4,  7, 13,  1,  5,  0, 15, 10,  3,  9,  8,  6},
                {  4,  2,  1, 11, 10, 13,  7,  8, 15,  9, 12,  5,  6,  3,  0, 14},
                { 11,  8, 12,  7,  1, 14,  2, 13,  6, 15,  0,  9, 10,  4,  5,  3}
            },
            {//S6
                { 12,  1, 10, 15,  9,  2,  6,  8,  0, 13,  3,  4, 14,  7,  5, 11},
                { 10, 15,  4,  2,  7, 12,  9,  5,  6,  1, 13, 14,  0, 11,  3,  8},
                {  9, 14, 15,  5,  2,  8, 12,  3,  7,  0,  4, 10,  1, 13, 11,  6},
                {  4,  3,  2, 12,  9,  5, 15, 10, 11, 14,  1,  7,  6,  0,  8, 13}
            },
            {//S7
                {  4, 11,  2, 14, 15,  0,  8, 13,  3, 12,  9,  7,  5, 10,  6,  1},
                { 13,  0, 11,  7,  4,  9,  1, 10, 14,  3,  5, 12,  2, 15,  8,  6},
                {  1,  4, 11, 13, 12,  3,  7, 14, 10, 15,  6,  8,  0,  5,  9,  2},
                {  6, 11, 13,  8,  1,  4, 10,  7,  9,  5,  0, 15, 14,  2,  3, 12}
            },
            {//S8
                { 13,  2,  8,  4,  6, 15, 11,  1, 10,  9,  3, 14,  5,  0, 12,  7},
                {  1, 15, 13,  8, 10,  3,  7,  4, 12,  5,  6, 11,  0, 14,  9,  2},
                {  7, 11,  4,  1,  9, 12, 14,  2,  0,  6, 10, 13, 15,  3,  5,  8},
                {  2,  1, 14,  7,  4, 10,  8, 13, 15, 12,  9,  0,  3,  5,  6, 11}
            }
        };

        public static readonly int[] _PC_1 = new[]
        {
            57, 49, 41, 33, 25, 17,  9,
             1, 58, 50, 42, 34, 26, 18,
            10,  2, 59, 51, 43, 35, 27,
            19, 11,  3, 60, 52, 44, 36,
            63, 55, 47, 39, 31, 23, 15,
             7, 62, 54, 46, 38, 30, 22,
            14,  6, 61, 53, 45, 37, 29,
            21, 13,  5, 28, 20, 12,  4
        };

        private static readonly int[] _PC_2 = new[]
        {
            14, 17, 11, 24,  1,  5,
             3, 28, 15,  6, 21, 10,
            23, 19, 12,  4, 26,  8,
            16,  7, 27, 20, 13,  2,
            41, 52, 31, 37, 47, 55,
            30, 40, 51, 45, 33, 48,
            44, 49, 39, 56, 34, 53,
            46, 42, 50, 36, 29, 32
        };

        private static readonly int[] P = new[]
        {
            16,  7, 20, 21,
            29, 12, 28, 17,
             1, 15, 23, 26,
             5, 18, 31, 10,
             2,  8, 24, 14,
            32, 27,  3,  9,
            19, 13, 30,  6,
            22, 11,  4, 25
        };

        private static int[] _roundShifts = new int[] { 1, 1, 2, 2, 2, 2, 2, 2, 1, 2, 2, 2, 2, 2, 2, 1 };

        private static UInt64[] _keys = new UInt64[16];

        public static UInt64 EncodeBlock(UInt64 text, UInt64 key)
        {
            var tmpText = Permutation(text, _initialPermutation);
            UInt64 l = tmpText >> 32;
            UInt64 r = tmpText & (((long)1 << 32) - 1);

            InitRoundKeys(key);

            for (int i = 0; i < 16; i++)
            {
                var roundKey = _keys[i];
                UInt64 tmp = RoundFunction(r, roundKey) ^ l;
                l = r;
                r = tmp;
            }

            tmpText = ((UInt64)l << 32) | r;
            tmpText = Permutation(tmpText, _inverseInitialPermutation);

            return tmpText;
        }

        public static UInt64 DecodeBlock(UInt64 text, UInt64 key)
        {
            var tmpText = Permutation(text, _initialPermutation);
            UInt64 l = tmpText >> 32;
            UInt64 r = tmpText & (((long)1 << 32) - 1);

            InitRoundKeys(key);

            for (int i = 15; i >= 0; i--)
            {
                var roundKey = _keys[i];
                UInt64 tmp = RoundFunction(l, roundKey) ^ r;
                r = l;
                l = tmp;
            }

            tmpText = ((UInt64)l << 32) | r;
            tmpText = Permutation(tmpText, _inverseInitialPermutation);

            return tmpText;
        }

        private static UInt64 Permutation(UInt64 num, int[] permutation)
        {
            UInt64 newBlock = 0;
            for (var i = 0; i < permutation.Length; i++)
            {
                var newBt = (num >> (permutation[i] - 1)) & 1;
                newBlock |= (newBt << i);
            }
            return newBlock;
        }

        private static UInt64 ExtentionPermutation(UInt64 num, int[] permutation)
        {
            return Permutation(num, permutation);
        }

        private static UInt64 RoundFunction(UInt64 rigtSideOfText, UInt64 roundKey)
        {
            UInt64 extendedText = ExtentionPermutation(rigtSideOfText, _extentionPermutation);
            extendedText = extendedText ^ roundKey;

            UInt64 mask6 = (1 << 6) - 1;
            UInt64 mask4 = (1 << 4) - 1;
            UInt64 result = 0;

            for (int i = 0; i < 8; i++)
            {
                UInt64 part = extendedText & mask6;
                extendedText = extendedText >> 6;

                var row = (part & 1) | (((part >> 5) & 1) << 1);
                var column = (part >> 1) & mask4;

                var sValue = _sBoxes[i, row, column];

                result = result | (UInt64)(sValue << (4 * i));
            }

            result = Permutation(result, P);
            return result;
        }

        private static UInt64 CyclicShiftLeft(UInt64 num, int shift)
        {
            return ((num << shift) | (num >> (28 - shift))) & ((1 << 28) - 1);
        }

        private static void InitRoundKeys(UInt64 key)
        {
            UInt64 firslyRoundKey = Permutation(key, _PC_1);
            UInt64 D0 = firslyRoundKey >> 28;
            UInt64 C0 = firslyRoundKey & ((1 << 28) - 1);

            for (int round = 0; round < 16; round++)
            {
                int p_i = _roundShifts[round];

                C0 = CyclicShiftLeft(C0, p_i);
                D0 = CyclicShiftLeft(D0, p_i);

                firslyRoundKey = (D0 << 28) | C0;
                UInt64 secondlyRoundKey = Permutation(firslyRoundKey, _PC_2);
                _keys[round] = secondlyRoundKey;
            }
        }
    }

    public static class DefaultDes
    {
        public static void Encrypt(string IFilename, string OFilename, UInt64 Key)
        {
            FileStream fsInput = new FileStream(IFilename, FileMode.Open, FileAccess.Read);
            FileStream fsEncrypted = new FileStream(OFilename, FileMode.Create, FileAccess.Write);
            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();

            //DES.Key = ASCIIEncoding.ASCII.GetBytes(Key);
            DES.Key = BitConverter.GetBytes(Key);
            //DES.IV = ASCIIEncoding.ASCII.GetBytes(Key);
            DES.IV = BitConverter.GetBytes(Key);
            ICryptoTransform desencrypt = DES.CreateEncryptor();
            CryptoStream cryptostream = new CryptoStream(fsEncrypted, desencrypt, CryptoStreamMode.Write);

            byte[] bytearrayinput = new byte[fsInput.Length];
            fsInput.Read(bytearrayinput, 0, bytearrayinput.Length);
            cryptostream.Write(bytearrayinput, 0, bytearrayinput.Length);
            cryptostream.Close();
            fsInput.Close();
            fsEncrypted.Close();

        }

        public static void Decrypt(string IFilename, string OFilename, UInt64 Key)
        {
            //Создать поток файлов, чтобы прочитать зашифрованный файл 
            FileStream fsread = new FileStream(IFilename, FileMode.Open, FileAccess.Read);
            FileStream fsDecrypted = new FileStream(OFilename, FileMode.Create, FileAccess.Write);
            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
            //Для этого провайдера требуется 64-битный ключ и IV. 
            //Установить секретный ключ для алгоритма DES 
            //DES.Key = ASCIIEncoding.ASCII.GetBytes(Key);
            DES.Key = BitConverter.GetBytes(Key);
            //Установить вектор инициализации 
            //DES.IV = ASCIIEncoding.ASCII.GetBytes(Key);
            DES.IV = BitConverter.GetBytes(Key);


            //Создать DES-расшифровщик из экземпляра DES 
            ICryptoTransform desdecrypt = DES.CreateDecryptor();
            // Создаем криптовый поток, установленный для чтения и выполнения 
            // Дешифрование DES для входящих байтов 
            CryptoStream cryptostream = new CryptoStream(fsDecrypted, desdecrypt, CryptoStreamMode.Write);

            byte[] bytearrayinput = new byte[fsread.Length];
            fsread.Read(bytearrayinput, 0, bytearrayinput.Length);
            cryptostream.Write(bytearrayinput, 0, bytearrayinput.Length);
            cryptostream.Close();
            fsread.Close();
            fsDecrypted.Close();
        }
    }

    public static class RC4
    {
        public delegate void EncodeBitHandler(string message);
        public delegate void ReturnDoubleValue(double value);
        public static event EncodeBitHandler EncodeFinished;
        public static event ReturnDoubleValue SetMaximum;
        public static event ReturnDoubleValue SetValue;

        static readonly int RC4_SIZE = 256;

        static byte[] S = new byte[RC4_SIZE];

        static int i;
        static int j;

        private static void Init_S(string key)
        {
            i = 0;
            j = 0;
            for (i = 0; i < RC4_SIZE; i++)
            {
                S[i] = (byte)i;
            }

            for (i = 0; i < RC4_SIZE; i++)
            {
                j = (j + S[i] + key[i % key.Length]) % RC4_SIZE;
                var tmp = S[i];
                S[i] = S[j];
                S[j] = tmp;
            }

            i = 0;
            j = 0;
        }

        public static void EncryptDecrypt(string iFileName, string oFileName, string key)
        {
            long l = 0;
            Init_S(key);

            using (FileStream iFileStream = new FileStream(iFileName, FileMode.Open))
            {
                var lenght = iFileStream.Length;
                SetMaximum(lenght);
                using (FileStream oFileStream = new FileStream(oFileName, FileMode.Create))
                {
                    while (lenght > l)
                    {
                        i = (i + 1) % RC4_SIZE;
                        j = (j + S[i]) % RC4_SIZE;
                        var tmp = S[i];
                        S[i] = S[j];
                        S[j] = tmp;
                        var t = (S[i] + S[j]) % RC4_SIZE;
                        var K = S[t];
                        var bt = (byte)iFileStream.ReadByte();
                        oFileStream.WriteByte((byte)((int)bt ^ (int)K));
                        l++;
                        SetValue.Invoke(l);
                    }
                    EncodeFinished($"Файл\n{iFileName}\nуспешно зашифрован\n\nСоздан файл\n{oFileName}\nс шифротекстом");
                }
            }

        }

    }
    }
}
