# AES - Encryption, Decryption
## 1. Tổng Quan Về Thuật Toán Mã Hoá AES
Chuẩn mã hóa dữ liệu cao cấp AES là một hệ mã khóa bí mật có tên là **Rijndael** (Do hai nhà mật mã học người Bỉ 
là **Joan Daemen** và **Vincent Rijmen** đưa ra và trở thành chuẩn từ năm 2002) cho phép xử lý các khối dữ liệu input
có kích thước `128bit`, sử dụng các khóa có độ dài `128bit` `192bit` hoặc `256 bit`
### Ví Dụ Mã Hoá Với Khoá 128bit:
Với đầu vào bản rõ có chuỗi bit là:
```C#
{0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x61, 0x62, 0x63, 0x64, 0x65, 0x66}
```
Giả sử khoá bí mật là:
```C#
{0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x61, 0x62, 0x63, 0x64, 0x65, 0x66}
```
Bản rõ được mã khoá theo khoá, kết quả thu được bản mã đầu ra là:
```C#
{0x20, 0x5d, 0x1f, 0xc2, 0x71, 0xad, 0xbd, 0xaa, 0x0d, 0xf0, 0x13, 0x4a, 0xaf, 0xce, 0x60, 0xf5}
```
## 2. Chi Tiết Thuật Toán Mã Hoá AES
### 2.1. Dữ Liệu Đầu Vào
Đầu vào của thuật toán được chia thành từng khối dữ liệu `128bit`, và do đặc điểm này, người ta còn gọi AES 
là thuật toán mã hoá khối.</br>
Chuỗi đầu vào được đưa vào ma trận `state [4x4]` theo **qui tắc dọc** với mỗi phần tử của ma trận là 1 byte:</br>
```C#
byte[,] state = {{0x30, 0x34, 0x38, 0x63}
                 {0x31, 0x35, 0x39, 0x64}
                 {0x32, 0x36, 0x61, 0x65}
                 {0x33, 0x37, 0x62, 0x66}}
```
Tương tự như vậy, khoá của thuật toán cũng được lưu vào ma trận `key [4x4]`:
```C#
byte[,] key = {{0x30, 0x34, 0x38, 0x63}
               {0x31, 0x35, 0x39, 0x64}
               {0x32, 0x36, 0x61, 0x65}
               {0x33, 0x37, 0x62, 0x66}}
```
### 2.2. Mô Tả Thuật Toán
### 2.2.1. Tiền Xử Lý
Từ ma trận `key`, ta thực hiện hàm `KeyExpansion` để mở rộng khoá, các khoá(_roundkey_) sẽ được hàm `AddRoundKey` sử dụng tại từng vòng mã hoá.</br>
**KeyExpansion `128bit`:**
```
 30 34 38 63 7c 48 70 13 d1 99 e9 fa 63 fa 13 e9 96 6c 7f 96 ff 93 ec 7a 2f bc 50 2a  1 bd ed c7 e1 5c b1 76 af f3 42 34 72 81 c3 f7
 31 35 39 65 72 47 7e 1b 5b 1c 62 79 26 3a 58 21 ec d6 8e af e0 36 b8 17 dc ea 52 45 6d 87 d5 90 2f a8 7d ed  4 ac d1 3c f4 58 89 b5
 32 36 61 64 7f 49 28 4c 3e 77 5f 13 2b 5c  3 10 ce 92 91 81 ef 7d ec 6d aa d7 3b 56 4c 9b a0 f6 c6 5d fd  b bc e1 1c 17 ef  e 12  5
 33 37 62 65 c8 ff 9d f8 b5 4a d7 2f 98 d2  5 2a 86 54 51 7b 16 42 13 68 cc 8e 9d f5 29 a7 3a cf ef 48 72 bd d7 9f ed 50 cf 50 bd ed
```
  0 |  1 |  2 |  3 |  4 |  5 |  6 |  7 |  8 |  9 |  10|  11|  12|  13|  14|  15|  16|  17|  18|  19|  20|  21|  22|  23|  24|  25|  26|  27|  28|  29|  30|  31|  32|  33|  34|  35|  36|  37|  38|  39|  40|  41|  42|  43
---:|---:|---:|---:|---:|---:|---:|---:|---:|---:|---:|---:|---:|---:|---:|---:|---:|---:|---:|---:|---:|---:|---:|---:|---:|---:|---:|---:|---:|---:|---:|---:|---:|---:|---:|---:|---:|---:|---:|---:|---:|---:|---:|---:
  30|  34|  38|  63|  7c|  48|  70|  13|  d1|  99|  e9|  fa|  63|  fa|  13|  e9|  96|  6c|  7f|  96|  ff|  93|  ec|  7a|  2f|  bc|  50|  2a|   1|  bd|  ed|  c7|  e1|  5c|  b1|  76|  af|  f3|  42|  34|  72|  81|  c3|  f7
  31|  35|  39|  65|  72|  47|  7e|  1b|  5b|  1c|  62|  79|  26|  3a|  58|  21|  ec|  d6|  8e|  af|  e0|  36|  b8|  17|  dc|  ea|  52|  45|  6d|  87|  d5|  90|  2f|  a8|  7d|  ed|   4|  ac|  d1|  3c|  f4|  58|  89|  b5
  32|  36|  61|  64|  7f|  49|  28|  4c|  3e|  77|  5f|  13|  2b|  5c|   3|  10|  ce|  92|  91|  81|  ef|  7d|  ec|  6d|  aa|  d7|  3b|  56|  4c|  9b|  a0|  f6|  c6|  5d|  fd|   b|  bc|  e1|  1c|  17|  ef|   e|  12|   5
  33|  37|  62|  65|  c8|  ff|  9d|  f8|  b5|  4a|  d7|  2f|  98|  d2|   5|  2a|  86|  54|  51|  7b|  16|  42|  13|  68|  cc|  8e|  9d|  f5|  29|  a7|  3a|  cf|  ef|  48|  72|  bd|  d7|  9f|  ed|  50|  cf|  50|  bd|  ed

Tại hàm `AddRoundKey` lần 1, cột `0,1,2,3` sẽ hợp lại thành một roundkey để `XOR` với `state`:
  0 |  1 |  2 |  3 
---:|---:|---:|---:
  30|  34|  38|  63
  31|  35|  39|  65
  32|  36|  61|  64
  33|  37|  62|  65

Lần lượt, tại hàm `AddRoundKey` lần 2, cột `4,5,6,7` được hợp lại tạo thành roundkey thứ 2:
  4 |  5 |  6 |  7 
---:|---:|---:|---:
  7c|  48|  70|  13
  72|  47|  7e|  1b
  7f|  49|  28|  4c
  c8|  ff|  9d|  f8

Đối với khoá `128bit`, Lần thứ 10, roundkey sẽ là:
  40|  41|  42|  43
---:|---:|---:|---:
  72|  81|  c3|  f7
  f4|  58|  89|  b5
  ef|   e|  12|   5
  cf|  50|  bd|  ed

### 2.2.2. Thuật Toán Mã Hoá
Đầu tiên ma trận `state` được cộng với ma trận `key` bằng phép toán `XOR`, sau đó `state` được biến đổi bằng cách thực hiện
một RoundFunction `Nr` lần, mỗi lần sẽ sử dụng một roundkey ở trong bảng KeyExpansion.</br>
`Nr` phụ thuộc vào độ dài khoá là `128bit` `192bit` hoặc `256bit`:
- `128bit` => `Nr` = 10
- `192bit` => `Nr` = 12
- `256bit` => `Nr` = 14

RoundFunction làm một hàm đi thực hiện lần lượt bốn hàm: `SubBytes` `ShiftRows` `MixColumns` `AddRoundKey`.</br>
Riêng vòng cuối cùng thực hiện ba hàm `SubBytes` `ShiftRows` `AddRoundKey`. Trạng thái cuối cùng sẽ được chuyển 
thành đầu ra mã hoá của thuật toán.</br>
_**Lưu ý: code chỉ mang tính chất minh hoạ.**_
```C#
public void Encrypt()
{
    // state xor key
    AddRoundKey(0);
    for (int i = 1; i < Nr; i++)
    {
        // RoundFunction
        SubBytes();
        ShiftRows();
        MixColumns();
        AddRoundKey(i * 4);
    }
    // Vòng cuối
    SubBytes();
    ShiftRows();
    AddRoundKey(Nr * 4);
}
```
### 2.2.3. Thuật Toán Giải Mã
Đối với thuật toán giải mã chỉ đơn giản là ta làm ngược lại so với thuật toán giải mã, ta sử dụng bốn hàm ngịch đảo của 
các hàm `SubBytes` `ShiftRows` `MixColumns` `AddRoundKey`, lần lượt là:
- `InvSubBytes`
- `InvShiftRows`
- `InvMixColumns`
- Riêng hàm `AddRoundKey` là nghịch đảo của chính nó vì sử dụng phép `XOR`

Trình tự thực hiện các hàm là ngược lại so với thuật toán mã hoá:
```C#
public void Decrypt()
{
    AddRoundKey(Nr * 4);
    for (int i = Nr - 1; i >= 1; i--)
    {
        InvShiftRows();
        InvSubBytes();
        AddRoundKey(i * 4);
        InvMixColumns();
    }
    InvShiftRows();
    InvSubBytes();
    AddRoundKey(0);
}
```
### 2.2.4. Hàm SubBytes và InvSubBytes
Hàm SubBytes và InvSubBytes thực hiện thay thế các byte của mảng `state` bằng cách sử dụng một bảng thế Sbox và RSbox.</br>
Chúng ta có thể tính ra bảng Sbox bằng cách nhân ngịch đảo trường hữu hạn GF(2<sup>8</sup>) và sử dụng phép biến đổi 
Affine dưới đây :</br>
<img src="https://latex.codecogs.com/svg.image?b'_i=b_i\oplus&space;b_{(i&plus;4)mod8}\oplus&space;b_{(i&plus;5)mod8}\oplus&space;b_{(i&plus;6)mod8}\oplus&space;b_{(i&plus;7)mod8}" title="b'_i=b_i\oplus b_{(i+4)mod8}\oplus b_{(i+5)mod8}\oplus b_{(i+6)mod8}\oplus b_{(i+7)mod8}" /></br>
Tuy nhiên, mình sẽ sử dụng một bảng Sbox và RSbox đã được tính sẵn:</br>
```C#
static byte[,] Sbox = {
/*           0    1    2    3    4    5    6    7    8    9    a    b    c    d    e    f */
/* 0 */     {0x63,0x7c,0x77,0x7b,0xf2,0x6b,0x6f,0xc5,0x30,0x01,0x67,0x2b,0xfe,0xd7,0xab,0x76},
/* 1 */     {0xca,0x82,0xc9,0x7d,0xfa,0x59,0x47,0xf0,0xad,0xd4,0xa2,0xaf,0x9c,0xa4,0x72,0xc0},
/* 2 */     {0xb7,0xfd,0x93,0x26,0x36,0x3f,0xf7,0xcc,0x34,0xa5,0xe5,0xf1,0x71,0xd8,0x31,0x15},
/* 3 */     {0x04,0xc7,0x23,0xc3,0x18,0x96,0x05,0x9a,0x07,0x12,0x80,0xe2,0xeb,0x27,0xb2,0x75},
/* 4 */     {0x09,0x83,0x2c,0x1a,0x1b,0x6e,0x5a,0xa0,0x52,0x3b,0xd6,0xb3,0x29,0xe3,0x2f,0x84},
/* 5 */     {0x53,0xd1,0x00,0xed,0x20,0xfc,0xb1,0x5b,0x6a,0xcb,0xbe,0x39,0x4a,0x4c,0x58,0xcf},
/* 6 */     {0xd0,0xef,0xaa,0xfb,0x43,0x4d,0x33,0x85,0x45,0xf9,0x02,0x7f,0x50,0x3c,0x9f,0xa8},
/* 7 */     {0x51,0xa3,0x40,0x8f,0x92,0x9d,0x38,0xf5,0xbc,0xb6,0xda,0x21,0x10,0xff,0xf3,0xd2},
/* 8 */     {0xcd,0x0c,0x13,0xec,0x5f,0x97,0x44,0x17,0xc4,0xa7,0x7e,0x3d,0x64,0x5d,0x19,0x73},
/* 9 */     {0x60,0x81,0x4f,0xdc,0x22,0x2a,0x90,0x88,0x46,0xee,0xb8,0x14,0xde,0x5e,0x0b,0xdb},
/* a */     {0xe0,0x32,0x3a,0x0a,0x49,0x06,0x24,0x5c,0xc2,0xd3,0xac,0x62,0x91,0x95,0xe4,0x79},
/* b */     {0xe7,0xc8,0x37,0x6d,0x8d,0xd5,0x4e,0xa9,0x6c,0x56,0xf4,0xea,0x65,0x7a,0xae,0x08},
/* c */     {0xba,0x78,0x25,0x2e,0x1c,0xa6,0xb4,0xc6,0xe8,0xdd,0x74,0x1f,0x4b,0xbd,0x8b,0x8a},
/* d */     {0x70,0x3e,0xb5,0x66,0x48,0x03,0xf6,0x0e,0x61,0x35,0x57,0xb9,0x86,0xc1,0x1d,0x9e},
/* e */     {0xe1,0xf8,0x98,0x11,0x69,0xd9,0x8e,0x94,0x9b,0x1e,0x87,0xe9,0xce,0x55,0x28,0xdf},
/* f */     {0x8c,0xa1,0x89,0x0d,0xbf,0xe6,0x42,0x68,0x41,0x99,0x2d,0x0f,0xb0,0x54,0xbb,0x16},
        };
```
```C#
static byte[,] rsbox = {
/*           0    1    2    3    4    5    6    7    8    9    a    b    c    d    e    f */
/* 0 */     {0x52,0x09,0x6a,0xd5,0x30,0x36,0xa5,0x38,0xbf,0x40,0xa3,0x9e,0x81,0xf3,0xd7,0xfb},
/* 1 */     {0x7c,0xe3,0x39,0x82,0x9b,0x2f,0xff,0x87,0x34,0x8e,0x43,0x44,0xc4,0xde,0xe9,0xcb},
/* 2 */     {0x54,0x7b,0x94,0x32,0xa6,0xc2,0x23,0x3d,0xee,0x4c,0x95,0x0b,0x42,0xfa,0xc3,0x4e},
/* 3 */     {0x08,0x2e,0xa1,0x66,0x28,0xd9,0x24,0xb2,0x76,0x5b,0xa2,0x49,0x6d,0x8b,0xd1,0x25},
/* 4 */     {0x72,0xf8,0xf6,0x64,0x86,0x68,0x98,0x16,0xd4,0xa4,0x5c,0xcc,0x5d,0x65,0xb6,0x92},
/* 5 */     {0x6c,0x70,0x48,0x50,0xfd,0xed,0xb9,0xda,0x5e,0x15,0x46,0x57,0xa7,0x8d,0x9d,0x84},
/* 6 */     {0x90,0xd8,0xab,0x00,0x8c,0xbc,0xd3,0x0a,0xf7,0xe4,0x58,0x05,0xb8,0xb3,0x45,0x06},
/* 7 */     {0xd0,0x2c,0x1e,0x8f,0xca,0x3f,0x0f,0x02,0xc1,0xaf,0xbd,0x03,0x01,0x13,0x8a,0x6b},
/* 8 */     {0x3a,0x91,0x11,0x41,0x4f,0x67,0xdc,0xea,0x97,0xf2,0xcf,0xce,0xf0,0xb4,0xe6,0x73},
/* 9 */     {0x96,0xac,0x74,0x22,0xe7,0xad,0x35,0x85,0xe2,0xf9,0x37,0xe8,0x1c,0x75,0xdf,0x6e},
/* a */     {0x47,0xf1,0x1a,0x71,0x1d,0x29,0xc5,0x89,0x6f,0xb7,0x62,0x0e,0xaa,0x18,0xbe,0x1b},
/* b */     {0xfc,0x56,0x3e,0x4b,0xc6,0xd2,0x79,0x20,0x9a,0xdb,0xc0,0xfe,0x78,0xcd,0x5a,0xf4},
/* c */     {0x1f,0xdd,0xa8,0x33,0x88,0x07,0xc7,0x31,0xb1,0x12,0x10,0x59,0x27,0x80,0xec,0x5f},
/* d */     {0x60,0x51,0x7f,0xa9,0x19,0xb5,0x4a,0x0d,0x2d,0xe5,0x7a,0x9f,0x93,0xc9,0x9c,0xef},
/* e */     {0xa0,0xe0,0x3b,0x4d,0xae,0x2a,0xf5,0xb0,0xc8,0xeb,0xbb,0x3c,0x83,0x53,0x99,0x61},
/* f */     {0x17,0x2b,0x04,0x7e,0xba,0x77,0xd6,0x26,0xe1,0x69,0x14,0x63,0x55,0x21,0x0c,0x7d},
        };
```
Ta thực hiện thay thế bằng hàm:
```C#
byte SubByte(byte alterByte)
{
    return Sbox[(alterByte & 0xf0) >> 4, alterByte & 0xf];
}

byte InvSubByte(byte alterByte)
{
    return RSbox[(alterByte & 0xf0) >> 4, alterByte & 0xf];
}
```
Ví dụ ta có mảng `state`:
  0 |  1 |  2 |  3 
---:|---:|---:|---:
  53|  44|  b8|  b2
  c7|  75|   9|  13
  34|  a6|  f0|  d4
  18|  17|  41|  15

Ta có `state[0,0] = 0x53` được thay bởi phần tử hàng 5, cột 3 tại bảng Sbox được `state[0,0] = 0xed`</br>
Tương tự `state[1,0] = 0xc7` thay bởi phần tử hàng c, cột 7 được `state[1,0] = 0xc6`</br>
### 2.2.5. Hàm ShiftRows Và InvShiftRows
Hàm này thực hiện chức năng xoay trái các hàng ở trong ma trận state.
Đối với hàm `ShiftRows`:
- Hàng 1 giữ im
- Hàng 2 xoay 1 vị trí
- Hàng 3 xoay 2 vị trí
- Hàng 4 xoay 3 vị trí

![ShiftRow](./AES-encrypt/Resources/ShiftRow.PNG)
Đối với hàm `InvShiftRows`:
- Hàng 1 giữ im
- Hàng 2 xoay 3 vị trí
- Hàng 3 xoay 2 vị trí
- Hàng 4 xoay 1 vị trí

![ShiftRow](./AES-encrypt/Resources/InvShiftRow.PNG)
### 2.2.6 Hàm MixColumnms Và InvMixColumns
Hàm `MixColumns` này thực hiện tính toán trên các cột của ma trận `state`, phép biến đổi được thực hiện dựa trên phép nhân ma trận (_**thực hiện trên trường GF(2<sup>8</sup>)**_) sau:</br></br>
<img src="https://latex.codecogs.com/svg.image?\begin{pmatrix}S^{'}_{0,c}&space;\\S^{'}_{1,c}&space;\\S^{'}_{2,c}&space;\\S^{'}_{3,c}\end{pmatrix}=\begin{pmatrix}02&space;&&space;&space;03&&space;&space;01&&space;&space;01\\01&space;&&space;&space;02&&space;&space;03&&space;&space;01\\01&space;&&space;&space;01&&space;&space;02&&space;&space;03\\03&space;&&space;&space;01&&space;&space;01&&space;&space;02\\\end{pmatrix}&space;\begin{pmatrix}S_{0,c}&space;\\S_{1,c}&space;\\S_{2,c}&space;\\S_{3,c}\end{pmatrix}&space;" title="\begin{pmatrix}S^{'}_{0,c} \\S^{'}_{1,c} \\S^{'}_{2,c} \\S^{'}_{3,c}\end{pmatrix}=\begin{pmatrix}02 & 03& 01& 01\\01 & 02& 03& 01\\01 & 01& 02& 03\\03 & 01& 01& 02\\\end{pmatrix} \begin{pmatrix}S_{0,c} \\S_{1,c} \\S_{2,c} \\S_{3,c}\end{pmatrix} " /></br></br>
Hay đơn giản hơn là bốn byte trong mỗi cột sẽ được thay thế theo công thức sau (_**thực hiện trên trường GF(2<sup>8</sup>)**_): </br> </br>
<img src="https://latex.codecogs.com/svg.image?S^{'}_{0,c}=(\{02\}&space;\bullet&space;S_{0,c})\oplus&space;(\{03\}\bullet&space;S_{1,c})\oplus&space;S_{2,c}\oplus&space;S_{3,c}" title="S^{'}_{0,c}=(\{02\} \bullet S_{0,c})\oplus (\{03\}\bullet S_{1,c})\oplus S_{2,c}\oplus S_{3,c}" /></br>
<img src="https://latex.codecogs.com/svg.image?S^{'}_{1,c}=S_{0,c}\oplus&space;(\{02\}\bullet&space;S_{1,c})\oplus&space;(\{03\}\bullet&space;S_{2,c})\oplus&space;S_{3,c}" title="S^{'}_{1,c}=S_{0,c}\oplus (\{02\}\bullet S_{1,c})\oplus (\{03\}\bullet S_{2,c})\oplus S_{3,c}" /></br>
<img src="https://latex.codecogs.com/svg.image?S^{'}_{2,c}=S_{0,c}\oplus&space;S_{1,c}\oplus&space;(\{02\}\bullet&space;S_{2,c})\oplus&space;(\{03\}\bullet&space;S_{3,c})" title="S^{'}_{2,c}=S_{0,c}\oplus S_{1,c}\oplus (\{02\}\bullet S_{2,c})\oplus (\{03\}\bullet S_{3,c})" /></br>
<img src="https://latex.codecogs.com/svg.image?S^{'}_{3,c}=(\{03\}\bullet&space;S_{0,c})\oplus&space;S_{1,c}\oplus&space;S_{2,c}\oplus&space;(\{02\}\bullet&space;S_{3,c})" title="S^{'}_{3,c}=(\{03\}\bullet S_{0,c})\oplus S_{1,c}\oplus S_{2,c}\oplus (\{02\}\bullet S_{3,c})" /></br></br>
Các phép tính ví dụ như: <img src="https://latex.codecogs.com/svg.image?\(\{02\}\bullet&space;S_{0,c}\)" title="\(\{02\}\bullet S_{0,c}\)" /> chính là phép nhân trên trường GF(2<sup>8</sup>), để thực hiện phép nhân này, ta sử dụng hàm sau:
```C#
private byte GMul(byte a, byte b)
{
    byte p = 0;
    for (int counter = 0; counter < 8; counter++)
    {
        if ((b & 1) != 0)
        {
            p ^= a;
        }
        bool hi_bit_set = (a & 0x80) != 0;
        a <<= 1;
        if (hi_bit_set)
        {
            a ^= 0x1B;
        }
        b >>= 1;
    }
    return p;
}
```
Hàm trên thực hiện và trả về tích hai số a và b trên trường hữu hạn GF(2<sup>8</sup>).</br>
Vậy nên hàm `MixColumns` như sau:
```C#
private void MixColumns()
{
    byte[] buffer = new byte[4];
    for (int c = 0; c < 4; c++)
    {
        buffer[0] = (byte)(GMul(0x2, state[0, c]) ^ GMul(0x3, state[1, c]) ^ state[2, c] ^ state[3, c]);
        buffer[1] = (byte)(state[0, c] ^ GMul(0x2, state[1, c]) ^ GMul(0x3, state[2, c]) ^ state[3, c]);
        buffer[2] = (byte)(state[0, c] ^ state[1, c] ^ GMul(0x2, state[2, c]) ^ GMul(0x3, state[3, c]));
        buffer[3] = (byte)(GMul(0x3, state[0, c]) ^ state[1, c] ^ state[2, c] ^ GMul(0x2, state[3, c]));
        state[0, c] = buffer[0];
        state[1, c] = buffer[1];
        state[2, c] = buffer[2];
        state[3, c] = buffer[3];
    }
}
```
Ngược lại là hàm `InvMixColumns`, đối với hàm `InvMixColumns` ta thực hiện phép nhân ma trận sau:</br></br>
<img src="https://latex.codecogs.com/svg.image?\begin{pmatrix}S^{'}_{0,c}&space;\\S^{'}_{1,c}&space;\\S^{'}_{2,c}&space;\\S^{'}_{3,c}\end{pmatrix}=\begin{pmatrix}0e&space;&&space;&space;0b&&space;&space;0d&&space;&space;09\\09&space;&&space;&space;0e&&space;&space;0b&&space;&space;0d\\0d&space;&&space;&space;09&&space;&space;0e&&space;&space;0b\\0b&space;&&space;&space;0d&&space;&space;09&&space;&space;0e\\\end{pmatrix}&space;\begin{pmatrix}S_{0,c}&space;\\S_{1,c}&space;\\S_{2,c}&space;\\S_{3,c}\end{pmatrix}&space;" title="\begin{pmatrix}S^{'}_{0,c} \\S^{'}_{1,c} \\S^{'}_{2,c} \\S^{'}_{3,c}\end{pmatrix}=\begin{pmatrix}0e & 0b& 0d& 09\\09 & 0e& 0b& 0d\\0d & 09& 0e& 0b\\0b & 0d& 09& 0e\\\end{pmatrix} \begin{pmatrix}S_{0,c} \\S_{1,c} \\S_{2,c} \\S_{3,c}\end{pmatrix} " /></br></br>
Hay đơn giản là: </br></br>
<img src="https://latex.codecogs.com/svg.image?S^{'}_{0,c}=\(\{0e\}\bullet&space;S_{0,c}\)\oplus\(\{0b\}\bullet&space;S_{1,c}\)\oplus\(\{0d\}\bullet&space;S_{2,c}\)\oplus\(\{09\}\bullet&space;S_{3,c}\)" title="S^{'}_{0,c}=\(\{0e\}\bullet S_{0,c}\)\oplus\(\{0b\}\bullet S_{1,c}\)\oplus\(\{0d\}\bullet S_{2,c}\)\oplus\(\{09\}\bullet S_{3,c}\)" /></br>
<img src="https://latex.codecogs.com/svg.image?S^{'}_{1,c}=\(\{09\}\bullet&space;S_{0,c}\)\oplus\(\{0e\}\bullet&space;S_{1,c}\)\oplus\(\{0b\}\bullet&space;S_{2,c}\)\oplus\(\{0d\}\bullet&space;S_{3,c}\)" title="S^{'}_{1,c}=\(\{09\}\bullet S_{0,c}\)\oplus\(\{0e\}\bullet S_{1,c}\)\oplus\(\{0b\}\bullet S_{2,c}\)\oplus\(\{0d\}\bullet S_{3,c}\)" /></br>
<img src="https://latex.codecogs.com/svg.image?S^{'}_{2,c}=\(\{0d\}\bullet&space;S_{0,c}\)\oplus\(\{09\}\bullet&space;S_{1,c}\)\oplus\(\{0e\}\bullet&space;S_{2,c}\)\oplus\(\{0b\}\bullet&space;S_{3,c}\)" title="S^{'}_{2,c}=\(\{0d\}\bullet S_{0,c}\)\oplus\(\{09\}\bullet S_{1,c}\)\oplus\(\{0e\}\bullet S_{2,c}\)\oplus\(\{0b\}\bullet S_{3,c}\)" /></br>
<img src="https://latex.codecogs.com/svg.image?S^{'}_{3,c}=\(\{0b\}\bullet&space;S_{0,c}\)\oplus\(\{0d\}\bullet&space;S_{1,c}\)\oplus\(\{09\}\bullet&space;S_{2,c}\)\oplus\(\{0e\}\bullet&space;S_{3,c}\)" title="S^{'}_{3,c}=\(\{0b\}\bullet S_{0,c}\)\oplus\(\{0d\}\bullet S_{1,c}\)\oplus\(\{09\}\bullet S_{2,c}\)\oplus\(\{0e\}\bullet S_{3,c}\)" /></br></br>
Dựa vào đó ta có hàm `InvMixColumns` như sau:
```C#
private void InvMixColumns()
{
    byte[] buffer = new byte[4];
    for (int c = 0; c < 4; c++)
    {
        buffer[0] = (byte)(GMul(0xe, state[0, c]) ^ GMul(0xb, state[1, c]) ^ GMul(0xd, state[2, c]) ^ GMul(0x9, state[3, c]));
        buffer[1] = (byte)(GMul(0x9, state[0, c]) ^ GMul(0xe, state[1, c]) ^ GMul(0xb, state[2, c]) ^ GMul(0xd, state[3, c]));
        buffer[2] = (byte)(GMul(0xd, state[0, c]) ^ GMul(0x9, state[1, c]) ^ GMul(0xe, state[2, c]) ^ GMul(0xb, state[3, c]));
        buffer[3] = (byte)(GMul(0xb, state[0, c]) ^ GMul(0xd, state[1, c]) ^ GMul(0x9, state[2, c]) ^ GMul(0xe, state[3, c]));
        state[0, c] = buffer[0];
        state[1, c] = buffer[1];
        state[2, c] = buffer[2];
        state[3, c] = buffer[3];
    }
}
```
### 2.2.7 Hàm AddRoundKey

### 2.2.8 Hàm KeyExpansion

# 3. Ví Dụ Chi Tiết Các Bước Mã Hoá

# 4. Reference
- https://nvlpubs.nist.gov/nistpubs/fips/nist.fips.197.pdf
- [Giáo trình An toàn và bảo mật thông tin](https://actvneduvn-my.sharepoint.com/:b:/g/personal/ct030433_actvn_edu_vn/EeDoz5wjKZpDjtRVZgIZNxsBz5s_8GviuJQ-rgaNLv_UQA?e=0JJLSM)
- https://github.com/cloudmadeofcandy/AES_implementation
## Wiki
- https://en.wikipedia.org/wiki/Advanced_Encryption_Standard
- https://en.wikipedia.org/wiki/Rijndael_S-box
- https://en.wikipedia.org/wiki/Rijndael_MixColumns
## KeyExpansion
- https://www.brainkart.com/article/AES-Key-Expansion_8410
## Round Constance 192bit - 256bit
- https://crypto.stackexchange.com/questions/81712/rcon-for-aes-192-and-256